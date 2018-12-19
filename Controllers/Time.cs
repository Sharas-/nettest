using System;
using Microsoft.AspNetCore.Mvc;

namespace nettest.Controllers
{
    [Route("[controller]")]
    public class TimeController : Controller
    {
        // GET
        [HttpGet]
        public IActionResult Now()
        {
            return Ok( DateTime.Now );

        }
    }
}