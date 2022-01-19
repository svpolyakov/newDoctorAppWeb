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
            int.TryParse(Request.Headers["FilterType"], out int parseResult);
            string login = Request.Headers["UserLogin"].ToString();
            if (parseResult != 0 && Enum.IsDefined(typeof(FilterPersonTypeDto), parseResult))
            {
                Guid DepartmentId;
                Guid DoctorId;
	            int.TryParse(Request.Headers["Page"], out int page);
	            int.TryParse(Request.Headers["PageSize"], out int pageSize);
	            string sortLabel = Request.Headers["SortLabel"].ToString();
            	bool.TryParse(Request.Headers["IsDescending"], out bool isDescending);
                PersonQueryParamsDto personQueryParams = new PersonQueryParamsDto ();
                personQueryParams.PersonQueryType = (FilterPersonTypeDto)parseResult;
                personQueryParams.Page = new PageParamDto { OffSet = page * pageSize + 1, Size = pageSize };
                personQueryParams.SortBy = new SortByParamDto(){ AttributeName = sortLabel, IsDescending = isDescending};
                personQueryParams.SearchCondition = new SearchParamDto { DepartmentId = Guid.TryParse(Request.Headers["SearchDepartmentId"].ToString(), out DepartmentId) ? DepartmentId : Guid.Empty,
                    DoctorId = Guid.TryParse(Request.Headers["SearchDoctorId"].ToString(), out DoctorId) ? DoctorId : Guid.Empty, FIOCardNumber = Request.Headers["SearchFIOCardNumber"].ToString() };
                InpatientDoctorClient inpatientDoctorClient = new InpatientDoctorClient();
                inpatientDoctorClient.Endpoint.Binding.ReceiveTimeout = new TimeSpan(0, 10, 0);
                inpatientDoctorClient.Endpoint.Binding.OpenTimeout = new TimeSpan(0, 10, 0);
                inpatientDoctorClient.Endpoint.Binding.SendTimeout = new TimeSpan(0, 10, 0);
                inpatientDoctorClient.Endpoint.Binding.CloseTimeout = new TimeSpan(0, 10, 0);
                return await inpatientDoctorClient.GetPatientsAsync( personQueryParams , login);
            }

            return null;
        }
        
    }
}
