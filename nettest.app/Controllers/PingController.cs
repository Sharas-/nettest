using System;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace nettest.app.Controllers
{
    [Route("/api/[controller]")]
    public class PingController : Controller
    {
        class EnvVars
        {
            public string COMMIT_INFO { get; set; } = "";
            public string COMMIT_HASH { get; set; } = "";
            public object COMMIT_NR { get; set; } = "";
        }

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
            return Ok(new
            {
                Environment = Env.EnvironmentName,
                HostIP = HttpContext.Connection.LocalIpAddress.ToString(),
                HostName = Environment.MachineName,
//                CommitHash = envVars.COMMIT_HASH,
//                CommitInfo = envVars.COMMIT_INFO,
//                CommitNr = envVars.COMMIT_NR
            });
        }
    }
}
