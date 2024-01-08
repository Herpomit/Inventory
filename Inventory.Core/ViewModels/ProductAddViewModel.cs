using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.Core.ViewModels
{
    public class ProductAddViewModel
    {
        [Required(ErrorMessage = "Lütfen Ürün Adı Giriniz!")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Lütfen Ürün Kategorisini Seçiniz!")]
        public int[] categoryIds { get; set; }
    }
}
