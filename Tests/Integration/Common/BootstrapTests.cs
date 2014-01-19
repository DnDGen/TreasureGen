using D20Dice;
using EquipmentGen.Bootstrap;
using EquipmentGen.Core.Generation.Factories.Interfaces;
using EquipmentGen.Core.Generation.Generators.Interfaces;
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
            var first = kernel.Get<ICoinGenerator>();
            var second = kernel.Get<ICoinGenerator>();
            Assert.That(first, Is.Not.EqualTo(second));
        }

        [Test]
        public void CoinPercentileResultProviderNotGeneratedAsSingletons()
        {
            var first = kernel.Get<ITypeAndAmountPercentileResultProvider>();
            var second = kernel.Get<ITypeAndAmountPercentileResultProvider>();
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
            var first = kernel.Get<IGoodsGenerator>();
            var second = kernel.Get<IGoodsGenerator>();
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
            var first = kernel.Get<ITreasureGenerator>();
            var second = kernel.Get<ITreasureGenerator>();
            Assert.That(first, Is.Not.EqualTo(second));
        }

        [Test]
        public void ItemsFactoryNotGeneratedAsSingletons()
        {
            var first = kernel.Get<IItemsGenerator>();
            var second = kernel.Get<IItemsGenerator>();
            Assert.That(first, Is.Not.EqualTo(second));
        }

        [Test]
        public void PowerFactoryFactoryNotGenerateAsSingletons()
        {
            var first = kernel.Get<IPowerItemGeneratorFactory>();
            var second = kernel.Get<IPowerItemGeneratorFactory>();
            Assert.That(first, Is.Not.EqualTo(second));
        }

        [Test]
        public void AlchemicalFactoryNotGeneratedAsSingletons()
        {
            var first = kernel.Get<IAlchemicalItemGenerator>();
            var second = kernel.Get<IAlchemicalItemGenerator>();
            Assert.That(first, Is.Not.EqualTo(second));
        }

        [Test]
        public void GearFactoryFactoryNotGeneratedAsSingletons()
        {
            var first = kernel.Get<IGearGeneratorFactory>();
            var second = kernel.Get<IGearGeneratorFactory>();
            Assert.That(first, Is.Not.EqualTo(second));
        }

        [Test]
        public void ToolFactoryNotGeneratedAsSingletons()
        {
            var first = kernel.Get<IToolGenerator>();
            var second = kernel.Get<IToolGenerator>();
            Assert.That(first, Is.Not.EqualTo(second));
        }
    }
}