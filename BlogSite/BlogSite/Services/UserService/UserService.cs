using BlogSite.Models.EntityModels;
using BlogSite.Services.ManagementServices;
using BlogSite.Services.UnitOfWorkService;
using System.Linq;

namespace BlogSite.Services.UserService
{
    public class UserService : IUserService
    {
        private IUnitOfWork _unitOfWork;
        private IManagementServices<User> _userManagementServices;

        public UserService(IUnitOfWork unitOfWork, IManagementServices<User> userManagementServices)
        {
            this._unitOfWork = unitOfWork;
            this._userManagementServices = userManagementServices;
        }

        public User GetUserByEmail(string email)
        {
            return _unitOfWork.UserRepository.DbSet.FirstOrDefault(u => u.Email == email);
        }

        public User AddUser(User model)
        {
            var users = _unitOfWork.UserRepository.GetAll();
            model = this._userManagementServices.AddService.Add(model, users);
            _unitOfWork.UserRepository.Add(model);
            _unitOfWork.SaveChanges();
            return model;
        }

        public User EditUser(User model, int userId)
        {
            var editUser = _unitOfWork.UserRepository.GetById(userId);
            model = this._userManagementServices.EditService.Edit(model, editUser);
            _unitOfWork.SaveChanges();
            return model;
        }

        public void DeleteUser(int? userId)
        {
            this._userManagementServices.DeleteService.Delete(userId);
            var editUser = _unitOfWork.UserRepository.GetById(userId.Value);
            _unitOfWork.UserRepository.Delete(editUser);
            _unitOfWork.SaveChanges();
        }

        public User GetById(int id)
        {
            return _unitOfWork.UserRepository.GetById(id);
        }
    }
}