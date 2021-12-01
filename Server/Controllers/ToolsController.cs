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
        [HttpGet("Login")]
        public async Task<Tuple<UserInfoDto, CustomizationInfoDto>> GetLoginAsync([FromQuery] string Login)
        {
            InpatientDoctorClient inpatientDoctorClient = new InpatientDoctorClient();
            return new Tuple<UserInfoDto, CustomizationInfoDto>(await inpatientDoctorClient.GetUserInfoAsync(Login), await inpatientDoctorClient.GetCustomizationAsync(Login, null));            
        }

        [HttpGet("Comment")]
        public async Task<ConsultanceCommentDto> GetCommentAsync([FromHeader] Guid personId, [FromHeader] Guid consultanceId, [FromHeader] string clientComment)
        {
            return await new InpatientDoctorClient().ResetConsultanceCommentAsync(personId, consultanceId, clientComment);
        }

        [HttpGet("Anamnesis")]
        public async Task<AnamnesisInfoDto> GetAnamnesisAsync([FromQuery] Guid id)
        {
            try
            {
                return await new InpatientDoctorClient().GetAnamnesisAsync(id);
            }
            catch (Exception e)
            {
                return null;
            }
        }

        //[HttpGet]
        //public ConnectionStatus Get()
        //{
        //    return new ConnectionStatus { Status = "Ok" };
        //}
    }
}
