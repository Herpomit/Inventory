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
    public class UnitService : Service<Unit>, IUnitService
    {
        private readonly IUnitRepository _unitRepository;

        public UnitService(IGenericRepository<Unit> repository, IUnitOfWork unitOfWork, IUnitRepository unitRepository) : base(repository, unitOfWork)
        {
            _unitRepository = unitRepository;
        }

        public async Task<UnitReturnModel> UnitTableAsync(int draw, int start, int length, string orderColumnName, string orderDir, [FromForm] Search search)
        {
            var query = _unitRepository.GetAll();

            if (!string.IsNullOrEmpty(search.value))
            {
                query = query.Where(x => x.Name.Contains(search.value) || x.Code.Contains(search.value));
            }

            if (!string.IsNullOrEmpty(orderColumnName))
            {
                query = query.OrderBy(orderColumnName + " " + orderDir);
            }

            int recordsTotal = await query.CountAsync();

            var data = await query.Skip(start).Take(length).ToListAsync();
            List<UnitViewModel> unitViewModels = new List<UnitViewModel>();

            foreach (var item in data)
            {
                unitViewModels.Add(new UnitViewModel
                {
                    Id = item.Id,
                    Name = item.Name,
                    Code = item.Code
                });
            }

            return new UnitReturnModel
            {
                draw = draw,
                recordsTotal = recordsTotal,
                recordsFiltered = recordsTotal,
                data = unitViewModels
            };

        }

    }
}
