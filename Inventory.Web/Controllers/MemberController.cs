using Inventory.Core.Services;
using Inventory.Core.ViewModels;
using Inventory.Repository.IdentityModels;
using Microsoft.AspNetCore.Mvc;

namespace Inventory.Web.Controllers
{
    public class MemberController : Controller
    {
        private readonly IUserService<Users> _userService;

        public MemberController(IUserService<Users> userService)
        {
            _userService = userService;
        }

        [Route("/Member/Login")]
        public IActionResult Login()
        {
            return View();
        }

        public async Task<IActionResult> Logout()
        {
            await _userService.Logout();
            return RedirectToAction("Login","Member");
        }

        [HttpPost]
        [Route("/Member/Login")]
        public async Task<JsonResult> Login(LoginViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return Json(new { errors = ModelState });
            }

            var result = await _userService.LoginAsync(model);

            if (result.isSuccess)
            {
                return Json(result.message);
            }

            ModelState.AddModelError("", result.message);
            return Json(new { errors = ModelState });
        }

    }
}
