using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Cors.Infrastructure;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Atrasis.Magic.Servers.Admin
{
	// Token: 0x02000005 RID: 5
	public class Startup
	{
		// Token: 0x06000014 RID: 20 RVA: 0x000020EF File Offset: 0x000002EF
		public Startup(IConfiguration configuration)
		{
			this.Configuration = configuration;
		}

		// Token: 0x17000006 RID: 6
		// (get) Token: 0x06000015 RID: 21 RVA: 0x000020FE File Offset: 0x000002FE
		public IConfiguration Configuration { get; }

		// Token: 0x06000016 RID: 22 RVA: 0x00002F18 File Offset: 0x00001118
		public void Configure(IApplicationBuilder app, IHostingEnvironment env)
		{
			if (env.IsDevelopment())
			{
				app.UseDeveloperExceptionPage();
			}
			else
			{
				app.UseExceptionHandler("/Home/Error");
				app.UseHsts();
			}
			app.UseStaticFiles();
			app.UseCookiePolicy();
			app.UseCors(delegate(CorsPolicyBuilder builder)
			{
				builder.AllowAnyOrigin();
				builder.AllowAnyHeader();
				builder.AllowAnyMethod();
			});
			app.UseMvc(delegate(IRouteBuilder routes)
			{
				routes.MapRoute("default", "{controller=Home}/{action=Index}/{id?}");
			});
		}

		// Token: 0x06000017 RID: 23 RVA: 0x00002106 File Offset: 0x00000306
		public void ConfigureServices(IServiceCollection services)
		{
			services.Configure(delegate(CookiePolicyOptions options)
			{
				options.CheckConsentNeeded = ((HttpContext context) => true);
				options.MinimumSameSitePolicy = SameSiteMode.None;
			});
			services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
		}
	}
}
