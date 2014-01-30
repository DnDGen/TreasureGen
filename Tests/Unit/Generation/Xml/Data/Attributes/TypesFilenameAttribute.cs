using System;

namespace EquipmentGen.Tests.Unit.Generation.Xml.Data.Attributes
{
    public class TypesFilenameAttribute : Attribute
    {
        public readonly String Filename;

        public TypesFilenameAttribute(String filename)
        {
            Filename = filename;
        }
    }
}