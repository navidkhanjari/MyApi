using Data.Repositories;
using Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace MyApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserRepository userRepository;
        public UserController(IUserRepository userRepository)
        {
            this.userRepository = userRepository;
        }

        [HttpGet]
        public async Task<List<User>> Get()
        {
            var user = await userRepository.TableNoTracking.ToListAsync();

            return user;
        }

        [HttpGet("Id:int")]
        public async Task<ActionResult<User>> Get(int Id, CancellationToken cancellationToken)
        {
            var user = await userRepository.GetByIdAsync(cancellationToken, Id);

            return user;
        }

        [HttpPost]
        public async Task Create(User user, CancellationToken cancellationToken)
        {
            await userRepository.AddAsync(user, cancellationToken);
        }

        [HttpPut]
        public async Task<IActionResult> Update(int Id, User user, CancellationToken cancellationToken)
        {
            var updateUser = await userRepository.GetByIdAsync(cancellationToken, Id);

            updateUser.UserName = user.UserName;
            updateUser.FullName = user.FullName;
            updateUser.Age = user.Age;
            updateUser.IsActive = user.IsActive;
            updateUser.LastLoginDate = user.LastLoginDate;
            updateUser.PasswordHash = user.PasswordHash;
            updateUser.Gender = user.Gender;

            await userRepository.UpdateAsync(updateUser, cancellationToken);

            return Ok();
        }

        [HttpDelete]
        public async Task<ActionResult> Delete(int Id, CancellationToken cancellationToken)
        {
            var user = await userRepository.GetByIdAsync(cancellationToken, Id);

            await userRepository.DeleteAsync(user, cancellationToken);

            return Ok();
        }
    }
}
