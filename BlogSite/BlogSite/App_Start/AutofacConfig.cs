using Autofac;
using Autofac.Integration.Mvc;
using log4net.AutoFac;
using BlogSite.AccountService;
using BlogSite.AccountService.Login;
using BlogSite.AccountService.Logout;
using BlogSite.AccountService.Register;
using BlogSite.DAL;
using BlogSite.Logging;
using BlogSite.Models.EntityModels;
using BlogSite.Services.ManagementServices;
using BlogSite.Services.ManagementServices.AddServices;
using BlogSite.Services.ManagementServices.DeleteServices;
using BlogSite.Services.ManagementServices.EditServices;
using BlogSite.Services.RepositoryService;
using BlogSite.Services.UnitOfWorkService;
using BlogSite.Services.UserService;
using System.Web.Mvc;

namespace BlogSite
{
    public class AutofacConfig
    {
        public static void ConfigureContainer()
        {
            var builder = new ContainerBuilder();

            RegisterTypes(builder);

            builder.RegisterControllers(typeof(MvcApplication).Assembly);

            builder.RegisterModule(new LoggingModule());

            var container = builder.Build();

            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
        }

        private static void RegisterTypes(ContainerBuilder builder)
        {
            builder.RegisterType<Context>().As<IContext>();
            builder.RegisterGeneric(typeof(Repository<>)).As(typeof(IRepository<>));
            builder.RegisterType<Log4NetLoggingAdapter>().As<ILogger>();

            builder.RegisterType<UserAddService>().As<IAddService<User>>();
            builder.RegisterType<UserEditService>().As<IEditService<User>>();
            builder.RegisterType<UserDeleteService>().As<IDeleteService<User>>();
            builder.RegisterGeneric(typeof(ManagementServices<>)).As(typeof(IManagementServices<>));

            builder.RegisterType<UnitOfWork>().As<IUnitOfWork>();

            builder.RegisterType<UserService>().As<IUserService>();

            builder.RegisterType<RegisterService>().As<IRegisterService>();
            builder.RegisterType<LoginService>().As<ILoginService>();
            builder.RegisterType<LogoutService>().As<ILogoutService>();
            builder.RegisterType<Account>().As<IAccount>();
        }
    }
}