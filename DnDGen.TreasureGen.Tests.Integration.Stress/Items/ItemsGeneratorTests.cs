using DnDGen.TreasureGen.Items;
using DnDGen.TreasureGen.Tests.Unit.Generators.Items;
using Ninject;
using NUnit.Framework;

namespace DnDGen.TreasureGen.Tests.Integration.Stress.Items
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

        private void GenerateAndAssertItems()
        {
            var level = GetNewLevel();
            var items = ItemsGenerator.GenerateAtLevel(level);

            Assert.That(items, Is.Not.Null);

            if (level > 20)
                Assert.That(items, Is.Not.Empty, $"Level {level}");

            foreach (var item in items)
                ItemVerifier.AssertItem(item);
        }
    }
}