using Inventory.Core.Models;
using Inventory.Core.Repositories;
using Inventory.Core.Services;
using Inventory.Core.UnitOfWorks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.Service.Services
{
    public class StockProductService : Service<StockedProduct>, IStockProductService
    {
        public StockProductService(IGenericRepository<StockedProduct> repository, IUnitOfWork unitOfWork) : base(repository, unitOfWork)
        {
        }
    }
}
