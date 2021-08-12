﻿using IndexedDB.Blazor;
using Microsoft.JSInterop;
using DoctorAppWeb.Shared.DataModel.Application;
using DoctorAppWeb.Shared.DataModel.MedOrganization;

namespace DoctorAppWeb.Shared.DataModel
{
    public class IndexedApplicationDb : IndexedDb
    {
        public IndexedSet<CustomAuthorization> CustomAuthorizations { get; set; }
        public IndexedSet<Info> InfoData { get; set; }        
        public IndexedSet<CustomGridPerson> CustomGridPersons { get; set; }
        public IndexedSet<CustomGroupPerson> CustomGroupPersons { get; set; }
        public IndexedSet<CustomPerson> CustomPersons { get; set; }
        public IndexedSet<Patient> Patients { get; set; }
        public IndexedSet<CustomSettings> CustomSettings { get; set; }
        public IndexedSet<Webpages> Webpages { get; set; }
        public IndexedSet<Doctor> Doctors { get; set; }
        public IndexedSet<Department> Departments { get; set; }
        public IndexedSet<FromDepartments> FromDepartments { get; set; }
        public IndexedSet<ReplacementDoctor> ReplacementDoctors { get; set; }
        public IndexedApplicationDb(IJSRuntime jSRuntime, string name, int version) : base(jSRuntime, name, version) { }        
    }
}
