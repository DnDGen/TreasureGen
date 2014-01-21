using EquipmentGen.Core.Data.Items;
using EquipmentGen.Core.Generation.Factories.Interfaces;
using EquipmentGen.Core.Generation.Generators.Interfaces;
using Ninject;
using NUnit.Framework;

namespace EquipmentGen.Tests.Integration.Stress.Generation.Generators
{
    [TestFixture]
    public class MundaneWeaponGeneratorTests : StressTest
    {
        [Inject]
        public IMundaneGearGeneratorFactory mundaneGearGeneratorFactory { get; set; }

        private IMundaneGearGenerator mundaneWeaponGenerator;

        [SetUp]
        public void Setup()
        {
            mundaneWeaponGenerator = mundaneGearGeneratorFactory.CreateWith(ItemsConstants.ItemTypes.Weapon);
            StartTest();
        }

        [TearDown]
        public void TearDown()
        {
            StopTest();
        }

        [Test]
        public void MundaneWeaponGeneratorGeneratesWeapon()
        {
            while (TestShouldKeepRunning())
            {
                var weapon = mundaneWeaponGenerator.Generate();

                Assert.That(weapon, Is.Not.Null);
                Assert.That(weapon.Name, Is.Not.Empty);
                Assert.That(weapon.Traits, Is.Not.Null);
                Assert.That(weapon.Abilities, Is.Empty);
                Assert.That(weapon.MagicalBonus, Is.EqualTo(0));

                if (weapon is Ammunition)
                {
                    var ammo = weapon as Ammunition;
                    Assert.That(ammo.Quantity, Is.GreaterThanOrEqualTo(0));
                }
            }

            AssertIterations();
        }
    }
}