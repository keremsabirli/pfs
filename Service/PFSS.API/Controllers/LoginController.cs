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
using PFSS.Models.Auth;
// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PFSS.API.Controllers
{
    [Route("api/Auth")]
    public class LoginController : Controller
    {

        protected readonly ServiceWrapper serviceWrapper;
        protected readonly IMapper mapper;

        public LoginController(ServiceWrapper serviceWrapper,IMapper mapper)
        {
            this.serviceWrapper = serviceWrapper;
        }

        /// <summary>
        /// Login Method
        /// </summary>
        /// <param name="loginParams"></param>
        /// <returns></returns>
        [Route("Login")]
        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> Login([FromBody] LoginParams loginParams)
        {
            var result= await this.serviceWrapper.LoginService.Login(loginParams);

            if (result == null)
            {
                return Ok(new ResponseModel()
                {
                   status=ResponseType.BussinesError,
                   UserMessage="Username or password is not valid"
                });
            }
            else
            {
                return Ok(new ResponseModel()
                {
                    status = ResponseType.Success,
                    data = result
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
        public async Task<IActionResult> Register([FromBody] RegisterModel user)
        {
            string userMessage = "";
            if (!user.email.isValidEmail())
            {
                userMessage = "Email is not valid.";
            }
            else if (!user.password.isValidCharRange(6, 12))
            {
                userMessage = "Password must be between 6 and 12 characters.";
            }
            else if (!user.userType.isIn(new List<UserType> {
                UserType.Admin,
                UserType.Guest,
                UserType.Standard
            }))
            {
                userMessage = "User Type is not valid";
            }
            else if ((await this.serviceWrapper.User.GetByCondition(a => a.email == user.email))?.Count > 0)
            {
                userMessage = "This email is already registered.";
            }



            if (!userMessage.IsNullOrEmpty())
            {
                return Ok(new ResponseModel()
                {
                    status=ResponseType.BussinesError,
                    UserMessage=userMessage
                });
            }
            var userModel = new User()
            {
                name = user.name,
                surname = user.surname,
                email = user.email,
                password = user.password,
                userType = user.userType
            };
             await this.serviceWrapper.LoginService.SignUp(userModel);

            return Ok(new ResponseModel()
            {
                status=ResponseType.Success
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
