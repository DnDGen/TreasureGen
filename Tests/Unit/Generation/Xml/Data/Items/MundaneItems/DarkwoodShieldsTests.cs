using EquipmentGen.Core.Data.Items;
using EquipmentGen.Tests.Unit.Generation.Xml.Data.Attributes;
using NUnit.Framework;

namespace EquipmentGen.Tests.Unit.Generation.Xml.Data.Items.MundaneItems
{
    [TestFixture, PercentileTable("DarkwoodShields")]
    public class DarkwoodShieldsTests : PercentileTests
    {
        [Test]
        public void DarkwoodBucklerPercentile()
        {
            AssertContent(ItemsConstants.Gear.Armor.Buckler, 1, 50);
        }

        [Test]
        public void DarkwoodShieldPercentile()
        {
            AssertContent(ItemsConstants.Gear.Armor.HeavyWoodenShield, 51, 100);
        }
    }
}