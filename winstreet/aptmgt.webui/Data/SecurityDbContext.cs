using aptmgt.entity.user;
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
    public class SecurityDbContext : ApiAuthorizationDbContext<ApplicationUser>
    {
        //This was working DbContextOptions options,
        public SecurityDbContext(
            DbContextOptions<SecurityDbContext> options,
            IOptions<OperationalStoreOptions> operationalStoreOptions) : base(options, operationalStoreOptions)
        {
        }

        private const string SchemaName = "Security"; 
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.HasDefaultSchema(SchemaName);
            base.OnModelCreating(builder);
        }
    }
}
