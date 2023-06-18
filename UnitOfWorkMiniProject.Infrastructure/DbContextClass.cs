using Microsoft.EntityFrameworkCore;
using UnitOfWorkMiniProject.Core.Models;

namespace UnitOfWorkMiniProject.Infrastructure
{
    public class DbContextClass : DbContext
    {
        public DbContextClass(DbContextOptions<DbContextClass> contextOptions) : base(contextOptions)
        {

        }

        public DbSet<DailyTask> Tasks { get; set; }
    }
}
