using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorAppWeb.Shared.DataModel.MedOrganization
{
    public class Patient
    {
        [Key]
        public int ID { get; set; }
        
        public Guid PersonID { get; set; }
        
        public string Firstname { get; set; }
        
        public string Lastname { get; set; }
        
        public string Patronymic { get; set; }
        
        public int SexEnum { get; set; }
        
        public string Birthday { get; set; }
        
        public int Age { get; set; }
        
        public string AgeDescription { get; set; }
        
        public string ResponsibleDep { get; set; }
        
        public string StayDep { get; set; }
        
        public string Diagnos { get; set; }
        
        public string Doctor { get; set; }
        
        public string Room { get; set; }
        
        public string Bed { get; set; }
        
        public string ServiceCaseNumber { get; set; }
        
        public DateTime? SDDepTreatmentCase { get; set; }
        
        public string SDInpatientServiceCase { get; set; }
        
        public bool InResuscitation { get; set; }
        
        public string PhysicalRestraint { get; set; }
        
        public string ObservationMode { get; set; }
        
        public string ObservationType { get; set; }
        
        public bool isChanged { get; set; }
        
        public Guid? VersionID { get; set; }
        
        public string HelpForm { get; set; }
        
        public DateTime? SDReceptionCase { get; set; }
        
        public AdmissionInfo AdmissionInfo { get; set; }
        
        public Guid HealthcareServiceId { get; set; }
        
        public bool IsWorking { get; set; }
        
        public string IsWorkingStr { get; set; }
        
        public string Benefits { get; set; }
        
        public Guid DiagnosAnamnesisID { get; set; }
        
        public Guid PathologyАnamnesisID { get; set; }
        
        public Guid LifeAnamnesisID { get; set; }
        
        public Guid PersonnelID { get; set; }
        public bool ShowDetails { get; set; }
        public string GetPropertyValue(string propertyName)
        {
            try
            {
                return this.GetType().GetProperty(propertyName)?.GetValue(this, null)?.ToString();
            }
            catch { return null; }
        }
    }

    public class AdmissionInfo
    {
        public string InpatientSrv { get; set; }
        public string Dtc { get; set; }
        public string ReceptCase { get; set; }
    }
}
