using DnDGen.TreasureGen.Items.Magical;
using NUnit.Framework;
using System.Linq;

namespace DnDGen.TreasureGen.Tests.Unit.Generators.Items.Magical
{
    [TestFixture]
    public class RodConstantsTests
    {
        [TestCase(RodConstants.Absorption, "Rod of Absorption")]
        [TestCase(RodConstants.Absorption_Full, "Rod of Absorption (max)")]
        [TestCase(RodConstants.Alertness, "Rod of Alertness")]
        [TestCase(RodConstants.Cancellation, "Rod of Cancellation")]
        [TestCase(RodConstants.EnemyDetection, "Rod of Enemy Detection")]
        [TestCase(RodConstants.Flailing, "Rod of Flailing")]
        [TestCase(RodConstants.FlameExtinguishing, "Rod of Flame Extinguishing")]
        [TestCase(RodConstants.ImmovableRod, "Immovable Rod")]
        [TestCase(RodConstants.LordlyMight, "Rod of Lordly Might")]
        [TestCase(RodConstants.MetalAndMineralDetection, "Rod of Metal and Mineral Detection")]
        [TestCase(RodConstants.Metamagic_Empower, "Rod of Metamagic: Empower")]
        [TestCase(RodConstants.Metamagic_Empower_Greater, "Rod of Greater Metamagic: Empower")]
        [TestCase(RodConstants.Metamagic_Empower_Lesser, "Rod of Lesser Metamagic: Empower")]
        [TestCase(RodConstants.Metamagic_Enlarge, "Rod of Metamagic: Enlarge")]
        [TestCase(RodConstants.Metamagic_Enlarge_Greater, "Rod of Greater Metamagic: Enlarge")]
        [TestCase(RodConstants.Metamagic_Enlarge_Lesser, "Rod of Lesser Metamagic: Enlarge")]
        [TestCase(RodConstants.Metamagic_Extend, "Rod of Metamagic: Extend")]
        [TestCase(RodConstants.Metamagic_Extend_Greater, "Rod of Greater Metamagic: Extend")]
        [TestCase(RodConstants.Metamagic_Extend_Lesser, "Rod of Lesser Metamagic: Extend")]
        [TestCase(RodConstants.Metamagic_Maximize, "Rod of Metamagic: Maximize")]
        [TestCase(RodConstants.Metamagic_Maximize_Greater, "Rod of Greater Metamagic: Maximize")]
        [TestCase(RodConstants.Metamagic_Maximize_Lesser, "Rod of Lesser Metamagic: Maximize")]
        [TestCase(RodConstants.Metamagic_Quicken, "Rod of Metamagic: Quicken")]
        [TestCase(RodConstants.Metamagic_Quicken_Greater, "Rod of Greater Metamagic: Quicken")]
        [TestCase(RodConstants.Metamagic_Quicken_Lesser, "Rod of Lesser Metamagic: Quicken")]
        [TestCase(RodConstants.Metamagic_Silent, "Rod of Metamagic: Silent")]
        [TestCase(RodConstants.Metamagic_Silent_Greater, "Rod of Greater Metamagic: Silent")]
        [TestCase(RodConstants.Metamagic_Silent_Lesser, "Rod of Lesser Metamagic: Silent")]
        [TestCase(RodConstants.Negation, "Rod of Negation")]
        [TestCase(RodConstants.Python, "Rod of the Python")]
        [TestCase(RodConstants.Rulership, "Rod of Rulership")]
        [TestCase(RodConstants.Security, "Rod of Security")]
        [TestCase(RodConstants.Splendor, "Rod of Splendor")]
        [TestCase(RodConstants.ThunderAndLightning, "Rod of Thunder and Lightning")]
        [TestCase(RodConstants.Viper, "Rod of the Viper")]
        [TestCase(RodConstants.Withering, "Rod of Withering")]
        [TestCase(RodConstants.Wonder, "Rod of Wonder")]
        public void Constant(string constant, string value)
        {
            Assert.That(constant, Is.EqualTo(value));
        }

        [Test]
        public void AllRods()
        {
            var rods = RodConstants.GetAllRods();

            Assert.That(rods, Contains.Item(RodConstants.Absorption));
            Assert.That(rods, Contains.Item(RodConstants.Alertness));
            Assert.That(rods, Contains.Item(RodConstants.Cancellation));
            Assert.That(rods, Contains.Item(RodConstants.EnemyDetection));
            Assert.That(rods, Contains.Item(RodConstants.Flailing));
            Assert.That(rods, Contains.Item(RodConstants.FlameExtinguishing));
            Assert.That(rods, Contains.Item(RodConstants.ImmovableRod));
            Assert.That(rods, Contains.Item(RodConstants.LordlyMight));
            Assert.That(rods, Contains.Item(RodConstants.MetalAndMineralDetection));
            Assert.That(rods, Contains.Item(RodConstants.Metamagic_Empower));
            Assert.That(rods, Contains.Item(RodConstants.Metamagic_Empower_Greater));
            Assert.That(rods, Contains.Item(RodConstants.Metamagic_Empower_Lesser));
            Assert.That(rods, Contains.Item(RodConstants.Metamagic_Enlarge));
            Assert.That(rods, Contains.Item(RodConstants.Metamagic_Enlarge_Greater));
            Assert.That(rods, Contains.Item(RodConstants.Metamagic_Enlarge_Lesser));
            Assert.That(rods, Contains.Item(RodConstants.Metamagic_Extend));
            Assert.That(rods, Contains.Item(RodConstants.Metamagic_Extend_Greater));
            Assert.That(rods, Contains.Item(RodConstants.Metamagic_Extend_Lesser));
            Assert.That(rods, Contains.Item(RodConstants.Metamagic_Maximize));
            Assert.That(rods, Contains.Item(RodConstants.Metamagic_Maximize_Greater));
            Assert.That(rods, Contains.Item(RodConstants.Metamagic_Maximize_Lesser));
            Assert.That(rods, Contains.Item(RodConstants.Metamagic_Quicken));
            Assert.That(rods, Contains.Item(RodConstants.Metamagic_Quicken_Greater));
            Assert.That(rods, Contains.Item(RodConstants.Metamagic_Quicken_Lesser));
            Assert.That(rods, Contains.Item(RodConstants.Metamagic_Silent));
            Assert.That(rods, Contains.Item(RodConstants.Metamagic_Silent_Greater));
            Assert.That(rods, Contains.Item(RodConstants.Metamagic_Silent_Lesser));
            Assert.That(rods, Contains.Item(RodConstants.Negation));
            Assert.That(rods, Contains.Item(RodConstants.Python));
            Assert.That(rods, Contains.Item(RodConstants.Rulership));
            Assert.That(rods, Contains.Item(RodConstants.Splendor));
            Assert.That(rods, Contains.Item(RodConstants.Security));
            Assert.That(rods, Contains.Item(RodConstants.ThunderAndLightning));
            Assert.That(rods, Contains.Item(RodConstants.Viper));
            Assert.That(rods, Contains.Item(RodConstants.Withering));
            Assert.That(rods, Contains.Item(RodConstants.Wonder));
            Assert.That(rods.Count(), Is.EqualTo(36));


        }
    }
}