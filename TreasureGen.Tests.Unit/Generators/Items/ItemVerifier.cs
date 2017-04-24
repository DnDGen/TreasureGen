using NUnit.Framework;
using System;
using System.Linq;
using TreasureGen.Items;
using TreasureGen.Items.Magical;

namespace TreasureGen.Tests.Unit.Generators.Items
{
    public class ItemVerifier
    {
        private readonly Random random;

        public ItemVerifier()
        {
            random = new Random();
        }

        public void AssertItem(Item item)
        {
            Assert.That(item.Name, Is.Not.Empty);
            Assert.That(item.ItemType, Is.Not.Empty, item.Name);
            Assert.That(item.BaseNames, Is.Not.Empty, item.Name);
            Assert.That(item.BaseNames, Is.All.Not.Empty, item.Name);
            Assert.That(item.BaseNames, Is.Unique, item.Name);
            Assert.That(item.Attributes, Is.Not.Null, item.Name);
            Assert.That(item.Attributes, Is.All.Not.Empty, item.Name);
            Assert.That(item.Attributes, Is.Unique, item.Name);
            Assert.That(item.Magic, Is.Not.Null, item.Name);
            Assert.That(item.Traits, Is.Not.Null, item.Name);
            Assert.That(item.Traits, Is.All.Not.Empty, item.Name);
            Assert.That(item.Traits, Is.Unique, item.Name);
            Assert.That(item.Contents, Is.Not.Null, item.Name);
            Assert.That(item.Contents, Is.All.Not.Empty, item.Name);

            if (!item.CanBeUsedAsWeaponOrArmor)
                Assert.That(item.Magic.SpecialAbilities, Is.Empty);

            foreach (var ability in item.Magic.SpecialAbilities)
            {
                Assert.That(ability.Name, Is.Not.Empty, item.Name);
                Assert.That(ability.BonusEquivalent, Is.Not.Negative, ability.Name);
                Assert.That(ability.AttributeRequirements, Is.Not.Null, ability.Name);
                Assert.That(ability.AttributeRequirements, Is.All.Not.Empty, ability.Name);
                Assert.That(ability.BaseName, Is.Not.Empty, $"{item.Name} with {ability.Name}");
                Assert.That(ability.Power, Is.Not.Negative, ability.Name);
            }

            AssertArmor(item);
            AssertSpecialMaterials(item);
        }

        private void AssertArmor(Item item)
        {
            if (!(item is Armor))
                return;

            var armor = item as Armor;
            Assert.That(armor.ArmorBonus, Is.Positive, armor.Name);
            Assert.That(armor.Size, Is.Not.Empty, armor.Name);
            Assert.That(armor.MaxDexterityBonus, Is.Not.Negative, armor.Name);
            Assert.That(armor.ArmorCheckPenalty, Is.Not.Positive, armor.Name);

            if (armor.IsMagical)
                Assert.That(armor.Traits, Contains.Item(TraitConstants.Masterwork), armor.Name);
        }

        private void AssertSpecialMaterials(Item item)
        {
            if (item.Traits.Contains(TraitConstants.SpecialMaterials.Adamantine))
            {
                Assert.That(item.Attributes, Contains.Item(AttributeConstants.Metal), item.Name);
                Assert.That(item.Traits, Contains.Item(TraitConstants.Masterwork), item.Name);
            }

            if (item.Traits.Contains(TraitConstants.SpecialMaterials.Darkwood))
            {
                Assert.That(item.Attributes, Contains.Item(AttributeConstants.Wood), item.Name);
                Assert.That(item.Traits, Contains.Item(TraitConstants.Masterwork), item.Name);
            }

            if (item.Traits.Contains(TraitConstants.SpecialMaterials.Dragonhide))
            {
                Assert.That(item.Attributes, Is.All.Not.EqualTo(AttributeConstants.Metal), item.Name);
                Assert.That(item.Attributes, Is.All.Not.EqualTo(AttributeConstants.Wood), item.Name);
                Assert.That(item.Traits, Contains.Item(TraitConstants.Masterwork), item.Name);
            }

            if (item.Traits.Contains(TraitConstants.SpecialMaterials.ColdIron))
            {
                Assert.That(item.Attributes, Contains.Item(AttributeConstants.Metal), item.Name);
            }

            if (item.Traits.Contains(TraitConstants.SpecialMaterials.Mithral))
            {
                Assert.That(item.Attributes, Contains.Item(AttributeConstants.Metal), item.Name);
                Assert.That(item.Traits, Contains.Item(TraitConstants.Masterwork), item.Name);
            }

            if (item.Traits.Contains(TraitConstants.SpecialMaterials.AlchemicalSilver))
            {
                Assert.That(item.Attributes, Contains.Item(AttributeConstants.Metal));
            }
        }

        public void AssertIntelligence(Intelligence intelligence)
        {
            Assert.That(intelligence.Ego, Is.Positive);
            Assert.That(intelligence.Alignment, Is.Not.Empty);
            Assert.That(intelligence.CharismaStat, Is.AtLeast(10));
            Assert.That(intelligence.WisdomStat, Is.AtLeast(10));
            Assert.That(intelligence.IntelligenceStat, Is.AtLeast(10));
            Assert.That(intelligence.Communication, Is.Not.Empty);
            Assert.That(intelligence.Communication, Is.All.Not.Empty);
            Assert.That(intelligence.Communication, Is.Unique);
            Assert.That(intelligence.Personality, Is.Not.Null);
            Assert.That(intelligence.Powers, Is.Not.Empty);
            Assert.That(intelligence.Powers, Is.All.Not.Empty);
            Assert.That(intelligence.Powers, Is.Unique);
            Assert.That(intelligence.Senses, Is.Not.Empty);
        }

        public void AssertSpecificCursedItem(Item item)
        {
            var materials = TraitConstants.SpecialMaterials.All();

            AssertItem(item);
            Assert.That(item.Magic.Curse, Is.Not.Empty, item.Name);
            Assert.That(item.Magic.Curse, Is.EqualTo(CurseConstants.SpecificCursedItem), item.Name);
            Assert.That(item.Attributes, Contains.Item(AttributeConstants.Specific), item.Name);
            Assert.That(item.Traits.Intersect(materials), Is.Empty, item.Name);
        }

        public Armor CreateRandomArmorTemplate(string name)
        {
            var template = new Armor();

            template.Name = name;
            template = PopulateItem(template) as Armor;

            return template;
        }

        public Item CreateRandomTemplate(string name)
        {
            var template = new Item();

            template.Name = name;
            template = PopulateItem(template);

            return template;
        }

        private Item PopulateItem(Item item)
        {
            item.BaseNames = new[] { Guid.NewGuid().ToString(), Guid.NewGuid().ToString() };
            item.Quantity = random.Next();
            item.Contents.Add(Guid.NewGuid().ToString());
            item.Contents.Add(Guid.NewGuid().ToString());
            item.IsMagical = true;
            item.ItemType = Guid.NewGuid().ToString();
            item.Magic.Bonus = random.Next();
            item.Magic.Charges = random.Next();
            item.Magic.Curse = Guid.NewGuid().ToString();
            item.Magic.Intelligence.Alignment = Guid.NewGuid().ToString();
            item.Magic.Intelligence.CharismaStat = random.Next();
            item.Magic.Intelligence.Communication = new[] { Guid.NewGuid().ToString(), Guid.NewGuid().ToString() };
            item.Magic.Intelligence.DedicatedPower = Guid.NewGuid().ToString();
            item.Magic.Intelligence.Ego = random.Next();
            item.Magic.Intelligence.IntelligenceStat = random.Next();
            item.Magic.Intelligence.Languages.Add(Guid.NewGuid().ToString());
            item.Magic.Intelligence.Languages.Add(Guid.NewGuid().ToString());
            item.Magic.Intelligence.Personality = Guid.NewGuid().ToString();
            item.Magic.Intelligence.Powers.Add(Guid.NewGuid().ToString());
            item.Magic.Intelligence.Powers.Add(Guid.NewGuid().ToString());
            item.Magic.Intelligence.Senses = Guid.NewGuid().ToString();
            item.Magic.Intelligence.SpecialPurpose = Guid.NewGuid().ToString();
            item.Magic.Intelligence.WisdomStat = random.Next();
            item.Magic.SpecialAbilities = new[]
            {
                new SpecialAbility { Name = Guid.NewGuid().ToString() },
                new SpecialAbility { Name = Guid.NewGuid().ToString() }
            };

            item.Traits.Add(Guid.NewGuid().ToString());
            item.Traits.Add(Guid.NewGuid().ToString());

            return item;
        }

        public void AssertMagicalItemFromTemplate(Item item, Item template)
        {
            Assert.That(item, Is.Not.EqualTo(template), item.Name);
            Assert.That(item.Name, Is.EqualTo(template.Name));
            Assert.That(item.IsMagical, Is.True, item.Name);
            Assert.That(item.Magic.Curse, Is.EqualTo(template.Magic.Curse).Or.EqualTo(CurseConstants.SpecificCursedItem), item.Name);
            Assert.That(item.Traits, Is.SupersetOf(template.Traits), item.Name);

            if (item.Attributes.Contains(AttributeConstants.OneTimeUse) || item.Attributes.Contains(AttributeConstants.Ammunition))
            {
                AssertNoIntelligence(item.Magic.Intelligence);
            }
            else
            {
                Assert.That(item.Magic.Intelligence.Alignment, Is.EqualTo(template.Magic.Intelligence.Alignment), item.Name);
                Assert.That(item.Magic.Intelligence.CharismaStat, Is.EqualTo(template.Magic.Intelligence.CharismaStat), item.Name);
                Assert.That(item.Magic.Intelligence.Communication, Is.EquivalentTo(template.Magic.Intelligence.Communication), item.Name);
                Assert.That(item.Magic.Intelligence.DedicatedPower, Is.EqualTo(template.Magic.Intelligence.DedicatedPower), item.Name);
                Assert.That(item.Magic.Intelligence.Ego, Is.EqualTo(template.Magic.Intelligence.Ego), item.Name);
                Assert.That(item.Magic.Intelligence.IntelligenceStat, Is.EqualTo(template.Magic.Intelligence.IntelligenceStat), item.Name);
                Assert.That(item.Magic.Intelligence.Languages, Is.EquivalentTo(template.Magic.Intelligence.Languages), item.Name);
                Assert.That(item.Magic.Intelligence.Personality, Is.EqualTo(template.Magic.Intelligence.Personality), item.Name);
                Assert.That(item.Magic.Intelligence.Powers, Is.EquivalentTo(template.Magic.Intelligence.Powers), item.Name);
                Assert.That(item.Magic.Intelligence.Senses, Is.EqualTo(template.Magic.Intelligence.Senses), item.Name);
                Assert.That(item.Magic.Intelligence.SpecialPurpose, Is.EqualTo(template.Magic.Intelligence.SpecialPurpose), item.Name);
                Assert.That(item.Magic.Intelligence.WisdomStat, Is.EqualTo(template.Magic.Intelligence.WisdomStat), item.Name);
            }
        }

        private void AssertNoIntelligence(Intelligence intelligence)
        {
            Assert.That(intelligence.Alignment, Is.Empty);
            Assert.That(intelligence.CharismaStat, Is.EqualTo(0));
            Assert.That(intelligence.Communication, Is.Empty);
            Assert.That(intelligence.DedicatedPower, Is.Empty);
            Assert.That(intelligence.Ego, Is.EqualTo(0));
            Assert.That(intelligence.IntelligenceStat, Is.EqualTo(0));
            Assert.That(intelligence.Languages, Is.Empty);
            Assert.That(intelligence.Personality, Is.Empty);
            Assert.That(intelligence.Powers, Is.Empty);
            Assert.That(intelligence.Senses, Is.Empty);
            Assert.That(intelligence.SpecialPurpose, Is.Empty);
            Assert.That(intelligence.WisdomStat, Is.EqualTo(0));
        }

        public void AssertMundaneItemFromTemplate(Item item, Item template)
        {
            Assert.That(item, Is.Not.EqualTo(template), item.Name);
            Assert.That(item.Name, Is.EqualTo(template.Name));
            Assert.That(item.Contents, Is.EquivalentTo(template.Contents), item.Name);
            Assert.That(item.IsMagical, Is.False, item.Name);
            Assert.That(item.Magic.Bonus, Is.EqualTo(0), item.Name);
            Assert.That(item.Magic.Charges, Is.EqualTo(0), item.Name);
            Assert.That(item.Magic.Curse, Is.Empty, item.Name);
            AssertNoIntelligence(item.Magic.Intelligence);
            Assert.That(item.Magic.SpecialAbilities, Is.Empty, item.Name);

            if (!(item is Armor))
                Assert.That(template.Traits, Is.SubsetOf(item.Traits), item.Name);
        }
    }
}
