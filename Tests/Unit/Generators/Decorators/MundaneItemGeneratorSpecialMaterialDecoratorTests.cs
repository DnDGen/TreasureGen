using System;
using System.Collections.Generic;
using EquipmentGen.Common.Items;
using EquipmentGen.Generators.Decorators;
using EquipmentGen.Generators.Interfaces.Items.Mundane;
using Moq;
using NUnit.Framework;

namespace EquipmentGen.Tests.Unit.Generators.Decorators
{
    [TestFixture]
    public class MudnaneItemGeneratorSpecialMaterialDecoratorTests
    {
        private IMundaneItemGenerator decorator;
        private Mock<ISpecialMaterialGenerator> mockMaterialGenerator;
        private Mock<IMundaneItemGenerator> mockInnerGenerator;
        private Item item;

        [SetUp]
        public void Setup()
        {
            mockMaterialGenerator = new Mock<ISpecialMaterialGenerator>();
            mockInnerGenerator = new Mock<IMundaneItemGenerator>();
            item = new Item();
            decorator = new MundaneItemGeneratorSpecialMaterialDecorator(mockInnerGenerator.Object, mockMaterialGenerator.Object);

            mockInnerGenerator.Setup(g => g.Generate()).Returns(item);
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
            mockMaterialGenerator.Setup(g => g.CanHaveSpecialMaterial(It.IsAny<String>(), It.IsAny<IEnumerable<String>>(), It.IsAny<IEnumerable<String>>()))
                .Returns(false);
            mockMaterialGenerator.Setup(g => g.GenerateFor(It.IsAny<String>(), It.IsAny<IEnumerable<String>>(), It.IsAny<IEnumerable<String>>()))
                .Returns("special material");

            var decoratedItem = decorator.Generate();
            Assert.That(decoratedItem.Traits, Is.Not.Contains("special material"));
            Assert.That(decoratedItem.Traits.Count, Is.EqualTo(0));
        }

        [Test]
        public void GetSpecialMaterial()
        {
            mockMaterialGenerator.SetupSequence(g => g.CanHaveSpecialMaterial(It.IsAny<String>(), It.IsAny<IEnumerable<String>>(), It.IsAny<IEnumerable<String>>()))
                .Returns(true).Returns(false);
            mockMaterialGenerator.Setup(g => g.GenerateFor(It.IsAny<String>(), It.IsAny<IEnumerable<String>>(), It.IsAny<IEnumerable<String>>()))
                .Returns("special material");

            var decoratedItem = decorator.Generate();
            Assert.That(decoratedItem.Traits, Contains.Item("special material"));
            Assert.That(decoratedItem.Traits.Count, Is.EqualTo(1));
        }

        [Test]
        public void GetMultipleSpecialMaterials()
        {
            mockMaterialGenerator.SetupSequence(g => g.CanHaveSpecialMaterial(It.IsAny<String>(), It.IsAny<IEnumerable<String>>(), It.IsAny<IEnumerable<String>>()))
                .Returns(true).Returns(true).Returns(false);
            mockMaterialGenerator.SetupSequence(g => g.GenerateFor(It.IsAny<String>(), It.IsAny<IEnumerable<String>>(), It.IsAny<IEnumerable<String>>()))
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

            mockMaterialGenerator.SetupSequence(g => g.CanHaveSpecialMaterial(It.IsAny<String>(), It.IsAny<IEnumerable<String>>(), It.IsAny<IEnumerable<String>>()))
                .Returns(true).Returns(false);
            mockMaterialGenerator.Setup(g => g.GenerateFor(It.IsAny<String>(), It.IsAny<IEnumerable<String>>(), It.IsAny<IEnumerable<String>>()))
                .Returns(TraitConstants.Dragonhide);

            var decoratedItem = decorator.Generate();
            Assert.That(decoratedItem.Traits, Contains.Item(TraitConstants.Dragonhide));
            Assert.That(decoratedItem.Traits.Count, Is.EqualTo(1));
            Assert.That(decoratedItem.Attributes, Is.Not.Contains(AttributeConstants.Metal));
        }

        [Test]
        public void DragonhideIsNotWood()
        {
            item.Attributes = new[] { AttributeConstants.Wood };

            mockMaterialGenerator.SetupSequence(g => g.CanHaveSpecialMaterial(It.IsAny<String>(), It.IsAny<IEnumerable<String>>(), It.IsAny<IEnumerable<String>>()))
                .Returns(true).Returns(false);
            mockMaterialGenerator.Setup(g => g.GenerateFor(It.IsAny<String>(), It.IsAny<IEnumerable<String>>(), It.IsAny<IEnumerable<String>>()))
                .Returns(TraitConstants.Dragonhide);

            var decoratedItem = decorator.Generate();
            Assert.That(decoratedItem.Traits, Contains.Item(TraitConstants.Dragonhide));
            Assert.That(decoratedItem.Traits.Count, Is.EqualTo(1));
            Assert.That(decoratedItem.Attributes, Is.Not.Contains(AttributeConstants.Wood));
        }
    }
}