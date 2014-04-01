﻿using System;
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
            for (var roll = 100; roll > 0; roll--)
            {
                Assert.That(table.Keys, Contains.Item(roll), tableName);
                Assert.That(table[roll], Is.Not.Null, tableName);
            }

            Assert.That(table.Keys.Count, Is.EqualTo(100), tableName);
        }

        protected void AssertPercentile(String content, Int32 roll)
        {
            var message = String.Format("Roll: {0}", roll);
            Assert.That(table.Keys, Contains.Item(roll), tableName);
            Assert.That(table[roll], Is.EqualTo(content), message);
        }

        protected void AssertPercentile(String content, Int32 lower, Int32 upper)
        {
            for (var roll = lower; roll <= upper; roll++)
                AssertPercentile(content, roll);
        }
    }
}