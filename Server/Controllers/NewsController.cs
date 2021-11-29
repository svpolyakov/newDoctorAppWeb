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
    public class NewsController : Controller
    {
        [HttpGet("NewHealthcareServices")]
        public async Task<List<NewServiceInfoDto>> GetNewHealthcareServicesAsync([FromHeader] Guid healthcareServiceId)
        {
            return await new InpatientDoctorClient().GetNewHealthcareServicesAsync(healthcareServiceId);
        }

        [HttpGet("NewPatientDiagnos")]
        public async Task<NewFiagnosInfoDto> GetNewPatientDiagnosAsync([FromHeader] Guid diagnosId)
        {
            return await new InpatientDoctorClient().GetNewPatientDiagnosAsync(diagnosId);
        }

        [HttpGet("NewLabTest")]
        public async Task<List<NewParameterInfoDto>> GetNewLabTestAsync([FromHeader] Guid labTestId)
        {
            return await new InpatientDoctorClient().GetNewLabTestAsync(labTestId);
        }

        [HttpGet("NewInvestigation")]
        public async Task<InvestigationDto> GetNewInvestigationAsync([FromHeader] Guid investigationId)
        {
            return await new InpatientDoctorClient().GetNewInvestigationAsync(investigationId);
        }

        [HttpGet("NewConsultance")]
        public async Task<ConsultanceDto> GetNewConsultanceAsync([FromHeader] Guid consultanceId)
        {
            return await new InpatientDoctorClient().GetNewConsultanceAsync(consultanceId);
        }
    }
}
