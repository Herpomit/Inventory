using Inventory.Core.DataTableReturnModels;
using Inventory.Core.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Inventory.Core.Services
{
    public interface IUserService<T> where T : class
    {
        Task<IEnumerable<T>> GetAllAsync();

        Task<UserViewModel> GetByIdAsync(int id);

        Task<UserReturnModel> UserTableAsync(int draw, int start, int length, string orderColumnName, string orderDir, [FromForm] Search search);

        Task<(bool isSuccess, string message)> Add(UserAddViewModel model);

        Task<(bool isSuccess, string message)> Update(UserUpdateViewModel model);

        Task<(bool isSuccess, string message)> Delete(int id);

        Task Logout();

        Task<IEnumerable<string>> GetUserRole(int id);

        Task<RoleViewModel> GetRoleUser(int id);

        Task<IEnumerable<RoleViewModel>> GetRolesAsync();

        Task<(bool isSuccess, string message)> LoginAsync(LoginViewModel model);
    }
}
