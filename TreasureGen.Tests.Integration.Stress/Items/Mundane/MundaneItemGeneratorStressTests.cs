using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using TreasureGen.Items;
using TreasureGen.Items.Mundane;

namespace TreasureGen.Tests.Integration.Stress.Items.Mundane
{
    [TestFixture]
    public abstract class MundaneItemGeneratorStressTests : ItemStressTests
    {
        protected MundaneItemGenerator mundaneItemGenerator;
        private IEnumerable<string> materials;

        [SetUp]
        public void MundaneItemGeneratorStressSetup()
        {
            materials = TraitConstants.SpecialMaterials.All();
        }

        protected void StressItem()
        {
            var item = GenerateItem();
            AssertItem(item);
        }

        protected override Item GenerateItem()
        {
            return mundaneItemGenerator.Generate();
        }

        protected void StressRandomCustomItem()
        {
            var names = GetItemNames();
            var name = GetRandom(names);

            var item = GenerateRandomCustomItem(name);
            AssertItem(item);
            Assert.That(item.Name, Is.EqualTo(name));
        }

        protected void StressCustomItem()
        {
            var names = GetItemNames();
            var name = GetRandom(names);
            var template = ItemVerifier.CreateRandomTemplate(name);

            var item = mundaneItemGenerator.GenerateFrom(template);
            AssertItem(item);
            ItemVerifier.AssertMundaneItemFromTemplate(item, template);
        }

        protected void StressItemFromSubset()
        {
            var names = GetItemNames();
            var subset = GetRandomSubset(names);
            var item = GenerateItemFromSubset(subset);
            AssertItem(item);
            Assert.That(subset.Any(n => item.NameMatches(n)), Is.True, $"{item.Name} ({string.Join(", ", item.BaseNames)}) from [{string.Join(", ", subset)}]");
        }

        protected override Item GenerateItemFromSubset(IEnumerable<string> subset)
        {
            return mundaneItemGenerator.GenerateFrom(subset);
        }

        private string GetRandom(IEnumerable<string> collection)
        {
            var count = collection.Count();
            var randomIndex = Random.Next(count);
            return collection.ElementAt(randomIndex);
        }

        private IEnumerable<string> GetRandomSubset(IEnumerable<string> collection)
        {
            var limit = collection.Count() / 2;
            var skipAmount = Random.Next(limit);
            var takeAmount = Random.Next(limit) + 1;

            return collection.Skip(skipAmount).Take(takeAmount);
        }

        protected override Item GenerateRandomCustomItem(string name)
        {
            var template = new Item();
            template.Name = name;

            return mundaneItemGenerator.GenerateFrom(template, true);
        }

        protected abstract IEnumerable<string> GetItemNames();

        protected void AssertItem(Item item)
        {
            ItemVerifier.AssertItem(item);
            MakeSpecificAssertionsAgainst(item);
        }

        protected abstract void MakeSpecificAssertionsAgainst(Item item);

        public virtual void SpecialMaterialsHappen()
        {
            var item = GenerateOrFail(GenerateItem, i => i.Traits.Intersect(materials).Any());
            AssertItem(item);
            Assert.That(item.Traits.Intersect(materials), Is.Not.Empty);
        }

        public abstract void NoDecorationsHappen();

        public void AssertNoDecorationsHappen()
        {
            var item = GenerateOrFail(GenerateItem, i => i.Traits.Intersect(materials).Any() == false);
            AssertItem(item);
            Assert.That(item.Traits.Intersect(materials), Is.Empty);
        }
    }
}