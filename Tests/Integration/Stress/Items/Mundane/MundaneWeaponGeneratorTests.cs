using EquipmentGen.Common.Items;
using EquipmentGen.Generators.Interfaces.Items.Mundane;
using Ninject;
using NUnit.Framework;

namespace EquipmentGen.Tests.Integration.Stress.Items.Mundane
{
    [TestFixture]
    public class MundaneWeaponGeneratorTests : StressTests
    {
        [Inject, Named(ItemTypeConstants.Weapon)]
        public IMundaneGearGenerator MundaneWeaponGenerator { get; set; }

        [Test]
        public void StressedMundaneWeaponGenerator()
        {
            StressGenerator();
        }

        protected override void MakeAssertions()
        {
            var weapon = MundaneWeaponGenerator.Generate();

            Assert.That(weapon.Name, Is.Not.Empty);
            Assert.That(weapon.Traits, Contains.Item(TraitConstants.Masterwork));
            Assert.That(weapon.Attributes, Contains.Item(ItemTypeConstants.Weapon));
            Assert.That(weapon.Quantity, Is.GreaterThan(0));
            Assert.That(weapon.IsMagical, Is.False);
            Assert.That(weapon.Attributes, Contains.Item(AttributeConstants.Common).Or.Contains(AttributeConstants.Uncommon));
            Assert.That(weapon.Attributes, Contains.Item(AttributeConstants.Melee).Or.Contains(AttributeConstants.Ranged));
            Assert.That(weapon.Contents, Is.Empty);
        }
    }
}