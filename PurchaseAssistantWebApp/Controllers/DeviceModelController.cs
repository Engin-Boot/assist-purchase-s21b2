using Microsoft.AspNetCore.Mvc;

namespace PurchaseAssistantWebApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DeviceModelController : ControllerBase
    {
        // Return particular model by model number
        [HttpGet("{modelName}")]
        public string Get(string modelName)
        {
            return modelName;
        }
    }
}
