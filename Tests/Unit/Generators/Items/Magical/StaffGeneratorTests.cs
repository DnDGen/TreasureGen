using Moq;
using NUnit.Framework;
using System;
using System.Linq;
using TreasureGen.Common.Items;
using TreasureGen.Generators.Domain.Items.Magical;
using TreasureGen.Generators.Items.Magical;
using TreasureGen.Selectors;
using TreasureGen.Tables;

namespace TreasureGen.Tests.Unit.Generators.Items.Magical
{
    [TestFixture]
    public class StaffGeneratorTests
    {
        private IMagicalItemGenerator staffGenerator;
        private Mock<IChargesGenerator> mockChargesGenerator;
        private Mock<IPercentileSelector> mockPercentileSelector;
        private Mock<IAttributesSelector> mockAttributesSelector;
        private String power;

        [SetUp]
        public void Setup()
        {
            mockPercentileSelector = new Mock<IPercentileSelector>();
            mockChargesGenerator = new Mock<IChargesGenerator>();
            mockAttributesSelector = new Mock<IAttributesSelector>();
            staffGenerator = new StaffGenerator(mockPercentileSelector.Object, mockChargesGenerator.Object, mockAttributesSelector.Object);
            power = "power";
        }

        [Test]
        public void GenerateStaff()
        {
            var staff = staffGenerator.GenerateAtPower(power);
            Assert.That(staff.ItemType, Is.EqualTo(ItemTypeConstants.Staff));
            Assert.That(staff.Attributes, Contains.Item(AttributeConstants.Charged));
            Assert.That(staff.Attributes, Contains.Item(AttributeConstants.OneTimeUse));
            Assert.That(staff.Attributes.Count(), Is.EqualTo(2));
            Assert.That(staff.Magic.Bonus, Is.EqualTo(0));
        }

        [Test]
        public void CannotGenerateMinorStaves()
        {
            Assert.That(() => staffGenerator.GenerateAtPower(PowerConstants.Minor), Throws.ArgumentException.With.Message.EqualTo("Cannot generate minor staves"));
        }

        [Test]
        public void GetKindOfStaffFromSelector()
        {
            var tableName = String.Format(TableNameConstants.Percentiles.Formattable.POWERITEMTYPEs, power, ItemTypeConstants.Staff);
            mockPercentileSelector.Setup(s => s.SelectFrom(tableName)).Returns("staffiness");

            var staff = staffGenerator.GenerateAtPower(power);
            Assert.That(staff.Name, Is.EqualTo("staffiness"));
        }

        [Test]
        public void GetChargesFromGenerator()
        {
            var tableName = String.Format(TableNameConstants.Percentiles.Formattable.POWERITEMTYPEs, power, ItemTypeConstants.Staff);
            mockPercentileSelector.Setup(s => s.SelectFrom(tableName)).Returns("staffiness");
            mockChargesGenerator.Setup(g => g.GenerateFor(ItemTypeConstants.Staff, "staffiness")).Returns(9266);

            var staff = staffGenerator.GenerateAtPower(power);
            Assert.That(staff.Magic.Charges, Is.EqualTo(9266));
        }

        [Test]
        public void StaffOfPowerHasBonusOf2()
        {
            var tableName = String.Format(TableNameConstants.Percentiles.Formattable.POWERITEMTYPEs, power, ItemTypeConstants.Staff);
            mockPercentileSelector.Setup(s => s.SelectFrom(tableName)).Returns(StaffConstants.Power);

            var staff = staffGenerator.GenerateAtPower(power);
            Assert.That(staff.Magic.Bonus, Is.EqualTo(2));
        }

        [Test]
        public void StaffOfPowerHasQuarterstaffAttributes()
        {
            var tableName = String.Format(TableNameConstants.Percentiles.Formattable.POWERITEMTYPEs, power, ItemTypeConstants.Staff);
            mockPercentileSelector.Setup(s => s.SelectFrom(tableName)).Returns(StaffConstants.Power);

            var attributes = new[] { "attribute 1", "attribute 2" };
            tableName = String.Format(TableNameConstants.Attributes.Formattable.ITEMTYPEAttributes, ItemTypeConstants.Weapon);
            mockAttributesSelector.Setup(s => s.SelectFrom(tableName, WeaponConstants.Quarterstaff)).Returns(attributes);

            var staff = staffGenerator.GenerateAtPower(power);
            foreach (var attribute in attributes)
                Assert.That(staff.Attributes, Contains.Item(attribute));
        }
    }
}