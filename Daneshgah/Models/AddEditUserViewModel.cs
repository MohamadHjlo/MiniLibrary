using System.ComponentModel.DataAnnotations;

namespace Daneshgah.Models
{
    public class AddEditUserViewModel
    {
        public int ID { get; set; }

        [Required(ErrorMessage = "نام را وارد کنید")]
        public string Name { get; set; }

        [Required(ErrorMessage = "نام خانوادگی را وارد کنید")]
        public string Family { get; set; }

        [Required(ErrorMessage = "رمز عبور را وارد کنید")]
        public string Password { get; set; }

        [Required(ErrorMessage = "تاریخ تولد را وارد کنید")]

        [MaxLength(4, ErrorMessage = "تاریخ تولد باید چهار رقم باشد")]
        [MinLength(4, ErrorMessage = "تاریخ تولد باید چهار رقم باشد")]
        public string BirthDate { get; set; }

        [Required(ErrorMessage = "ایمیل را وارد کنید")]
        public string Email { get; set; }
    }
}
