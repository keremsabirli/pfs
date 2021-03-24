using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
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
        [HttpGet]
        public async Task<ActionResult> GetInitialInfo()
        {
            var directories = await serviceWrapper.Directory.GetByCondition(x => PFSUser.AuthorizedDirectories.Contains(x.Id));
            return Ok(directories);
        }
    }
}
