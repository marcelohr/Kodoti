using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Model.Identity
{
    public class AplicationUserRole : IdentityUserRole<string>
    {
        public AplicationUser User { get; set; }
        public AplicationRole Role { get; set; }
    }
}
