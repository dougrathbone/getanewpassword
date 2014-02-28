using System.Web.Mvc;
using GANP.Website.Models;
using GANP.Website.Services;

namespace GANP.Website.Controllers
{
    public class HomeController : Controller
    {
        private IFileOperationService _reader;
        private IGeneratePasswordService _service;
        public HomeController()
        {
            _reader = new FileOperationService();
            _service = new GeneratePasswordService(_reader,new HttpFilePathService());
        }

        public HomeController(IFileOperationService fileService, IGeneratePasswordService service)
        {
            _reader = fileService;
            _service = service;
        }

        public ActionResult Index()
        {
            var options = new GeneratePasswordOptions();
            var newPassword = _service.GeneratePassword(options);
            var model = new GeneratePasswordModel(newPassword, options);
            return View(model);
        }
    }
}