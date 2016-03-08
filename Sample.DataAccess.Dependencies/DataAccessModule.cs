using System.Data.Entity;
using Autofac;
using Sample.DataAccess.Context;
using Sample.DataAccess.Repository;
using Sample.DataAccess.Repository.MsSQL;

namespace Sample.DataAccess.Dependencies{
    public class DataAccessModule : Module{
        protected override void Load(ContainerBuilder builder){
            builder.RegisterType<SampleEntities>().As<IDbContext>().InstancePerLifetimeScope(); //.PropertiesAutowired();
            builder.RegisterGeneric(typeof (GenericRepository<>)).As(typeof (IRepository<>));

            base.Load(builder);
        }
    }
}