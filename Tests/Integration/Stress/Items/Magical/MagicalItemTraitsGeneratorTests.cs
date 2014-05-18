using System;
using System.Collections.Generic;
using System.Linq;
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

        [Test]
        public void StressedMagicalItemTraitsGenerator()
        {
            StressGenerator();
        }

        protected override void MakeAssertions()
        {
            var itemType = GetNewMagicalItemType();
            var attributes = GetNewAttributesFor(itemType);
            var traits = TraitsGenerator.GenerateFor(itemType, attributes);

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
                case 5: return ItemTypeConstants.Weapon;
                case 6: return ItemTypeConstants.WondrousItem;
                default: throw new ArgumentOutOfRangeException();
            }
        }

        private IEnumerable<String> GetNewAttributesFor(String itemType)
        {
            if (itemType == ItemTypeConstants.Weapon || itemType == ItemTypeConstants.Armor)
                return GetNewAttributesForGear(itemType, false);

            var quantity = Random.Next(5);
            var attributes = new List<String>();

            while (quantity-- > 0)
            {
                switch (Random.Next(5))
                {
                    case 0: attributes.Add(AttributeConstants.Charged); break;
                    case 1: attributes.Add(AttributeConstants.Metal); break;
                    case 2: attributes.Add(AttributeConstants.OneTimeUse); break;
                    case 3: attributes.Add(AttributeConstants.Specific); break;
                    case 4: attributes.Add(AttributeConstants.Wood); break;
                }
            }

            return attributes.Distinct();
        }
    }
}