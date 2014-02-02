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
        public void GearWithOneAbility()
        {
            gear.Abilities = new[] 
            {
                new SpecialAbility() { Name = "ability" }
            };

            Assert.That(gear.ToString(), Is.EqualTo("shiny gear of ability"));
        }

        [Test]
        public void GearWithTwoAbilities()
        {
            gear.Abilities = new[] 
            {
                new SpecialAbility() { Name = "ability" },
                new SpecialAbility() { Name = "second ability" }
            };

            Assert.That(gear.ToString(), Is.EqualTo("shiny gear of ability and second ability"));
        }

        [Test]
        public void GearWithThreeAbilities()
        {
            gear.Abilities = new[] 
            {
                new SpecialAbility() { Name = "ability" },
                new SpecialAbility() { Name = "second ability" },
                new SpecialAbility() { Name = "third ability" }
            };

            Assert.That(gear.ToString(), Is.EqualTo("shiny gear of ability, second ability, and third ability"));
        }

        [Test]
        public void GearWithMagicalBonusAndAbilitiesAndTraits()
        {
            gear.MagicalBonus = 2;
            gear.Traits.Add("trait");
            gear.Traits.Add("other trait");
            gear.Traits.Add("third trait");
            gear.Abilities = new[] 
            {
                new SpecialAbility() { Name = "ability" },
                new SpecialAbility() { Name = "second ability" },
                new SpecialAbility() { Name = "third ability" }
            };

            Assert.That(gear.ToString(), Is.EqualTo("+2 shiny gear of ability, second ability, and third ability (trait, other trait, third trait)"));
        }
    }
}