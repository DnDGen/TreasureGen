using EquipmentGen.Core.Generation.Generators.Interfaces;
using Ninject;
using NUnit.Framework;

namespace EquipmentGen.Tests.Integration.Stress.Generation.Generators
{
    [TestFixture]
    public class MagicalItemTraitsGeneratorTests : StressTests
    {
        [Inject]
        public IMagicalItemTraitsGenerator TraitsGenerator { get; set; }

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
        public void StressedMagicalItemTraitsGeenrator()
        {
            while (TestShouldKeepRunning())
            {
                var itemType = GetNewMagicalItemType();
                var traits = TraitsGenerator.GenerateFor(itemType);

                Assert.That(traits, Is.Not.Null);
            }

            AssertIterations();
        }
    }
}