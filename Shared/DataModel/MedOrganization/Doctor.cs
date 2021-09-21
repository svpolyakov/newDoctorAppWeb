using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorAppWeb.Shared.DataModel.MedOrganization
{
    public class Doctor
    {
        [Key]
        public int ID { get; set; }
        public Guid PersonId { get; set; }
        public string SurName { get; set; }
        public string FirstName { get; set; }
        public string Patronymic { get; set; }
        public List<PersonnelPosition> PersonnelPositionList { get; set; }
    }

    public class PersonnelPosition
    {
        public Guid IdPersonnel { get; set; }
        public string PositionType { get; set; }
        public string Department { get; set; }
    }
}
