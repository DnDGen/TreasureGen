using Moq;
using NUnit.Framework;
using RollGen;
using System;
using System.Linq;
using TreasureGen.Domain.Generators.Items.Mundane;
using TreasureGen.Domain.Selectors.Attributes;
using TreasureGen.Domain.Selectors.Percentiles;
using TreasureGen.Domain.Tables;
using TreasureGen.Items;
using TreasureGen.Items.Magical;

namespace TreasureGen.Tests.Unit.Generators.Items.Mundane
{
    [TestFixture]
    public class AmmunitionGeneratorTests
    {
        private IAmmunitionGenerator ammunitionGenerator;
        private Mock<IPercentileSelector> mockPercentileSelector;
        private Mock<Dice> mockDice;
        private Mock<ICollectionsSelector> mockAttributesSelector;
        private ItemVerifier itemVerifier;

        [SetUp]
        public void Setup()
        {
            mockPercentileSelector = new Mock<IPercentileSelector>();
            mockAttributesSelector = new Mock<ICollectionsSelector>();
            mockDice = new Mock<Dice>();
            ammunitionGenerator = new AmmunitionGenerator(mockPercentileSelector.Object, mockDice.Object, mockAttributesSelector.Object);
            itemVerifier = new ItemVerifier();

            mockDice.Setup(d => d.Roll(1).d(100).AsSum()).Returns(0);
        }

        [Test]
        public void GenerateAmmunition()
        {
            mockPercentileSelector.Setup(p => p.SelectFrom(TableNameConstants.Percentiles.Set.Ammunitions)).Returns("ammunition name");

            var ammunition = ammunitionGenerator.Generate();
            Assert.That(ammunition.Name, Is.EqualTo("ammunition name"));
            Assert.That(ammunition.BaseNames.Single(), Is.EqualTo("ammunition name"));
            Assert.That(ammunition.ItemType, Is.EqualTo(ItemTypeConstants.Weapon));
        }

        [TestCase(1, 1)]
        [TestCase(2, 1)]
        [TestCase(3, 1)]
        [TestCase(4, 2)]
        [TestCase(5, 2)]
        [TestCase(6, 3)]
        [TestCase(7, 3)]
        [TestCase(8, 4)]
        [TestCase(9, 4)]
        [TestCase(10, 5)]
        [TestCase(11, 5)]
        [TestCase(12, 6)]
        [TestCase(13, 6)]
        [TestCase(14, 7)]
        [TestCase(15, 7)]
        [TestCase(16, 8)]
        [TestCase(17, 8)]
        [TestCase(18, 9)]
        [TestCase(19, 9)]
        [TestCase(20, 10)]
        [TestCase(21, 10)]
        [TestCase(22, 11)]
        [TestCase(23, 11)]
        [TestCase(24, 12)]
        [TestCase(25, 12)]
        [TestCase(26, 13)]
        [TestCase(27, 13)]
        [TestCase(28, 14)]
        [TestCase(29, 14)]
        [TestCase(30, 15)]
        [TestCase(31, 15)]
        [TestCase(32, 16)]
        [TestCase(33, 16)]
        [TestCase(34, 17)]
        [TestCase(35, 17)]
        [TestCase(36, 18)]
        [TestCase(37, 18)]
        [TestCase(38, 19)]
        [TestCase(39, 19)]
        [TestCase(40, 20)]
        [TestCase(41, 20)]
        [TestCase(42, 21)]
        [TestCase(43, 21)]
        [TestCase(44, 22)]
        [TestCase(45, 22)]
        [TestCase(46, 23)]
        [TestCase(47, 23)]
        [TestCase(48, 24)]
        [TestCase(49, 24)]
        [TestCase(50, 25)]
        [TestCase(51, 25)]
        [TestCase(52, 26)]
        [TestCase(53, 26)]
        [TestCase(54, 27)]
        [TestCase(55, 27)]
        [TestCase(56, 28)]
        [TestCase(57, 28)]
        [TestCase(58, 29)]
        [TestCase(59, 29)]
        [TestCase(60, 30)]
        [TestCase(61, 30)]
        [TestCase(62, 31)]
        [TestCase(63, 31)]
        [TestCase(64, 32)]
        [TestCase(65, 32)]
        [TestCase(66, 33)]
        [TestCase(67, 33)]
        [TestCase(68, 34)]
        [TestCase(69, 34)]
        [TestCase(70, 35)]
        [TestCase(71, 35)]
        [TestCase(72, 36)]
        [TestCase(73, 36)]
        [TestCase(74, 37)]
        [TestCase(75, 37)]
        [TestCase(76, 38)]
        [TestCase(77, 38)]
        [TestCase(78, 39)]
        [TestCase(79, 39)]
        [TestCase(80, 40)]
        [TestCase(81, 40)]
        [TestCase(82, 41)]
        [TestCase(83, 41)]
        [TestCase(84, 42)]
        [TestCase(85, 42)]
        [TestCase(86, 43)]
        [TestCase(87, 43)]
        [TestCase(88, 44)]
        [TestCase(89, 44)]
        [TestCase(90, 45)]
        [TestCase(91, 45)]
        [TestCase(92, 46)]
        [TestCase(93, 46)]
        [TestCase(94, 47)]
        [TestCase(95, 47)]
        [TestCase(96, 48)]
        [TestCase(97, 48)]
        [TestCase(98, 49)]
        [TestCase(99, 49)]
        [TestCase(100, 50)]
        public void AmmunitionQuantityRoll(int roll, int quantity)
        {
            mockDice.Setup(d => d.Roll(1).d(100).AsSum()).Returns(roll);
            var ammunition = ammunitionGenerator.Generate();
            Assert.That(ammunition.Quantity, Is.EqualTo(quantity));
        }

        [Test]
        public void GetAttributesFromSelector()
        {
            mockPercentileSelector.Setup(p => p.SelectFrom(TableNameConstants.Percentiles.Set.Ammunitions)).Returns("ammunition name");
            var attributes = new[] { "type 1", "type 2" };
            mockAttributesSelector.Setup(p => p.SelectFrom(TableNameConstants.Collections.Set.AmmunitionAttributes, "ammunition name")).Returns(attributes);

            var ammunition = ammunitionGenerator.Generate();
            Assert.That(ammunition.Attributes, Is.EqualTo(attributes));
        }

        [Test]
        public void TemplateIsAmmunition()
        {
            var name = Guid.NewGuid().ToString();
            var template = itemVerifier.CreateRandomTemplate(name);

            var ammunitions = new[] { "other ammunition", name };
            mockPercentileSelector.Setup(s => s.SelectAllFrom(TableNameConstants.Percentiles.Set.Ammunitions)).Returns(ammunitions);

            var isAmmunition = ammunitionGenerator.TemplateIsAmmunition(template);
            Assert.That(isAmmunition, Is.True);
        }

        [Test]
        public void TemplateIsNotAmmunition()
        {
            var name = Guid.NewGuid().ToString();
            var template = itemVerifier.CreateRandomTemplate(name);

            var ammunitions = new[] { "other ammunition", "ammunition" };
            mockPercentileSelector.Setup(s => s.SelectAllFrom(TableNameConstants.Percentiles.Set.Ammunitions)).Returns(ammunitions);

            var isAmmunition = ammunitionGenerator.TemplateIsAmmunition(template);
            Assert.That(isAmmunition, Is.False);
        }

        [Test]
        public void GenerateCustomAmmunition()
        {
            var name = Guid.NewGuid().ToString();
            var template = itemVerifier.CreateRandomTemplate(name);
            template.Magic.SpecialAbilities = Enumerable.Empty<SpecialAbility>();

            var attributes = new[] { "type 1", "type 2", AttributeConstants.Ammunition };
            mockAttributesSelector.Setup(p => p.SelectFrom(TableNameConstants.Collections.Set.AmmunitionAttributes, name)).Returns(attributes);

            var ammunition = ammunitionGenerator.GenerateFrom(template);
            itemVerifier.AssertMagicalItemFromTemplate(ammunition, template);
            Assert.That(ammunition.ItemType, Is.EqualTo(ItemTypeConstants.Weapon));
            Assert.That(ammunition.Quantity, Is.EqualTo(template.Quantity));
            Assert.That(ammunition.Attributes, Is.EqualTo(attributes));
            Assert.That(ammunition.BaseNames.Single(), Is.EqualTo(name));
        }
    }
}