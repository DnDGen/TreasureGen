using System;
using D20Dice;
using EquipmentGen.Common.Items;
using EquipmentGen.Generators.Interfaces.Items.Magical;
using EquipmentGen.Selectors.Interfaces;
using EquipmentGen.Selectors.Interfaces.Objects;

namespace EquipmentGen.Generators.Items.Magical
{
    public class PotionGenerator : IMagicalItemGenerator
    {
        private IDice dice;
        private ITypeAndAmountPercentileSelector typeAndAmountPercentileSelector;
        private IPercentileSelector percentileSelector;
        private ICurseGenerator curseGenerator;

        public PotionGenerator(IDice dice, ITypeAndAmountPercentileSelector typeAndAmountPercentileSelector, IPercentileSelector percentileSelector,
            ICurseGenerator curseGenerator)
        {
            this.dice = dice;
            this.typeAndAmountPercentileSelector = typeAndAmountPercentileSelector;
            this.percentileSelector = percentileSelector;
            this.curseGenerator = curseGenerator;
        }

        public Item GenerateAtPower(String power)
        {
            var result = GetResult(power);
            var potion = new Item();

            potion.Name = result.Type;
            potion.Magic.Bonus = Convert.ToInt32(result.Amount);
            potion.IsMagical = true;
            potion.Attributes = new[] { AttributeConstants.OneTimeUse };

            if (curseGenerator.HasCurse(potion.IsMagical))
            {
                var curse = curseGenerator.GenerateCurse();
                if (curse == "SpecificCursedItem")
                    return curseGenerator.GenerateSpecificCursedItem();

                potion.Magic.Curse = curse;
            }

            return potion;
        }

        private TypeAndAmountPercentileResult GetResult(String power)
        {
            var roll = dice.Percentile();
            var tableName = String.Format("{0}Potions", power);
            var result = typeAndAmountPercentileSelector.SelectFrom(tableName, roll);

            if (result.Type.Contains("ALIGNMENT"))
            {
                roll = dice.Percentile();
                var alignment = percentileSelector.SelectFrom("ProtectionAlignments", roll);
                result.Type = result.Type.Replace("ALIGNMENT", alignment);
            }

            if (result.Type.Contains("ENERGY"))
            {
                roll = dice.Percentile();
                var energy = percentileSelector.SelectFrom("Elements", roll);
                result.Type = result.Type.Replace("ENERGY", energy);
            }

            return result;
        }
    }
}