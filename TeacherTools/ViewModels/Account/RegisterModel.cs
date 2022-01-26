using System.ComponentModel.DataAnnotations;

namespace TeacherTools.ViewModels.Account
{
    public class RegisterModel
    {
        [Required(ErrorMessage = "Не указано имя пользователя")]
        public string Login { get; set; }

        [Required(ErrorMessage = "Не указан пароль пользователя")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Compare("Password", ErrorMessage ="Пароли не совпадают")]
        [DataType(DataType.Password)]
        public string ConfirmPassword { get; set; }
    }
}
