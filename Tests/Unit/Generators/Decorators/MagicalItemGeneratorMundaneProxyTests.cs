using Moq;
using NUnit.Framework;
using TreasureGen.Common.Items;
using TreasureGen.Generators.Domain.Decorators;
using TreasureGen.Generators.Items.Magical;

namespace TreasureGen.Tests.Unit.Generators.Decorators
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
    }
}