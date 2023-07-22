using ToDoList.Models;

namespace ToDoList.Repositories.Interfaces
{
    public interface IUserRepository
    {
        Task<List<UserModel>> GetAllUsers();
        Task<UserModel> GetUser(int id);
        Task<UserModel> SaveUser(UserModel user);
        Task<UserModel> UpdateUser(UserModel user, int id);
        Task<bool> DeleteUser(int id);
    }
}
