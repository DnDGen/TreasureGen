using System;

namespace EquipmentGen.Tests.Unit.Generation.Xml.Data.Attributes
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