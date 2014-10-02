using System;
using EquipmentGen.Tables.Interfaces;
using NUnit.Framework;

namespace EquipmentGen.Tests.Integration.Tables.Items.Magical.Intelligence
{
    [TestFixture]
    public class IntelligenceAttributesTests : AttributesTests
    {
        protected override String tableName
        {
            get { return TableNameConstants.Attributes.Set.IntelligenceAttributes; }
        }

        [TestCase("12", "30 ft. vision and hearing", 1, 0)]
        [TestCase("13", "60 ft. vision and hearing", 2, 0)]
        [TestCase("14", "120 ft. vision and hearing", 2, 0)]
        [TestCase("15", "60 ft. darkvision and hearing", 3, 0)]
        [TestCase("16", "60 ft. darkvision and hearing", 3, 0)]
        [TestCase("17", "120 ft. darkvision and hearing", 3, 1)]
        [TestCase("18", "120 ft. darkvision, blindsense, and hearing", 3, 2)]
        [TestCase("19", "120 ft. darkvision, blindsense, and hearing", 4, 3)]
        public void OrderedAttributes(String strength, String senses, Int32 lesserPowersCount, Int32 greaterPowersCount)
        {
            var attributes = new[]
            {
                senses, 
                Convert.ToString(lesserPowersCount),
                Convert.ToString(greaterPowersCount) 
            };

            OrderedAttributes(strength, attributes);
        }
    }
}