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
        public async Task<IEnumerable<PersonDto>> GetAsync()
        {
            int parseResult;
            int.TryParse(Request.Headers["FilterType"], out parseResult);
            string login = Request.Headers["UserLogin"].ToString();
            if(parseResult != 0 && Enum.IsDefined(typeof(FilterPersonTypeDto), parseResult))
            {
                using InpatientDoctorClient inpatientDoctorClient = new InpatientDoctorClient();
                return await inpatientDoctorClient.GetPersonsAsync((FilterPersonTypeDto) parseResult, login);
            }
            return null;
        }
        
    }
}
