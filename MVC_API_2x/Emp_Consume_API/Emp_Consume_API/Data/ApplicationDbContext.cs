using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Emp_Consume_API.Models;

namespace Emp_Consume_API.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<Emp_Consume_API.Models.Departments> Departments { get; set; }
        public DbSet<Emp_Consume_API.Models.Employees> Employees { get; set; }
    }
}
