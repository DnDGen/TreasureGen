using System;

namespace EquipmentGen.Tests.Unit.Generation.Xml.Data.Attributes
{
    public class TypesTableAttribute : Attribute
    {
        public readonly String TableName;

        public TypesTableAttribute(String tableName)
        {
            TableName = tableName;
        }
    }
}