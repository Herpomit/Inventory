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
    public class StockedProductUnitMapService : Service<StockedProductUnitMap>, IStockedProductUnitMapService
    {
        public StockedProductUnitMapService(IGenericRepository<StockedProductUnitMap> repository, IUnitOfWork unitOfWork) : base(repository, unitOfWork)
        {
        }
    }
}
