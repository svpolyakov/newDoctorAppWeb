using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorAppWeb.Shared.DataModel.Application
{
    public class FromDepartments
    {
        [Key]
        public long Id { get; set; }
        public Guid BusinessElementID { get; set; }
        public bool Selected { get; set; }
        public DateTime DateUpdate { get; set; }
    }
}