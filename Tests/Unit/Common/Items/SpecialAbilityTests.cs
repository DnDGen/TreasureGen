using EquipmentGen.Common.Items;
using NUnit.Framework;

namespace EquipmentGen.Tests.Unit.Common.Items
{
    [TestFixture]
    public class SpecialAbilityTests
    {
        private SpecialAbility specialAbility;

        [SetUp]
        public void Setup()
        {
            specialAbility = new SpecialAbility();
        }

        [Test]
        public void NameInitialized()
        {
            Assert.That(specialAbility.Name, Is.Empty);
        }

        [Test]
        public void AttributeRequirementsInitialized()
        {
            Assert.That(specialAbility.AttributeRequirements, Is.Empty);
        }

        [Test]
        public void BonusEquivalentInitialized()
        {
            Assert.That(specialAbility.BonusEquivalent, Is.EqualTo(0));
        }

        [Test]
        public void CoreNameInitialized()
        {
            Assert.That(specialAbility.BaseName, Is.Empty);
        }

        [Test]
        public void StrengthInitialized()
        {
            Assert.That(specialAbility.Strength, Is.EqualTo(0));
        }
    }
}