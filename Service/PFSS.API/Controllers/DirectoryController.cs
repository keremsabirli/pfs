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
        [HttpPost("Create")]
        public async Task<ActionResult> CreateDirectory(CreateDirectoryRequestModel model)
        {
            Directory directory = new Directory()
            {
                Creator = PFSUser,
                ParentDirectory = await serviceWrapper.Directory.GetById(model.ParentDirectoryId),
                Name = model.Name
            };
            await serviceWrapper.Directory.Add(directory);
            return Ok();
        }
    }
}
