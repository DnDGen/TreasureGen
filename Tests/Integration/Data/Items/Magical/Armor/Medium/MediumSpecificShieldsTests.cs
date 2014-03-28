using EquipmentGen.Tests.Integration.Tables.TestAttributes;
using NUnit.Framework;

namespace EquipmentGen.Tests.Integration.Tables.Items.MagicalItems.Armor.Medium
{
    [TestFixture, PercentileTable("MediumSpecificShields")]
    public class MediumSpecificShieldsTests : PercentileTests
    {
        [Test]
        public void DarkwoodBucklerPercentile()
        {
            AssertPercentile("Darkwood buckler", 1, 20);
        }

        [Test]
        public void DarkwoodShieldPercentile()
        {
            AssertPercentile("Darkwood shield", 21, 45);
        }

        [Test]
        public void MithralHeavyShieldPercentile()
        {
            AssertPercentile("Mithral heavy shield", 46, 70);
        }

        [Test]
        public void CastersShieldPercentile()
        {
            AssertPercentile("Caster's shield", 71, 85);
        }

        [Test]
        public void SpinedShieldPercentile()
        {
            AssertPercentile("Spined shield", 86, 90);
        }

        [Test]
        public void LionsShieldPercentile()
        {
            AssertPercentile("Lion's shield", 91, 95);
        }

        [Test]
        public void WingedShieldPercentile()
        {
            AssertPercentile("Winged shield", 96, 100);
        }
    }
}