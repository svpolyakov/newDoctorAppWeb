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
    public class ProceduresController : ControllerBase
    {
        [HttpGet("Procedures")]
        public async Task<List<ProcedureResultDto>> GetProceduresAsync([FromHeader] Guid personId, [FromHeader] Guid hcsId, [FromHeader] SrvType srvType)
        {
            return await new InpatientDoctorClient().GetProceduresAsync(personId, hcsId, srvType);
        }
    }
}
