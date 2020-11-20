using DnDGen.RollGen;
using DnDGen.TreasureGen.Items;
using DnDGen.TreasureGen.Items.Magical;
using DnDGen.TreasureGen.Selectors.Percentiles;
using NUnit.Framework;
using System;
using System.Linq;

namespace DnDGen.TreasureGen.Tests.Unit.Generators.Items
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
            Assert.That(item.ItemType, Is.Not.Empty, $"{item.Description} item type");
            Assert.That(item.BaseNames, Is.Not.Empty, item.Description);
            Assert.That(item.BaseNames, Is.All.Not.Empty, item.Description);
            Assert.That(item.BaseNames, Is.Unique, item.Description);
            Assert.That(item.Attributes, Is.Not.Null, item.Description);
            Assert.That(item.Attributes, Is.All.Not.Empty, item.Description);
            Assert.That(item.Attributes, Is.Unique, item.Description);
            Assert.That(item.Magic, Is.Not.Null, item.Description);
            Assert.That(item.Traits, Is.Not.Null, item.Description);
            Assert.That(item.Traits, Is.All.Not.Empty, item.Description);
            Assert.That(item.Traits, Is.Unique, item.Description);
            Assert.That(item.Contents, Is.Not.Null, item.Description);
            Assert.That(item.Contents, Is.All.Not.Empty, item.Description);

            if (!item.CanBeUsedAsWeaponOrArmor)
                Assert.That(item.Magic.SpecialAbilities, Is.Empty, item.Description);

            foreach (var ability in item.Magic.SpecialAbilities)
            {
                Assert.That(ability.Name, Is.Not.Empty, $"{item.Description} ability name");
                Assert.That(ability.BonusEquivalent, Is.Not.Negative, ability.Name);
                Assert.That(ability.AttributeRequirements, Is.Not.Null, ability.Name);
                Assert.That(ability.AttributeRequirements, Is.All.Not.Empty, ability.Name);
                Assert.That(ability.BaseName, Is.Not.Empty, $"{item.Description} with {ability.Name}");
                Assert.That(ability.Power, Is.Not.Negative, ability.Name);

                if (ability.BaseName == SpecialAbilityConstants.Bane)
                {
                    Assert.That(ability.Damages.Select(d => d.Condition), Is.All.Not.Empty, $"{item.Description} with {ability.Name}");
                    Assert.That(ability.CriticalDamages.SelectMany(kvp => kvp.Value).Select(d => d.Condition), Is.All.Not.Empty, $"{item.Description} with {ability.Name}");
                }
            }

            AssertArmor(item);
            AssertWeapon(item);
            AssertSpecialMaterials(item);
        }

        private void AssertArmor(Item item)
        {
            if (!(item is Armor))
                return;

            var armor = item as Armor;
            Assert.That(armor.ArmorBonus, Is.Positive, armor.Description);
            Assert.That(armor.CanBeUsedAsWeaponOrArmor, Is.True, armor.Description);
            Assert.That(armor.Size, Is.Not.Empty, armor.Description);
            Assert.That(armor.MaxDexterityBonus, Is.Not.Negative, armor.Description);
            Assert.That(armor.ArmorCheckPenalty, Is.Not.Positive, armor.Description);

            if (armor.IsMagical)
                Assert.That(armor.Traits, Contains.Item(TraitConstants.Masterwork), armor.Description);
        }

        private void AssertWeapon(Item item)
        {
            if (!(item is Weapon))
                return;

            var weapon = item as Weapon;
            Assert.That(weapon.CanBeUsedAsWeaponOrArmor, Is.True, weapon.Description);
            Assert.That(weapon.CriticalMultiplier, Is.EqualTo("x2").Or.EqualTo("x3").Or.EqualTo("x4"), $"{weapon.Description} critical multiplier");
            Assert.That(weapon.Size, Is.Not.Empty, $"{weapon.Description} size");
            Assert.That(weapon.Damages, Is.Not.Empty
                .And.Count.EqualTo(1 + weapon.Magic.SpecialAbilities.SelectMany(a => a.Damages).Count()), $"{weapon.Description} damages: {weapon.DamageDescription}");
            Assert.That(weapon.CriticalDamages, Is.Not.Empty
                .And.Count.EqualTo(1 + weapon.Magic.SpecialAbilities
                    .Where(a => a.CriticalDamages.Any())
                    .SelectMany(a => a.CriticalDamages[weapon.CriticalMultiplier])
                    .Count()), $"{weapon.Description} critical damages: {weapon.CriticalDamageDescription}");

            foreach (var damage in weapon.Damages)
            {
                Assert.That(damage.Roll, Is.Not.Empty, weapon.Description);
                Assert.That(damage.Type, Is.Not.Empty, weapon.Description);
                Assert.That(damage.Condition, Does.Not.Contain(ReplacementStringConstants.DesignatedFoe), weapon.Description);
            }

            foreach (var damage in weapon.CriticalDamages)
            {
                Assert.That(damage.Roll, Is.Not.Empty, weapon.Description);
                Assert.That(damage.Type, Is.Not.Empty, weapon.Description);
                Assert.That(damage.Condition, Does.Not.Contain(ReplacementStringConstants.DesignatedFoe), weapon.Description);
            }

            Assert.That(weapon.Damages[0].Type, Contains.Substring(AttributeConstants.DamageTypes.Bludgeoning)
                .Or.Contains(AttributeConstants.DamageTypes.Piercing)
                .Or.Contains(AttributeConstants.DamageTypes.Slashing), weapon.Description);
            Assert.That(weapon.CriticalDamages[0].Type, Contains.Substring(AttributeConstants.DamageTypes.Bludgeoning)
                .Or.Contains(AttributeConstants.DamageTypes.Piercing)
                .Or.Contains(AttributeConstants.DamageTypes.Slashing), weapon.Description);

            Assert.That(weapon.ThreatRange, Is.Positive.And.InRange(1, 6), $"{weapon.Description} threat range");
            Assert.That(weapon.ThreatRangeDescription, Is.Not.Empty, $"{weapon.Description} threat range description");
            Assert.That(weapon.Ammunition, Is.Not.Null, weapon.Description);

            if (weapon.IsMagical)
                Assert.That(weapon.Traits, Contains.Item(TraitConstants.Masterwork), weapon.Description);

            Assert.That(weapon.Attributes, Is.Not.Empty
                .And.Not.Contains(AttributeConstants.DamageTypes.Bludgeoning)
                .And.Not.Contains(AttributeConstants.DamageTypes.Piercing)
                .And.Not.Contains(AttributeConstants.DamageTypes.Slashing), $"{weapon.Description} attributes");

            Assert.That(weapon.CombatTypes, Is.Not.Empty, $"{weapon.Description} combat types");
            Assert.That(weapon.CombatTypes, Contains.Item(AttributeConstants.Melee).Or.Contains(AttributeConstants.Ranged), weapon.Description);
            Assert.That(weapon.CombatTypes.Count(), Is.InRange(1, 2), weapon.Description);

            if (weapon.Attributes.Contains(AttributeConstants.DoubleWeapon))
            {
                Assert.That(weapon.SecondaryCriticalMultiplier, Is.EqualTo("x2").Or.EqualTo("x3").Or.EqualTo("x4"), $"{weapon.Description} secondary critical multiplier");
                Assert.That(weapon.SecondaryDamages, Is.Not.Empty, $"{weapon.Description} secondary damages: {weapon.SecondaryDamageDescription}");
                Assert.That(weapon.SecondaryCriticalDamages, Is.Not.Empty, $"{weapon.Description} secondary critical damages: {weapon.SecondaryCriticalDamageDescription}");

                foreach (var damage in weapon.SecondaryDamages)
                {
                    Assert.That(damage.Roll, Is.Not.Empty, weapon.Description);
                    Assert.That(damage.Type, Is.Not.Empty, weapon.Description);
                    Assert.That(damage.Condition, Does.Not.Contain(ReplacementStringConstants.DesignatedFoe), weapon.Description);
                }

                foreach (var damage in weapon.SecondaryCriticalDamages)
                {
                    Assert.That(damage.Roll, Is.Not.Empty, weapon.Description);
                    Assert.That(damage.Type, Is.Not.Empty, weapon.Description);
                    Assert.That(damage.Condition, Does.Not.Contain(ReplacementStringConstants.DesignatedFoe), weapon.Description);
                }

                Assert.That(weapon.SecondaryDamages[0].Type, Contains.Substring(AttributeConstants.DamageTypes.Bludgeoning)
                    .Or.Contains(AttributeConstants.DamageTypes.Piercing)
                    .Or.Contains(AttributeConstants.DamageTypes.Slashing), weapon.Description);
                Assert.That(weapon.SecondaryCriticalDamages[0].Type, Contains.Substring(AttributeConstants.DamageTypes.Bludgeoning)
                    .Or.Contains(AttributeConstants.DamageTypes.Piercing)
                    .Or.Contains(AttributeConstants.DamageTypes.Slashing), weapon.Description);

                if (weapon.SecondaryHasAbilities)
                {
                    Assert.That(weapon.SecondaryMagicBonus, Is.EqualTo(weapon.Magic.Bonus), weapon.Description);
                    Assert.That(weapon.SecondaryDamages, Is.Not.Empty
                        .And.Count.EqualTo(1 + weapon.Magic.SpecialAbilities.SelectMany(a => a.Damages).Count()), $"{weapon.Description} secondary damages: {weapon.SecondaryDamageDescription}");
                    Assert.That(weapon.SecondaryCriticalDamages, Is.Not.Empty
                        .And.Count.EqualTo(1 + weapon.Magic.SpecialAbilities
                            .Where(a => a.CriticalDamages.Any())
                            .SelectMany(a => a.CriticalDamages[weapon.SecondaryCriticalMultiplier])
                            .Count()), $"{weapon.Description} secondary critical damages: {weapon.SecondaryCriticalDamageDescription}");
                }
                else if (weapon.Magic.Bonus > 0)
                {
                    Assert.That(weapon.SecondaryMagicBonus, Is.EqualTo(weapon.Magic.Bonus - 1), weapon.Description);
                }
                else
                {
                    Assert.That(weapon.SecondaryMagicBonus, Is.Zero, weapon.Description);
                    Assert.That(weapon.SecondaryDamages, Is.Not.Empty
                        .And.Count.EqualTo(1), $"{weapon.Description} secondary damages: {weapon.SecondaryDamageDescription}");
                    Assert.That(weapon.SecondaryCriticalDamages, Is.Not.Empty
                        .And.Count.EqualTo(1), $"{weapon.Description} secondary critical damages: {weapon.SecondaryCriticalDamageDescription}");
                }
            }
            else
            {
                Assert.That(weapon.SecondaryDamages, Is.Empty, weapon.Description);
                Assert.That(weapon.SecondaryCriticalDamages, Is.Empty, weapon.Description);
                Assert.That(weapon.SecondaryCriticalMultiplier, Is.Empty, weapon.Description);
                Assert.That(weapon.SecondaryMagicBonus, Is.Zero, weapon.Description);
            }
        }

        private void AssertSpecialMaterials(Item item)
        {
            if (item.Traits.Contains(TraitConstants.SpecialMaterials.Adamantine))
            {
                Assert.That(item.Attributes, Contains.Item(AttributeConstants.Metal), item.Description);
                Assert.That(item.Traits, Contains.Item(TraitConstants.Masterwork), item.Description);
            }

            if (item.Traits.Contains(TraitConstants.SpecialMaterials.Darkwood))
            {
                Assert.That(item.Attributes, Contains.Item(AttributeConstants.Wood), item.Description);
                Assert.That(item.Traits, Contains.Item(TraitConstants.Masterwork), item.Description);
            }

            if (item.Traits.Contains(TraitConstants.SpecialMaterials.Dragonhide))
            {
                Assert.That(item.Attributes, Does.Not.Contain(AttributeConstants.Metal)
                    .And.Not.Contains(AttributeConstants.Wood), $"{item.Name} of Dragonhide");
                Assert.That(item.Traits, Contains.Item(TraitConstants.Masterwork), $"{item.Description} of Dragonhide");
            }

            if (item.Traits.Contains(TraitConstants.SpecialMaterials.ColdIron))
            {
                Assert.That(item.Attributes, Contains.Item(AttributeConstants.Metal), item.Description);
            }

            if (item.Traits.Contains(TraitConstants.SpecialMaterials.Mithral))
            {
                Assert.That(item.Attributes, Contains.Item(AttributeConstants.Metal), item.Description);
                Assert.That(item.Traits, Contains.Item(TraitConstants.Masterwork), item.Description);
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
            Assert.That(intelligence.Communication, Is.Not.Empty
                .And.All.Not.Empty
                .And.Unique);
            Assert.That(intelligence.Personality, Is.Not.Null);
            Assert.That(intelligence.Powers, Is.Not.Empty
                .And.All.Not.Empty
                .And.Unique);
            Assert.That(intelligence.Senses, Is.Not.Empty);
        }

        public void AssertSpecificCursedItem(Item item)
        {
            var materials = TraitConstants.SpecialMaterials.All();

            AssertItem(item);
            Assert.That(item.Magic.Curse, Is.Not.Empty.And.EqualTo(CurseConstants.SpecificCursedItem), item.Description);
            Assert.That(item.Attributes, Contains.Item(AttributeConstants.Specific), item.Description);
            Assert.That(item.Traits.Intersect(materials), Is.Empty, item.Description);
        }

        public Armor CreateRandomArmorTemplate(string name)
        {
            var template = new Armor();

            template.Name = name;
            template = PopulateItem(template) as Armor;

            template.ArmorBonus = random.Next();
            template.ArmorCheckPenalty = -random.Next();
            template.MaxDexterityBonus = random.Next();

            return template;
        }

        public Weapon CreateRandomWeaponTemplate(string name)
        {
            var template = new Weapon();

            template.Name = name;
            template = PopulateItem(template) as Weapon;

            var damageTypes = new[] { AttributeConstants.DamageTypes.Bludgeoning, AttributeConstants.DamageTypes.Piercing, AttributeConstants.DamageTypes.Slashing };
            template.CriticalMultiplier = $"x{random.Next(3) + 2}";
            template.Damages.Add(new Damage
            {
                Roll = $"{random.Next(Limits.Quantity) + 1}d{random.Next(Limits.Die) + 1}",
                Type = $"{damageTypes[random.Next(3)]} {Guid.NewGuid()}"
            });
            template.CriticalDamages.Add(new Damage
            {
                Roll = $"{random.Next(Limits.Quantity) + 1}d{random.Next(Limits.Die) + 1}",
                Type = $"{damageTypes[random.Next(3)]} {Guid.NewGuid()}"
            });
            template.ThreatRange = random.Next(3) + 1;
            template.Size = $"size {Guid.NewGuid()}";

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
            item.Attributes = new[] { Guid.NewGuid().ToString(), Guid.NewGuid().ToString() };

            return item;
        }

        public void AssertMagicalItemFromTemplate(Item item, Item template)
        {
            Assert.That(item, Is.Not.EqualTo(template), item.Description);
            Assert.That(item.IsMagical, Is.True, item.Description);
            Assert.That(item.Magic.Curse, Is.EqualTo(template.Magic.Curse).Or.EqualTo(CurseConstants.SpecificCursedItem), item.Description);

            var sizes = TraitConstants.Sizes.All();
            Assert.That(item.Traits, Is.SupersetOf(template.Traits.Except(sizes)), item.Description);

            if (item.Attributes.Contains(AttributeConstants.OneTimeUse) || item.Attributes.Contains(AttributeConstants.Ammunition))
            {
                AssertNoIntelligence(item.Magic.Intelligence, item.Description);
            }
            else
            {
                Assert.That(item.Magic.Intelligence.Alignment, Is.EqualTo(template.Magic.Intelligence.Alignment), item.Description);
                Assert.That(item.Magic.Intelligence.CharismaStat, Is.EqualTo(template.Magic.Intelligence.CharismaStat), item.Description);
                Assert.That(item.Magic.Intelligence.Communication, Is.EquivalentTo(template.Magic.Intelligence.Communication), item.Description);
                Assert.That(item.Magic.Intelligence.DedicatedPower, Is.EqualTo(template.Magic.Intelligence.DedicatedPower), item.Description);
                Assert.That(item.Magic.Intelligence.Ego, Is.EqualTo(template.Magic.Intelligence.Ego), item.Description);
                Assert.That(item.Magic.Intelligence.IntelligenceStat, Is.EqualTo(template.Magic.Intelligence.IntelligenceStat), item.Description);
                Assert.That(item.Magic.Intelligence.Languages, Is.EquivalentTo(template.Magic.Intelligence.Languages), item.Description);
                Assert.That(item.Magic.Intelligence.Personality, Is.EqualTo(template.Magic.Intelligence.Personality), item.Description);
                Assert.That(item.Magic.Intelligence.Powers, Is.EquivalentTo(template.Magic.Intelligence.Powers), item.Description);
                Assert.That(item.Magic.Intelligence.Senses, Is.EqualTo(template.Magic.Intelligence.Senses), item.Description);
                Assert.That(item.Magic.Intelligence.SpecialPurpose, Is.EqualTo(template.Magic.Intelligence.SpecialPurpose), item.Description);
                Assert.That(item.Magic.Intelligence.WisdomStat, Is.EqualTo(template.Magic.Intelligence.WisdomStat), item.Description);
            }
        }

        private void AssertNoIntelligence(Intelligence intelligence, string name)
        {
            Assert.That(intelligence.Alignment, Is.Empty, name);
            Assert.That(intelligence.CharismaStat, Is.EqualTo(0), name);
            Assert.That(intelligence.Communication, Is.Empty, name);
            Assert.That(intelligence.DedicatedPower, Is.Empty, name);
            Assert.That(intelligence.Ego, Is.EqualTo(0), name);
            Assert.That(intelligence.IntelligenceStat, Is.EqualTo(0), name);
            Assert.That(intelligence.Languages, Is.Empty, name);
            Assert.That(intelligence.Personality, Is.Empty, name);
            Assert.That(intelligence.Powers, Is.Empty, name);
            Assert.That(intelligence.Senses, Is.Empty, name);
            Assert.That(intelligence.SpecialPurpose, Is.Empty, name);
            Assert.That(intelligence.WisdomStat, Is.EqualTo(0), name);
        }

        public void AssertMundaneItemFromTemplate(Item item, Item template)
        {
            Assert.That(item, Is.Not.EqualTo(template), item.Description);
            Assert.That(item.Name, Is.EqualTo(template.Name));
            Assert.That(item.Contents, Is.EquivalentTo(template.Contents), item.Description);
            Assert.That(item.IsMagical, Is.False, item.Description);
            Assert.That(item.Magic.Bonus, Is.EqualTo(0), item.Description);
            Assert.That(item.Magic.Charges, Is.EqualTo(0), item.Description);
            Assert.That(item.Magic.Curse, Is.Empty, item.Description);
            AssertNoIntelligence(item.Magic.Intelligence, item.Description);
            Assert.That(item.Magic.SpecialAbilities, Is.Empty, item.Description);

            if (!(item is Armor))
                Assert.That(template.Traits, Is.SubsetOf(item.Traits), item.Description);
        }
    }
}
