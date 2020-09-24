using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace LaugamaCorp.Server
{
    public class ApplicationUser : IdentityUser
    {
        public string Cargo { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
    }
}
