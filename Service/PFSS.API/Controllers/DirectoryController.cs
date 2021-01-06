using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PFSS.API.RequestModels.Directory;
using PFSS.Services.Wrapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PFSS.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DirectoryController : PFSController
    {
        public DirectoryController(ServiceWrapper serviceWrapper) : base(serviceWrapper)
        {

        }
        [HttpPost]
        public async Task<ActionResult> CreateDirectory(CreateDirectoryRequestModel model)
        {
            //var directory = 
            //serviceWrapper.Directory.Add()
            return Ok();
        }
    }
}
