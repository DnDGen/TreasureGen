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

        public Item CreateRandomTemplate(string name)
        {
            var template = new Item();

            template.Name = name;
            template.BaseNames = new[] { Guid.NewGuid().ToString(), Guid.NewGuid().ToString() };
            template.Quantity = random.Next();
            template.Contents.Add(Guid.NewGuid().ToString());
            template.Contents.Add(Guid.NewGuid().ToString());
            template.IsMagical = true;
            template.ItemType = Guid.NewGuid().ToString();
            template.Magic.Bonus = random.Next();
            template.Magic.Charges = random.Next();
            template.Magic.Curse = Guid.NewGuid().ToString();
            template.Magic.Intelligence.Alignment = Guid.NewGuid().ToString();
            template.Magic.Intelligence.CharismaStat = random.Next();
            template.Magic.Intelligence.Communication = new[] { Guid.NewGuid().ToString(), Guid.NewGuid().ToString() };
            template.Magic.Intelligence.DedicatedPower = Guid.NewGuid().ToString();
            template.Magic.Intelligence.Ego = random.Next();
            template.Magic.Intelligence.IntelligenceStat = random.Next();
            template.Magic.Intelligence.Languages.Add(Guid.NewGuid().ToString());
            template.Magic.Intelligence.Languages.Add(Guid.NewGuid().ToString());
            template.Magic.Intelligence.Personality = Guid.NewGuid().ToString();
            template.Magic.Intelligence.Powers.Add(Guid.NewGuid().ToString());
            template.Magic.Intelligence.Powers.Add(Guid.NewGuid().ToString());
            template.Magic.Intelligence.Senses = Guid.NewGuid().ToString();
            template.Magic.Intelligence.SpecialPurpose = Guid.NewGuid().ToString();
            template.Magic.Intelligence.WisdomStat = random.Next();
            template.Magic.SpecialAbilities = new[]
            {
                new SpecialAbility { Name = Guid.NewGuid().ToString() },
                new SpecialAbility { Name = Guid.NewGuid().ToString() }
            };

            template.Traits.Add(Guid.NewGuid().ToString());
            template.Traits.Add(Guid.NewGuid().ToString());

            return template;
        }

        public void AssertMagicalItemFromTemplate(Item item, Item template)
        {
            Assert.That(item, Is.Not.EqualTo(template), item.Name);
            Assert.That(item.Name, Is.EqualTo(template.Name));

            if (item.ItemType == ItemTypeConstants.Wand)
            {
                Assert.That(item.Contents, Is.Empty);
            }
            else
            {
                Assert.That(item.Contents, Is.EquivalentTo(template.Contents), item.Name);
            }

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

            if (item.ItemType == ItemTypeConstants.Scroll)
            {
                Assert.That(item.Magic.Bonus, Is.EqualTo(0), item.Name);
                Assert.That(item.Magic.Charges, Is.EqualTo(0), item.Name);
            }
            else if (item.ItemType == ItemTypeConstants.Potion)
            {
                Assert.That(item.Magic.Bonus, Is.EqualTo(template.Magic.Bonus), item.Name);
                Assert.That(item.Magic.Charges, Is.EqualTo(0), item.Name);
            }
            else if (item.ItemType == ItemTypeConstants.Wand)
            {
                Assert.That(item.Magic.Bonus, Is.EqualTo(0), item.Name);
                Assert.That(item.Magic.Charges, Is.EqualTo(template.Magic.Charges), item.Name);
            }
            else
            {
                Assert.That(item.Magic.Bonus, Is.EqualTo(template.Magic.Bonus), item.Name);
                Assert.That(item.Magic.Charges, Is.EqualTo(template.Magic.Charges), item.Name);
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
            Assert.That(template.Traits, Is.SubsetOf(item.Traits), item.Name);
        }
    }
}
