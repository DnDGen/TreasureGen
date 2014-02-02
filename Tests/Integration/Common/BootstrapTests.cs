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
        public void CoinGeneratorNotGeneratedAsSingleton()
        {
            AssertNotSingleton<ICoinGenerator>();
        }

        [Test]
        public void CoinPercentileResultProviderNotGeneratedAsSingleton()
        {
            AssertNotSingleton<ITypeAndAmountPercentileResultProvider>();
        }

        [Test]
        public void DiceGeneratedAsSingleton()
        {
            AssertSingleton<IDice>();
        }

        [Test]
        public void GoodPercentileResultProviderNotGeneratedAsSingleton()
        {
            AssertNotSingleton<IGoodPercentileResultProvider>();
        }

        [Test]
        public void GoodsGeneratorNotGeneratedAsSingleton()
        {
            AssertNotSingleton<IGoodsGenerator>();
        }

        [Test]
        public void PercentileResultProviderGeneratedAsSingleton()
        {
            AssertSingleton<IPercentileResultProvider>();
        }

        [Test]
        public void PercentileXmlParserNotGeneratedAsSingleton()
        {
            AssertNotSingleton<IPercentileXmlParser>();
        }

        [Test]
        public void EmbeddedResourceStreamLoaderNotGeneratedAsSingleton()
        {
            AssertNotSingleton<IStreamLoader>();
        }

        [Test]
        public void TreasureGeneratorNotGeneratedAsSingleton()
        {
            AssertNotSingleton<ITreasureGenerator>();
        }

        [Test]
        public void ItemsGeneratorNotGeneratedAsSingleton()
        {
            AssertNotSingleton<IItemsGenerator>();
        }

        [Test]
        public void AlchemicalItemGeneratorNotGeneratedAsSingleton()
        {
            AssertNotSingleton<IAlchemicalItemGenerator>();
        }

        [Test]
        public void MagicalGearGeneratorFactoryNotGeneratedAsSingleton()
        {
            AssertNotSingleton<IMagicalGearGeneratorFactory>();
        }

        [Test]
        public void ToolGeneratorNotGeneratedAsSingleton()
        {
            AssertNotSingleton<IToolGenerator>();
        }

        [Test]
        public void MundaneGearGeneratorFactoryNotGeneratedAsSingleton()
        {
            AssertNotSingleton<IMundaneGearGeneratorFactory>();
        }

        [Test]
        public void MundaneItemGeneratorNotGeneratedAssinglestons()
        {
            AssertNotSingleton<IMundaneItemGenerator>();
        }

        [Test]
        public void MagicalItemGeneratorFactoryNotGeneratedAsSingleton()
        {
            AssertNotSingleton<IMagicalItemGeneratorFactory>();
        }

        [Test]
        public void AmmunitionGeneratorNotGeneratedAsSingleton()
        {
            AssertNotSingleton<IAmmunitionGenerator>();
        }

        [Test]
        public void MaterialsProviderNotGeneratedAsSingleton()
        {
            AssertNotSingleton<ISpecialMaterialGenerator>();
        }

        [Test]
        public void TypesProviderGeneratedAsSingleton()
        {
            AssertSingleton<ITypesProvider>();
        }

        [Test]
        public void TypesXmlParserNotGeneratedAsSingleton()
        {
            AssertNotSingleton<ITypesXmlParser>();
        }

        [Test]
        public void SpecialAbilitiesGeneratorNotGeneratedAsSingleton()
        {
            AssertNotSingleton<ISpecialAbilitiesGenerator>();
        }

        [Test]
        public void CurseGeneratorNotGeneratedAsSingleton()
        {
            AssertNotSingleton<ICurseGenerator>();
        }

        [Test]
        public void MagicalItemTraitsGeneratorNotGeneratedAsSingleton()
        {
            AssertNotSingleton<IMagicalItemTraitsGenerator>();
        }

        [Test]
        public void SpecialAbilityPercentileResultProviderNotGeneratedAsSingleton()
        {
            AssertNotSingleton<ISpecialAbilityPercentileResultProvider>();
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