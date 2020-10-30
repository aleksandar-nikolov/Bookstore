using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using BookStore_API.Contracts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BookStore_API.Controllers
{
    public class CustomControllerBase : ControllerBase
    {
        protected ILoggerService Logger { get; }
        protected IMapper Mapper { get; }

        public CustomControllerBase(ILoggerService logger, IMapper mapper)
        {
            this.Mapper = mapper;
            this.Logger = logger;
        }

        protected void LogEndpointAttempt()
        {
            Logger.LogInfo($"{GetActionInfo()} Attempt");
        }

        protected IActionResult GetInternalError(Exception e)
        {
            return GetInternalError($"{e.Message} - {e.InnerException?.Message}");
        }

        protected IActionResult GetInternalError(string message)
        {
            Logger.LogError($"{GetActionInfo()} - {message}");
            return StatusCode(StatusCodes.Status500InternalServerError, message);
        }

        protected string GetActionInfo()
        {
            return
                $"{ControllerContext.ActionDescriptor.ControllerName} - {ControllerContext.ActionDescriptor.ActionName}";
        }
    }
}
