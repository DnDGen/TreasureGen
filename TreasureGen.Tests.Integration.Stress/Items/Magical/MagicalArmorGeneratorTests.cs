using Ninject;
using NUnit.Framework;
using System;
using System.Linq;
using TreasureGen.Items;
using TreasureGen.Items.Magical;

namespace TreasureGen.Tests.Integration.Stress.Items.Magical
{
    [TestFixture]
    public class MagicalArmorGeneratorTests : MagicalItemGeneratorStressTests
    {
        [Inject, Named(ItemTypeConstants.Armor)]
        public MagicalItemGenerator MagicalArmorGenerator { get; set; }

        [TestCase("Magical Armor generator")]
        public override void Stress(string thingToStress)
        {
            Stress();
        }

        protected override string itemType
        {
            get { return ItemTypeConstants.Armor; }
        }

        protected override void MakeAssertionsAgainst(Item armor)
        {
            Assert.That(armor.Name, Is.Not.Empty, armor.Name);
            Assert.That(armor.Traits, Is.Not.Null, armor.Name);
            Assert.That(armor.Attributes, Is.Not.Null, armor.Name);
            Assert.That(armor.Quantity, Is.EqualTo(1), armor.Name);
            Assert.That(armor.Contents, Is.Not.Null, armor.Name);
            Assert.That(armor.ItemType, Is.EqualTo(ItemTypeConstants.Armor), armor.Name);
            Assert.That(armor.Magic.Charges, Is.EqualTo(0), armor.Name);
            Assert.That(armor.Magic.SpecialAbilities, Is.Not.Null, armor.Name);
        }

        protected override Item GenerateItem()
        {
            var power = GetNewPower();
            return MagicalArmorGenerator.GenerateAtPower(power);
        }

        [Test]
        public void MagicalArmorHappens()
        {
            GenerateOrFail(a => a.IsMagical);
        }

        [Test]
        public void MundaneArmorHappens()
        {
            GenerateOrFail(a => a.IsMagical == false);
        }

        [Test]
        public void SpecialAbilitiesHappen()
        {
            GenerateOrFail(a => a.Magic.SpecialAbilities.Any());
        }

        [Test]
        public void SpecialAbilitiesDoNotHappen()
        {
            GenerateOrFail(a => a.Magic.SpecialAbilities.Any() == false);
        }

        [Test]
        public void ContentsHappen()
        {
            GenerateOrFail(a => a.Contents.Any());
        }

        [Test]
        public void ContentsDoNotHappen()
        {
            GenerateOrFail(a => a.Contents.Any() == false);
        }

        [Test]
        public void SpecificArmorHappens()
        {
            GenerateOrFail(a => a.Attributes.Contains(AttributeConstants.Specific) && a.Magic.Curse != CurseConstants.SpecificCursedItem);
        }

        [Test]
        public void UndecoratedSpecificArmorHappens()
        {
            GenerateOrFail(a => a.Attributes.Contains(AttributeConstants.Specific) && a.Magic.Intelligence.Ego == 0 && a.Magic.Curse == String.Empty);
        }

        [Test]
        public void IntelligentSpecificArmorHappens()
        {
            GenerateOrFail(a => a.Attributes.Contains(AttributeConstants.Specific) && a.Magic.Curse != CurseConstants.SpecificCursedItem && a.Magic.Intelligence.Ego > 0);
        }

        [Test]
        public void CursedSpecificArmorHappens()
        {
            GenerateOrFail(a => a.Attributes.Contains(AttributeConstants.Specific) && a.Magic.Curse != CurseConstants.SpecificCursedItem && a.Magic.Curse != String.Empty);
        }

        [Test]
        public void SpecificArmorDoesNotHappen()
        {
            GenerateOrFail(a => a.Attributes.Contains(AttributeConstants.Specific) == false);
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
        public override void SpecialMaterialsHappen()
        {
            base.SpecialMaterialsHappen();
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

        [Test]
        public override void SpecificCursedItemsAreIntelligent()
        {
            AssertSpecificCursedItemsAreIntelligent();
        }

        [Test]
        public override void SpecificCursedItemsAreNotDecorated()
        {
            AssertSpecificCursedItemsAreNotDecorated();
        }

        [Test]
        public override void SpecificCursedItemsHaveTraits()
        {
            AssertSpecificCursedItemsHaveTraits();
        }

        [Test]
        public override void SpecificCursedItemsDoNotHaveSpecialMaterials()
        {
            AssertSpecificCursedItemsDoNotHaveSpecialMaterials();
        }
    }
}