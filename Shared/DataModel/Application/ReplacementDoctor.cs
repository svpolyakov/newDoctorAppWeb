using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorAppWeb.Shared.DataModel.Application
{
    public class ReplacementDoctor
    {
        [Key]
        public long Id { get; set; }
        public Guid PersonId { get; set; }
        public Guid PositionTypeID { get; set; }
        public bool Selected { get; set; }
        public DateTime DateUpdate { get; set; }
    }
}
