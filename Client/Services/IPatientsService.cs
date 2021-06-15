using DoctorAppWeb.Shared.Models;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DoctorAppWeb.Client.Services
{
    public interface IPatientsService
    {        
        public Task<CustomPerson> GetCustomPerson();
        public Task<CustomGroupPerson> GetCustomGroupPerson();
        public Task<CustomGroupPerson[]> GetCustomGroupPersons();
        public Task SelectCustomGroupPerson(long id);
    }
}
