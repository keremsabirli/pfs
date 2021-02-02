using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PFSS.API.RequestModels.User;
using PFSS.Models;
using PFSS.Services.Wrapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PFSS.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : PFSController
    {
        public UserController(ServiceWrapper serviceWrapper, IMapper mapper) : base(serviceWrapper, mapper)
        {
        }
        
        [HttpPost("Create")]
        public async Task<ActionResult> CreateUser(CreateUserRequestModel model)
        {
            var user = new User()
            {
                Name = model.Name
            };
            await serviceWrapper.User.Add(user);
            return Ok();
        }
    }
}
