using System.Collections.Generic;
using System.Linq;
using TreasureGen.Domain.Selectors.Attributes;
using TreasureGen.Domain.Selectors.Percentiles;
using TreasureGen.Domain.Tables;
using TreasureGen.Items;
using TreasureGen.Items.Magical;

namespace TreasureGen.Domain.Generators.Items.Magical
{
    internal class RingGenerator : MagicalItemGenerator
    {
        private IPercentileSelector percentileSelector;
        private ICollectionsSelector attributesSelector;
        private ISpellGenerator spellGenerator;
        private IChargesGenerator chargesGenerator;
        private ITypeAndAmountPercentileSelector typeAndAmountPercentileSelector;

        public RingGenerator(IPercentileSelector percentileSelector, ICollectionsSelector attributesSelector, ISpellGenerator spellGenerator, IChargesGenerator chargesGenerator, ITypeAndAmountPercentileSelector typeAndAmountPercentileSelector)
        {
            this.percentileSelector = percentileSelector;
            this.attributesSelector = attributesSelector;
            this.spellGenerator = spellGenerator;
            this.chargesGenerator = chargesGenerator;
            this.typeAndAmountPercentileSelector = typeAndAmountPercentileSelector;
        }

        public Item GenerateAtPower(string power)
        {
            var tableName = string.Format(TableNameConstants.Percentiles.Formattable.POWERITEMTYPEs, power, ItemTypeConstants.Ring);
            var result = typeAndAmountPercentileSelector.SelectFrom(tableName);

            var ring = new Item();
            ring.Name = result.Type;
            ring.BaseNames = new[] { result.Type };
            ring.Magic.Bonus = result.Amount;
            ring.IsMagical = true;
            ring.ItemType = ItemTypeConstants.Ring;

            tableName = string.Format(TableNameConstants.Collections.Formattable.ITEMTYPEAttributes, ring.ItemType);
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

        private IEnumerable<string> GenerateSpells(string power, int levelCap)
        {
            var level = spellGenerator.GenerateLevel(power);
            var levelSum = level;
            var spells = new List<string>();

            while (levelSum <= levelCap)
            {
                var type = spellGenerator.GenerateType();
                var spell = spellGenerator.Generate(type, level);
                var formattedSpell = string.Format("{0} ({1}, {2})", spell, type, level);
                spells.Add(formattedSpell);

                level = spellGenerator.GenerateLevel(power);
                levelSum += level;
            }

            return spells;
        }

        public Item Generate(Item template, bool allowRandomDecoration = false)
        {
            var ring = template.Clone();
            ring.BaseNames = new[] { ring.Name };
            ring.ItemType = ItemTypeConstants.Ring;
            ring.Quantity = 1;
            ring.IsMagical = true;

            var tableName = string.Format(TableNameConstants.Collections.Formattable.ITEMTYPEAttributes, ItemTypeConstants.Ring);
            ring.Attributes = attributesSelector.SelectFrom(tableName, ring.Name);

            return ring.SmartClone();
        }
    }
}