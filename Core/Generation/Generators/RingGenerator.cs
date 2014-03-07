using System;
using System.Collections.Generic;
using System.Linq;
using EquipmentGen.Core.Data.Items;
using EquipmentGen.Core.Data.Items.Constants;
using EquipmentGen.Core.Generation.Generators.Interfaces;
using EquipmentGen.Core.Generation.Providers.Interfaces;

namespace EquipmentGen.Core.Generation.Generators
{
    public class RingGenerator : IMagicalItemGenerator
    {
        private IPercentileResultProvider percentileResultProvider;
        private IAttributesProvider attributesProvider;
        private IMagicalItemTraitsGenerator traitsGenerator;
        private ISpellGenerator spellGenerator;
        private IIntelligenceGenerator intelligenceGenerator;
        private IChargesGenerator chargesGenerator;

        public RingGenerator(IPercentileResultProvider percentileResultProvider, IAttributesProvider attributesProvider,
            IMagicalItemTraitsGenerator traitsGenerator, ISpellGenerator spellGenerator, IIntelligenceGenerator intelligenceGenerator,
            IChargesGenerator chargesGenerator)
        {
            this.percentileResultProvider = percentileResultProvider;
            this.attributesProvider = attributesProvider;
            this.traitsGenerator = traitsGenerator;
            this.spellGenerator = spellGenerator;
            this.intelligenceGenerator = intelligenceGenerator;
            this.chargesGenerator = chargesGenerator;
        }

        public Item GenerateAtPower(String power)
        {
            var ring = new Item();
            var tableName = String.Format("{0}Rings", power);
            var ability = percentileResultProvider.GetResultFrom(tableName);

            ring.Name = String.Format("Ring of {0}", ability);
            ring.Magic[Magic.IsMagical] = true;
            ring.Attributes = attributesProvider.GetAttributesFor(ability, "RingAttributes");
            var traits = traitsGenerator.GenerateFor(ItemTypeConstants.Ring);
            ring.Traits.AddRange(traits);

            if (ability.Contains("+"))
                ring.Magic[Magic.Bonus] = GetBonus(ability);

            if (ring.Attributes.Any(a => a == AttributeConstants.Charged))
                ring.Magic[Magic.Charges] = chargesGenerator.GenerateFor(ItemTypeConstants.Ring, ability);

            if (intelligenceGenerator.IsIntelligent(ItemTypeConstants.Ring, ring.Attributes, ring.Magic))
                ring.Magic[Magic.Intelligence] = intelligenceGenerator.GenerateFor(ring.Magic);

            if (ability.Contains("Counterspells"))
            {
                ring.Name = GetNewRingNameWithSpells(ring.Name, power, 6);
            }
            else if (ability.Contains("Minor spell storing"))
            {
                ring.Name = GetNewRingNameWithSpells(ring.Name, power, 3);
            }
            else if (ability.Contains("Major spell storing"))
            {
                ring.Name = GetNewRingNameWithSpells(ring.Name, power, 10);
            }
            else if (ability.Contains("Spell storing"))
            {
                ring.Name = GetNewRingNameWithSpells(ring.Name, power, 5);
            }
            else if (ability.Contains("nergy resistance"))
            {
                var energy = percentileResultProvider.GetResultFrom("Elements");
                ring.Name = String.Format("{0} ({1})", ring.Name, energy);
            }

            return ring;
        }

        private Int32 GetBonus(String name)
        {
            var bonus = name.Split('+').Last();
            return Convert.ToInt32(bonus);
        }

        private String GetNewRingNameWithSpells(String name, String power, Int32 levelCap)
        {
            var spells = GenerateSpells(power, levelCap);
            var spellsString = String.Join(", ", spells);
            return String.Format("{0} ({1})", name, spellsString);
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
                spells.Add(spell);
            }

            return spells;
        }
    }
}