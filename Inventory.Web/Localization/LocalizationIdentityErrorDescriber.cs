using Microsoft.AspNetCore.Identity;

namespace Inventory.Web.Localization
{
    public class LocalizationIdentityErrorDescriber : IdentityErrorDescriber
    {
        public override IdentityError DuplicateEmail(string email)
        {
            return new() { Code = nameof(DuplicateEmail), Description = $"Bu Eposta Adresi '{email}' Zaten Kullanımda." };
        }

        public override IdentityError DuplicateUserName(string userName)
        {
            return new() { Code = nameof(DuplicateUserName), Description = $"Bu Kullanıcı Adı '{userName}' Zaten Kullanımda." };
        }

        public override IdentityError PasswordMismatch()
        {
            return new() { Code = nameof(PasswordMismatch), Description = "Şifreler Uyuşmuyor!" };
        }

        public override IdentityError InvalidEmail(string email)
        {
            return new() { Code = nameof(InvalidEmail), Description = $"Bu Eposta Adresi '{email}' Geçersiz." };
        }

        public override IdentityError InvalidUserName(string userName)
        {
            return new() { Code = nameof(InvalidUserName), Description = $"Bu Kullanıcı Adı ({userName}) Geçersiz!" };
        }

        public override IdentityError PasswordTooShort(int length)
        {
            return new() { Code = nameof(PasswordTooShort), Description = $"Şifre En Az {length} Karakter Olmalıdır!" };
        }
    }
}
