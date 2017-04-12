using System.Data.Entity;

namespace DoctorPlatform.Train.Libraries.EntityFramework.Repositories
{
    public interface IRepositoryWithDbContext
    {
        DbContext GetDbContext();
    }
}
