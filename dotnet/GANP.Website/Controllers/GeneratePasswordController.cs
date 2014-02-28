using System.Web.Http;
using GANP.Website.Models;
using GANP.Website.Services;

namespace GANP.Website.Controllers
{
    public class GeneratePasswordController : ApiController
    {
        private IGeneratePasswordService _service;

        public GeneratePasswordController()
        {
            _service = new GeneratePasswordService(new FileOperationService(), new HttpFilePathService());
        }

        public GeneratePasswordController(IGeneratePasswordService service)
        {
            _service = service;
        }

        public GeneratePasswordModel GetAllProducts(GeneratePasswordOptions options)
        {
            var requestOptions = options ?? new GeneratePasswordOptions();
            var password = _service.GeneratePassword(requestOptions);
            return new GeneratePasswordModel(password, requestOptions);
        }
    }
}