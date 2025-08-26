using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Web.UI.Models
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "Kullanıcı adınız boş olamaz!")]
        [Display(Name = "Kullanıcı Adı")]
        public string Username { get; set; }

        [Required(ErrorMessage = "Parolanız boş olamaz!")]
        [DataType(DataType.Password)]
        [Display(Name = "Parola")]
        public string Password { get; set; }

        [Display(Name = "Beni Hatırla")]
        public bool RememberMe { get; set; }
    }

    public class RegisterViewModel
    {
        [Required(ErrorMessage = "E-postanız boş olamaz!")]
        [EmailAddress(ErrorMessage ="E-posta adresinizi doğru formatta girmediniz!")]
        [Display(Name = "E-posta Adresi")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Kullanıcı adınız boş olamaz!")]
        [Display(Name = "Kullanıcı Adı")]
        [MinLength(3, ErrorMessage = "Kullanıcı adınız 3 karakterden az olamaz!")]
        [MaxLength(15, ErrorMessage = "Kullanıcı adınız 15 karakterden fazla olamaz!")]
        public string Username { get; set; }

        [Required(ErrorMessage = "Parolanız boş olamaz!")]
        [DataType(DataType.Password)]
        [Display(Name = "Parola")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Parola onayınız boş olamaz!")]
        [DataType(DataType.Password)]
        [Display(Name = "Parola Onay")]
        [Compare("Password",ErrorMessage ="Lütfen parola ve parola onayınızın aynı olduğundan emin olun!")]
        public string ConfirmPassword { get; set; }
    }
}