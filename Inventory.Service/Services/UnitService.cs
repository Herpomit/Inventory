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
    public class UnitService: Service<Unit>, IUnitService
    {
        public UnitService(IGenericRepository<Unit> repository, IUnitOfWork unitOfWork) : base(repository, unitOfWork)
        {
        }
    }    
}
