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

            var item = mundaneItemGenerator.Generate(template);
            AssertItem(item);
            ItemVerifier.AssertMundaneItemFromTemplate(item, template);
        }

        private string GetRandom(IEnumerable<string> collection)
        {
            var randomIndex = Random.Next(collection.Count());
            return collection.ElementAt(randomIndex);
        }

        protected override Item GenerateRandomCustomItem(string name)
        {
            var template = new Item();
            template.Name = name;

            return mundaneItemGenerator.Generate(template, true);
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