namespace BlogSite.Services.ManagementServices.EditServices
{
    public interface IEditService<T> where T : class
    {
        T Edit(T model, T modelToEdit);
    }
}