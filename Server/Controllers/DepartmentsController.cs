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
            IEnumerable<Department> deps = departments.Select(x => new Department { BusinessElementID = x.BusinessElementID.ToString(), BusinessElementFullName = x.BusinessElementFullName});
            IEnumerable<Doctor> docs = doctors.Select(x => new Doctor {FirstName = x.FirstName, SurName = x.SurName, Patronymic = x.Patronymic, PersonId = x.PersonId, PersonnelPositionList = x.PersonnelPositionList.Select(x => new PersonnelPosition { PositionType = x.PositionType, IdPersonnel = x.IdPersonnel, Department = x.Department}).ToList() });
            return new Tuple<IEnumerable<Department>, IEnumerable<Doctor>>(deps, docs);
            
        }
    }
}
