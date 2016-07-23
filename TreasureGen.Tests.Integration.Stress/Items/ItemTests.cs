using NUnit.Framework;
using TreasureGen.Items;

namespace TreasureGen.Tests.Integration.Stress.Items
{
    [TestFixture]
    public abstract class ItemTests : StressTests
    {
        protected abstract Item GenerateItem();
    }
}
