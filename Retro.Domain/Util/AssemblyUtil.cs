using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;

namespace Retro.Domain.Util
{
    public static class AssemblyUtil
    {
        public static IEnumerable<string> FindEmbeddedFile(this Assembly assembly, string pattern) {
            var resourceNames = assembly.GetManifestResourceNames();
            return resourceNames.Where(resourceName => resourceName.Contains(pattern));
        }

        public static string ReadEmbeddedFile(this Assembly assembly, string file) {
            var stream = assembly.GetManifestResourceStream(file);

            if (stream != null) {
                var reader = new StreamReader(stream);
                return reader.ReadToEnd();
            }

            return string.Empty;
        }
    }
}