using Moq;
using NUnit.Framework;
using System.Linq;
using TreasureGen.Domain.Generators.Items.Magical;
using TreasureGen.Items;
using TreasureGen.Items.Magical;

namespace TreasureGen.Tests.Unit.Generators.Items.Magical
{
    [TestFixture]
    public class MagicalItemGeneratorMundaneProxyTests
    {
        private MagicalItemGenerator mundaneProxy;
        private Mock<MagicalItemGenerator> mockInnerGenerator;
        private Item innerItem;

        [SetUp]
        public void Setup()
        {
            mockInnerGenerator = new Mock<MagicalItemGenerator>();
            mundaneProxy = new MagicalItemGeneratorMundaneProxy(mockInnerGenerator.Object);
            innerItem = new Item();

            mockInnerGenerator.Setup(g => g.GenerateAtPower("power")).Returns(innerItem);
        }

        [Test]
        public void GetItemFromInnerGenerator()
        {
            var item = mundaneProxy.GenerateAtPower("power");
            Assert.That(item, Is.EqualTo(innerItem));
        }

        [Test]
        public void ThrowArgumentExceptionIfPowerIsMundane()
        {
            Assert.That(() => mundaneProxy.GenerateAtPower(PowerConstants.Mundane), Throws.ArgumentException);
        }

        [Test]
        public void PassCustomItemThrough()
        {
            var template = new Item();
            mockInnerGenerator.Setup(g => g.Generate(template, true)).Returns(innerItem);

            var item = mundaneProxy.Generate(template, true);
            Assert.That(item, Is.EqualTo(innerItem));
        }

        [Test]
        public void GenerateFromSubset()
        {
            var subset = new[] { "first", "second" };
            mockInnerGenerator.Setup(g => g.GenerateFromSubset("power", subset)).Returns(innerItem);

            var item = mundaneProxy.GenerateFromSubset("power", subset);
            Assert.That(item, Is.EqualTo(innerItem));
        }

        [Test]
        public void GenerateFromEmptySubset()
        {
            Assert.That(() => mundaneProxy.GenerateFromSubset("power", Enumerable.Empty<string>()), Throws.ArgumentException.With.Message.EqualTo("Cannot generate from an empty collection subset"));
        }

        [Test]
        public void ThrowArgumentExceptionIfPowerFromSubsetIsMundane()
        {
            var subset = new[] { "first", "second" };
            Assert.That(() => mundaneProxy.GenerateFromSubset(PowerConstants.Mundane, subset), Throws.ArgumentException);
        }
    }
}