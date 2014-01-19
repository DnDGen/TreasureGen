using System;
using EquipmentGen.Core.Data.Items;
using EquipmentGen.Core.Generation.Factories;
using EquipmentGen.Core.Generation.Factories.Interfaces;
using Ninject;
using NUnit.Framework;

namespace EquipmentGen.Tests.Integration.Stress.Generation.Factories
{
    [TestFixture]
    public class GearGeneratorFactoryTests : StressTest
    {
        [Inject]
        public IGearFactoryFactory GearGeneratorFactory { get; set; }
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
        public void GearGeneratorFactoryCreatesGearGenerator()
        {
            while (TestShouldKeepRunning())
            {
                var type = GetNewType();
                var factory = GearGeneratorFactory.CreateWith(type);

                Assert.That(factory, Is.Not.Null);
                AssertThatTypeMatches(type, factory);
            }

            AssertIterations();
        }

        private String GetNewType()
        {
            switch (Random.Next(4))
            {
                case 0: return ItemsConstants.ItemTypes.AlchemicalItem;
                case 1: return ItemsConstants.ItemTypes.Armor;
                case 2: return ItemsConstants.ItemTypes.Weapon;
                case 3: return ItemsConstants.ItemTypes.Tool;
                default: throw new ArgumentOutOfRangeException();
            }
        }

        private void AssertThatTypeMatches(String power, Object factory)
        {
            switch (power)
            {
                case ItemsConstants.ItemTypes.AlchemicalItem: Assert.That(factory, Is.TypeOf<AlchemicalItemFactory>()); break;
                case ItemsConstants.ItemTypes.Armor: Assert.That(factory, Is.TypeOf<ArmorFactory>()); break;
                case ItemsConstants.ItemTypes.Weapon: Assert.That(factory, Is.TypeOf<WeaponFactory>()); break;
                case ItemsConstants.ItemTypes.Tool: Assert.That(factory, Is.TypeOf<ToolFactory>()); break;
                default: throw new ArgumentOutOfRangeException();
            }
        }
    }
}