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


        #region Assets
        public DbSet<AssetDetails> AssetDetails { get; set; }
        #endregion Assets

        #region Builder
        public DbSet<entity.builder.Builder> Builder { get; set; }
        #endregion Builder
        
        #region Community
        public DbSet<CommunityBlock> CommunityBlock { get; set; }
        public DbSet<CommunityDetails> CommunityDetails { get; set; }
        public DbSet<CommunityFlats> CommunityFlats { get; set; }
        #endregion Community

        #region Facility
        public DbSet<FacilityMaster> FacilityMaster { get; set; }
        #endregion Facility
        
        #region User
        public DbSet<CommunityUser> CommunityUser { get; set; }
        public DbSet<OwnerMaster> OwnerMaster { get; set; }
        public DbSet<Role> Role { get; set; }
        public DbSet<Tenants> Tenants { get; set; }
        public DbSet<Vendor> Vendor { get; set; }
        #endregion User

    }
}
