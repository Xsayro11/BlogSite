using BlogSite.Services.ManagementServices.AddServices;
using BlogSite.Services.ManagementServices.DeleteServices;
using BlogSite.Services.ManagementServices.EditServices;

namespace BlogSite.Services.ManagementServices
{
    public interface IManagementServices<T> where T : class
    {
        IAddService<T> AddService { get; }
        IEditService<T> EditService { get; }
        IDeleteService<T> DeleteService { get; }
    }
}