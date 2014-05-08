using EquipmentGen.Common.Items;
using EquipmentGen.Generators.Interfaces.Items.Magical;
using Ninject;
using NUnit.Framework;

namespace EquipmentGen.Tests.Integration.Stress.Items.Magical
{
    [TestFixture]
    public class MagicalArmorGeneratorTests : StressTests
    {
        [Inject, Named(ItemTypeConstants.Armor)]
        public IMagicalGearGenerator MagicalArmorGenerator { get; set; }

        [Test]
        public void StressedMagicalArmorGenerator()
        {
            StressGenerator();
        }

        protected override void MakeAssertions()
        {
            var power = GetNewPower(false);
            var armor = MagicalArmorGenerator.GenerateAtPower(power);

            if (armor.ItemType == ItemTypeConstants.SpecificCursedItem)
                return;

            Assert.That(armor.Name, Is.Not.Empty);
            Assert.That(armor.Traits, Is.Not.Null);
            Assert.That(armor.Attributes, Is.Not.Null);
            Assert.That(armor.Quantity, Is.EqualTo(1));
            Assert.That(armor.Contents, Is.Not.Null);
            Assert.That(armor.ItemType, Is.EqualTo(ItemTypeConstants.Armor));

            if (armor.IsMagical)
                Assert.That(armor.Magic.Bonus, Is.GreaterThan(0));
        }
    }
}