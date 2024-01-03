using Inventory.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.Core.Services
{
    public interface IProductCategoryMapService : IService<ProductCategoryMap>
    {
        Task<IEnumerable<ProductCategoryMap>> GetByProductIdAsync(int productId);
        Task<IEnumerable<ProductCategoryMap>> GetByCategoryIdAsync(int categoryId);
    }
}
