using EquipmentGen.Core.Generation.Generators;
using EquipmentGen.Core.Generation.Generators.Interfaces;
using NUnit.Framework;

namespace EquipmentGen.Tests.Unit.Generation.Generators
{
    [TestFixture]
    public class ToolGeneratorTests
    {
        private IToolGenerator generator;

        [SetUp]
        public void Setup()
        {
            generator = new ToolGenerator();
        }

        [Test]
        public void ToolGeneratorReturnsTool()
        {
            var tool = generator.Generate();
            Assert.That(tool, Is.Not.Null);
            Assert.That(tool.Name, Is.Not.Empty);
        }
    }
}