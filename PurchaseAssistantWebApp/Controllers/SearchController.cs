using Microsoft.AspNetCore.Mvc;

namespace PurchaseAssistantWebApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SearchController : ControllerBase
    {
        // Returns list of all monitors
        public string Get()
        {
            return "all monitors";
        }

        // Returns list of monitors based on monitor type(primary or additional)
        [HttpGet("{monitorType}")]
        public string Get(string monitorType)
        {
            return monitorType;
        }

        // Returns list of monitors based on monitor type and portability
        [HttpGet("{monitorType}/{portability}")]
        public string Get(string monitorType, string portability)
        {
            return monitorType + portability;
        }

        // Returns list of monitors based on monitor type, portability and display size
        [HttpGet("{monitorType}/{portability}/{displaySize}")]
        public string Get(string monitorType, string portability, string displaySize)
        {
            return monitorType + portability + displaySize;
        }

        // Returns list of monitors based on monitor type, portability, series and series name
        [HttpGet("{monitorType}/{portability}/{series}/{seriesName}")]
        public string Get(string monitorType, string portability, string series, string seriesName)
        {
            return monitorType + portability + series + seriesName;
        }

    }
}
