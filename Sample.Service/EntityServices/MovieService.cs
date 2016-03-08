using Sample.DataAccess.Context;
using Sample.DataAccess.Entities;
using Sample.DataAccess.Repository;
using Sample.Service.Core;

namespace Sample.Service.EntityServices{
    public interface IMovieService : IService<Movie> {}

    
    public class MovieService : BaseService<Movie>, IMovieService{
        public MovieService(IRepository<Movie> specificationRepository)
            : base(specificationRepository) {}
    }
}