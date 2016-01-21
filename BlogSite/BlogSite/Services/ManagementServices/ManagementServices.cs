using BlogSite.Services.ManagementServices.AddServices;
using BlogSite.Services.ManagementServices.DeleteServices;
using BlogSite.Services.ManagementServices.EditServices;
using System;

namespace BlogSite.Services.ManagementServices
{
    public class ManagementServices<T> : IManagementServices<T> where T : class
    {
        private Lazy<IAddService<T>> _addService;
        private Lazy<IEditService<T>> _editService;
        private Lazy<IDeleteService<T>> _deleteService;

        public ManagementServices(IAddService<T> addService, IEditService<T> editService, IDeleteService<T> deleteService)
        {
            this._addService = new Lazy<IAddService<T>>(() => addService);
            this._editService = new Lazy<IEditService<T>>(() => editService);
            this._deleteService = new Lazy<IDeleteService<T>>(() => deleteService);
        }

        public IAddService<T> AddService
        {
            get
            {
                return this._addService.Value;
            }
        }

        public IEditService<T> EditService
        {
            get
            {
                return this._editService.Value;
            }
        }

        public IDeleteService<T> DeleteService
        {
            get
            {
                return this._deleteService.Value;
            }
        }
    }
}