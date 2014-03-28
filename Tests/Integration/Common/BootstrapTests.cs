using D20Dice;
using EquipmentGen.Bootstrap;
using EquipmentGen.Generators.Interfaces;
using EquipmentGen.Generators.Interfaces.Coins;
using EquipmentGen.Generators.Interfaces.Goods;
using EquipmentGen.Generators.Interfaces.Items;
using EquipmentGen.Generators.Interfaces.Items.Magical;
using EquipmentGen.Generators.Interfaces.Items.Mundane;
using EquipmentGen.Generators.RuntimeFactories.Interfaces;
using EquipmentGen.Mappers.Attributes;
using EquipmentGen.Mappers.Interfaces;
using EquipmentGen.Mappers.Percentile;
using EquipmentGen.Mappers.SpecialAbilityData;
using EquipmentGen.Selectors.Interfaces;
using EquipmentGen.Tables.Interfaces;
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
        public void TypeAndAmountPercentileSelectorNotConstructedAsSingleton()
        {
            AssertNotSingleton<ITypeAndAmountPercentileSelector>();
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
        public void PercentileSelectorNotConstructedAsSingleton()
        {
            AssertNotSingleton<IPercentileSelector>();
        }

        [Test]
        public void PercentileMapperConstructedAsSingleton()
        {
            AssertSingleton<IPercentileMapper>();
        }

        [Test]
        public void PercentileMapperHasCachingProxy()
        {
            var mapper = kernel.Get<IPercentileMapper>();
            Assert.That(mapper, Is.InstanceOf<PercentileMapperCachingProxy>());
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
        public void SpecialMaterialGeneratorNotConstructedAsSingleton()
        {
            AssertNotSingleton<ISpecialMaterialGenerator>();
        }

        [Test]
        public void AttributesSelectorNotConstructedAsSingleton()
        {
            AssertNotSingleton<IAttributesSelector>();
        }

        [Test]
        public void AttributesMapperConstructedAsSingleton()
        {
            AssertSingleton<IAttributesMapper>();
        }

        [Test]
        public void AttributesMapperHasCachingProxy()
        {
            var mapper = kernel.Get<IAttributesMapper>();
            Assert.That(mapper, Is.InstanceOf<AttributesMapperCachingProxy>());
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
        public void SpecialAbilityDataSelectorNotConstructedAsSingleton()
        {
            AssertNotSingleton<ISpecialAbilityDataSelector>();
        }

        [Test]
        public void SpellGeneratorNotConstructedAsSingleton()
        {
            AssertNotSingleton<ISpellGenerator>();
        }

        [Test]
        public void SpecialAbilityDataMapperConstructedAsSingleton()
        {
            AssertSingleton<ISpecialAbilityDataMapper>();
        }

        [Test]
        public void SpecialAbilityDataMapperHasCachingProxy()
        {
            var mapper = kernel.Get<ISpecialAbilityDataMapper>();
            Assert.That(mapper, Is.InstanceOf<SpecialAbilityDataMapperCachingProxy>());
        }

        [Test]
        public void IntelligenceGeneratorNotConstructedAsSingleton()
        {
            AssertNotSingleton<IIntelligenceGenerator>();
        }

        [Test]
        public void ChargesGeneratorNotConstructedAsSingleton()
        {
            AssertNotSingleton<IChargesGenerator>();
        }

        [Test]
        public void SpecificGearGeneratorNotConstructedAsSingleton()
        {
            AssertNotSingleton<ISpecificGearGenerator>();
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