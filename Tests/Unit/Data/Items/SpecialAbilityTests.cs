using EquipmentGen.Core.Data.Items;
using NUnit.Framework;

namespace EquipmentGen.Tests.Unit.Data.Items
{
    [TestFixture]
    public class SpecialAbilityTests
    {
        private SpecialAbility ability;

        [SetUp]
        public void Setup()
        {
            ability = new SpecialAbility();
        }

        [Test]
        public void TypeRequirementsInitialized()
        {
            Assert.That(ability.AttributeRequirements, Is.Not.Null);
        }
    }
}