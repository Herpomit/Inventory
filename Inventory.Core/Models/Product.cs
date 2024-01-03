using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.Core.Models
{
    public class Product
    {
        public int Id { get; set; }

        public string Name { get; set; }

        ICollection<ProductCategoryMap> ProductsCategoriesMaps { get; set; }

    }
}
