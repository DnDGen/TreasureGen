using Ninject;
using NUnit.Framework;
using TreasureGen.Items;
using TreasureGen.Items.Mundane;

namespace TreasureGen.Tests.Integration.Stress.Items.Mundane
{
    [TestFixture]
    public class ToolGeneratorTests : MundaneItemGeneratorStressTests
    {
        [Inject, Named(ItemTypeConstants.Tool)]
        public MundaneItemGenerator ToolGenerator { get; set; }

        [TestCase("Tool generator")]
        public override void Stress(string thingToStress)
        {
            Stress();
        }

        protected override void MakeAssertions()
        {
            var tool = GenerateItem();

            Assert.That(tool.Name, Is.Not.Empty);
            Assert.That(tool.Attributes, Is.Empty);
            Assert.That(tool.IsMagical, Is.False);
            Assert.That(tool.Quantity, Is.EqualTo(1));
            Assert.That(tool.Traits, Is.Empty);
            Assert.That(tool.Contents, Is.Empty);
            Assert.That(tool.ItemType, Is.EqualTo(ItemTypeConstants.Tool));
        }

        protected override Item GenerateItem()
        {
            return ToolGenerator.Generate();
        }

        [Test]
        public override void NoDecorationsHappen()
        {
            AssertNoDecorationsHappen();
        }
    }
}