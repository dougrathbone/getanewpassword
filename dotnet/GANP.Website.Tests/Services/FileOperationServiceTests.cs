using System.IO;
using GANP.Website.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GANP.Website.Tests.Services
{
    [TestClass]
    public class FileOperationServiceTests
    {
        [TestMethod]
        public void FileOperationService_ValidFilePath_LoadsFile()
        {
            var service = new FileOperationService();

            var text = service.ReadAllText(TestHelpers.GetFullPath("samplefile.txt"));

            Assert.IsNotNull(text);
        }

        [TestMethod]
        [ExpectedException(typeof (FileNotFoundException))]
        public void FileOperationService_InValidFilePath_ThrowsFileNotFoundException()
        {
            var service = new FileOperationService();

            // should throw exception
            var text = service.ReadAllText(@"C:\filethatdoesntexist.txt");
        }
    }
}
