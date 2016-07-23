using Ninject;
using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;
using TreasureGen.Items;

namespace TreasureGen.Tests.Integration.Stress.Items.Mundane
{
    [TestFixture]
    public abstract class MundaneItemGeneratorStressTests : ItemTests
    {
        [Inject]
        public ItemVerifier ItemVerifier { get; set; }

        private IEnumerable<string> materials;

        [SetUp]
        public void MundaneItemGeneratorStressSetup()
        {
            materials = TraitConstants.GetSpecialMaterials();
        }

        protected void StressItem()
        {
            var item = GenerateItem();
            AssertItem(item);
        }

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