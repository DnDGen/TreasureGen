using EquipmentGen.Bootstrap;
using EquipmentGen.Core.Generation.Factories.Interfaces;
using Ninject;
using NUnit.Framework;

namespace EquipmentGen.Tests.Integration.Common
{
    [TestFixture]
    public class BootstrapTests
    {
        private IKernel kernel;

        [SetUp]
        public void Setup()
        {
            kernel = new StandardKernel();

            var equipmentGenModuleLoader = new EquipmentGenModuleLoader();
            equipmentGenModuleLoader.LoadModules(kernel);
        }

        [Test]
        public void CoinFactoriesNotGeneratedAsSingletons()
        {
            var first = kernel.Get<ICoinFactory>();
            var second = kernel.Get<ICoinFactory>();
            Assert.That(first, Is.Not.EqualTo(second));
        }
    }
}