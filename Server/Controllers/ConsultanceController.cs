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
    public class ConsultanceController : ControllerBase
    {
        [HttpGet("Consultance")]
        public async Task<PatientConsultanceResultDto> GetConsultanceAsync([FromHeader] Guid patientId, [FromHeader] Guid hcsId, [FromHeader] SrvType srvType)
        {
            return await new InpatientDoctorClient().GetPatientConsultanceListAsync(patientId, hcsId, srvType);
        }
    }
}
