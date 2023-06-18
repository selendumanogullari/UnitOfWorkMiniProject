using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnitOfWorkMiniProject.Core.Interfaces;

namespace UnitOfWorkMiniProject.Infrastructure.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DbContextClass _dbContext;
        public ITaskRepository DailyTasks { get; }

        public UnitOfWork(DbContextClass dbContext,
                            ITaskRepository taskRepository)
        {
            _dbContext = dbContext;
            DailyTasks = taskRepository;
        }

        public int Save()
        {
            return _dbContext.SaveChanges();
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                _dbContext.Dispose();
            }
        }

    }
}
