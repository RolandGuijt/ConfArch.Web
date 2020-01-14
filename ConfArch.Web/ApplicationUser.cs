using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace ConfArch.Web
{
    public class ApplicationUser: IdentityUser
    {
        public DateTime CareerStartedDate { get; set; }
        public string FullName { get; set; }
    }
}
