using Inventory.Core.Models;
using Inventory.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.Repository.Repositories
{
    public class StockProductRepository: GenericRepository<StockedProduct>, IStockProductRepository
    {
        public StockProductRepository(InventoryDbContext context) : base(context)
        {
        }
    }
}
