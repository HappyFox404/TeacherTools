using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TeacherTools.Models
{
    [Index(new string[] { "FirstName", "LastName", "Birthday", "Account" }, IsUnique = true, Name = "uStudent")]
    public class Student
    {
        [Column(TypeName = "varchar(20)")]
        public string FirstName { get; set; }
        [Column(TypeName = "varchar(20)")]
        public string LastName { get; set; }
        [NotMapped]
        public string FullName
        {
            get
            {
                return LastName + " " + FirstName;
            }
        }
        public DateTime Birthday { get; set; }
        [NotMapped]
        public int Age
        {
            get
            {
                int age = DateTime.Now.Year - Birthday.Year;
                if (DateTime.Now.DayOfYear < Birthday.DayOfYear)
                    return ++age;
                return age;
            }
        }
        public List<Group> Groups { get; set; } = new List<Group>();
        [Required]
        public Account Account { get; set; }
    }
}
