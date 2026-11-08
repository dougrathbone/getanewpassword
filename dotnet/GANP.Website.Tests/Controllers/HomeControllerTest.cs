using GANP.Website.Controllers;
using GANP.Website.Models;
using GANP.Website.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace GANP.Website.Tests.Controllers
{
    [TestClass]
    public class HomeControllerTest
    {
        [TestMethod]
        public void Index_ReturnsViewWithPassword()
        {
            var service = new Mock<IGeneratePasswordService>();
            service.Setup(x => x.GeneratePassword(It.IsAny<GeneratePasswordOptions>())).Returns("Word-Word-Word-Word-1");
            var controller = new HomeController(service.Object);

            var result = controller.Index() as ViewResult;

            Assert.IsNotNull(result);
            Assert.AreEqual("Word-Word-Word-Word-1", ((GeneratePasswordModel)result.Model).Password);
        }
    }
}
