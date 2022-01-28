using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TeacherTools.Models
{
    [Index(new string[] { "Name", "DateCreate", "Account" }, IsUnique = true, Name = "uCourse")]
    public class Group
    {
        [Column(TypeName = "varchar(30)")]
        public string Name { get; set; }
        public DateTime DateCreate { get; set; }
        public string About { get; set; }
        public List<Student> Students { get; set; } = new List<Student>();
        [Required]
        public Account Account { get; set; }
    }
}
