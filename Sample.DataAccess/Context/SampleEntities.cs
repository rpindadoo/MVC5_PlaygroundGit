using System.Data.Entity;
using Sample.DataAccess.Entities;

namespace Sample.DataAccess.Context{
    public class SampleEntities : DbContext, IDbContext{
        public DbSet<User> Users { get; set; }
        public DbSet<Movie> Movies { get; set; }
        public DbSet<MovieRate> MovieRates { get; set; }

        public new IDbSet<T> Set<T>() where T : class{
            return base.Set<T>();
        }

        public new void SaveChanges(){
            base.SaveChanges();
        }
    }

    public interface IDbContext{
        IDbSet<T> Set<T>() where T : class;
        void SaveChanges();
    }
}