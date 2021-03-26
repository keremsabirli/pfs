using AutoMapper;
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
    public class PFSAuthenticatedController : PFSController
    {
        public PFSAuthenticatedController(ServiceWrapper serviceWrapper, IMapper mapper) : base(serviceWrapper, mapper)
        {
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
                context.Result = new ObjectResult(responseModel) { StatusCode = 403 };
            }
            base.OnActionExecuting(context);
        }
    }
}
