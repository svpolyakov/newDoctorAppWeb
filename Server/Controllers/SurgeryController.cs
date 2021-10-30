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
    public class SurgeryController : ControllerBase
    {
        [HttpGet("SurgeryList")]
        public async Task<SurgeryDto[]> GetSurgeryListAsync([FromHeader] Guid patientId)
        {
            return await new InpatientDoctorClient().GetPatientSurgeryListAsync(patientId);
        }
    }
}
