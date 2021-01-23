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
    [ApiController]
    public class PFSController : ControllerBase
    {
        protected User PFSUser { get; set; }
        protected List<UserGroup> UserGroups { get; set; }
        protected readonly ServiceWrapper serviceWrapper;
        protected readonly IMapper mapper;
        public PFSController(ServiceWrapper serviceWrapper, IMapper mapper)
        {
            this.serviceWrapper = serviceWrapper;
            PFSUser = serviceWrapper.User.GetById("e14035fc-965f-47eb-b625-d63f1f574e7c").Result;
        }
    }
}
