using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Model.Identity
{
    public class AplicationRole : IdentityRole
    {
        public List<AplicationUserRole> UserRoles { get; set; }
    }
}
