using Ninject;
using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;
using TreasureGen.Items;

namespace TreasureGen.Tests.Integration.Stress.Items
{
    [TestFixture]
    public class ItemsGeneratorTests : StressTests
    {
        [Inject]
        public IItemsGenerator ItemsGenerator { get; set; }
        [Inject]
        public ItemVerifier ItemVerifier { get; set; }

        [Test]
        public void StressItems()
        {
            Stress(AssertItems);
        }

        private void AssertItems()
        {
            var items = GenerateItems();
            Assert.That(items, Is.Not.Null);

            foreach (var item in items)
            {
                ItemVerifier.AssertItem(item);
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
            var items = GenerateOrFail(GenerateItems, i => i.Any());
            Assert.That(items, Is.Not.Empty);
        }

        [Test]
        public void ItemsDoNotHappen()
        {
            var items = GenerateOrFail(GenerateItems, i => !i.Any());
            Assert.That(items, Is.Empty);
        }
    }
}