using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PFSS.Models;
using PFSS.Services.Wrapper;
using PFSS.Helpers;
using PFSS.RequestModels.User;
using PFSS.Models.ViewModels;
// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PFSS.API.Controllers
{
    [Route("api/Auth")]
    public class AuthController : PFSController
    {

        public AuthController(ServiceWrapper serviceWrapper,IMapper mapper) : base(serviceWrapper, mapper)
        {

        }

        /// <summary>
        /// Login Method
        /// </summary>
        /// <param name="loginParams"></param>
        /// <returns></returns>
        [Route("Login")]
        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> Login([FromBody] LoginRequestModel loginParams)
        {
            var result = mapper.Map<LoginViewModel>(await this.serviceWrapper.LoginService.Login(loginParams));

            if (result == null)
            {
                return Ok(new ResponseModel<LoginViewModel>()
                {
                   Status=ResponseType.BussinessError,
                   UserMessage="Username or password is not valid"
                });
            }
            else
            {
                return Ok(new ResponseModel<LoginViewModel>()
                {
                    Status = ResponseType.Success,
                    Data = result
                });
            }
        }

        /// <summary>
        /// Register New User
        /// </summary>
        /// <param name="user">
        /// Password must be between 6 and 12 characters.
        /// User Type in (0,1,2)
        /// 0:Admin,
        /// 1:Guest,
        /// 2:Standart
        /// </param>
        /// <returns></returns>

        [Route("Register")]
        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> Register([FromBody] RegisterRequestModel user)
        {
            string userMessage = "";
            if (!user.Email.IsValidEmail())
            {
                userMessage = "Email is not valid.";
            }
            else if (!user.Password.IsValidCharRange(6, 12))
            {
                userMessage = "Password must be between 6 and 12 characters.";
            }
            else if (!user.UserType.IsIn(new List<UserType> {
                UserType.Admin,
                UserType.Guest,
                UserType.Standard
            }))
            {
                userMessage = "User Type is not valid";
            }
            else if ((await this.serviceWrapper.User.GetByCondition(a => a.Email == user.Email))?.Count > 0)
            {
                userMessage = "This email is already registered.";
            }



            if (!userMessage.IsNullOrEmpty())
            {
                return Ok(new ResponseModel<Object>()
                {
                    Status=ResponseType.BussinessError,
                    UserMessage=userMessage
                });
            }
            var userModel = new User()
            {
                Name = user.Name,
                Surname = user.Surname,
                Email = user.Email,
                Password = user.Password,
                UserType = user.UserType
            };
             await this.serviceWrapper.LoginService.SignUp(userModel);

            return Ok(new ResponseModel<Object>()
            {
                Status=ResponseType.Success
            });
        }

        [Route("Test")]
        [Authorize]
        [HttpGet]
        public async Task<ActionResult> test()
        {
            User userBilgileri;
            var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            if (userId != null)
            {
                var users = await this.serviceWrapper.User.GetByCondition(a => a.Id == userId);
                userBilgileri = users.FirstOrDefault();
                return Ok(userBilgileri);
            }
            return Ok(new { test = "Kayıt Başarılı" });
        }

    }
}
