using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Security.Authentication.ExtendedProtection;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace nettest.Controllers
{
    [Route("[controller]")]
    public class DiagnosisController : Controller
    {
        public DiagnosisController(IServiceCollection services, IHostingEnvironment env)
        {
            this.Services = services;
            this.Env = env;
        }

        public IHostingEnvironment Env { get; set; }

        public IServiceCollection Services { get; set; }

        // GET
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(new
            {
                Environment = Env.EnvironmentName,
                Middleware = GetMiddleware()
            });
        }

        private IEnumerable<string> GetMiddleware()
        {
            return Services.Select(service => service.ServiceType.ToString());
        }
    }
}