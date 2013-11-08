using System;
using System.IO;
using System.Linq;
using System.Reflection;
using EquipmentGen.Core.Generation.Xml.Parsers.Interfaces;

namespace EquipmentGen.Core.Generation.Xml.Parsers
{
    public class EmbeddedResourceStreamLoader : IStreamLoader
    {
        public Stream LoadStream(String filename)
        {
            var executingAssembly = Assembly.GetExecutingAssembly();
            var resources = executingAssembly.GetManifestResourceNames();

            if (!resources.Any(r => r.Contains(filename)))
                throw new FileNotFoundException(filename);

            var streamSource = resources.First(r => r.Contains(filename));

            return executingAssembly.GetManifestResourceStream(streamSource);
        }
    }
}