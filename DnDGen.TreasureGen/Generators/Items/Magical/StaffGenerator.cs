using DnDGen.Infrastructure.Generators;
using DnDGen.Infrastructure.Selectors.Collections;
using DnDGen.TreasureGen.Items;
using DnDGen.TreasureGen.Items.Magical;
using DnDGen.TreasureGen.Items.Mundane;
using DnDGen.TreasureGen.Selectors.Percentiles;
using DnDGen.TreasureGen.Tables;
using System;
using System.Linq;

namespace DnDGen.TreasureGen.Generators.Items.Magical
{
    internal class StaffGenerator : MagicalItemGenerator
    {
        private readonly ITypeAndAmountPercentileSelector typeAndAmountPercentileSelector;
        private readonly IChargesGenerator chargesGenerator;
        private readonly ICollectionSelector collectionsSelector;
        private readonly ISpecialAbilitiesGenerator specialAbilitiesGenerator;
        private readonly JustInTimeFactory justInTimeFactory;

        public StaffGenerator(ITypeAndAmountPercentileSelector typeAndAmountPercentileSelector,
            IChargesGenerator chargesGenerator,
            ICollectionSelector collectionsSelector,
            ISpecialAbilitiesGenerator specialAbilitiesGenerator,
            JustInTimeFactory justInTimeFactory)
        {
            this.typeAndAmountPercentileSelector = typeAndAmountPercentileSelector;
            this.chargesGenerator = chargesGenerator;
            this.collectionsSelector = collectionsSelector;
            this.specialAbilitiesGenerator = specialAbilitiesGenerator;
            this.justInTimeFactory = justInTimeFactory;
        }

        public Item GenerateFrom(string power)
        {
            if (power == PowerConstants.Minor)
                throw new ArgumentException("Cannot generate minor staves");

            var tablename = string.Format(TableNameConstants.Percentiles.Formattable.POWERITEMTYPEs, power, ItemTypeConstants.Staff);
            var selection = typeAndAmountPercentileSelector.SelectFrom(tablename);

            return GenerateStaff(selection.Type, selection.Amount);
        }

        private Item GenerateStaff(string name, int bonus)
        {
            var staff = new Item();
            staff.Name = name;
            staff.Magic.Bonus = bonus;
            staff = BuildStaff(staff);
            staff.Magic.Charges = chargesGenerator.GenerateFor(staff.ItemType, name);

            return staff;
        }

        public Item GenerateFrom(string power, string itemName)
        {
            if (power == PowerConstants.Minor)
                throw new ArgumentException("Cannot generate minor staves");

            var tablename = string.Format(TableNameConstants.Percentiles.Formattable.POWERITEMTYPEs, power, ItemTypeConstants.Staff);
            var selections = typeAndAmountPercentileSelector.SelectAllFrom(tablename);
            var matches = selections.Where(s => s.Type == itemName).ToList();

            if (!matches.Any())
            {
                foreach (var result in selections)
                {
                    var baseNames = collectionsSelector.SelectFrom(TableNameConstants.Collections.Set.ItemGroups, result.Type);
                    if (baseNames.Contains(itemName))
                        matches.Add(result);
                }
            }

            if (!matches.Any())
            {
                throw new ArgumentException($"{itemName} is not a valid {power} Staff");
            }

            var selection = collectionsSelector.SelectRandomFrom(matches);
            return GenerateStaff(selection.Type, selection.Amount);
        }

        private Item BuildStaff(Item staff)
        {
            staff.ItemType = ItemTypeConstants.Staff;
            staff.Attributes = new[] { AttributeConstants.Charged, AttributeConstants.OneTimeUse };
            staff.Quantity = 1;
            staff.IsMagical = true;
            staff.BaseNames = collectionsSelector.SelectFrom(TableNameConstants.Collections.Set.ItemGroups, staff.Name);

            staff = GetWeapon(staff);

            return staff;
        }

        private Item GetWeapon(Item staff)
        {
            var weapons = WeaponConstants.GetBaseNames();
            if (!weapons.Intersect(staff.BaseNames).Any())
                return staff;

            var weaponName = weapons.Intersect(staff.BaseNames).First();

            var mundaneWeaponGenerator = justInTimeFactory.Build<MundaneItemGenerator>(ItemTypeConstants.Weapon);
            var mundaneWeapon = mundaneWeaponGenerator.Generate(weaponName);

            staff.Attributes = staff.Attributes.Union(mundaneWeapon.Attributes).Except(new[] { AttributeConstants.OneTimeUse });
            staff.CloneInto(mundaneWeapon);

            if (mundaneWeapon.IsMagical)
                mundaneWeapon.Traits.Add(TraitConstants.Masterwork);

            return mundaneWeapon;
        }

        public Item GenerateFrom(Item template, bool allowRandomDecoration = false)
        {
            var staff = template.Clone();
            staff = BuildStaff(staff);

            staff.Magic.Intelligence = template.Magic.Intelligence.Clone();
            staff.Magic.SpecialAbilities = specialAbilitiesGenerator.GenerateFor(template.Magic.SpecialAbilities);

            return staff.SmartClone();
        }

        public bool IsItemOfPower(string itemName, string power)
        {
            if (power == PowerConstants.Minor)
                return false;

            var tablename = string.Format(TableNameConstants.Percentiles.Formattable.POWERITEMTYPEs, power, ItemTypeConstants.Staff);
            var results = typeAndAmountPercentileSelector.SelectAllFrom(tablename);
            var matches = results.Where(r => r.Type == itemName);

            if (results.Any(r => r.Type == itemName))
                return true;

            foreach (var result in results)
            {
                var baseNames = collectionsSelector.SelectFrom(TableNameConstants.Collections.Set.ItemGroups, result.Type);
                if (baseNames.Contains(itemName))
                    return true;
            }

            return false;
        }
    }
}