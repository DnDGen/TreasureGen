using NUnit.Framework;

namespace EquipmentGen.Tests.Unit.Generation.Xml.Data.Goods.Gems
{
    [TestFixture]
    public class GemValueTests : PercentileTests
    {
        [SetUp]
        public void Setup()
        {
            tableName = "GemValue";
        }

        [Test]
        public void GemValue4d4Percentile()
        {
            AssertContent("4d4,banded agate,eye agate,moss agate,azurite,blue quartz,hematite,lapis lazuli,malachite,obsidian,rhodochrosite,tiger eye turquoise,irregular freshwater pearl", 1, 25);
        }

        [Test]
        public void GemValue2d4x10Percentile()
        {
            AssertContent("2d4*10,bloodstone,carnelian,chalcedony,chrysoprase,citrine,iolite,jasper,moonstone,onyx,peridot,clear quartz rock crystal,sard,sardonyx,rose quartz,smoky rose quartz,star rose quartz,zircon", 26, 50);
        }

        [Test]
        public void GemValue4d4x10Percentile()
        {
            AssertContent("4d4*10,amber,amethyst,chrysoberyl,coral,red garnet,brown-green garnet,jade,jet,white pearl,golden pearl,pink pearl,silver pearl,red spinel,red-brown spinel,deep green spinel,tourmaline", 51, 70);
        }

        [Test]
        public void GemValue2d4x100Percentile()
        {
            AssertContent("2d4*100,alexandrite,aquamarine,violet garnet,black pearl,deep blue spinel,golden yellow topaz", 71, 90);
        }

        [Test]
        public void GemValue4d4x100Percentile()
        {
            AssertContent("4d4*100,emerald,white opal,black opal,fire opal,blue sapphire,fiery yellow corundum,rich purple corundum,blue star sapphire,black star sapphire,star ruby", 91, 99);
        }

        [Test]
        public void GemValue2d4x1000Percentile()
        {
            AssertContent("2d4*1000,clearest bright green emerald,blue-white diamond,canary diamond,pink diamond,brown diamond,blue diamond,jacinth", 100);
        }
    }
}