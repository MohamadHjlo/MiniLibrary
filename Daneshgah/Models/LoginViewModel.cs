using System.ComponentModel.DataAnnotations;

namespace Daneshgah.Models
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "نام را وارد کنید")]
        public string Name { get; set; }

        [Required(ErrorMessage = "رمز عبور را وارد کنید")]
        public string Password { get; set; }
    }
}
