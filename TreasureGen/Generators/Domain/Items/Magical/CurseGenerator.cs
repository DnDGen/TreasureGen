using RollGen;
using System;
using System.Linq;
using TreasureGen.Common.Items;
using TreasureGen.Generators.Items.Magical;
using TreasureGen.Selectors;
using TreasureGen.Tables;

namespace TreasureGen.Generators.Domain.Items.Magical
{
    public class CurseGenerator : ICurseGenerator
    {
        private IDice dice;
        private IPercentileSelector percentileSelector;
        private IBooleanPercentileSelector booleanPercentileSelector;
        private IAttributesSelector attributesSelector;

        public CurseGenerator(IDice dice, IPercentileSelector percentileSelector, IBooleanPercentileSelector booleanPercentileSelector,
            IAttributesSelector attributesSelector)
        {
            this.dice = dice;
            this.percentileSelector = percentileSelector;
            this.booleanPercentileSelector = booleanPercentileSelector;
            this.attributesSelector = attributesSelector;
        }

        public Boolean HasCurse(Boolean isMagical)
        {
            if (!isMagical)
                return false;

            return booleanPercentileSelector.SelectFrom(TableNameConstants.Percentiles.Set.IsItemCursed);
        }

        public String GenerateCurse()
        {
            var curse = percentileSelector.SelectFrom(TableNameConstants.Percentiles.Set.Curses);

            if (curse == CurseConstants.Intermittent)
                return String.Format("{0} ({1})", curse, GetIntermittentFunctioning());

            if (curse == CurseConstants.Drawback)
                return percentileSelector.SelectFrom(TableNameConstants.Percentiles.Set.CurseDrawbacks);

            return curse;
        }

        private String GetIntermittentFunctioning()
        {
            var roll = dice.Roll().d3();

            if (roll == 1)
                return "Unreliable";

            if (roll == 3)
                return "Uncontrolled";

            var situation = percentileSelector.SelectFrom(TableNameConstants.Percentiles.Set.CursedDependentSituations);
            return String.Format("Dependent: {0}", situation);
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