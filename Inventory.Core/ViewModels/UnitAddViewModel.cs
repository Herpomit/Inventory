using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.Core.ViewModels
{
    public class UnitAddViewModel
    {
        [Required(ErrorMessage = "Ad Alanı Zorunludur!")]
        public string Name { get; set; }

        [Required(ErrorMessage ="Kod Alanı Zorunludur!")]
        public string Code { get; set; }
    }
}
