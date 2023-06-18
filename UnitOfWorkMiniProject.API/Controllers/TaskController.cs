using Microsoft.AspNetCore.Mvc;
using UnitOfWorkMiniProject.Core.Models;
using UnitOfWorkMiniProject.Services.Interfaces;

namespace UnitOfWorkMiniProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TaskController : ControllerBase
    {
        public readonly IDailyTaskService _taskService;
        public TaskController(IDailyTaskService taskService)
        {
            _taskService = taskService;
        }

        /// <summary>
        /// Get the list of Task
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> GetTaskList()
        {
            var taskList = await _taskService.GetAllTask();
            if(taskList == null)
            {
                return NotFound();
            }
            return Ok(taskList);
        }

        /// <summary>
        /// Get task by id
        /// </summary>
        /// <param name="TaskId"></param>
        /// <returns></returns>
        [HttpGet("{taskId}")]
        public async Task<IActionResult> GetTaskById(int taskId)
        {
            var task = await _taskService.GetTaskById(taskId);

            if (task != null)
            {
                return Ok(task);
            }
            else
            {
                return BadRequest();
            }
        }

        /// <summary>
        /// Add a new Task
        /// </summary>
        /// <param name="task"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> CreateTask(DailyTask task)
        {
            var isTaskCreated = await _taskService.CreateTask(task);

            if (isTaskCreated)
            {
                return Ok(isTaskCreated);
            }
            else
            {
                return BadRequest();
            }
        }

        /// <summary>
        /// Update the Task
        /// </summary>
        /// <param name="Task"></param>
        /// <returns></returns>
        [HttpPut]
        public async Task<IActionResult> UpdateTask(DailyTask task)
        {
            if (task != null)
            {
                var isTaskCreated = await _taskService.UpdateTask(task);
                if (isTaskCreated)
                {
                    return Ok(isTaskCreated);
                }
                return BadRequest();
            }
            else
            {
                return BadRequest();
            }
        }

        /// <summary>
        /// Delete Task by id
        /// </summary>
        /// <param name="taskId"></param>
        /// <returns></returns>
        [HttpDelete("{taskId}")]
        public async Task<IActionResult> DeleteTask(int taskId)
        {
            var isTaskDeleted = await _taskService.DeleteTask(taskId);

            if (isTaskDeleted)
            {
                return Ok(isTaskDeleted);
            }
            else
            {
                return BadRequest();
            }
        }
    }
}
