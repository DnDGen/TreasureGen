using System;
using NUnit.Framework;

namespace EquipmentGen.Tests.Integration.Tables.Items.Magical.WondrousItems
{
    [TestFixture]
    public class PlanesTests : PercentileTests
    {
        protected override String tableName
        {
            get { return "Planes"; }
        }

        [TestCase("Material Plane", 1, 5)]
        [TestCase("Ethereal Plane", 6, 10)]
        [TestCase("Plane of Shadow", 11, 15)]
        [TestCase("Astral plane", 16, 20)]
        [TestCase("Elemental Plane of Air", 21, 25)]
        [TestCase("Elemental Plane of Earth", 26, 30)]
        [TestCase("Elemental Plane of Fire", 31, 35)]
        [TestCase("Elemental Plane of Water", 36, 40)]
        [TestCase("Negative Energy Plane", 41, 45)]
        [TestCase("Positive Energy Plane", 46, 50)]
        [TestCase("Celestia", 51, 53)]
        [TestCase("Bytopia", 54, 56)]
        [TestCase("Elysium", 57, 59)]
        [TestCase("Beastlands", 60, 62)]
        [TestCase("Arborea", 63, 65)]
        [TestCase("Arcadia", 66, 68)]
        [TestCase("Ysgard", 69, 71)]
        [TestCase("Mechanus", 72, 74)]
        [TestCase("Limbo", 75, 77)]
        [TestCase("Acheron", 78, 80)]
        [TestCase("Pandemonium", 81, 83)]
        [TestCase("Baator", 84, 86)]
        [TestCase("Gehenna", 87, 89)]
        [TestCase("Hades", 90, 92)]
        [TestCase("Carceri", 93, 95)]
        [TestCase("Abyss", 96, 98)]
        [TestCase("The Outlands", 99, 100)]
        public override void Percentile(String content, Int32 lower, Int32 upper)
        {
            base.Percentile(content, lower, upper);
        }
    }
}