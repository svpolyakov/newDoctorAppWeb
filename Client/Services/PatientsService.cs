using DoctorAppWeb.Shared.DataModel;
using DoctorAppWeb.Shared.DataModel.Application;
using DoctorAppWeb.Shared.DataModel.MedOrganization;
using IndexedDB.Blazor;

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace DoctorAppWeb.Client.Services
{


    public interface IPatientsService
    {
        public List<Patient> AllPersons { get; set; }
        public long? FilterType { get; set; }
        public string UserName { get; set; }
        public Guid CurrentPatient { get; set; }
        public string CurrentPage { get; set; }
    }



    public class PatientsService: IPatientsService
    {
        public List<Patient> AllPersons { get; set; }
        public long? FilterType { get; set; }
        public string UserName { get; set; }
        public Guid CurrentPatient { get; set; }
        private readonly IIndexedDbFactory _dbFactory;        
        public PatientsService(IIndexedDbFactory dbFactory) {
            _dbFactory = dbFactory;
        }
        public string CurrentPage { get; set; }       
    }
}
