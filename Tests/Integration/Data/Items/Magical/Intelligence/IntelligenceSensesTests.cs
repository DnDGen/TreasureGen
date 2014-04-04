using System;
using NUnit.Framework;

namespace EquipmentGen.Tests.Integration.Tables.Items.Magical.Intelligence
{
    [TestFixture]
    public class IntelligenceSensesTests : AttributesTests
    {
        protected override String GetTableName()
        {
            return "IntelligenceSenses";
        }

        [TestCase("12", "30 ft. vision and hearing")]
        [TestCase("13", "60 ft. vision and hearing")]
        [TestCase("14", "120 ft. vision and hearing")]
        [TestCase("15", "60 ft. darkvision and hearing")]
        [TestCase("16", "60 ft. darkvision and hearing")]
        [TestCase("17", "120 ft. darkvision and hearing")]
        [TestCase("18", "120 ft. darkvision, blindsense, and hearing")]
        [TestCase("19", "120 ft. darkvision, blindsense, and hearing")]
        public void Senses(String strength, String senses)
        {
            var attributes = new[] { senses };
            AssertContent(strength, attributes);
        }
    }
}