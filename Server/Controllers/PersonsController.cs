using Microsoft.AspNetCore.Mvc;
using PatientsWcf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Logging;

namespace DoctorAppWeb.Server.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PersonsController : ControllerBase
    {
        private readonly ILogger<PersonsController> _logger;

        public PersonsController(ILogger<PersonsController> logger) {
            _logger = logger;
            _logger.LogDebug("Create");
        }

        [HttpGet]
        public async Task<IEnumerable<PatientDto>> GetAsync()
        {
            int parseResult;
            int.TryParse(Request.Headers["FilterType"], out parseResult);
            string login = Request.Headers["UserLogin"].ToString();
            if(parseResult != 0 && Enum.IsDefined(typeof(FilterPersonTypeDto), parseResult))
            {
                InpatientDoctorClient inpatientDoctorClient = new InpatientDoctorClient();
                inpatientDoctorClient.Endpoint.Binding.ReceiveTimeout = new TimeSpan(0, 10, 0);
                inpatientDoctorClient.Endpoint.Binding.OpenTimeout = new TimeSpan(0, 10, 0);
                inpatientDoctorClient.Endpoint.Binding.SendTimeout = new TimeSpan(0, 10, 0);
                inpatientDoctorClient.Endpoint.Binding.CloseTimeout = new TimeSpan(0, 10, 0);
                return await inpatientDoctorClient.GetPatientsAsync( new PersonQueryParamsDto { PersonQueryType = (FilterPersonTypeDto)parseResult } , login);
            }
            return null;
        }
        
    }
}
