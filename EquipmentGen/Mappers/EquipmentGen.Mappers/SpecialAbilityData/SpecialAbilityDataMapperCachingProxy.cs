using System;
using System.Collections.Generic;
using EquipmentGen.Mappers.Interfaces;
using EquipmentGen.Mappers.Objects;

namespace EquipmentGen.Mappers.SpecialAbilityData
{
    public class SpecialAbilityDataMapperCachingProxy : ISpecialAbilityDataMapper
    {
        private Dictionary<String, Dictionary<String, SpecialAbilityDataObject>> tables;
        private ISpecialAbilityDataMapper innerMapper;

        public SpecialAbilityDataMapperCachingProxy(ISpecialAbilityDataMapper innerMapper)
        {
            this.innerMapper = innerMapper;
            tables = new Dictionary<String, Dictionary<String, SpecialAbilityDataObject>>();
        }

        public Dictionary<String, SpecialAbilityDataObject> Map(String tableName)
        {
            if (!tables.ContainsKey(tableName))
                CacheTable(tableName);

            return tables[tableName];
        }

        private void CacheTable(String tableName)
        {
            var table = innerMapper.Map(tableName);
            tables.Add(tableName, table);
        }
    }
}