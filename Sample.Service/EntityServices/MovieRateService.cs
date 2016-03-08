using Sample.DataAccess.Context;
using Sample.DataAccess.Entities;
using Sample.DataAccess.Repository;
using Sample.Service.Core;

namespace Sample.Service.EntityServices{
    public interface IMovieRateService : IService<MovieRate> {}

    
    public class MovieRateService : BaseService<MovieRate>, IMovieRateService{
        public MovieRateService(IRepository<MovieRate> specificationRepository)
            : base(specificationRepository) {}
    }
}