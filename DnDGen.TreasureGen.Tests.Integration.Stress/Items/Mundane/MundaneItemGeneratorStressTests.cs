using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;
using DnDGen.TreasureGen.Items;
using DnDGen.TreasureGen.Items.Mundane;

namespace DnDGen.TreasureGen.Tests.Integration.Stress.Items.Mundane
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

        protected void GenerateAndAssertItem()
        {
            var item = GenerateItem();
            AssertItem(item);
        }

        protected override Item GenerateItem()
        {
            return mundaneItemGenerator.Generate();
        }

        protected void GenerateAndAssertCustomItem()
        {
            var name = GetRandomName();
            var template = ItemVerifier.CreateRandomTemplate(name);

            var item = mundaneItemGenerator.GenerateFrom(template);
            AssertItem(item);
            Assert.That(item.Name, Is.EqualTo(name));
            ItemVerifier.AssertMundaneItemFromTemplate(item, template);
        }

        protected void GenerateAndAssertItemFromSubset()
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
    }
}