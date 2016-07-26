using NUnit.Framework;
using System.Linq;
using TreasureGen.Items.Mundane;

namespace TreasureGen.Tests.Unit.Generators.Items.Mundane
{
    [TestFixture]
    public class ToolConstantsTests
    {
        [TestCase(ToolConstants.Backpack_Empty, "Empty backpack")]
        [TestCase(ToolConstants.Crowbar, "Crowbar")]
        [TestCase(ToolConstants.Lantern_Bullseye, "Bullseye lantern")]
        [TestCase(ToolConstants.Lock_Simple, "Simple lock")]
        [TestCase(ToolConstants.Lock_Average, "Average lock")]
        [TestCase(ToolConstants.Lock_Good, "Good lock")]
        [TestCase(ToolConstants.Lock_Superior, "Superior lock")]
        [TestCase(ToolConstants.Manacles_Masterwork, "Masterwork manacles")]
        [TestCase(ToolConstants.Mirror_SmallSteel, "Small steel mirror")]
        [TestCase(ToolConstants.Rope_Silk, "Silk rope (50')")]
        [TestCase(ToolConstants.Spyglass, "Spyglass")]
        [TestCase(ToolConstants.ArtisansTools_Masterwork, "Masterwork artisan's tools")]
        [TestCase(ToolConstants.ClimbersKit, "Climber's kit")]
        [TestCase(ToolConstants.DisguiseKit, "Disguise kit")]
        [TestCase(ToolConstants.HealersKit, "Healer's kit")]
        [TestCase(ToolConstants.HolySymbol_Silver, "Silver holy symbol")]
        [TestCase(ToolConstants.Hourglass, "Hourglass")]
        [TestCase(ToolConstants.MagnifyingGlass, "Magnifying glass")]
        [TestCase(ToolConstants.MusicalInstrument_Masterwork, "Masterwork musical instrument")]
        [TestCase(ToolConstants.ThievesTools_Masterwork, "Masterwork thieves' tools")]
        public void Constant(string constant, string value)
        {
            Assert.That(constant, Is.EqualTo(value));
        }

        [Test]
        public void AllTools()
        {
            var tools = ToolConstants.GetAllTools();

            Assert.That(tools, Contains.Item(ToolConstants.Backpack_Empty));
            Assert.That(tools, Contains.Item(ToolConstants.ArtisansTools_Masterwork));
            Assert.That(tools, Contains.Item(ToolConstants.ClimbersKit));
            Assert.That(tools, Contains.Item(ToolConstants.Crowbar));
            Assert.That(tools, Contains.Item(ToolConstants.DisguiseKit));
            Assert.That(tools, Contains.Item(ToolConstants.HealersKit));
            Assert.That(tools, Contains.Item(ToolConstants.HolySymbol_Silver));
            Assert.That(tools, Contains.Item(ToolConstants.Hourglass));
            Assert.That(tools, Contains.Item(ToolConstants.Lantern_Bullseye));
            Assert.That(tools, Contains.Item(ToolConstants.Lock_Average));
            Assert.That(tools, Contains.Item(ToolConstants.Lock_Good));
            Assert.That(tools, Contains.Item(ToolConstants.Lock_Simple));
            Assert.That(tools, Contains.Item(ToolConstants.Lock_Superior));
            Assert.That(tools, Contains.Item(ToolConstants.MagnifyingGlass));
            Assert.That(tools, Contains.Item(ToolConstants.Manacles_Masterwork));
            Assert.That(tools, Contains.Item(ToolConstants.Mirror_SmallSteel));
            Assert.That(tools, Contains.Item(ToolConstants.MusicalInstrument_Masterwork));
            Assert.That(tools, Contains.Item(ToolConstants.Rope_Silk));
            Assert.That(tools, Contains.Item(ToolConstants.Spyglass));
            Assert.That(tools, Contains.Item(ToolConstants.ThievesTools_Masterwork));
            Assert.That(tools.Count(), Is.EqualTo(20));
        }
    }
}
