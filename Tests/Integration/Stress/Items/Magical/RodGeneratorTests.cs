using System;
using System.Linq;
using EquipmentGen.Common.Items;
using EquipmentGen.Generators.Interfaces.Items.Magical;
using Ninject;
using NUnit.Framework;

namespace EquipmentGen.Tests.Integration.Stress.Items.Magical
{
    [TestFixture]
    public class RodGeneratorTests : MagicalItemGeneratorStressTests
    {
        [Inject, Named(ItemTypeConstants.Rod)]
        public IMagicalItemGenerator RodGenerator { get; set; }

        [TestCase("Rod generator")]
        public override void Stress(String thingToStress)
        {
            Stress();
        }

        protected override void MakeAssertionsAgainst(Item rod)
        {
            Assert.That(rod.Name, Is.Not.Empty);
            Assert.That(rod.Attributes, Is.Not.Null);
            Assert.That(rod.Contents, Is.Not.Null);
            Assert.That(rod.IsMagical, Is.True);
            Assert.That(rod.ItemType, Is.EqualTo(ItemTypeConstants.Rod));
            Assert.That(rod.Magic.Bonus, Is.AtLeast(0));
            Assert.That(rod.Magic.Charges, Is.AtLeast(0));
            Assert.That(rod.Magic.SpecialAbilities, Is.Empty);
            Assert.That(rod.Quantity, Is.EqualTo(1));
            Assert.That(rod.Traits, Is.Not.Null);

            var rodMaterials = rod.Traits.Intersect(materials);
            Assert.That(rodMaterials, Is.Empty);
        }

        protected override Item GenerateItem()
        {
            var power = GetNewPower(allowMinor: false);
            return RodGenerator.GenerateAtPower(power);
        }

        [Test]
        public void ChargesHappen()
        {
            Item rod;

            do rod = GenerateItem();
            while (TestShouldKeepRunning() && !rod.Attributes.Contains(AttributeConstants.Charged));

            Assert.That(rod.Attributes, Contains.Item(AttributeConstants.Charged));
            Assert.That(rod.Magic.Charges, Is.Positive);
            AssertIterations();
        }

        [Test]
        public void ChargesDoNotHappen()
        {
            Item rod;

            do rod = GenerateItem();
            while (TestShouldKeepRunning() && rod.Attributes.Contains(AttributeConstants.Charged));

            Assert.That(rod.Attributes, Is.Not.Contains(AttributeConstants.Charged));
            Assert.That(rod.Magic.Charges, Is.EqualTo(0));
            AssertIterations();
        }

        [Test]
        public void ContentsHappen()
        {
            Item rod;

            do rod = GenerateItem();
            while (TestShouldKeepRunning() && !rod.Contents.Any());

            Assert.That(rod.Contents, Is.Not.Empty);
            AssertIterations();
        }

        [Test]
        public void ContentsDoNotHappen()
        {
            Item rod;

            do rod = GenerateItem();
            while (TestShouldKeepRunning() && rod.Contents.Any());

            Assert.That(rod.Contents, Is.Empty);
            AssertIterations();
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