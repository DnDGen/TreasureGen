using EquipmentGen.Core.Data.Items;
using NUnit.Framework;

namespace EquipmentGen.Tests.Unit.Common.Items
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
    }
}