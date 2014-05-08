using EquipmentGen.Common.Items;
using EquipmentGen.Generators.Interfaces.Items.Mundane;
using Ninject;
using NUnit.Framework;

namespace EquipmentGen.Tests.Integration.Stress.Items.Mundane
{
    [TestFixture]
    public class MundaneArmorGeneratorTests : StressTests
    {
        [Inject, Named(ItemTypeConstants.Armor)]
        public IMundaneGearGenerator MundaneArmorGenerator { get; set; }

        [Test]
        public void StressedMundaneArmorGenerator()
        {
            StressGenerator();
        }

        protected override void MakeAssertions()
        {
            var armor = MundaneArmorGenerator.Generate();

            Assert.That(armor.Name, Is.Not.Empty);
            Assert.That(armor.Traits, Is.Not.Null);
            Assert.That(armor.ItemType, Is.EqualTo(ItemTypeConstants.Armor), armor.Name);
            Assert.That(armor.Attributes, Is.Not.Null);
            Assert.That(armor.Quantity, Is.EqualTo(1));
            Assert.That(armor.IsMagical, Is.False);
            Assert.That(armor.Contents, Is.Empty);
        }
    }
}