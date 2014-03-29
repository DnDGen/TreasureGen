using System;
using System.Collections.Generic;
using EquipmentGen.Mappers.Interfaces;
using EquipmentGen.Tests.Integration.Common;
using Ninject;
using NUnit.Framework;

namespace EquipmentGen.Tests.Integration.Tables
{
    [TestFixture]
    public abstract class PercentileTests : IntegrationTests
    {
        [Inject]
        public IPercentileMapper PercentileMapper { get; set; }

        private String tableName;
        private Dictionary<Int32, String> table;

        [SetUp]
        public void Setup()
        {
            tableName = GetTableName();
            table = PercentileMapper.Map(tableName);
        }

        protected abstract String GetTableName();

        [Test]
        public void TableIsComplete()
        {
            for (var i = 100; i > 0; i--)
                Assert.That(table[i], Is.Not.Null, tableName);

            Assert.That(table.Keys.Count, Is.EqualTo(100), tableName);
        }

        protected void AssertPercentile(String content, Int32 roll)
        {
            AssertPercentile(content, roll, roll);
        }

        protected void AssertPercentile(String content, Int32 lower, Int32 upper)
        {
            for (var i = 100; i > 0; i--)
            {
                if (i >= lower && i <= upper)
                    Assert.That(table[i], Is.EqualTo(content));
                else
                    Assert.That(table[i], Is.Not.EqualTo(content));
            }
        }
    }
}