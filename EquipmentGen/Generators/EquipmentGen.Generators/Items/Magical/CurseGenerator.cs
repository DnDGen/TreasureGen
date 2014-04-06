using System;
using System.Collections.Generic;
using System.Linq;
using D20Dice;
using EquipmentGen.Common.Items;
using EquipmentGen.Generators.Interfaces.Items.Magical;
using EquipmentGen.Selectors.Interfaces;

namespace EquipmentGen.Generators.Items.Magical
{
    public class CurseGenerator : ICurseGenerator
    {
        private IDice dice;
        private IPercentileSelector percentileSelector;

        public CurseGenerator(IDice dice, IPercentileSelector percentileSelector)
        {
            this.dice = dice;
            this.percentileSelector = percentileSelector;
        }

        public Boolean HasCurse(Dictionary<Magic, Object> magic)
        {
            if (!magic.Any())
                return false;

            var roll = dice.Percentile();
            return roll <= 5;
        }

        public String GenerateCurse()
        {
            var roll = dice.Percentile();
            var curse = percentileSelector.SelectFrom("Curses", roll);

            if (curse == "Intermittent Functioning")
                return String.Format("{0} (Dependent: {1})", curse, GetIntermittentFunctioning());

            if (curse == "Drawback")
                return GetDrawback();

            return curse;
        }

        private String GetIntermittentFunctioning()
        {
            var roll = dice.d3();

            if (roll == 1)
                return "Unreliable";

            if (roll == 3)
                return "Uncontrolled";

            roll = dice.Percentile();
            var situation = percentileSelector.SelectFrom("CursedDependentSituations", roll);

            if (situation.Contains("DesignatedFoe"))
                situation = GetSituationWithDesignatedFoe(situation);

            if (situation.Contains("Alignment"))
                situation = GetSituationWithAlignment(situation);

            if (situation.Contains("Gender"))
                situation = GetSituationWithGender(situation);

            return situation;
        }

        private String GetSituationWithDesignatedFoe(String situation)
        {
            var roll = dice.Percentile();
            var foe = percentileSelector.SelectFrom("DesignatedFoes", roll);
            return situation.Replace("DesignatedFoe", foe);
        }

        private String GetSituationWithAlignment(String situation)
        {
            var roll = dice.Percentile();
            var alignment = percentileSelector.SelectFrom("IntelligenceAlignments", roll);
            return situation.Replace("Alignment", alignment);
        }

        private String GetSituationWithGender(String situation)
        {
            var roll = dice.d2();

            if (roll == 1)
                return situation.Replace("Gender", "male");

            return situation.Replace("Gender", "female");
        }

        private String GetDrawback()
        {
            var roll = dice.Percentile();
            return percentileSelector.SelectFrom("CurseDrawbacks", roll);
        }

        public Item GenerateSpecificCursedItem()
        {
            var specificCursedItem = new Item();
            var roll = dice.Percentile();

            specificCursedItem.Name = percentileSelector.SelectFrom("SpecificCursedItems", roll);
            specificCursedItem.Magic[Magic.IsMagical] = true;
            specificCursedItem.Magic[Magic.Curse] = "This is a specific cursed item";

            return specificCursedItem;
        }
    }
}