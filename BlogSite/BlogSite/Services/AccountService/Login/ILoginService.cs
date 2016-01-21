namespace BlogSite.AccountService.Login
{
    public interface ILoginService
    {
        bool Login(string email, string password);
    }
}