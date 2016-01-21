using BlogSite.AccountService.Login;
using BlogSite.AccountService.Logout;
using BlogSite.AccountService.Register;
using BlogSite.Models.ViewModels;

namespace BlogSite.AccountService
{
    public class Account : IAccount
    {
        private IRegisterService _registerService;
        private ILoginService _loginService;
        private ILogoutService _logoutService;

        public Account(IRegisterService registerService, ILoginService loginService, ILogoutService logoutService)
        {
            this._registerService = registerService;
            this._loginService = loginService;
            this._logoutService = logoutService;
        }

        public void Register(RegisterViewModel user)
        {
            this._registerService.Register(user.FirstName, user.LastName, user.Password, user.Email, user.Gender);
        }

        public bool Login(LoginViewModel user)
        {
            return this._loginService.Login(user.Email, user.Password);
        }

        public void Logout()
        {
            this._logoutService.Logout();
        }

        public bool IsValid(LoginViewModel user)
        {
            if (user == null)
                return false;

            if (string.IsNullOrEmpty(user.Email))
                return false;
            if (string.IsNullOrEmpty(user.Password))
                return false;

            return true;
        }

        public bool IsValid(RegisterViewModel user)
        {
            if (user == null)
                return false;

            if (string.IsNullOrEmpty(user.FirstName))
                return false;
            if (string.IsNullOrEmpty(user.LastName))
                return false;
            if (string.IsNullOrEmpty(user.Email))
                return false;
            if (string.IsNullOrEmpty(user.Password))
                return false;

            return true;
        }
    }
}