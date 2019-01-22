using System;
using Microsoft.AspNetCore.Mvc;
using nettest.repos;

namespace nettest.app.Controllers
{
    [Route("/api/[controller]")]
    public class TimeController : Controller
    {
        // GET
        [HttpGet]
        public IActionResult Now()
        {
            return Ok( new
            {
                Time = DateTime.Now,
                AccessCount = AccessCounter.UpdateCount()
            });
        }
    }
}
