using System;
using EquipmentGen.Common.Items;
using EquipmentGen.Generators.Interfaces.Items.Magical;
using Ninject;
using NUnit.Framework;

namespace EquipmentGen.Tests.Integration.Stress.Items.Magical
{
    [TestFixture]
    public class StaffGeneratorTests : MagicalItemGeneratorStressTests
    {
        [Inject, Named(ItemTypeConstants.Staff)]
        public IMagicalItemGenerator StaffGenerator { get; set; }

        protected override Item GenerateItem()
        {
            var power = GetNewPower(allowMinor: false);
            return StaffGenerator.GenerateAtPower(power);
        }

        protected override void MakeAssertionsAgainst(Item staff)
        {
            Assert.That(staff.Name, Is.StringStarting("Staff of "));
            Assert.That(staff.Attributes, Contains.Item(AttributeConstants.Charged));
            Assert.That(staff.Attributes, Contains.Item(AttributeConstants.OneTimeUse));
            Assert.That(staff.Contents, Is.Empty);
            Assert.That(staff.IsMagical, Is.True);
            Assert.That(staff.ItemType, Is.EqualTo(ItemTypeConstants.Staff));
            Assert.That(staff.Magic.Bonus, Is.EqualTo(0));
            Assert.That(staff.Magic.Charges, Is.InRange<Int32>(1, 50));
            Assert.That(staff.Magic.Curse, Is.Not.Null);
            Assert.That(staff.Magic.Intelligence.Ego, Is.EqualTo(0));
            Assert.That(staff.Quantity, Is.EqualTo(1));
            Assert.That(staff.Traits, Is.Not.Null);
        }

        [Test]
        public void TraitsHappen()
        {
            AssertTraitsHappen();
        }
    }
}