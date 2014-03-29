using System;
using NUnit.Framework;

namespace EquipmentGen.Tests.Integration.Tables.Items.Magical.Armor.Medium
{
    [TestFixture]
    public class MediumSpecificShieldsTests : PercentileTests
    {
        protected override String GetTableName()
        {
            return "MediumSpecificShields";
        }

        [TestCase("Darkwood buckler", 1, 20)]
        [TestCase("Darkwood shield", 21, 45)]
        [TestCase("Mithral heavy shield", 46, 70)]
        [TestCase("Caster's shield", 71, 85)]
        [TestCase("Spined shield", 86, 90)]
        [TestCase("Lion's shield", 91, 95)]
        [TestCase("Winged shield", 96, 100)]
        public void Percentile(String content, Int32 lower, Int32 upper)
        {
            AssertPercentile(content, lower, upper);
        }
    }
}