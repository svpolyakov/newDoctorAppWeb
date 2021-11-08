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
    public class AnalysisController : ControllerBase
    {
        [HttpGet("Analysis")]
        public async Task<List<LabTestDto>> GetAnalysisAsync([FromHeader] Guid personId, [FromHeader] Guid hcsId, [FromHeader] SrvType srvType)
        {
            return await new InpatientDoctorClient().GetLabTestsAsync(personId, hcsId, srvType);
        }
    }
}
