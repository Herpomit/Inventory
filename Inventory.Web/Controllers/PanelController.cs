using Inventory.Core.Services;
using Inventory.Repository.IdentityModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Inventory.Web.Controllers
{
    [Authorize(Roles = ("Admin , User"))]
    public class PanelController : Controller
    {
        private readonly IUserService<Users> _userService;

        public PanelController(IUserService<Users> userService)
        {
            _userService = userService;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Categories()
        {
            return View();
        }
        public IActionResult Users()
        {
            return View();
        }

        public async Task<IActionResult> UserAdd()
        {
            var roles = await _userService.GetRolesAsync();

            ViewBag.Roles = roles;

            return View();
        }

        [Route("/Panel/UserEdit/{id}")]
        public async Task<IActionResult> UserEdit(int id)
        { 
            var user = await _userService.GetByIdAsync(id);
            var roles = await _userService.GetRolesAsync();
            var userRole = await _userService.GetUserRole(id);
            ViewBag.Roles = roles;
            ViewBag.UserRole = userRole;
            return View(user);
        }
    }
}
