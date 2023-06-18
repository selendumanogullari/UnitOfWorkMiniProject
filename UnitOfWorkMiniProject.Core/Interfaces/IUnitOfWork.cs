

namespace UnitOfWorkMiniProject.Core.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        ITaskRepository DailyTasks { get; }

        int Save();
    }
}
