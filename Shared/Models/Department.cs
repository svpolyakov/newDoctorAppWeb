using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorAppWeb.Shared.Models
{
    public class Department
    {
        [Key]
        public int ID { get; set; }
        public string BusinessElementID { get; set; }
        public string BusinessElementShortName { get; set; }
        public DateTime? DateUpdate { get; set; }
    }
}
