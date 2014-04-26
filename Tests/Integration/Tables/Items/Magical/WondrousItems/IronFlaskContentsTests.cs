using System;
using NUnit.Framework;

namespace EquipmentGen.Tests.Integration.Tables.Items.Magical.WondrousItems
{
    [TestFixture]
    public class IronFlaskContentsTests : PercentileTests
    {
        protected override String tableName
        {
            get { return "IronFlaskContents"; }
        }

        [TestCase(EmptyContent, 1, 50)]
        [TestCase("Large air elemental", 51, 54)]
        [TestCase("Arrowhawk", 55, 58)]
        [TestCase("Large earth elemental", 59, 62)]
        [TestCase("Xorn", 63, 66)]
        [TestCase("Large fire elemental", 67, 70)]
        [TestCase("Salamander", 71, 74)]
        [TestCase("Large water elemental", 75, 78)]
        [TestCase("Adult tojanida", 79, 82)]
        [TestCase("Chaos beast", 83, 84)]
        [TestCase("Formian taskmaster", 85, 86)]
        public void Percentile(String content, Int32 lower, Int32 upper)
        {
            AssertPercentile(content, lower, upper);
        }

        [TestCase("Vrock", 87)]
        [TestCase("Hezrou", 88)]
        [TestCase("Glabrezu", 89)]
        [TestCase("Succubus", 90)]
        [TestCase("Osyluth", 91)]
        [TestCase("Barbazu", 92)]
        [TestCase("Erinyes", 93)]
        [TestCase("Cornugon", 94)]
        [TestCase("Avoral", 95)]
        [TestCase("Ghaele", 96)]
        [TestCase("Formian myrmarch", 97)]
        [TestCase("Elder arrowhawk", 98)]
        [TestCase("Rakshasa", 99)]
        [TestCase("BalorOrPitFiend", 100)]
        public void Percentile(String content, Int32 roll)
        {
            AssertPercentile(content, roll);
        }
    }
}