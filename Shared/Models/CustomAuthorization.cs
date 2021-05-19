using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IndexedDB.Blazor;
using Microsoft.JSInterop;

namespace DoctorAppWeb.Shared.Models
{
    public class CustomAuthorization
    {
        [System.ComponentModel.DataAnnotations.Key]
        public long Id { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public bool? ActualAuthorization { get; set; }
        public bool Availability_751 { get; set; }
        public bool Availability_283 { get; set; }
        public bool Availability_265 { get; set; }
        public bool Availability_5 { get; set; }
        public DateTime? DateUpdate { get; set; }
        public string AuthorizationPage { get; set; }
    }

    public class MainDB : IndexedDb
    {
        public MainDB(IJSRuntime jSRuntime, string name, int version) : base(jSRuntime, name, version) { }
        public IndexedSet<CustomAuthorization> CustomAuthorizations { get; set; }
    }
}
