using Inventory.Core.DataTableReturnModels;
using Inventory.Core.Models;
using Inventory.Core.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.Core.Services
{
    public interface IUnitService : IService<Unit>
    {
        Task<UnitReturnModel> UnitTableAsync(int draw, int start, int length, string orderColumnName, string orderDir, [FromForm] Search search);
    }

}
