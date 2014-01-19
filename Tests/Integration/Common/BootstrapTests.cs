using D20Dice;
using EquipmentGen.Bootstrap;
using EquipmentGen.Core.Generation.Factories;
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

        [Test]
        public void ItemsFactoryNotGeneratedAsSingletons()
        {
            var first = kernel.Get<IItemsFactory>();
            var second = kernel.Get<IItemsFactory>();
            Assert.That(first, Is.Not.EqualTo(second));
        }

        [Test]
        public void PowerFactoryFactoryNotGenerateAsSingletons()
        {
            var first = kernel.Get<IPowerFactoryFactory>();
            var second = kernel.Get<IPowerFactoryFactory>();
            Assert.That(first, Is.Not.EqualTo(second));
        }

        [Test]
        public void AlchemicalFactoryNotGeneratedAsSingletons()
        {
            var first = kernel.Get<IAlchemicalItemFactory>();
            var second = kernel.Get<IAlchemicalItemFactory>();
            Assert.That(first, Is.Not.EqualTo(second));
        }

        [Test]
        public void ArmorFactoryNotGeneratedAsSingletons()
        {
            var first = kernel.Get<IGearFactory>("ArmorFactory");
            var second = kernel.Get<IGearFactory>("ArmorFactory");
            Assert.That(first, Is.Not.EqualTo(second));
        }

        [Test]
        public void ArmorFactoryIsGeneratedUppercase()
        {
            var factory = kernel.Get<IGearFactory>("ArmorFactory");
            Assert.That(factory, Is.TypeOf<ArmorFactory>());
        }

        [Test]
        public void ArmorFactoryIsGeneratedLowercase()
        {
            var factory = kernel.Get<IGearFactory>("armorFactory");
            Assert.That(factory, Is.TypeOf<ArmorFactory>());
        }

        [Test]
        public void WeaponFactoryNotGeneratedAsSingletons()
        {
            var first = kernel.Get<IGearFactory>("WeaponFactory");
            var second = kernel.Get<IGearFactory>("WeaponFactory");
            Assert.That(first, Is.Not.EqualTo(second));
        }

        [Test]
        public void WeaponFactoryIsGeneratedUppercase()
        {
            var factory = kernel.Get<IGearFactory>("WeaponFactory");
            Assert.That(factory, Is.TypeOf<WeaponFactory>());
        }

        [Test]
        public void WeaponFactoryIsGeneratedLowercase()
        {
            var factory = kernel.Get<IGearFactory>("weaponFactory");
            Assert.That(factory, Is.TypeOf<WeaponFactory>());
        }

        [Test]
        public void ToolFactoryNotGeneratedAsSingletons()
        {
            var first = kernel.Get<IToolFactory>();
            var second = kernel.Get<IToolFactory>();
            Assert.That(first, Is.Not.EqualTo(second));
        }
    }
}