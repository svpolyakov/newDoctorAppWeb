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

        [HttpGet("Users")]
        public async Task<List<UserDto>> GetUsersAsync([FromHeader] string login)
        {
            InpatientDoctorClient inpatientDoctorClient = new InpatientDoctorClient();
            return await inpatientDoctorClient.GetAllUsersAsync(login);
        }

        [HttpPost]
        public async Task<ActionResult<CustomizationInfoDto>> PostAsync([FromHeader] CustomizationInfoDto customizationInfo, [FromHeader] string Login, [FromHeader] string targetLogin)
        {
            InpatientDoctorClient inpatientDoctorClient = new InpatientDoctorClient();
            await inpatientDoctorClient.SaveCustomizationAsync(customizationInfo, Login, targetLogin);
            return await inpatientDoctorClient.GetCustomizationAsync(Login, targetLogin);
        }

        [HttpPost("Copy")]
        public async Task<ActionResult<CustomizationInfoDto>> CopyAsync([FromHeader] string sourceLogin, [FromHeader] string targetLogin)
        {
            InpatientDoctorClient inpatientDoctorClient = new InpatientDoctorClient();
            await inpatientDoctorClient.CopyCustomizationAsync(sourceLogin, targetLogin);
            return await inpatientDoctorClient.GetCustomizationAsync(targetLogin, null);
        }
    }
}
