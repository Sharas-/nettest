using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace nettest
{
	internal class Startup
	{
		public Startup(IConfiguration config)
		{
			this.Configuration = config;
		}
		internal IConfiguration Configuration { get; }
		
		public void Configure(IHostingEnvironment env, IApplicationBuilder app)
		{
			app.UseMvc();
		}

		public void ConfigureDevelopmentServices(IServiceCollection services) 
		{
			ConfigureServices(services);
		}

		public void ConfigureServices(IServiceCollection services)
		{
			services.AddLogging(logBuilder =>
			{
				logBuilder.AddConfiguration(Configuration.GetSection("logging"));
				logBuilder.AddConsole();
			});
			services.AddMvc();
			services.AddSingleton(services);
		}
	}
}
