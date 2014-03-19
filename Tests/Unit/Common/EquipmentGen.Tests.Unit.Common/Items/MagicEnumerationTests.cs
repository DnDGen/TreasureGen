using System;
using EquipmentGen.Common.Items;
using NUnit.Framework;

namespace EquipmentGen.Tests.Unit.Common.Items
{
    [TestFixture]
    public class MagicEnumerationTests
    {
        [Test]
        public void BonusConstant()
        {
            var index = Convert.ToInt32(Magic.Bonus);
            Assert.That(index, Is.EqualTo(0));
        }

        [Test]
        public void AbilitiesConstant()
        {
            var index = Convert.ToInt32(Magic.Abilities);
            Assert.That(index, Is.EqualTo(1));
        }

        [Test]
        public void ChargesConstant()
        {
            var index = Convert.ToInt32(Magic.Charges);
            Assert.That(index, Is.EqualTo(2));
        }

        [Test]
        public void IntelligenceConstant()
        {
            var index = Convert.ToInt32(Magic.Intelligence);
            Assert.That(index, Is.EqualTo(3));
        }

        [Test]
        public void CurseConstant()
        {
            var index = Convert.ToInt32(Magic.Curse);
            Assert.That(index, Is.EqualTo(4));
        }
    }
}