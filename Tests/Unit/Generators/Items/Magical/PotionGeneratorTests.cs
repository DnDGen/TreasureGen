using System;
using D20Dice;
using EquipmentGen.Common.Items;
using EquipmentGen.Generators.Interfaces.Items.Magical;
using EquipmentGen.Generators.Items.Magical;
using EquipmentGen.Selectors.Interfaces;
using EquipmentGen.Selectors.Interfaces.Objects;
using Moq;
using NUnit.Framework;

namespace EquipmentGen.Tests.Unit.Generators.Items.Magical
{
    [TestFixture]
    public class PotionGeneratorTests
    {
        private IMagicalItemGenerator potionGenerator;
        private Mock<IDice> mockDice;
        private Mock<ITypeAndAmountPercentileSelector> mockTypeAndAmountPercentileSelector;
        private Mock<IPercentileSelector> mockPercentileSelector;
        private Mock<ICurseGenerator> mockCurseGenerator;
        private TypeAndAmountPercentileResult result;

        [SetUp]
        public void Setup()
        {
            mockDice = new Mock<IDice>();
            mockTypeAndAmountPercentileSelector = new Mock<ITypeAndAmountPercentileSelector>();
            mockPercentileSelector = new Mock<IPercentileSelector>();
            result = new TypeAndAmountPercentileResult();
            mockCurseGenerator = new Mock<ICurseGenerator>();

            mockTypeAndAmountPercentileSelector.Setup(s => s.SelectFrom(It.IsAny<String>(), It.IsAny<Int32>())).Returns(result);

            potionGenerator = new PotionGenerator(mockDice.Object, mockTypeAndAmountPercentileSelector.Object, mockPercentileSelector.Object);
        }

        [Test]
        public void ReturnPotion()
        {
            var potion = potionGenerator.GenerateAtPower("power");
            Assert.That(potion, Is.Not.Null);
            Assert.That(potion.Attributes, Contains.Item(AttributeConstants.OneTimeUse));
            Assert.That(potion.IsMagical, Is.True);
            Assert.That(potion.Quantity, Is.EqualTo(1));
        }

        [Test]
        public void GetPotionFromSelector()
        {
            var newResult = new TypeAndAmountPercentileResult();
            newResult.Type = "potion";
            newResult.Amount = "9266";

            mockDice.Setup(d => d.Percentile(1)).Returns(9266);
            mockTypeAndAmountPercentileSelector.Setup(s => s.SelectFrom("powerPotions", 9266)).Returns(newResult);

            var potion = potionGenerator.GenerateAtPower("power");
            Assert.That(potion.Name, Is.EqualTo(result.Type));
            Assert.That(potion.Magic.Bonus, Is.EqualTo(Convert.ToInt32(result.Amount)));

        }

        [Test]
        public void AlignmentIsGenerated()
        {
            result.Type = "potion of ALIGNMENT";
            mockPercentileSelector.Setup(s => s.SelectFrom("IntelligenceAlignments", It.IsAny<Int32>())).Returns("an alignment");

            var potion = potionGenerator.GenerateAtPower("power");
            Assert.That(potion.Name, Is.EqualTo("potion of an alignment"));
        }

        [Test]
        public void EnergyIsGenerated()
        {
            result.Type = "potion of ENERGY";
            mockPercentileSelector.Setup(s => s.SelectFrom("Elements", It.IsAny<Int32>())).Returns("an element");

            var potion = potionGenerator.GenerateAtPower("power");
            Assert.That(potion.Name, Is.EqualTo("potion of an element"));
        }

        [Test]
        public void DoNotGetCurseIfNotCursed()
        {
            mockCurseGenerator.Setup(g => g.HasCurse(It.IsAny<Boolean>())).Returns(false);
            mockCurseGenerator.Setup(g => g.GenerateCurse()).Returns("cursed");

            var potion = potionGenerator.GenerateAtPower("power");
            Assert.That(potion.Magic.Curse, Is.Empty);
        }

        [Test]
        public void GetCurseIfCursed()
        {
            mockCurseGenerator.Setup(g => g.HasCurse(It.IsAny<Boolean>())).Returns(true);
            mockCurseGenerator.Setup(g => g.GenerateCurse()).Returns("cursed");

            var potion = potionGenerator.GenerateAtPower("power");
            Assert.That(potion.Magic.Curse, Is.EqualTo("cursed"));
        }

        [Test]
        public void GetSpecificCursedItems()
        {
            var cursedItem = new Item();
            mockCurseGenerator.Setup(g => g.HasCurse(It.IsAny<Boolean>())).Returns(true);
            mockCurseGenerator.Setup(g => g.GenerateCurse()).Returns("SpecificCursedItem");
            mockCurseGenerator.Setup(g => g.GenerateSpecificCursedItem()).Returns(cursedItem);

            var potion = potionGenerator.GenerateAtPower("power");
            Assert.That(potion, Is.EqualTo(cursedItem));
        }
    }
}