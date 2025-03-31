using System.ComponentModel.DataAnnotations.Schema;

namespace StudentDatesManager.Models
{
    public class SpecialDate
    {
        public int id { get; set; }
        [Column("SpecialDate")]
        public DateOnly StudentSpecialDate { get; set; }
        public bool OfficialDate { get; set; } = true;
    }
}
