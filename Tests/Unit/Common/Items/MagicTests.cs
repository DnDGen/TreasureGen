using TreasureGen.Common.Items;
using NUnit.Framework;

namespace TreasureGen.Tests.Unit.Common.Items
{
    [TestFixture]
    public class MagicTests
    {
        private Magic magic;

        [SetUp]
        public void Setup()
        {
            magic = new Magic();
        }

        [Test]
        public void BonusInitialized()
        {
            Assert.That(magic.Bonus, Is.EqualTo(0));
        }

        [Test]
        public void Chargesinitialized()
        {
            Assert.That(magic.Charges, Is.EqualTo(0));
        }

        [Test]
        public void SpecialAbilitiesInitialized()
        {
            Assert.That(magic.SpecialAbilities, Is.Empty);
        }

        [Test]
        public void IntelligenceInitialized()
        {
            Assert.That(magic.Intelligence, Is.Not.Null);
        }

        [Test]
        public void CurseInitialized()
        {
            Assert.That(magic.Curse, Is.Empty);
        }
    }
}