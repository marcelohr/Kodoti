using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Model.Identity
{
    public class AplicationUser : IdentityUser
    {
        public DateTime? BirthDate { get; set; }
        public List<AplicationUserRole> UserRoles { get; set; }
    }
}
