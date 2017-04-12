using System.Data.Entity;

namespace DoctorPlatform.Train.Libraries.EntityFramework
{ 
    public interface IDbContextProvider<out TDbContext>
        where TDbContext : DbContext
    {
        TDbContext GetDbContext();
    }
}
