using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorAppWeb.Shared.DataModel.MedOrganization
{
    public class Doctor
    {
        public int ID { get; set; }
        public string PersonID { get; set; }
        public string PersonSurname { get; set; }
        public string PersonFirstName { get; set; }
        public string PersonPatronymic { get; set; }
        public DateTime? DateUpdate { get; set; }
    }
}
