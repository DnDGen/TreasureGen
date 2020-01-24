using DnDGen.TreasureGen.Generators.Items.Magical;
using DnDGen.TreasureGen.Items;
using DnDGen.TreasureGen.Items.Magical;
using DnDGen.TreasureGen.Tables;
using Moq;
using NUnit.Framework;
using System;

namespace DnDGen.TreasureGen.Tests.Unit.Generators.Items.Magical
{
    [TestFixture]
    public class MagicalItemGeneratorCurseDecoratorTests
    {
        private MagicalItemGenerator decorator;
        private Mock<ICurseGenerator> mockCurseGenerator;
        private Mock<MagicalItemGenerator> mockInnerGenerator;
        private Item innerItem;
        private ItemVerifier itemVerifier;

        [SetUp]
        public void Setup()
        {
            mockInnerGenerator = new Mock<MagicalItemGenerator>();
            mockCurseGenerator = new Mock<ICurseGenerator>();
            decorator = new MagicalItemGeneratorCurseDecorator(mockInnerGenerator.Object, mockCurseGenerator.Object);
            innerItem = new Item();
            itemVerifier = new ItemVerifier();

            innerItem.ItemType = "item type";
            innerItem.Name = "item name";

            mockInnerGenerator.Setup(g => g.GenerateFrom("power")).Returns(innerItem);
        }

        [Test]
        public void GetItemFromInnerGenerator()
        {
            var item = decorator.GenerateFrom("power");
            Assert.That(item, Is.EqualTo(innerItem));
        }

        [Test]
        public void DoNotGetCurseIfNotCursed()
        {
            mockCurseGenerator.Setup(g => g.HasCurse(innerItem)).Returns(false);
            mockCurseGenerator.Setup(g => g.GenerateCurse()).Returns("cursed");

            var item = decorator.GenerateFrom("power");
            Assert.That(item.Magic.Curse, Is.Empty);
        }

        [Test]
        public void GetCurseIfCursed()
        {
            mockCurseGenerator.Setup(g => g.HasCurse(innerItem)).Returns(true);
            mockCurseGenerator.Setup(g => g.GenerateCurse()).Returns("cursed");

            var item = decorator.GenerateFrom("power");
            Assert.That(item.Magic.Curse, Is.EqualTo("cursed"));
        }

        [Test]
        public void GetSpecificCursedItem_CanBeSpecific()
        {
            var specificCursedItem = new Item();
            mockCurseGenerator.Setup(g => g.HasCurse(innerItem)).Returns(true);
            mockCurseGenerator.Setup(g => g.ItemTypeCanBeSpecificCursedItem(innerItem.ItemType)).Returns(true);
            mockCurseGenerator.Setup(g => g.GenerateCurse()).Returns(TableNameConstants.Percentiles.Set.SpecificCursedItems);
            mockCurseGenerator.Setup(g => g.Generate()).Returns(specificCursedItem);

            var item = decorator.GenerateFrom("power");
            Assert.That(item, Is.EqualTo(specificCursedItem));
        }

        [Test]
        public void DoNotGetSpecificCursedItem_CannotBeSpecific()
        {
            var specificCursedItem = new Item();
            mockCurseGenerator.Setup(g => g.HasCurse(innerItem)).Returns(true);
            mockCurseGenerator.Setup(g => g.ItemTypeCanBeSpecificCursedItem(innerItem.ItemType)).Returns(false);
            mockCurseGenerator.SetupSequence(g => g.GenerateCurse())
                .Returns(TableNameConstants.Percentiles.Set.SpecificCursedItems)
                .Returns(TableNameConstants.Percentiles.Set.SpecificCursedItems)
                .Returns("cursed");

            var item = decorator.GenerateFrom("power");
            Assert.That(item, Is.EqualTo(innerItem));
            Assert.That(item.Magic.Curse, Is.EqualTo("cursed"));
        }

        [Test]
        public void DecorateCustomItem()
        {
            var template = new Item();

            mockInnerGenerator.Setup(g => g.GenerateFrom(template, true)).Returns(innerItem);
            mockCurseGenerator.Setup(g => g.HasCurse(innerItem)).Returns(true);
            mockCurseGenerator.Setup(g => g.GenerateCurse()).Returns("cursed");

            var decoratedItem = decorator.GenerateFrom(template, allowRandomDecoration: true);
            Assert.That(decoratedItem, Is.Not.EqualTo(template));
            Assert.That(decoratedItem, Is.EqualTo(innerItem));
            Assert.That(decoratedItem.Magic.Curse, Is.EqualTo("cursed"));
        }

        [Test]
        public void DoNotDecorateCustomItem()
        {
            var template = new Item();

            mockInnerGenerator.Setup(g => g.GenerateFrom(template, false)).Returns(innerItem);
            mockCurseGenerator.Setup(g => g.HasCurse(innerItem)).Returns(true);
            mockCurseGenerator.Setup(g => g.GenerateCurse()).Returns("cursed");

            var decoratedItem = decorator.GenerateFrom(template);
            Assert.That(decoratedItem, Is.Not.EqualTo(template));
            Assert.That(decoratedItem, Is.EqualTo(innerItem));
            Assert.That(decoratedItem.Magic.Curse, Is.Empty);
        }

        [Test]
        public void DoNotGetSpecificCursedItemsForCustomItem()
        {
            var template = new Item();
            var specificCursedItem = new Item();

            mockInnerGenerator.Setup(g => g.GenerateFrom(template, true)).Returns(innerItem);
            mockCurseGenerator.Setup(g => g.HasCurse(innerItem)).Returns(true);
            mockCurseGenerator.SetupSequence(g => g.GenerateCurse())
                .Returns(TableNameConstants.Percentiles.Set.SpecificCursedItems)
                .Returns(TableNameConstants.Percentiles.Set.SpecificCursedItems)
                .Returns("cursed");
            mockCurseGenerator.Setup(g => g.Generate()).Returns(specificCursedItem);

            var decoratedItem = decorator.GenerateFrom(template, allowRandomDecoration: true);
            Assert.That(decoratedItem, Is.Not.EqualTo(template));
            Assert.That(decoratedItem, Is.Not.EqualTo(specificCursedItem));
            Assert.That(decoratedItem, Is.EqualTo(innerItem));
            Assert.That(decoratedItem.Magic.Curse, Is.EqualTo("cursed"));
        }

        [Test]
        public void GenerateSpecificCursedCustomItem()
        {
            var name = Guid.NewGuid().ToString();
            var template = itemVerifier.CreateRandomTemplate(name);

            var cursedItem = itemVerifier.CreateRandomTemplate(name);
            mockCurseGenerator.Setup(g => g.IsSpecificCursedItem(template)).Returns(true);
            mockCurseGenerator.Setup(g => g.GenerateFrom(template, false)).Returns(cursedItem);

            var decoratedItem = decorator.GenerateFrom(template, allowRandomDecoration: true);
            Assert.That(decoratedItem, Is.EqualTo(cursedItem));
            mockInnerGenerator.Verify(g => g.GenerateFrom(It.IsAny<Item>(), It.IsAny<bool>()), Times.Never);
        }

        [Test]
        public void GenerateNoCurseFromName()
        {
            mockCurseGenerator.Setup(g => g.HasCurse(innerItem)).Returns(false);
            mockCurseGenerator.Setup(g => g.GenerateCurse()).Returns("cursed");

            mockInnerGenerator.Setup(g => g.GenerateFrom("power", "item name")).Returns(innerItem);

            var item = decorator.GenerateFrom("power", "item name");
            Assert.That(item, Is.EqualTo(innerItem));
            Assert.That(item.Magic.Curse, Is.Empty);
        }

        [Test]
        public void GenerateCurseFromName()
        {
            mockCurseGenerator.Setup(g => g.HasCurse(innerItem)).Returns(true);
            mockCurseGenerator.Setup(g => g.GenerateCurse()).Returns("cursed");

            mockInnerGenerator.Setup(g => g.GenerateFrom("power", "item name")).Returns(innerItem);

            var item = decorator.GenerateFrom("power", "item name");
            Assert.That(item, Is.EqualTo(innerItem));
            Assert.That(item.Magic.Curse, Is.EqualTo("cursed"));
        }

        [Test]
        public void GenerateSpecificFromName_CanBeSpecific()
        {
            var subset = new[] { "item 1", "item 2" };
            mockInnerGenerator.Setup(g => g.GenerateFrom("power", "item name")).Returns(innerItem);

            var specificCursedItem = new Item();
            mockCurseGenerator.Setup(g => g.HasCurse(innerItem)).Returns(true);
            mockCurseGenerator.Setup(g => g.CanBeSpecificCursedItem("item name")).Returns(true);
            mockCurseGenerator.Setup(g => g.GenerateCurse()).Returns(TableNameConstants.Percentiles.Set.SpecificCursedItems);
            mockCurseGenerator.Setup(g => g.Generate("item name")).Returns(specificCursedItem);

            var item = decorator.GenerateFrom("power", "item name");
            Assert.That(item, Is.EqualTo(specificCursedItem));
        }

        [Test]
        public void DoNotGenerateSpecificFromName_CannotBeSpecific()
        {
            var subset = new[] { "item 1", "item 2" };
            mockInnerGenerator.Setup(g => g.GenerateFrom("power", "item name")).Returns(innerItem);

            var specificCursedItem = new Item();
            mockCurseGenerator.Setup(g => g.HasCurse(innerItem)).Returns(true);
            mockCurseGenerator.Setup(g => g.CanBeSpecificCursedItem("item name")).Returns(false);
            mockCurseGenerator.SetupSequence(g => g.GenerateCurse())
                .Returns(TableNameConstants.Percentiles.Set.SpecificCursedItems)
                .Returns(TableNameConstants.Percentiles.Set.SpecificCursedItems)
                .Returns("cursed");
            mockCurseGenerator.Setup(g => g.Generate("item name")).Returns(specificCursedItem);

            var item = decorator.GenerateFrom("power", "item name");
            Assert.That(item, Is.EqualTo(innerItem));
            Assert.That(item.Magic.Curse, Is.EqualTo("cursed"));
        }
    }
}