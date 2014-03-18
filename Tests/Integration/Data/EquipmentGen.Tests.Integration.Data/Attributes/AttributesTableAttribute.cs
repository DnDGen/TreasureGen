using System;

namespace EquipmentGen.Tests.Integration.Data.Attributes
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