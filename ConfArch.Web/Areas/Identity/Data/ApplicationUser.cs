using Microsoft.AspNetCore.Identity;
using System;

namespace ConfArch.Web
{
    public class ApplicationUser : IdentityUser
    {
        [PersonalData]      // all data marked with this attriubute will be deleted when user deletes account
        public DateTime CareerStarted { get; set; }
        public string FullName { get; set; }
    }
}
