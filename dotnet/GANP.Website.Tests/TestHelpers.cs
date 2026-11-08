using System.IO;
using System.Reflection;

namespace GANP.Website.Tests
{
    public static class TestHelpers
    {
        public static string GetFullPath(string relativePathToTestProjectRoot)
        {
            var assemblyPath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            return Path.Combine(assemblyPath, relativePathToTestProjectRoot);
        }
    }
}
