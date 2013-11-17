using EquipmentGen.Core.Data.Goods;
using NUnit.Framework;

namespace EquipmentGen.Tests.Data.Goods
{
    [TestFixture]
    public class GoodsConstantsTests
    {
        [Test]
        public void GemConstant()
        {
            Assert.That(GoodsConstants.Gem, Is.EqualTo("Gem"));
        }

        [Test]
        public void ArtConstant()
        {
            Assert.That(GoodsConstants.Art, Is.EqualTo("Art"));
        }
    }
}