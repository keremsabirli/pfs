using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PFSS.API.RequestModels.Directory;
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
    public class DirectoryController : PFSController
    {
        public DirectoryController(ServiceWrapper serviceWrapper, IMapper mapper) : base(serviceWrapper, mapper)
        {

        }
        [HttpGet]
        public async Task<ActionResult> GetDirectoryChilds(GetDirectoryChildsRequestModel model)
        {
            var directoryChilds = await serviceWrapper.Directory.GetByCondition(x => x.Id == model.ParentDirectoryId);
            return Ok(directoryChilds);
        }
        [HttpPost]
        public async Task<ActionResult> CreateDirectory(CreateDirectoryRequestModel model)
        {
            var directory = mapper.Map<Models.Directory>(model);
            directory.UserId = PFSUser.Id;
            await serviceWrapper.Directory.Add(directory);
            return Ok();
        }
    }
}
