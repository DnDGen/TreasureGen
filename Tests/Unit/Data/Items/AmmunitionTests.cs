using EquipmentGen.Core.Data.Items;
using NUnit.Framework;

namespace EquipmentGen.Tests.Unit.Data.Items
{
    [TestFixture]
    public class AmmunitionTests
    {
        private Ammunition ammo;

        [SetUp]
        public void Setup()
        {
            ammo = new Ammunition();
        }

        [Test]
        public void AmmunitionToString()
        {
            ammo.Name = "ammo";
            ammo.Quantity = 9266;

            Assert.That(ammo.ToString(), Is.EqualTo("ammo (9266)"));
        }
    }
}