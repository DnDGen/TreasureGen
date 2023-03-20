using DnDGen.TreasureGen.Items.Magical;
using NUnit.Framework;
using System.Linq;

namespace DnDGen.TreasureGen.Tests.Unit.Generators.Items.Magical
{
    [TestFixture]
    public class RingConstantsTests
    {
        [TestCase(RingConstants.AnimalFriendship, "Ring of Animal Friendship")]
        [TestCase(RingConstants.Blinking, "Ring of Blinking")]
        [TestCase(RingConstants.ChameleonPower, "Ring of Chameleon Power")]
        [TestCase(RingConstants.Climbing, "Ring of Climbing")]
        [TestCase(RingConstants.Climbing_Improved, "Ring of Improved Climbing")]
        [TestCase(RingConstants.Clumsiness, "Ring of Clumsiness")]
        [TestCase(RingConstants.Counterspells, "Ring of Counterspells")]
        [TestCase(RingConstants.DjinniCalling, "Ring of Djinni Calling")]
        [TestCase(RingConstants.ElementalCommand_Air, "Ring of Elemental Command (Air)")]
        [TestCase(RingConstants.ElementalCommand_Earth, "Ring of Elemental Command (Earth)")]
        [TestCase(RingConstants.ElementalCommand_Fire, "Ring of Elemental Command (Fire)")]
        [TestCase(RingConstants.ElementalCommand_Water, "Ring of Elemental Command (Water)")]
        [TestCase(RingConstants.ENERGYResistance_Greater, "Ring of Greater ENERGY Resistance")]
        [TestCase(RingConstants.ENERGYResistance_Major, "Ring of Major ENERGY Resistance")]
        [TestCase(RingConstants.ENERGYResistance_Minor, "Ring of Minor ENERGY Resistance")]
        [TestCase(RingConstants.AcidResistance_Greater, "Ring of Greater Acid Resistance")]
        [TestCase(RingConstants.AcidResistance_Major, "Ring of Major Acid Resistance")]
        [TestCase(RingConstants.AcidResistance_Minor, "Ring of Minor Acid Resistance")]
        [TestCase(RingConstants.ColdResistance_Greater, "Ring of Greater Cold Resistance")]
        [TestCase(RingConstants.ColdResistance_Major, "Ring of Major Cold Resistance")]
        [TestCase(RingConstants.ColdResistance_Minor, "Ring of Minor Cold Resistance")]
        [TestCase(RingConstants.FireResistance_Greater, "Ring of Greater Fire Resistance")]
        [TestCase(RingConstants.FireResistance_Major, "Ring of Major Fire Resistance")]
        [TestCase(RingConstants.FireResistance_Minor, "Ring of Minor Fire Resistance")]
        [TestCase(RingConstants.ElectricityResistance_Greater, "Ring of Greater Electricity Resistance")]
        [TestCase(RingConstants.ElectricityResistance_Major, "Ring of Major Electricity Resistance")]
        [TestCase(RingConstants.ElectricityResistance_Minor, "Ring of Minor Electricity Resistance")]
        [TestCase(RingConstants.SonicResistance_Greater, "Ring of Greater Sonic Resistance")]
        [TestCase(RingConstants.SonicResistance_Major, "Ring of Major Sonic Resistance")]
        [TestCase(RingConstants.SonicResistance_Minor, "Ring of Minor Sonic Resistance")]
        [TestCase(RingConstants.Evasion, "Ring of Evasion")]
        [TestCase(RingConstants.FeatherFalling, "Ring of Feather Falling")]
        [TestCase(RingConstants.ForceShield, "Ring of Force Shield")]
        [TestCase(RingConstants.FreedomOfMovement, "Ring of Freedom of Movement")]
        [TestCase(RingConstants.FriendShield, "Ring of Friend Shield (pair)")]
        [TestCase(RingConstants.Invisibility, "Ring of Invisibility")]
        [TestCase(RingConstants.Jumping, "Ring of Jumping")]
        [TestCase(RingConstants.Jumping_Improved, "Ring of Improved Jumping")]
        [TestCase(RingConstants.MindShielding, "Ring of Mind Shielding")]
        [TestCase(RingConstants.Protection, "Ring of Protection")]
        [TestCase(RingConstants.Ram, "Ring of Ram")]
        [TestCase(RingConstants.Regeneration, "Ring of Regeneration")]
        [TestCase(RingConstants.ShootingStars, "Ring of Shooting Stars")]
        [TestCase(RingConstants.SpellStoring, "Ring of Spell Storing")]
        [TestCase(RingConstants.SpellStoring_Major, "Ring of Major Spell Storing")]
        [TestCase(RingConstants.SpellStoring_Minor, "Ring of Minor Spell Storing")]
        [TestCase(RingConstants.SpellTurning, "Ring of Spell Turning")]
        [TestCase(RingConstants.Sustenance, "Ring of Sustenance")]
        [TestCase(RingConstants.Swimming, "Ring of Swimming")]
        [TestCase(RingConstants.Swimming_Improved, "Ring of Improved Swimming")]
        [TestCase(RingConstants.Telekinesis, "Ring of Telekinesis")]
        [TestCase(RingConstants.ThreeWishes, "Ring of Three Wishes")]
        [TestCase(RingConstants.WaterWalking, "Ring of Water Walking")]
        [TestCase(RingConstants.Wizardry_I, "Ring of Wizardry (I)")]
        [TestCase(RingConstants.Wizardry_II, "Ring of Wizardry (II)")]
        [TestCase(RingConstants.Wizardry_III, "Ring of Wizardry (III)")]
        [TestCase(RingConstants.Wizardry_IV, "Ring of Wizardry (IV)")]
        [TestCase(RingConstants.XRayVision, "Ring of X-ray Vision")]
        public void Constant(string constant, string value)
        {
            Assert.That(constant, Is.EqualTo(value));
        }

        [Test]
        public void AllRings()
        {
            var rings = RingConstants.GetAllRings();

            Assert.That(rings, Contains.Item(RingConstants.AcidResistance_Greater));
            Assert.That(rings, Contains.Item(RingConstants.AcidResistance_Major));
            Assert.That(rings, Contains.Item(RingConstants.AcidResistance_Minor));
            Assert.That(rings, Contains.Item(RingConstants.AnimalFriendship));
            Assert.That(rings, Contains.Item(RingConstants.Blinking));
            Assert.That(rings, Contains.Item(RingConstants.ChameleonPower));
            Assert.That(rings, Contains.Item(RingConstants.Climbing));
            Assert.That(rings, Contains.Item(RingConstants.Climbing_Improved));
            Assert.That(rings, Contains.Item(RingConstants.Clumsiness));
            Assert.That(rings, Contains.Item(RingConstants.ColdResistance_Greater));
            Assert.That(rings, Contains.Item(RingConstants.ColdResistance_Major));
            Assert.That(rings, Contains.Item(RingConstants.ColdResistance_Minor));
            Assert.That(rings, Contains.Item(RingConstants.Counterspells));
            Assert.That(rings, Contains.Item(RingConstants.DjinniCalling));
            Assert.That(rings, Contains.Item(RingConstants.ElectricityResistance_Greater));
            Assert.That(rings, Contains.Item(RingConstants.ElectricityResistance_Major));
            Assert.That(rings, Contains.Item(RingConstants.ElectricityResistance_Minor));
            Assert.That(rings, Contains.Item(RingConstants.ElementalCommand_Air));
            Assert.That(rings, Contains.Item(RingConstants.ElementalCommand_Earth));
            Assert.That(rings, Contains.Item(RingConstants.ElementalCommand_Fire));
            Assert.That(rings, Contains.Item(RingConstants.ElementalCommand_Water));
            Assert.That(rings, Contains.Item(RingConstants.Evasion));
            Assert.That(rings, Contains.Item(RingConstants.FeatherFalling));
            Assert.That(rings, Contains.Item(RingConstants.FireResistance_Greater));
            Assert.That(rings, Contains.Item(RingConstants.FireResistance_Major));
            Assert.That(rings, Contains.Item(RingConstants.FireResistance_Minor));
            Assert.That(rings, Contains.Item(RingConstants.ForceShield));
            Assert.That(rings, Contains.Item(RingConstants.FreedomOfMovement));
            Assert.That(rings, Contains.Item(RingConstants.FriendShield));
            Assert.That(rings, Contains.Item(RingConstants.Invisibility));
            Assert.That(rings, Contains.Item(RingConstants.Jumping));
            Assert.That(rings, Contains.Item(RingConstants.Jumping_Improved));
            Assert.That(rings, Contains.Item(RingConstants.MindShielding));
            Assert.That(rings, Contains.Item(RingConstants.Protection));
            Assert.That(rings, Contains.Item(RingConstants.Ram));
            Assert.That(rings, Contains.Item(RingConstants.Regeneration));
            Assert.That(rings, Contains.Item(RingConstants.ShootingStars));
            Assert.That(rings, Contains.Item(RingConstants.SonicResistance_Greater));
            Assert.That(rings, Contains.Item(RingConstants.SonicResistance_Major));
            Assert.That(rings, Contains.Item(RingConstants.SonicResistance_Minor));
            Assert.That(rings, Contains.Item(RingConstants.SpellStoring));
            Assert.That(rings, Contains.Item(RingConstants.SpellStoring_Major));
            Assert.That(rings, Contains.Item(RingConstants.SpellStoring_Minor));
            Assert.That(rings, Contains.Item(RingConstants.SpellTurning));
            Assert.That(rings, Contains.Item(RingConstants.Sustenance));
            Assert.That(rings, Contains.Item(RingConstants.Swimming));
            Assert.That(rings, Contains.Item(RingConstants.Swimming_Improved));
            Assert.That(rings, Contains.Item(RingConstants.ThreeWishes));
            Assert.That(rings, Contains.Item(RingConstants.Telekinesis));
            Assert.That(rings, Contains.Item(RingConstants.WaterWalking));
            Assert.That(rings, Contains.Item(RingConstants.Wizardry_I));
            Assert.That(rings, Contains.Item(RingConstants.Wizardry_II));
            Assert.That(rings, Contains.Item(RingConstants.Wizardry_III));
            Assert.That(rings, Contains.Item(RingConstants.Wizardry_IV));
            Assert.That(rings, Contains.Item(RingConstants.XRayVision));
            Assert.That(rings.Count(), Is.EqualTo(55));
        }
    }
}