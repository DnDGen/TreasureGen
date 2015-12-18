using RollGen;
using System;
using TreasureGen.Common.Items;
using TreasureGen.Generators.Items.Magical;
using TreasureGen.Selectors;
using TreasureGen.Tables;

namespace TreasureGen.Generators.Domain.Items.Magical
{
    public class ChargesGenerator : IChargesGenerator
    {
        private Dice dice;
        private IRangeAttributesSelector rangeAttributesSelector;
        private IBooleanPercentileSelector booleanPercentileSelector;

        public ChargesGenerator(Dice dice, IRangeAttributesSelector rangeAttributesSelector,
            IBooleanPercentileSelector booleanPercentileSelector)
        {
            this.dice = dice;
            this.rangeAttributesSelector = rangeAttributesSelector;
            this.booleanPercentileSelector = booleanPercentileSelector;
        }

        public Int32 GenerateFor(String itemType, String name)
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

        private Int32 PercentileCharges()
        {
            var roll = dice.Roll().Percentile();
            return Math.Max(roll / 2, 1);
        }
    }
}