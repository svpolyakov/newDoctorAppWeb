using PatientsWcf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorAppWeb.Shared.SharedServices
{
    /// <summary>
    /// 
    /// </summary>
    public interface IDataWCFService
    {
        public Task<Guid?> AuthorizeAsync(string login, string password);
        public Task<List<PatientDto>> GetPersonsAsync(FilterPersonTypeDto filterPersonType, string login);
        public Task<List<IndicantDto>> GetIndicantAsync(System.Guid id);
        public Task<List<ActualDoctorDto>> GetAllActualDoctorsAsync();
        public Task<List<DepartmentDto>> GetAllDepartmentsAsync();
    }
}
