using Inventory.Core.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.Core.DataTableReturnModels
{
    public class ProductReturnModel
    {
        public int draw { get; set; }

        public int recordsFiltered { get; set; }

        public int recordsTotal { get; set; }

        public required List<ProductViewModel> data { get; set; }
    }
}
