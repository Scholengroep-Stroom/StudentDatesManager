using Microsoft.AspNetCore.Mvc;
using StudentDatesManager.Models;

namespace StudentDatesManager.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SpecialDatesController : ControllerBase
    {
        private readonly AppDbContext _context;

        public SpecialDatesController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public ActionResult<IEnumerable<SpecialDate>> GetAllDates()
        {
            var dates = _context.SpecialDates
                                .OrderBy(d => d.StudentSpecialDate)
                                .ToList();
            return Ok(dates);
        }

        [HttpPost]
        public ActionResult<SpecialDateDto> PostNewDate([FromBody] SpecialDateDto newDateDto)
        {
            if (newDateDto == null || !DateOnly.TryParse(newDateDto.SpecialDate, out var parsedDate))
            {
                return BadRequest("Invalid date format.");
            }

            var newDate = new SpecialDate
            {
                StudentSpecialDate = parsedDate,
                OfficialDate = newDateDto.OfficialDate
            };

            _context.SpecialDates.Add(newDate);
            _context.SaveChanges();

            var createdDto = new SpecialDateDto
            {
                Id = newDate.id,
                SpecialDate = newDate.StudentSpecialDate.ToString("yyyy-MM-dd"),
                OfficialDate = newDate.OfficialDate
            };

            return CreatedAtAction(nameof(GetAllDates), new { id = newDate.id }, createdDto);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteDate(int id)
        {
            var dateToDelete = _context.SpecialDates.Find(id);
            if (dateToDelete == null)
            {
                return NotFound(new { message = "Special date not found" });
            }

            // Ensure the date is in the future (greater than yesterday)
            if (dateToDelete.StudentSpecialDate <= DateOnly.FromDateTime(DateTime.Today.AddDays(-1)))
            {
                return BadRequest(new { message = "Cannot delete past or current dates" });
            }

            _context.SpecialDates.Remove(dateToDelete);
            _context.SaveChanges();

            var deletedDateDto = new SpecialDateDto
            {
                Id = dateToDelete.id,
                SpecialDate = dateToDelete.StudentSpecialDate.ToString("yyyy-MM-dd"),
                OfficialDate = dateToDelete.OfficialDate
            };

            return Ok(new { message = "Special date deleted successfully", deletedDate = deletedDateDto });
        }


    }
}