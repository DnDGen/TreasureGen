using System;
using EquipmentGen.Core.Data.Items;
using EquipmentGen.Core.Generation.Generators.Interfaces;
using EquipmentGen.Core.Generation.Providers.Interfaces;

namespace EquipmentGen.Core.Generation.Generators
{
    public class MundaneWeaponGenerator : IMundaneGearGenerator
    {
        private IPercentileResultProvider percentileResultProvider;
        private IAmmunitionGenerator ammunitionGenerator;

        public MundaneWeaponGenerator(IPercentileResultProvider percentileResultProvider, IAmmunitionGenerator ammunitionGenerator)
        {
            this.percentileResultProvider = percentileResultProvider;
            this.ammunitionGenerator = ammunitionGenerator;
        }

        public Gear Generate()
        {
            var type = percentileResultProvider.GetPercentileResult("MundaneWeapons");


            var tableName = String.Format("{0}Weapons", type);
            var weaponName = percentileResultProvider.GetPercentileResult(tableName);

            if (weaponName == "Ammunition")
                return ammunitionGenerator.Generate();

            var gear = new Gear();
            gear.Traits.Add(ItemsConstants.Gear.Traits.Masterwork);
            gear.Name = weaponName;

            return gear;
        }
    }
}