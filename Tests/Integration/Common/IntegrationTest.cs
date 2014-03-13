using System;
using System.Collections.Generic;
using EquipmentGen.Bootstrap;
using EquipmentGen.Core.Data.Items.Constants;
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
                case 0: return PowerConstants.Minor;
                case 1: return PowerConstants.Medium;
                case 2: return PowerConstants.Major;
                case 3: return PowerConstants.Mundane;
                default: throw new ArgumentOutOfRangeException();
            }
        }

        protected IEnumerable<String> GetNewAttributes(Boolean allowNoMaterial)
        {
            var attributes = new List<String>();

            switch (Random.Next(2))
            {
                case 0: attributes.Add(ItemTypeConstants.Armor); break;
                case 1: attributes.Add(ItemTypeConstants.Weapon); break;
            }

            if (attributes.Contains(ItemTypeConstants.Weapon))
            {
                switch (Random.Next(3))
                {
                    case 0: attributes.Add(AttributeConstants.Melee); break;
                    case 1: attributes.Add(AttributeConstants.Ranged); break;
                    case 2:
                        attributes.Add(AttributeConstants.Melee);
                        attributes.Add(AttributeConstants.Ranged);
                        break;
                }

                switch (Random.Next(4))
                {
                    case 0: attributes.Add(AttributeConstants.Metal); break;
                    case 1: attributes.Add(AttributeConstants.Wood); break;
                    case 2:
                        attributes.Add(AttributeConstants.Metal);
                        attributes.Add(AttributeConstants.Wood);
                        break;
                    case 3:
                        if (allowNoMaterial)
                            break;
                        attributes.Add(AttributeConstants.Metal);
                        break;
                }
            }

            if (attributes.Contains(ItemTypeConstants.Armor))
            {
                switch (Random.Next(3))
                {
                    case 0: attributes.Add(AttributeConstants.Shield); break;
                    case 1: break;
                    case 2:
                        attributes.Add(AttributeConstants.Shield);
                        attributes.Add(AttributeConstants.NotTower);
                        break;
                }

                switch (Random.Next(3))
                {
                    case 0: attributes.Add(AttributeConstants.Metal); break;
                    case 1: attributes.Add(AttributeConstants.Wood); break;
                    case 2: break;
                }
            }

            return attributes;
        }
    }
}