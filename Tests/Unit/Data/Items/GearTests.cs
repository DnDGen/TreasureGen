using EquipmentGen.Core.Data.Items;
using NUnit.Framework;

namespace EquipmentGen.Tests.Unit.Data.Items
{
    [TestFixture]
    public class GearTests
    {
        private Gear gear;

        [SetUp]
        public void Setup()
        {
            gear = new Gear();
        }

        [Test]
        public void AbilitiesInitialized()
        {
            Assert.That(gear.Abilities, Is.Not.Null);
        }
    }
}