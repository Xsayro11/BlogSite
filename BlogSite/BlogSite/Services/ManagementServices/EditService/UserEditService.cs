using BlogSite.Logging;
using BlogSite.Models.EntityModels;

namespace BlogSite.Services.ManagementServices.EditServices
{
    public class UserEditService : IEditService<User>
    {
        private ILogger _log;

        public UserEditService(ILogger log)
        {
            this._log = log;
        }

        public User Edit(User model, User modelToEdit)
        {
            if (model == null)
                return null;

            modelToEdit.FirstName = model.FirstName;
            modelToEdit.LastName = model.LastName;
            modelToEdit.Email = model.Email;
            modelToEdit.Password = model.Password;

            return modelToEdit;
        }
    }
}