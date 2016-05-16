using NUnit.Framework;
using System;
using TreasureGen.Items.Magical;

namespace TreasureGen.Tests.Unit.Generators.Items.Magical
{
    [TestFixture]
    public class RodConstantsTests
    {
        [TestCase(RodConstants.Absorption, "Rod of absorption")]
        [TestCase(RodConstants.FullAbsorption, "Rod of absorption (max)")]
        [TestCase(RodConstants.Alertness, "Rod of alertness")]
        [TestCase(RodConstants.Cancellation, "Rod of cancellation")]
        [TestCase(RodConstants.EnemyDetection, "Rod of enemy detection")]
        [TestCase(RodConstants.Flailing, "Rod of flailing")]
        [TestCase(RodConstants.FlameExtinguishing, "Rod of flame extinguishing")]
        [TestCase(RodConstants.ImmovableRod, "Immovable rod")]
        [TestCase(RodConstants.LordlyMight, "Rod of lordly might")]
        [TestCase(RodConstants.MetalAndMineralDetection, "Rod of metal and mineral detection")]
        [TestCase(RodConstants.Metamagic_Empower, "Rod of metamagic: Empower")]
        [TestCase(RodConstants.Metamagic_Empower_Greater, "Rod of greater metamagic: Empower")]
        [TestCase(RodConstants.Metamagic_Empower_Lesser, "Rod of lesser metamagic: Empower")]
        [TestCase(RodConstants.Metamagic_Enlarge, "Rod of metamagic: Enlarge")]
        [TestCase(RodConstants.Metamagic_Enlarge_Greater, "Rod of greater metamagic: Enlarge")]
        [TestCase(RodConstants.Metamagic_Enlarge_Lesser, "Rod of lesser metamagic: Enlarge")]
        [TestCase(RodConstants.Metamagic_Extend, "Rod of metamagic: Extend")]
        [TestCase(RodConstants.Metamagic_Extend_Greater, "Rod of greater metamagic: Extend")]
        [TestCase(RodConstants.Metamagic_Extend_Lesser, "Rod of lesser metamagic: Extend")]
        [TestCase(RodConstants.Metamagic_Maximize, "Rod of metamagic: Maximize")]
        [TestCase(RodConstants.Metamagic_Maximize_Greater, "Rod of greater metamagic: Maximize")]
        [TestCase(RodConstants.Metamagic_Maximize_Lesser, "Rod of lesser metamagic: Maximize")]
        [TestCase(RodConstants.Metamagic_Quicken, "Rod of metamagic: Quicken")]
        [TestCase(RodConstants.Metamagic_Quicken_Greater, "Rod of greater metamagic: Quicken")]
        [TestCase(RodConstants.Metamagic_Quicken_Lesser, "Rod of lesser metamagic: Quicken")]
        [TestCase(RodConstants.Metamagic_Silent, "Rod of metamagic: Silent")]
        [TestCase(RodConstants.Metamagic_Silent_Greater, "Rod of greater metamagic: Silent")]
        [TestCase(RodConstants.Metamagic_Silent_Lesser, "Rod of lesser metamagic: Silent")]
        [TestCase(RodConstants.Negation, "Rod of negation")]
        [TestCase(RodConstants.Python, "Rod of the python")]
        [TestCase(RodConstants.Rulership, "Rod of rulership")]
        [TestCase(RodConstants.Security, "Rod of security")]
        [TestCase(RodConstants.Splendor, "Rod of splendor")]
        [TestCase(RodConstants.ThunderAndLightning, "Rod of thunder and lightning")]
        [TestCase(RodConstants.Viper, "Rod of the viper")]
        [TestCase(RodConstants.Withering, "Rod of withering")]
        [TestCase(RodConstants.Wonder, "Rod of wonder")]
        public void Constant(String constant, String value)
        {
            Assert.That(constant, Is.EqualTo(value));
        }
    }
}