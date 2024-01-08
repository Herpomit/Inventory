using Inventory.Core.DataTableReturnModels;
using Inventory.Core.Models;
using Inventory.Core.Repositories;
using Inventory.Core.Services;
using Inventory.Core.UnitOfWorks;
using Inventory.Core.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq.Dynamic.Core;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.Service.Services
{
    public class ProductService : Service<Product>, IProductService
    {
        private readonly IProdcutRepository _prodcutRepository;
        private readonly IProductCategoryMapRepository _productCategoryMapRepository;

        public ProductService(IGenericRepository<Product> repository, IUnitOfWork unitOfWork, IProdcutRepository prodcutRepository, IProductCategoryMapRepository productCategoryMapRepository) : base(repository, unitOfWork)
        {
            _prodcutRepository = prodcutRepository;
            _productCategoryMapRepository = productCategoryMapRepository;
        }

        public async Task<ProductReturnModel> ProductTableAsync(int draw, int start, int length, string orderColumnName, string orderDir, [FromForm] Search search)
        {
            var query = _prodcutRepository.GetAll();

            if (!string.IsNullOrEmpty(search.value))
            {
                query = query.Where(x => x.Name.Contains(search.value));
            }

            if (!string.IsNullOrEmpty(orderColumnName))
            {
                query = query.OrderBy(orderColumnName + " " + orderDir);
            }

            int recordsTotal = await query.CountAsync();

            var data = await query.Skip(start).Take(length).ToListAsync();

            List<ProductViewModel> productViewModels = new List<ProductViewModel>();

            foreach (var item in data)
            {
                productViewModels.Add(new ProductViewModel
                {
                    Id = item.Id,
                    Name = item.Name,
                    CategoryNames = await _productCategoryMapRepository.GetByProductId(item.Id).Select(x => x.Category.Name).ToListAsync()
                });
            }

            return new ProductReturnModel
            {
                draw = draw,
                recordsTotal = recordsTotal,
                recordsFiltered = recordsTotal,
                data = productViewModels
            };
        }
    }
}
