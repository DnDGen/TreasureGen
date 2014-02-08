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
        public void CoinGeneratorNotConstructedAsSingleton()
        {
            AssertNotSingleton<ICoinGenerator>();
        }

        [Test]
        public void CoinPercentileResultProviderNotConstructedAsSingleton()
        {
            AssertNotSingleton<ITypeAndAmountPercentileResultProvider>();
        }

        [Test]
        public void DiceConstructedAsSingleton()
        {
            AssertSingleton<IDice>();
        }

        [Test]
        public void GoodsGeneratorNotConstructedAsSingleton()
        {
            AssertNotSingleton<IGoodsGenerator>();
        }

        [Test]
        public void PercentileResultProviderConstructedAsSingleton()
        {
            AssertSingleton<IPercentileResultProvider>();
        }

        [Test]
        public void PercentileXmlParserNotConstructedAsSingleton()
        {
            AssertNotSingleton<IPercentileXmlParser>();
        }

        [Test]
        public void EmbeddedResourceStreamLoaderNotConstructedAsSingleton()
        {
            AssertNotSingleton<IStreamLoader>();
        }

        [Test]
        public void TreasureGeneratorNotConstructedAsSingleton()
        {
            AssertNotSingleton<ITreasureGenerator>();
        }

        [Test]
        public void ItemsGeneratorNotConstructedAsSingleton()
        {
            AssertNotSingleton<IItemsGenerator>();
        }

        [Test]
        public void AlchemicalItemGeneratorNotConstructedAsSingleton()
        {
            AssertNotSingleton<IAlchemicalItemGenerator>();
        }

        [Test]
        public void MagicalGearGeneratorFactoryNotConstructedAsSingleton()
        {
            AssertNotSingleton<IMagicalGearGeneratorFactory>();
        }

        [Test]
        public void ToolGeneratorNotConstructedAsSingleton()
        {
            AssertNotSingleton<IToolGenerator>();
        }

        [Test]
        public void MundaneGearGeneratorFactoryNotConstructedAsSingleton()
        {
            AssertNotSingleton<IMundaneGearGeneratorFactory>();
        }

        [Test]
        public void MundaneItemGeneratorNotConstructedAssinglestons()
        {
            AssertNotSingleton<IMundaneItemGenerator>();
        }

        [Test]
        public void MagicalItemGeneratorFactoryNotConstructedAsSingleton()
        {
            AssertNotSingleton<IMagicalItemGeneratorFactory>();
        }

        [Test]
        public void AmmunitionGeneratorNotConstructedAsSingleton()
        {
            AssertNotSingleton<IAmmunitionGenerator>();
        }

        [Test]
        public void MaterialsProviderNotConstructedAsSingleton()
        {
            AssertNotSingleton<ISpecialMaterialGenerator>();
        }

        [Test]
        public void TypesProviderConstructedAsSingleton()
        {
            AssertSingleton<ITypesProvider>();
        }

        [Test]
        public void TypesXmlParserNotConstructedAsSingleton()
        {
            AssertNotSingleton<ITypesXmlParser>();
        }

        [Test]
        public void SpecialAbilitiesGeneratorNotConstructedAsSingleton()
        {
            AssertNotSingleton<ISpecialAbilitiesGenerator>();
        }

        [Test]
        public void CurseGeneratorNotConstructedAsSingleton()
        {
            AssertNotSingleton<ICurseGenerator>();
        }

        [Test]
        public void MagicalItemTraitsGeneratorNotConstructedAsSingleton()
        {
            AssertNotSingleton<IMagicalItemTraitsGenerator>();
        }

        [Test]
        public void SpecialAbilityDataProviderConstructedAsSingleton()
        {
            AssertSingleton<ISpecialAbilityDataProvider>();
        }

        [Test]
        public void SpellGeneratorNotConstructedAsSingleton()
        {
            AssertNotSingleton<ISpellGenerator>();
        }

        [Test]
        public void SpecialAbilityDataXmlParserNotConstructedAsSingleton()
        {
            AssertNotSingleton<ISpecialAbilityDataXmlParser>();
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