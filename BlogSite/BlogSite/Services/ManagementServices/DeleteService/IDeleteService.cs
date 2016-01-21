namespace BlogSite.Services.ManagementServices.DeleteServices
{
    public interface IDeleteService<T> where T : class
    {
        void Delete(int? id);
    }
}