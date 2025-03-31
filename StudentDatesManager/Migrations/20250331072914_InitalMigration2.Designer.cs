﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using StudentDatesManager.Models;

#nullable disable

namespace StudentDatesManager.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20250331072914_InitalMigration2")]
    partial class InitalMigration2
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("StudentDatesManager.Models.SpecialDate", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"));

                    b.Property<bool>("OfficialDate")
                        .HasColumnType("bit");

                    b.Property<DateTime>("StudentSpecialDate")
                        .HasColumnType("datetime2")
                        .HasColumnName("SpecialDate");

                    b.HasKey("id");

                    b.ToTable("SpecialDates");
                });
#pragma warning restore 612, 618
        }
    }
}
