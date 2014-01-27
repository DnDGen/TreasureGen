using System;
using System.Collections.Generic;
using System.Linq;
using D20Dice;
using EquipmentGen.Core.Generation.Providers;
using EquipmentGen.Core.Generation.Providers.Interfaces;
using EquipmentGen.Core.Generation.Xml.Parsers.Interfaces;
using Moq;
using NUnit.Framework;

namespace EquipmentGen.Tests.Unit.Generation.Providers
{
    [TestFixture]
    public class MaterialsProviderTests
    {
        private IMaterialsProvider materialsProvider;
        private Mock<IDice> mockDice;
        private Mock<ITypesXmlParser> mockTypesXmlParser;

        private Dictionary<String, IEnumerable<String>> materials;

        [SetUp]
        public void Setup()
        {
            mockDice = new Mock<IDice>();

            materials = new Dictionary<String, IEnumerable<String>>();
            mockTypesXmlParser = new Mock<ITypesXmlParser>();
            mockTypesXmlParser.Setup(p => p.Parse("SpecialMaterials.xml")).Returns(materials);

            materialsProvider = new MaterialsProvider(mockDice.Object, mockTypesXmlParser.Object);
        }

        [Test]
        public void HasSpecialMaterialsReturnsFalseIfPercentileLessThan96()
        {
            for (var roll = 1; roll < 96; roll++)
            {
                mockDice.Setup(d => d.Percentile(1)).Returns(roll);
                var hasSpecialMaterial = materialsProvider.HasSpecialMaterial();
                Assert.That(hasSpecialMaterial, Is.False);
            }
        }

        [Test]
        public void HasSpecialMaterialsReturnsTrueIfPercentileGreaterThan95()
        {
            for (var roll = 96; roll <= 100; roll++)
            {
                mockDice.Setup(d => d.Percentile(1)).Returns(roll);
                var hasSpecialMaterial = materialsProvider.HasSpecialMaterial();
                Assert.That(hasSpecialMaterial, Is.True);
            }
        }

        [Test]
        public void GetMaterialsFromXmlParser()
        {
            materialsProvider.GetSpecialMaterialFor(Enumerable.Empty<String>());
            mockTypesXmlParser.Verify(p => p.Parse("SpecialMaterials.xml"), Times.Once);
        }

        [Test]
        public void MaterialAllowedIfPassedInTypesContainAllRequiredTypes()
        {
            materials.Add("special material", new[] { "type 1", "type 2" });

            var material = materialsProvider.GetSpecialMaterialFor(new[] { "type 1", "type 2" });
            Assert.That(material, Is.EqualTo("special material"));

            material = materialsProvider.GetSpecialMaterialFor(new[] { "type 1", "type 2", "other type" });
            Assert.That(material, Is.EqualTo("special material"));
        }

        [Test]
        public void MaterialNotAllowedIfPassedInTypesDoNotContainAllRequiredTypes()
        {
            materials.Add("special material", new[] { "type 1", "type 2" });

            var material = materialsProvider.GetSpecialMaterialFor(Enumerable.Empty<String>());
            Assert.That(material, Is.EqualTo(String.Empty));

            material = materialsProvider.GetSpecialMaterialFor(new[] { "type 1" });
            Assert.That(material, Is.EqualTo(String.Empty));

            material = materialsProvider.GetSpecialMaterialFor(new[] { "type 2" });
            Assert.That(material, Is.EqualTo(String.Empty));

            material = materialsProvider.GetSpecialMaterialFor(new[] { "type 1", "other type" });
            Assert.That(material, Is.EqualTo(String.Empty));

            material = materialsProvider.GetSpecialMaterialFor(new[] { "type 2", "other type" });
            Assert.That(material, Is.EqualTo(String.Empty));
        }

        [Test]
        public void IfMoreThanOneAllowedMaterial_ThenDiceRollToDetermineWhich()
        {
            materials.Add("special material 1", new[] { "type" });
            materials.Add("special material 2", new[] { "type" });
            mockDice.Setup(d => d.Roll("1d2-1")).Returns(0);

            var material = materialsProvider.GetSpecialMaterialFor(new[] { "type" });
            Assert.That(material, Is.EqualTo("special material 1"));

            mockDice.Setup(d => d.Roll("1d2-1")).Returns(1);

            material = materialsProvider.GetSpecialMaterialFor(new[] { "type" });
            Assert.That(material, Is.EqualTo("special material 2"));
        }

        [Test]
        public void IfNoAllowedMaterial_ReturnEmptyString()
        {
            var material = materialsProvider.GetSpecialMaterialFor(new[] { "type" });
            Assert.That(material, Is.Empty);
        }
    }
}