using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorAppWeb.Shared.DataModel.MedOrganization
{
    public class Department
    {
        [Key]
        public int ID { get; set; }
        public string BusinessElementID { get; set; }
        public string BusinessElementFullName { get; set; }
        public DateTime? DateUpdate { get; set; }
    }
}
