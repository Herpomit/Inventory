using Inventory.Core.DataTableReturnModels;
using Inventory.Core.Services;
using Microsoft.AspNetCore.Mvc;

namespace Inventory.Web.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ICategoryService _service;

        public CategoryController(ICategoryService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<JsonResult> CategoryList(int draw, int start, int length, string orderColumnName, string orderDir, [FromForm] Search search)
        {
            var data = await _service.CategoryTableAsync(draw, start, length, orderColumnName, orderDir, search);
            return Json(new { draw = data.draw, recordsFiltered = data.recordsTotal, recordsTotal = data.recordsTotal, data = data.data });
        }
    }
}
