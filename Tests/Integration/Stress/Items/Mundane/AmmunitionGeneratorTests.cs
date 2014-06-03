using System;
using EquipmentGen.Common.Items;
using EquipmentGen.Generators.Items.Mundane;
using Ninject;
using NUnit.Framework;

namespace EquipmentGen.Tests.Integration.Stress.Items.Mundane
{
    [TestFixture]
    public class AmmunitionGeneratorTests : StressTests
    {
        [Inject]
        public AmmunitionGenerator AmmunitionGenerator { get; set; }

        protected override void MakeAssertions()
        {
            var ammunition = AmmunitionGenerator.Generate();

            Assert.That(ammunition.IsMagical, Is.False);
            Assert.That(ammunition.Name, Is.Not.Empty);
            Assert.That(ammunition.Quantity, Is.InRange<Int32>(1, 50));
            Assert.That(ammunition.Traits, Is.Not.Null);
            Assert.That(ammunition.ItemType, Is.EqualTo(ItemTypeConstants.Weapon));
            Assert.That(ammunition.Attributes, Contains.Item(AttributeConstants.Ammunition));
            Assert.That(ammunition.Attributes, Contains.Item(AttributeConstants.Ranged));
            Assert.That(ammunition.Contents, Is.Empty);
        }
    }
}