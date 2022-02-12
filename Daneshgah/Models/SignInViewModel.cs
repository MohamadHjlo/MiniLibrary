using System.ComponentModel.DataAnnotations;

namespace Daneshgah.Models
{
    public class SignInViewModel
    {
        [Required(ErrorMessage = "نام را وارد کنید")]
        public string Name { get; set; }

        [Required(ErrorMessage = "نام خانوادگی را وارد کنید")]
        public string Family { get; set; }

        [Required(ErrorMessage = "رمز عبور را وارد کنید")]
        public string Password { get; set; }

        [Required(ErrorMessage = "تاریخ تولد را وارد کنید")]
      
        //[RegularExpression(@"^$|^([1۱][۰-۹ 0-9]{3}[/\/]([0 ۰][۱-۶ 1-6])[/\/]([0 ۰][۱-۹ 1-9]|[۱۲12][۰-۹ 0-9]|[3۳][01۰۱])|[1۱][۰-۹ 0-9]{3}[/\/]([۰0][۷-۹ 7-9]|[1۱][۰۱۲012])[/\/]([۰0][1-9 ۱-۹]|[12۱۲][0-9 ۰-۹]|(30|۳۰)))$", ErrorMessage = "تاریخ وارد شده نامعتبر است.")]
        [MaxLength(4,ErrorMessage = "تاریخ تولد باید چهار رقم باشد")]
        [MinLength(4, ErrorMessage = "تاریخ تولد باید چهار رقم باشد")]
        public string BirthDate { get; set; }

        [Required(ErrorMessage = "ایمیل را وارد کنید")]
        public string Email { get; set; }
    }
}
