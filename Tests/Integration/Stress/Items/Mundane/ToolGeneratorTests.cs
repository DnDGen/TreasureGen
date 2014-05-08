using EquipmentGen.Common.Items;
using EquipmentGen.Generators.Interfaces.Items.Mundane;
using Ninject;
using NUnit.Framework;

namespace EquipmentGen.Tests.Integration.Stress.Items.Mundane
{
    [TestFixture]
    public class ToolGeneratorTests : StressTests
    {
        [Inject]
        public IToolGenerator ToolGenerator { get; set; }

        [Test]
        public void StressedToolGenerator()
        {
            StressGenerator();
        }

        protected override void MakeAssertions()
        {
            var tool = ToolGenerator.Generate();

            Assert.That(tool.Name, Is.Not.Empty);
            Assert.That(tool.Attributes, Is.Empty);
            Assert.That(tool.IsMagical, Is.False);
            Assert.That(tool.Quantity, Is.EqualTo(1));
            Assert.That(tool.Traits, Is.Empty);
            Assert.That(tool.Contents, Is.Empty);
            Assert.That(tool.ItemType, Is.EqualTo(ItemTypeConstants.Tool));
        }
    }
}