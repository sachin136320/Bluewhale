using aptmgt.entity.user;
using aptmgt.entity.assets;
using aptmgt.entity.facility;
using aptmgt.entity.community;
using IdentityServer4.EntityFramework.Options;
using Microsoft.AspNetCore.ApiAuthorization.IdentityServer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace aptmgt.webui.Data
{
    public class ApplicationDBContext : DbContext
    {
        public ApplicationDBContext(
            DbContextOptions<ApplicationDBContext> options) : base(options)
        {
        }

        private const string SchemaName = "AppData";
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema(SchemaName);

            //modelBuilder.Entity<entity.builder.Builder>().Property(b => b.BuilderId).HasComputedColumnSql("");

            base.OnModelCreating(modelBuilder);
        }

        public DbSet<CommunityUser> CommunityUser { get; set; }
        public DbSet<AssetDetails> AssetDetails { get; set; }

        public DbSet<entity.builder.Builder> Builder { get; set; }
        
        public DbSet<CommunityBlock> CommunityBlock { get; set; }
        public DbSet<CommunityDetails> CommunityDetails { get; set; }
        public DbSet<CommunityFlats> CommunityFlats { get; set; }
        
        public DbSet<FacilityMaster> FacilityMaster { get; set; }

    }
}
