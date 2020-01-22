using DnDGen.TreasureGen.Generators.Items.Magical;
using DnDGen.TreasureGen.Items;
using DnDGen.TreasureGen.Items.Magical;
using Moq;
using NUnit.Framework;
using System.Linq;

namespace DnDGen.TreasureGen.Tests.Unit.Generators.Items.Magical
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

            mockInnerGenerator.Setup(g => g.GenerateFrom("power")).Returns(innerItem);
        }

        [Test]
        public void GetItemFromInnerGenerator()
        {
            var item = mundaneProxy.GenerateFrom("power");
            Assert.That(item, Is.EqualTo(innerItem));
        }

        [Test]
        public void ThrowArgumentExceptionIfPowerIsMundane()
        {
            Assert.That(() => mundaneProxy.GenerateFrom(PowerConstants.Mundane), Throws.ArgumentException);
        }

        [Test]
        public void PassCustomItemThrough()
        {
            var template = new Item();
            mockInnerGenerator.Setup(g => g.GenerateFrom(template, true)).Returns(innerItem);

            var item = mundaneProxy.GenerateFrom(template, true);
            Assert.That(item, Is.EqualTo(innerItem));
        }

        [Test]
        public void GenerateFromSubset()
        {
            var subset = new[] { "first", "second" };
            mockInnerGenerator.Setup(g => g.GenerateFrom("power", subset)).Returns(innerItem);

            var item = mundaneProxy.GenerateFrom("power", subset);
            Assert.That(item, Is.EqualTo(innerItem));
        }

        [Test]
        public void GenerateFromEmptySubset()
        {
            Assert.That(() => mundaneProxy.GenerateFrom("power", Enumerable.Empty<string>()), Throws.ArgumentException.With.Message.EqualTo("Cannot generate from an empty collection subset"));
        }

        [Test]
        public void ThrowArgumentExceptionIfPowerFromSubsetIsMundane()
        {
            var subset = new[] { "first", "second" };
            Assert.That(() => mundaneProxy.GenerateFrom(PowerConstants.Mundane, subset), Throws.ArgumentException);
        }
    }
}