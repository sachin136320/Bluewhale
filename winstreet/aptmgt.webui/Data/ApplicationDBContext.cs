using aptmgt.entity.user;
using aptmgt.entity.assets;
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


        #region Community
        public DbSet<entity.builder.Builder> Builder { get; set; }
        public DbSet<CommunityBlock> CommunityBlock { get; set; }
        public DbSet<CommunityDetails> CommunityDetails { get; set; }
        public DbSet<CommunityFlats> CommunityFlats { get; set; }
        #endregion Community

        #region AssestRelatedTables 
        public DbSet<AssetDetails> AssetDetails { get; set; }        
        public DbSet<AssetRequest> AssetRequest { get; set; }
        public DbSet<ServiceDetails> ServiceDetails { get; set; }
        public DbSet<ServiceHistory> ServiceHistory { get; set; }
        #endregion AssestRelatedTables

        #region Visitor
        public DbSet<VisitorDetails> VisitorDetails { get; set; }
        #endregion Visitor

        #region Facility
        public DbSet<entity.facility.FacilityBooking> FacilityBooking { get; set; }
        public DbSet<entity.facility.FacilityBookingHistory> FacilityBookingHistory { get; set; }
        public DbSet<entity.facility.FacilityMaster> FacilityMaster { get; set; }
        #endregion Facility

        #region ParkingManagement 
        //public DbSet<entity.parking.ParkingAssignment> ParkingAssignment { get; set; }
        //public DbSet<entity.parking.ParkingAssignmentHistory> ParkingAssignmentHistory { get; set; }
        #endregion ParkingManagement 

        #region User
        public DbSet<CommunityUser> CommunityUser { get; set; }
        public DbSet<ApplicationUser> ApplicationUser { get; set; }
        public DbSet<OwnerMaster> OwnerMaster { get; set; }
        public DbSet<Role> Role { get; set; }
        #endregion User

        #region Vehicle
        //public DbSet<entity.vehicles.VehicleDetails> VehicleDetails { get; set; }
        //public DbSet<entity.vehicles.VehicleDetailsHistory> VehicleDetailsHistory { get; set; }
        #endregion Vehicle

        #region Accounts
        //public DbSet<entity.Accounts.Account> Account { get; set; }
        //public DbSet<entity.Accounts.Expense> Expense { get; set; }
        //public DbSet<entity.Accounts.maintMaster> maintMaster { get; set; }
        //public DbSet<entity.Accounts.MonthlyMaint> MonthlyMaint { get; set; }
        //public DbSet<entity.Accounts.SourceOthers> SourceOthers { get; set; }
        //public DbSet<entity.Accounts.TransactionMaster> TransactionMaster { get; set; }
        #endregion Accounts

        #region Polls
        //public DbSet<entity.poll.Poll> Poll { get; set; }
        //public DbSet<entity.poll.PollQuestion> PollQuestion { get; set; }
        //public DbSet<entity.poll.PollResponse> PollResponse { get; set; }
        #endregion Polls



    }
}
