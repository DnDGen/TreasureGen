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
            var assembly = Assembly.GetExecutingAssembly();
            var resources = assembly.GetManifestResourceNames();

            if (!resources.Any(r => r.EndsWith(filename)))
                throw new FileNotFoundException(filename);

            var streamSource = resources.Single(r => r.EndsWith(filename));

            return assembly.GetManifestResourceStream(streamSource);
        }
    }
}