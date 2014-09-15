using System;
using System.Linq;
using EquipmentGen.Common.Items;
using EquipmentGen.Generators.Interfaces.Items.Magical;
using Ninject;
using NUnit.Framework;

namespace EquipmentGen.Tests.Integration.Stress.Items.Magical
{
    [TestFixture]
    public class WondrousItemGeneratorTests : MagicalItemGeneratorStressTests
    {
        [Inject, Named(ItemTypeConstants.WondrousItem)]
        public IMagicalItemGenerator WondrousItemGenerator { get; set; }

        [TestCase("Wondrous item generator")]
        public override void Stress(String thingToStress)
        {
            Stress();
        }

        protected override Item GenerateItem()
        {
            var power = GetNewPower();
            return WondrousItemGenerator.GenerateAtPower(power);
        }

        protected override void MakeAssertionsAgainst(Item wondrousItem)
        {
            Assert.That(wondrousItem.Name, Is.Not.Empty);
            Assert.That(wondrousItem.Traits, Is.Not.Null);
            Assert.That(wondrousItem.Attributes, Is.Not.Null);
            Assert.That(wondrousItem.Quantity, Is.EqualTo(1));
            Assert.That(wondrousItem.IsMagical, Is.True);
            Assert.That(wondrousItem.Contents, Is.Not.Null);
            Assert.That(wondrousItem.ItemType, Is.EqualTo(ItemTypeConstants.WondrousItem));
            Assert.That(wondrousItem.Magic.Bonus, Is.AtLeast(0));
            Assert.That(wondrousItem.Magic.Charges, Is.AtLeast(0));
            Assert.That(wondrousItem.Magic.SpecialAbilities, Is.Empty);

            if (wondrousItem.Attributes.Contains(AttributeConstants.Charged))
                Assert.That(wondrousItem.Magic.Charges, Is.GreaterThan(0));

            var itemMaterials = wondrousItem.Traits.Intersect(materials);
            Assert.That(itemMaterials, Is.Empty);
        }

        [Test]
        public override void IntelligenceHappens()
        {
            base.IntelligenceHappens();
        }

        [Test]
        public override void TraitsHappen()
        {
            base.TraitsHappen();
        }

        [Test]
        public override void CursesHappen()
        {
            AssertCursesHappen();
        }

        [Test]
        public override void SpecificCursesHappen()
        {
            AssertSpecificCursesHappen();
        }

        [Test]
        public override void NoDecorationsHappen()
        {
            AssertNoDecorationsHappen();
        }
    }
}