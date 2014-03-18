using EquipmentGen.Tests.Integration.Tables.Attributes;
using NUnit.Framework;

namespace EquipmentGen.Tests.Integration.Tables.Goods.Art
{
    [TestFixture, AttributesTable("ArtDescriptions")]
    public class ArtDescriptionsTests : AttributesTests
    {
        [Test]
        public void ArtValue1d10x10Descriptions()
        {
            var descriptions = new[]
                {
                    "silver ewer",
                    "carved bone statuette",
                    "carved ivory statuette",
                    "finely wrought small gold bracelet"
                };

            AssertContent("1d10*10", descriptions);
        }

        [Test]
        public void ArtValue3d6x10Descriptions()
        {
            var descriptions = new[]
                {
                    "cloth of gold vestments",
                    "black velvet mask with numerous citrines",
                    "silver chalice with lapis lazuli gems"
                };

            AssertContent("3d6*10", descriptions);
        }

        [Test]
        public void ArtValue1d6x100Descriptions()
        {
            var descriptions = new[]
                {
                    "large well-done wool tapestry",
                    "brass mug with jade inlays"
                };

            AssertContent("1d6*100", descriptions);
        }

        [Test]
        public void ArtValue1d10x100Descriptions()
        {
            var descriptions = new[]
                {
                    "silver comb with moonstones",
                    "silver-plated steel longsword with jet jewel in hilt"
                };

            AssertContent("1d10*100", descriptions);
        }

        [Test]
        public void ArtValue2d6x100Descriptions()
        {
            var descriptions = new[]
                {
                    "carved harp of exotic wood with ivory inlay and zircon gems",
                    "10 lb. solid gold idol"
                };

            AssertContent("2d6*100", descriptions);
        }

        [Test]
        public void ArtValue3d6x100Descriptions()
        {
            var descriptions = new[]
                {
                    "gold dragon comb with red garnet eye",
                    "gold and topaz bottle stopper cork",
                    "ceremonial electrum dagger with a star ruby in the pommel"
                };

            AssertContent("3d6*100", descriptions);
        }

        [Test]
        public void ArtValue4d6x100Descriptions()
        {
            var descriptions = new[]
                {
                    "eyepatch with mock eye of sapphire and moonstone",
                    "fire opal pendant on a fine gold chain",
                    "old masterpiece painting"
                };

            AssertContent("4d6*100", descriptions);
        }

        [Test]
        public void ArtValue5d6x100Descriptions()
        {
            var descriptions = new[]
                {
                    "embroidered silk and velvet mantle with numerous moonstones",
                    "sapphire pendant on gold chain"
                };

            AssertContent("5d6*100", descriptions);
        }

        [Test]
        public void ArtValue1d4x1000Descriptions()
        {
            var descriptions = new[]
                {
                    "embroidered and bejeweled glove",
                    "jeweled anklet",
                    "gold music box"
                };

            AssertContent("1d4*1000", descriptions);
        }

        [Test]
        public void ArtValue1d6x1000Descriptions()
        {
            var descriptions = new[]
                {
                    "golden circlet with four aquamarines",
                    "a necklace of small pink pearls"
                };

            AssertContent("1d6*1000", descriptions);
        }

        [Test]
        public void ArtValue2d4x1000Descriptions()
        {
            var descriptions = new[]
                {
                    "jeweled gold crown",
                    "jeweled electrum ring"
                };

            AssertContent("2d4*1000", descriptions);
        }

        [Test]
        public void ArtValue2d6x1000Descriptions()
        {
            var descriptions = new[]
                {
                    "gold and ruby ring",
                    "gold cup set with emeralds"
                };

            AssertContent("2d6*1000", descriptions);
        }
    }
}