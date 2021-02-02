using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PFSS.API.RequestModels.Container;
using PFSS.Models;
using PFSS.Services.Wrapper;
using PFSS.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PFSS.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContainerController : PFSController
    {
        public ContainerController(ServiceWrapper serviceWrapper, IMapper mapper) : base(serviceWrapper, mapper)
        {
        }
        [HttpGet("Get")]
        public async Task<ActionResult> GetContainers()
        {
            var containers = await serviceWrapper.Container.GetUserContainers(PFSUser.Id);
            var container = containers[0];
            var viewModel = mapper.Map<ContainerViewModel>(container);
            return Ok(viewModel);
        }
        [HttpPost("Create")]
        public async Task<ActionResult> CreateContainer(CreateContainerRequestModel model)
        {
            var container = mapper.Map<Container>(model);
            container.CreatorId = PFSUser.Id;
            await serviceWrapper.Container.Add(container);
            return Ok();
        }
        [HttpPut("Update")]
        public async Task<ActionResult> Update(Container container)
        {
            container.CreatorId = PFSUser.Id;
            await serviceWrapper.Container.Update(container);
            return Ok();
        }
    }
}
