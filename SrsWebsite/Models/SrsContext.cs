using System;
using Microsoft.EntityFrameworkCore;

namespace SrsWebsite.Models
{
    public class SrsContext : DbContext
    {
        public SrsContext(DbContextOptions<SrsContext> options): base(options) { }

        public DbSet<User> Users { get; set; }
        public DbSet<Shooting> Shootings { get; set; }
        public DbSet<CaliberType> CaliberTypes { get; set; }
        public DbSet<PaymentType> PaymentTypes { get; set; }
        public DbSet<ShootingType> ShootingTypes { get; set; }
    }


}