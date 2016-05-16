using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using TreasureGen.Items;

namespace TreasureGen.Tests.Integration.Stress.Items.Mundane
{
    [TestFixture]
    public abstract class MundaneItemGeneratorStressTests : ItemTests
    {
        private IEnumerable<String> materials;

        [SetUp]
        public void MundaneItemGeneratorStressSetup()
        {
            materials = TraitConstants.GetSpecialMaterials();
        }

        public virtual void SpecialMaterialsHappen()
        {
            GenerateOrFail(i => i.Traits.Intersect(materials).Any());
        }

        public abstract void NoDecorationsHappen();

        public void AssertNoDecorationsHappen()
        {
            GenerateOrFail(i => i.Traits.Intersect(materials).Any() == false);
        }
    }
}