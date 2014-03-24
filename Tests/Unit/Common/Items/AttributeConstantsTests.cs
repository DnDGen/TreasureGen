using System;
using EquipmentGen.Common.Items;
using NUnit.Framework;

namespace EquipmentGen.Tests.Unit.Common.Items
{
    [TestFixture]
    public class AttributeConstantsTests
    {
        [TestCase(AttributeConstants.Common, "Common")]
        [TestCase(AttributeConstants.Uncommon, "Uncommon")]
        [TestCase(AttributeConstants.Wood, "Wood")]
        [TestCase(AttributeConstants.Metal, "Metal")]
        [TestCase(AttributeConstants.DoubleWeapon, "Double weapon")]
        [TestCase(AttributeConstants.Melee, "Melee")]
        [TestCase(AttributeConstants.Ranged, "Ranged")]
        [TestCase(AttributeConstants.Ammunition, "Ammunition")]
        [TestCase(AttributeConstants.Shield, "Shield")]
        [TestCase(AttributeConstants.NotBludgeoning, "Not bludgeoning")]
        [TestCase(AttributeConstants.Bludgeoning, "Bludgeoning")]
        [TestCase(AttributeConstants.Thrown, "Thrown")]
        [TestCase(AttributeConstants.Slashing, "Slashing")]
        [TestCase(AttributeConstants.NotTower, "Not tower")]
        [TestCase(AttributeConstants.OneTimeUse, "One-time use")]
        [TestCase(AttributeConstants.Charged, "Charged")]
        public void AttributeConstantIsCorrect(String constant, String value)
        {
            Assert.That(constant, Is.EqualTo(value));
        }
    }
}