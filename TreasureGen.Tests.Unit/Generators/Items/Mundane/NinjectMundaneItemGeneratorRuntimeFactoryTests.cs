using Ninject.MockingKernel;
using Ninject.MockingKernel.Moq;
using NUnit.Framework;
using TreasureGen.Domain.Generators.Items.Mundane;
using TreasureGen.Items.Mundane;

namespace TreasureGen.Tests.Unit.Generators.Items.Mundane
{
    [TestFixture]
    public class NinjectMundaneItemGeneratorRuntimeFactoryTests
    {
        private IMundaneItemGeneratorRuntimeFactory factory;
        private MoqMockingKernel mockKernel;

        [SetUp]
        public void Setup()
        {
            mockKernel = new MoqMockingKernel();
            factory = new NinjectMundaneItemGeneratorRuntimeFactory(mockKernel);
        }

        [Test]
        public void FactoryMakesGeneratorOf()
        {
            mockKernel.Bind<MundaneItemGenerator>().ToMock().InSingletonScope().Named("name");
            var mockGenerator = mockKernel.GetMock<MundaneItemGenerator>();

            var generator = factory.CreateGeneratorOf("name");
            Assert.That(generator, Is.Not.Null);
            Assert.That(generator, Is.EqualTo(mockGenerator.Object));
        }
    }
}