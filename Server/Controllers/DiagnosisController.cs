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
    public class DiagnosisController : ControllerBase
    {
        [HttpGet]
        public async Task<IEnumerable<DepartmentPatientDiagnosInfoDto>> GetAsync()
        {
            Guid parsePersonId;
            Guid parseHealthcareServiceId;
            bool parseIsArchive;
            Guid.TryParse(Request.Headers["PersonId"], out parsePersonId);
            bool.TryParse(Request.Headers["Archive"], out parseIsArchive);
            Guid.TryParse(Request.Headers["HealthcareServiceId"], out parseHealthcareServiceId);
            InpatientDoctorClient inpatientDoctorClient = new InpatientDoctorClient();
            try
            {
                return await inpatientDoctorClient.GetPatientDiagnosisAsync(parsePersonId, parseIsArchive, parseIsArchive ? Guid.Empty : parseHealthcareServiceId);
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}

