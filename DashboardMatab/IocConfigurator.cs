using Autofac;
using Autofac.Integration.Mvc;
using DashboardMatab.Models;
using DashboardMatab.Services;
using System.Web.Mvc;

namespace DashboardMatab
{
    public class IocConfigurator
    {
        public static void ConfigureDependencyInjection()
        {
            var builder = new ContainerBuilder();

            builder.RegisterControllers(typeof(MvcApplication).Assembly);
            //builder.RegisterType<Repository<Student>>().As<IRepository<Student>>();

            builder.RegisterType<MatabDBEntities>().InstancePerRequest();

            builder.RegisterType<Repository>().InstancePerRequest();

            IContainer container = builder.Build();
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
        }
    }
}