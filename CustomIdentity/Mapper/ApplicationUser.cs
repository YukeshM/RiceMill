using Microsoft.AspNetCore.Identity;
using System;

namespace CustomIdentity
{
    public class ApplicationUser : IdentityUser<Guid>
    {
        public int Age
        {
            get; set;
        }

        public string LastName
        {
            get; set;
        }

        public int GenderId
        {
            get; set;
        }
    }
}
