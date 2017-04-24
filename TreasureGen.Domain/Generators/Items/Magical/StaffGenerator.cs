using System;
using System.Collections.Generic;
using System.Linq;
using TreasureGen.Domain.Selectors.Collections;
using TreasureGen.Domain.Selectors.Percentiles;
using TreasureGen.Domain.Tables;
using TreasureGen.Items;
using TreasureGen.Items.Magical;

namespace TreasureGen.Domain.Generators.Items.Magical
{
    internal class StaffGenerator : MagicalItemGenerator
    {
        private readonly IPercentileSelector percentileSelector;
        private readonly IChargesGenerator chargesGenerator;
        private readonly ICollectionsSelector collectionsSelector;
        private readonly ISpecialAbilitiesGenerator specialAbilitiesGenerator;
        private readonly Generator generator;

        public StaffGenerator(IPercentileSelector percentileSelector, IChargesGenerator chargesGenerator, ICollectionsSelector collectionsSelector, ISpecialAbilitiesGenerator specialAbilitiesGenerator, Generator generator)
        {
            this.percentileSelector = percentileSelector;
            this.chargesGenerator = chargesGenerator;
            this.collectionsSelector = collectionsSelector;
            this.specialAbilitiesGenerator = specialAbilitiesGenerator;
            this.generator = generator;
        }

        public Item GenerateAtPower(string power)
        {
            if (power == PowerConstants.Minor)
                throw new ArgumentException("Cannot generate minor staves");

            var tablename = string.Format(TableNameConstants.Percentiles.Formattable.POWERITEMTYPEs, power, ItemTypeConstants.Staff);
            var staffName = percentileSelector.SelectFrom(tablename);

            var staff = new Item();
            staff.Name = staffName;
            staff.ItemType = ItemTypeConstants.Staff;
            staff.Attributes = new[] { AttributeConstants.OneTimeUse, AttributeConstants.Charged };
            staff = BuildStaff(staff);
            staff.Magic.Charges = chargesGenerator.GenerateFor(staff.ItemType, staffName);

            return staff;
        }

        private Item BuildStaff(Item staff)
        {
            staff.Quantity = 1;
            staff.IsMagical = true;
            staff.BaseNames = collectionsSelector.SelectFrom(TableNameConstants.Collections.Set.ItemGroups, staff.Name);

            if (staff.Name != StaffConstants.Power)
                return staff;

            var tablename = string.Format(TableNameConstants.Collections.Formattable.ITEMTYPEAttributes, ItemTypeConstants.Weapon);
            var quarterstaffAttributes = collectionsSelector.SelectFrom(tablename, WeaponConstants.Quarterstaff);
            staff.Attributes = staff.Attributes.Union(quarterstaffAttributes).Except(new[] { AttributeConstants.OneTimeUse });

            if (staff.Name == StaffConstants.Power)
                staff.Magic.Bonus = 2;

            return staff;
        }

        public Item Generate(Item template, bool allowRandomDecoration = false)
        {
            var staff = template.Clone();
            staff.ItemType = ItemTypeConstants.Staff;
            staff.Attributes = new[] { AttributeConstants.Charged, AttributeConstants.OneTimeUse };
            staff = BuildStaff(staff);

            staff.Magic.Intelligence = template.Magic.Intelligence.Clone();
            staff.Magic.SpecialAbilities = specialAbilitiesGenerator.GenerateFor(template.Magic.SpecialAbilities);

            return staff.SmartClone();
        }

        public Item GenerateFromSubset(string power, IEnumerable<string> subset)
        {
            if (power == PowerConstants.Minor)
                throw new ArgumentException("Cannot generate minor staffs");

            var staff = generator.Generate(
                () => GenerateAtPower(power),
                s => subset.Any(n => s.NameMatches(n)),
                () => GenerateDefaultFrom(subset),
                $"Staff from [{string.Join(", ", subset)}]");

            return staff;
        }

        private Item GenerateDefaultFrom(IEnumerable<string> subset)
        {
            var template = new Item();
            template.Name = collectionsSelector.SelectRandomFrom(subset);
            template.Magic.Charges = chargesGenerator.GenerateFor(ItemTypeConstants.Staff, template.Name);

            var defaultStaff = Generate(template);

            return defaultStaff;
        }
    }
}