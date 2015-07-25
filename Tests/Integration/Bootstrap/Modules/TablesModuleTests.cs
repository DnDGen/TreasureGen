using TreasureGen.Tables.Interfaces;
using NUnit.Framework;

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