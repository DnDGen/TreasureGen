using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using TreasureGen.Items;
using TreasureGen.Items.Magical;

namespace TreasureGen.Tests.Integration.Stress.Items.Magical
{
    [TestFixture]
    public abstract class MagicalItemGeneratorStressTests : ItemStressTests
    {
        protected abstract string itemType { get; }
        protected abstract bool allowMinor { get; }

        protected IEnumerable<string> materials;
        private MagicalItemGenerator magicalItemGenerator;
        private IEnumerable<string> specialAbilities;

        [SetUp]
        public void MundaneItemGeneratorStressSetup()
        {
            magicalItemGenerator = GetNewInstanceOf<MagicalItemGenerator>(itemType);

            materials = TraitConstants.SpecialMaterials.All();
            specialAbilities = SpecialAbilityConstants.GetAllAbilities();
        }

        protected void StressItem()
        {
            var item = Generate(GenerateItem, i => i.ItemType == itemType);
            AssertItem(item);
        }

        protected override Item GenerateItem()
        {
            var power = GetNewPower(allowMinor);
            return magicalItemGenerator.GenerateAtPower(power);
        }

        protected void AssertItem(Item item)
        {
            ItemVerifier.AssertItem(item);
            MakeSpecificAssertionsAgainst(item);
        }

        protected abstract void MakeSpecificAssertionsAgainst(Item item);

        protected void StressRandomCustomItem()
        {
            var name = GetRandomName();
            var item = GenerateRandomCustomItem(name);

            AssertItem(item);
            Assert.That(item.Name, Is.EqualTo(name));
        }

        private string GetRandomName()
        {
            var names = GetItemNames();
            var name = GetRandom(names);

            return name;
        }

        protected override Item GenerateRandomCustomItem(string name)
        {
            var template = GetRandomTemplate(name);
            return magicalItemGenerator.Generate(template, allowRandomDecoration: true);
        }

        private Item GetRandomTemplate(string name)
        {
            var template = ItemVerifier.CreateRandomTemplate(name);

            var abilitiesCount = Random.Next(specialAbilities.Count()) + 1;
            var abilityNames = specialAbilities.Take(abilitiesCount);
            template.Magic.SpecialAbilities = abilityNames.Select(n => new SpecialAbility { Name = n });

            return template;
        }

        protected void StressCustomItem()
        {
            var name = GetRandomName();
            var template = GetRandomTemplate(name);

            var item = magicalItemGenerator.Generate(template);
            AssertItem(item);
            ItemVerifier.AssertMagicalItemFromTemplate(item, template);
        }

        protected abstract IEnumerable<string> GetItemNames();

        private string GetRandom(IEnumerable<string> collection)
        {
            var randomIndex = Random.Next(collection.Count());
            return collection.ElementAt(randomIndex);
        }

        protected void StressItemFromSubset()
        {
            var names = GetItemNames();
            var subset = GetRandomSubset(names);

            var item = GenerateItemFromSubset(subset);
            AssertItem(item);
            Assert.That(item.ItemType, Is.EqualTo(itemType));
            Assert.That(subset.Any(n => item.NameMatches(n)), Is.True, $"{item.Name} ({string.Join(", ", item.BaseNames)}) from [{string.Join(", ", subset)}]");
        }

        protected override Item GenerateItemFromSubset(IEnumerable<string> subset)
        {
            var power = GetNewPower(allowMinor);
            return magicalItemGenerator.GenerateFromSubset(power, subset);
        }

        private IEnumerable<string> GetRandomSubset(IEnumerable<string> collection)
        {
            var limit = collection.Count() / 2;
            var skipAmount = Random.Next(limit);
            var takeAmount = Random.Next(limit) + 1;

            return collection.Skip(skipAmount).Take(takeAmount);
        }

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