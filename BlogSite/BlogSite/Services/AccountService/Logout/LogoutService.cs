using BlogSite.Services.UserService;
using System.Web.Security;

namespace BlogSite.AccountService.Logout
{
    public class LogoutService : ILogoutService
    {
        private IUserService _userService;

        public LogoutService(IUserService userService)
        {
            this._userService = userService;
        }

        public void Logout()
        {
            FormsAuthentication.SignOut();
        }
    }
}