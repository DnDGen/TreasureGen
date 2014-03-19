using System;

namespace EquipmentGen.Tests.Integration.Tables.TestAttributes
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