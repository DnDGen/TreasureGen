using EquipmentGen.Tests.Unit.Generation.Xml.Data.Attributes;
using NUnit.Framework;

namespace EquipmentGen.Tests.Unit.Generation.Xml.Data.Items.MagicalItems.WondrousItems
{
    [TestFixture, PercentileTable("MinorWondrousItems")]
    public class MinorWondrousItemsTests : PercentileTests
    {
        [Test]
        public void QuaalsFeatherTokenAnchorPercentile()
        {
            AssertContent("Quaal's feather token, anchor", 1);
        }

        [Test]
        public void UniversalSolventPercentile()
        {
            AssertContent("Universal solvent", 2);
        }

        [Test]
        public void ElixerOfLovePercentile()
        {
            AssertContent("Elixer of love", 3);
        }
    }
}