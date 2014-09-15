using System;
using System.Linq;
using EquipmentGen.Common.Items;
using EquipmentGen.Generators.Interfaces.Items.Magical;
using Ninject;
using NUnit.Framework;

namespace EquipmentGen.Tests.Integration.Stress.Items.Magical
{
    [TestFixture]
    public class SpecialAbilitiesGeneratorTests : StressTests
    {
        [Inject]
        public ISpecialAbilitiesGenerator SpecialAbilitiesGenerator { get; set; }

        [TestCase("Special abilities generator")]
        public override void Stress(String thingToStress)
        {
            Stress();
        }

        protected override void MakeAssertions()
        {
            var itemType = GetNewGearItemType();
            var attributes = GetNewAttributesForGear(itemType, false);
            var power = GetNewPower(false);
            var bonus = Random.Next(5) + 1;
            var quantity = Random.Next(10) + 1;
            var abilities = SpecialAbilitiesGenerator.GenerateFor(ItemTypeConstants.Armor, attributes, power, bonus, quantity);

            Assert.That(abilities.Count(), Is.AtLeast(1));

            var sum = abilities.Sum(a => a.BonusEquivalent);
            Assert.That(sum + bonus, Is.AtMost(10));

            var coreNames = abilities.Select(a => a.BaseName);
            var names = abilities.Select(a => a.Name);
            var message = String.Format("Power: {0}\nTypes: {1}\nBonus: {2}\nQuantity: {3}\nNames: {4}\nCore names: {5}",
                power, String.Join(", ", attributes), bonus, quantity, String.Join(", ", names), String.Join(", ", coreNames));
            var distinct = coreNames.Distinct();
            Assert.That(abilities.Count(), Is.EqualTo(distinct.Count()), message);

            foreach (var ability in abilities)
            {
                Assert.That(ability.Name, Is.Not.Empty);
                Assert.That(ability.BonusEquivalent, Is.InRange<Int32>(0, 5));
                Assert.That(ability.Strength, Is.Not.Negative);
                Assert.That(ability.AttributeRequirements, Is.Not.Null);
                Assert.That(ability.BaseName, Is.Not.Empty);
            }
        }
    }
}