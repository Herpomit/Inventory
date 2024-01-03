using Inventory.Core.Models;
using Inventory.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.Repository.Repositories
{
    public class ProductCategoryRepository : GenericRepository<ProductCategoryMap>, IProductCategoryMapRepository
    {
        public ProductCategoryRepository(InventoryDbContext context) : base(context)
        {
        }

        public IQueryable<ProductCategoryMap> GetByCategoryId(int categoryId)
        {
            return _context.ProductCategoryMaps.Where(x => x.CategoryId == categoryId);
        }

        public IQueryable<ProductCategoryMap> GetByProductId(int productId)
        {
            return _context.ProductCategoryMaps.Where(x => x.ProductId == productId);
        }
    }
}
