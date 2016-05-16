using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using TreasureGen.Items;
using TreasureGen.Items.Magical;

namespace TreasureGen.Tests.Integration.Stress.Items.Magical
{
    [TestFixture]
    public abstract class MagicalItemGeneratorStressTests : ItemTests
    {
        protected abstract string itemType { get; }
        protected IEnumerable<string> materials;

        [SetUp]
        public void MundaneItemGeneratorStressSetup()
        {
            materials = TraitConstants.GetSpecialMaterials();
        }

        protected override void MakeAssertions()
        {
            var item = GenerateItem();

            //INFO: This is in case the generator produces a specific cursed item of the incorrect item type
            if (item.ItemType != itemType)
                return;

            MakeAssertionsAgainst(item);
        }

        protected abstract void MakeAssertionsAgainst(Item item);

        public virtual void IntelligenceHappens()
        {
            GenerateOrFail(i => i.Magic.Intelligence.Ego > 0);
        }

        public abstract void CursesHappen();

        protected void AssertCursesHappen()
        {
            GenerateOrFail(i => string.IsNullOrEmpty(i.Magic.Curse) == false && i.Magic.Curse != CurseConstants.SpecificCursedItem);
        }

        public abstract void SpecificCursesHappen();

        protected void AssertSpecificCursesHappen()
        {
            GenerateOrFail(i => i.Magic.Curse == CurseConstants.SpecificCursedItem);
        }

        public abstract void SpecificCursedItemsAreIntelligent();

        protected void AssertSpecificCursedItemsAreIntelligent()
        {
            GenerateOrFail(i => i.Magic.Curse == CurseConstants.SpecificCursedItem && i.Magic.Intelligence.Ego > 0);
        }

        public abstract void SpecificCursedItemsHaveTraits();

        protected void AssertSpecificCursedItemsHaveTraits()
        {
            GenerateOrFail(i => i.Magic.Curse == CurseConstants.SpecificCursedItem && i.Traits.Except(materials).Any());
        }

        public abstract void SpecificCursedItemsDoNotHaveSpecialMaterials();

        protected void AssertSpecificCursedItemsDoNotHaveSpecialMaterials()
        {
            Stress(AssertNoSpecialMaterialsForSpecificCursedItems);
        }

        private void AssertNoSpecialMaterialsForSpecificCursedItems()
        {
            var item = GenerateItem();
            if (item.Magic.Curse != CurseConstants.SpecificCursedItem)
                return;

            var itemMaterials = item.Traits.Intersect(materials);
            Assert.That(itemMaterials, Is.Empty, item.Name);
            Assert.That(item.Magic.Curse, Is.EqualTo(CurseConstants.SpecificCursedItem), item.Name);
        }

        public abstract void SpecificCursedItemsAreNotDecorated();

        protected void AssertSpecificCursedItemsAreNotDecorated()
        {
            GenerateOrFail(i => i.Magic.Curse == CurseConstants.SpecificCursedItem && i.Magic.Intelligence.Ego == 0);
        }

        public virtual void TraitsHappen()
        {
            GenerateOrFail(i => i.Traits.Except(materials).Any());
        }

        public virtual void SpecialMaterialsHappen()
        {
            GenerateOrFail(i => i.Traits.Intersect(materials).Any());
        }

        public abstract void NoDecorationsHappen();

        protected void AssertNoDecorationsHappen()
        {
            GenerateOrFail(i => i.Traits.Any() == false && String.IsNullOrEmpty(i.Magic.Curse) && i.Magic.Intelligence.Ego == 0);
        }
    }
}