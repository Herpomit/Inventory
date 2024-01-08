using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.Core.ViewModels
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "Eposta Boş Geçilemez.")]
        [EmailAddress(ErrorMessage = "Eposta Adresi Geçersiz!")]
        public string Email { get; set; } = null!;

        [Required(ErrorMessage = "Şifre Boş Geçilemez.")]
        [DataType(DataType.Password)]
        public string Password { get; set; } = null!;

        public bool RememberMe { get; set; }
    }
}
