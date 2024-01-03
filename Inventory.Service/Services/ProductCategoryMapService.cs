using Inventory.Core.Models;
using Inventory.Core.Repositories;
using Inventory.Core.Services;
using Inventory.Core.UnitOfWorks;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.Service.Services
{
    public class ProductCategoryMapService: Service<ProductCategoryMap> , IProductCategoryMapService
    {
        private readonly IProductCategoryMapRepository _productCategoryMapRepository;

        public ProductCategoryMapService(IGenericRepository<ProductCategoryMap> repository, IUnitOfWork unitOfWork, IProductCategoryMapRepository productCategoryMapRepository) : base(repository, unitOfWork)
        {
            _productCategoryMapRepository = productCategoryMapRepository;
        }

        public async Task<IEnumerable<ProductCategoryMap>> GetByCategoryIdAsync(int categoryId)
        {
            return await _productCategoryMapRepository.GetByCategoryId(categoryId).ToListAsync();
        }

        public async Task<IEnumerable<ProductCategoryMap>> GetByProductIdAsync(int productId)
        {
            return await _productCategoryMapRepository.GetByProductId(productId).ToListAsync();
        }
    }
}
