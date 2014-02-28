using System;
using GANP.Website.Models;
using GANP.Website.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace GANP.Website.Tests.Services
{
    [TestClass]
    public class GeneratePasswordServiceTests
    {
        [TestMethod]
        public void GeneratePasswordService_GeneratePassword_GeneratesValidPassword()
        {
            var mockFile = generateFileService();
            var service = new GeneratePasswordService(mockFile.Object, new FilePathService());
            var options = new GeneratePasswordOptions();
            var result = service.GeneratePassword(options);

            Assert.IsFalse(String.IsNullOrEmpty(result));
        }

        [TestMethod]
        public void GeneratePasswordService_GeneratePassword_AddsNumber()
        {
            var mockFile = generateFileService();
            var service = new GeneratePasswordService(mockFile.Object, new FilePathService());
            var options = new GeneratePasswordOptions();
            var result = service.GeneratePassword(options);
            
            char lastChar = char.Parse(result.Substring(result.Length-1,1));

            Assert.IsTrue(char.IsNumber(lastChar));
        }
        
        [TestMethod]
        public void GeneratePasswordService_RandomWord_PicksRandomWords()
        {
            var service = new GeneratePasswordService();
            var words = new string[5]
            {
                "word1", "word2", "word3", "word4", "word5"
            };
            var result = service.SelectRandomWord(words, false);
            var secondResult = service.SelectRandomWord(words, false);

            Assert.IsFalse(result == secondResult);
        }

        [TestMethod]
        public void GeneratePasswordService_RandomWord_UpperCasesWords()
        {
            var service = new GeneratePasswordService();
            var words = new string[5]
            {
                "word1", "word2", "word3", "word4", "word5"
            };
            var result = service.SelectRandomWord(words, false);
            Assert.IsTrue(char.IsUpper(result[0]));
        }
        
        private Mock<IFileOperationService> generateFileService()
        {
            var mock = new Mock<IFileOperationService>();

            mock.Setup(x => x.ReadAllText(It.IsAny<string>()))
                .Returns("word1, word2, word3, word4, word5");

            return mock;
        }
    }
}
