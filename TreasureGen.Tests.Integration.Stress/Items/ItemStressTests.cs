using Ninject;
using NUnit.Framework;
using System.Collections.Generic;
using TreasureGen.Items;
using TreasureGen.Tests.Unit.Generators.Items;

namespace TreasureGen.Tests.Integration.Stress.Items
{
    [TestFixture]
    public abstract class ItemStressTests : StressTests
    {
        [Inject]
        public ItemVerifier ItemVerifier { get; set; }

        protected abstract Item GenerateItem();
        protected abstract Item GenerateRandomCustomItem(string name);
        protected abstract Item GenerateItemFromSubset(IEnumerable<string> subset);
    }
}
