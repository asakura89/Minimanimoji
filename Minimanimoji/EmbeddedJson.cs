using System;
using System.IO;
using System.Reflection;
using System.Text;

namespace Minimanimoji {
    public static class EmbeddedJson {
        static readonly Assembly ThisAssembly = Assembly.GetExecutingAssembly();

        public static String Get(String filename) {
            using (Stream stream = ThisAssembly.GetManifestResourceStream($"Minimanimoji.{filename}"))
                if (stream != null)
                    using (var sr = new StreamReader(stream, Encoding.UTF8))
                        return sr.ReadToEnd();
                else
                    return String.Empty;
        }
    }
}