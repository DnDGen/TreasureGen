using EquipmentGen.Tests.Unit.Generation.Xml.Data.Attributes;
using NUnit.Framework;

namespace EquipmentGen.Tests.Unit.Generation.Xml.Data.Goods.Gems
{
    [TestFixture, TypesTable("GemDescriptions")]
    public class GemDescriptionsTests : TypesTest
    {
        [Test]
        public void GemValue4d4Descriptions()
        {
            var descriptions = new[]
                {
                    "eye agate",
                    "moss agate",
                    "banded agate",
                    "azurite",
                    "blue quartz",
                    "hematite",
                    "lapis lazuli",
                    "malachite",
                    "obsidian",
                    "rhodochrosite",
                    "tiger eye turquoise",
                    "irregular freshwater pearl",
                };

            AssertContent("4d4", descriptions);
        }

        [Test]
        public void GemValue2d4x10Descriptions()
        {
            var descriptions = new[]
                {
                    "bloodstone",
                    "carnelian",
                    "chalcedony",
                    "chrysoprase",
                    "citrine",
                    "iolite",
                    "jasper",
                    "moonstone",
                    "onyx",
                    "peridot",
                    "clear quartz rock crystal",
                    "sard",
                    "sardonyx",
                    "rose quartz",
                    "smoky rose quartz",
                    "star rose quartz",
                    "zircon"
                };

            AssertContent("2d4*10", descriptions);
        }

        [Test]
        public void GemValue4d4x10Descriptions()
        {
            var descriptions = new[]
                {
                    "amber",
                    "amethyst",
                    "chrysoberyl",
                    "coral",
                    "red garnet",
                    "brown-green garnet",
                    "jade",
                    "jet",
                    "white pearl",
                    "golden pearl",
                    "pink pearl",
                    "silver pearl",
                    "red spinel",
                    "red-brown spinel",
                    "deep green spinel",
                    "tourmaline",
                };

            AssertContent("4d4*10", descriptions);
        }

        [Test]
        public void GemValue2d4x100Descriptions()
        {
            var descriptions = new[]
                {
                    "alexandrite",
                    "aquamarine",
                    "violet garnet",
                    "black pearl",
                    "deep blue spinel",
                    "golden yellow topaz"
                };

            AssertContent("2d4*100", descriptions);
        }

        [Test]
        public void GemValue4d4x100Descriptions()
        {
            var descriptions = new[]
                {
                    "emerald",
                    "white opal",
                    "black opal",
                    "fire opal",
                    "blue sapphire",
                    "fiery yellow corundum",
                    "rich purple corundum",
                    "blue star sapphire",
                    "black star sapphire",
                    "star ruby"
                };

            AssertContent("4d4*100", descriptions);
        }

        [Test]
        public void GemValue2d4x1000Descriptions()
        {
            var descriptions = new[]
                {
                    "clearest bright green emerald",
                    "blue-white diamond",
                    "canary diamond",
                    "pink diamond",
                    "brown diamond",
                    "blue diamond",
                    "jacinth"
                };

            AssertContent("2d4*1000", descriptions);
        }
    }
}