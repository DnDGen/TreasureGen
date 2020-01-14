using NUnit.Framework;
using DnDGen.TreasureGen.Tables;
using DnDGen.TreasureGen.Goods;

namespace DnDGen.TreasureGen.Tests.Integration.Tables.Goods.Gems
{
    [TestFixture]
    public class GemDescriptionsTests : CollectionsTests
    {
        protected override string tableName
        {
            get { return string.Format(TableNameConstants.Collections.Formattable.GOODTYPEDescriptions, GoodsConstants.Gem); }
        }

        [TestCase(AmountConstants.Range4d4, "eye agate",
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
                         "irregular freshwater pearl")]
        [TestCase(AmountConstants.Range2d4x10, "bloodstone",
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
                            "zircon")]
        [TestCase(AmountConstants.Range4d4x10, "amber",
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
                            "tourmaline")]
        [TestCase(AmountConstants.Range2d4x100, "alexandrite",
                             "aquamarine",
                             "violet garnet",
                             "black pearl",
                             "deep blue spinel",
                             "golden yellow topaz")]
        [TestCase(AmountConstants.Range4d4x100, "emerald",
                             "white opal",
                             "black opal",
                             "fire opal",
                             "blue sapphire",
                             "fiery yellow corundum",
                             "rich purple corundum",
                             "blue star sapphire",
                             "black star sapphire",
                             "star ruby")]
        [TestCase(AmountConstants.Range2d4x1000, "clearest bright green emerald",
                              "blue-white diamond",
                              "canary diamond",
                              "pink diamond",
                              "brown diamond",
                              "blue diamond",
                              "jacinth")]
        public override void Collections(string name, params string[] attributes)
        {
            base.Collections(name, attributes);
        }
    }
}