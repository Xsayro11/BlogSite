using BlogSite.Models.ViewModels;

namespace BlogSite.AccountService
{
    public interface IAccount
    {
        bool Login(LoginViewModel user);
        void Register(RegisterViewModel user);
        void Logout();
        bool IsValid(LoginViewModel user);
        bool IsValid(RegisterViewModel user);
    }
}