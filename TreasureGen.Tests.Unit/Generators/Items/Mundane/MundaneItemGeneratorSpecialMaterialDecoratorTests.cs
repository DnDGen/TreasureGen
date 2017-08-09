using DnDGen.Core.Selectors.Collections;
using Moq;
using NUnit.Framework;
using System.Collections.Generic;
using TreasureGen.Domain.Generators.Items.Mundane;
using TreasureGen.Domain.Items.Mundane;
using TreasureGen.Domain.Tables;
using TreasureGen.Items;
using TreasureGen.Items.Mundane;

namespace TreasureGen.Tests.Unit.Generators.Items.Mundane
{
    [TestFixture]
    public class MudnaneItemGeneratorSpecialMaterialDecoratorTests
    {
        private MundaneItemGenerator decorator;
        private Mock<ISpecialMaterialGenerator> mockMaterialGenerator;
        private Mock<MundaneItemGenerator> mockInnerGenerator;
        private Item item;
        private Mock<ICollectionsSelector> mockCollectionsSelector;
        private List<string> masterworkMaterials;

        [SetUp]
        public void Setup()
        {
            mockMaterialGenerator = new Mock<ISpecialMaterialGenerator>();
            mockInnerGenerator = new Mock<MundaneItemGenerator>();
            mockCollectionsSelector = new Mock<ICollectionsSelector>();
            decorator = new MundaneItemGeneratorSpecialMaterialDecorator(mockInnerGenerator.Object, mockMaterialGenerator.Object, mockCollectionsSelector.Object);

            item = new Item();
            masterworkMaterials = new List<string>();

            mockInnerGenerator.Setup(g => g.Generate()).Returns(item);
            mockCollectionsSelector.Setup(s => s.SelectFrom(TableNameConstants.Collections.Set.SpecialMaterials, TraitConstants.Masterwork)).Returns(masterworkMaterials);
        }

        [Test]
        public void GetItemFromInnerGenerator()
        {
            var decoratedItem = decorator.Generate();
            Assert.That(decoratedItem, Is.EqualTo(item));
        }

        [Test]
        public void DoNotGetSpecialMaterial()
        {
            mockMaterialGenerator.Setup(g => g.CanHaveSpecialMaterial(It.IsAny<string>(), It.IsAny<IEnumerable<string>>(), It.IsAny<IEnumerable<string>>()))
                .Returns(false);
            mockMaterialGenerator.Setup(g => g.GenerateFor(It.IsAny<string>(), It.IsAny<IEnumerable<string>>(), It.IsAny<IEnumerable<string>>()))
                .Returns("special material");

            var decoratedItem = decorator.Generate();
            Assert.That(decoratedItem.Traits, Is.Not.Contains("special material"));
            Assert.That(decoratedItem.Traits.Count, Is.EqualTo(0));
        }

        [Test]
        public void GetSpecialMaterial()
        {
            mockMaterialGenerator.SetupSequence(g => g.CanHaveSpecialMaterial(It.IsAny<string>(), It.IsAny<IEnumerable<string>>(), It.IsAny<IEnumerable<string>>()))
                .Returns(true).Returns(false);
            mockMaterialGenerator.Setup(g => g.GenerateFor(It.IsAny<string>(), It.IsAny<IEnumerable<string>>(), It.IsAny<IEnumerable<string>>()))
                .Returns("special material");

            var decoratedItem = decorator.Generate();
            Assert.That(decoratedItem.Traits, Contains.Item("special material"));
            Assert.That(decoratedItem.Traits.Count, Is.EqualTo(1));
        }

        [Test]
        public void GetMultipleSpecialMaterials()
        {
            mockMaterialGenerator.SetupSequence(g => g.CanHaveSpecialMaterial(It.IsAny<string>(), It.IsAny<IEnumerable<string>>(), It.IsAny<IEnumerable<string>>()))
                .Returns(true).Returns(true).Returns(false);
            mockMaterialGenerator.SetupSequence(g => g.GenerateFor(It.IsAny<string>(), It.IsAny<IEnumerable<string>>(), It.IsAny<IEnumerable<string>>()))
                .Returns("special material 1").Returns("special material 2").Returns("special material 3");

            var decoratedItem = decorator.Generate();
            Assert.That(decoratedItem.Traits, Contains.Item("special material 1"));
            Assert.That(decoratedItem.Traits, Contains.Item("special material 2"));
            Assert.That(decoratedItem.Traits.Count, Is.EqualTo(2));
        }

        [Test]
        public void DragonhideIsNotMetal()
        {
            item.Attributes = new[] { AttributeConstants.Metal };

            mockMaterialGenerator.SetupSequence(g => g.CanHaveSpecialMaterial(It.IsAny<string>(), It.IsAny<IEnumerable<string>>(), It.IsAny<IEnumerable<string>>()))
                .Returns(true).Returns(false);
            mockMaterialGenerator.Setup(g => g.GenerateFor(It.IsAny<string>(), It.IsAny<IEnumerable<string>>(), It.IsAny<IEnumerable<string>>()))
                .Returns(TraitConstants.SpecialMaterials.Dragonhide);

            var decoratedItem = decorator.Generate();
            Assert.That(decoratedItem.Traits, Contains.Item(TraitConstants.SpecialMaterials.Dragonhide));
            Assert.That(decoratedItem.Attributes, Is.All.Not.EqualTo(AttributeConstants.Metal));
        }

        [Test]
        public void DragonhideIsNotWood()
        {
            item.Attributes = new[] { AttributeConstants.Wood };

            mockMaterialGenerator.SetupSequence(g => g.CanHaveSpecialMaterial(It.IsAny<string>(), It.IsAny<IEnumerable<string>>(), It.IsAny<IEnumerable<string>>()))
                .Returns(true).Returns(false);
            mockMaterialGenerator.Setup(g => g.GenerateFor(It.IsAny<string>(), It.IsAny<IEnumerable<string>>(), It.IsAny<IEnumerable<string>>()))
                .Returns(TraitConstants.SpecialMaterials.Dragonhide);

            var decoratedItem = decorator.Generate();
            Assert.That(decoratedItem.Traits, Contains.Item(TraitConstants.SpecialMaterials.Dragonhide));
            Assert.That(decoratedItem.Attributes, Is.All.Not.EqualTo(AttributeConstants.Wood));
        }

        [Test]
        public void DecorateCustomItem()
        {
            var template = new Item();

            mockInnerGenerator.Setup(g => g.GenerateFrom(template, true)).Returns(item);
            mockMaterialGenerator.SetupSequence(g => g.CanHaveSpecialMaterial(It.IsAny<string>(), It.IsAny<IEnumerable<string>>(), It.IsAny<IEnumerable<string>>()))
                .Returns(true).Returns(false);
            mockMaterialGenerator.Setup(g => g.GenerateFor(It.IsAny<string>(), It.IsAny<IEnumerable<string>>(), It.IsAny<IEnumerable<string>>()))
                .Returns("special material");

            var decoratedItem = decorator.GenerateFrom(template, true);
            Assert.That(decoratedItem, Is.Not.EqualTo(template));
            Assert.That(decoratedItem, Is.EqualTo(item));
            Assert.That(decoratedItem.Traits, Contains.Item("special material"));
            Assert.That(decoratedItem.Traits.Count, Is.EqualTo(1));
        }

        [Test]
        public void DoNotDecorateCustomItem()
        {
            var template = new Item();

            mockInnerGenerator.Setup(g => g.GenerateFrom(template, false)).Returns(item);
            mockMaterialGenerator.SetupSequence(g => g.CanHaveSpecialMaterial(It.IsAny<string>(), It.IsAny<IEnumerable<string>>(), It.IsAny<IEnumerable<string>>()))
                .Returns(true).Returns(false);
            mockMaterialGenerator.Setup(g => g.GenerateFor(It.IsAny<string>(), It.IsAny<IEnumerable<string>>(), It.IsAny<IEnumerable<string>>()))
                .Returns("special material");

            var decoratedItem = decorator.GenerateFrom(template);
            Assert.That(decoratedItem, Is.Not.EqualTo(template));
            Assert.That(decoratedItem, Is.EqualTo(item));
            Assert.That(decoratedItem.Traits, Is.Empty);
        }

        [Test]
        public void GenerateFromSubset()
        {
            mockMaterialGenerator.Setup(g => g.CanHaveSpecialMaterial(It.IsAny<string>(), It.IsAny<IEnumerable<string>>(), It.IsAny<IEnumerable<string>>())).Returns(false);
            mockMaterialGenerator.Setup(g => g.GenerateFor(It.IsAny<string>(), It.IsAny<IEnumerable<string>>(), It.IsAny<IEnumerable<string>>())).Returns("special material");

            var subset = new[] { "item 1", "item 2" };
            mockInnerGenerator.Setup(g => g.GenerateFrom(subset)).Returns(item);

            var decoratedItem = decorator.GenerateFrom(subset);
            Assert.That(decoratedItem, Is.EqualTo(item));
            Assert.That(decoratedItem.Traits, Is.Not.Contains("special material"));
            Assert.That(decoratedItem.Traits.Count, Is.EqualTo(0));
        }

        [Test]
        public void GetSpecialMaterialFromSubset()
        {
            mockMaterialGenerator.SetupSequence(g => g.CanHaveSpecialMaterial(It.IsAny<string>(), It.IsAny<IEnumerable<string>>(), It.IsAny<IEnumerable<string>>()))
                .Returns(true).Returns(false);
            mockMaterialGenerator.Setup(g => g.GenerateFor(It.IsAny<string>(), It.IsAny<IEnumerable<string>>(), It.IsAny<IEnumerable<string>>()))
                .Returns("special material");

            var subset = new[] { "item 1", "item 2" };
            mockInnerGenerator.Setup(g => g.GenerateFrom(subset)).Returns(item);

            var decoratedItem = decorator.GenerateFrom(subset);
            Assert.That(decoratedItem.Traits, Contains.Item("special material"));
            Assert.That(decoratedItem.Traits.Count, Is.EqualTo(1));
        }

        [Test]
        public void GetMultipleSpecialMaterialsFromSubset()
        {
            mockMaterialGenerator.SetupSequence(g => g.CanHaveSpecialMaterial(It.IsAny<string>(), It.IsAny<IEnumerable<string>>(), It.IsAny<IEnumerable<string>>()))
                .Returns(true).Returns(true).Returns(false);
            mockMaterialGenerator.SetupSequence(g => g.GenerateFor(It.IsAny<string>(), It.IsAny<IEnumerable<string>>(), It.IsAny<IEnumerable<string>>()))
                .Returns("special material 1").Returns("special material 2").Returns("special material 3");

            var subset = new[] { "item 1", "item 2" };
            mockInnerGenerator.Setup(g => g.GenerateFrom(subset)).Returns(item);

            var decoratedItem = decorator.GenerateFrom(subset);
            Assert.That(decoratedItem.Traits, Contains.Item("special material 1"));
            Assert.That(decoratedItem.Traits, Contains.Item("special material 2"));
            Assert.That(decoratedItem.Traits.Count, Is.EqualTo(2));
        }

        [Test]
        public void DragonhideFromSubsetIsNotMetal()
        {
            item.Attributes = new[] { AttributeConstants.Metal };

            mockMaterialGenerator.SetupSequence(g => g.CanHaveSpecialMaterial(It.IsAny<string>(), It.IsAny<IEnumerable<string>>(), It.IsAny<IEnumerable<string>>()))
                .Returns(true).Returns(false);
            mockMaterialGenerator.Setup(g => g.GenerateFor(It.IsAny<string>(), It.IsAny<IEnumerable<string>>(), It.IsAny<IEnumerable<string>>()))
                .Returns(TraitConstants.SpecialMaterials.Dragonhide);

            var subset = new[] { "item 1", "item 2" };
            mockInnerGenerator.Setup(g => g.GenerateFrom(subset)).Returns(item);

            var decoratedItem = decorator.GenerateFrom(subset);
            Assert.That(decoratedItem.Traits, Contains.Item(TraitConstants.SpecialMaterials.Dragonhide));
            Assert.That(decoratedItem.Attributes, Is.All.Not.EqualTo(AttributeConstants.Metal));
        }

        [Test]
        public void DragonhideFromSubsetIsNotWood()
        {
            item.Attributes = new[] { AttributeConstants.Wood };

            mockMaterialGenerator.SetupSequence(g => g.CanHaveSpecialMaterial(It.IsAny<string>(), It.IsAny<IEnumerable<string>>(), It.IsAny<IEnumerable<string>>()))
                .Returns(true).Returns(false);
            mockMaterialGenerator.Setup(g => g.GenerateFor(It.IsAny<string>(), It.IsAny<IEnumerable<string>>(), It.IsAny<IEnumerable<string>>()))
                .Returns(TraitConstants.SpecialMaterials.Dragonhide);

            var subset = new[] { "item 1", "item 2" };
            mockInnerGenerator.Setup(g => g.GenerateFrom(subset)).Returns(item);

            var decoratedItem = decorator.GenerateFrom(subset);
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

            var decoratedItem = decorator.Generate();
            Assert.That(decoratedItem.Traits, Contains.Item("special material"));
            Assert.That(decoratedItem.Traits, Contains.Item(TraitConstants.Masterwork));
        }

        [Test]
        public void SpecialMaterialFromItemIsMasterwork()
        {
            masterworkMaterials.Add("special material");

            mockMaterialGenerator.Setup(g => g.CanHaveSpecialMaterial(It.IsAny<string>(), It.IsAny<IEnumerable<string>>(), It.IsAny<IEnumerable<string>>())).Returns(false);
            item.Traits.Add("special material");

            var decoratedItem = decorator.Generate();
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

            var decoratedItem = decorator.Generate();
            Assert.That(decoratedItem.Traits, Contains.Item("special material"));
            Assert.That(decoratedItem.Traits, Is.All.Not.EqualTo(TraitConstants.Masterwork));
        }

        [Test]
        public void SpecialMaterialFromItemIsNotMasterwork()
        {
            mockMaterialGenerator.Setup(g => g.CanHaveSpecialMaterial(It.IsAny<string>(), It.IsAny<IEnumerable<string>>(), It.IsAny<IEnumerable<string>>())).Returns(false);
            item.Traits.Add("special material");

            var decoratedItem = decorator.Generate();
            Assert.That(decoratedItem.Traits, Contains.Item("special material"));
            Assert.That(decoratedItem.Traits, Is.All.Not.EqualTo(TraitConstants.Masterwork));
        }
    }
}