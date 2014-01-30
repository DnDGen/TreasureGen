using EquipmentGen.Tests.Unit.Generation.Xml.Data.Attributes;
using NUnit.Framework;

namespace EquipmentGen.Tests.Unit.Generation.Xml.Data.Goods.Art
{
    [TestFixture, PercentileTable("ArtValue")]
    public class ArtValueTests : PercentileTests
    {
        [Test]
        public void ArtValue1d10x10Percentile()
        {
            AssertContent("1d10*10,silver ewer,carved bone statuette,carved ivory statuette,finely wrought small gold bracelet", 1, 10);
        }

        [Test]
        public void ArtValue3d6x10Percentile()
        {
            AssertContent("3d6*10,cloth of gold vestments,black velvet mask with numerous citrines,silver chalice with lapis lazuli gems", 11, 25);
        }

        [Test]
        public void ArtValue1d6x100Percentile()
        {
            AssertContent("1d6*100,large well-done wool tapestry,brass mug with jade inlays", 26, 40);
        }

        [Test]
        public void ArtValue1d10x100Percentile()
        {
            AssertContent("1d10*100,silver comb with moonstones,silver-plated steel longsword with jet jewel in hilt", 41, 50);
        }

        [Test]
        public void ArtValue2d6x100Percentile()
        {
            AssertContent("2d6*100,carved harp of exotic wood with ivory inlay and zircon gems,10 lb. solid gold idol", 51, 60);
        }

        [Test]
        public void ArtValue3d6x100Percentile()
        {
            AssertContent("3d6*100,gold dragon comb with red garnet eye,gold and topaz bottle stopper cork,ceremonial electrum dagger with a star ruby in the pommel", 61, 70);
        }

        [Test]
        public void ArtValue4d6x100Percentile()
        {
            AssertContent("4d6*100,eyepatch with mock eye of sapphire and moonstone,fire opal pendant on a fine gold chain,old masterpiece painting", 71, 80);
        }

        [Test]
        public void ArtValue5d6x100Percentile()
        {
            AssertContent("5d6*100,embroidered silk and velvet mantle with numerous moonstones,sapphire pendant on gold chain", 81, 85);
        }

        [Test]
        public void ArtValue1d4x1000Percentile()
        {
            AssertContent("1d4*1000,embroidered and bejeweled glove,jeweled anklet,gold music box", 86, 90);
        }

        [Test]
        public void ArtValue1d6x1000Percentile()
        {
            AssertContent("1d6*1000,golden circlet with four aquamarines,a necklace of small pink pearls", 91, 95);
        }

        [Test]
        public void ArtValue2d4x1000Percentile()
        {
            AssertContent("2d4*1000,jeweled gold crown,jeweled electrum ring", 96, 99);
        }

        [Test]
        public void ArtValue2d6x1000Percentile()
        {
            AssertContent("2d6*1000,gold and ruby ring,gold cup set with emeralds", 100);
        }
    }
}