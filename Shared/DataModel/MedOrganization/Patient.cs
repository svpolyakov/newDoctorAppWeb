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
        public string SurName { get; set; }
        public string FirstName { get; set; }
        public string Patronymic { get; set; }
        public int? Age { get; set; }
        public DateTime? BirthDay { get; set; }
        public string ResponsibleDep { get; set; }
        public string StayDep { get; set; }
        public string Diagnos { get; set; }
        public string Doctor { get; set; }
        public string Room { get; set; }
        public string Bed { get; set; }
        public string ServiceCaseNumber { get; set; }
        public DateTime? SDDepTreatmentCase { get; set; }
        public DateTime? SDInpatientServiceCase { get; set; }
        public bool? InResuscitation { get; set; }
        public string PhysicalRestraint { get; set; }
        public string ObservationMode { get; set; }
        public string ObservationType { get; set; }
        public bool? IsChanged { get; set; }
        public Guid? VersionID { get; set; }
        public string AgeDescription { get; set; }
        public int Gender { get; set; }
    }
}
