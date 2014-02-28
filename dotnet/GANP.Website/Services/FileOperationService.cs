using System.IO;

namespace GANP.Website.Services
{
    public interface IFileOperationService
    {
        string ReadAllText(string path);
    }

    public class FileOperationService : IFileOperationService
    {
        public string ReadAllText(string path)
        {
            return File.ReadAllText(path);
        }
    }
}