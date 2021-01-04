using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver.GridFS;
using PFSS.API.Controllers;
using PFSS.Services.Wrapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PrivateFileStorageService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FileController : BaseController
    {
        public FileController(ServiceWrapper serviceWrapper): base(serviceWrapper)
        {

        }
        [HttpGet]
        public ActionResult Get()
        {
            return Ok("Ok");
        }
        [HttpGet("{id}")]
        public ActionResult Get(string id)
        {
            return Ok();
        }
        [HttpPost]
        public async Task<ActionResult> Upload(List<IFormFile> files)
        {
            await Task.WhenAll(files.Select(file => serviceWrapper.File.Upload(file)));
            return Ok();
        }
    }
}
