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

        public RingGenerator(IPercentileSelector percentileSelector, IAttributesSelector attributesSelector,
            IMagicalItemTraitsGenerator traitsGenerator, ISpellGenerator spellGenerator, IIntelligenceGenerator intelligenceGenerator,
            IChargesGenerator chargesGenerator, IDice dice, ICurseGenerator curseGenerator)
        {
            this.percentileSelector = percentileSelector;
            this.attributesSelector = attributesSelector;
            this.traitsGenerator = traitsGenerator;
            this.spellGenerator = spellGenerator;
            this.intelligenceGenerator = intelligenceGenerator;
            this.chargesGenerator = chargesGenerator;
            this.dice = dice;
            this.curseGenerator = curseGenerator;
        }

        public Item GenerateAtPower(String power)
        {
            var roll = dice.Percentile();
            var tableName = String.Format("{0}Rings", power);
            var ability = percentileSelector.SelectFrom(tableName, roll);

            var ring = new Item();
            ring.Name = String.Format("Ring of {0}", ability);
            ring.IsMagical = true;
            ring.Attributes = attributesSelector.SelectFrom("RingAttributes", ability);
            var traits = traitsGenerator.GenerateFor(ItemTypeConstants.Ring);
            ring.Traits.AddRange(traits);

            if (ability.Contains("+"))
                ring.Magic.Bonus = GetBonus(ability);

            if (ring.Attributes.Contains(AttributeConstants.Charged))
                ring.Magic.Charges = chargesGenerator.GenerateFor(ItemTypeConstants.Ring, ability);

            if (intelligenceGenerator.IsIntelligent(ItemTypeConstants.Ring, ring.Attributes, ring.IsMagical))
                ring.Magic.Intelligence = intelligenceGenerator.GenerateFor(ring.Magic);

            if (curseGenerator.HasCurse(ring.IsMagical))
            {
                var curse = curseGenerator.GenerateCurse();
                if (curse == "SpecificCursedItem")
                    return curseGenerator.GenerateSpecificCursedItem();

                ring.Magic.Curse = curse;
            }

            if (ability.Contains("Counterspells"))
            {
                var level = spellGenerator.GenerateLevel(power);
                if (level <= 6)
                {
                    var type = spellGenerator.GenerateType();
                    var spell = spellGenerator.Generate(type, level);
                    var formattedSpell = String.Format("{0} ({1}, {2})", spell, type, level);
                    ring.Contents.Add(formattedSpell);
                }
            }
            else if (ability.Contains("Minor spell storing"))
            {
                var spells = GenerateSpells(power, 3);
                ring.Contents.AddRange(spells);
            }
            else if (ability.Contains("Major spell storing"))
            {
                var spells = GenerateSpells(power, 10);
                ring.Contents.AddRange(spells);
            }
            else if (ability.Contains("Spell storing"))
            {
                var spells = GenerateSpells(power, 5);
                ring.Contents.AddRange(spells);
            }
            else if (ability.Contains("nergy resistance"))
            {
                roll = dice.Percentile();
                var energy = percentileSelector.SelectFrom("Elements", roll);
                ring.Name = String.Format("{0} ({1})", ring.Name, energy);
            }

            return ring;
        }

        private Int32 GetBonus(String name)
        {
            var bonus = name.Split('+').Last();
            return Convert.ToInt32(bonus);
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