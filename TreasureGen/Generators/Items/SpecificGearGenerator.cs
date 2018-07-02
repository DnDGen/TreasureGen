using DnDGen.Core.Generators;
using DnDGen.Core.Selectors.Collections;
using System.Collections.Generic;
using System.Linq;
using TreasureGen.Generators.Items.Magical;
using TreasureGen.Selectors.Percentiles;
using TreasureGen.Tables;
using TreasureGen.Items;
using TreasureGen.Items.Magical;
using TreasureGen.Items.Mundane;

namespace TreasureGen.Generators.Items
{
    internal class SpecificGearGenerator : ISpecificGearGenerator
    {
        private readonly ITypeAndAmountPercentileSelector typeAndAmountPercentileSelector;
        private readonly ICollectionSelector collectionsSelector;
        private readonly IChargesGenerator chargesGenerator;
        private readonly ITreasurePercentileSelector percentileSelector;
        private readonly ISpellGenerator spellGenerator;
        private readonly ISpecialAbilitiesGenerator specialAbilitiesGenerator;
        private readonly JustInTimeFactory justInTimeFactory;

        public SpecificGearGenerator(ITypeAndAmountPercentileSelector typeAndAmountPercentileSelector,
            ICollectionSelector collectionsSelector,
            IChargesGenerator chargesGenerator,
            ITreasurePercentileSelector percentileSelector,
            ISpellGenerator spellGenerator,
            ISpecialAbilitiesGenerator specialAbilitiesGenerator,
            JustInTimeFactory justInTimeFactory)
        {
            this.typeAndAmountPercentileSelector = typeAndAmountPercentileSelector;
            this.collectionsSelector = collectionsSelector;
            this.chargesGenerator = chargesGenerator;
            this.percentileSelector = percentileSelector;
            this.spellGenerator = spellGenerator;
            this.specialAbilitiesGenerator = specialAbilitiesGenerator;
            this.justInTimeFactory = justInTimeFactory;
        }

        public Item GenerateRandomPrototypeFrom(string power, string specificGearType)
        {
            var tableName = string.Format(TableNameConstants.Percentiles.Formattable.POWERSpecificITEMTYPEs, power, specificGearType);
            var selection = typeAndAmountPercentileSelector.SelectFrom(tableName);

            var gear = new Item();
            gear.Name = selection.Type;
            gear.BaseNames = collectionsSelector.SelectFrom(TableNameConstants.Collections.Set.ItemGroups, selection.Type);
            gear.ItemType = GetItemType(specificGearType);
            gear.Magic.Bonus = selection.Amount;
            gear.Quantity = 0;

            return gear;
        }

        private Item SetPrototypeAttributes(Item prototype, string specificGearType)
        {
            var gear = prototype.Clone();

            if (gear.Name == WeaponConstants.JavelinOfLightning)
            {
                gear.IsMagical = true;
            }
            else if (gear.Name == ArmorConstants.CastersShield)
            {
                var hasSpell = percentileSelector.SelectFrom<bool>(TableNameConstants.Percentiles.Set.CastersShieldContainsSpell);

                if (hasSpell)
                {
                    var spellType = percentileSelector.SelectFrom(TableNameConstants.Percentiles.Set.CastersShieldSpellTypes);
                    var spellLevel = spellGenerator.GenerateLevel(PowerConstants.Medium);
                    var spell = spellGenerator.Generate(spellType, spellLevel);
                    var formattedSpell = string.Format("{0} ({1}, {2})", spell, spellType, spellLevel);
                    gear.Contents.Add(formattedSpell);
                }
            }

            gear.Name = RenameGear(gear.Name);
            gear.Magic.SpecialAbilities = GetSpecialAbilities(specificGearType, gear.Name);

            var tableName = string.Format(TableNameConstants.Collections.Formattable.SpecificITEMTYPEAttributes, specificGearType);
            gear.Attributes = collectionsSelector.SelectFrom(tableName, gear.Name);

            tableName = string.Format(TableNameConstants.Collections.Formattable.SpecificITEMTYPETraits, specificGearType);
            var traits = collectionsSelector.SelectFrom(tableName, gear.Name);

            foreach (var trait in traits)
                gear.Traits.Add(trait);

            if (gear.Attributes.Contains(AttributeConstants.Charged))
                gear.Magic.Charges = chargesGenerator.GenerateFor(specificGearType, gear.Name);

            if (gear.Name == WeaponConstants.SlayingArrow || gear.Name == WeaponConstants.GreaterSlayingArrow)
            {
                var designatedFoe = percentileSelector.SelectFrom(TableNameConstants.Percentiles.Set.DesignatedFoes);
                var trait = string.Format("Designated Foe: {0}", designatedFoe);
                gear.Traits.Add(trait);
            }

            if (gear.IsMagical)
                gear.Traits.Add(TraitConstants.Masterwork);

            if (gear.ItemType == ItemTypeConstants.Armor)
                return GetArmor(gear);

            if (gear.ItemType == ItemTypeConstants.Weapon)
                return GetWeapon(gear);

            if (gear.Quantity == 0)
                gear.Quantity = 1;

            return gear;
        }

        private Armor GetArmor(Item gear)
        {
            var template = new Armor();
            template.Name = gear.BaseNames.First();

            var mundaneArmorGenerator = justInTimeFactory.Build<MundaneItemGenerator>(ItemTypeConstants.Armor);
            var armor = mundaneArmorGenerator.GenerateFrom(template) as Armor;

            gear.CloneInto(armor);

            if (armor.IsMagical)
                armor.Traits.Add(TraitConstants.Masterwork);

            return armor as Armor;
        }

        private Weapon GetWeapon(Item gear)
        {
            var template = new Weapon();
            template.Name = gear.BaseNames.First();

            var mundaneWeaponGenerator = justInTimeFactory.Build<MundaneItemGenerator>(ItemTypeConstants.Weapon);
            var mundaneWeapon = mundaneWeaponGenerator.GenerateFrom(template) as Weapon;
            var weapon = new Weapon();

            gear.CloneInto(weapon);

            weapon.Quantity = mundaneWeapon.Quantity;
            weapon.Ammunition = mundaneWeapon.Ammunition;
            weapon.CriticalMultiplier = mundaneWeapon.CriticalMultiplier;
            weapon.Damage = mundaneWeapon.Damage;
            weapon.DamageType = mundaneWeapon.DamageType;
            weapon.Size = mundaneWeapon.Size;
            weapon.ThreatRange = mundaneWeapon.ThreatRange;

            if (weapon.IsMagical)
                weapon.Traits.Add(TraitConstants.Masterwork);

            if (weapon.Attributes.Contains(AttributeConstants.Ammunition) || weapon.Attributes.Contains(AttributeConstants.OneTimeUse))
                weapon.Magic.Intelligence = new Intelligence();

            return weapon as Weapon;
        }

        private string RenameGear(string oldName)
        {
            switch (oldName)
            {
                case WeaponConstants.SilverDagger: return WeaponConstants.Dagger;
                case WeaponConstants.LuckBlade0: return WeaponConstants.LuckBlade;
                case WeaponConstants.LuckBlade1: return WeaponConstants.LuckBlade;
                case WeaponConstants.LuckBlade2: return WeaponConstants.LuckBlade;
                case WeaponConstants.LuckBlade3: return WeaponConstants.LuckBlade;
                default: return oldName;
            }
        }

        private IEnumerable<SpecialAbility> GetSpecialAbilities(string specificGearType, string name)
        {
            var tableName = string.Format(TableNameConstants.Collections.Formattable.SpecificITEMTYPESpecialAbilities, specificGearType);
            var abilityNames = collectionsSelector.SelectFrom(tableName, name);
            var abilityPrototypes = abilityNames.Select(n => new SpecialAbility { Name = n });
            var abilities = specialAbilitiesGenerator.GenerateFor(abilityPrototypes);

            return abilities;
        }

        public Item GenerateFrom(Item template)
        {
            var gear = template.Clone();

            var specificGearType = GetSpecificGearType(gear.Name);
            gear.ItemType = GetItemType(specificGearType);
            gear.BaseNames = collectionsSelector.SelectFrom(TableNameConstants.Collections.Set.ItemGroups, gear.Name);

            gear = SetPrototypeAttributes(gear, specificGearType);

            return gear;
        }

        private string GetItemType(string specificGearType)
        {
            if (specificGearType == ItemTypeConstants.Weapon)
                return ItemTypeConstants.Weapon;

            return ItemTypeConstants.Armor;
        }

        private string GetSpecificGearType(string name)
        {
            var gearType = collectionsSelector.FindCollectionOf(TableNameConstants.Collections.Set.ItemGroups, name, AttributeConstants.Shield, ItemTypeConstants.Armor, ItemTypeConstants.Weapon);
            return gearType;
        }

        public bool IsSpecific(Item template)
        {
            var specificItems = collectionsSelector.SelectFrom(TableNameConstants.Collections.Set.ItemGroups, AttributeConstants.Specific);
            return specificItems.Contains(template.Name);
        }
    }
}