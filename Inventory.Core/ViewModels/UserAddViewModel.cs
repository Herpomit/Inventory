using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.Core.ViewModels
{
    public class UserAddViewModel
    {
        [Required(ErrorMessage = "Kullanıcı Adı Alanı Zorunludur!")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Eposta Alanı Zorunludur!")]
        [EmailAddress(ErrorMessage = "Eposta Adresi Geçersiz!")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Telefon Numarası Alanı Zorunludur!")]
        public string PhoneNumber { get; set; }

        [Required(ErrorMessage = "Şifre Alanı Zorunludur!")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required(ErrorMessage = "Şifre Tekrar Alanı Zorunludur!")]
        [Compare("Password", ErrorMessage = "Şifreler Uyuşmuyor!")]
        [DataType(DataType.Password)]
        public string PasswordConfirm { get; set; }

        [Required(ErrorMessage = "Yetki Seviyesi Zorunludur!")]
        public int roleId { get; set; }
    }
}
