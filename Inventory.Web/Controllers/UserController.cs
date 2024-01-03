using Inventory.Core.DataTableReturnModels;
using Inventory.Core.Services;
using Inventory.Core.ViewModels;
using Inventory.Repository.IdentityModels;
using Inventory.Service.Services;
using Microsoft.AspNetCore.Mvc;

namespace Inventory.Web.Controllers
{
    public class UserController : Controller
    {
        private readonly IUserService<Users> _service;

        public UserController(IUserService<Users> service)
        {
            _service = service;
        }

        public async Task<JsonResult> UserTable(int draw, int start, int length, string orderColumnName, string orderDir, [FromForm] Search search)
        {
            var data = await _service.UserTableAsync(draw, start, length, orderColumnName, orderDir, search);
            return Json(new { draw = data.draw, recordsFiltered = data.recordsFiltered, recordsTotal = data.recordsTotal, data = data.data });
        }

        [HttpPost]
        public async Task<JsonResult> AddJson(UserAddViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return Json(new { errors = ModelState });
            }

            var (isSuccess, message) = await _service.Add(model);

            if (isSuccess)
            {
                return Json(message);
            }
            ModelState.AddModelError("", message);
            return Json(new { errors = ModelState });
        }


        [HttpGet]
        public async Task<JsonResult> UserById(int id)
        {
            var data = await _service.GetByIdAsync(id);
            return Json(data);
        }

        [HttpPost]
        public async Task<JsonResult> EditJson(UserUpdateViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return Json(new { errors = ModelState });
            }

            var (isSuccess, message) = await _service.Update(model);

            if (isSuccess)
            {
                TempData["Message"] = message;
                return Json(message);
            }

            ModelState.AddModelError("", message);
            return Json(new { errors = ModelState });
        }

        [HttpDelete]
        public async Task<JsonResult> DeleteJson(int id)
        {
            var (isSuccess, message) = await _service.Delete(id);

            if (isSuccess)
            {
                return Json(message);
            }

            return Json(message);
        }
    }
}
