using Ninject;
using NUnit.Framework;
using System;
using TreasureGen.Common.Items;
using TreasureGen.Generators.Domain.Items.Mundane;

namespace TreasureGen.Tests.Integration.Stress.Items.Mundane
{
    [TestFixture]
    public class AmmunitionGeneratorTests : ItemTests
    {
        [Inject]
        public AmmunitionGenerator AmmunitionGenerator { get; set; }

        [TestCase("Ammunition generator")]
        public override void Stress(String thingToStress)
        {
            Stress();
        }

        protected override Item GenerateItem()
        {
            return AmmunitionGenerator.Generate();
        }

        protected override void MakeAssertions()
        {
            var ammunition = GenerateItem();

            Assert.That(ammunition.IsMagical, Is.False);
            Assert.That(ammunition.Name, Is.Not.Empty);
            Assert.That(ammunition.Quantity, Is.InRange(1, 50));
            Assert.That(ammunition.Traits, Is.Not.Null);
            Assert.That(ammunition.ItemType, Is.EqualTo(ItemTypeConstants.Weapon));
            Assert.That(ammunition.Attributes, Contains.Item(AttributeConstants.Ammunition));
            Assert.That(ammunition.Attributes, Contains.Item(AttributeConstants.Ranged));
            Assert.That(ammunition.Contents, Is.Empty);
        }

        [Test]
        public void MultipleAmmunitionHappens()
        {
            var ammunition = GenerateOrFail(a => a.Quantity > 1);
            Assert.That(ammunition.Quantity, Is.InRange(2, 50));
        }
    }
}