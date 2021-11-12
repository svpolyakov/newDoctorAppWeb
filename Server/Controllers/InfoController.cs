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
    public class InfoController : ControllerBase
    {
        [HttpGet("MedDocList")]
        public async Task<List<ServiceMedDocDto>> GetMedDocListAsync([FromHeader]Guid personId, [FromHeader]Guid hcsId)
        {
            return await new InpatientDoctorClient().GetMedDocListAsync(personId, hcsId);
        }

        [HttpGet("MedDoc")]
        public async Task<MedDocDto> GetMedDocAsync([FromHeader] Guid epicrisisVersionId)
        {
            return await new InpatientDoctorClient().GetMedDocAsync(epicrisisVersionId);
        }
    }
}
