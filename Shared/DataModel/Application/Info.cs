using IndexedDB.Blazor;
using Microsoft.JSInterop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorAppWeb.Shared.DataModel.Application
{
    public class Info
    {
        [System.ComponentModel.DataAnnotations.Key]
        public long Id { get; set; }
        public DateTime? DateGetData { get; set; }
        public DateTime? DateSetData { get; set; }
    }    
}
