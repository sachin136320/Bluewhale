using aptmgt.entity.impl.user;
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
	public class ApplicationDBContext : ApiAuthorizationDbContext<ApplicationUser>
	{
		public ApplicationDBContext(
			DbContextOptions options,
			IOptions<OperationalStoreOptions> operationalStoreOptions) : base(options, operationalStoreOptions)
		{
		}

		private const string SchemaName = "AppData";
		protected override void OnModelCreating(ModelBuilder builder)
		{
			builder.HasDefaultSchema(SchemaName);
			base.OnModelCreating(builder);
		}
	}
}
