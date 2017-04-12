using System.Data.Entity;

namespace DoctorPlatform.Train.Libraries.EntityFramework
{
    public sealed class BaseDbContextProvider<TDbContext> : IDbContextProvider<TDbContext>
        where TDbContext : DbContext
    {

        public TDbContext DbContext { get; }

        public BaseDbContextProvider(TDbContext dbContext)
        {
            DbContext = dbContext;
        }

        public TDbContext GetDbContext()
        {
            return DbContext;
        }
    }
}
