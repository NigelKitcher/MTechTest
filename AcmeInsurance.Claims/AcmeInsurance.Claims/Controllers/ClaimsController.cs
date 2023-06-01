using AcmeInsurance.Claims.Models;
using Microsoft.AspNetCore.Mvc;

namespace AcmeInsurance.Claims.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ClaimsController : ControllerBase
    {
        private readonly ILogger<ClaimsController> _logger;

        public ClaimsController(ILogger<ClaimsController> logger)
        {
            _logger = logger;
        }

        [HttpGet(Name = "GetCompany")]
        public JsonResult Get()
        {
            return new JsonResult( 
                new Company()
                {
                    Name = "Test"
                });
        }
    }
}