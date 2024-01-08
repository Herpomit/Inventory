using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.Core.ViewModels
{
    public class UnitUpdateViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Birim Adı Zorunludur!")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Birim Kodu Zorunludur!")]
        public string Code { get; set; }
    }
}
