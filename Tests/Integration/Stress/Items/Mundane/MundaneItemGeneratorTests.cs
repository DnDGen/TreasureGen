using EquipmentGen.Generators.Interfaces.Items.Mundane;
using Ninject;
using NUnit.Framework;

namespace EquipmentGen.Tests.Integration.Stress.Items.Mundane
{
    [TestFixture]
    public class MundaneItemGeneratorTests : StressTests
    {
        [Inject]
        public IMundaneItemGenerator MundaneItemGenerator { get; set; }

        [Test]
        public void StressedMundaneItemGenerator()
        {
            StressGenerator();
        }

        protected override void MakeAssertions()
        {
            var item = MundaneItemGenerator.Generate();
            Assert.That(item.Name, Is.Not.Empty);
            Assert.That(item.Traits, Is.Not.Null);
            Assert.That(item.Attributes, Is.Not.Null);
            Assert.That(item.Quantity, Is.GreaterThan(0));
            Assert.That(item.Magic, Is.Empty);
        }
    }
}