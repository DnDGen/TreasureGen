using Ninject;
using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;
using TreasureGen.Items;
using TreasureGen.Items.Magical;

namespace TreasureGen.Tests.Integration.Stress.Items.Magical
{
    [TestFixture]
    public abstract class MagicalItemGeneratorStressTests : ItemTests
    {
        [Inject]
        public ItemVerifier ItemVerifier { get; set; }

        protected abstract string itemType { get; }
        protected IEnumerable<string> materials;

        [SetUp]
        public void MundaneItemGeneratorStressSetup()
        {
            materials = TraitConstants.GetSpecialMaterials();
        }

        protected void StressItem()
        {
            var item = Generate(GenerateItem, i => i.ItemType == itemType);
            AssertItem(item);
        }

        protected void AssertItem(Item item)
        {
            ItemVerifier.AssertItem(item);
            MakeSpecificAssertionsAgainst(item);
        }

        protected abstract void MakeSpecificAssertionsAgainst(Item item);

        public virtual void IntelligenceHappens()
        {
            var item = GenerateOrFail(GenerateItem, i => i.ItemType == itemType && i.Magic.Intelligence.Ego > 0);
            AssertItem(item);
            ItemVerifier.AssertIntelligence(item.Magic.Intelligence);
        }

        public abstract void CursesHappen();

        protected void AssertCursesHappen()
        {
            var item = GenerateOrFail(GenerateItem, i => i.ItemType == itemType && string.IsNullOrEmpty(i.Magic.Curse) == false && i.Magic.Curse != CurseConstants.SpecificCursedItem);
            AssertItem(item);
            Assert.That(item.Magic.Curse, Is.Not.Empty);
            Assert.That(item.Magic.Curse, Is.Not.EqualTo(CurseConstants.SpecificCursedItem));
        }

        public virtual void TraitsHappen()
        {
            var item = GenerateOrFail(GenerateItem, i => i.ItemType == itemType && i.Traits.Except(materials).Any());
            AssertItem(item);
            Assert.That(item.Traits.Except(materials), Is.Not.Empty);
        }

        public virtual void SpecialMaterialsHappen()
        {
            var item = GenerateOrFail(GenerateItem, i => i.ItemType == itemType && i.Traits.Intersect(materials).Any());
            AssertItem(item);
            Assert.That(item.Traits.Intersect(materials), Is.Not.Empty);
        }

        public abstract void NoDecorationsHappen();

        protected void AssertNoDecorationsHappen()
        {
            var item = GenerateOrFail(GenerateItem, i => i.ItemType == itemType && i.Traits.Any() == false && string.IsNullOrEmpty(i.Magic.Curse) && i.Magic.Intelligence.Ego == 0);
            AssertItem(item);
            Assert.That(item.Traits, Is.Empty);
            Assert.That(item.Magic.Curse, Is.Empty);
            Assert.That(item.Magic.Intelligence.Ego, Is.EqualTo(0));
        }

        public abstract void SpecificCursesHappen();

        protected void AssertSpecificCursesHappen()
        {
            var item = GenerateOrFail(GenerateItem, i => i.Magic.Curse == CurseConstants.SpecificCursedItem);
            ItemVerifier.AssertSpecificCursedItem(item);
        }

        public virtual void StressSpecificCursedItems()
        {
            Stress(AssertSpecificCursedItems);
        }

        protected void AssertSpecificCursedItems()
        {
            var item = Generate(GenerateItem, i => i.Magic.Curse == CurseConstants.SpecificCursedItem);
            ItemVerifier.AssertSpecificCursedItem(item);
        }

        public abstract void SpecificCursedItemsWithTraitsHappen();

        protected void AssertSpecificCursedItemsWithTraitsHappen()
        {
            var item = GenerateOrFail(GenerateItem, i => i.Magic.Curse == CurseConstants.SpecificCursedItem && i.Traits.Except(materials).Any());
            ItemVerifier.AssertSpecificCursedItem(item);
            Assert.That(item.Traits, Is.Not.Empty);
            Assert.That(item.Traits.Except(materials), Is.Not.Empty);
        }

        public abstract void SpecificCursedItemsWithIntelligenceHappen();

        protected void AssertSpecificCursedItemsWithIntelligenceHappen()
        {
            var item = GenerateOrFail(GenerateItem, i => i.Magic.Curse == CurseConstants.SpecificCursedItem && i.Magic.Intelligence.Ego > 0);
            ItemVerifier.AssertSpecificCursedItem(item);
            ItemVerifier.AssertIntelligence(item.Magic.Intelligence);
        }

        public abstract void SpecificCursedItemsWithNoDecorationHappen();

        protected void AssertSpecificCursedItemsWithNoDecorationHappen()
        {
            var item = GenerateOrFail(GenerateItem, i => i.Magic.Curse == CurseConstants.SpecificCursedItem && i.Traits.Any() == false && i.Magic.Intelligence.Ego == 0);
            ItemVerifier.AssertSpecificCursedItem(item);
            Assert.That(item.Traits, Is.Empty);
            Assert.That(item.Magic.Intelligence.Ego, Is.EqualTo(0));
        }
    }
}