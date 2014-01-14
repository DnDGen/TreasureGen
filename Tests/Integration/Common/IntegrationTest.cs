using EquipmentGen.Bootstrap;
using Ninject;
using NUnit.Framework;

namespace EquipmentGen.Tests.Integration.Common
{
    [TestFixture]
    public abstract class IntegrationTest
    {
        private IKernel kernel;

        public IntegrationTest()
        {
            kernel = new StandardKernel();

            var equipmentGenModuleLoader = new EquipmentGenModuleLoader();
            equipmentGenModuleLoader.LoadModules(kernel);

            kernel.Inject(this);
        }
    }
}