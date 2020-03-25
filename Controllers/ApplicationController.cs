using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace DailyClass.Controllers
{
    [ApiController]
    [Route("/api")]
    public class ApplicationController : ControllerBase
    {
        [Route("")]
        public string Index(){
            return "GET index";
        }
    }
}
