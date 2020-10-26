using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using PurchaseAssistantWebApp.Models;

namespace PurchaseAssistantWebApp.Database
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        #region Entities

        public DbSet<User> Users { get; set; }
        public DbSet<SalesRepresentative> SalesRepresentatives { get; set; }
        public DbSet<CallSetupRequest> PendingRequests { get; set; }
        public DbSet<CallSetupRequest> ServedRequests { get; set; }
        public DbSet<ModelsSpecification> Models { get; set; }

        #endregion

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<CallSetupRequest>().Property(p => p.SelectedModels).HasConversion(
            v => JsonConvert.SerializeObject(v),
            v => JsonConvert.DeserializeObject<List<string>>(v));

            
        }
    }
}
