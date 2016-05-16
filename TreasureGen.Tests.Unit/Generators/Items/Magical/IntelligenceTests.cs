using NUnit.Framework;
using TreasureGen.Items.Magical;

namespace TreasureGen.Tests.Unit.Generators.Items.Magical
{
    [TestFixture]
    public class IntelligenceTests
    {
        private Intelligence intelligence;

        [SetUp]
        public void Setup()
        {
            intelligence = new Intelligence();
        }

        [Test]
        public void IntelligenceStatInitialized()
        {
            Assert.That(intelligence.IntelligenceStat, Is.EqualTo(0));
        }

        [Test]
        public void CharismaStatInitialized()
        {
            Assert.That(intelligence.CharismaStat, Is.EqualTo(0));
        }

        [Test]
        public void WisdomStatInitialized()
        {
            Assert.That(intelligence.WisdomStat, Is.EqualTo(0));
        }

        [Test]
        public void PowersInitialized()
        {
            Assert.That(intelligence.Powers, Is.Empty);
        }

        [Test]
        public void AlignmentInitialized()
        {
            Assert.That(intelligence.Alignment, Is.Empty);
        }

        [Test]
        public void CommunicationInitialized()
        {
            Assert.That(intelligence.Communication, Is.Empty);
        }

        [Test]
        public void DedicatedPowerInitialized()
        {
            Assert.That(intelligence.DedicatedPower, Is.Empty);
        }

        [Test]
        public void EgoInitialized()
        {
            Assert.That(intelligence.Ego, Is.EqualTo(0));
        }

        [Test]
        public void SensesInitialized()
        {
            Assert.That(intelligence.Senses, Is.Empty);
        }

        [Test]
        public void SpecialPurposeInitialized()
        {
            Assert.That(intelligence.SpecialPurpose, Is.Empty);
        }

        [Test]
        public void LanguagesAreInitialized()
        {
            Assert.That(intelligence.Languages, Is.Empty);
        }

        [Test]
        public void PersonalityIsInitialized()
        {
            Assert.That(intelligence.Personality, Is.Empty);
        }
    }
}