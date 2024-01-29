using Inventory.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.Core.ViewModels
{
    public class StockProductViewModel
    {
        public StockedProduct StockedProduct { get; set; }

        public List<StockedProductUnitMap> StockedProductUnits { get; set; }
    }
}
