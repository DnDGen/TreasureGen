using DnDGen.EventGen;
using DnDGen.TreasureGen.Items;
using DnDGen.TreasureGen.Items.Mundane;
using DnDGen.TreasureGen.Tests.Unit.Generators.Items;
using Ninject;
using NUnit.Framework;
using System;
using System.Linq;

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

        [TestCase(ArmorConstants.FullPlate, TraitConstants.Sizes.Colossal)]
        [TestCase(ArmorConstants.FullPlate, TraitConstants.Sizes.Gargantuan)]
        [TestCase(ArmorConstants.FullPlate, TraitConstants.Sizes.Huge)]
        [TestCase(ArmorConstants.FullPlate, TraitConstants.Sizes.Large)]
        [TestCase(ArmorConstants.FullPlate, TraitConstants.Sizes.Medium)]
        [TestCase(ArmorConstants.FullPlate, TraitConstants.Sizes.Small)]
        [TestCase(ArmorConstants.FullPlate, TraitConstants.Sizes.Tiny)]
        public void GenerateArmorOfSize(string itemName, string size)
        {
            var item = ArmorGenerator.Generate(itemName, "my trait", size);
            itemVerifier.AssertItem(item);
            Assert.That(item, Is.InstanceOf<Armor>());

            var armor = item as Armor;
            Assert.That(armor.Size, Is.EqualTo(size));
            Assert.That(armor.Traits, Contains.Item("my trait")
                .And.Not.Contains(size));
        }

        [TestCase(ArmorConstants.FullPlate, TraitConstants.Sizes.Colossal)]
        [TestCase(ArmorConstants.FullPlate, TraitConstants.Sizes.Gargantuan)]
        [TestCase(ArmorConstants.FullPlate, TraitConstants.Sizes.Huge)]
        [TestCase(ArmorConstants.FullPlate, TraitConstants.Sizes.Large)]
        [TestCase(ArmorConstants.FullPlate, TraitConstants.Sizes.Medium)]
        [TestCase(ArmorConstants.FullPlate, TraitConstants.Sizes.Small)]
        [TestCase(ArmorConstants.FullPlate, TraitConstants.Sizes.Tiny)]
        public void GenerateArmorOfSize_FromTemplate(string itemName, string size)
        {
            var template = itemVerifier.CreateRandomArmorTemplate(itemName);
            template.Traits.Add(size);

            var item = ArmorGenerator.Generate(template);
            itemVerifier.AssertItem(item);
            Assert.That(item, Is.InstanceOf<Armor>());

            var armor = item as Armor;
            Assert.That(armor.Size, Is.EqualTo(size), armor.Name);
            Assert.That(armor.Traits, Does.Not.Contain(size)
                .And.SupersetOf(template.Traits.Take(2)), armor.Name);
        }
    }
}
