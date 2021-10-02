using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace EmlakProject.Models
{
    public class ChangePassword
    {
        [Required]
        [DisplayName("Eski Şifre")]
        public string OldPassword { get; set; }
        [Required]
        [DisplayName("Yeni Şifre")]
        [StringLength(100, MinimumLength = 5, ErrorMessage = "Şifreniz en az 5 karakter olmalıdır!")] //En az 5 karakter en fazla 100 karakter
        public string NewPassword { get; set; }
        [Required]
        [DisplayName("Şifre Tekrar")]
        [Compare("NewPassword", ErrorMessage = "Şifreler aynı değil!")] //Şifreleri karşılaştırıyoruz
        public string ConNewPassword { get; set; }
    }
}