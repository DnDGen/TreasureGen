using System;
using System.Collections.Generic;
using System.Linq;
using EquipmentGen.Common.Items;
using EquipmentGen.Generators.Interfaces.Items;
using Ninject;
using NUnit.Framework;

namespace EquipmentGen.Tests.Integration.Stress.Items
{
    [TestFixture]
    public class ItemsGeneratorTests : StressTests
    {
        [Inject]
        public IItemsGenerator ItemsGenerator { get; set; }

        [TestCase("Items generator")]
        public override void Stress(String thingToStress)
        {
            Stress();
        }

        protected override void MakeAssertions()
        {
            var items = GenerateItems();

            Assert.That(items, Is.Not.Null);
            foreach (var item in items)
            {
                Assert.That(item.Name, Is.Not.Empty);
                Assert.That(item.Attributes, Is.Not.Null);
                Assert.That(item.Magic, Is.Not.Null);
                Assert.That(item.Quantity, Is.GreaterThan(0));
                Assert.That(item.Traits, Is.Not.Null);
                Assert.That(item.Contents, Is.Not.Null);
                Assert.That(item.ItemType, Is.Not.Empty);
            }
        }

        private IEnumerable<Item> GenerateItems()
        {
            var level = GetNewLevel();
            return ItemsGenerator.GenerateAtLevel(level);
        }

        [Test]
        public void ItemsHappen()
        {
            IEnumerable<Item> items;

            do items = GenerateItems();
            while (TestShouldKeepRunning() && !items.Any());

            Assert.That(items, Is.Not.Empty);
        }

        [Test]
        public void ItemsDoNotHappen()
        {
            IEnumerable<Item> items;

            do items = GenerateItems();
            while (TestShouldKeepRunning() && items.Any());

            Assert.That(items, Is.Empty);
        }
    }
}