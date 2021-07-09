using DoctorAppWeb.Shared.DataModel.Application;

using Microsoft.AspNetCore.Mvc;
using PatientsWcf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DoctorAppWeb.Server.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ToolsController : Controller
    {
        [HttpGet("{Login}")]
        public UserInfoDto Get(string Login)
        {
            return new InpatientDoctorClient().GetUserInfoAsync(Login).Result;
        }

        [HttpGet]
        public ConnectionStatus Get()
        {
            return new ConnectionStatus { Status = "Ok" };
        }
    }
}
