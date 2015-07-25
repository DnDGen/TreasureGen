using System;
using TreasureGen.Common.Items;
using NUnit.Framework;

namespace TreasureGen.Tests.Unit.Common.Items
{
    [TestFixture]
    public class StaffConstantsTests
    {
        [TestCase(StaffConstants.Charming, "Staff of Charming")]
        [TestCase(StaffConstants.Fire, "Staff of Fire")]
        [TestCase(StaffConstants.SwarmingInsects, "Staff of Swarming insects")]
        [TestCase(StaffConstants.Healing, "Staff of Healing")]
        [TestCase(StaffConstants.SizeAlteration, "Staff of Size alteration")]
        [TestCase(StaffConstants.Illumination, "Staff of Illumination")]
        [TestCase(StaffConstants.Frost, "Staff of Frost")]
        [TestCase(StaffConstants.Defense, "Staff of Defense")]
        [TestCase(StaffConstants.Abjuration, "Staff of Abjuration")]
        [TestCase(StaffConstants.Conjuration, "Staff of Conjuration")]
        [TestCase(StaffConstants.Enchantment, "Staff of Enchantment")]
        [TestCase(StaffConstants.Evocation, "Staff of Evocation")]
        [TestCase(StaffConstants.Illusion, "Staff of Illusion")]
        [TestCase(StaffConstants.Necromancy, "Staff of Necromancy")]
        [TestCase(StaffConstants.Transmutation, "Staff of Transmutation")]
        [TestCase(StaffConstants.Divination, "Staff of Divination")]
        [TestCase(StaffConstants.EarthAndStone, "Staff of Earth and stone")]
        [TestCase(StaffConstants.Woodlands, "Staff of Woodlands")]
        [TestCase(StaffConstants.Life, "Staff of Life")]
        [TestCase(StaffConstants.Passage, "Staff of Passage")]
        [TestCase(StaffConstants.Power, "Staff of Power")]
        public void Constant(String constant, String value)
        {
            Assert.That(constant, Is.EqualTo(value));
        }
    }
}