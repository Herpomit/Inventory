using Inventory.Core.DataTableReturnModels;
using Inventory.Core.Services;
using Inventory.Core.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Inventory.Web.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ICategoryService _service;
        private readonly IProductCategoryMapService _productCategoryMapService;

        public CategoryController(ICategoryService service, IProductCategoryMapService productCategoryMapService)
        {
            _service = service;
            _productCategoryMapService = productCategoryMapService;
        }

        public async Task<JsonResult> CategoryTable(int draw, int start, int length, string orderColumnName, string orderDir, [FromForm] Search search)
        {
            var data = await _service.CategoryTableAsync(draw, start, length, orderColumnName, orderDir, search);
            return Json(new { draw = data.draw, recordsFiltered = data.recordsTotal, recordsTotal = data.recordsTotal, data = data.data });
        }

        [HttpPost]
        public async Task<JsonResult> CategoryAdd(CategoryAddViewModel model)
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
                return Json("Kategori Başarılı Bir Şekilde Eklendi!");
            }

            ModelState.AddModelError(string.Empty,"Kategori Eklenemedi!");
            return Json(new { errors = ModelState });
        }

        [HttpGet]
        public async Task<JsonResult> CategoryGetById(int id)
        {
            var result = await _service.GetByIdAsync(id);
            return Json(result);
        }

        [HttpPost]
        public async Task<JsonResult> CategoryEdit(CategoryUpdateViewModel model)
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
                return Json("Kategori Başarılı Bir Şekilde Güncellendi!");
            }

            ModelState.AddModelError(string.Empty, "Kategori Güncellenemedi!");
            return Json(new { errors = ModelState });
        }

        [HttpDelete]
        public async Task<JsonResult> CategoryDelete(CategoryViewModel model)
        {
            var result = await _service.DeleteAsync(new()
            {
                Id = model.Id,
                Name = model.Name,
            });

            if (result)
            {
                var all = await _productCategoryMapService.GetByCategoryIdAsync(model.Id);
                await _productCategoryMapService.DeleteRangeAsync(all);
                return Json("Kategori Başarılı Bir Şekilde Silindi!!");
            }

            ModelState.AddModelError(string.Empty, "Kategori Silinemedi!");
            return Json(new { errors = ModelState });
        }
    }
}
