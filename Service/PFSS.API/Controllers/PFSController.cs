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
    [ApiController]
    public class PFSController : ControllerBase
    {
        protected User PFSUser { get; set; }
        public readonly ServiceWrapper serviceWrapper;
        public PFSController(ServiceWrapper serviceWrapper)
        {
            this.serviceWrapper = serviceWrapper;
        }
    }
}
