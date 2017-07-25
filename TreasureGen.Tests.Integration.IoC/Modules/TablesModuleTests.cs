using DnDGen.Core.Tables;
using NUnit.Framework;
using TreasureGen.Domain.Tables;

namespace TreasureGen.Tests.Integration.IoC.Modules
{
    [TestFixture]
    public class TablesModuleTests : IoCTests
    {
        [Test]
        public void AssemblyLoaderNotConstructedAsSingleton()
        {
            AssertNotSingleton<AssemblyLoader>();
        }

        [Test]
        public void AssemblyLoaderIsForTreasure()
        {
            var selector = InjectAndAssertDuration<AssemblyLoader>();
            Assert.That(selector, Is.InstanceOf<TreasureGenAssemblyLoader>());
        }
    }
}