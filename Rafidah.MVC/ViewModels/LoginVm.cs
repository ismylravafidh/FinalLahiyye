using System.ComponentModel.DataAnnotations;

namespace Rafidah.MVC.ViewModels
{
    public class LoginVm
    {
        [Required(ErrorMessage = "UserName Or Email Bos Ola Bilmez")]
        public string UserNameOrEmail { get; set; }
        [Required(ErrorMessage = "Password Bos Ola Bilmez")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
