using System;
using EquipmentGen.Common.Items;
using EquipmentGen.Common.Items;
using EquipmentGen.Generators.Interfaces;
using EquipmentGen.Generators.Interfaces.Items.Mundane;
using Ninject;
using NUnit.Framework;

namespace EquipmentGen.Tests.Integration.Stress.Items.Mundane
{
    [TestFixture]
    public class AmmunitionGeneratorTests : StressTests
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
        public void StressedAmmunitionGenerator()
        {
            while (TestShouldKeepRunning())
            {
                var ammunition = AmmunitionGenerator.Generate();

                Assert.That(ammunition.Magic, Is.Empty);
                Assert.That(ammunition.Name, Is.Not.Empty);
                Assert.That(ammunition.Quantity, Is.InRange<Int32>(1, 50));
                Assert.That(ammunition.Traits, Is.Not.Null);
                Assert.That(ammunition.Attributes, Contains.Item(ItemTypeConstants.Weapon));
                Assert.That(ammunition.Attributes, Contains.Item(AttributeConstants.Ammunition));
                Assert.That(ammunition.Attributes, Contains.Item(AttributeConstants.Ranged));
            }

            AssertIterations();
        }
    }
}