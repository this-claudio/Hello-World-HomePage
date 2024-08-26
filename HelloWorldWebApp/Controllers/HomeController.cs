using HelloWorld.Model;
using Microsoft.AspNetCore.Mvc;

namespace HelloWorldWebApplication.Controllers
{
    [ApiController]
    [Route("")]
    public class HomeController : ControllerBase
    {
 
        private readonly ILogger<HomeController> _logger;

        private readonly IWebHostEnvironment _env;

        public HomeController(ILogger<HomeController> logger, IWebHostEnvironment env)
        {
            _logger = logger;
            _env = env;
        }

        [HttpGet()]
        [Route("status")]
        public StatusModel GetStatus()
        {
            _logger.LogInformation($"[{DateTime.Now}] Get /Status");
            return new StatusModel(Environment.MachineName, Environment.OSVersion.VersionString, true, System.Diagnostics.Process.GetCurrentProcess().Id.ToString());
        }

        [HttpGet()]
        [Route("home")]
        public IActionResult Get()
        {
            _logger.LogInformation($"[{DateTime.Now}] Get / redirect to /home");
            return GetHome();
        }

        [HttpGet()]
        public IActionResult GetHome()
        {
            _logger.LogInformation($"[{DateTime.Now}] Get /home");
            var filePath = Path.Combine(_env.WebRootPath, "home.html");

            if (System.IO.File.Exists(filePath))
            {
                return PhysicalFile(filePath, "text/html");
            }
            else
            {
                return NotFound();
            }
        }
    }


}