using DnDGen.Infrastructure.IoC;
using NUnit.Framework;

namespace DnDGen.TreasureGen.Tests.Integration.Tables
{
    [TestFixture]
    public abstract class TableTests : IntegrationTests
    {
        protected abstract string tableName { get; }

        [OneTimeSetUp]
        public void TableOneTimeSetup()
        {
            var coreLoader = new InfrastructureModuleLoader();
            coreLoader.ReplaceAssemblyLoaderWith<TreasureGenAssemblyLoader>(kernel);
        }
    }
}