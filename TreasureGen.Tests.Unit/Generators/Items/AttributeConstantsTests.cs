using NUnit.Framework;
using TreasureGen.Items;

namespace TreasureGen.Tests.Unit.Generators.Items
{
    [TestFixture]
    public class AttributeConstantsTests
    {
        [TestCase(AttributeConstants.Ammunition, "Ammunition")]
        [TestCase(AttributeConstants.Charged, "Charged")]
        [TestCase(AttributeConstants.DoubleWeapon, "Double weapon")]
        [TestCase(AttributeConstants.Exotic, "Exotic")]
        [TestCase(AttributeConstants.Light, "Light")]
        [TestCase(AttributeConstants.Martial, "Martial")]
        [TestCase(AttributeConstants.Melee, "Melee")]
        [TestCase(AttributeConstants.Metal, "Metal")]
        [TestCase(AttributeConstants.OneHanded, "One-Handed")]
        [TestCase(AttributeConstants.OneTimeUse, "One-time use")]
        [TestCase(AttributeConstants.Projectile, "Projectile")]
        [TestCase(AttributeConstants.Ranged, "Ranged")]
        [TestCase(AttributeConstants.Reach, "Reach")]
        [TestCase(AttributeConstants.Shield, "Shield")]
        [TestCase(AttributeConstants.Simple, "Simple")]
        [TestCase(AttributeConstants.Thrown, "Thrown")]
        [TestCase(AttributeConstants.TowerShield, "Tower shield")]
        [TestCase(AttributeConstants.TwoHanded, "Two-Handed")]
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