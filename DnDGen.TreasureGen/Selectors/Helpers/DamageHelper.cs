using DnDGen.TreasureGen.Selectors.Selections;
using DnDGen.TreasureGen.Tables;
using System.Collections.Generic;

namespace DnDGen.TreasureGen.Selectors.Helpers
{
    public class DamageHelper : DataHelper
    {
        public DamageHelper()
            : base(WeaponSelection.DamageDivider)
        { }

        public string[] BuildData(string roll, string type)
        {
            var data = DataIndexConstants.Weapon.DamageData.InitializeData();

            data[DataIndexConstants.Weapon.DamageData.RollIndex] = roll;
            data[DataIndexConstants.Weapon.DamageData.TypeIndex] = type;

            return data;
        }

        public override string BuildKey(string creature, string[] data)
        {
            return BuildKeyFromSections(creature,
                data[DataIndexConstants.Weapon.DamageData.RollIndex],
                data[DataIndexConstants.Weapon.DamageData.TypeIndex]);
        }

        public override bool ValidateEntry(string entry)
        {
            var data = ParseEntry(entry);
            var init = DataIndexConstants.Weapon.DamageData.InitializeData();
            return data.Length == init.Length;
        }

        public bool ValidateEntries(string entries)
        {
            var datas = ParseEntries(entries);
            var init = DataIndexConstants.Weapon.DamageData.InitializeData();
            var valid = true;

            foreach (var data in datas)
            {
                valid &= data.Length == 0 || data.Length == init.Length;
            }

            return valid;
        }

        public string BuildEntries(params string[] data)
        {
            var entries = new List<string>();

            for (var i = 0; i < data.Length; i += 2)
            {
                var entry = BuildEntry(data[i], data[i + 1]);
                entries.Add(entry);
            }

            return string.Join(WeaponSelection.DamageSplitDivider.ToString(), entries);
        }

        public string[][] ParseEntries(string entry)
        {
            if (string.IsNullOrEmpty(entry))
                return new string[0][];

            var entries = entry.Split(WeaponSelection.DamageSplitDivider);
            var data = new string[entries.Length][];

            for (var i = 0; i < entries.Length; i++)
            {
                data[i] = ParseEntry(entries[i]);
            }

            return data;
        }
    }
}
