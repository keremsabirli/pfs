using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PFSS.API.RequestModels.Directory;
using PFSS.Models;
using PFSS.Models.ViewModels;
using PFSS.Services.Wrapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PFSS.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DirectoryController : PFSAuthenticatedController
    {
        public DirectoryController(ServiceWrapper serviceWrapper, IMapper mapper) : base(serviceWrapper, mapper)
        {
        }
        [HttpGet]
        public async Task<ActionResult> GetDirectoryChilds(GetDirectoryChildsRequestModel model)
        {
            var directoryChilds = (await serviceWrapper.Directory.GetByCondition(x => x.Id == model.ParentDirectoryId)).ToList();
            mapper.Map<List<DirectoryViewModel>>(directoryChilds);
            return Ok(directoryChilds);
        }
        [HttpPost("Create")]
        public async Task<ActionResult> CreateDirectory(CreateDirectoryRequestModel model)
        {
            var directory = mapper.Map<Directory>(model);
            directory.CreatorId = PFSUser.Id;
            var updatedDirectory = await serviceWrapper.Directory.Add(directory);
            if (directory.ParentDirectoryId == null && !PFSUser.AuthorizedDirectories.Contains(updatedDirectory.Id))
            {
                await serviceWrapper.User.AddDirectoryAuthorization(PFSUser.Id, updatedDirectory.Id);
            }
            return Ok();
        }
    }
}
