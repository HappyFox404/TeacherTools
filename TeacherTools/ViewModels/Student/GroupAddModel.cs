using System;
using System.ComponentModel.DataAnnotations;

namespace TeacherTools.ViewModels.Student
{
    public class GroupAddModel
    {
        [Required(ErrorMessage = "Не указано имя группы")]
        [StringLength(30, MinimumLength = 3, ErrorMessage = "Длина названия не может быть меньше 3 символов")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Не указана дата формирования группы")]
        public DateTime DateCreate { get; set; }
        public string About { get; set; }
    }
}
