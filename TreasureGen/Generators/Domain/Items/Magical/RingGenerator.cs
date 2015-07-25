using System;
using System.Collections.Generic;
using System.Linq;
using TreasureGen.Common.Items;
using TreasureGen.Generators.Items.Magical;
using TreasureGen.Selectors.Interfaces;
using TreasureGen.Tables.Interfaces;

namespace TreasureGen.Generators.Domain.Items.Magical
{
    public class RingGenerator : IMagicalItemGenerator
    {
        private IPercentileSelector percentileSelector;
        private IAttributesSelector attributesSelector;
        private ISpellGenerator spellGenerator;
        private IChargesGenerator chargesGenerator;
        private ITypeAndAmountPercentileSelector typeAndAmountPercentileSelector;

        public RingGenerator(IPercentileSelector percentileSelector, IAttributesSelector attributesSelector, ISpellGenerator spellGenerator, IChargesGenerator chargesGenerator, ITypeAndAmountPercentileSelector typeAndAmountPercentileSelector)
        {
            this.percentileSelector = percentileSelector;
            this.attributesSelector = attributesSelector;
            this.spellGenerator = spellGenerator;
            this.chargesGenerator = chargesGenerator;
            this.typeAndAmountPercentileSelector = typeAndAmountPercentileSelector;
        }

        public Item GenerateAtPower(String power)
        {
            var tableName = String.Format(TableNameConstants.Percentiles.Formattable.POWERITEMTYPEs, power, ItemTypeConstants.Ring);
            var result = typeAndAmountPercentileSelector.SelectFrom(tableName);

            var ring = new Item();
            ring.Name = result.Type;
            ring.Magic.Bonus = result.Amount;
            ring.IsMagical = true;
            ring.ItemType = ItemTypeConstants.Ring;

            tableName = String.Format(TableNameConstants.Attributes.Formattable.ITEMTYPEAttributes, ring.ItemType);
            ring.Attributes = attributesSelector.SelectFrom(tableName, result.Type);

            if (ring.Attributes.Contains(AttributeConstants.Charged))
                ring.Magic.Charges = chargesGenerator.GenerateFor(ItemTypeConstants.Ring, result.Type);

            if (ring.Name == RingConstants.Counterspells)
            {
                var level = spellGenerator.GenerateLevel(power);
                if (level <= 6)
                {
                    var type = spellGenerator.GenerateType();
                    var spell = spellGenerator.Generate(type, level);
                    ring.Contents.Add(spell);
                }
            }
            else if (ring.Name == RingConstants.SpellStoring_Minor)
            {
                var spells = GenerateSpells(power, 3);
                ring.Contents.AddRange(spells);
            }
            else if (ring.Name == RingConstants.SpellStoring_Major)
            {
                var spells = GenerateSpells(power, 10);
                ring.Contents.AddRange(spells);
            }
            else if (ring.Name == RingConstants.SpellStoring)
            {
                var spells = GenerateSpells(power, 5);
                ring.Contents.AddRange(spells);
            }

            return ring;
        }

        private IEnumerable<String> GenerateSpells(String power, Int32 levelCap)
        {
            var level = spellGenerator.GenerateLevel(power);
            var levelSum = level;
            var spells = new List<String>();

            while (levelSum <= levelCap)
            {
                var type = spellGenerator.GenerateType();
                var spell = spellGenerator.Generate(type, level);
                var formattedSpell = String.Format("{0} ({1}, {2})", spell, type, level);
                spells.Add(formattedSpell);

                level = spellGenerator.GenerateLevel(power);
                levelSum += level;
            }

            return spells;
        }
    }
}