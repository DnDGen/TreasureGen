using System;
using EquipmentGen.Core.Data.Items;
using EquipmentGen.Core.Generation.Generators.Interfaces;
using Ninject;
using NUnit.Framework;

namespace EquipmentGen.Tests.Integration.Stress.Generation.Generators
{
    [TestFixture]
    public class AmmunitionGeneratorTests : StressTest
    {
        [Inject]
        public IAmmunitionGenerator AmmunitionGenerator { get; set; }

        [SetUp]
        public void Setup()
        {
            StartTest();
        }

        [TearDown]
        public void TearDown()
        {
            StopTest();
        }

        [Test]
        public void AmmunitionGeneratorGeneratesAmmunition()
        {
            while (TestShouldKeepRunning())
            {
                var ammunition = AmmunitionGenerator.Generate();

                Assert.That(ammunition, Is.Not.Null);
                Assert.That(ammunition.Abilities, Is.Empty);
                Assert.That(ammunition.MagicalBonus, Is.EqualTo(0));
                Assert.That(ammunition.Name, Is.Not.Empty);
                Assert.That(ammunition.Quantity, Is.InRange<Int32>(1, 50));
                Assert.That(ammunition.Traits, Is.Not.Null);
                Assert.That(ammunition.Types, Contains.Item(ItemsConstants.ItemTypes.Weapon));
                Assert.That(ammunition.Types, Contains.Item(ItemsConstants.Gear.Types.Ammunition));
                Assert.That(ammunition.Types, Contains.Item(ItemsConstants.Gear.Types.Ranged));
            }

            AssertIterations();
        }
    }
}