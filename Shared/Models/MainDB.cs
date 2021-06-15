using IndexedDB.Blazor;
using Microsoft.JSInterop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorAppWeb.Shared.Models
{
    public class MainDB : IndexedDb
    {

        public MainDB(IJSRuntime jSRuntime, string name, int version) : base(jSRuntime, name, version) { }
        public IndexedSet<CustomAuthorization> CustomAuthorizations { get; set; }
        public IndexedSet<Info> InfoData { get; set; }

        // These are like tables. Declare as many of them as you want.
        public IndexedSet<Person> People { get; set; }
        public IndexedSet<CustomGridPerson> CustomGridPersons { get; set; }
        public IndexedSet<CustomGroupPerson> CustomGroupPersons { get; set; }
        /*public IndexedSet<Department> Departments { get; set; }
        public IndexedSet<Doctor> Doctors { get; set; }
        
        
        public IndexedSet<Patient> Patients { get; set; }*/
        public IndexedSet<CustomPerson> CustomPersons { get; set; }

    }
}
