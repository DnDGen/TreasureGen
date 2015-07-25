using NUnit.Framework;
using TreasureGen.Tables;

namespace TreasureGen.Tests.Integration.Bootstrap.Modules
{
    [TestFixture]
    public class TablesModuleTests : BootstrapTests
    {
        [Test]
        public void EmbeddedResourceStreamLoaderNotConstructedAsSingleton()
        {
            AssertNotSingleton<IStreamLoader>();
        }
    }
}