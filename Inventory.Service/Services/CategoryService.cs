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
    public class CategoryService : Service<Category>, ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;

        public CategoryService(IGenericRepository<Category> repository, IUnitOfWork unitOfWork, ICategoryRepository categoryRepository) : base(repository, unitOfWork)
        {
            _categoryRepository = categoryRepository;
        }

        public async Task<CategoryReturnModel> CategoryTableAsync(int draw, int start, int length, string orderColumnName, string orderDir, [FromForm] Search search)
        {
            var query = _categoryRepository.GetAll();

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
            List<CategoryViewModel> categoryViewModels = new List<CategoryViewModel>();
            foreach (var item in data)
            {
                categoryViewModels.Add(new CategoryViewModel
                {
                    Id = item.Id,
                    Name = item.Name
                });
            }


            return new CategoryReturnModel
            {
                draw = draw,
                recordsTotal = recordsTotal,
                recordsFiltered = recordsTotal,
                data = categoryViewModels
            };
        }
    }
}
