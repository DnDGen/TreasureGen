using Moq;
using NUnit.Framework;
using TreasureGen.Domain.Generators.Items.Magical;
using TreasureGen.Domain.Tables;
using TreasureGen.Items;
using TreasureGen.Items.Magical;

namespace TreasureGen.Tests.Unit.Generators.Items.Magical
{
    [TestFixture]
    public class MagicalItemGeneratorCurseDecoratorTests
    {
        private MagicalItemGenerator decorator;
        private Mock<ICurseGenerator> mockCurseGenerator;
        private Mock<MagicalItemGenerator> mockInnerGenerator;
        private Item innerItem;

        [SetUp]
        public void Setup()
        {
            mockInnerGenerator = new Mock<MagicalItemGenerator>();
            mockCurseGenerator = new Mock<ICurseGenerator>();
            decorator = new MagicalItemGeneratorCurseDecorator(mockInnerGenerator.Object, mockCurseGenerator.Object);
            innerItem = new Item();

            mockInnerGenerator.Setup(g => g.GenerateAtPower("power")).Returns(innerItem);
        }

        [Test]
        public void GetItemFromInnerGenerator()
        {
            var item = decorator.GenerateAtPower("power");
            Assert.That(item, Is.EqualTo(innerItem));
        }

        [Test]
        public void DoNotGetCurseIfNotCursed()
        {
            mockCurseGenerator.Setup(g => g.HasCurse(It.IsAny<bool>())).Returns(false);
            mockCurseGenerator.Setup(g => g.GenerateCurse()).Returns("cursed");

            var item = decorator.GenerateAtPower("power");
            Assert.That(item.Magic.Curse, Is.Empty);
        }

        [Test]
        public void GetCurseIfCursed()
        {
            mockCurseGenerator.Setup(g => g.HasCurse(It.IsAny<bool>())).Returns(true);
            mockCurseGenerator.Setup(g => g.GenerateCurse()).Returns("cursed");

            var item = decorator.GenerateAtPower("power");
            Assert.That(item.Magic.Curse, Is.EqualTo("cursed"));
        }

        [Test]
        public void GetSpecificCursedItems()
        {
            var specificCursedItem = new Item();
            mockCurseGenerator.Setup(g => g.HasCurse(It.IsAny<bool>())).Returns(true);
            mockCurseGenerator.Setup(g => g.GenerateCurse()).Returns(TableNameConstants.Percentiles.Set.SpecificCursedItems);
            mockCurseGenerator.Setup(g => g.GenerateSpecificCursedItem()).Returns(specificCursedItem);

            var item = decorator.GenerateAtPower("power");
            Assert.That(item, Is.EqualTo(specificCursedItem));
        }
    }
}