using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DoctorAppWeb.Server.Models
{
//    public class ApplicationUser : IdentityUser
    public class ApplicationUser 
    {
        public  string Id { get; set; }
        public string UserName { get; set; }
        public string SecurityStamp { get; set; }
        //[PersonalData]
        //public Guid UserId { get; set; }
        //[PersonalData]
        //public string FirstName { get; set; }
        //[PersonalData]
        //public string LastName { get; set; }
        //[PersonalData]
        //public string MiddleName { get; set; }
        //[PersonalData]
        //public string Snils { get; set; }
        //[PersonalData]
        //public string Permissions { get; set; }
    }
}
