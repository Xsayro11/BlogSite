using BlogSite.Models.EntityModels;

namespace BlogSite.Services.UserService
{
    public interface IUserService
    {
        User GetUserByEmail(string email);
        User AddUser(User model);
        User EditUser(User model, int userId);
        void DeleteUser(int? userId);
        User GetById(int id);
    }
}