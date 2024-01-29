using Inventory.Core.Services;
using Inventory.Core.ViewModels;
using Inventory.Repository.IdentityModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Inventory.Web.Controllers
{
    [Authorize(Roles = ("Admin , User"))]
    public class PanelController : Controller
    {
        private readonly IUserService<Users> _userService;
        private readonly IProductService _productService;
        private readonly ICategoryService _categoryService;
        private readonly IProductCategoryMapService _productCategoryMapService;


        private readonly IHttpContextAccessor _httpContextAccessor;
        public PanelController(IUserService<Users> userService, IHttpContextAccessor httpContextAccessor, ICategoryService categoryService, IProductCategoryMapService productCategoryMapService, IProductService productService)
        {
            _userService = userService;
            _httpContextAccessor = httpContextAccessor;
            _categoryService = categoryService;
            _productCategoryMapService = productCategoryMapService;
            _productService = productService;
        }

        private int activeUserId => int.Parse(_httpContextAccessor.HttpContext!.User.FindFirstValue(ClaimTypes.NameIdentifier!)!);

        //void role()
        //{
        //    var role = _userService.GetRoleUser(activeUserId);

        //    if (role.Id == 1)
        //    {
        //        ViewBag.Role = "Admin";
        //    }
        //    else if (role.Id == 2)
        //    {
        //        ViewBag.Role = "User";
        //    }
        //}



        public IActionResult Index()
        {
            return View();
        }

        public IActionResult StockedProducts()
        {
            return View();
        }


        public IActionResult Categories()
        {

            return View();
        }

        public IActionResult Products()
        {

            return View();
        }

        public async Task<IActionResult> ProductAdd()
        {
            var categories = await _categoryService.GetAllAsync();
            ViewBag.Categories = categories;
            return View();
        }

        public async Task<IActionResult> ProductEdit(int id)
        {
            var product = await _productService.GetByIdAsync(id);
            ProductViewModel productViewModel = new ProductViewModel();
            productViewModel.Id = product.Id;
            productViewModel.Name = product.Name;
            var categories = await _categoryService.GetAllAsync();
            var productCategoryMap = await _productCategoryMapService.GetByProductIdAsync(id);
            ViewBag.ProductCategoryMap = productCategoryMap;
            ViewBag.Categories = categories;
            return View(productViewModel);
        }

        #region Units
        public IActionResult Units()
        {

            return View();
        }
        #endregion

        #region Users
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
        #endregion

    }
}
