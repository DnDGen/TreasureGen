using DnDGen.TreasureGen.Items.Mundane;
using NUnit.Framework;
using System.Linq;

namespace DnDGen.TreasureGen.Tests.Unit.Generators.Items.Mundane
{
    [TestFixture]
    public class AlchemicalItemConstantsTests
    {
        [TestCase(AlchemicalItemConstants.AlchemistsFire, "Alchemist's Fire")]
        [TestCase(AlchemicalItemConstants.Acid, "Acid")]
        [TestCase(AlchemicalItemConstants.Smokestick, "Smokestick")]
        [TestCase(AlchemicalItemConstants.HolyWater, "Holy Water")]
        [TestCase(AlchemicalItemConstants.Antitoxin, "Antitoxin")]
        [TestCase(AlchemicalItemConstants.EverburningTorch, "Everburning Torch")]
        [TestCase(AlchemicalItemConstants.TanglefootBag, "Tanglefoot Bag")]
        [TestCase(AlchemicalItemConstants.Thunderstone, "Thunderstone")]
        public void Constant(string constant, string value)
        {
            Assert.That(constant, Is.EqualTo(value));
        }

        [Test]
        public void AllAlchemicalItems()
        {
            var alchemicalItems = AlchemicalItemConstants.GetAllAlchemicalItems();

            Assert.That(alchemicalItems, Contains.Item(AlchemicalItemConstants.AlchemistsFire));
            Assert.That(alchemicalItems, Contains.Item(AlchemicalItemConstants.Acid));
            Assert.That(alchemicalItems, Contains.Item(AlchemicalItemConstants.Smokestick));
            Assert.That(alchemicalItems, Contains.Item(AlchemicalItemConstants.HolyWater));
            Assert.That(alchemicalItems, Contains.Item(AlchemicalItemConstants.Antitoxin));
            Assert.That(alchemicalItems, Contains.Item(AlchemicalItemConstants.EverburningTorch));
            Assert.That(alchemicalItems, Contains.Item(AlchemicalItemConstants.TanglefootBag));
            Assert.That(alchemicalItems, Contains.Item(AlchemicalItemConstants.Thunderstone));
            Assert.That(alchemicalItems.Count(), Is.EqualTo(8));
        }
    }
}
