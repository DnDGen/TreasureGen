using DnDGen.TreasureGen.Items;
using DnDGen.TreasureGen.Items.Mundane;
using DnDGen.TreasureGen.Tests.Unit.Generators.Items;
using NUnit.Framework;

namespace DnDGen.TreasureGen.Tests.Integration.Generators.Items.Mundane
{
    [TestFixture]
    public class AlchemicalItemGeneratorTests : IntegrationTests
    {
        private ItemVerifier itemVerifier;
        private MundaneItemGenerator alchemicalItemGenerator;

        [SetUp]
        public void Setup()
        {
            itemVerifier = new ItemVerifier();
            alchemicalItemGenerator = GetNewInstanceOf<MundaneItemGenerator>(ItemTypeConstants.AlchemicalItem);
        }

        [TestCaseSource(typeof(ItemTestData), nameof(ItemTestData.AlchemicalItems))]
        public void GenerateAlchemicalItem(string itemName)
        {
            var item = alchemicalItemGenerator.Generate(itemName);
            itemVerifier.AssertItem(item);
        }
    }
}
