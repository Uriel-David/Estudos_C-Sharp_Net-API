using Microsoft.EntityFrameworkCore;
using ToDoList.Data;
using ToDoList.Models;
using ToDoList.Repositories.Interfaces;

namespace ToDoList.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly TaskSystemDBContext _dbContext;

        public UserRepository(TaskSystemDBContext taskSystemDBContext)
        {
            _dbContext = taskSystemDBContext;
        }

        public async Task<List<UserModel>> GetAllUsers()
        {
            return await _dbContext.Users.ToListAsync();
        }

        public async Task<UserModel> GetUser(int id)
        {
            return await _dbContext.Users.FirstOrDefaultAsync(x => x.Id == id) ?? throw new Exception($"User with this ID: {id} Not found.");
        }

        public async Task<UserModel> SaveUser(UserModel user)
        {
            await _dbContext.Users.AddAsync(user);
            await _dbContext.SaveChangesAsync();

            return user;
        }

        public async Task<UserModel> UpdateUser(UserModel user, int id)
        {
            UserModel userPerId = await GetUser(id) ?? throw new Exception($"User with this ID: {id} Not found.");
            userPerId.Name = user.Name;
            userPerId.Email = user.Email;

            _dbContext.Users.Update(userPerId);
            await _dbContext.SaveChangesAsync();

            return userPerId;
        }

        public async Task<bool> DeleteUser(int id)
        {
            UserModel userPerId = await GetUser(id) ?? throw new Exception($"User with this ID: {id} Not found.");

            _dbContext.Users.Remove(userPerId);
            await _dbContext.SaveChangesAsync();

            return true;
        }
    }
}
