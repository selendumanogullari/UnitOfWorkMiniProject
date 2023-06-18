using UnitOfWorkMiniProject.Core.Interfaces;
using UnitOfWorkMiniProject.Core.Models;
using UnitOfWorkMiniProject.Services.Interfaces;

namespace UnitOfWorkMiniProject.Services
{
    public class DailyTaskService : IDailyTaskService
    {
        public IUnitOfWork _unitOfWork;

        public DailyTaskService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<bool> CreateTask(DailyTask task)
        {
            if (task != null)
            {
                await _unitOfWork.DailyTasks.Add(task);

                var result = _unitOfWork.Save();

                if (result > 0)
                    return true;
                else
                    return false;
            }
            return false;
        }

        public async Task<bool> DeleteTask(int taskId)
        {
            if (taskId > 0)
            {
                var taskDetails = await _unitOfWork.DailyTasks.GetById(taskId);
                if (taskDetails != null)
                {
                    _unitOfWork.DailyTasks.Delete(taskDetails);
                    var result = _unitOfWork.Save();

                    if (result > 0)
                        return true;
                    else
                        return false;
                }
            }
            return false;
        }

        public async Task<IEnumerable<DailyTask>> GetAllTask()
        {
            var task = await _unitOfWork.DailyTasks.GetAll();
            return task;
        }


        public async Task<DailyTask> GetTaskById(int tasktId)
        {
            if (tasktId > 0)
            {
                var task = await _unitOfWork.DailyTasks.GetById(tasktId);
                if (task != null)
                {
                    return task;
                }
            }
            return null;
        }

        public async Task<bool> UpdateTask(DailyTask task)
        {
            if (task != null)
            {
                var dailyTask = await _unitOfWork.DailyTasks.GetById(task.Id);
                if(dailyTask != null)
                {
                    dailyTask.TaskName= task.TaskName;
                    dailyTask.StartDate= task.StartDate;
                    dailyTask.EndDate= task.EndDate;

                    _unitOfWork.DailyTasks.Update(dailyTask);

                    var result = _unitOfWork.Save();

                    if (result > 0)
                        return true;
                    else
                        return false;
                }
            }
            return false;
        }
    }
}
