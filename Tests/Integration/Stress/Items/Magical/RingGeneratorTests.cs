using System.Linq;
using EquipmentGen.Common.Items;
using EquipmentGen.Generators.Interfaces.Items.Magical;
using Ninject;
using NUnit.Framework;

namespace EquipmentGen.Tests.Integration.Stress.Items.Magical
{
    [TestFixture]
    public class RingGeneratorTests : MagicalItemGeneratorStressTests
    {
        [Inject, Named(ItemTypeConstants.Ring)]
        public IMagicalItemGenerator RingGenerator { get; set; }

        protected override void MakeAssertionsAgainst(Item ring)
        {
            Assert.That(ring.Name, Is.StringStarting("Ring of "));
            Assert.That(ring.Traits, Is.Not.Null);
            Assert.That(ring.Attributes, Is.Not.Null);
            Assert.That(ring.Quantity, Is.EqualTo(1));
            Assert.That(ring.IsMagical, Is.True);
            Assert.That(ring.Contents, Is.Not.Null);
            Assert.That(ring.ItemType, Is.EqualTo(ItemTypeConstants.Ring));
            Assert.That(ring.Magic.Bonus, Is.AtLeast(0));
            Assert.That(ring.Magic.Charges, Is.AtLeast(0));
            Assert.That(ring.Magic.SpecialAbilities, Is.Empty);

            if (ring.Attributes.Contains(AttributeConstants.Charged))
                Assert.That(ring.Magic.Charges, Is.GreaterThan(0));

            var itemMaterials = ring.Traits.Intersect(materials);
            Assert.That(itemMaterials, Is.Empty);
        }

        protected override Item GenerateItem()
        {
            var power = GetNewPower();
            return RingGenerator.GenerateAtPower(power);
        }

        [Test]
        public void IntelligenceHappens()
        {
            AssertIntelligenceHappens();
        }

        [Test]
        public void TraitsHappen()
        {
            AssertTraitsHappen();
        }
    }
}