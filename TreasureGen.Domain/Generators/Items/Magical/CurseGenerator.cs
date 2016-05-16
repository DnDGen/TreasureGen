using RollGen;
using System.Linq;
using TreasureGen.Domain.Selectors.Attributes;
using TreasureGen.Domain.Selectors.Percentiles;
using TreasureGen.Domain.Tables;
using TreasureGen.Items;
using TreasureGen.Items.Magical;

namespace TreasureGen.Domain.Generators.Items.Magical
{
    internal class CurseGenerator : ICurseGenerator
    {
        private Dice dice;
        private IPercentileSelector percentileSelector;
        private IBooleanPercentileSelector booleanPercentileSelector;
        private IAttributesSelector attributesSelector;

        public CurseGenerator(Dice dice, IPercentileSelector percentileSelector, IBooleanPercentileSelector booleanPercentileSelector,
            IAttributesSelector attributesSelector)
        {
            this.dice = dice;
            this.percentileSelector = percentileSelector;
            this.booleanPercentileSelector = booleanPercentileSelector;
            this.attributesSelector = attributesSelector;
        }

        public bool HasCurse(bool isMagical)
        {
            return isMagical && booleanPercentileSelector.SelectFrom(TableNameConstants.Percentiles.Set.IsItemCursed);
        }

        public string GenerateCurse()
        {
            var curse = percentileSelector.SelectFrom(TableNameConstants.Percentiles.Set.Curses);

            if (curse == CurseConstants.Intermittent)
                return string.Format("{0} ({1})", curse, GetIntermittentFunctioning());

            if (curse == CurseConstants.Drawback)
                return percentileSelector.SelectFrom(TableNameConstants.Percentiles.Set.CurseDrawbacks);

            return curse;
        }

        private string GetIntermittentFunctioning()
        {
            var roll = dice.Roll().d3();

            if (roll == 1)
                return "Unreliable";

            if (roll == 3)
                return "Uncontrolled";

            var situation = percentileSelector.SelectFrom(TableNameConstants.Percentiles.Set.CursedDependentSituations);
            return string.Format("Dependent: {0}", situation);
        }

        public Item GenerateSpecificCursedItem()
        {
            var specificCursedItem = new Item();
            specificCursedItem.Name = percentileSelector.SelectFrom(TableNameConstants.Percentiles.Set.SpecificCursedItems);
            specificCursedItem.Magic.Curse = CurseConstants.SpecificCursedItem;
            specificCursedItem.ItemType = attributesSelector.SelectFrom(TableNameConstants.Attributes.Set.SpecificCursedItemItemTypes, specificCursedItem.Name).Single();
            specificCursedItem.Attributes = attributesSelector.SelectFrom(TableNameConstants.Attributes.Set.SpecificCursedItemAttributes, specificCursedItem.Name);

            return specificCursedItem;
        }
    }
}