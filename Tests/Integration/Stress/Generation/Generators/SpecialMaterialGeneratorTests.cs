using EquipmentGen.Core.Generation.Generators.Interfaces;
using Ninject;
using NUnit.Framework;

namespace EquipmentGen.Tests.Integration.Stress.Generation.Generators
{
    [TestFixture]
    public class SpecialMaterialGeneratorTests : StressTest
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
                var types = GetNewTypes();
                var material = SpecialMaterialGenerator.GenerateFor(types);

                Assert.That(material, Is.Not.Null);
            }

            AssertIterations();
        }
    }
}