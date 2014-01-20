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
            gear.Name = "shiny gear";
        }

        [Test]
        public void PlainGear()
        {
            Assert.That(gear.ToString(), Is.EqualTo(gear.Name));
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
            gear.Traits.Add("trait");

            Assert.That(gear.ToString(), Is.EqualTo("shiny gear (trait)"));
        }

        [Test]
        public void GearWithTwoTraits()
        {
            gear.Traits.Add("trait");
            gear.Traits.Add("other trait");

            Assert.That(gear.ToString(), Is.EqualTo("shiny gear (trait, other trait)"));
        }

        [Test]
        public void GearWithThreeTraits()
        {
            gear.Traits.Add("trait");
            gear.Traits.Add("other trait");
            gear.Traits.Add("third trait");

            Assert.That(gear.ToString(), Is.EqualTo("shiny gear (trait, other trait, third trait)"));
        }

        [Test]
        public void GearWithOneAbility()
        {
            gear.Abilities.Add("ability");

            Assert.That(gear.ToString(), Is.EqualTo("shiny gear of ability"));
        }

        [Test]
        public void GearWithTwoAbilities()
        {
            gear.Abilities.Add("ability");
            gear.Abilities.Add("second ability");

            Assert.That(gear.ToString(), Is.EqualTo("shiny gear of ability and second ability"));
        }

        [Test]
        public void GearWithThreeAbilities()
        {
            gear.Abilities.Add("ability");
            gear.Abilities.Add("second ability");
            gear.Abilities.Add("third ability");

            Assert.That(gear.ToString(), Is.EqualTo("shiny gear of ability, second ability, and third ability"));
        }

        [Test]
        public void GearWithMagicalBonusAndAbilitiesAndTraits()
        {
            gear.MagicalBonus = 2;
            gear.Abilities.Add("ability");
            gear.Abilities.Add("second ability");
            gear.Abilities.Add("third ability");
            gear.Traits.Add("trait");
            gear.Traits.Add("other trait");
            gear.Traits.Add("third trait");

            Assert.That(gear.ToString(), Is.EqualTo("+2 shiny gear of ability, second ability, and third ability (trait, other trait, third trait)"));
        }
    }
}