using NUnit.Framework;
using TreasureGen.Tables;
using TreasureGen.Goods;

namespace TreasureGen.Tests.Integration.Tables.Goods.Art
{
    [TestFixture]
    public class ArtDescriptionsTests : CollectionsTests
    {
        protected override string tableName
        {
            get { return string.Format(TableNameConstants.Collections.Formattable.GOODTYPEDescriptions, GoodsConstants.Art); }
        }

        [TestCase(AmountConstants.Range1d10x10, "silver ewer",
                             "carved bone statuette",
                             "carved ivory statuette",
                             "finely wrought small gold bracelet")]
        [TestCase(AmountConstants.Range3d6x10, "cloth of gold vestments",
                            "black velvet mask with numerous citrines",
                            "silver chalice with lapis lazuli gems")]
        [TestCase(AmountConstants.Range1d6x100, "large well-done wool tapestry",
                             "brass mug with jade inlays")]
        [TestCase(AmountConstants.Range1d10x100, "silver comb with moonstones",
                              "silver-plated steel longsword with jet jewel in hilt")]
        [TestCase(AmountConstants.Range2d6x100, "carved harp of exotic wood with ivory inlay and zircon gems",
                             "10 lb. solid gold idol")]
        [TestCase(AmountConstants.Range3d6x100, "gold dragon comb with red garnet eye",
                             "gold and topaz bottle stopper cork",
                             "ceremonial electrum dagger with a star ruby in the pommel")]
        [TestCase(AmountConstants.Range4d6x100, "eyepatch with mock eye of sapphire and moonstone",
                             "fire opal pendant on a fine gold chain",
                             "old masterpiece painting")]
        [TestCase(AmountConstants.Range5d6x100, "embroidered silk and velvet mantle with numerous moonstones",
                             "sapphire pendant on gold chain")]
        [TestCase(AmountConstants.Range1d4x1000, "embroidered and bejeweled glove",
                              "jeweled anklet",
                              "gold music box")]
        [TestCase(AmountConstants.Range1d6x1000, "golden circlet with four aquamarines",
                              "a necklace of small pink pearls")]
        [TestCase(AmountConstants.Range2d4x1000, "jeweled gold crown",
                              "jeweled electrum ring")]
        [TestCase(AmountConstants.Range2d6x1000, "gold and ruby ring",
                              "gold cup set with emeralds")]
        public override void Collections(string name, params string[] attributes)
        {
            base.Collections(name, attributes);
        }
    }
}