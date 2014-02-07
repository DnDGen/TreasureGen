using EquipmentGen.Core.Data.Items;
using NUnit.Framework;

namespace EquipmentGen.Tests.Unit.Data.Items
{
    [TestFixture]
    public class SpecialAbilityConstantsTests
    {
        [Test]
        public void GlameredConstant()
        {
            Assert.That(SpecialAbilityConstants.Glamered, Is.EqualTo("Glamered"));
        }

        [Test]
        public void AbilityConstant()
        {
            Assert.Fail();
        }
    }
}