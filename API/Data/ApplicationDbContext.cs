using API.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Net.NetworkInformation;
using System.Reflection.Emit;

namespace API.Data
{
    public class ApplicationDbContext : DbContext
    {

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }
        
        public DbSet<CustPhone> CustPhones { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CustPhone>().ToTable("CustPhone");
            modelBuilder.Entity<CustPhone>().HasKey(u => new
            {
                u.CustId,
                u.PhoneNo
            });
        }
        
    }
}
