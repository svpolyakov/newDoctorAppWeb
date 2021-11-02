using DoctorAppWeb.Shared.SharedServices;

using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PatientsWcf;

namespace DoctorAppWeb.Server.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class IndicantsController : ControllerBase
    {
        private readonly ILogger<IndicantsController> _logger;
        private readonly IDataWCFService _dataWCFService;

        public IndicantsController(ILogger<IndicantsController> logger, IDataWCFService dataWCFService)
        {
            _logger = logger;
            _dataWCFService = dataWCFService;
            _logger.LogDebug("Create");
            
        }

        public async Task<List<IndicantDto>> GetAsync(System.Guid id)
        {
            _logger.LogDebug("GetAsync");
            return await _dataWCFService.GetIndicantAsync(id);
        }

        [HttpGet("Table")]
        public async Task<List<PatientIndicantDto>> GetTableAsync([FromHeader] System.Guid hServiceId, [FromHeader] double maxPeriodData)
        {
            _logger.LogDebug("GetTableAsync");
            InpatientDoctorClient inpatientDoctorClient = new InpatientDoctorClient();
            
            return await inpatientDoctorClient.GetIndicantTableAsync(hServiceId, maxPeriodData);
        }

        [HttpGet("Chart")]
        public async Task<List<IndicantChartDto>> GetChartAsync([FromHeader] System.Guid hServiceId, [FromHeader] double maxPeriodData)
        {
            _logger.LogDebug("GetChartAsync");
            InpatientDoctorClient inpatientDoctorClient = new InpatientDoctorClient();

            return await inpatientDoctorClient.GetIndicantChartAsync(hServiceId, maxPeriodData);
        }
    }
}
