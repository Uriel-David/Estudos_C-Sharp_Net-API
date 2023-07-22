using Microsoft.EntityFrameworkCore;
using ToDoList.Data;
using ToDoList.Models;
using ToDoList.Repositories.Interfaces;

namespace ToDoList.Repositories
{
    public class TaskRepository : ITaskRepository
    {
        private readonly TaskSystemDBContext _dbContext;

        public TaskRepository(TaskSystemDBContext taskSystemDBContext)
        {
            _dbContext = taskSystemDBContext;
        }

        public async Task<List<TaskModel>> GetAllTasks()
        {
            return await _dbContext.Tasks
                .Include(x => x.User)
                .ToListAsync();
        }

        public async Task<TaskModel> GetTask(int id)
        {
            return await _dbContext.Tasks
                .Include(x => x.User)
                .FirstOrDefaultAsync(x => x.Id == id) ?? throw new Exception($"User with this ID: {id} Not found.");
        }

        public async Task<TaskModel> SaveTask(TaskModel task)
        {
            await _dbContext.Tasks.AddAsync(task);
            await _dbContext.SaveChangesAsync();

            return task;
        }

        public async Task<TaskModel> UpdateTask(TaskModel task, int id)
        {
            TaskModel taskPerId = await GetTask(id) ?? throw new Exception($"Task with this ID: {id} Not found.");
            taskPerId.Name = task.Name;
            taskPerId.Description = task.Description;
            taskPerId.Status = task.Status;
            taskPerId.UserId = task.UserId;

            _dbContext.Tasks.Update(taskPerId);
            await _dbContext.SaveChangesAsync();

            return taskPerId;
        }

        public async Task<bool> DeleteTask(int id)
        {
            TaskModel taskPerId = await GetTask(id) ?? throw new Exception($"Task with this ID: {id} Not found.");

            _dbContext.Tasks.Remove(taskPerId);
            await _dbContext.SaveChangesAsync();

            return true;
        }
    }
}
