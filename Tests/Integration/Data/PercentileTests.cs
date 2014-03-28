﻿using System;
using System.Collections.Generic;
using System.Linq;
using EquipmentGen.Mappers.Interfaces;
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

        private Dictionary<Int32, String> table;
        private String tableName;

        [SetUp]
        public void Setup()
        {
            tableName = GetTableNameFromAttribute();
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