using System.ComponentModel.DataAnnotations;

namespace MaterialSupport.Core.Dto
{
    public class LoginRequest
    {
        [Required(ErrorMessage = "Поле Имя пользователя должно быть заполнено!")]
        public string Username { get; set; }

        [Required(ErrorMessage = "Поле Пароль должно быть заполнено!")]
        public string Password { get; set; }
    }
}
