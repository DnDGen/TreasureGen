using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using TreasureGen.Items;
using TreasureGen.Items.Magical;

namespace TreasureGen.Tests.Integration.Stress.Items.Magical
{
    [TestFixture]
    public abstract class MagicalItemGeneratorStressTests : ItemStressTests
    {
        protected abstract string itemType { get; }
        protected abstract bool allowMinor { get; }

        protected IEnumerable<string> materials;
        protected MagicalItemGenerator magicalItemGenerator;
        private IEnumerable<string> specialAbilities;

        [SetUp]
        public void MundaneItemGeneratorStressSetup()
        {
            magicalItemGenerator = GetNewInstanceOf<MagicalItemGenerator>(itemType);

            materials = TraitConstants.SpecialMaterials.All();
            specialAbilities = SpecialAbilityConstants.GetAllAbilities();
        }

        protected void StressItem()
        {
            var item = Generate(GenerateItem, i => i.ItemType == itemType);
            AssertItem(item);
        }

        protected override Item GenerateItem()
        {
            var power = GetNewPower(allowMinor);
            return magicalItemGenerator.GenerateAtPower(power);
        }

        private Item GetRandomTemplate(string name)
        {
            var template = ItemVerifier.CreateRandomTemplate(name);

            var abilitiesCount = Random.Next(specialAbilities.Count()) + 1;
            var abilityNames = specialAbilities.Take(abilitiesCount);
            template.Magic.SpecialAbilities = abilityNames.Select(n => new SpecialAbility { Name = n });

            return template;
        }

        protected void StressCustomItem()
        {
            var name = GetRandomName();
            var template = GetRandomTemplate(name);
            var allowDecoration = Convert.ToBoolean(Random.Next(2));

            var item = magicalItemGenerator.Generate(template, allowDecoration);
            AssertItem(item);
            Assert.That(item.Name, Is.EqualTo(name));

            if (!allowDecoration)
                ItemVerifier.AssertMagicalItemFromTemplate(item, template);
        }

        protected void StressItemFromSubset()
        {
            var names = GetItemNames();
            var subset = GetRandomSubset(names);

            var item = GenerateItemFromSubset(subset);
            AssertItem(item);
            Assert.That(item.ItemType, Is.EqualTo(itemType));
            Assert.That(subset.Any(n => item.NameMatches(n)), Is.True, $"{item.Name} ({string.Join(", ", item.BaseNames)}) from [{string.Join(", ", subset)}]");
        }

        protected override Item GenerateItemFromSubset(IEnumerable<string> subset)
        {
            var power = GetNewPower(allowMinor);
            return magicalItemGenerator.GenerateFromSubset(power, subset);
        }
    }
}