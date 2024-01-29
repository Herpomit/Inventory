using Inventory.Core.Services;
using Inventory.Core.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Inventory.Web.Controllers
{
    public class StockedProductController : Controller
    {
        private readonly IStockProductService _stockProductService;
        private readonly IStockedProductUnitMapService _stockedProductUnitMapService;

        public StockedProductController(IStockProductService stockProductService, IStockedProductUnitMapService stockedProductUnitMapService)
        {
            _stockProductService = stockProductService;
            _stockedProductUnitMapService = stockedProductUnitMapService;
        }

        [HttpGet]
        public async Task<JsonResult> StockProductTable()
        {
            var allData = await _stockProductService.GetAllWithProductAsync();

            return Json(new { data = allData });
        }

        [HttpGet]
        [Route("/StockedProduct/StockProductById/{stockProductId}")]
        public async Task<JsonResult> StockProductById(int stockProductId)
        {
            var data = await _stockProductService.GetByIdAsync(stockProductId);
            return Json(new { data = data });
        }

        [HttpPost]
        public async Task<JsonResult> AddStockProduct(StockProductAddViewModel stockProduct)
        {
            if (!ModelState.IsValid)
            {
                return Json(new { errors = ModelState });
            }

            var data = await _stockProductService.AddAsync(new()
            {
                ProductId = stockProduct.ProductId,
                Stock = stockProduct.Stock,
                CreatedAt = DateTime.Now,
                UpdatedAt = DateTime.Now
            });



            if (data != null)
            {
                if (!await _stockedProductUnitMapService.AnyAsync(x => x.stockedProductId == data.Id && x.unitId == stockProduct.UnitId ))
                {
                    await _stockedProductUnitMapService.AddAsync(new()
                    {
                        stockedProductId = data.Id,
                        unitId = stockProduct.UnitId
                    });
                }
            }

            ModelState.AddModelError(string.Empty, "Ürün Eklenemedi!");
            return Json(new { errors = ModelState });
        }

        [HttpPost]
        public async Task<JsonResult> Edit()
        {

        }
    }
}
