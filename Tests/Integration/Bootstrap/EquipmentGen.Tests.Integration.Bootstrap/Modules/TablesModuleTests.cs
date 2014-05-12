using EquipmentGen.Tables.Interfaces;
using NUnit.Framework;

namespace EquipmentGen.Tests.Integration.Bootstrap.Modules
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