using Ninject;
using NUnit.Framework;
using System;
using TreasureGen.Common.Items;
using TreasureGen.Generators.Items.Mundane;

namespace TreasureGen.Tests.Integration.Stress.Items.Mundane
{
    [TestFixture]
    public class AlchemicalItemGeneratorTests : MundaneItemGeneratorStressTests
    {
        [Inject, Named(ItemTypeConstants.AlchemicalItem)]
        public MundaneItemGenerator AlchemicalItemGenerator { get; set; }

        [TestCase("Alchemical item generator")]
        public override void Stress(String thingToStress)
        {
            Stress();
        }

        protected override void MakeAssertions()
        {
            var item = GenerateItem();

            Assert.That(item.Name, Is.Not.Empty);
            Assert.That(item.Quantity, Is.GreaterThan(0));
            Assert.That(item.IsMagical, Is.False);
            Assert.That(item.Attributes, Is.Empty);
            Assert.That(item.Traits, Is.Empty);
            Assert.That(item.Contents, Is.Empty);
            Assert.That(item.ItemType, Is.EqualTo(ItemTypeConstants.AlchemicalItem));
        }

        protected override Item GenerateItem()
        {
            return AlchemicalItemGenerator.Generate();
        }

        [Test]
        public override void NoDecorationsHappen()
        {
            AssertNoDecorationsHappen();
        }
    }
}