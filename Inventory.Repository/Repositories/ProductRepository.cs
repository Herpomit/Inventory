using Inventory.Core.Models;
using Inventory.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.Repository.Repositories
{
    public class ProductRepository : GenericRepository<Product>, IProdcutRepository
    {
        public ProductRepository(InventoryDbContext context) : base(context)
        {
        }
    }
}
