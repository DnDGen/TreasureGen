using System;
using System.Collections.Generic;
using System.Linq;
using EquipmentGen.Mappers.Interfaces;
using EquipmentGen.Mappers.Objects;
using EquipmentGen.Tests.Integration.Common;
using EquipmentGen.Tests.Integration.Tables.TestAttributes;
using Ninject;
using NUnit.Framework;

namespace EquipmentGen.Tests.Integration.Tables
{
    [TestFixture]
    public abstract class PercentileTests : IntegrationTests
    {
        [Inject]
        public IPercentileMapper PercentileMapper { get; set; }

        private IEnumerable<PercentileObject> table;

        [SetUp]
        public void Setup()
        {
            var tableName = GetTableNameFromAttribute();
            table = PercentileMapper.Map(tableName);
        }

        private String GetTableNameFromAttribute()
        {
            var type = GetType();
            var attributes = type.GetCustomAttributes(true);

            if (!attributes.Any(a => a is PercentileTableAttribute))
                throw new ArgumentException("This test class does not have the needed PercentileTableAttribute");

            var percentileTableAttribute = attributes.First(a => a is PercentileTableAttribute) as PercentileTableAttribute;
            return percentileTableAttribute.Table;
        }

        protected void AssertEmpty(Int32 lower, Int32 upper)
        {
            var isEmptyInRange = table.Any(o => o.LowerLimit >= lower && o.UpperLimit <= upper);
            Assert.That(isEmptyInRange, Is.False);
        }

        protected void AssertContent(String content, Int32 roll)
        {
            AssertContent(content, roll, roll);
        }

        protected void AssertContent(String content, Int32 lower, Int32 upper)
        {
            Assert.That(table.Select(o => o.Content), Contains.Item(content));

            var result = table.Single(o => o.Content == content);
            Assert.That(result.LowerLimit, Is.EqualTo(lower), "Lower limit");
            Assert.That(result.UpperLimit, Is.EqualTo(upper), "Upper limit");
        }
    }
}