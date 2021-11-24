using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using animeAppWebApi.Data;
using Microsoft.EntityFrameworkCore;
using animeAppWebApi.Models;
using animeAppWebApi.Repository;
using animeAppWebApi.Dtos;

namespace animeAppWebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IUserRepository userRepo;
        public UserController(UserDBContext userDBContext)
        {
            userRepo = new UserRepository(userDBContext);
        }

        //Lists All users
        [HttpGet]
        [Route("get")]
        public async Task<IEnumerable<UserDto>> Get()
        {
            var users = (await userRepo.GetUsers()).Select(user => new UserDto
            {
                userID = user.userID,
                userEmail = user.userEmail,
                username = user.username,
                userPassword = user.userPassword,
                userPremium = user.userPremium,
                userBio = user.userBio,
                //userLogo = user.userLogo,
                userGender = user.userGender,
                userDOB = user.userDOB
            });
            return users;

        }
        //Signup for user
        [HttpPost]
        [Route("signup")]
        public async Task UserSignUp([FromBody]UserSignupDto userDto)
        {
            UserModel user = new()
            {
                userEmail = userDto.userEmail,
                username = userDto.username,
                userPassword = userDto.userPassword,
                userPremium = false,
            };
            if (ModelState.IsValid)
            {
                await userRepo.SignUpUser(user);
            }
        }
        //Delete a user
        [HttpDelete]
        [Route("delete/{id}")]
        public async Task UserDelete(int id)
        {
            await userRepo.DeleteUser(id);
        }
        //User Login
        [HttpPost]
        [Route("login")]
        public async Task<ActionResult<UserLoginDto>> UserLogin([FromBody]UserLoginDto userDto)
        {
            UserModel user = new()
            {
                username = userDto.username,
                userPassword = userDto.userPassword              
            };
            user = await userRepo.LoginUser(user);
            if(user == null)
            {
                return BadRequest();
            }

            return Ok();
        }

    }
}
