using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IndexedDB.Blazor;
using Microsoft.JSInterop;

namespace DoctorAppWeb.Shared.DataModel.Application
{
    public class CustomAuthorization
    {
        [System.ComponentModel.DataAnnotations.Key]
        public long Id { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public DateTime? DateActual { get; set; }
        public DateTime? DateUpdate { get; set; }        
        public int? PeriodActive { get; set; }
        public bool Availability_751 { get; set; }
        public bool Availability_283 { get; set; }
        public bool Availability_265 { get; set; }
        public bool Availability_5 { get; set; }
        //public List<DepartmentInfoDto> DepartmentInfoList { get; set; }        
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string MiddleName { get; set; }
        public string Snils { get; set; }
        public string Permissions { get; set; }
        public string AuthorizationPage { get; set; }
        public Guid? UserId { get; set; }
    }    
}
