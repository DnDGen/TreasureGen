using System;
using System.Collections.Generic;
using EquipmentGen.Core.Data.Items;
using EquipmentGen.Core.Generation.Factories.Interfaces;
using EquipmentGen.Core.Generation.Generators.Interfaces;
using Ninject;
using NUnit.Framework;

namespace EquipmentGen.Tests.Integration.Stress.Generation.Generators
{
    [TestFixture]
    public class MundaneItemGeneratorTests : StressTest
    {
        [Inject]
        public IPowerItemGeneratorFactory PowerItemGeneratorFactory { get; set; }

        private IPowerItemGenerator mundaneItemGenerator;
        private IEnumerable<Type> itemTypes;

        [SetUp]
        public void Setup()
        {
            itemTypes = new[]
            {
                typeof(AlchemicalItem),
                typeof(Tool),
                typeof(Gear)
            };

            mundaneItemGenerator = PowerItemGeneratorFactory.CreateWith(ItemsConstants.Power.Mundane);
            StartTest();
        }

        [TearDown]
        public void TearDown()
        {
            StopTest();
        }

        [Test]
        public void MundaneItemGeneratorReturnsItem()
        {
            while (TestShouldKeepRunning())
            {
                var item = mundaneItemGenerator.Generate();

                Assert.That(item, Is.Not.Null);
                Assert.That(item.Name, Is.Not.Empty);
                Assert.That(itemTypes, Contains.Item(item.GetType()));

                if (item is Gear)
                {
                    var gear = item as Gear;
                    Assert.That(gear.MagicalBonus, Is.EqualTo(0));
                    Assert.That(gear.Abilities, Is.Empty);
                }
            }

            AssertIterations();
        }
    }
}