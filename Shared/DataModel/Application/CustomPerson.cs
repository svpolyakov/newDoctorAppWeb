using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorAppWeb.Shared.DataModel.Application
{
    public class CustomGroupPerson
    {
        public string NameButtonEn { get; set; }
        public string NameButtonRu { get; set; }
        public bool Selected { get; set; }
        public DateTime? DateUpdate { get; set; }
    }
    public class CustomGridPerson
    {
        public string NameColumnEn { get; set; }
        public string NameColumnRu { get; set; }
        public int OrderColumn { get; set; }
        public bool VisibilityColumn { get; set; }
        public bool AvailableGroupings { get; set; }
        public bool IsGrouping { get; set; }
        public bool WhereToDisplay { get; set; }
        public DateTime? DateUpdate { get; set; }
    }

    public class CustomSettings
    {
        [Key]
        public long Id { get; set; }
        public int MaxPeriodData { get; set; }
        public int PeriodActive { get; set; }
        public DateTime? DateUpdate { get; set; }
        public bool OnlineMode { get; set; }
        public string FormID { get; set; }
    }

    public class PagesSettings
    {
        [Key]
        public long Id { get; set; }
        public string FormID { get; set; }
        public string FormSettings { get; set; }
    }
}
