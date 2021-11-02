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
    public class MedicamentsController : ControllerBase
    {
        [HttpGet("Medicaments")]
        public async Task<PatientMedicamentResultDto> GetMedicamentsAsync([FromHeader] Guid patientId, [FromHeader] Guid hcsId, [FromHeader] SrvType srvType)
        {
            return await new InpatientDoctorClient().GetPatientMedicamentListAsync(patientId, hcsId, srvType);
        }
    }
}
