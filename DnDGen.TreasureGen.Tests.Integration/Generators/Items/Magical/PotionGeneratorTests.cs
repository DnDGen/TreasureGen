using DnDGen.TreasureGen.Items;
using DnDGen.TreasureGen.Items.Magical;
using DnDGen.TreasureGen.Tests.Unit.Generators.Items;
using Ninject;
using NUnit.Framework;

namespace DnDGen.TreasureGen.Tests.Integration.Generators.Items.Magical
{
    [TestFixture]
    public class PotionGeneratorTests : IntegrationTests
    {
        [Inject, Named(ItemTypeConstants.Potion)]
        public MagicalItemGenerator PotionGenerator { get; set; }

        private ItemVerifier itemVerifier;

        [SetUp]
        public void Setup()
        {
            itemVerifier = new ItemVerifier();
        }

        [TestCaseSource(typeof(ItemPowerTestData), "Potions")]
        public void GeneratePotion(string itemName, string power)
        {
            var item = PotionGenerator.Generate(power, itemName);
            itemVerifier.AssertItem(item);
        }
    }
}
