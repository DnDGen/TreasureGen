using System;
using System.Collections.Generic;
using EquipmentGen.Mappers.Interfaces;
using EquipmentGen.Mappers.Objects;
using EquipmentGen.Selectors;
using EquipmentGen.Selectors.Interfaces;
using Moq;
using NUnit.Framework;

namespace EquipmentGen.Tests.Unit.Selectors
{
    [TestFixture]
    public class SpecialAbilityDataSelectorTests
    {
        private ISpecialAbilityDataSelector selector;
        private Mock<IAttributesSelector> mockAttributesSelector;
        private Mock<ISpecialAbilityDataMapper> mockMapper;

        private Dictionary<String, SpecialAbilityDataObject> data;
        private SpecialAbilityDataObject specialAbilityData;

        [SetUp]
        public void Setup()
        {
            mockAttributesSelector = new Mock<IAttributesSelector>();

            data = new Dictionary<String, SpecialAbilityDataObject>();
            specialAbilityData = new SpecialAbilityDataObject();
            specialAbilityData.CoreName = "core name";
            specialAbilityData.BonusEquivalent = 92;
            specialAbilityData.Strength = 66;
            data.Add("ability name", specialAbilityData);

            mockMapper = new Mock<ISpecialAbilityDataMapper>();
            mockMapper.Setup(p => p.Map("SpecialAbilityData")).Returns(data);

            selector = new SpecialAbilityDataSelector(mockMapper.Object, mockAttributesSelector.Object);
        }

        [Test]
        public void GetDataFromMapper()
        {
            var result = selector.SelectFor("ability name");
            Assert.That(result.Name, Is.EqualTo("ability name"));
            Assert.That(result.CoreName, Is.EqualTo(specialAbilityData.CoreName));
            Assert.That(result.BonusEquivalent, Is.EqualTo(specialAbilityData.BonusEquivalent));
            Assert.That(result.Strength, Is.EqualTo(specialAbilityData.Strength));
        }

        [Test]
        public void GetAttributeRequirements()
        {
            var attributes = new[] { "type 1" };
            mockAttributesSelector.Setup(p => p.SelectFrom("SpecialAbilityAttributes", "core name")).Returns(attributes);

            var result = selector.SelectFor("ability name");
            Assert.That(result.AttributeRequirements, Is.EqualTo(attributes));
        }

        [Test]
        public void ThrowExceptionIfSpecialAbilityNotFound()
        {
            Assert.That(() => selector.SelectFor("Ability not in collection"), Throws.ArgumentException.With.Message.EqualTo(
                "The ability Ability not in collection was not present in the special ability data collection."));
        }
    }
}