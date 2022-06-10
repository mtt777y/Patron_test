using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Patron_test.Components;

namespace Patron_test.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class FileController : ControllerBase
    {
        private readonly IWebHostEnvironment _hostingEnvironment;
        private readonly ILogger _logger;
        private readonly ThreadControl _threadControl;

        public FileController(IWebHostEnvironment hostingEnvironment, ILogger<FileController> logger, ThreadControl threadControl)
        {
            _hostingEnvironment = hostingEnvironment;
            _logger = logger;
            _threadControl = threadControl;
        }

        [HttpGet]
        public ActionResult<string> GetFileValue(string filename)
        {
            try
            {
                _logger.LogDebug($"Start processing ({filename})...");
                return Ok(ABitRetardedFileReader.StartAndCallback(filename, _hostingEnvironment.ContentRootPath, _logger, _threadControl));
            }
            finally
            {
                _logger.LogDebug($"End processing ({filename})!");
            }
            
        }
    }
}
