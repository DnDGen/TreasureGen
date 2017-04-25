using NUnit.Framework;
using TreasureGen.Items;

namespace TreasureGen.Tests.Unit.Generators.Items
{
    [TestFixture]
    public class AttributeConstantsTests
    {
        [TestCase(AttributeConstants.Ammunition, "Ammunition")]
        [TestCase(AttributeConstants.Charged, "Charged")]
        [TestCase(AttributeConstants.Common, "Common")]
        [TestCase(AttributeConstants.DoubleWeapon, "Double weapon")]
        [TestCase(AttributeConstants.Melee, "Melee")]
        [TestCase(AttributeConstants.Metal, "Metal")]
        [TestCase(AttributeConstants.OneTimeUse, "One-time use")]
        [TestCase(AttributeConstants.Ranged, "Ranged")]
        [TestCase(AttributeConstants.Shield, "Shield")]
        [TestCase(AttributeConstants.Thrown, "Thrown")]
        [TestCase(AttributeConstants.TowerShield, "Tower shield")]
        [TestCase(AttributeConstants.TwoHanded, "Two-Handed")]
        [TestCase(AttributeConstants.Uncommon, "Uncommon")]
        [TestCase(AttributeConstants.Wood, "Wood")]
        [TestCase(AttributeConstants.DamageTypes.Bludgeoning, "Bludgeoning")]
        [TestCase(AttributeConstants.DamageTypes.Piercing, "Piercing")]
        [TestCase(AttributeConstants.DamageTypes.Slashing, "Slashing")]
        public void AttributeConstant(string constant, string value)
        {
            Assert.That(constant, Is.EqualTo(value));
        }
    }
}