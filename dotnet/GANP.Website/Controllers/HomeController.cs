using GANP.Website.Models;
using GANP.Website.Services;
using Microsoft.AspNetCore.Mvc;

namespace GANP.Website.Controllers
{
    public class HomeController : Controller
    {
        private readonly IGeneratePasswordService _service;

        public HomeController(IGeneratePasswordService service)
        {
            _service = service;
        }

        public IActionResult Index()
        {
            var options = new GeneratePasswordOptions();
            var newPassword = _service.GeneratePassword(options);
            return View(new GeneratePasswordModel(newPassword, options));
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error() => View();
    }
}
