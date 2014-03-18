using System;

namespace EquipmentGen.Tests.Integration.Tables.Attributes
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