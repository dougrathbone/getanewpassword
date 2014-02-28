using System.IO;
using System.Reflection;
using System.Web;

namespace GANP.Website.Services
{
    public interface IFilePathService
    {
        string GetRelativePath(string path);
    }

    public class FilePathService : IFilePathService
    {
        public string GetRelativePath(string path)
        {
            var binaryLocation = Assembly.GetExecutingAssembly().Location;
            var parentPath = binaryLocation.Substring(0, binaryLocation.LastIndexOf('\\'));
            return Path.Combine(parentPath, path);
        }
    }
    public class HttpFilePathService : IFilePathService
    {
        public string GetRelativePath(string path)
        {
            return HttpContext.Current.Server.MapPath(path);
        }
    }
}