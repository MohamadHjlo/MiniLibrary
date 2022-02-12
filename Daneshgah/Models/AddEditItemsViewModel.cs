using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Daneshgah.Models
{
    public class AddEditItemsViewModel
    {
        public int Id { get; set; }

        [DisplayName("عنوان")]
        [Required(ErrorMessage = "عنوان باید وارد شود")]
        public string Title { get; set; }

        [DisplayName("موضوع")]
        [Required(ErrorMessage = "موضوع باید وارد شود")]
        public string Topic { get; set; }

        [DisplayName("شابک")]
        [Required(ErrorMessage = "شابک باید وارد شود")]
        [Range(10000000000, 9999999999999, ErrorMessage = "شابک باید عددی بین 10 تا 13 رقم باشد")]
        public long ISBN { get; set; }

        [DisplayName("تعداد صفحات")]
        [Required(ErrorMessage = "تعداد صفحات باید وارد شود")]
        public int PageCount { get; set; }

        [DisplayName("سال نشر")]
        [Required(ErrorMessage = "سال نشر باید وارد شود")]
        public int PublicationYear { get; set; }

        [DisplayName("ماه")]
        [Required(ErrorMessage = "ماه نشر باید وارد شود")]
        public int PublicationMounth { get; set; }

        [DisplayName("روز")]
        [Required(ErrorMessage = "روز نشر باید وارد شود")]
        public int PublicationDate { get; set; }

        [DisplayName("ناشر")]
        [Required(ErrorMessage = "نام ناشر باید وارد شود")]
        public string Publisher { get; set; }

        
    }
}
