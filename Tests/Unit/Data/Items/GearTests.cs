using System;
using System.Linq;
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
            gear = new Gear() { Name = "shiny gear", Abilities = Enumerable.Empty<String>(), Traits = Enumerable.Empty<String>() };
        }

        [Test]
        public void PlainGear()
        {
            Assert.That(gear.ToString(), Is.EqualTo(gear.Name));
        }

        [Test]
        public void MasterworkGear()
        {
            gear.IsMasterwork = true;
            Assert.That(gear.ToString(), Is.EqualTo("Masterwork shiny gear"));
        }

        [Test]
        public void GearWithMagicalBonus()
        {
            gear.MagicalBonus = 3;
            Assert.That(gear.ToString(), Is.EqualTo("+3 shiny gear"));
        }

        [Test]
        public void GearWithOneTrait()
        {
            gear.Traits = new[] { "trait" };
            Assert.That(gear.ToString(), Is.EqualTo("shiny gear (trait)"));
        }

        [Test]
        public void GearWithTwoTraits()
        {
            gear.Traits = new[] { "trait", "other trait" };
            Assert.That(gear.ToString(), Is.EqualTo("shiny gear (trait, other trait)"));
        }

        [Test]
        public void GearWithThreeTraits()
        {
            gear.Traits = new[] { "trait", "other trait", "third trait" };
            Assert.That(gear.ToString(), Is.EqualTo("shiny gear (trait, other trait, third trait)"));
        }

        [Test]
        public void GearWithOneAbility()
        {
            gear.Abilities = new[] { "ability" };
            Assert.That(gear.ToString(), Is.EqualTo("shiny gear of ability"));
        }

        [Test]
        public void GearWithTwoAbilities()
        {
            gear.Abilities = new[] { "ability", "second ability" };
            Assert.That(gear.ToString(), Is.EqualTo("shiny gear of ability and second ability"));
        }

        [Test]
        public void GearWithThreeAbilities()
        {
            gear.Abilities = new[] { "ability", "second ability", "third ability" };
            Assert.That(gear.ToString(), Is.EqualTo("shiny gear of ability, second ability, and third ability"));
        }

        [Test]
        public void GearWithMagicalBonusAndAbilitiesAndTraits()
        {
            gear.MagicalBonus = 2;
            gear.Abilities = new[] { "ability", "second ability", "third ability" };
            gear.Traits = new[] { "trait", "other trait", "third trait" };

            Assert.That(gear.ToString(), Is.EqualTo("+2 shiny gear of ability, second ability, and third ability (trait, other trait, third trait)"));
        }
    }
}