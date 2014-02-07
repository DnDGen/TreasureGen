using EquipmentGen.Core.Data.Items;
using EquipmentGen.Core.Generation.Factories.Interfaces;
using EquipmentGen.Core.Generation.Generators.Interfaces;
using Ninject;
using NUnit.Framework;

namespace EquipmentGen.Tests.Integration.Duration.Generation.Generators
{
    [TestFixture]
    public class MundaneWeaponGeneratorTests : DurationTest
    {
        [Inject]
        public IMundaneGearGeneratorFactory MundaneGearGeneratorFactory { get; set; }

        private IMundaneGearGenerator mundaneWeaponGenerator;

        [SetUp]
        public void Setup()
        {
            mundaneWeaponGenerator = MundaneGearGeneratorFactory.CreateWith(ItemTypeConstants.Weapon);
            StartTest();
        }

        [TearDown]
        public void TearDown()
        {
            StopTest();
        }

        [Test]
        public void MundaneWeaponGeneratorDuration()
        {
            mundaneWeaponGenerator.Generate();
            AssertDuration();
        }
    }
}