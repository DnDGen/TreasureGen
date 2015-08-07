using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using TreasureGen.Common.Items;

namespace TreasureGen.Tests.Integration.Stress.Items.Mundane
{
    [TestFixture]
    public abstract class MundaneItemGeneratorStressTests : StressTests
    {
        private IEnumerable<String> materials;

        [SetUp]
        public void MundaneItemGeneratorStressSetup()
        {
            materials = TraitConstants.GetSpecialMaterials();
        }

        protected abstract Item GenerateItem();

        public virtual void SpecialMaterialsHappen()
        {
            var item = new Item();

            do item = GenerateItem();
            while (TestShouldKeepRunning() && !item.Traits.Intersect(materials).Any());

            var itemMaterials = item.Traits.Intersect(materials);
            Assert.That(itemMaterials, Is.Not.Empty, type);
        }

        public abstract void NoDecorationsHappen();

        public void AssertNoDecorationsHappen()
        {
            var item = new Item();

            do item = GenerateItem();
            while (TestShouldKeepRunning() && item.Traits.Intersect(materials).Any());

            var itemMaterials = item.Traits.Intersect(materials);
            Assert.That(itemMaterials, Is.Empty, type);
        }
    }
}