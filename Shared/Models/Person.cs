using IndexedDB.Blazor;
using Microsoft.JSInterop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorAppWeb.Shared.Models
{
    public class Person
    {
        [System.ComponentModel.DataAnnotations.Key]
        public long Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }

     
}
