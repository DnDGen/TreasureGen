using System;
using EquipmentGen.Common.Items;
using NUnit.Framework;

namespace EquipmentGen.Tests.Unit.Common.Items
{
    [TestFixture]
    public class RingConstantsTests
    {
        [TestCase(RingConstants.AnimalFriendship, "Ring of Animal friendship")]
        [TestCase(RingConstants.Blinking, "Ring of Blinking")]
        [TestCase(RingConstants.ChameleonPower, "Ring of Chameleon power")]
        [TestCase(RingConstants.Climbing, "Ring of Climbing")]
        [TestCase(RingConstants.Climbing_Improved, "Ring of Improved climbing")]
        [TestCase(RingConstants.Clumsiness, "Ring of Clumsiness")]
        [TestCase(RingConstants.Counterspells, "Ring of Counterspells")]
        [TestCase(RingConstants.DjinniCalling, "Ring of Djinni calling")]
        [TestCase(RingConstants.ElementalCommand_Air, "Ring of Elemental command (air)")]
        [TestCase(RingConstants.ElementalCommand_Earth, "Ring of Elemental command (earth)")]
        [TestCase(RingConstants.ElementalCommand_Fire, "Ring of Elemental command (fire)")]
        [TestCase(RingConstants.ElementalCommand_Water, "Ring of Elemental command (water)")]
        [TestCase(RingConstants.ENERGYResistance_Greater, "Ring of Greater ENERGY resistance")]
        [TestCase(RingConstants.ENERGYResistance_Major, "Ring of Major ENERGY resistance")]
        [TestCase(RingConstants.ENERGYResistance_Minor, "Ring of Minor ENERGY resistance")]
        [TestCase(RingConstants.AcidResistance_Greater, "Ring of Greater Acid resistance")]
        [TestCase(RingConstants.AcidResistance_Major, "Ring of Major Acid resistance")]
        [TestCase(RingConstants.AcidResistance_Minor, "Ring of Minor Acid resistance")]
        [TestCase(RingConstants.ColdResistance_Greater, "Ring of Greater Cold resistance")]
        [TestCase(RingConstants.ColdResistance_Major, "Ring of Major Cold resistance")]
        [TestCase(RingConstants.ColdResistance_Minor, "Ring of Minor Cold resistance")]
        [TestCase(RingConstants.FireResistance_Greater, "Ring of Greater Fire resistance")]
        [TestCase(RingConstants.FireResistance_Major, "Ring of Major Fire resistance")]
        [TestCase(RingConstants.FireResistance_Minor, "Ring of Minor Fire resistance")]
        [TestCase(RingConstants.ElectricityResistance_Greater, "Ring of Greater Electricity resistance")]
        [TestCase(RingConstants.ElectricityResistance_Major, "Ring of Major Electricity resistance")]
        [TestCase(RingConstants.ElectricityResistance_Minor, "Ring of Minor Electricity resistance")]
        [TestCase(RingConstants.SonicResistance_Greater, "Ring of Greater Sonic resistance")]
        [TestCase(RingConstants.SonicResistance_Major, "Ring of Major Sonic resistance")]
        [TestCase(RingConstants.SonicResistance_Minor, "Ring of Minor Sonic resistance")]
        [TestCase(RingConstants.Evasion, "Ring of Evasion")]
        [TestCase(RingConstants.FeatherFalling, "Ring of Feather falling")]
        [TestCase(RingConstants.ForceShield, "Ring of Force shield")]
        [TestCase(RingConstants.FreedomOfMovement, "Ring of Freedom of movement")]
        [TestCase(RingConstants.FriendShield, "Ring of Friend shield (pair)")]
        [TestCase(RingConstants.Invisibility, "Ring of Invisibility")]
        [TestCase(RingConstants.Jumping, "Ring of Jumping")]
        [TestCase(RingConstants.Jumping_Improved, "Ring of Improved jumping")]
        [TestCase(RingConstants.MindShielding, "Ring of Mind shielding")]
        [TestCase(RingConstants.Protection, "Ring of Protection")]
        [TestCase(RingConstants.Ram, "Ring of Ram")]
        [TestCase(RingConstants.Regeneration, "Ring of Regeneration")]
        [TestCase(RingConstants.ShootingStars, "Ring of Shooting stars")]
        [TestCase(RingConstants.SpellStoring, "Ring of Spell storing")]
        [TestCase(RingConstants.SpellStoring_Major, "Ring of Major spell storing")]
        [TestCase(RingConstants.SpellStoring_Minor, "Ring of Minor spell storing")]
        [TestCase(RingConstants.SpellTurning, "Ring of Spell turning")]
        [TestCase(RingConstants.Sustenance, "Ring of Sustenance")]
        [TestCase(RingConstants.Swimming, "Ring of Swimming")]
        [TestCase(RingConstants.Swimming_Improved, "Ring of Improved swimming")]
        [TestCase(RingConstants.Telekinesis, "Ring of Telekinesis")]
        [TestCase(RingConstants.ThreeWishes, "Ring of Three wishes")]
        [TestCase(RingConstants.WaterWalking, "Ring of Water walking")]
        [TestCase(RingConstants.Wizardry_I, "Ring of Wizardry (I)")]
        [TestCase(RingConstants.Wizardry_II, "Ring of Wizardry (II)")]
        [TestCase(RingConstants.Wizardry_III, "Ring of Wizardry (III)")]
        [TestCase(RingConstants.Wizardry_IV, "Ring of Wizardry (IV)")]
        [TestCase(RingConstants.XRayVision, "Ring of X-ray vision")]
        public void Constant(String constant, String value)
        {
            Assert.That(constant, Is.EqualTo(value));
        }
    }
}