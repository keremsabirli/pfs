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

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PFSS.API.Controllers
{
    [Route("api/[controller]")]
    public class LoginController : Controller
    {

        protected readonly ServiceWrapper serviceWrapper;
        protected readonly IMapper mapper;

        public LoginController(ServiceWrapper serviceWrapper,IMapper mapper)
        {
            this.serviceWrapper = serviceWrapper;
        }


        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> Login([FromBody] LoginParams loginParams)
        {
            var result= await this.serviceWrapper.LoginService.Login(loginParams);

            if (result == null)
            {
                return Unauthorized();
            }
            else
            {
                return Ok(result);
            }
        }


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
