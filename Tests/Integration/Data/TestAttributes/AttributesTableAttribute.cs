using System;

namespace EquipmentGen.Tests.Integration.Tables.TestAttributes
{
    public class AttributesTableAttribute : Attribute
    {
        public readonly String TableName;

        public AttributesTableAttribute(String tableName)
        {
            TableName = tableName;
        }
    }
}