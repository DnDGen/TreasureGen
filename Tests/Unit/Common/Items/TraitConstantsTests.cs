using System;
using EquipmentGen.Common.Items;
using NUnit.Framework;

namespace EquipmentGen.Tests.Unit.Common.Items
{
    [TestFixture]
    public class TraitConstantsTests
    {
        [TestCase(TraitConstants.Masterwork, "Masterwork")]
        [TestCase(TraitConstants.Darkwood, "Darkwood")]
        [TestCase(TraitConstants.Small, "Small")]
        [TestCase(TraitConstants.Medium, "Medium")]
        [TestCase(TraitConstants.Adamantine, "Adamantine")]
        [TestCase(TraitConstants.Dragonhide, "Dragonhide")]
        [TestCase(TraitConstants.ColdIron, "Cold iron")]
        [TestCase(TraitConstants.Mithral, "Mithral")]
        [TestCase(TraitConstants.AlchemicalSilver, "Alchemical silver")]
        [TestCase(TraitConstants.Markings, "Markings provide a clue to its function")]
        [TestCase(TraitConstants.ShedsLight, "Sheds light")]
        public void TraitConstantIsCorrect(String constant, String value)
        {
            Assert.That(constant, Is.EqualTo(value));
        }
    }
}