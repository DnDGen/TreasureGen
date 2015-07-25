using TreasureGen.Common.Items;
using TreasureGen.Generators.Decorators;
using TreasureGen.Generators.Interfaces.Items.Magical;
using Moq;
using NUnit.Framework;

namespace TreasureGen.Tests.Unit.Generators.Decorators
{
    [TestFixture]
    public class MagicalItemGeneratorMundaneProxyTests
    {
        private IMagicalItemGenerator mundaneProxy;
        private Mock<IMagicalItemGenerator> mockInnerGenerator;
        private Item innerItem;

        [SetUp]
        public void Setup()
        {
            mockInnerGenerator = new Mock<IMagicalItemGenerator>();
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