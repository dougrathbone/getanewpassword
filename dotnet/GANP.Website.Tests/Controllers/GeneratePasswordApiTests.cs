using System.Net.Http.Headers;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GANP.Website.Tests.Controllers
{
    [TestClass]
    public class GeneratePasswordApiTests
    {
        private static WebApplicationFactory<Program> _factory;

        [ClassInitialize]
        public static void Init(TestContext _) => _factory = new WebApplicationFactory<Program>();

        [ClassCleanup]
        public static void Cleanup() => _factory.Dispose();

        [TestMethod]
        public async Task Get_ReturnsJson_ByDefault()
        {
            var response = await _factory.CreateClient().GetAsync("/api/generatepassword");

            response.EnsureSuccessStatusCode();
            StringAssert.Contains(response.Content.Headers.ContentType.ToString(), "json");
            StringAssert.Contains(await response.Content.ReadAsStringAsync(), "\"Password\"");
        }

        [TestMethod]
        public async Task Get_ReturnsXml_WhenAcceptHeaderAsksForXml()
        {
            var client = _factory.CreateClient();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/xml"));

            var response = await client.GetAsync("/api/generatepassword");

            response.EnsureSuccessStatusCode();
            StringAssert.Contains(response.Content.Headers.ContentType.ToString(), "xml");
        }

        [TestMethod]
        public async Task HomePage_RendersPassword()
        {
            var response = await _factory.CreateClient().GetAsync("/");

            response.EnsureSuccessStatusCode();
            StringAssert.Contains(await response.Content.ReadAsStringAsync(), "id=\"result\"");
        }
    }
}
