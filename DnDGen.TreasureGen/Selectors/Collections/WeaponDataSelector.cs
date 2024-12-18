﻿using DnDGen.Infrastructure.Selectors.Collections;
using DnDGen.TreasureGen.Items;
using DnDGen.TreasureGen.Selectors.Helpers;
using DnDGen.TreasureGen.Selectors.Selections;
using DnDGen.TreasureGen.Tables;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DnDGen.TreasureGen.Selectors.Collections
{
    internal class WeaponDataSelector : IWeaponDataSelector
    {
        private readonly ICollectionSelector collectionSelector;
        private readonly DamageHelper damageHelper;

        public WeaponDataSelector(ICollectionSelector collectionSelector)
        {
            this.collectionSelector = collectionSelector;
            damageHelper = new DamageHelper();
        }

        public WeaponSelection Select(string name)
        {
            var data = collectionSelector.SelectFrom(Config.Name, TableNameConstants.Collections.Set.WeaponData, name).ToArray();
            var damagesData = collectionSelector.SelectFrom(Config.Name, TableNameConstants.Collections.Set.WeaponDamages, name).ToArray();

            var damages = new List<List<Damage>>();
            foreach (var damageData in damagesData)
            {
                var sizeDamagesData = damageHelper.ParseEntries(damageData);
                var sizeDamages = new List<Damage>();

                foreach (var sizeDamageData in sizeDamagesData)
                {
                    sizeDamages.Add(new Damage
                    {
                        Roll = sizeDamageData[DataIndexConstants.Weapon.DamageData.RollIndex],
                        Type = sizeDamageData[DataIndexConstants.Weapon.DamageData.TypeIndex],
                        Condition = sizeDamageData[DataIndexConstants.Weapon.DamageData.ConditionIndex],
                    });
                }

                damages.Add(sizeDamages);
            }

            var selection = new WeaponSelection();
            selection.ThreatRange = Convert.ToInt32(data[DataIndexConstants.Weapon.ThreatRange]);
            selection.Ammunition = data[DataIndexConstants.Weapon.Ammunition];
            selection.CriticalMultiplier = data[DataIndexConstants.Weapon.CriticalMultiplier];
            selection.SecondaryCriticalMultiplier = data[DataIndexConstants.Weapon.SecondaryCriticalMultiplier];

            var sizes = TraitConstants.Sizes.All().ToArray();

            for (var i = 0; i < sizes.Length; i++)
            {
                var critIndex = i + sizes.Length;
                selection.DamagesBySize[sizes[i]] = damages[i];
                selection.CriticalDamagesBySize[sizes[i]] = damages[critIndex];
            }

            return selection;
        }
    }
}
