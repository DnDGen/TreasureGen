using NUnit.Framework;
using System;
using System.Linq;
using TreasureGen.Items;

namespace TreasureGen.Tests.Unit.Generators.Items
{
    [TestFixture]
    public class TraitConstantsTests
    {
        [TestCase(TraitConstants.Masterwork, "Masterwork")]
        [TestCase(TraitConstants.Darkwood, "Darkwood")]
        [TestCase(TraitConstants.Small, "Small")]
        [TestCase(TraitConstants.Medium, "Medium")]
        [TestCase(TraitConstants.Large, "Large")]
        [TestCase(TraitConstants.Adamantine, "Adamantine")]
        [TestCase(TraitConstants.Dragonhide, "Dragonhide")]
        [TestCase(TraitConstants.ColdIron, "Cold iron")]
        [TestCase(TraitConstants.Mithral, "Mithral")]
        [TestCase(TraitConstants.AlchemicalSilver, "Alchemical silver")]
        [TestCase(TraitConstants.Markings, "Markings provide a clue to its function")]
        [TestCase(TraitConstants.ShedsLight, "Sheds light")]
        public void Constant(String constant, String value)
        {
            Assert.That(constant, Is.EqualTo(value));
        }

        [Test]
        public void SpecialMaterialsContainAllSpecialMaterials()
        {
            var materials = TraitConstants.GetSpecialMaterials();
            Assert.That(materials, Contains.Item(TraitConstants.Mithral));
            Assert.That(materials, Contains.Item(TraitConstants.Adamantine));
            Assert.That(materials, Contains.Item(TraitConstants.AlchemicalSilver));
            Assert.That(materials, Contains.Item(TraitConstants.Darkwood));
            Assert.That(materials, Contains.Item(TraitConstants.ColdIron));
            Assert.That(materials, Contains.Item(TraitConstants.Dragonhide));
            Assert.That(materials.Count(), Is.EqualTo(6));
        }
    }
}