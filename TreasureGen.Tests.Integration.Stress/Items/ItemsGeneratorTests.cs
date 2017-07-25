using Ninject;
using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;
using TreasureGen.Items;
using TreasureGen.Tests.Unit.Generators.Items;

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
            stressor.Stress(() => GenerateAndAssertItems());
        }

        private void GenerateAndAssertItems(int level = 0)
        {
            var items = GenerateItems(level);
            Assert.That(items, Is.Not.Null);

            foreach (var item in items)
                ItemVerifier.AssertItem(item);

            if (level > 20)
                Assert.That(items, Is.Not.Empty);
        }

        private IEnumerable<Item> GenerateItems(int level = 0)
        {
            if (level == 0)
                level = GetNewLevel();

            return ItemsGenerator.GenerateAtLevel(level);
        }

        [Test]
        public void ItemsHappen()
        {
            var items = stressor.GenerateOrFail(() => GenerateItems(), i => i.Any());
            Assert.That(items, Is.Not.Empty);
        }

        [Test]
        public void ItemsDoNotHappen()
        {
            var items = stressor.GenerateOrFail(() => GenerateItems(), i => !i.Any());
            Assert.That(items, Is.Empty);
        }
    }
}