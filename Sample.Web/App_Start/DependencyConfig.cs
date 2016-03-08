using System.Web.Mvc;
using Autofac;
using Autofac.Integration.Mvc;
using Sample.DataAccess.Dependencies;
using Sample.Service.Dependencies;
using Sample.Web.Controllers.Helpers;

namespace Sample.Web{
    public static class DependencyConfig{
        public static void RegisterDependencies(){
            var container = new ContainerBuilder();

            container.RegisterModule(new DataAccessModule());
            container.RegisterModule(new ServiceModule());

            container.RegisterControllers(typeof (MvcApplication).Assembly).PropertiesAutowired();
            container.RegisterFilterProvider();

            container.RegisterType<ChartHelper>().As<IChartHelper>();

            DependencyResolver.SetResolver(new AutofacDependencyResolver(container.Build()));
        }
    }
}