using Ninject;
using NUnit.Framework;
using TreasureGen.Items;
using TreasureGen.Items.Mundane;

namespace TreasureGen.Tests.Integration.Stress.Items.Mundane
{
    [TestFixture]
    public class AlchemicalItemGeneratorTests : MundaneItemGeneratorStressTests
    {
        [Inject, Named(ItemTypeConstants.AlchemicalItem)]
        public MundaneItemGenerator AlchemicalItemGenerator { get; set; }

        [Test]
        public void StressAlchemicalItem()
        {
            Stress(StressItem);
        }

        protected override void MakeSpecificAssertionsAgainst(Item item)
        {
            Assert.That(item.Name, Is.Not.Empty);
            Assert.That(item.Quantity, Is.Positive);
            Assert.That(item.IsMagical, Is.False);
            Assert.That(item.Attributes, Is.Empty);
            Assert.That(item.Traits, Is.Empty);
            Assert.That(item.Contents, Is.Empty);
            Assert.That(item.ItemType, Is.EqualTo(ItemTypeConstants.AlchemicalItem));
        }

        protected override Item GenerateItem()
        {
            return AlchemicalItemGenerator.Generate();
        }

        [Test]
        public override void NoDecorationsHappen()
        {
            AssertNoDecorationsHappen();
        }
    }
}