using System;
using System.ComponentModel.DataAnnotations;

namespace TeacherTools.ViewModels.Student
{
    public class StudentAddModel
    {
        [Required(ErrorMessage = "Не указано имя")]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "Не указано фамилия")]
        public string LastName { get; set; }
        [Required(ErrorMessage = "Не указана дата рождения")]
        public DateTime Birthday { get; set; }
    }
}
