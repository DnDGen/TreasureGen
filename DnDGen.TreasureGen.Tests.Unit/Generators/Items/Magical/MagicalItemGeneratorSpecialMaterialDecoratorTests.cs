using DnDGen.Infrastructure.Selectors.Collections;
using DnDGen.TreasureGen.Generators.Items.Magical;
using DnDGen.TreasureGen.Items;
using DnDGen.TreasureGen.Items.Magical;
using DnDGen.TreasureGen.Items.Mundane;
using DnDGen.TreasureGen.Tables;
using Moq;
using NUnit.Framework;
using System.Collections.Generic;

namespace DnDGen.TreasureGen.Tests.Unit.Generators.Items.Magical
{
    [TestFixture]
    public class MagicalItemGeneratorSpecialMaterialDecoratorTests
    {
        private MagicalItemGenerator decorator;
        private Mock<ISpecialMaterialGenerator> mockMaterialGenerator;
        private Mock<MagicalItemGenerator> mockInnerGenerator;
        private Item item;
        private Mock<ICollectionSelector> mockCollectionsSelector;
        private List<string> masterworkMaterials;

        [SetUp]
        public void Setup()
        {
            mockMaterialGenerator = new Mock<ISpecialMaterialGenerator>();
            mockInnerGenerator = new Mock<MagicalItemGenerator>();
            mockCollectionsSelector = new Mock<ICollectionSelector>();
            decorator = new MagicalItemGeneratorSpecialMaterialDecorator(mockInnerGenerator.Object, mockMaterialGenerator.Object, mockCollectionsSelector.Object);

            item = new Item();
            masterworkMaterials = new List<string>();

            mockInnerGenerator.Setup(g => g.GenerateFrom("power")).Returns(item);
            mockCollectionsSelector.Setup(s => s.SelectFrom(TableNameConstants.Collections.Set.SpecialMaterials, TraitConstants.Masterwork)).Returns(masterworkMaterials);
        }

        [Test]
        public void GetItemFromInnerGenerator()
        {
            var decoratedItem = decorator.GenerateFrom("power");
            Assert.That(decoratedItem, Is.EqualTo(item));
        }

        [Test]
        public void SpecificCursedItemsDoNotHaveSpecialMaterials()
        {
            item.Magic.Curse = CurseConstants.SpecificCursedItem;

            mockMaterialGenerator.Setup(g => g.CanHaveSpecialMaterial(It.IsAny<string>(), It.IsAny<IEnumerable<string>>(), It.IsAny<IEnumerable<string>>())).Returns(true);
            mockMaterialGenerator.Setup(g => g.GenerateFor(It.IsAny<string>(), It.IsAny<IEnumerable<string>>(), It.IsAny<IEnumerable<string>>())).Returns("special material");

            var decoratedItem = decorator.GenerateFrom("power");
            Assert.That(decoratedItem.Traits, Is.Empty);
        }

        [Test]
        public void DoNotGetSpecialMaterial()
        {
            mockMaterialGenerator.Setup(g => g.CanHaveSpecialMaterial(It.IsAny<string>(), It.IsAny<IEnumerable<string>>(), It.IsAny<IEnumerable<string>>())).Returns(false);
            mockMaterialGenerator.Setup(g => g.GenerateFor(It.IsAny<string>(), It.IsAny<IEnumerable<string>>(), It.IsAny<IEnumerable<string>>())).Returns("special material");

            var decoratedItem = decorator.GenerateFrom("power");
            Assert.That(decoratedItem.Traits, Is.Empty);
        }

        [Test]
        public void GetSpecialMaterial()
        {
            mockMaterialGenerator.SetupSequence(g => g.CanHaveSpecialMaterial(It.IsAny<string>(), It.IsAny<IEnumerable<string>>(), It.IsAny<IEnumerable<string>>()))
                .Returns(true)
                .Returns(false);
            mockMaterialGenerator.Setup(g => g.GenerateFor(It.IsAny<string>(), It.IsAny<IEnumerable<string>>(), It.IsAny<IEnumerable<string>>())).Returns("special material");

            var decoratedItem = decorator.GenerateFrom("power");
            Assert.That(decoratedItem.Traits, Contains.Item("special material"));
            Assert.That(decoratedItem.Traits.Count, Is.EqualTo(1));
        }

        [Test]
        public void GetMultipleSpecialMaterials()
        {
            mockMaterialGenerator.SetupSequence(g => g.CanHaveSpecialMaterial(It.IsAny<string>(), It.IsAny<IEnumerable<string>>(), It.IsAny<IEnumerable<string>>()))
                .Returns(true)
                .Returns(true)
                .Returns(false);
            mockMaterialGenerator.SetupSequence(g => g.GenerateFor(It.IsAny<string>(), It.IsAny<IEnumerable<string>>(), It.IsAny<IEnumerable<string>>()))
                .Returns("special material 1")
                .Returns("special material 2")
                .Returns("special material 3");

            var decoratedItem = decorator.GenerateFrom("power");
            Assert.That(decoratedItem.Traits, Contains.Item("special material 1"));
            Assert.That(decoratedItem.Traits, Contains.Item("special material 2"));
            Assert.That(decoratedItem.Traits.Count, Is.EqualTo(2));
        }

        [Test]
        public void DragonhideIsNotMetal()
        {
            item.Attributes = new[] { AttributeConstants.Metal };

            mockMaterialGenerator.SetupSequence(g => g.CanHaveSpecialMaterial(It.IsAny<string>(), It.IsAny<IEnumerable<string>>(), It.IsAny<IEnumerable<string>>()))
                .Returns(true)
                .Returns(false);
            mockMaterialGenerator.Setup(g => g.GenerateFor(It.IsAny<string>(), It.IsAny<IEnumerable<string>>(), It.IsAny<IEnumerable<string>>())).Returns(TraitConstants.SpecialMaterials.Dragonhide);

            var decoratedItem = decorator.GenerateFrom("power");
            Assert.That(decoratedItem.Traits, Contains.Item(TraitConstants.SpecialMaterials.Dragonhide));
            Assert.That(decoratedItem.Attributes, Is.All.Not.EqualTo(AttributeConstants.Metal));
        }

        [Test]
        public void DragonhideIsNotWood()
        {
            item.Attributes = new[] { AttributeConstants.Wood };

            mockMaterialGenerator.SetupSequence(g => g.CanHaveSpecialMaterial(It.IsAny<string>(), It.IsAny<IEnumerable<string>>(), It.IsAny<IEnumerable<string>>()))
                .Returns(true)
                .Returns(false);
            mockMaterialGenerator.Setup(g => g.GenerateFor(It.IsAny<string>(), It.IsAny<IEnumerable<string>>(), It.IsAny<IEnumerable<string>>())).Returns(TraitConstants.SpecialMaterials.Dragonhide);

            var decoratedItem = decorator.GenerateFrom("power");
            Assert.That(decoratedItem.Traits, Contains.Item(TraitConstants.SpecialMaterials.Dragonhide));
            Assert.That(decoratedItem.Attributes, Is.All.Not.EqualTo(AttributeConstants.Wood));
        }

        [Test]
        public void DecorateCustomItem()
        {
            var template = new Item();

            mockInnerGenerator.Setup(g => g.GenerateFrom(template, true)).Returns(item);
            mockMaterialGenerator.SetupSequence(g => g.CanHaveSpecialMaterial(It.IsAny<string>(), It.IsAny<IEnumerable<string>>(), It.IsAny<IEnumerable<string>>()))
                .Returns(true)
                .Returns(false);
            mockMaterialGenerator.Setup(g => g.GenerateFor(It.IsAny<string>(), It.IsAny<IEnumerable<string>>(), It.IsAny<IEnumerable<string>>())).Returns("special material");

            var decoratedItem = decorator.GenerateFrom(template, allowRandomDecoration: true);
            Assert.That(decoratedItem, Is.Not.EqualTo(template));
            Assert.That(decoratedItem, Is.EqualTo(item));
            Assert.That(decoratedItem.Traits, Contains.Item("special material"));
        }

        [Test]
        public void DoNotDecorateCustomItem()
        {
            var template = new Item();

            mockInnerGenerator.Setup(g => g.GenerateFrom(template, false)).Returns(item);
            mockMaterialGenerator.SetupSequence(g => g.CanHaveSpecialMaterial(It.IsAny<string>(), It.IsAny<IEnumerable<string>>(), It.IsAny<IEnumerable<string>>()))
                .Returns(true)
                .Returns(false);
            mockMaterialGenerator.Setup(g => g.GenerateFor(It.IsAny<string>(), It.IsAny<IEnumerable<string>>(), It.IsAny<IEnumerable<string>>())).Returns("special material");

            var decoratedItem = decorator.GenerateFrom(template);
            Assert.That(decoratedItem, Is.Not.EqualTo(template));
            Assert.That(decoratedItem, Is.EqualTo(item));
            Assert.That(decoratedItem.Traits, Is.Empty);
        }

        [Test]
        public void GenerateFromSubset()
        {
            var subset = new[] { "item 1", "item 2" };
            var subsetItem = new Item();
            mockInnerGenerator.Setup(g => g.GenerateFrom("power", subset)).Returns(subsetItem);

            var decoratedItem = decorator.GenerateFrom("power", subset);
            Assert.That(decoratedItem, Is.EqualTo(subsetItem));
        }

        [Test]
        public void SpecificCursedItemsDoNotHaveSpecialMaterialsFromSubset()
        {
            var subset = new[] { "item 1", "item 2" };
            mockInnerGenerator.Setup(g => g.GenerateFrom("power", subset)).Returns(item);

            item.Magic.Curse = CurseConstants.SpecificCursedItem;

            mockMaterialGenerator.Setup(g => g.CanHaveSpecialMaterial(It.IsAny<string>(), It.IsAny<IEnumerable<string>>(), It.IsAny<IEnumerable<string>>())).Returns(true);
            mockMaterialGenerator.Setup(g => g.GenerateFor(It.IsAny<string>(), It.IsAny<IEnumerable<string>>(), It.IsAny<IEnumerable<string>>())).Returns("special material");

            var decoratedItem = decorator.GenerateFrom("power", subset);
            Assert.That(decoratedItem.Traits, Is.Empty);
        }

        [Test]
        public void DoNotGetSpecialMaterialFromSubset()
        {
            var subset = new[] { "item 1", "item 2" };
            mockInnerGenerator.Setup(g => g.GenerateFrom("power", subset)).Returns(item);

            mockMaterialGenerator.Setup(g => g.CanHaveSpecialMaterial(It.IsAny<string>(), It.IsAny<IEnumerable<string>>(), It.IsAny<IEnumerable<string>>())).Returns(false);
            mockMaterialGenerator.Setup(g => g.GenerateFor(It.IsAny<string>(), It.IsAny<IEnumerable<string>>(), It.IsAny<IEnumerable<string>>())).Returns("special material");

            var decoratedItem = decorator.GenerateFrom("power", subset);
            Assert.That(decoratedItem.Traits, Is.Empty);
        }

        [Test]
        public void GetSpecialMaterialFromSubset()
        {
            var subset = new[] { "item 1", "item 2" };
            mockInnerGenerator.Setup(g => g.GenerateFrom("power", subset)).Returns(item);

            mockMaterialGenerator.SetupSequence(g => g.CanHaveSpecialMaterial(It.IsAny<string>(), It.IsAny<IEnumerable<string>>(), It.IsAny<IEnumerable<string>>()))
                .Returns(true)
                .Returns(false);
            mockMaterialGenerator.Setup(g => g.GenerateFor(It.IsAny<string>(), It.IsAny<IEnumerable<string>>(), It.IsAny<IEnumerable<string>>())).Returns("special material");

            var decoratedItem = decorator.GenerateFrom("power", subset);
            Assert.That(decoratedItem.Traits, Contains.Item("special material"));
            Assert.That(decoratedItem.Traits.Count, Is.EqualTo(1));
        }

        [Test]
        public void GetMultipleSpecialMaterialsFromSubset()
        {
            var subset = new[] { "item 1", "item 2" };
            mockInnerGenerator.Setup(g => g.GenerateFrom("power", subset)).Returns(item);

            mockMaterialGenerator.SetupSequence(g => g.CanHaveSpecialMaterial(It.IsAny<string>(), It.IsAny<IEnumerable<string>>(), It.IsAny<IEnumerable<string>>()))
                .Returns(true)
                .Returns(true)
                .Returns(false);
            mockMaterialGenerator.SetupSequence(g => g.GenerateFor(It.IsAny<string>(), It.IsAny<IEnumerable<string>>(), It.IsAny<IEnumerable<string>>()))
                .Returns("special material 1")
                .Returns("special material 2")
                .Returns("special material 3");

            var decoratedItem = decorator.GenerateFrom("power", subset);
            Assert.That(decoratedItem.Traits, Contains.Item("special material 1"));
            Assert.That(decoratedItem.Traits, Contains.Item("special material 2"));
            Assert.That(decoratedItem.Traits.Count, Is.EqualTo(2));
        }

        [Test]
        public void DragonhideFromSubsetIsNotMetal()
        {
            var subset = new[] { "item 1", "item 2" };
            mockInnerGenerator.Setup(g => g.GenerateFrom("power", subset)).Returns(item);

            item.Attributes = new[] { AttributeConstants.Metal };

            mockMaterialGenerator.SetupSequence(g => g.CanHaveSpecialMaterial(It.IsAny<string>(), It.IsAny<IEnumerable<string>>(), It.IsAny<IEnumerable<string>>()))
                .Returns(true)
                .Returns(false);
            mockMaterialGenerator.Setup(g => g.GenerateFor(It.IsAny<string>(), It.IsAny<IEnumerable<string>>(), It.IsAny<IEnumerable<string>>())).Returns(TraitConstants.SpecialMaterials.Dragonhide);

            var decoratedItem = decorator.GenerateFrom("power", subset);
            Assert.That(decoratedItem.Traits, Contains.Item(TraitConstants.SpecialMaterials.Dragonhide));
            Assert.That(decoratedItem.Attributes, Is.All.Not.EqualTo(AttributeConstants.Metal));
        }

        [Test]
        public void DragonhideFromSubsetIsNotWood()
        {
            var subset = new[] { "item 1", "item 2" };
            mockInnerGenerator.Setup(g => g.GenerateFrom("power", subset)).Returns(item);

            item.Attributes = new[] { AttributeConstants.Wood };

            mockMaterialGenerator.SetupSequence(g => g.CanHaveSpecialMaterial(It.IsAny<string>(), It.IsAny<IEnumerable<string>>(), It.IsAny<IEnumerable<string>>()))
                .Returns(true)
                .Returns(false);
            mockMaterialGenerator.Setup(g => g.GenerateFor(It.IsAny<string>(), It.IsAny<IEnumerable<string>>(), It.IsAny<IEnumerable<string>>())).Returns(TraitConstants.SpecialMaterials.Dragonhide);

            var decoratedItem = decorator.GenerateFrom("power", subset);
            Assert.That(decoratedItem.Traits, Contains.Item(TraitConstants.SpecialMaterials.Dragonhide));
            Assert.That(decoratedItem.Attributes, Is.All.Not.EqualTo(AttributeConstants.Wood));
        }

        [Test]
        public void SpecialMaterialIsMasterwork()
        {
            masterworkMaterials.Add("special material");

            mockMaterialGenerator.SetupSequence(g => g.CanHaveSpecialMaterial(It.IsAny<string>(), It.IsAny<IEnumerable<string>>(), It.IsAny<IEnumerable<string>>()))
                .Returns(true)
                .Returns(false);
            mockMaterialGenerator.Setup(g => g.GenerateFor(It.IsAny<string>(), It.IsAny<IEnumerable<string>>(), It.IsAny<IEnumerable<string>>())).Returns("special material");

            var decoratedItem = decorator.GenerateFrom("power");
            Assert.That(decoratedItem.Traits, Contains.Item("special material"));
            Assert.That(decoratedItem.Traits, Contains.Item(TraitConstants.Masterwork));
        }

        [Test]
        public void SpecialMaterialFromItemIsMasterwork()
        {
            masterworkMaterials.Add("special material");

            mockMaterialGenerator.Setup(g => g.CanHaveSpecialMaterial(It.IsAny<string>(), It.IsAny<IEnumerable<string>>(), It.IsAny<IEnumerable<string>>())).Returns(false);
            item.Traits.Add("special material");

            var decoratedItem = decorator.GenerateFrom("power");
            Assert.That(decoratedItem.Traits, Contains.Item("special material"));
            Assert.That(decoratedItem.Traits, Contains.Item(TraitConstants.Masterwork));
        }

        [Test]
        public void SpecialMaterialIsNotMasterwork()
        {
            mockMaterialGenerator.SetupSequence(g => g.CanHaveSpecialMaterial(It.IsAny<string>(), It.IsAny<IEnumerable<string>>(), It.IsAny<IEnumerable<string>>()))
                .Returns(true)
                .Returns(false);
            mockMaterialGenerator.Setup(g => g.GenerateFor(It.IsAny<string>(), It.IsAny<IEnumerable<string>>(), It.IsAny<IEnumerable<string>>())).Returns("special material");

            var decoratedItem = decorator.GenerateFrom("power");
            Assert.That(decoratedItem.Traits, Contains.Item("special material"));
            Assert.That(decoratedItem.Traits, Is.All.Not.EqualTo(TraitConstants.Masterwork));
        }

        [Test]
        public void SpecialMaterialFromItemIsNotMasterwork()
        {
            mockMaterialGenerator.Setup(g => g.CanHaveSpecialMaterial(It.IsAny<string>(), It.IsAny<IEnumerable<string>>(), It.IsAny<IEnumerable<string>>())).Returns(false);
            item.Traits.Add("special material");

            var decoratedItem = decorator.GenerateFrom("power");
            Assert.That(decoratedItem.Traits, Contains.Item("special material"));
            Assert.That(decoratedItem.Traits, Is.All.Not.EqualTo(TraitConstants.Masterwork));
        }
    }
}