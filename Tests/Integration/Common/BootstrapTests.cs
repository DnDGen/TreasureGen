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
        public void CoinGeneratorNotGeneratedAsSingletons()
        {
            AssertNotSingleton<ICoinGenerator>();
        }

        [Test]
        public void CoinPercentileResultProviderNotGeneratedAsSingletons()
        {
            AssertNotSingleton<ITypeAndAmountPercentileResultProvider>();
        }

        [Test]
        public void DiceGeneratedAsSingletons()
        {
            AssertSingleton<IDice>();
        }

        [Test]
        public void GoodPercentileResultProviderNotGeneratedAsSingletons()
        {
            AssertNotSingleton<IGoodPercentileResultProvider>();
        }

        [Test]
        public void GoodsGeneratorNotGeneratedAsSingletons()
        {
            AssertNotSingleton<IGoodsGenerator>();
        }

        [Test]
        public void PercentileResultProviderGeneratedAsSingletons()
        {
            AssertSingleton<IPercentileResultProvider>();
        }

        [Test]
        public void PercentileXmlParserNotGeneratedAsSingletons()
        {
            AssertNotSingleton<IPercentileXmlParser>();
        }

        [Test]
        public void EmbeddedResourceStreamLoaderNotGeneratedAsSingletons()
        {
            AssertNotSingleton<IStreamLoader>();
        }

        [Test]
        public void TreasureGeneratorNotGeneratedAsSingletons()
        {
            AssertNotSingleton<ITreasureGenerator>();
        }

        [Test]
        public void ItemsGeneratorNotGeneratedAsSingletons()
        {
            AssertNotSingleton<IItemsGenerator>();
        }

        [Test]
        public void AlchemicalItemGeneratorNotGeneratedAsSingletons()
        {
            AssertNotSingleton<IAlchemicalItemGenerator>();
        }

        [Test]
        public void PowerGearGeneratorFactoryNotGeneratedAsSingletons()
        {
            AssertNotSingleton<IPowerGearGeneratorFactory>();
        }

        [Test]
        public void ToolGeneratorNotGeneratedAsSingletons()
        {
            AssertNotSingleton<IToolGenerator>();
        }

        [Test]
        public void PowerItemGeneratorNotGeneratedAsSingletons()
        {
            AssertNotSingleton<IPowerItemGenerator>();
        }

        [Test]
        public void MundaneGearGeneratorFactoryNotGeneratedAsSingletons()
        {
            AssertNotSingleton<IMundaneGearGeneratorFactory>();
        }

        [Test]
        public void MundaneItemGeneratorNotGeneratedAssinglestons()
        {
            AssertNotSingleton<IMundaneItemGenerator>();
        }

        [Test]
        public void MagicalItemGeneratorFactoryNotGeneratedAsSingletons()
        {
            AssertNotSingleton<IMagicalItemGeneratorFactory>();
        }

        [Test]
        public void AmmunitionGeneratorNotGeneratedAsSingletons()
        {
            AssertNotSingleton<IAmmunitionGenerator>();
        }

        [Test]
        public void MaterialsProviderNotGeneratedAsSingletons()
        {
            AssertNotSingleton<ISpecialMaterialGenerator>();
        }

        [Test]
        public void GearTypesProviderGeneratedAsSingletons()
        {
            AssertSingleton<IGearTypesProvider>();
        }

        [Test]
        public void TypesXmlParserNotGeneratedAsSingletons()
        {
            AssertNotSingleton<ITypesXmlParser>();
        }

        [Test]
        public void GearSpecialAbilitiesGeneratorNotGeneratedAsSingletons()
        {
            AssertNotSingleton<IGearSpecialAbilitiesGenerator>();
        }

        [Test]
        public void CurseGeneratorNotGeneratedAsSingletons()
        {
            AssertNotSingleton<ICurseGenerator>();
        }

        private void AssertSingleton<T>()
        {
            var first = kernel.Get<T>();
            var second = kernel.Get<T>();
            Assert.That(first, Is.EqualTo(second));
        }

        private void AssertNotSingleton<T>()
        {
            var first = kernel.Get<T>();
            var second = kernel.Get<T>();
            Assert.That(first, Is.Not.EqualTo(second));
        }
    }
}