using DoctorAppWeb.Shared.SharedServices;

using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

using PatientsWcf;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DoctorAppWeb.Server.Controllers
{
 

    [ApiController]
    [Route("[controller]")]
    public class DoctorsController : ControllerBase
    {
        private readonly ILogger<DoctorsController> _logger;
        private readonly IDataWCFService _dataWCFService;

        public DoctorsController(ILogger<DoctorsController> logger, IDataWCFService dataWCFService)
        {
            _logger = logger;
            _dataWCFService = dataWCFService;
            _logger.LogDebug("Create");

        }

        public async Task<ActualDoctorDto[]> GetAsync( )
        {
            _logger.LogDebug("GetAsync");
            return await _dataWCFService.GetAllActualDoctorsAsync();
        }
    }
}
