using System.IO;
using System.Reflection;

namespace GANP.Website.Tests
{
    public static class TestHelpers
    {
        public static string GetFullPath(string relativePathToTestProjectRoot)
        {
            var assemblyPath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            if (assemblyPath.Substring(assemblyPath.Length - 1, 1) != "\\" && relativePathToTestProjectRoot.Substring(0, 1) != "\\")
            {
                assemblyPath = assemblyPath + "\\";
            }
            return Path.Combine(assemblyPath,relativePathToTestProjectRoot);
        }
    }
}
