using System;

namespace EquipmentGen.Tests.Unit.Generation.Xml.Data.Attributes
{
    public class TypesTableNameAttribute : Attribute
    {
        public readonly String TableName;

        public TypesTableNameAttribute(String tableName)
        {
            TableName = tableName;
        }
    }
}