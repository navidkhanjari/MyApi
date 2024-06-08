using Data.Repositories;
using Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyApi.Models;
using WebFramework.Api;

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
        public async Task<ApiResult<List<User>>> Get(CancellationToken cancellationToken)
        {
            var users = await userRepository.TableNoTracking.ToListAsync(cancellationToken);

            return users;
        }

        [HttpGet("Id:int")]
        public async Task<ApiResult<User>> Get(int Id, CancellationToken cancellationToken)
        {
            var user = await userRepository.GetByIdAsync(cancellationToken, Id);

            return user;
        }

        [HttpPost]
        public async Task<ApiResult<User>> Create(UserDto userDto, CancellationToken cancellationToken)
        {
            var user = new User()
            {
                FullName = userDto.FullName,
                Age = userDto.Age,
                Gender = userDto.Gender,
                UserName = userDto.UserName,
            };

            await userRepository.AddAsync(user, userDto.Password, cancellationToken);

            return user;
        }

        [HttpPut]
        public async Task<ApiResult> Update(int Id, User user, CancellationToken cancellationToken)
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
        public async Task<ApiResult> Delete(int Id, CancellationToken cancellationToken)
        {
            var user = await userRepository.GetByIdAsync(cancellationToken, Id);

            await userRepository.DeleteAsync(user, cancellationToken);

            return Ok();
        }
    }
}
