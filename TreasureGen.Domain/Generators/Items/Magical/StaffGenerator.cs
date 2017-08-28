using DnDGen.Core.Generators;
using DnDGen.Core.Selectors.Collections;
using System;
using System.Collections.Generic;
using System.Linq;
using TreasureGen.Domain.Selectors.Percentiles;
using TreasureGen.Domain.Selectors.Selections;
using TreasureGen.Domain.Tables;
using TreasureGen.Items;
using TreasureGen.Items.Magical;
using TreasureGen.Items.Mundane;

namespace TreasureGen.Domain.Generators.Items.Magical
{
    internal class StaffGenerator : MagicalItemGenerator
    {
        private readonly ITypeAndAmountPercentileSelector typeAndAmountPercentileSelector;
        private readonly IChargesGenerator chargesGenerator;
        private readonly ICollectionsSelector collectionsSelector;
        private readonly ISpecialAbilitiesGenerator specialAbilitiesGenerator;
        private readonly Generator generator;
        private readonly JustInTimeFactory justInTimeFactory;

        public StaffGenerator(ITypeAndAmountPercentileSelector typeAndAmountPercentileSelector,
            IChargesGenerator chargesGenerator,
            ICollectionsSelector collectionsSelector,
            ISpecialAbilitiesGenerator specialAbilitiesGenerator,
            Generator generator,
            JustInTimeFactory justInTimeFactory)
        {
            this.typeAndAmountPercentileSelector = typeAndAmountPercentileSelector;
            this.chargesGenerator = chargesGenerator;
            this.collectionsSelector = collectionsSelector;
            this.specialAbilitiesGenerator = specialAbilitiesGenerator;
            this.generator = generator;
            this.justInTimeFactory = justInTimeFactory;
        }

        public Item GenerateFrom(string power)
        {
            if (power == PowerConstants.Minor)
                throw new ArgumentException("Cannot generate minor staves");

            var tablename = string.Format(TableNameConstants.Percentiles.Formattable.POWERITEMTYPEs, power, ItemTypeConstants.Staff);
            var selection = typeAndAmountPercentileSelector.SelectFrom(tablename);

            var staff = new Item();
            staff.Name = selection.Type;
            staff.Magic.Bonus = selection.Amount;
            staff = BuildStaff(staff);
            staff.Magic.Charges = chargesGenerator.GenerateFor(staff.ItemType, staff.Name);

            return staff;
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

            var template = new Weapon();
            template.Name = weapons.Intersect(staff.BaseNames).First();

            var mundaneWeaponGenerator = justInTimeFactory.Build<MundaneItemGenerator>(ItemTypeConstants.Weapon);
            var mundaneWeapon = mundaneWeaponGenerator.GenerateFrom(template);

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

        public Item GenerateFrom(string power, IEnumerable<string> subset)
        {
            if (power == PowerConstants.Minor)
                throw new ArgumentException("Cannot generate minor staffs");

            var staff = generator.Generate(
                () => GenerateFrom(power),
                s => subset.Any(n => s.NameMatches(n)),
                () => CreateDefaultStaff(power, subset),
                s => $"{s.Name} is not in subset [{string.Join(", ", subset)}]",
                $"{power} Staff from [{string.Join(", ", subset)}]");

            return staff;
        }

        private Item CreateDefaultStaff(string power, IEnumerable<string> subset)
        {
            var template = new Item();
            template.Name = collectionsSelector.SelectRandomFrom(subset);
            template.Magic.Charges = chargesGenerator.GenerateFor(ItemTypeConstants.Staff, template.Name);

            var tablename = string.Format(TableNameConstants.Percentiles.Formattable.POWERITEMTYPEs, power, ItemTypeConstants.Staff);
            var allSelections = typeAndAmountPercentileSelector.SelectAllFrom(tablename);
            var selection = allSelections.FirstOrDefault(s => s.Type == template.Name);

            if (selection == null)
                selection = GetSelectionFromAllPowers(template.Name);

            template.Magic.Bonus = selection.Amount;

            var defaultStaff = GenerateFrom(template);

            return defaultStaff;
        }

        private TypeAndAmountSelection GetSelectionFromAllPowers(string name)
        {
            var tablename = string.Format(TableNameConstants.Percentiles.Formattable.POWERITEMTYPEs, PowerConstants.Medium, ItemTypeConstants.Staff);
            var mediumStaves = typeAndAmountPercentileSelector.SelectAllFrom(tablename);

            tablename = string.Format(TableNameConstants.Percentiles.Formattable.POWERITEMTYPEs, PowerConstants.Major, ItemTypeConstants.Staff);
            var majorStaves = typeAndAmountPercentileSelector.SelectAllFrom(tablename);

            var staves = mediumStaves.Union(majorStaves);
            return staves.First(s => s.Type == name);
        }
    }
}