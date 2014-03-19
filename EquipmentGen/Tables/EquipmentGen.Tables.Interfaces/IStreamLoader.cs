using System;
using System.IO;

namespace EquipmentGen.Tables.Interfaces
{
    public interface IStreamLoader
    {
        Stream LoadFor(String filename);
    }
}