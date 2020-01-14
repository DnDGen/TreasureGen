using DnDGen.Infrastructure.IoC;
using DnDGen.EventGen.IoC;
using Ninject;
using NUnit.Framework;
using DnDGen.RollGen.IoC;
using DnDGen.TreasureGen.IoC;

namespace DnDGen.TreasureGen.Tests.Integration
{
    [TestFixture]
    public abstract class IntegrationTests
    {
        protected IKernel kernel;

        public IntegrationTests()
        {
            kernel = new StandardKernel(new NinjectSettings() { InjectNonPublic = true });

            var rollGenModuleLoader = new RollGenModuleLoader();
            rollGenModuleLoader.LoadModules(kernel);

            var infrastructureModuleLoader = new InfrastructureModuleLoader();
            infrastructureModuleLoader.LoadModules(kernel);

            var eventGenModuleLoader = new EventGenModuleLoader();
            eventGenModuleLoader.LoadModules(kernel);

            var treasureGenModuleLoader = new TreasureGenModuleLoader();
            treasureGenModuleLoader.LoadModules(kernel);
        }

        [SetUp]
        public void IntegrationTestsSetup()
        {
            kernel.Inject(this);
        }

        protected T GetNewInstanceOf<T>()
        {
            return kernel.Get<T>();
        }

        protected T GetNewInstanceOf<T>(string name)
        {
            return kernel.Get<T>(name);
        }
    }
}