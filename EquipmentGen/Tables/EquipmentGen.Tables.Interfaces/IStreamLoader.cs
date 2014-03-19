using System;
using System.IO;

namespace EquipmentGen.Core.Generation.Xml.Parsers.Interfaces
{
    public interface IStreamLoader
    {
        Stream LoadStream(String filename);
    }
}