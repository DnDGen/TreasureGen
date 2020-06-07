using DnDGen.TreasureGen.Items;
using DnDGen.TreasureGen.Items.Magical;
using DnDGen.TreasureGen.Tests.Unit.Generators.Items;
using Ninject;
using NUnit.Framework;

namespace DnDGen.TreasureGen.Tests.Integration.Generators.Items.Magical
{
    [TestFixture]
    public class WondrousItemGeneratorTests : IntegrationTests
    {
        [Inject, Named(ItemTypeConstants.WondrousItem)]
        public MagicalItemGenerator WondrousItemGenerator { get; set; }

        private ItemVerifier itemVerifier;

        [SetUp]
        public void Setup()
        {
            itemVerifier = new ItemVerifier();
        }

        [TestCaseSource(typeof(ItemPowerTestData), "WondrousItems")]
        public void GenerateWondrousItem(string itemName, string power)
        {
            var item = WondrousItemGenerator.Generate(power, itemName);
            itemVerifier.AssertItem(item);
        }
    }
}
