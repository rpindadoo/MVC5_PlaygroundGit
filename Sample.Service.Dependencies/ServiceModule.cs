using Autofac;
using Sample.DataAccess.Context;
using Sample.DataAccess.Entities;
using Sample.Service.Core;
using Sample.Service.EntityServices;

namespace Sample.Service.Dependencies{
    public class ServiceModule : Module{
        protected override void Load(ContainerBuilder builder){
            builder.RegisterGeneric(typeof(BaseService<>)).As(typeof(IService<>));

            builder.RegisterType<UserService>().As<IUserService>().As<IService<User>>();
            builder.RegisterType<MovieService>().As<IMovieService>().As<IService<Movie>>();
            builder.RegisterType<MovieRateService>().As<IMovieRateService>().As<IService<MovieRate>>();

            base.Load(builder);
        }
    }
}