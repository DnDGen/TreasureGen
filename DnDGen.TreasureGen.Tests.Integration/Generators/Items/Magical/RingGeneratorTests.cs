using DnDGen.TreasureGen.Items;
using DnDGen.TreasureGen.Items.Magical;
using DnDGen.TreasureGen.Tests.Unit.Generators.Items;
using Ninject;
using NUnit.Framework;

namespace DnDGen.TreasureGen.Tests.Integration.Generators.Items.Magical
{
    [TestFixture]
    public class RingGeneratorTests : IntegrationTests
    {
        [Inject, Named(ItemTypeConstants.Ring)]
        public MagicalItemGenerator RingGenerator { get; set; }

        private ItemVerifier itemVerifier;

        [SetUp]
        public void Setup()
        {
            itemVerifier = new ItemVerifier();
        }

        [TestCaseSource(typeof(ItemPowerTestData), nameof(ItemPowerTestData.Rings))]
        public void GenerateRing(string itemName, string power)
        {
            var item = RingGenerator.Generate(power, itemName);
            itemVerifier.AssertItem(item);
        }
    }
}
