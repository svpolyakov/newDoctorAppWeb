using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DoctorAppWeb.Shared.Models;

namespace DoctorAppWeb.Server.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ToolsController : Controller
    {
        [HttpGet]
        public ConnectionStatus Get()
        {
            return new ConnectionStatus { Status = "Ok"};
        }
    }
}
