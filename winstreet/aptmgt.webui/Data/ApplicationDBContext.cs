using aptmgt.entity.user;
using aptmgt.entity.assets;
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
			DbContextOptions<ApplicationDBContext> options ) : base(options)
		{
		}

		private const string SchemaName = "AppData";
		protected override void OnModelCreating(ModelBuilder builder)
		{
			builder.HasDefaultSchema(SchemaName);
			base.OnModelCreating(builder);
		}

		public DbSet<CommunityUser> CommunityUser { get; set; }		
		public DbSet<AssetDetails> AssetDeails { get; set; }

	}
}
