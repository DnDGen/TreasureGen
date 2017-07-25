using RollGen;
using System;
using TreasureGen.Domain.Selectors.Collections;
using TreasureGen.Domain.Selectors.Percentiles;
using TreasureGen.Domain.Tables;
using TreasureGen.Items;
using TreasureGen.Items.Magical;

namespace TreasureGen.Domain.Generators.Items.Magical
{
    internal class ChargesGenerator : IChargesGenerator
    {
        private readonly Dice dice;
        private readonly IRangeDataSelector rangeDataSelector;
        private readonly ITreasurePercentileSelector percentileSelector;

        public ChargesGenerator(Dice dice, IRangeDataSelector rangeDataSelector, ITreasurePercentileSelector percentileSelector)
        {
            this.dice = dice;
            this.rangeDataSelector = rangeDataSelector;
            this.percentileSelector = percentileSelector;
        }

        public int GenerateFor(string itemType, string name)
        {
            if (itemType == ItemTypeConstants.Wand || itemType == ItemTypeConstants.Staff)
                return PercentileCharges();

            if (name == WondrousItemConstants.DeckOfIllusions)
            {
                var isFullyCharged = percentileSelector.SelectFrom<bool>(TableNameConstants.Percentiles.Set.IsDeckOfIllusionsFullyCharged);

                if (isFullyCharged)
                    name = WondrousItemConstants.FullDeckOfIllusions;
            }

            var result = rangeDataSelector.SelectFrom(TableNameConstants.Collections.Set.ChargeLimits, name);
            var die = result.Maximum - result.Minimum + 1;

            return dice.Roll().d(die).AsSum() - 1 + result.Minimum;
        }

        private int PercentileCharges()
        {
            var roll = dice.Roll().Percentile().AsSum();
            return Math.Max(roll / 2, 1);
        }
    }
}