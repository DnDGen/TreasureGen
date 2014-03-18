using EquipmentGen.Tests.Integration.Tables.Attributes;
using NUnit.Framework;

namespace EquipmentGen.Tests.Integration.Tables.Items.MagicalItems.Armor.Medium
{
    [TestFixture, PercentileTable("MediumSpecificShields")]
    public class MediumSpecificShieldsTests : PercentileTests
    {
        [Test]
        public void DarkwoodBucklerPercentile()
        {
            AssertContent("Darkwood buckler", 1, 20);
        }

        [Test]
        public void DarkwoodShieldPercentile()
        {
            AssertContent("Darkwood shield", 21, 45);
        }

        [Test]
        public void MithralHeavyShieldPercentile()
        {
            AssertContent("Mithral heavy shield", 46, 70);
        }

        [Test]
        public void CastersShieldPercentile()
        {
            AssertContent("Caster's shield", 71, 85);
        }

        [Test]
        public void SpinedShieldPercentile()
        {
            AssertContent("Spined shield", 86, 90);
        }

        [Test]
        public void LionsShieldPercentile()
        {
            AssertContent("Lion's shield", 91, 95);
        }

        [Test]
        public void WingedShieldPercentile()
        {
            AssertContent("Winged shield", 96, 100);
        }
    }
}