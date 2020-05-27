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

        [TestCase(ToolConstants.ArtisansTools_Masterwork)]
        [TestCase(ToolConstants.Backpack_Empty)]
        [TestCase(ToolConstants.ClimbersKit)]
        [TestCase(ToolConstants.Crowbar)]
        [TestCase(ToolConstants.DisguiseKit)]
        [TestCase(ToolConstants.HealersKit)]
        [TestCase(ToolConstants.HolySymbol_Silver)]
        [TestCase(ToolConstants.Hourglass)]
        [TestCase(ToolConstants.Lantern_Bullseye)]
        [TestCase(ToolConstants.Lock_Average)]
        [TestCase(ToolConstants.Lock_Good)]
        [TestCase(ToolConstants.Lock_Simple)]
        [TestCase(ToolConstants.Lock_Superior)]
        [TestCase(ToolConstants.MagnifyingGlass)]
        [TestCase(ToolConstants.Manacles_Masterwork)]
        [TestCase(ToolConstants.Mirror_SmallSteel)]
        [TestCase(ToolConstants.MusicalInstrument_Masterwork)]
        [TestCase(ToolConstants.Rope_Silk)]
        [TestCase(ToolConstants.Spyglass)]
        [TestCase(ToolConstants.ThievesTools_Masterwork)]
        public void GenerateTool(string itemName)
        {
            var item = toolGenerator.Generate(itemName);
            itemVerifier.AssertItem(item);
        }
    }
}
