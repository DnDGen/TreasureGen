using System;
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
            ability.Name = "ability name";
        }

        [Test]
        public void SpecialAbilityWithStrengthOf0()
        {
            ability.Strength = 0;
            var toString = ability.ToString();
            Assert.That(toString, Is.EqualTo("ability name"));
        }

        [Test]
        public void SpecialAbilityWithStrengthOf1()
        {
            ability.Strength = 1;
            var toString = ability.ToString();
            Assert.That(toString, Is.EqualTo("Improved ability name"));
        }

        [Test]
        public void SpecialAbilityWithStrengthOf2()
        {
            ability.Strength = 2;
            var toString = ability.ToString();
            Assert.That(toString, Is.EqualTo("Greater ability name"));
        }

        [Test]
        public void SpecialAbilityWithStrengthGreaterThan2()
        {
            ability.Strength = 9266;
            var toString = ability.ToString();
            Assert.That(toString, Is.EqualTo("ability name (9266)"));
        }

        [Test]
        public void FortificationWithStrengthOf0()
        {
            ability.Strength = 0;
            ability.Name = "fortification";
            var toString = ability.ToString();
            Assert.That(toString, Is.EqualTo("Light fortification"));
        }

        [Test]
        public void FortificationWithStrengthOf1()
        {
            ability.Strength = 1;
            ability.Name = "fortification";
            var toString = ability.ToString();
            Assert.That(toString, Is.EqualTo("Moderate fortification"));
        }

        [Test]
        public void FortificationWithStrengthOf2()
        {
            ability.Strength = 2;
            ability.Name = "fortification";
            var toString = ability.ToString();
            Assert.That(toString, Is.EqualTo("Heavy fortification"));
        }

        [Test]
        public void FortificationWithStrengthGreaterThan2()
        {
            ability.Strength = 9266;
            ability.Name = "fortification";
            Assert.That(() => ability.ToString(), Throws.InstanceOf<ArgumentOutOfRangeException>());
        }
    }
}