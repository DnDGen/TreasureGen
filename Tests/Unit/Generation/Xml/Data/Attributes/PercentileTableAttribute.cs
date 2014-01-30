using System;

namespace EquipmentGen.Tests.Unit.Generation.Xml.Data.Attributes
{
    public class PercentileTableAttribute : Attribute
    {
        public readonly String Table;

        public PercentileTableAttribute(String table)
        {
            Table = table;
        }
    }
}