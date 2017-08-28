using NUnit.Framework;
using System.Collections.Generic;
using TreasureGen.Items;
using TreasureGen.Items.Mundane;

namespace TreasureGen.Tests.Integration.Stress.Items.Mundane
{
    [TestFixture]
    public class AlchemicalItemGeneratorTests : MundaneItemGeneratorStressTests
    {
        [SetUp]
        public void Setup()
        {
            mundaneItemGenerator = GetNewInstanceOf<MundaneItemGenerator>(ItemTypeConstants.AlchemicalItem);
        }

        [Test]
        public void StressAlchemicalItem()
        {
            stressor.Stress(GenerateAndAssertItem);
        }

        protected override void MakeSpecificAssertionsAgainst(Item item)
        {
            Assert.That(item.Name, Is.Not.Empty);
            Assert.That(item.Quantity, Is.Positive);
            Assert.That(item.IsMagical, Is.False);
            Assert.That(item.Attributes, Is.Empty);
            Assert.That(item.ItemType, Is.EqualTo(ItemTypeConstants.AlchemicalItem));
        }

        protected override IEnumerable<string> GetItemNames()
        {
            return AlchemicalItemConstants.GetAllAlchemicalItems();
        }

        [Test]
        public void StressCustomAlchemicalItem()
        {
            stressor.Stress(GenerateAndAssertCustomItem);
        }

        [Test]
        [Ignore("There is no currently-known use case where we generate an alchemical item from a subset")]
        public void StressAlchemicalItemFromSubset()
        {
            stressor.Stress(GenerateAndAssertItemFromSubset);
        }
    }
}