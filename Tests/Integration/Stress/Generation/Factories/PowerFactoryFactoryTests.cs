using System;
using EquipmentGen.Core.Data.Items;
using EquipmentGen.Core.Generation.Factories;
using EquipmentGen.Core.Generation.Factories.Interfaces;
using Ninject;
using NUnit.Framework;

namespace EquipmentGen.Tests.Integration.Stress.Generation.Factories
{
    [TestFixture]
    public class PowerFactoryFactoryTests : StressTest
    {
        [Inject]
        public IPowerFactoryFactory PowerFactoryFactory { get; set; }
        [Inject]
        public Random Random { get; set; }

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
        public void PowerFactoryFactoryReturnsPowerFactory()
        {
            while (TestShouldKeepRunning())
            {
                var power = GetNewPower();
                var factory = PowerFactoryFactory.CreateWith(power);

                Assert.That(factory, Is.Not.Null);
                AssertThatTypeMatches(power, factory);
            }

            AssertIterations();
        }

        private String GetNewPower()
        {
            switch (Random.Next(4))
            {
                case 0: return ItemsConstants.Power.Mundane;
                case 1: return ItemsConstants.Power.Minor;
                case 2: return ItemsConstants.Power.Medium;
                case 3: return ItemsConstants.Power.Major;
                default: throw new ArgumentOutOfRangeException();
            }
        }

        private void AssertThatTypeMatches(String power, IPowerFactory factory)
        {
            switch (power)
            {
                case ItemsConstants.Power.Mundane: Assert.That(factory, Is.TypeOf<MundaneItemFactory>()); break;
                case ItemsConstants.Power.Minor: Assert.That(factory, Is.TypeOf<MinorItemFactory>()); break;
                case ItemsConstants.Power.Medium: Assert.That(factory, Is.TypeOf<MediumItemFactory>()); break;
                case ItemsConstants.Power.Major: Assert.That(factory, Is.TypeOf<MajorItemFactory>()); break;
                default: throw new ArgumentOutOfRangeException();
            }
        }
    }
}