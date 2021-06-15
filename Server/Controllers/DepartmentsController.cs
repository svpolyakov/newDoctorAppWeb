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
    public class DepartmentsController : ControllerBase
    {
        private readonly ILogger<DepartmentsController> _logger;
        private readonly IDataWCFService _dataWCFService;

        public DepartmentsController(ILogger<DepartmentsController> logger, IDataWCFService dataWCFService)
        {
            _logger = logger;
            _dataWCFService = dataWCFService;
            _logger.LogDebug("Create");

        }

        public async Task<IEnumerable<DepartmentDto>> GetAsync()
        {
            _logger.LogDebug("GetAsync");
            IEnumerable<DepartmentDto> departments = await _dataWCFService.GetAllDepartmentsAsync();
            return departments;
        }
    }
}
