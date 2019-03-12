using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace ApplicationCore.Entities
{
    public class User: IdentityUser
    {
        public string Password { get; set; }
    }
}
