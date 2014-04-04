using System;
using NUnit.Framework;

namespace EquipmentGen.Tests.Integration.Tables.Items.Magical.Intelligence
{
    [TestFixture]
    public class IntelligenceLesserPowersCountTests : AttributesTests
    {
        protected override String GetTableName()
        {
            return "IntelligenceLesserPowersCount";
        }

        [TestCase("12", "1")]
        [TestCase("13", "2")]
        [TestCase("14", "2")]
        [TestCase("15", "3")]
        [TestCase("16", "3")]
        [TestCase("17", "3")]
        [TestCase("18", "3")]
        [TestCase("19", "4")]
        public void LesserPowersCount(String strength, String count)
        {
            var attributes = new[] { count };
            AssertContent(strength, attributes);
        }
    }
}