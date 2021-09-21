using DoctorAppWeb.Shared.DataModel.MedOrganization;
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

        public async Task<Tuple<IEnumerable<Department>, IEnumerable<Doctor>>> GetAsync()
        {
            _logger.LogDebug("GetAsync");
            IEnumerable<DepartmentDto> departments = await _dataWCFService.GetAllDepartmentsAsync();
            IEnumerable<ActualDoctorDto> doctors = await _dataWCFService.GetAllActualDoctorsAsync();
            IEnumerable<Department> deps = departments.Select(x => new Department { BusinessElementID = x.BusinessElementID.ToString(), BusinessElementShortName = x.BusinessElementShortName, DateUpdate = x.DateUpdate });
            IEnumerable<Doctor> docs = new List<Doctor>();//doctors.Select(x => new Doctor { DateUpdate = x.DateUpdate, PersonFirstName = x.FirstName, PersonSurname = x.SurName, PersonPatronymic = x.Patronymic, PersonID = x.Id.ToString(), PersonnelID = x.PersonnelId.ToString(), PersonnelName = x.PersonnelName });
            return new Tuple<IEnumerable<Department>, IEnumerable<Doctor>>(deps, docs);
            
        }
    }
}
