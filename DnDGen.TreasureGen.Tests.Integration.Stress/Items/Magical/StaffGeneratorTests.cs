using DnDGen.TreasureGen.Items;
using DnDGen.TreasureGen.Items.Magical;
using NUnit.Framework;
using System.Collections.Generic;

namespace DnDGen.TreasureGen.Tests.Integration.Stress.Items.Magical
{
    [TestFixture]
    public class StaffGeneratorTests : MagicalItemGeneratorStressTests
    {
        protected override bool allowMinor
        {
            get { return false; }
        }

        protected override string itemType
        {
            get { return ItemTypeConstants.Staff; }
        }

        [Test]
        public void StressStaff()
        {
            stressor.Stress(GenerateAndAssertItem);
        }

        protected override IEnumerable<string> GetItemNames()
        {
            return StaffConstants.GetAllStaffs();
        }

        [Test]
        public void StressCustomStaff()
        {
            stressor.Stress(GenerateAndAssertCustomItem);
        }

        protected override void MakeSpecificAssertionsAgainst(Item staff)
        {
            Assert.That(staff.Name, Does.StartWith("Staff of "));
            Assert.That(staff.Attributes, Contains.Item(AttributeConstants.Charged), staff.Name);

            if (staff is Weapon)
            {
                Assert.That(staff.Attributes, Is.All.Not.EqualTo(AttributeConstants.OneTimeUse), staff.Name);
            }
            else
            {
                Assert.That(staff.Attributes, Contains.Item(AttributeConstants.OneTimeUse), staff.Name);
                Assert.That(staff.Magic.Intelligence.Ego, Is.EqualTo(0), staff.Name);
            }

            Assert.That(staff.IsMagical, Is.True, staff.Name);
            Assert.That(staff.ItemType, Is.EqualTo(ItemTypeConstants.Staff), staff.Name);
            Assert.That(staff.Magic.Bonus, Is.Not.Negative, staff.Name);
            Assert.That(staff.Magic.Charges, Is.Positive, staff.Name);
            Assert.That(staff.Magic.Curse, Is.Not.Null, staff.Name);
            Assert.That(staff.Quantity, Is.EqualTo(1), staff.Name);
            Assert.That(staff.Traits, Is.Not.Null, staff.Name);
        }

        [Test]
        public void StressStaffFromName()
        {
            stressor.Stress(GenerateAndAssertItemFromName);
        }
    }
}