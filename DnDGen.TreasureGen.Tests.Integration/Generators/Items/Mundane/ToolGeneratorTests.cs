using DnDGen.TreasureGen.Items;
using DnDGen.TreasureGen.Items.Mundane;
using DnDGen.TreasureGen.Tests.Unit.Generators.Items;
using NUnit.Framework;

namespace DnDGen.TreasureGen.Tests.Integration.Generators.Items.Mundane
{
    [TestFixture]
    public class ToolGeneratorTests : IntegrationTests
    {
        private ItemVerifier itemVerifier;
        private MundaneItemGenerator toolGenerator;

        [SetUp]
        public void Setup()
        {
            itemVerifier = new ItemVerifier();
            toolGenerator = GetNewInstanceOf<MundaneItemGenerator>(ItemTypeConstants.Tool);
        }

        [TestCaseSource(typeof(ItemTestData), nameof(ItemTestData.Tools))]
        public void GenerateTool(string itemName)
        {
            var item = toolGenerator.Generate(itemName);
            itemVerifier.AssertItem(item);
        }
    }
}
