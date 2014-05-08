using EquipmentGen.Common.Items;
using EquipmentGen.Generators.Interfaces.Items.Mundane;
using Ninject;
using NUnit.Framework;

namespace EquipmentGen.Tests.Integration.Stress.Items.Mundane
{
    [TestFixture]
    public class AlchemicalItemGeneratorTests : StressTests
    {
        [Inject]
        public IAlchemicalItemGenerator AlchemicalItemGenerator { get; set; }

        [Test]
        public void StressedAlchemicalItemGenerator()
        {
            StressGenerator();
        }

        protected override void MakeAssertions()
        {
            var item = AlchemicalItemGenerator.Generate();

            Assert.That(item.Name, Is.Not.Empty);
            Assert.That(item.Quantity, Is.GreaterThan(0));
            Assert.That(item.IsMagical, Is.False);
            Assert.That(item.Attributes, Is.Empty);
            Assert.That(item.Traits, Is.Empty);
            Assert.That(item.Contents, Is.Empty);
            Assert.That(item.ItemType, Is.EqualTo(ItemTypeConstants.AlchemicalItem));
        }
    }
}