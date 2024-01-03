using Inventory.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.Core.Repositories
{
    public interface IProductCategoryMapRepository : IGenericRepository<ProductCategoryMap>
    {
        IQueryable<ProductCategoryMap> GetByProductId(int productId);
        IQueryable<ProductCategoryMap> GetByCategoryId(int categoryId);
    }
}
