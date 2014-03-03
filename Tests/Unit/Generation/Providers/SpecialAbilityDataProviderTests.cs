using System;
using System.Collections.Generic;
using EquipmentGen.Core.Generation.Providers;
using EquipmentGen.Core.Generation.Providers.Interfaces;
using EquipmentGen.Core.Generation.Xml.Parsers.Interfaces;
using EquipmentGen.Core.Generation.Xml.Parsers.Objects;
using Moq;
using NUnit.Framework;

namespace EquipmentGen.Tests.Unit.Generation.Providers
{
    [TestFixture]
    public class SpecialAbilityDataProviderTests
    {
        private ISpecialAbilityDataProvider provider;
        private Mock<IAttributesProvider> mockAttributesProvider;
        private Mock<ISpecialAbilityDataXmlParser> mockParser;

        private Dictionary<String, SpecialAbilityDataObject> data;
        private SpecialAbilityDataObject specialAbilityData;

        [SetUp]
        public void Setup()
        {
            mockAttributesProvider = new Mock<IAttributesProvider>();

            data = new Dictionary<String, SpecialAbilityDataObject>();
            specialAbilityData = new SpecialAbilityDataObject();
            specialAbilityData.CoreName = "core name";
            specialAbilityData.BonusEquivalent = 92;
            specialAbilityData.Strength = 66;
            data.Add("ability name", specialAbilityData);

            mockParser = new Mock<ISpecialAbilityDataXmlParser>();
            mockParser.Setup(p => p.Parse("SpecialAbilityData.xml")).Returns(data);

            provider = new SpecialAbilityDataProvider(mockParser.Object, mockAttributesProvider.Object);
        }

        [Test]
        public void GetDataFromXmlParser()
        {
            var result = provider.GetDataFor("ability name");
            Assert.That(result.Name, Is.EqualTo("ability name"));
            Assert.That(result.CoreName, Is.EqualTo(specialAbilityData.CoreName));
            Assert.That(result.BonusEquivalent, Is.EqualTo(specialAbilityData.BonusEquivalent));
            Assert.That(result.Strength, Is.EqualTo(specialAbilityData.Strength));
        }

        [Test]
        public void GetTypeRequirements()
        {
            var attributes = new[] { "type 1" };
            mockAttributesProvider.Setup(p => p.GetAttributesFor("core name", "SpecialAbilityAttributes")).Returns(attributes);

            var result = provider.GetDataFor("ability name");
            Assert.That(result.AttributeRequirements, Is.EqualTo(attributes));
        }

        [Test]
        public void CacheTable()
        {
            provider.GetDataFor("ability name");
            provider.GetDataFor("ability name");
            mockParser.Verify(p => p.Parse(It.IsAny<String>()), Times.Once);
        }

        [Test]
        public void ThrowExceptionIfSpecialAbilityNotFound()
        {
            Assert.That(() => provider.GetDataFor("Ability not in collection"), Throws.ArgumentException.With.Message.EqualTo(
                "The ability Ability not in collection was not present in the special ability data collection."));
        }
    }
}