﻿using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace ApplicationCore.Entities
{
    public class User: IdentityUser, IEntity
    {
        public string Password { get; set; }

        public ICollection<UserTask> UserTasks { get; set; }
    }
}
