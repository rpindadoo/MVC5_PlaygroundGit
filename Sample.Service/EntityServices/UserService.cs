using Sample.DataAccess.Context;
using Sample.DataAccess.Entities;
using Sample.DataAccess.Repository;
using Sample.Service.Core;

namespace Sample.Service.EntityServices{
    public interface IUserService : IService<User> {}

    
    public class UserService : BaseService<User>, IUserService{
        public UserService( IRepository<User> repository)
            : base(repository) {}
    }
}