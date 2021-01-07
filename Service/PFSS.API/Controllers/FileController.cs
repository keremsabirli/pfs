using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;
using MongoDB.Driver;
using MongoDB.Driver.GridFS;
using PFSS.API.Controllers;
using PFSS.Models;
using PFSS.Services.Wrapper;
using System;
using System.Collections.Generic;
using System.Linq;
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
        [HttpGet]
        public ActionResult<IList<PFSS.Models.File>> Get()
        {
            var files = serviceWrapper.File.Get(x => x.User.Id == PFSUser.Id);
            return Ok(files);
        }
        [HttpPost]
        public async Task<ActionResult> Upload(List<IFormFile> files)
        {
            await Task.WhenAll(files.Select(file => serviceWrapper.File.Upload(file)));
            return Ok();
        }
    }
}
