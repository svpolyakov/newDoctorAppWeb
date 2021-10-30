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
    public class InvestigationsController : ControllerBase
    {
        [HttpGet("Investigations")]
        public async Task<InvestigationsResultDto> GetInvestigationsAsync([FromHeader] Guid patientId, [FromHeader] Guid hcsId, [FromHeader] SrvType srvType)
        {
            return await new InpatientDoctorClient().GetInvestigationsAsync(patientId, hcsId, srvType);
        }
    }
}
