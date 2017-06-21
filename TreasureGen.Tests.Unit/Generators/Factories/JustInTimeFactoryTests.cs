using Ninject.MockingKernel;
using Ninject.MockingKernel.Moq;
using NUnit.Framework;
using TreasureGen.Domain.Generators.Factories;
using TreasureGen.Items.Magical;

namespace TreasureGen.Tests.Unit.Generators.Factories
{
    [TestFixture]
    public class JustInTimeFactoryTests
    {
        private JustInTimeFactory justInTimeFactory;
        private MoqMockingKernel mockKernel;

        [SetUp]
        public void Setup()
        {
            mockKernel = new MoqMockingKernel();
            justInTimeFactory = new NinjectJustInTimeFactory(mockKernel);
        }

        [Test]
        public void FactoryBuilds()
        {
            mockKernel.Bind<MagicalItemGenerator>().ToMock().InSingletonScope();
            var mockGenerator = mockKernel.GetMock<MagicalItemGenerator>();

            var generator = justInTimeFactory.Build<MagicalItemGenerator>();
            Assert.That(generator, Is.Not.Null);
            Assert.That(generator, Is.EqualTo(mockGenerator.Object));
        }

        [Test]
        public void FactoryBuildsWithName()
        {
            mockKernel.Bind<MagicalItemGenerator>().ToMock().InSingletonScope().Named("name");
            var mockGenerator = mockKernel.GetMock<MagicalItemGenerator>();

            var generator = justInTimeFactory.Build<MagicalItemGenerator>("name");
            Assert.That(generator, Is.Not.Null);
            Assert.That(generator, Is.EqualTo(mockGenerator.Object));
        }
    }
}
