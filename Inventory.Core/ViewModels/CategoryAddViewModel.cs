using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.Core.ViewModels
{
    public class CategoryAddViewModel
    {
        [Required(ErrorMessage = "Kategori Adı Zorunludur!")]
        public string Name { get; set; }
    }
}
