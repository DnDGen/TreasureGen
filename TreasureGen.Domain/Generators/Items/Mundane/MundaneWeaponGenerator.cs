using RollGen;
using System;
using System.Linq;
using TreasureGen.Domain.Selectors.Attributes;
using TreasureGen.Domain.Selectors.Percentiles;
using TreasureGen.Domain.Tables;
using TreasureGen.Items;
using TreasureGen.Items.Mundane;

namespace TreasureGen.Domain.Generators.Items.Mundane
{
    internal class MundaneWeaponGenerator : MundaneItemGenerator
    {
        private IPercentileSelector percentileSelector;
        private IAmmunitionGenerator ammunitionGenerator;
        private ICollectionsSelector collectionsSelector;
        private IBooleanPercentileSelector booleanPercentileSelector;
        private Dice dice;

        public MundaneWeaponGenerator(IPercentileSelector percentileSelector, IAmmunitionGenerator ammunitionGenerator, ICollectionsSelector collectionsSelector, IBooleanPercentileSelector booleanPercentileSelector, Dice dice)
        {
            this.percentileSelector = percentileSelector;
            this.ammunitionGenerator = ammunitionGenerator;
            this.collectionsSelector = collectionsSelector;
            this.booleanPercentileSelector = booleanPercentileSelector;
            this.dice = dice;
        }

        public Item Generate()
        {
            var type = percentileSelector.SelectFrom(TableNameConstants.Percentiles.Set.MundaneWeapons);
            var tableName = string.Format(TableNameConstants.Percentiles.Formattable.WEAPONTYPEWeapons, type);
            var weaponName = percentileSelector.SelectFrom(tableName);

            var weapon = new Item();

            if (weaponName == AttributeConstants.Ammunition)
            {
                weapon = ammunitionGenerator.Generate();
            }
            else
            {
                weapon.Name = weaponName;

                if (weapon.Name.Contains("Composite"))
                {
                    weapon.Name = GetCompositeBowName(weaponName);
                    var compositeStrengthBonus = GetCompositeBowBonus(weaponName);
                    weapon.Traits.Add(compositeStrengthBonus);
                }

                weapon.ItemType = ItemTypeConstants.Weapon;
                tableName = string.Format(TableNameConstants.Collections.Formattable.ITEMTYPEAttributes, weapon.ItemType);
                weapon.Attributes = collectionsSelector.SelectFrom(tableName, weapon.Name);
            }

            var isMasterwork = booleanPercentileSelector.SelectFrom(TableNameConstants.Percentiles.Set.IsMasterwork);
            if (isMasterwork)
                weapon.Traits.Add(TraitConstants.Masterwork);

            if (weapon.Attributes.Contains(AttributeConstants.Thrown) && weapon.Attributes.Contains(AttributeConstants.Melee) == false)
                weapon.Quantity = dice.Roll().d20().AsSum();

            var size = percentileSelector.SelectFrom(TableNameConstants.Percentiles.Set.MundaneGearSizes);
            weapon.Traits.Add(size);

            return weapon;
        }

        private string GetCompositeBowBonus(string weaponName)
        {
            var compositeBonusStartIndex = weaponName.IndexOf('+');
            var compositeBonus = weaponName.Substring(compositeBonusStartIndex, 2);
            return $"{compositeBonus} Strength bonus";
        }

        private string GetCompositeBowName(string weaponName)
        {
            switch (weaponName)
            {
                case WeaponConstants.CompositePlus0Longbow:
                case WeaponConstants.CompositePlus1Longbow:
                case WeaponConstants.CompositePlus2Longbow:
                case WeaponConstants.CompositePlus3Longbow:
                case WeaponConstants.CompositePlus4Longbow: return WeaponConstants.CompositeLongbow;
                case WeaponConstants.CompositePlus0Shortbow:
                case WeaponConstants.CompositePlus1Shortbow:
                case WeaponConstants.CompositePlus2Shortbow: return WeaponConstants.CompositeShortbow;
                default: throw new ArgumentException($"Composite bow {weaponName} does not map to a known bow");
            }
        }

        public Item Generate(Item template, bool allowRandomDecoration = false)
        {
            template.ItemType = ItemTypeConstants.Weapon;
            var weapon = template.CopyWithoutMagic();

            if (ammunitionGenerator.TemplateIsAmmunition(template))
            {
                weapon = ammunitionGenerator.GenerateFrom(template);
                weapon = weapon.CopyWithoutMagic();
            }
            else
            {
                var tableName = string.Format(TableNameConstants.Collections.Formattable.ITEMTYPEAttributes, weapon.ItemType);
                weapon.Attributes = collectionsSelector.SelectFrom(tableName, weapon.Name);
            }

            var sizes = percentileSelector.SelectAllFrom(TableNameConstants.Percentiles.Set.MundaneGearSizes);

            if (weapon.Traits.Intersect(sizes).Any() == false)
            {
                var size = percentileSelector.SelectFrom(TableNameConstants.Percentiles.Set.MundaneGearSizes);
                weapon.Traits.Add(size);
            }

            if (allowRandomDecoration)
            {
                var isMasterwork = booleanPercentileSelector.SelectFrom(TableNameConstants.Percentiles.Set.IsMasterwork);
                if (isMasterwork)
                    weapon.Traits.Add(TraitConstants.Masterwork);
            }

            return weapon;
        }
    }
}