using DnDGen.EventGen;
using DnDGen.TreasureGen.Items;
using DnDGen.TreasureGen.Items.Magical;
using DnDGen.TreasureGen.Tests.Unit.Generators.Items;
using Ninject;
using NUnit.Framework;
using System;

namespace DnDGen.TreasureGen.Tests.Integration.Generators.Items.Magical
{
    [TestFixture]
    public class RingGeneratorTests : IntegrationTests
    {
        [Inject, Named(ItemTypeConstants.Ring)]
        public MagicalItemGenerator RingGenerator { get; set; }
        [Inject]
        public ClientIDManager ClientIDManager { get; set; }

        private ItemVerifier itemVerifier;

        [SetUp]
        public void Setup()
        {
            itemVerifier = new ItemVerifier();
            ClientIDManager.SetClientID(Guid.NewGuid());
        }

        [TestCase(RingConstants.AcidResistance_Greater, PowerConstants.Major)]
        [TestCase(RingConstants.AcidResistance_Major, PowerConstants.Medium)]
        [TestCase(RingConstants.AcidResistance_Minor, PowerConstants.Minor)]
        [TestCase(RingConstants.AcidResistance_Minor, PowerConstants.Medium)]
        [TestCase(RingConstants.AcidResistance_Minor, PowerConstants.Major)]
        [TestCase(RingConstants.AnimalFriendship, PowerConstants.Minor)]
        [TestCase(RingConstants.AnimalFriendship, PowerConstants.Medium)]
        [TestCase(RingConstants.Blinking, PowerConstants.Medium)]
        [TestCase(RingConstants.Blinking, PowerConstants.Major)]
        [TestCase(RingConstants.ChameleonPower, PowerConstants.Minor)]
        [TestCase(RingConstants.ChameleonPower, PowerConstants.Medium)]
        [TestCase(RingConstants.Climbing, PowerConstants.Minor)]
        [TestCase(RingConstants.Climbing_Improved, PowerConstants.Medium)]
        [TestCase(RingConstants.Clumsiness, PowerConstants.Minor)]
        [TestCase(RingConstants.Clumsiness, PowerConstants.Medium)]
        [TestCase(RingConstants.Clumsiness, PowerConstants.Major)]
        [TestCase(RingConstants.ColdResistance_Greater, PowerConstants.Major)]
        [TestCase(RingConstants.ColdResistance_Major, PowerConstants.Medium)]
        [TestCase(RingConstants.ColdResistance_Minor, PowerConstants.Minor)]
        [TestCase(RingConstants.ColdResistance_Minor, PowerConstants.Medium)]
        [TestCase(RingConstants.ColdResistance_Minor, PowerConstants.Major)]
        [TestCase(RingConstants.Counterspells, PowerConstants.Minor)]
        [TestCase(RingConstants.Counterspells, PowerConstants.Medium)]
        [TestCase(RingConstants.DjinniCalling, PowerConstants.Major)]
        [TestCase(RingConstants.ElectricityResistance_Greater, PowerConstants.Major)]
        [TestCase(RingConstants.ElectricityResistance_Major, PowerConstants.Medium)]
        [TestCase(RingConstants.ElectricityResistance_Minor, PowerConstants.Minor)]
        [TestCase(RingConstants.ElectricityResistance_Minor, PowerConstants.Medium)]
        [TestCase(RingConstants.ElectricityResistance_Minor, PowerConstants.Major)]
        [TestCase(RingConstants.ElementalCommand_Air, PowerConstants.Major)]
        [TestCase(RingConstants.ElementalCommand_Earth, PowerConstants.Major)]
        [TestCase(RingConstants.ElementalCommand_Fire, PowerConstants.Major)]
        [TestCase(RingConstants.ElementalCommand_Water, PowerConstants.Major)]
        [TestCase(RingConstants.ENERGYResistance_Greater, PowerConstants.Major)]
        [TestCase(RingConstants.ENERGYResistance_Major, PowerConstants.Medium)]
        [TestCase(RingConstants.ENERGYResistance_Minor, PowerConstants.Minor)]
        [TestCase(RingConstants.ENERGYResistance_Minor, PowerConstants.Medium)]
        [TestCase(RingConstants.ENERGYResistance_Minor, PowerConstants.Major)]
        [TestCase(RingConstants.FeatherFalling, PowerConstants.Minor)]
        [TestCase(RingConstants.FireResistance_Greater, PowerConstants.Major)]
        [TestCase(RingConstants.FireResistance_Major, PowerConstants.Medium)]
        [TestCase(RingConstants.FireResistance_Minor, PowerConstants.Minor)]
        [TestCase(RingConstants.FireResistance_Minor, PowerConstants.Medium)]
        [TestCase(RingConstants.FireResistance_Minor, PowerConstants.Major)]
        [TestCase(RingConstants.ForceShield, PowerConstants.Minor)]
        [TestCase(RingConstants.ForceShield, PowerConstants.Medium)]
        [TestCase(RingConstants.FreedomOfMovement, PowerConstants.Major)]
        [TestCase(RingConstants.FriendShield, PowerConstants.Major)]
        [TestCase(RingConstants.Invisibility, PowerConstants.Medium)]
        [TestCase(RingConstants.Invisibility, PowerConstants.Major)]
        [TestCase(RingConstants.Jumping, PowerConstants.Minor)]
        [TestCase(RingConstants.Jumping_Improved, PowerConstants.Medium)]
        [TestCase(RingConstants.MindShielding, PowerConstants.Minor)]
        [TestCase(RingConstants.MindShielding, PowerConstants.Medium)]
        [TestCase(RingConstants.Protection, PowerConstants.Minor)]
        [TestCase(RingConstants.Protection, PowerConstants.Medium)]
        [TestCase(RingConstants.Protection, PowerConstants.Major)]
        [TestCase(RingConstants.Ram, PowerConstants.Minor)]
        [TestCase(RingConstants.Ram, PowerConstants.Medium)]
        [TestCase(RingConstants.Regeneration, PowerConstants.Major)]
        [TestCase(RingConstants.ShootingStars, PowerConstants.Major)]
        [TestCase(RingConstants.SonicResistance_Greater, PowerConstants.Major)]
        [TestCase(RingConstants.SonicResistance_Major, PowerConstants.Medium)]
        [TestCase(RingConstants.SonicResistance_Minor, PowerConstants.Minor)]
        [TestCase(RingConstants.SonicResistance_Minor, PowerConstants.Medium)]
        [TestCase(RingConstants.SonicResistance_Minor, PowerConstants.Major)]
        [TestCase(RingConstants.SpellStoring, PowerConstants.Major)]
        [TestCase(RingConstants.SpellStoring_Major, PowerConstants.Major)]
        [TestCase(RingConstants.SpellStoring_Minor, PowerConstants.Medium)]
        [TestCase(RingConstants.SpellStoring_Minor, PowerConstants.Major)]
        [TestCase(RingConstants.SpellTurning, PowerConstants.Major)]
        [TestCase(RingConstants.Sustenance, PowerConstants.Minor)]
        [TestCase(RingConstants.Swimming, PowerConstants.Minor)]
        [TestCase(RingConstants.Swimming_Improved, PowerConstants.Medium)]
        [TestCase(RingConstants.Telekinesis, PowerConstants.Major)]
        [TestCase(RingConstants.ThreeWishes, PowerConstants.Major)]
        [TestCase(RingConstants.WaterWalking, PowerConstants.Minor)]
        [TestCase(RingConstants.WaterWalking, PowerConstants.Medium)]
        [TestCase(RingConstants.Wizardry_I, PowerConstants.Medium)]
        [TestCase(RingConstants.Wizardry_I, PowerConstants.Major)]
        [TestCase(RingConstants.Wizardry_II, PowerConstants.Major)]
        [TestCase(RingConstants.Wizardry_III, PowerConstants.Major)]
        [TestCase(RingConstants.Wizardry_IV, PowerConstants.Major)]
        [TestCase(RingConstants.XRayVision, PowerConstants.Medium)]
        [TestCase(RingConstants.XRayVision, PowerConstants.Major)]
        public void GenerateRing(string itemName, string power)
        {
            var isOfPower = RingGenerator.IsItemOfPower(itemName, power);
            Assert.That(isOfPower, Is.True);

            var item = RingGenerator.Generate(power, itemName);
            itemVerifier.AssertItem(item);
        }

        [Test]
        public void AllRingsCanBeGenerated()
        {
            var rings = RingConstants.GetAllRings();

            foreach (var ring in rings)
            {
                var isMinor = RingGenerator.IsItemOfPower(ring, PowerConstants.Minor);
                var isMedium = RingGenerator.IsItemOfPower(ring, PowerConstants.Medium);
                var isMajor = RingGenerator.IsItemOfPower(ring, PowerConstants.Major);

                Assert.That(true, Is.EqualTo(isMinor)
                    .Or.EqualTo(isMedium)
                    .Or.EqualTo(isMajor), ring);
            }
        }
    }
}
