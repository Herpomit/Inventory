using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.Core.Models
{
    public class StockedProductUnitMap
    {
        public int Id { get; set; }

        public int stockedProductId { get; set; }
        public StockedProduct StockedProduct { get; set; }

        public int unitId { get; set; }
        public Unit Unit { get; set; }

        public decimal weight { get; set; }
    }
}
