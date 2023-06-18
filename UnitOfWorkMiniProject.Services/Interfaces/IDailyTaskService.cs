using UnitOfWorkMiniProject.Core.Models;

namespace UnitOfWorkMiniProject.Services.Interfaces
{
    public interface IDailyTaskService
    {
        Task<bool> CreateTask(DailyTask task);

        Task<IEnumerable<DailyTask>> GetAllTask();

        Task<DailyTask> GetTaskById(int taskId);

        Task<bool> UpdateTask(DailyTask task);

        Task<bool> DeleteTask(int taskId);
    }
}
