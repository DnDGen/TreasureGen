using NUnit.Framework;
using System.Collections.Generic;
using TreasureGen.Items;
using TreasureGen.Items.Magical;

namespace TreasureGen.Tests.Integration.Stress.Items.Magical
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
            Stress(StressItem);
        }

        protected override IEnumerable<string> GetItemNames()
        {
            return StaffConstants.GetAllStaffs();
        }

        [Test]
        public void StressCustomStaff()
        {
            Stress(StressCustomItem);
        }

        [Test]
        public void StressRandomCustomStaff()
        {
            Stress(StressRandomCustomItem);
        }

        protected override void MakeSpecificAssertionsAgainst(Item staff)
        {
            Assert.That(staff.Name, Does.StartWith("Staff of "));
            Assert.That(staff.Attributes, Contains.Item(AttributeConstants.Charged));

            if (staff.Name != StaffConstants.Power)
            {
                Assert.That(staff.Attributes, Contains.Item(AttributeConstants.OneTimeUse));
                Assert.That(staff.Magic.Intelligence.Ego, Is.EqualTo(0));
            }

            Assert.That(staff.IsMagical, Is.True);
            Assert.That(staff.ItemType, Is.EqualTo(ItemTypeConstants.Staff));
            Assert.That(staff.Magic.Bonus, Is.Not.Negative);
            Assert.That(staff.Magic.Charges, Is.Positive);
            Assert.That(staff.Magic.Curse, Is.Not.Null);
            Assert.That(staff.Quantity, Is.EqualTo(1));
            Assert.That(staff.Traits, Is.Not.Null);
        }

        [Test]
        public override void TraitsHappen()
        {
            base.TraitsHappen();
        }

        [Test]
        public override void IntelligenceHappens()
        {
            base.IntelligenceHappens();
        }

        [Test]
        public override void CursesHappen()
        {
            AssertCursesHappen();
        }

        [Test]
        public override void SpecificCursesHappen()
        {
            AssertSpecificCursesHappen();
        }

        [Test]
        public override void NoDecorationsHappen()
        {
            AssertNoDecorationsHappen();
        }

        [Test]
        public override void SpecificCursedItemsWithTraitsHappen()
        {
            AssertSpecificCursedItemsWithTraitsHappen();
        }

        [Test]
        public override void SpecificCursedItemsWithIntelligenceHappen()
        {
            AssertSpecificCursedItemsWithIntelligenceHappen();
        }

        [Test]
        public override void SpecificCursedItemsWithNoDecorationHappen()
        {
            AssertSpecificCursedItemsWithNoDecorationHappen();
        }

        [Test]
        public override void StressSpecificCursedItems()
        {
            base.StressSpecificCursedItems();
        }

        [Test]
        public void StressStaffFromSubset()
        {
            Stress(StressItemFromSubset);
        }
    }
}