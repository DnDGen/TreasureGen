using System;
using EquipmentGen.Common.Items;
using EquipmentGen.Generators.Interfaces.Items.Magical;
using Ninject;
using NUnit.Framework;

namespace EquipmentGen.Tests.Integration.Stress.Items.Magical
{
    [TestFixture]
    public class MagicalItemTraitsGeneratorTests : StressTests
    {
        [Inject]
        public IMagicalItemTraitsGenerator TraitsGenerator { get; set; }

        protected override void StressGenerator()
        {
            var itemType = GetNewMagicalItemType();
            var traits = TraitsGenerator.GenerateFor(itemType);

            Assert.That(traits, Is.Not.Null);
        }

        private String GetNewMagicalItemType()
        {
            switch (Random.Next(7))
            {
                case 0: return ItemTypeConstants.Armor;
                case 1: return ItemTypeConstants.Ring;
                case 2: return ItemTypeConstants.Rod;
                case 3: return ItemTypeConstants.Staff;
                case 4: return ItemTypeConstants.Wand;
                case 5: return AttributeConstants.Melee;
                case 6: return AttributeConstants.Ranged;
                case 7: return ItemTypeConstants.WondrousItem;
                default: throw new ArgumentOutOfRangeException();
            }
        }
    }
}