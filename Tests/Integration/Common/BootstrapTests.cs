using D20Dice;
using EquipmentGen.Bootstrap;
using EquipmentGen.Core.Generation.Factories.Interfaces;
using EquipmentGen.Core.Generation.Providers.Interfaces;
using EquipmentGen.Core.Generation.Xml.Parsers.Interfaces;
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

        [Test]
        public void CoinPercentileResultProviderNotGeneratedAsSingletons()
        {
            var first = kernel.Get<ICoinPercentileResultProvider>();
            var second = kernel.Get<ICoinPercentileResultProvider>();
            Assert.That(first, Is.Not.EqualTo(second));
        }

        [Test]
        public void DiceGeneratedAsSingletons()
        {
            var first = kernel.Get<IDice>();
            var second = kernel.Get<IDice>();
            Assert.That(first, Is.EqualTo(second));
        }

        [Test]
        public void GoodPercentileResultProviderNotGeneratedAsSingletons()
        {
            var first = kernel.Get<IGoodPercentileResultProvider>();
            var second = kernel.Get<IGoodPercentileResultProvider>();
            Assert.That(first, Is.Not.EqualTo(second));
        }

        [Test]
        public void GoodsFactoryNotGeneratedAsSingletons()
        {
            var first = kernel.Get<IGoodsFactory>();
            var second = kernel.Get<IGoodsFactory>();
            Assert.That(first, Is.Not.EqualTo(second));
        }

        [Test]
        public void PercentileResultProviderGeneratedAsSingletons()
        {
            var first = kernel.Get<IPercentileResultProvider>();
            var second = kernel.Get<IPercentileResultProvider>();
            Assert.That(first, Is.EqualTo(second));
        }

        [Test]
        public void PercentileXmlParserNotGeneratedAsSingletons()
        {
            var first = kernel.Get<IPercentileXmlParser>();
            var second = kernel.Get<IPercentileXmlParser>();
            Assert.That(first, Is.Not.EqualTo(second));
        }

        [Test]
        public void EmbeddedResourceStreamLoaderNotGeneratedAsSingletons()
        {
            var first = kernel.Get<IStreamLoader>();
            var second = kernel.Get<IStreamLoader>();
            Assert.That(first, Is.Not.EqualTo(second));
        }

        [Test]
        public void TreasureFactoryNotGeneratedAsSingletons()
        {
            var first = kernel.Get<ITreasureFactory>();
            var second = kernel.Get<ITreasureFactory>();
            Assert.That(first, Is.Not.EqualTo(second));
        }
    }
}