using EquipmentGen.Core.Data.Items;
using NUnit.Framework;

namespace EquipmentGen.Tests.Unit.Generation.Xml.Data.Items.MundaneItems
{
    [TestFixture]
    public class DarkwoodShieldsTests : PercentileTests
    {
        [SetUp]
        public void Setup()
        {
            tableName = "DarkwoodShields";
        }

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