using System;
using System.Collections.Generic;
using EquipmentGen.Bootstrap;
using EquipmentGen.Core.Data.Items;
using Ninject;
using NUnit.Framework;

namespace EquipmentGen.Tests.Integration.Common
{
    [TestFixture]
    public abstract class IntegrationTest
    {
        [Inject]
        public Random Random { get; set; }

        private IKernel kernel;

        public IntegrationTest()
        {
            kernel = new StandardKernel();

            var equipmentGenModuleLoader = new EquipmentGenModuleLoader();
            equipmentGenModuleLoader.LoadModules(kernel);

            kernel.Inject(this);
        }

        protected Int32 GetNewLevel()
        {
            return Random.Next(1, 21);
        }

        protected String GetNewPower(Boolean allowMundane)
        {
            var limit = allowMundane ? 4 : 3;

            switch (Random.Next(limit))
            {
                case 0: return ItemsConstants.Power.Minor;
                case 1: return ItemsConstants.Power.Medium;
                case 2: return ItemsConstants.Power.Major;
                case 3: return ItemsConstants.Power.Mundane;
                default: throw new ArgumentOutOfRangeException();
            }
        }

        protected IEnumerable<String> GetNewTypes()
        {
            var types = new List<String>();

            switch (Random.Next(2))
            {
                case 0: types.Add(ItemsConstants.ItemTypes.Armor); break;
                case 1: types.Add(ItemsConstants.ItemTypes.Weapon); break;
            }

            if (types.Contains(ItemsConstants.ItemTypes.Weapon))
            {
                switch (Random.Next(2))
                {
                    case 0: types.Add(ItemsConstants.Gear.Types.Melee); break;
                    default: types.Add(ItemsConstants.Gear.Types.Ranged); break;
                }
            }

            if (types.Contains(ItemsConstants.ItemTypes.Armor))
            {
                switch (Random.Next(2))
                {
                    case 0: types.Add(ItemsConstants.Gear.Types.Shield); break;
                    default: break;
                }
            }

            switch (Random.Next(3))
            {
                case 0: types.Add(ItemsConstants.Gear.Types.Metal); break;
                case 1: types.Add(ItemsConstants.Gear.Types.Wood); break;
                default: break;
            }

            return types;
        }
    }
}