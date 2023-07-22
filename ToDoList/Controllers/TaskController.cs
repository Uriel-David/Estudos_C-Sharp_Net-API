using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ToDoList.Models;
using ToDoList.Repositories.Interfaces;

namespace ToDoList.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TaskController : ControllerBase
    {
        private readonly ITaskRepository _taskRepository;

        public TaskController(ITaskRepository taskRepository)
        {
            _taskRepository = taskRepository;
        }

        [HttpGet]
        public async Task<ActionResult<List<TaskModel>>> GetAllTasks()
        {
            List<TaskModel> tasks = await _taskRepository.GetAllTasks();
            return Ok(tasks);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<TaskModel>> GetTask(int id)
        {
            TaskModel task = await _taskRepository.GetTask(id);
            return Ok(task);
        }

        [HttpPost]
        public async Task<ActionResult<TaskModel>> SaveTask([FromBody] TaskModel taskModel)
        {
            TaskModel task = await _taskRepository.SaveTask(taskModel);
            return Ok(task);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<TaskModel>> UpdateTask([FromBody] TaskModel taskModel, int id)
        {
            taskModel.Id = id;
            TaskModel task = await _taskRepository.UpdateTask(taskModel, id);
            return Ok(task);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<TaskModel>> DeleteTask(int id)
        {
            bool task = await _taskRepository.DeleteTask(id);
            return Ok(task);
        }
    }
}
