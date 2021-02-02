using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PFSS.API.Controllers;
using PFSS.Models;
using PFSS.Services.Wrapper;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace PrivateFileStorageService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FileController : PFSController
    {
        public FileController(ServiceWrapper serviceWrapper, IMapper mapper): base(serviceWrapper, mapper)
        {

        }
        [HttpGet("{id}")]
        public async Task<ActionResult> Get(string id)
        {
            var file = await serviceWrapper.File.GetById(id);
            var fileStream = await serviceWrapper.File.GetPhysicalFile(file.PhysicalFileId);
            return Ok(fileStream);
        }
        [HttpPost]
        public async Task<ActionResult> Upload(List<IFormFile> files)
        {
            await Task.WhenAll(files.Select(file => serviceWrapper.File.Upload(file)));
            return Ok();
        }
    }
}
