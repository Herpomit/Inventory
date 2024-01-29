using Inventory.Core.Models;
using Inventory.Core.Repositories;
using Inventory.Core.Services;
using Inventory.Core.UnitOfWorks;
using Inventory.Core.ViewModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.Service.Services
{
    public class StockProductService : Service<StockedProduct>, IStockProductService
    {
        private readonly IStockProductRepository _stockProductRepository;
        private readonly IStockedProductUnitMapRepository _stockedProductUnitMapRepository;

        public StockProductService(IGenericRepository<StockedProduct> repository, IUnitOfWork unitOfWork, IStockProductRepository stockProductRepository, IStockedProductUnitMapRepository stockedProductUnitMapRepository) : base(repository, unitOfWork)
        {
            _stockProductRepository = stockProductRepository;
            _stockedProductUnitMapRepository = stockedProductUnitMapRepository;
        }

        public async Task<List<StockProductViewModel>> GetAllWithProductAsync()
        {
            var allData = await _stockProductRepository.GetAll().Include(x => x.Product).ToListAsync();
            List<StockProductViewModel> stockProductViewModels = new List<StockProductViewModel>();
            foreach (var item in allData)
            {
                stockProductViewModels.Add(new()
                {
                    StockedProduct = item,
                    StockedProductUnits = await _stockedProductUnitMapRepository.GetAll().Where(x => x.stockedProductId == item.Id).Include(x => x.Unit).ToListAsync()
                });
            }

            return stockProductViewModels;
        }
    }
}
