using Inventory.Core.DataTableReturnModels;
using Inventory.Core.Services;
using Inventory.Core.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Inventory.Web.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductService _service;
        private readonly IProductCategoryMapService _productCategoryService;

        public ProductController(IProductService service, IProductCategoryMapService productCategoryService)
        {
            _service = service;
            _productCategoryService = productCategoryService;
        }

        public async Task<JsonResult> ProductTable(int draw, int start, int length, string orderColumnName, string orderDir, [FromForm] Search search)
        {
            var data = await _service.ProductTableAsync(draw, start, length, orderColumnName, orderDir, search);
            return Json(new { draw = data.draw, recordsFiltered = data.recordsFiltered, recordsTotal = data.recordsTotal, data = data.data });
        }

        [HttpGet]
        public async Task<JsonResult> GetById(int id)
        {
            var data = await _service.GetByIdAsync(id);
            return Json(data);
        }

        [HttpPost]
        public async Task<JsonResult> Add(ProductAddViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return Json(new { errors = ModelState });
            }

            var result = await _service.AddAsync(new()
            {
                Name = model.Name,
            });

            if (result != null)
            {
                foreach (var item in model.categoryIds)
                {
                    var check = await _productCategoryService.AnyAsync(x => x.CategoryId == item && x.ProductId == result.Id);
                    if (!check)
                    {
                        await _productCategoryService.AddAsync(new()
                        {
                            CategoryId = item,
                            ProductId = result.Id
                        });
                    }
                }

                return Json("Ürün Eklendi!");
            }
            ModelState.AddModelError(string.Empty, "Ürün Eklenemedi!");
            return Json(new { errors = ModelState });
        }

        [HttpPost]
        public async Task<JsonResult> Edit(ProductUpdateViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return Json(new { errors = ModelState });
            }

            var result = await _service.UpdateAsync(new()
            {
                Id = model.Id,
                Name = model.Name,
            });

            if (result != null)
            {
                var all = await _productCategoryService.GetByProductIdAsync(model.Id);
                
                await _productCategoryService.DeleteRangeAsync(all);

                foreach (var item in model.categoryIds)
                {
                    await _productCategoryService.AddAsync(new()
                    {
                        CategoryId = item,
                        ProductId = result.Id
                    });
                }
                return Json("Ürün Güncellendi!");
            }
            ModelState.AddModelError(string.Empty, "Ürün Güncellenemedi!");
            return Json(new { errors = ModelState });
        }

        [HttpDelete]
        public async Task<JsonResult> Delete(int id)
        {
            var data = await _service.GetByIdAsync(id);
            if (data == null)
            {
                return Json(new { success = false, message = "Ürün Bulunamadı!" });
            }

            var result = await _service.DeleteAsync(data);
            if (result)
            {
                var all = await _productCategoryService.GetByProductIdAsync(id);
                await _productCategoryService.DeleteRangeAsync(all);
                return Json("Ürün Silindi!");
            }
            return Json(new { success = false, message = "Ürün Silinemedi!" });
        }

    }
}
