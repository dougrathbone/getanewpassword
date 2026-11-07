using GANP.Website.Models;
using GANP.Website.Services;
using Microsoft.AspNetCore.Mvc;

namespace GANP.Website.Controllers
{
    [ApiController]
    [Route("api/generatepassword")]
    [Produces("application/json", "application/xml")]
    public class GeneratePasswordController : ControllerBase
    {
        private readonly IGeneratePasswordService _service;

        public GeneratePasswordController(IGeneratePasswordService service)
        {
            _service = service;
        }

        [HttpGet]
        public GeneratePasswordModel Get([FromQuery] GeneratePasswordOptions options)
        {
            return Build(options);
        }

        [HttpPost]
        public GeneratePasswordModel Post([FromBody] GeneratePasswordOptions options = null)
        {
            return Build(options);
        }

        private GeneratePasswordModel Build(GeneratePasswordOptions options)
        {
            var requestOptions = options ?? new GeneratePasswordOptions();
            var password = _service.GeneratePassword(requestOptions);
            return new GeneratePasswordModel(password, requestOptions);
        }
    }
}
