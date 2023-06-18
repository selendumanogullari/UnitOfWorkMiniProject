using UnitOfWorkMiniProject.Core.Interfaces;
using UnitOfWorkMiniProject.Core.Models;

namespace UnitOfWorkMiniProject.Infrastructure.Repositories
{
    public class DailyTaskRepository : GenericRepository<DailyTask>, ITaskRepository
    {
        public DailyTaskRepository(DbContextClass dbContext) : base(dbContext)
        {

        }
    }
}
