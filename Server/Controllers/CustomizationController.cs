using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PatientsWcf;

namespace DoctorAppWeb.Server.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CustomizationController : Controller
    {
        [HttpGet]
        public async Task<CustomizationInfoDto> GetAsync()
        {
            string login = Request.Headers["UserLogin"].ToString();
            return  await new InpatientDoctorClient().GetCustomizationAsync(login, null);
        }

        [HttpPost]
        public async Task PostAsync()
        {
            //new InpatientDoctorClient().SaveCustomizationAsync()
        }
    }
}
