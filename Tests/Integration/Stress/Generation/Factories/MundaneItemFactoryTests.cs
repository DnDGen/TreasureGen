using System;
using System.Collections.Generic;
using EquipmentGen.Core.Data.Items;
using EquipmentGen.Core.Generation.Factories.Interfaces;
using Ninject;
using NUnit.Framework;

namespace EquipmentGen.Tests.Integration.Stress.Generation.Factories
{
    [TestFixture]
    public class MundaneItemFactoryTests : StressTest
    {
        [Inject]
        public IPowerFactoryFactory PowerFactoryFactory { get; set; }

        private IPowerFactory mundaneItemFactory;
        private IEnumerable<Type> itemTypes;

        [SetUp]
        public void Setup()
        {
            itemTypes = new[]
            {
                typeof(AlchemicalItem),
                typeof(BasicItem),
                typeof(Gear)
            };

            mundaneItemFactory = PowerFactoryFactory.CreateWith(ItemsConstants.Power.Mundane);
            StartTest();
        }

        [TearDown]
        public void TearDown()
        {
            StopTest();
        }

        [Test]
        public void MundaneItemFactoryReturnsItem()
        {
            while (TestShouldKeepRunning())
            {
                var item = mundaneItemFactory.Create();

                Assert.That(item, Is.Not.Null);
                Assert.That(item.Name, Is.Not.Empty);
                Assert.That(itemTypes, Contains.Item(item.GetType()));
            }

            AssertIterations();
        }
    }
}