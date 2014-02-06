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
        private Mock<ITypesProvider> mockTypesProvider;
        private Mock<ISpecialAbilityDataXmlParser> mockParser;

        private Dictionary<String, SpecialAbilityDataObject> data;

        [SetUp]
        public void Setup()
        {
            mockTypesProvider = new Mock<ITypesProvider>();

            data = new Dictionary<String, SpecialAbilityDataObject>();
            mockParser = new Mock<ISpecialAbilityDataXmlParser>();
            mockParser.Setup(p => p.Parse("SpecialAbilityData")).Returns(data);

            provider = new SpecialAbilityDataProvider();
        }

        [Test]
        public void SpecialAbilityDataProviderReturnsAbility()
        {
            var result = provider.GetDataFor("ability name");
            Assert.That(result, Is.Not.Null);
        }

        [Test]
        public void SpecialAbilityDataProviderGetsDataFromXmlParser()
        {
            var specialAbilityData = new SpecialAbilityDataObject();
            specialAbilityData.CoreName = "core name";
            specialAbilityData.BonusEquivalent = 92;
            specialAbilityData.Strength = 66;
            data.Add("ability name", specialAbilityData);

            var result = provider.GetDataFor("ability name");
            Assert.That(result.Name, Is.EqualTo("ability name"));
            Assert.That(result.CoreName, Is.EqualTo(specialAbilityData.CoreName));
            Assert.That(result.BonusEquivalent, Is.EqualTo(specialAbilityData.BonusEquivalent));
            Assert.That(result.Strength, Is.EqualTo(specialAbilityData.Strength));
        }

        [Test]
        public void SpecialAbilityDataProviderGetsTypeRequirements()
        {
            var types = new[] { "type 1" };
            mockTypesProvider.Setup(p => p.GetTypesFor("ability name", "SpecialAbilityTypes")).Returns(types);

            var result = provider.GetDataFor("ability name");
            Assert.That(result.TypeRequirements, Is.EqualTo(types));
        }

        [Test]
        public void SpecialAbilityDataProviderCachesTable()
        {
            provider.GetDataFor("ability name");
            provider.GetDataFor("ability name");
            mockParser.Verify(p => p.Parse(It.IsAny<String>()), Times.Once);
        }
    }
}