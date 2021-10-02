using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace EmlakProject.Models
{
    public class Login
    {
        [Required(ErrorMessage = "Lütfen kullanıcı adınızı giriniz!")]
        [DisplayName("Kullanıcı Adı")]
        public string Username { get; set; }
        [Required(ErrorMessage = "Lütfen şifrenizi giriniz!")]
        [DisplayName("Şifre")]
        public string Password { get; set; }
        public bool RememberMe { get; set; }
    }
}