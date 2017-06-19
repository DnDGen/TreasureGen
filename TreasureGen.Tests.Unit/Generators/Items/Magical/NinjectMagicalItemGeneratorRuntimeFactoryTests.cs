using Ninject.MockingKernel;
using Ninject.MockingKernel.Moq;
using NUnit.Framework;
using TreasureGen.Domain.Generators.Items.Magical;
using TreasureGen.Items.Magical;

namespace TreasureGen.Tests.Unit.Generators.Items.Magical
{
    [TestFixture]
    public class NinjectMagicalItemGeneratorRuntimeFactoryTests
    {
        private IMagicalItemGeneratorRuntimeFactory factory;
        private MoqMockingKernel mockKernel;

        [SetUp]
        public void Setup()
        {
            mockKernel = new MoqMockingKernel();
            factory = new NinjectMagicalItemGeneratorRuntimeFactory(mockKernel);
        }

        [Test]
        public void FactoryMakesGenerator()
        {
            mockKernel.Bind<MagicalItemGenerator>().ToMock().InSingletonScope().Named("name");
            var mockGenerator = mockKernel.GetMock<MagicalItemGenerator>();

            var generator = factory.CreateGeneratorOf("name");
            Assert.That(generator, Is.Not.Null);
            Assert.That(generator, Is.EqualTo(mockGenerator.Object));
        }
    }
}