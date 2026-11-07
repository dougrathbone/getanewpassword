using System.IO;
using System.Reflection;

namespace GANP.Website.Services
{
    public interface IFilePathService
    {
        string GetRelativePath(string path);
    }

    /// <summary>Resolves paths relative to the folder containing the executing assembly.</summary>
    public class FilePathService : IFilePathService
    {
        public string GetRelativePath(string path)
        {
            var parentPath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            return Path.Combine(parentPath, path);
        }
    }

    /// <summary>Resolves paths relative to the web app content root (works on Windows and Linux).</summary>
    public class ContentRootFilePathService : IFilePathService
    {
        private readonly IWebHostEnvironment _environment;

        public ContentRootFilePathService(IWebHostEnvironment environment)
        {
            _environment = environment;
        }

        public string GetRelativePath(string path)
        {
            return Path.Combine(_environment.ContentRootPath, path.TrimStart('\\', '/'));
        }
    }
}
