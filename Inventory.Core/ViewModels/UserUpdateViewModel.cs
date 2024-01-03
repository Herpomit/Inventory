using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.Core.ViewModels
{
    public class UserUpdateViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Kullanıcı Adı Boş Geçilemez!")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Email Boş Geçilemez!")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Telefon Numarası Boş Geçilemez!")]
        public string PhoneNumber { get; set; }

        [DataType(DataType.Password)]
        public string? Password { get; set; }

        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "Şifreler Uyuşmuyor!")]
        public string? PasswordConfirm { get; set; }

    }
}
