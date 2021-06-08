using Microsoft.AspNetCore.Mvc;
using PatientsWcf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;

namespace DoctorAppWeb.Server.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PersonsController : ControllerBase
    {
        [HttpGet]
        public IEnumerable<PersonDto> Get()
        {
            InpatientDoctorClient inpatientDoctorClient = new InpatientDoctorClient();
            
            return inpatientDoctorClient.GetPersonsAsync().Result.ToArray();
        }
    }
}
