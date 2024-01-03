using Inventory.Core.DataTableReturnModels;
using Inventory.Core.Services;
using Inventory.Core.ViewModels;
using Inventory.Repository.IdentityModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq.Dynamic.Core;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.Service.Services
{
    public class UserService : IUserService<Users>
    {
        private readonly UserManager<Users> _userManager;
        private readonly SignInManager<Users> _signInManager;

        public UserService(UserManager<Users> userManager, SignInManager<Users> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        public async Task<(bool isSuccess, string message)> Add(UserAddViewModel model)
        {
            var result = await _userManager.CreateAsync(new()
            {
                UserName = model.UserName,
                Email = model.Email,
                PhoneNumber = model.PhoneNumber,
            }, model.PasswordConfirm);

            if (result.Succeeded)
            {
                return (true, "Kullanıcı Başarılı Bir Şekilde Eklendi!");
            }
            else
            {
                return (false, string.Join(",", result.Errors.Select(e => e.Description)));
            }
        }

        public async Task<(bool isSuccess, string message)> Delete(int id)
        {
            var user = await _userManager.FindByIdAsync(id.ToString());
            if (user == null)
            {
                return (false, "Kullanıcı Bulunamadı!");
            }
            var result = await _userManager.DeleteAsync(user);
            if (result.Succeeded)
            {
                return (true, "Kullanıcı Başarılı Bir Şekilde Silindi!");
            }
            else
            {
                return (false, string.Join(",", result.Errors.Select(e => e.Description)));
            }
        }

        public async Task<IEnumerable<Users>> GetAllAsync()
        {
            return await _userManager.Users.ToListAsync();
        }

        public async Task<Users> GetByIdAsync(int id)
        {
            return await _userManager.FindByIdAsync(id.ToString());
        }

        public async Task<(bool isSuccess, string message)> LoginAsync(LoginViewModel model)
        {
            var hasUser = await _userManager.FindByEmailAsync(model.Email);
            if (hasUser == null)
            {
                return (false, "Email veya Şifre Yanlış");
            }

            var result = await _signInManager.PasswordSignInAsync(hasUser.UserName, model.Password, model.RememberMe, false);

            if (result.Succeeded)
            {
                return (true, "Giriş Başarılı.Anasayfa'ya Yönlendiriliyorsunuz!");
            }
            else if (result.IsLockedOut)
            {
                return (false, "Hesabınız Kilitlendi");
            }
            else
            {
                return (false, "Email veya Şifre Yanlış");
            }
        }

        public async Task Logout()
        {
            await _signInManager.SignOutAsync();
        }

        public async Task<(bool isSuccess, string message)> Update(UserUpdateViewModel model)
        {
            var user = await _userManager.FindByIdAsync(model.Id.ToString());
            if (user == null)
            {
                return (false, "Kullanıcı Bulunamadı!");
            }
            user.UserName = model.UserName;
            user.Email = model.Email;
            user.PhoneNumber = model.PhoneNumber;
            var result = await _userManager.UpdateAsync(user);
            if (!string.IsNullOrEmpty(model.PasswordConfirm) && !string.IsNullOrEmpty(model.Password))
            {
                var token = await _userManager.GeneratePasswordResetTokenAsync(user);
                var resultPassword = await _userManager.ResetPasswordAsync(user, token, model.PasswordConfirm);
                if (resultPassword.Succeeded && result.Succeeded)
                {
                    return (true, "Kullanıcı Başarılı Bir Şekilde Güncellendi!");
                }
                else
                {
                    return (false, string.Join(",", resultPassword.Errors.Select(e => e.Description)));
                }
            }
            if (result.Succeeded)
            {
                return (true, "Kullanıcı Başarılı Bir Şekilde Güncellendi!");
            }
            else
            {
                return (false, string.Join(",", result.Errors.Select(e => e.Description)));
            }
        }

        public async Task<UserReturnModel> UserTableAsync(int draw, int start, int length, string orderColumnName, string orderDir, [FromForm] Search search)
        {
            var query = _userManager.Users.AsQueryable();

            if (!string.IsNullOrEmpty(search.value))
            {
                query = query.Where(x => x.UserName!.Contains(search.value) || x.Email!.Contains(search.value) || x.PhoneNumber!.Contains(search.value));
            }

            if (!string.IsNullOrEmpty(orderColumnName) && !string.IsNullOrEmpty(orderDir))
            {
                query = query.OrderBy($"{orderColumnName} {orderDir}");
            }

            var recordsTotal = query.Count();

            var data = await query.Skip(start).Take(length).ToListAsync();

            List<UserViewModel> users = new List<UserViewModel>();
            foreach (var user in data)
            {
                users.Add(new UserViewModel
                {
                    Id = user.Id,
                    UserName = user.UserName!,
                    Email = user.Email!,
                    PhoneNumber = user.PhoneNumber!
                });
            }


            return new UserReturnModel
            {
                draw = draw,
                recordsTotal = recordsTotal,
                recordsFiltered = recordsTotal,
                data = users
            };
        }
    }
}
