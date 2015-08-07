using NUnit.Framework;
using System;
using TreasureGen.Common.Goods;
using TreasureGen.Tables;

namespace TreasureGen.Tests.Integration.Tables.Goods.Art
{
    [TestFixture]
    public class ArtDescriptionsTests : AttributesTests
    {
        protected override String tableName
        {
            get { return String.Format(TableNameConstants.Attributes.Formattable.GOODTYPEDescriptions, GoodsConstants.Art); }
        }

        [TestCase("10d10", "silver ewer",
                             "carved bone statuette",
                             "carved ivory statuette",
                             "finely wrought small gold bracelet")]
        [TestCase("30d6", "cloth of gold vestments",
                            "black velvet mask with numerous citrines",
                            "silver chalice with lapis lazuli gems")]
        [TestCase("100d6", "large well-done wool tapestry",
                             "brass mug with jade inlays")]
        [TestCase("100d10", "silver comb with moonstones",
                              "silver-plated steel longsword with jet jewel in hilt")]
        [TestCase("200d6", "carved harp of exotic wood with ivory inlay and zircon gems",
                             "10 lb. solid gold idol")]
        [TestCase("300d6", "gold dragon comb with red garnet eye",
                             "gold and topaz bottle stopper cork",
                             "ceremonial electrum dagger with a star ruby in the pommel")]
        [TestCase("400d6", "eyepatch with mock eye of sapphire and moonstone",
                             "fire opal pendant on a fine gold chain",
                             "old masterpiece painting")]
        [TestCase("500d6", "embroidered silk and velvet mantle with numerous moonstones",
                             "sapphire pendant on gold chain")]
        [TestCase("1000d4", "embroidered and bejeweled glove",
                              "jeweled anklet",
                              "gold music box")]
        [TestCase("1000d6", "golden circlet with four aquamarines",
                              "a necklace of small pink pearls")]
        [TestCase("2000d4", "jeweled gold crown",
                              "jeweled electrum ring")]
        [TestCase("2000d6", "gold and ruby ring",
                              "gold cup set with emeralds")]
        public override void Attributes(String name, params String[] attributes)
        {
            base.Attributes(name, attributes);
        }
    }
}