using System;
using NUnit.Framework;

namespace EquipmentGen.Tests.Integration.Tables.Items.Magical.Intelligence
{
    [TestFixture]
    public class IntelligenceGreaterPowersCountTests : AttributesTests
    {
        protected override String tableName
        {
            get { return "IntelligenceGreaterPowersCount"; }
        }

        [TestCase("12", "0")]
        [TestCase("13", "0")]
        [TestCase("14", "0")]
        [TestCase("15", "0")]
        [TestCase("16", "0")]
        [TestCase("17", "1")]
        [TestCase("18", "2")]
        [TestCase("19", "3")]
        public void IntelligenceGreaterPowersCount(String strength, String count)
        {
            var attributes = new[] { count };
            AssertAttributes(strength, attributes);
        }
    }
}