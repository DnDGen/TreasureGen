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
    public class StaffGeneratorTests : IntegrationTests
    {
        [Inject, Named(ItemTypeConstants.Staff)]
        public MagicalItemGenerator StaffGenerator { get; set; }
        [Inject]
        public ClientIDManager ClientIDManager { get; set; }

        private ItemVerifier itemVerifier;

        [SetUp]
        public void Setup()
        {
            itemVerifier = new ItemVerifier();
            ClientIDManager.SetClientID(Guid.NewGuid());
        }

        [TestCase(StaffConstants.Abjuration, PowerConstants.Medium)]
        [TestCase(StaffConstants.Abjuration, PowerConstants.Major)]
        [TestCase(StaffConstants.Charming, PowerConstants.Medium)]
        [TestCase(StaffConstants.Charming, PowerConstants.Major)]
        [TestCase(StaffConstants.Conjuration, PowerConstants.Medium)]
        [TestCase(StaffConstants.Conjuration, PowerConstants.Major)]
        [TestCase(StaffConstants.Defense, PowerConstants.Medium)]
        [TestCase(StaffConstants.Defense, PowerConstants.Major)]
        [TestCase(StaffConstants.Divination, PowerConstants.Medium)]
        [TestCase(StaffConstants.Divination, PowerConstants.Major)]
        [TestCase(StaffConstants.EarthAndStone, PowerConstants.Medium)]
        [TestCase(StaffConstants.EarthAndStone, PowerConstants.Major)]
        [TestCase(StaffConstants.Enchantment, PowerConstants.Medium)]
        [TestCase(StaffConstants.Enchantment, PowerConstants.Major)]
        [TestCase(StaffConstants.Evocation, PowerConstants.Medium)]
        [TestCase(StaffConstants.Evocation, PowerConstants.Major)]
        [TestCase(StaffConstants.Fire, PowerConstants.Medium)]
        [TestCase(StaffConstants.Fire, PowerConstants.Major)]
        [TestCase(StaffConstants.Frost, PowerConstants.Medium)]
        [TestCase(StaffConstants.Frost, PowerConstants.Major)]
        [TestCase(StaffConstants.Healing, PowerConstants.Medium)]
        [TestCase(StaffConstants.Healing, PowerConstants.Major)]
        [TestCase(StaffConstants.Illumination, PowerConstants.Medium)]
        [TestCase(StaffConstants.Illumination, PowerConstants.Major)]
        [TestCase(StaffConstants.Illusion, PowerConstants.Medium)]
        [TestCase(StaffConstants.Illusion, PowerConstants.Major)]
        [TestCase(StaffConstants.Life, PowerConstants.Medium)]
        [TestCase(StaffConstants.Life, PowerConstants.Major)]
        [TestCase(StaffConstants.Necromancy, PowerConstants.Medium)]
        [TestCase(StaffConstants.Necromancy, PowerConstants.Major)]
        [TestCase(StaffConstants.Passage, PowerConstants.Medium)]
        [TestCase(StaffConstants.Passage, PowerConstants.Major)]
        [TestCase(StaffConstants.Power, PowerConstants.Medium)]
        [TestCase(StaffConstants.Power, PowerConstants.Major)]
        [TestCase(StaffConstants.SizeAlteration, PowerConstants.Medium)]
        [TestCase(StaffConstants.SizeAlteration, PowerConstants.Major)]
        [TestCase(StaffConstants.SwarmingInsects, PowerConstants.Medium)]
        [TestCase(StaffConstants.SwarmingInsects, PowerConstants.Major)]
        [TestCase(StaffConstants.Transmutation, PowerConstants.Medium)]
        [TestCase(StaffConstants.Transmutation, PowerConstants.Major)]
        [TestCase(StaffConstants.Woodlands, PowerConstants.Medium)]
        [TestCase(StaffConstants.Woodlands, PowerConstants.Major)]
        public void GenerateStaff(string itemName, string power)
        {
            var isOfPower = StaffGenerator.IsItemOfPower(itemName, power);
            Assert.That(isOfPower, Is.True);

            var item = StaffGenerator.GenerateFrom(power, itemName);
            itemVerifier.AssertItem(item);
        }
    }
}
