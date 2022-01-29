using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TeacherTools.Models
{
    [Index("Login", IsUnique = true, Name = "uLogin")]
    public class Account
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Column(TypeName = "varchar(20)")]
        public string Login { get; set; }
        [Required]
        public string Password { get; set; }
        public List<Student> Students { get; set; } = null!;
    }
}
