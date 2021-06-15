using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorAppWeb.Shared.Models
{
    public class CustomPerson
    {
        [Key]
        public long Id { get; set; }
        public List<CustomGridPerson> CustomGridPerson { get; set; }
        public List<CustomGroupPerson> CustomGroupPersons { get; set; }
        public DateTime? DateUpdate { get; set; }
    }

    public class CustomGridPerson
    {
        [Key]
        public long Id { get; set; }
        public string NameColumnEn { get; set; }
        public string NameColumnRu { get; set; }
        public bool OrderColumn { get; set; }
        public bool VisibilityColumn { get; set; }
        public bool AvailableGroupings { get; set; }
        public bool IsGrouping { get; set; }
    }

    public class CustomGroupPerson
    {
        [Key]
        public long Id { get; set; }
        public string NameButtonEn { get; set; }
        public string NameButtonRu { get; set; }
        public bool OrderButton { get; set; }
        public bool Selected { get; set; }
    }
}
