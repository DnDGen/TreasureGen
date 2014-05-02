using System;
using System.Collections.Generic;
using System.Linq;
using D20Dice;
using EquipmentGen.Common.Items;
using EquipmentGen.Generators.Interfaces.Items.Magical;
using EquipmentGen.Selectors.Interfaces;

namespace EquipmentGen.Generators.Items.Magical
{
    public class RingGenerator : IMagicalItemGenerator
    {
        private IPercentileSelector percentileSelector;
        private IAttributesSelector attributesSelector;
        private IMagicalItemTraitsGenerator traitsGenerator;
        private ISpellGenerator spellGenerator;
        private IIntelligenceGenerator intelligenceGenerator;
        private IChargesGenerator chargesGenerator;
        private IDice dice;
        private ICurseGenerator curseGenerator;
        private ITypeAndAmountPercentileSelector typeAndAmountPercentileSelector;

        public RingGenerator(IPercentileSelector percentileSelector, IAttributesSelector attributesSelector,
            IMagicalItemTraitsGenerator traitsGenerator, ISpellGenerator spellGenerator, IIntelligenceGenerator intelligenceGenerator,
            IChargesGenerator chargesGenerator, IDice dice, ICurseGenerator curseGenerator, ITypeAndAmountPercentileSelector typeAndAmountPercentileSelector)
        {
            this.percentileSelector = percentileSelector;
            this.attributesSelector = attributesSelector;
            this.traitsGenerator = traitsGenerator;
            this.spellGenerator = spellGenerator;
            this.intelligenceGenerator = intelligenceGenerator;
            this.chargesGenerator = chargesGenerator;
            this.dice = dice;
            this.curseGenerator = curseGenerator;
            this.typeAndAmountPercentileSelector = typeAndAmountPercentileSelector;
        }

        public Item GenerateAtPower(String power)
        {
            var roll = dice.Percentile();
            var tableName = String.Format("{0}Rings", power);
            var result = typeAndAmountPercentileSelector.SelectFrom(tableName, roll);

            var ring = new Item();
            ring.Name = String.Format("Ring of {0}", result.Type);
            ring.Magic.Bonus = Convert.ToInt32(result.Amount);
            ring.IsMagical = true;
            ring.Attributes = attributesSelector.SelectFrom("RingAttributes", result.Type);

            var traits = traitsGenerator.GenerateFor(ItemTypeConstants.Ring);
            ring.Traits.AddRange(traits);

            if (ring.Attributes.Contains(AttributeConstants.Charged))
                ring.Magic.Charges = chargesGenerator.GenerateFor(ItemTypeConstants.Ring, result.Type);

            if (intelligenceGenerator.IsIntelligent(ItemTypeConstants.Ring, ring.Attributes, ring.IsMagical))
                ring.Magic.Intelligence = intelligenceGenerator.GenerateFor(ring.Magic);

            if (curseGenerator.HasCurse(ring.IsMagical))
            {
                var curse = curseGenerator.GenerateCurse();
                if (curse == "SpecificCursedItem")
                    return curseGenerator.GenerateSpecificCursedItem();

                ring.Magic.Curse = curse;
            }

            if (result.Type.Contains("Counterspells"))
            {
                var level = spellGenerator.GenerateLevel(power);
                if (level <= 6)
                {
                    var type = spellGenerator.GenerateType();
                    var spell = spellGenerator.Generate(type, level);
                    ring.Contents.Add(spell);
                }
            }
            else if (result.Type.Contains("Minor spell storing"))
            {
                var spells = GenerateSpells(power, 3);
                ring.Contents.AddRange(spells);
            }
            else if (result.Type.Contains("Major spell storing"))
            {
                var spells = GenerateSpells(power, 10);
                ring.Contents.AddRange(spells);
            }
            else if (result.Type.Contains("Spell storing"))
            {
                var spells = GenerateSpells(power, 5);
                ring.Contents.AddRange(spells);
            }
            else if (result.Type.Contains("ENERGY"))
            {
                roll = dice.Percentile();
                var element = percentileSelector.SelectFrom("Elements", roll);
                ring.Name = ring.Name.Replace("ENERGY", element);
            }

            return ring;
        }

        private IEnumerable<String> GenerateSpells(String power, Int32 levelCap)
        {
            var levelSum = 0;
            var spells = new List<String>();

            while (levelSum < levelCap)
            {
                var level = spellGenerator.GenerateLevel(power);
                levelSum += level;

                if (levelSum > levelCap)
                    continue;

                var type = spellGenerator.GenerateType();
                var spell = spellGenerator.Generate(type, level);
                var formattedSpell = String.Format("{0} ({1}, {2})", spell, type, level);
                spells.Add(formattedSpell);
            }

            return spells;
        }
    }
}