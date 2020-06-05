using DnDGen.TreasureGen.Items;
using DnDGen.TreasureGen.Selectors.Percentiles;
using DnDGen.TreasureGen.Tables;
using DnDGen.TreasureGen.Tests.Integration.Generators.Items;
using Ninject;
using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;

namespace DnDGen.TreasureGen.Tests.Integration.Tables.Items
{
    [TestFixture]
    public class PowerGroupsTests : CollectionsTests
    {
        [Inject]
        internal ITypeAndAmountPercentileSelector TypeAndAmountPercentileSelector { get; set; }
        [Inject]
        internal IReplacementSelector ReplacementSelector { get; set; }

        protected override string tableName
        {
            get
            {
                return TableNameConstants.Collections.Set.PowerGroups;
            }
        }

        [TestCase(ItemTypeConstants.AlchemicalItem,
            PowerConstants.Mundane)]
        [TestCase(ItemTypeConstants.Armor,
            PowerConstants.Mundane,
            PowerConstants.Minor,
            PowerConstants.Medium,
            PowerConstants.Major)]
        [TestCase(ItemTypeConstants.Potion,
            PowerConstants.Minor,
            PowerConstants.Medium,
            PowerConstants.Major)]
        [TestCase(ItemTypeConstants.Ring,
            PowerConstants.Minor,
            PowerConstants.Medium,
            PowerConstants.Major)]
        [TestCase(ItemTypeConstants.Rod,
            PowerConstants.Medium,
            PowerConstants.Major)]
        [TestCase(ItemTypeConstants.Scroll,
            PowerConstants.Minor,
            PowerConstants.Medium,
            PowerConstants.Major)]
        [TestCase(ItemTypeConstants.Staff,
            PowerConstants.Medium,
            PowerConstants.Major)]
        [TestCase(ItemTypeConstants.Tool,
            PowerConstants.Mundane)]
        [TestCase(ItemTypeConstants.Wand,
            PowerConstants.Minor,
            PowerConstants.Medium,
            PowerConstants.Major)]
        [TestCase(ItemTypeConstants.Weapon,
            PowerConstants.Mundane,
            PowerConstants.Minor,
            PowerConstants.Medium,
            PowerConstants.Major)]
        [TestCase(ItemTypeConstants.WondrousItem,
            PowerConstants.Minor,
            PowerConstants.Medium,
            PowerConstants.Major)]
        public void PowerGroup(string name, params string[] powers)
        {
            base.Collections(name, powers);
        }

        [TestCaseSource(typeof(ItemTestData), "AlchemicalItems")]
        public void AlchemicalItemPowerGroupsMatch(string itemName)
        {
            var powers = table[ItemTypeConstants.AlchemicalItem];
            base.Collections(itemName, powers.ToArray());
        }

        [TestCaseSource(typeof(ItemTestData), "Armors")]
        public void ArmorPowerGroupsMatch(string itemName)
        {
            var possiblePowers = new List<string>();
            var powers = table[ItemTypeConstants.Armor];
            possiblePowers.AddRange(powers);

            var generalArmors = ArmorConstants.GetAllArmorsAndShields(false);
            var shields = ArmorConstants.GetAllShields(true);
            var cursed = ????

            if (!generalArmors.Contains(itemName))
            {
                var gearType = shields.Contains(itemName) ? AttributeConstants.Shield : ItemTypeConstants.Armor;
                possiblePowers.Remove(PowerConstants.Mundane);

                foreach (var power in powers.Except(new[] { PowerConstants.Mundane }))
                {
                    var tableName = string.Format(TableNameConstants.Percentiles.Formattable.POWERSpecificITEMTYPEs, power, gearType);
                    var results = TypeAndAmountPercentileSelector.SelectAllFrom(tableName);

                    if (!results.Any(r => NameMatchesWithReplacements(r.Type, itemName)))
                        possiblePowers.Remove(power);
                }
            }

            base.Collections(itemName, possiblePowers.ToArray());
        }

        [TestCaseSource(typeof(ItemTestData), "Potions")]
        public void PotionPowerGroupsMatch(string itemName)
        {
            var possiblePowers = new List<string>();
            var powers = table[ItemTypeConstants.Potion];

            foreach (var power in powers)
            {
                var tableName = string.Format(TableNameConstants.Percentiles.Formattable.POWERITEMTYPEs, power, ItemTypeConstants.Potion);
                var results = TypeAndAmountPercentileSelector.SelectAllFrom(tableName);

                if (results.Any(r => NameMatchesWithReplacements(r.Type, itemName)))
                    possiblePowers.Add(power);
            }

            base.Collections(itemName, possiblePowers.ToArray());
        }

        private bool NameMatchesWithReplacements(string source, string target)
        {
            var sourceReplacements = ReplacementSelector.SelectAll(source);
            var targetReplacements = ReplacementSelector.SelectAll(target);

            return source == target
                || sourceReplacements.Any(s => s == target)
                || targetReplacements.Any(t => t == source);
        }

        [TestCaseSource(typeof(ItemTestData), "Rings")]
        public void RingPowerGroupsMatch(string itemName)
        {
            var possiblePowers = new List<string>();
            var powers = table[ItemTypeConstants.Ring];

            foreach (var power in powers)
            {
                var tableName = string.Format(TableNameConstants.Percentiles.Formattable.POWERITEMTYPEs, power, ItemTypeConstants.Ring);
                var results = TypeAndAmountPercentileSelector.SelectAllFrom(tableName);

                if (results.Any(r => NameMatchesWithReplacements(r.Type, itemName)))
                    possiblePowers.Add(power);
            }

            base.Collections(itemName, possiblePowers.ToArray());
        }

        [TestCaseSource(typeof(ItemTestData), "Rods")]
        public void RodPowerGroupsMatch(string itemName)
        {
            var possiblePowers = new List<string>();
            var powers = table[ItemTypeConstants.Rod];

            foreach (var power in powers)
            {
                var tableName = string.Format(TableNameConstants.Percentiles.Formattable.POWERITEMTYPEs, power, ItemTypeConstants.Rod);
                var results = TypeAndAmountPercentileSelector.SelectAllFrom(tableName);

                if (results.Any(r => NameMatchesWithReplacements(r.Type, itemName)))
                    possiblePowers.Add(power);
            }

            base.Collections(itemName, possiblePowers.ToArray());
        }

        [TestCaseSource(typeof(ItemTestData), "Staffs")]
        public void StaffPowerGroupsMatch(string itemName)
        {
            var possiblePowers = new List<string>();
            var powers = table[ItemTypeConstants.Staff];

            foreach (var power in powers)
            {
                var tableName = string.Format(TableNameConstants.Percentiles.Formattable.POWERITEMTYPEs, power, ItemTypeConstants.Staff);
                var results = TypeAndAmountPercentileSelector.SelectAllFrom(tableName);

                if (results.Any(r => NameMatchesWithReplacements(r.Type, itemName)))
                    possiblePowers.Add(power);
            }

            base.Collections(itemName, possiblePowers.ToArray());
        }

        [TestCaseSource(typeof(ItemTestData), "Tools")]
        public void ToolPowerGroupsMatch(string itemName)
        {
            var powers = table[ItemTypeConstants.Tool];
            base.Collections(itemName, powers.ToArray());
        }

        [TestCaseSource(typeof(ItemTestData), "Weapons")]
        public void WeaponPowerGroupsMatch(string itemName)
        {
            var possiblePowers = new List<string>();
            var powers = table[ItemTypeConstants.Weapon];
            possiblePowers.AddRange(powers);

            var generalWeapons = WeaponConstants.GetAllWeapons(false, true);

            if (!generalWeapons.Contains(itemName))
            {
                possiblePowers.Remove(PowerConstants.Mundane);

                foreach (var power in powers)
                {
                    var tableName = string.Format(TableNameConstants.Percentiles.Formattable.POWERSpecificITEMTYPEs, power, ItemTypeConstants.Weapon);
                    var results = TypeAndAmountPercentileSelector.SelectAllFrom(tableName);

                    if (!results.Any(r => NameMatchesWithReplacements(r.Type, itemName)))
                        possiblePowers.Remove(power);
                }
            }

            base.Collections(itemName, possiblePowers.ToArray());
        }

        [TestCaseSource(typeof(ItemTestData), "WondrousItems")]
        public void WondrousItemPowerGroupsMatch(string itemName)
        {
            var possiblePowers = new List<string>();
            var powers = table[ItemTypeConstants.WondrousItem];

            foreach (var power in powers)
            {
                var tableName = string.Format(TableNameConstants.Percentiles.Formattable.POWERITEMTYPEs, power, ItemTypeConstants.WondrousItem);
                var results = TypeAndAmountPercentileSelector.SelectAllFrom(tableName);

                if (results.Any(r => NameMatchesWithReplacements(r.Type, itemName)))
                    possiblePowers.Add(power);
            }

            base.Collections(itemName, possiblePowers.ToArray());
        }
    }
}
