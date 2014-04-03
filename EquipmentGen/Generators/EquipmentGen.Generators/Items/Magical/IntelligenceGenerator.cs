using System;
using System.Collections.Generic;
using System.Linq;
using D20Dice;
using EquipmentGen.Common.Items;
using EquipmentGen.Generators.Interfaces.Items.Magical;
using EquipmentGen.Selectors.Interfaces;

namespace EquipmentGen.Generators.Items.Magical
{
    public class IntelligenceGenerator : IIntelligenceGenerator
    {
        private IDice dice;
        private IPercentileSelector percentileSelector;
        private IAttributesSelector attributesSelector;

        public IntelligenceGenerator(IDice dice, IPercentileSelector percentileSelector, IAttributesSelector attributesSelector)
        {
            this.dice = dice;
            this.percentileSelector = percentileSelector;
            this.attributesSelector = attributesSelector;
        }

        public Boolean IsIntelligent(String itemType, IEnumerable<String> attributes, Dictionary<Magic, Object> magic)
        {
            if (!magic.Any())
                return false;

            if (attributes.Contains(AttributeConstants.OneTimeUse))
                return false;

            var roll = dice.Percentile();
            var upperLimit = GetUpperLimitFor(itemType);

            return roll <= upperLimit;
        }

        private Int32 GetUpperLimitFor(String itemType)
        {
            switch (itemType)
            {
                case ItemTypeConstants.Ring:
                case ItemTypeConstants.Rod:
                case ItemTypeConstants.WondrousItem:
                case ItemTypeConstants.Armor: return 1;
                case AttributeConstants.Ranged: return 5;
                case AttributeConstants.Melee: return 15;
                default: return 0;
            }
        }

        public Intelligence GenerateFor(Dictionary<Magic, Object> magic)
        {
            var roll = dice.Percentile();
            var highStatResult = percentileSelector.SelectFrom("IntelligenceStrongStat", roll);
            var highStat = Convert.ToInt32(highStatResult);

            var intelligence = new Intelligence();
            intelligence.Ego += (highStat - 10) / 2 * 2;

            if (magic.ContainsKey(Magic.Bonus))
                intelligence.Ego += Convert.ToInt32(magic[Magic.Bonus]);

            if (magic.ContainsKey(Magic.Abilities))
            {
                var abilities = magic[Magic.Abilities] as IEnumerable<SpecialAbility>;
                foreach (var ability in abilities)
                    intelligence.Ego += ability.BonusEquivalent;
            }

            switch (dice.d3())
            {
                case 1: intelligence.CharismaStat = 10; break;
                case 2: intelligence.IntelligenceStat = 10; break;
                case 3: intelligence.WisdomStat = 10; break;
            }

            if (intelligence.CharismaStat == 0)
                intelligence.CharismaStat = highStat;

            if (intelligence.IntelligenceStat == 0)
                intelligence.IntelligenceStat = highStat;

            if (intelligence.WisdomStat == 0)
                intelligence.WisdomStat = highStat;

            intelligence.Communication = attributesSelector.SelectFrom("IntelligenceCommunication", highStatResult);

            if (intelligence.Communication.Contains("Speech"))
                intelligence.Languages = GenerateLanguages(intelligence.IntelligenceStat);

            if (intelligence.Communication.Contains("Read"))
                intelligence.Ego++;

            if (intelligence.Communication.Contains("Read magic"))
                intelligence.Ego++;

            if (intelligence.Communication.Contains("Telepathy"))
                intelligence.Ego++;

            intelligence.Senses = attributesSelector.SelectFrom("IntelligenceSenses", highStatResult).First();

            var lesserPowers = GeneratePowers("Lesser", highStatResult);
            intelligence.Ego += lesserPowers.Count;
            intelligence.Powers.AddRange(lesserPowers);

            var greaterPowers = GeneratePowers("Greater", highStatResult);

            if (dice.d4() <= greaterPowers.Count())
            {
                greaterPowers.RemoveAt(greaterPowers.Count - 1);

                roll = dice.Percentile();
                intelligence.SpecialPurpose = percentileSelector.SelectFrom("IntelligenceSpecialPurpose", roll);

                roll = dice.Percentile();
                intelligence.DedicatedPower = percentileSelector.SelectFrom("IntelligenceDedicatedPower", roll);

                intelligence.Ego += 4;
            }

            intelligence.Ego += greaterPowers.Count * 2;
            intelligence.Powers.AddRange(greaterPowers);

            roll = dice.Percentile();
            intelligence.Alignment = percentileSelector.SelectFrom("IntelligenceAlignments", roll);

            roll = dice.Percentile();
            intelligence.Personality = percentileSelector.SelectFrom("PersonalityTraits", roll);

            return intelligence;
        }

        private List<String> GenerateLanguages(Int32 intelligenceStat)
        {
            var modifier = (intelligenceStat - 10) / 2;
            var languages = GetNonDuplicateList("Languages", modifier);
            languages.Add("Common");

            return languages;
        }

        private List<String> GeneratePowers(String strength, String highStatResult)
        {
            var tableName = String.Format("Intelligence{0}PowersCount", strength);
            var powersResult = attributesSelector.SelectFrom(tableName, highStatResult).First();
            var powersCount = Convert.ToInt32(powersResult);

            tableName = String.Format("Intelligence{0}Powers", strength);

            return GetNonDuplicateList(tableName, powersCount);
        }

        private List<String> GetNonDuplicateList(String tableName, Int32 quantity)
        {
            var list = new List<String>();

            while (list.Count < quantity)
            {
                var roll = dice.Percentile(1);
                var power = percentileSelector.SelectFrom(tableName, roll);

                if (list.Contains(power))
                    continue;

                list.Add(power);
            }

            return list;
        }
    }
}