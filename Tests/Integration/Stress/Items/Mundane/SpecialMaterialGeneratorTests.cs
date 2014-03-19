using EquipmentGen.Common.Items;
using EquipmentGen.Generators.Interfaces;
using EquipmentGen.Generators.Interfaces.Items.Mundane;
using Ninject;
using NUnit.Framework;

namespace EquipmentGen.Tests.Integration.Stress.Items.Mundane
{
    [TestFixture]
    public class SpecialMaterialGeneratorTests : StressTests
    {
        [Inject]
        public ISpecialMaterialGenerator SpecialMaterialGenerator { get; set; }

        [SetUp]
        public void Setup()
        {
            StartTest();
        }

        [TearDown]
        public void TearDown()
        {
            StopTest();
        }

        [Test]
        public void StressedSpecialMaterialGenerator()
        {
            while (TestShouldKeepRunning())
            {
                var types = GetNewAttributes(false);
                var material = SpecialMaterialGenerator.GenerateFor(types);

                Assert.That(material, Is.Not.Null);
            }

            AssertIterations();
        }
    }
}