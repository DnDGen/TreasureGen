using System;
using System.Collections.Generic;
using System.Linq;
using TreasureGen.Common;
using TreasureGen.Common.Goods;
using TreasureGen.Common.Items;

namespace TreasureGen.Tests.Integration.Stress.Items.Magical
{
    public class InterestFormatter
    {
        public String MakeOutput(Treasure treasure)
        {
            var output = "Most interesting treasure:";
            output += AddOutput("Coin Type", treasure.Coin.Currency);
            output += AddOutput("Coin Amount", treasure.Coin.Quantity);
            output += AddOutput("Goods", treasure.Goods);
            output += AddOutput("Items", treasure.Items);

            return output;
        }

        private String AddOutput(String title, IEnumerable<Good> values)
        {
            if (!values.Any())
                return String.Empty;

            var output = String.Format("\n{0}:", title);
            foreach (var value in values)
                output += String.Format("\n\t{0} ({1})", value.Description, value.ValueInGold);

            return output;
        }

        private String AddOutput(String title, IEnumerable<Item> values)
        {
            if (!values.Any())
                return String.Empty;

            var output = String.Format("\n{0}:", title);
            foreach (var value in values)
                output += String.Format("\n\t{0}", AddOutput(value));

            return output;
        }

        private String AddOutput(Item item)
        {
            var output = String.Format("Name: {0}", item.Name);
            output += AddOutput("Contents", item.Contents);
            output += AddOutput("Bonus", item.Magic.Bonus);
            output += AddOutput("Charges", item.Magic.Charges);
            output += AddOutput("Curse", item.Magic.Curse);
            output += AddOutput("Special abilities", item.Magic.SpecialAbilities);
            output += AddOutput("Intelligence alignment", item.Magic.Intelligence.Alignment);
            output += AddOutput("Intelligence charisma", item.Magic.Intelligence.CharismaStat);
            output += AddOutput("Intelligence communication", item.Magic.Intelligence.Communication);
            output += AddOutput("Intelligence dedicated power", item.Magic.Intelligence.DedicatedPower);
            output += AddOutput("Intelligence intelligence", item.Magic.Intelligence.IntelligenceStat);
            output += AddOutput("Intelligence languages", item.Magic.Intelligence.Languages);
            output += AddOutput("Intelligence personality", item.Magic.Intelligence.Personality);
            output += AddOutput("Intelligence powers", item.Magic.Intelligence.Powers);
            output += AddOutput("Intelligence senses", item.Magic.Intelligence.Senses);
            output += AddOutput("Intelligence special purpose", item.Magic.Intelligence.SpecialPurpose);
            output += AddOutput("Intelligence wisdom", item.Magic.Intelligence.WisdomStat);
            output += AddOutput("Quantity", item.Quantity);
            output += AddOutput("Traits", item.Traits);

            return output;
        }

        public String MakeOutput(Item item)
        {
            var output = "Most interesting item:";
            output += AddOutput(item);

            return output;
        }

        private String AddOutput(String title, Int32 value)
        {
            if (value > 0)
                return String.Format("\n{0}: {1}", title, value);

            return String.Empty;
        }

        private String AddOutput(String title, String value)
        {
            if (value.Any())
                return String.Format("\n{0}: {1}", title, value);

            return String.Empty;
        }

        private String AddOutput(String title, IEnumerable<String> values)
        {
            if (!values.Any())
                return String.Empty;

            var output = String.Format("\n{0}:", title);
            foreach (var value in values)
                output += String.Format("\n\t{0}", value);

            return output;
        }

        private String AddOutput(String title, IEnumerable<SpecialAbility> values)
        {
            if (!values.Any())
                return String.Empty;

            var output = String.Format("\n{0}:", title);
            foreach (var value in values)
                output += String.Format("\n\t{0}", value.Name);

            return output;
        }
    }
}