using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ToDoList.Models;
using ToDoList.Repositories.Interfaces;

namespace ToDoList.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserRepository _userRepository;

        public UserController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        [HttpGet]
        public async Task<ActionResult<List<UserModel>>> GetAllUsers()
        {
            List<UserModel> users = await _userRepository.GetAllUsers();
            return Ok(users);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<UserModel>> GetUser(int id)
        {
            UserModel user = await _userRepository.GetUser(id);
            return Ok(user);
        }

        [HttpPost]
        public async Task<ActionResult<UserModel>> saveUser([FromBody] UserModel userModel)
        {
            UserModel user = await _userRepository.SaveUser(userModel);
            return Ok(user);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<UserModel>> UpdateUser([FromBody] UserModel userModel, int id)
        {
            userModel.Id = id;
            UserModel user = await _userRepository.UpdateUser(userModel, id);
            return Ok(user);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<UserModel>> DeleteUser(int id)
        {
            bool user = await _userRepository.DeleteUser(id);
            return Ok(user);
        }
    }
}
