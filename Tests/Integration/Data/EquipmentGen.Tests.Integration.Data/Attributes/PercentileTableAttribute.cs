using System;

namespace EquipmentGen.Tests.Integration.Data.Attributes
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