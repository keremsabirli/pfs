using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Primitives;
using PFSS.Models;
using PFSS.Services.Wrapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PFSS.API.Controllers
{
    [ApiController]
    public class PFSController : Controller
    {
        protected User PFSUser { get; set; }
        protected List<UserGroup> UserGroups { get; set; }
        protected readonly ServiceWrapper serviceWrapper;
        protected readonly IMapper mapper;
        public PFSController(ServiceWrapper serviceWrapper, IMapper mapper)
        {
            this.serviceWrapper = serviceWrapper;
            this.mapper = mapper;
        }
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            StringValues Token;
            context.HttpContext.Request.Headers.TryGetValue("Token", out Token);
            var token = Token.ToString().Split()[1];
            PFSUser = serviceWrapper.User.GetByToken(token).Result;
            if (PFSUser == null)
            {
                var responseModel = new ResponseModel<object>() { Status = ResponseType.Error, UserMessage = "Invalid Token" };
                context.Result = new ObjectResult(responseModel){ StatusCode = 403 };
            } 
            base.OnActionExecuting(context);
        }
    }
}
