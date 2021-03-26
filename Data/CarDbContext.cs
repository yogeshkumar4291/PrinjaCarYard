using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using PrinjaCarYard.Models;

namespace PrinjaCarYard.Data
{
    public class CarDbContext : IdentityDbContext
    {
        public CarDbContext(DbContextOptions<CarDbContext> options)
            : base(options)
        {
        }
        public DbSet<PrinjaCarYard.Models.Serie> Serie { get; set; }
        public DbSet<PrinjaCarYard.Models.Brand> Brand { get; set; }
        public DbSet<PrinjaCarYard.Models.Accessorie> Accessorie { get; set; }
    }
}
