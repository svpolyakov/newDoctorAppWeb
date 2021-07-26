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
        public Tuple<UserInfoDto, CustomizationInfoDto> Get(string Login)
        {
            InpatientDoctorClient inpatientDoctorClient = new InpatientDoctorClient();
            return new Tuple<UserInfoDto, CustomizationInfoDto>(inpatientDoctorClient.GetUserInfoAsync(Login).Result, inpatientDoctorClient.GetCustomizationAsync(Login).Result);            
        }

        [HttpGet]
        public ConnectionStatus Get()
        {
            return new ConnectionStatus { Status = "Ok" };
        }
    }
}
