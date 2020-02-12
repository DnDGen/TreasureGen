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
    public class MundaneArmorGeneratorTests : IntegrationTests
    {
        [Inject, Named(ItemTypeConstants.Armor)]
        public MundaneItemGenerator ArmorGenerator { get; set; }
        [Inject]
        public ClientIDManager ClientIDManager { get; set; }

        private ItemVerifier itemVerifier;

        [SetUp]
        public void Setup()
        {
            itemVerifier = new ItemVerifier();
            ClientIDManager.SetClientID(Guid.NewGuid());
        }

        [TestCase(ArmorConstants.BandedMail)]
        [TestCase(ArmorConstants.Breastplate)]
        [TestCase(ArmorConstants.Buckler)]
        [TestCase(ArmorConstants.Chainmail)]
        [TestCase(ArmorConstants.ChainShirt)]
        [TestCase(ArmorConstants.FullPlate)]
        [TestCase(ArmorConstants.HalfPlate)]
        [TestCase(ArmorConstants.HeavySteelShield)]
        [TestCase(ArmorConstants.HeavyWoodenShield)]
        [TestCase(ArmorConstants.HideArmor)]
        [TestCase(ArmorConstants.LeatherArmor)]
        [TestCase(ArmorConstants.LightSteelShield)]
        [TestCase(ArmorConstants.LightWoodenShield)]
        [TestCase(ArmorConstants.PaddedArmor)]
        [TestCase(ArmorConstants.ScaleMail)]
        [TestCase(ArmorConstants.SplintMail)]
        [TestCase(ArmorConstants.StuddedLeatherArmor)]
        [TestCase(ArmorConstants.TowerShield)]
        public void GenerateArmor(string itemName)
        {
            var item = ArmorGenerator.Generate(itemName);
            itemVerifier.AssertItem(item);
        }
    }
}
