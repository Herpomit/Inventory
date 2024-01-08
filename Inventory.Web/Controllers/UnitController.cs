using Inventory.Core.DataTableReturnModels;
using Inventory.Core.Services;
using Inventory.Core.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Inventory.Web.Controllers
{
    public class UnitController : Controller
    {
        private readonly IUnitService _service;

        public UnitController(IUnitService service)
        {
            _service = service;
        }

        public async Task<JsonResult> UnitTable(int draw, int start, int length, string orderColumnName, string orderDir, [FromForm] Search search)
        {
            var data = await _service.UnitTableAsync(draw, start, length, orderColumnName, orderDir, search);
            return Json(new { draw = data.draw, recordsFiltered = data.recordsTotal, recordsTotal = data.recordsTotal, data = data.data });
        }

        [HttpGet]
        public async Task<JsonResult> UnitGetById(int id)
        {
            var data = await _service.GetByIdAsync(id);
            return Json(data);
        }

        [HttpPost]
        public async Task<JsonResult> UnitAdd(UnitAddViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return Json(new { errors = ModelState });
            }
            var result = await _service.AddAsync(new()
            {
                Name = model.Name,
                Code = model.Code,
            });

            if (result != null)
            {
                return Json("Birim Başarılı Bir Şekilde Eklendi!");
            }

            ModelState.AddModelError(string.Empty, "Birim Eklenemedi!");
            return Json(new { errors = ModelState });
        }

        [HttpPost]
        public async Task<JsonResult> UnitEdit(UnitUpdateViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return Json(new { errors = ModelState });
            }
            var result = await _service.UpdateAsync(new()
            {
                Id = model.Id,
                Name = model.Name,
                Code = model.Code,
            });

            if (result != null)
            {
                return Json("Birim Başarılı Bir Şekilde Güncellendi!");
            }

            ModelState.AddModelError(string.Empty, "Birim Güncellenemedi!");
            return Json(new { errors = ModelState });
        }

        [HttpDelete]
        public async Task<JsonResult> UnitDelete(int id)
        {
            if (!ModelState.IsValid)
            {
                return Json(new { errors = ModelState });
            }
            var unit = await _service.GetByIdAsync(id);

            if (unit == null)
            {
                ModelState.AddModelError(string.Empty, "Birim Bulunamadı!");
                return Json(new { errors = ModelState });
            }

            var result = await _service.DeleteAsync(unit);

            if (result)
            {
                return Json("Birim Başarılı Bir Şekilde Silindi!");
            }

            ModelState.AddModelError(string.Empty, "Birim Silinemedi!");
            return Json(new { errors = ModelState });
        }
    }
}
