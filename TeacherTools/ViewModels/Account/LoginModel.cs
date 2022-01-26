using System.ComponentModel.DataAnnotations;

namespace TeacherTools.ViewModels.Account
{
    public class LoginModel
    {
        [Required(ErrorMessage = "Не указано имя пользователя")]
        public string Login { get; set; }
        [Required(ErrorMessage = "Не указан пароль пользователя")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
