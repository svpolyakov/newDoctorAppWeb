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
        public Task<PatientsWcf.PatientDto[]> GetPersonsAsync(FilterPersonTypeDto filterPersonType, string login);
        public Task<PatientsWcf.IndicantDto[]> GetIndicantAsync(System.Guid id);
        public Task<PatientsWcf.ActualDoctorDto[]> GetAllActualDoctorsAsync();
        public Task<PatientsWcf.DepartmentDto[]> GetAllDepartmentsAsync();
    }
}
