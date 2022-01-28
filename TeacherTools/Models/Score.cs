using Microsoft.EntityFrameworkCore;
using System;
using System.ComponentModel.DataAnnotations;

namespace TeacherTools.Models
{
    public class Score
    {
        [Required]
        public DateTime DateAppend { get; set; }
        [Required]
        public Student Student { get; set; }
        [Required]
        public Group Group { get; set; }
        [Required]
        public int ScoreNumber { get; set; }
    }
}
