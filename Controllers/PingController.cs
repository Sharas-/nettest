using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Security.Authentication.ExtendedProtection;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace nettest.Controllers
{
    [Route("[controller]")]
    public class PingController : Controller
    {
        class EnvVars { public string COMMIT_INFO = ""; public string COMMIT_HASH = ""; }

        public PingController(IHostingEnvironment env, IConfiguration config)
        {
            this.Env = env;
            this.Config = config;
        }

        public IConfiguration Config { get; set; }

        public IHostingEnvironment Env { get; set; }


        [HttpGet("")]
        public IActionResult Ping()
        {
            return Ok();
        }
        
        // GET
        [HttpGet("info")]
        public IActionResult Info()
        {
            EnvVars envVars = Config.Get<EnvVars>();
            var myIP = HttpContext.Features.Get<IHttpConnectionFeature>().LocalIpAddress.ToString();
            return Ok(new
            {
                Environment = Env.EnvironmentName,
                HostIP = myIP,
                Host_name = Environment.MachineName,
                CommitHash = envVars.COMMIT_HASH,
                CommitInfo = envVars.COMMIT_INFO
            });
        }
    }
}