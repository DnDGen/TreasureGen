using System;
using System.Collections.Generic;
using System.Linq;
using EquipmentGen.Common.Items;
using EquipmentGen.Generators.Interfaces.Items.Magical;
using Ninject;
using NUnit.Framework;

namespace EquipmentGen.Tests.Integration.Stress.Items.Magical
{
    [TestFixture]
    public class IntelligenceGeneratorTests : StressTests
    {
        [Inject]
        public IIntelligenceGenerator IntelligenceGenerator { get; set; }
        [Inject]
        public ISpecialAbilitiesGenerator AbilitiesGenerator { get; set; }

        private IEnumerable<String> alignments;
        private IEnumerable<String> armorNames;
        private IEnumerable<String> weaponNames;

        [SetUp]
        public void Setup()
        {
            alignments = new[]
                {
                    "Lawful good",
                    "Neutral good",
                    "Chaotic good",
                    "Lawful neutral",
                    "True neutral",
                    "Chaotic neutral",
                    "Lawful evil",
                    "Neutral evil",
                    "Chaotic evil",
                };

            armorNames = ArmorConstants.GetAllArmors();
            weaponNames = WeaponConstants.GetAllWeapons();
        }

        [TestCase("Intelligence generator")]
        public override void Stress(String thingToStress)
        {
            Stress();
        }

        protected override void MakeAssertions()
        {
            var itemType = GetNewGearItemType();
            var attributes = GetNewAttributesForGear(itemType, false);
            var power = GetNewPower(false);
            var quantity = Random.Next(10) + 1;

            var item = new Item();
            item.Name = GetItemName(itemType);
            item.Magic.Bonus = Random.Next(5) + 1;
            item.Magic.SpecialAbilities = AbilitiesGenerator.GenerateFor(itemType, attributes, power, item.Magic.Bonus, quantity);

            var intelligence = IntelligenceGenerator.GenerateFor(item);

            Assert.That(alignments, Contains.Item(intelligence.Alignment));
            Assert.That(intelligence.CharismaStat, Is.InRange<Int32>(10, 19));
            Assert.That(intelligence.Communication, Is.Not.Empty);
            Assert.That(intelligence.DedicatedPower, Is.Not.Null);
            Assert.That(intelligence.Ego, Is.GreaterThan(0));
            Assert.That(intelligence.IntelligenceStat, Is.InRange<Int32>(10, 19));
            Assert.That(intelligence.Powers, Is.Not.Empty);
            Assert.That(intelligence.Senses, Is.Not.Empty);
            Assert.That(intelligence.SpecialPurpose, Is.Not.Null);
            Assert.That(intelligence.WisdomStat, Is.InRange<Int32>(10, 19));
            Assert.That(intelligence.Personality, Is.Not.Null);

            if (intelligence.Communication.Contains("Speech"))
                Assert.That(intelligence.Languages, Contains.Item("Common"));
            else
                Assert.That(intelligence.Languages, Is.Empty);
        }

        private String GetItemName(String itemType)
        {
            if (itemType == ItemTypeConstants.Armor)
                return GetArmorName();

            return GetWeaponName();
        }

        private String GetArmorName()
        {
            var index = Random.Next(armorNames.Count());
            return armorNames.ElementAt(index);
        }

        private String GetWeaponName()
        {
            var index = Random.Next(weaponNames.Count());
            return weaponNames.ElementAt(index);
        }

        [Test]
        public void SpecialPurposeHappens()
        {
            Assert.Fail();
        }
    }
}