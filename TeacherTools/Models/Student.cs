using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TeacherTools.Models
{
    public class Student
    {
        public string FirstName { get; set; }
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
    }
}
