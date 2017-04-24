using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;
using TreasureGen.Items;
using TreasureGen.Items.Magical;

namespace TreasureGen.Tests.Integration.Stress.Items.Magical
{
    [TestFixture]
    public class MagicalArmorGeneratorTests : MagicalItemGeneratorStressTests
    {
        protected override bool allowMinor
        {
            get { return true; }
        }

        protected override string itemType
        {
            get { return ItemTypeConstants.Armor; }
        }

        [Test]
        public void StressArmor()
        {
            Stress(StressItem);
        }

        protected override void MakeSpecificAssertionsAgainst(Item armor)
        {
            Assert.That(armor.Quantity, Is.EqualTo(1), armor.Name);
            Assert.That(armor.ItemType, Is.EqualTo(ItemTypeConstants.Armor), armor.Name);
        }

        [Test]
        public void MagicalArmorHappens()
        {
            var armor = GenerateOrFail(GenerateItem, a => a.ItemType == itemType && a.IsMagical);
            AssertItem(armor);
            Assert.That(armor.IsMagical, Is.True);
        }

        [Test]
        public void MundaneArmorHappens()
        {
            var armor = GenerateOrFail(GenerateItem, a => a.ItemType == itemType && a.IsMagical == false);
            AssertItem(armor);
            Assert.That(armor.IsMagical, Is.False);
        }

        [Test]
        public void SpecialAbilitiesHappen()
        {
            var armor = GenerateOrFail(GenerateItem, a => a.ItemType == itemType && a.Magic.SpecialAbilities.Any());
            AssertItem(armor);
            Assert.That(armor.Magic.SpecialAbilities, Is.Not.Empty);
        }

        [Test]
        public void SpecialAbilitiesDoNotHappen()
        {
            var armor = GenerateOrFail(GenerateItem, a => a.ItemType == itemType && a.Magic.SpecialAbilities.Any() == false);
            AssertItem(armor);
            Assert.That(armor.Magic.SpecialAbilities, Is.Empty);
        }

        [Test]
        public void ContentsHappen()
        {
            var armor = GenerateOrFail(GenerateItem, a => a.ItemType == itemType && a.Contents.Any());
            AssertItem(armor);
            Assert.That(armor.Contents, Is.Not.Empty);
        }

        [Test]
        public void ContentsDoNotHappen()
        {
            var armor = GenerateOrFail(GenerateItem, a => a.ItemType == itemType && a.Contents.Any() == false);
            AssertItem(armor);
            Assert.That(armor.Contents, Is.Empty);
        }

        [Test]
        public void SpecificArmorHappens()
        {
            var armor = GenerateOrFail(GenerateItem, a => a.ItemType == itemType && a.Attributes.Contains(AttributeConstants.Specific) && a.Magic.Curse != CurseConstants.SpecificCursedItem);
            AssertItem(armor);
            Assert.That(armor.Attributes, Contains.Item(AttributeConstants.Specific));
            Assert.That(armor.Magic.Curse, Is.Not.EqualTo(CurseConstants.SpecificCursedItem));
        }

        [Test]
        public void UndecoratedSpecificArmorHappens()
        {
            var armor = GenerateOrFail(GenerateItem, a => a.ItemType == itemType && a.Attributes.Contains(AttributeConstants.Specific) && a.Magic.Intelligence.Ego == 0 && a.Magic.Curse == string.Empty);
            AssertItem(armor);
            Assert.That(armor.Attributes, Contains.Item(AttributeConstants.Specific));
            Assert.That(armor.Magic.Curse, Is.Empty);
            Assert.That(armor.Magic.Intelligence.Ego, Is.EqualTo(0));
        }

        [Test]
        public void IntelligentSpecificArmorHappens()
        {
            var armor = GenerateOrFail(GenerateItem, a => a.ItemType == itemType && a.Attributes.Contains(AttributeConstants.Specific) && a.Magic.Curse != CurseConstants.SpecificCursedItem && a.Magic.Intelligence.Ego > 0);
            AssertItem(armor);
            Assert.That(armor.Attributes, Contains.Item(AttributeConstants.Specific));
            Assert.That(armor.Magic.Curse, Is.Not.EqualTo(CurseConstants.SpecificCursedItem));
            ItemVerifier.AssertIntelligence(armor.Magic.Intelligence);

        }

        [Test]
        public void CursedSpecificArmorHappens()
        {
            var armor = GenerateOrFail(GenerateItem, a => a.ItemType == itemType && a.Attributes.Contains(AttributeConstants.Specific) && a.Magic.Curse != CurseConstants.SpecificCursedItem && a.Magic.Curse != string.Empty);
            AssertItem(armor);
            Assert.That(armor.Attributes, Contains.Item(AttributeConstants.Specific));
            Assert.That(armor.Magic.Curse, Is.Not.Empty);
            Assert.That(armor.Magic.Curse, Is.Not.EqualTo(CurseConstants.SpecificCursedItem));
        }

        [Test]
        public void SpecificArmorDoesNotHappen()
        {
            var armor = GenerateOrFail(GenerateItem, a => a.ItemType == itemType && a.Attributes.Contains(AttributeConstants.Specific) == false);
            AssertItem(armor);
            Assert.That(armor.Attributes, Is.All.Not.EqualTo(AttributeConstants.Specific));
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
            //INFO: have to make our own method here, since all magic armors are masterwork
            var item = GenerateOrFail(GenerateItem, i => i.ItemType == itemType && !i.Traits.Except(new[] { TraitConstants.Masterwork }).Any() && string.IsNullOrEmpty(i.Magic.Curse) && i.Magic.Intelligence.Ego == 0);
            AssertItem(item);
            Assert.That(item.Traits.Except(new[] { TraitConstants.Masterwork }), Is.Empty);
            Assert.That(item.Magic.Curse, Is.Empty);
            Assert.That(item.Magic.Intelligence.Ego, Is.EqualTo(0));
        }

        [Test]
        public override void SpecificCursedItemsWithTraitsHappen()
        {
            AssertSpecificCursedItemsWithTraitsHappen();
        }

        [Test]
        public override void SpecificCursedItemsWithIntelligenceHappen()
        {
            AssertSpecificCursedItemsWithIntelligenceHappen();
        }

        [Test]
        public override void SpecificCursedItemsWithNoDecorationHappen()
        {
            AssertSpecificCursedItemsWithNoDecorationHappen();
        }

        [Test]
        public override void StressSpecificCursedItems()
        {
            base.StressSpecificCursedItems();
        }

        protected override IEnumerable<string> GetItemNames()
        {
            return ArmorConstants.GetAllArmors(true);
        }

        [Test]
        public void StressCustomArmor()
        {
            Stress(StressCustomItem);
        }

        [Test]
        public void StressRandomCustomArmor()
        {
            Stress(StressRandomCustomItem);
        }

        [Test]
        public void StressArmorFromSubset()
        {
            Stress(StressItemFromSubset);
        }
    }
}