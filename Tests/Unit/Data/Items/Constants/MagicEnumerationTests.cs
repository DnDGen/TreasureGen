using EquipmentGen.Core.Data.Items.Constants;
using NUnit.Framework;

namespace EquipmentGen.Tests.Unit.Data.Items.Constants
{
    [TestFixture]
    public class MagicEnumerationTests
    {
        [Test]
        public void BonusConstant()
        {
            Assert.That(Magic.Bonus, Is.EqualTo(0));
        }

        [Test]
        public void AbilitiesConstant()
        {
            Assert.That(Magic.Abilities, Is.EqualTo(1));
        }

        [Test]
        public void ChargesConstant()
        {
            Assert.That(Magic.Charges, Is.EqualTo(2));
        }

        [Test]
        public void IntelligenceConstant()
        {
            Assert.That(Magic.Intelligence, Is.EqualTo(3));
        }

        [Test]
        public void CurseConstant()
        {
            Assert.That(Magic.Curse, Is.EqualTo(4));
        }
    }
}