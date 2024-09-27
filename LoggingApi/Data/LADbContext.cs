using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Model;

namespace LoggingApi.Data
{
    public class LADbContext : DbContext
    {
        public LADbContext(DbContextOptions<LADbContext> options) : base(options) { }

        public DbSet<Logging>? logging { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}