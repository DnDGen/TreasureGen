using RollGen;
using System;
using TreasureGen.Domain.Selectors.Attributes;
using TreasureGen.Domain.Selectors.Percentiles;
using TreasureGen.Domain.Tables;
using TreasureGen.Items;
using TreasureGen.Items.Magical;

namespace TreasureGen.Domain.Generators.Items.Magical
{
    internal class ChargesGenerator : IChargesGenerator
    {
        private Dice dice;
        private IRangeAttributesSelector rangeAttributesSelector;
        private IBooleanPercentileSelector booleanPercentileSelector;

        public ChargesGenerator(Dice dice, IRangeAttributesSelector rangeAttributesSelector, IBooleanPercentileSelector booleanPercentileSelector)
        {
            this.dice = dice;
            this.rangeAttributesSelector = rangeAttributesSelector;
            this.booleanPercentileSelector = booleanPercentileSelector;
        }

        public int GenerateFor(string itemType, string name)
        {
            if (itemType == ItemTypeConstants.Wand || itemType == ItemTypeConstants.Staff)
                return PercentileCharges();

            if (name == WondrousItemConstants.DeckOfIllusions)
            {
                var isFullyCharged = booleanPercentileSelector.SelectFrom(TableNameConstants.Percentiles.Set.IsDeckOfIllusionsFullyCharged);

                if (isFullyCharged)
                    name = WondrousItemConstants.FullDeckOfIllusions;
            }

            var result = rangeAttributesSelector.SelectFrom(TableNameConstants.Attributes.Set.ChargeLimits, name);
            var die = result.Maximum - result.Minimum + 1;

            return dice.Roll().d(die) - 1 + result.Minimum;
        }

        private int PercentileCharges()
        {
            var roll = dice.Roll().Percentile();
            return Math.Max(roll / 2, 1);
        }
    }
}