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
        public string PersonID { get; set; }
        public string PersonnelID { get; set; }
        public string PersonSurname { get; set; }
        public string PersonFirstName { get; set; }
        public string PersonPatronymic { get; set; }
        public string PersonnelName { get; set; }
        public DateTime? DateUpdate { get; set; }
        public List<PersonnelPositionDto> PersonnelPositionList { get; set; }
    }

    public class PersonnelPositionDto
    {
        public Guid PositionTypeId { get; set; }
        public string PositionType { get; set; }
    }
}
