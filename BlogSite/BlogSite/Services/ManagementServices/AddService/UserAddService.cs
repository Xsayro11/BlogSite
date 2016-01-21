using BlogSite.Logging;
using BlogSite.Models.EntityModels;
using System.Collections.Generic;

namespace BlogSite.Services.ManagementServices.AddServices
{
    public class UserAddService : IAddService<User>
    {
        private ILogger _log;

        public UserAddService(ILogger log)
        {
            this._log = log;
        }

        public User Add(User model, List<User> models)
        {
            if (model == null)
                return null;

            if (models != null)
            {
                foreach (var user in models)
                    if (user.Email == model.Email)
                        return null;
            }

            return model;
        }
    }
}