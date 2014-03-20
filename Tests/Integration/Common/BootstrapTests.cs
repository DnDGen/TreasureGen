using D20Dice;
using EquipmentGen.Bootstrap;
using EquipmentGen.Generators.Interfaces;
using EquipmentGen.Generators.Interfaces.Coins;
using EquipmentGen.Generators.Interfaces.Goods;
using EquipmentGen.Generators.Interfaces.Items;
using EquipmentGen.Generators.Interfaces.Items.Magical;
using EquipmentGen.Generators.Interfaces.Items.Mundane;
using EquipmentGen.Generators.RuntimeFactories.Interfaces;
using EquipmentGen.Mappers.Interfaces;
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
        public void PercentileSelectorConstructedAsSingleton()
        {
            AssertSingleton<IPercentileSelector>();
        }

        [Test]
        public void PercentileMapperNotConstructedAsSingleton()
        {
            AssertNotSingleton<IPercentileMapper>();
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
        public void SpecialAmterialsGeneratorNotConstructedAsSingleton()
        {
            AssertNotSingleton<ISpecialMaterialGenerator>();
        }

        [Test]
        public void AttributesSelectorConstructedAsSingleton()
        {
            AssertSingleton<IAttributesSelector>();
        }

        [Test]
        public void AttributesMapperNotConstructedAsSingleton()
        {
            AssertNotSingleton<IAttributesMapper>();
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
        public void SpecialAbilityDataSelectorConstructedAsSingleton()
        {
            AssertSingleton<ISpecialAbilityDataSelector>();
        }

        [Test]
        public void SpellGeneratorNotConstructedAsSingleton()
        {
            AssertNotSingleton<ISpellGenerator>();
        }

        [Test]
        public void SpecialAbilityDataMapperNotConstructedAsSingleton()
        {
            AssertNotSingleton<ISpecialAbilityDataMapper>();
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