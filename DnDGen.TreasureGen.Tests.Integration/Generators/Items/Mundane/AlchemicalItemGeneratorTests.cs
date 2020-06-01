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

        [TestCase(AlchemicalItemConstants.Acid)]
        [TestCase(AlchemicalItemConstants.AlchemistsFire)]
        [TestCase(AlchemicalItemConstants.Antitoxin)]
        [TestCase(AlchemicalItemConstants.EverburningTorch)]
        [TestCase(AlchemicalItemConstants.HolyWater)]
        [TestCase(AlchemicalItemConstants.Smokestick)]
        [TestCase(AlchemicalItemConstants.TanglefootBag)]
        [TestCase(AlchemicalItemConstants.Thunderstone)]
        public void GenerateAlchemicalItem(string itemName)
        {
            var item = alchemicalItemGenerator.Generate(itemName);
            itemVerifier.AssertItem(item);
        }
    }
}
