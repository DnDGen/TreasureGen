using DnDGen.TreasureGen.Items.Magical;
using NUnit.Framework;
using System.Linq;

namespace DnDGen.TreasureGen.Tests.Unit.Generators.Items.Magical
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
        public void Constant(string constant, string value)
        {
            Assert.That(constant, Is.EqualTo(value));
        }

        [Test]
        public void AllStaffs()
        {
            var staffs = StaffConstants.GetAllStaffs();

            Assert.That(staffs, Contains.Item(StaffConstants.Abjuration));
            Assert.That(staffs, Contains.Item(StaffConstants.Charming));
            Assert.That(staffs, Contains.Item(StaffConstants.Conjuration));
            Assert.That(staffs, Contains.Item(StaffConstants.Defense));
            Assert.That(staffs, Contains.Item(StaffConstants.Divination));
            Assert.That(staffs, Contains.Item(StaffConstants.EarthAndStone));
            Assert.That(staffs, Contains.Item(StaffConstants.Enchantment));
            Assert.That(staffs, Contains.Item(StaffConstants.Evocation));
            Assert.That(staffs, Contains.Item(StaffConstants.Fire));
            Assert.That(staffs, Contains.Item(StaffConstants.Frost));
            Assert.That(staffs, Contains.Item(StaffConstants.Healing));
            Assert.That(staffs, Contains.Item(StaffConstants.Illumination));
            Assert.That(staffs, Contains.Item(StaffConstants.Illusion));
            Assert.That(staffs, Contains.Item(StaffConstants.Life));
            Assert.That(staffs, Contains.Item(StaffConstants.Necromancy));
            Assert.That(staffs, Contains.Item(StaffConstants.Passage));
            Assert.That(staffs, Contains.Item(StaffConstants.Power));
            Assert.That(staffs, Contains.Item(StaffConstants.SizeAlteration));
            Assert.That(staffs, Contains.Item(StaffConstants.SwarmingInsects));
            Assert.That(staffs, Contains.Item(StaffConstants.Transmutation));
            Assert.That(staffs, Contains.Item(StaffConstants.Woodlands));
            Assert.That(staffs.Count(), Is.EqualTo(21));
        }
    }
}