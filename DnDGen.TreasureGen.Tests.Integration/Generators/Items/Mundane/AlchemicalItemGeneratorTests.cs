using DnDGen.EventGen;
using DnDGen.TreasureGen.Items;
using DnDGen.TreasureGen.Items.Mundane;
using DnDGen.TreasureGen.Tests.Unit.Generators.Items;
using Ninject;
using NUnit.Framework;
using System;

namespace DnDGen.TreasureGen.Tests.Integration.Generators.Items.Mundane
{
    [TestFixture]
    public class AlchemicalItemGeneratorTests : IntegrationTests
    {
        [Inject, Named(ItemTypeConstants.AlchemicalItem)]
        public MundaneItemGenerator AlchemicalItemGenerator { get; set; }
        [Inject]
        public ClientIDManager ClientIDManager { get; set; }

        private ItemVerifier itemVerifier;

        [SetUp]
        public void Setup()
        {
            itemVerifier = new ItemVerifier();
            ClientIDManager.SetClientID(Guid.NewGuid());
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
            var item = AlchemicalItemGenerator.Generate(itemName);
            itemVerifier.AssertItem(item);
        }
    }
}
