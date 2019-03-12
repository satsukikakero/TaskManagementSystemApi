using ApplicationCore.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;

namespace Infrastructure
{
    public class DbContext: IdentityDbContext<User>
    {
        public DbContext(DbContextOptions<DbContext> options) : base(options)
        {
        }
    }
}
