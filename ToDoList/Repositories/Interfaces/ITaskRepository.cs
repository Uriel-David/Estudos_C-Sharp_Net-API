using ToDoList.Models;

namespace ToDoList.Repositories.Interfaces
{
    public interface ITaskRepository
    {
        Task<List<TaskModel>> GetAllTasks();
        Task<TaskModel> GetTask(int id);
        Task<TaskModel> SaveTask(TaskModel user);
        Task<TaskModel> UpdateTask(TaskModel user, int id);
        Task<bool> DeleteTask(int id);
    }
}
