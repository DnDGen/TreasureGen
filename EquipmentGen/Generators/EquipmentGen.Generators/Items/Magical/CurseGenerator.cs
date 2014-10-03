using System;
using System.Linq;
using D20Dice;
using EquipmentGen.Common.Items;
using EquipmentGen.Generators.Interfaces.Items.Magical;
using EquipmentGen.Selectors.Interfaces;
using EquipmentGen.Tables.Interfaces;

namespace EquipmentGen.Generators.Items.Magical
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

            if (curse == "Intermittent Functioning")
                return String.Format("{0} ({1})", curse, GetIntermittentFunctioning());

            if (curse == "Drawback")
                return GetDrawback();

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

            if (situation.Contains("DESIGNATEDFOE"))
                situation = GetSituationWithDesignatedFoe(situation);

            if (situation.Contains("ALIGNMENT"))
                situation = GetSituationWithAlignment(situation);

            if (situation.Contains("GENDER"))
                situation = GetSituationWithGender(situation);

            return String.Format("Dependent: {0}", situation);
        }

        private String GetSituationWithDesignatedFoe(String situation)
        {
            var foe = percentileSelector.SelectFrom(TableNameConstants.Percentiles.Set.DesignatedFoes);
            return situation.Replace("DESIGNATEDFOE", foe);
        }

        private String GetSituationWithAlignment(String situation)
        {
            var alignment = percentileSelector.SelectFrom(TableNameConstants.Percentiles.Set.ProtectionAlignments);
            return situation.Replace("ALIGNMENT", alignment);
        }

        private String GetSituationWithGender(String situation)
        {
            var roll = dice.Roll().d2();

            if (roll == 1)
                return situation.Replace("GENDER", "male");

            return situation.Replace("GENDER", "female");
        }

        private String GetDrawback()
        {
            var drawback = percentileSelector.SelectFrom(TableNameConstants.Percentiles.Set.CurseDrawbacks);

            if (drawback.Contains("HEIGHT"))
                return GetDrawbackWithHeight(drawback);

            return drawback;
        }

        private String GetDrawbackWithHeight(String drawback)
        {
            var change = percentileSelector.SelectFrom(TableNameConstants.Percentiles.Set.CurseHeightChanges);
            return drawback.Replace("HEIGHT", change);
        }

        public Item GenerateSpecificCursedItem()
        {
            var specificCursedItem = new Item();
            specificCursedItem.Name = percentileSelector.SelectFrom(TableNameConstants.Percentiles.Set.SpecificCursedItems);
            specificCursedItem.Magic.Curse = "This is a specific cursed item";
            specificCursedItem.ItemType = attributesSelector.SelectFrom(TableNameConstants.Attributes.Set.SpecificCursedItemItemTypes, specificCursedItem.Name).Single();
            specificCursedItem.Attributes = attributesSelector.SelectFrom(TableNameConstants.Attributes.Set.SpecificCursedItemAttributes, specificCursedItem.Name);

            return specificCursedItem;
        }
    }
}