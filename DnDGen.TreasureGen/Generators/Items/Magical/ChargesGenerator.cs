using DnDGen.RollGen;
using DnDGen.TreasureGen.Items;
using DnDGen.TreasureGen.Items.Magical;
using DnDGen.TreasureGen.Selectors.Collections;
using DnDGen.TreasureGen.Selectors.Percentiles;
using DnDGen.TreasureGen.Tables;
using System;

namespace DnDGen.TreasureGen.Generators.Items.Magical
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
                var isFullyCharged = percentileSelector.SelectFrom<bool>(Config.Name, TableNameConstants.Percentiles.Set.IsDeckOfIllusionsFullyCharged);

                if (isFullyCharged)
                    name = WondrousItemConstants.DeckOfIllusions_Full;
            }

            var result = rangeDataSelector.SelectFrom(TableNameConstants.Collections.Set.ChargeLimits, name);
            var roll = RollHelper.GetRollWithMostEvenDistribution(result.Minimum, result.Maximum, true);

            return dice.Roll(roll).AsSum();
        }

        private int PercentileCharges()
        {
            var roll = dice.Roll().Percentile().AsSum();
            return Math.Max(roll / 2, 1);
        }
    }
}