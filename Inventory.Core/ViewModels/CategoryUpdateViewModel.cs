using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.Core.ViewModels
{
    public class CategoryUpdateViewModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Kategori Adı Zorunludur!")]
        public string Name { get; set; }
    }
}
