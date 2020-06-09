using DnDGen.TreasureGen.Items;
using DnDGen.TreasureGen.Items.Magical;
using DnDGen.TreasureGen.Tests.Unit.Generators.Items;
using Ninject;
using NUnit.Framework;

namespace DnDGen.TreasureGen.Tests.Integration.Generators.Items.Magical
{
    [TestFixture]
    public class MagicalArmorGeneratorTests : IntegrationTests
    {
        [Inject, Named(ItemTypeConstants.Armor)]
        public MagicalItemGenerator ArmorGenerator { get; set; }

        private ItemVerifier itemVerifier;

        [SetUp]
        public void Setup()
        {
            itemVerifier = new ItemVerifier();
        }

        [TestCaseSource(typeof(ItemPowerTestData), "Armors")]
        public void GenerateArmor(string itemName, string power)
        {
            var item = ArmorGenerator.Generate(power, itemName);
            itemVerifier.AssertItem(item);
        }

        [TestCase(ArmorConstants.FullPlate, PowerConstants.Minor, TraitConstants.Sizes.Colossal)]
        [TestCase(ArmorConstants.FullPlate, PowerConstants.Minor, TraitConstants.Sizes.Gargantuan)]
        [TestCase(ArmorConstants.FullPlate, PowerConstants.Minor, TraitConstants.Sizes.Huge)]
        [TestCase(ArmorConstants.FullPlate, PowerConstants.Minor, TraitConstants.Sizes.Large)]
        [TestCase(ArmorConstants.FullPlate, PowerConstants.Minor, TraitConstants.Sizes.Medium)]
        [TestCase(ArmorConstants.FullPlate, PowerConstants.Minor, TraitConstants.Sizes.Small)]
        [TestCase(ArmorConstants.FullPlate, PowerConstants.Minor, TraitConstants.Sizes.Tiny)]
        [TestCase(ArmorConstants.FullPlate, PowerConstants.Medium, TraitConstants.Sizes.Colossal)]
        [TestCase(ArmorConstants.FullPlate, PowerConstants.Medium, TraitConstants.Sizes.Gargantuan)]
        [TestCase(ArmorConstants.FullPlate, PowerConstants.Medium, TraitConstants.Sizes.Huge)]
        [TestCase(ArmorConstants.FullPlate, PowerConstants.Medium, TraitConstants.Sizes.Large)]
        [TestCase(ArmorConstants.FullPlate, PowerConstants.Medium, TraitConstants.Sizes.Medium)]
        [TestCase(ArmorConstants.FullPlate, PowerConstants.Medium, TraitConstants.Sizes.Small)]
        [TestCase(ArmorConstants.FullPlate, PowerConstants.Medium, TraitConstants.Sizes.Tiny)]
        [TestCase(ArmorConstants.FullPlate, PowerConstants.Major, TraitConstants.Sizes.Colossal)]
        [TestCase(ArmorConstants.FullPlate, PowerConstants.Major, TraitConstants.Sizes.Gargantuan)]
        [TestCase(ArmorConstants.FullPlate, PowerConstants.Major, TraitConstants.Sizes.Huge)]
        [TestCase(ArmorConstants.FullPlate, PowerConstants.Major, TraitConstants.Sizes.Large)]
        [TestCase(ArmorConstants.FullPlate, PowerConstants.Major, TraitConstants.Sizes.Medium)]
        [TestCase(ArmorConstants.FullPlate, PowerConstants.Major, TraitConstants.Sizes.Small)]
        [TestCase(ArmorConstants.FullPlate, PowerConstants.Major, TraitConstants.Sizes.Tiny)]
        public void GenerateArmorOfSize(string itemName, string power, string size)
        {
            var item = ArmorGenerator.Generate(power, itemName, "my trait", size);
            itemVerifier.AssertItem(item);
            Assert.That(item, Is.InstanceOf<Armor>());

            var armor = item as Armor;
            Assert.That(armor.ItemType, Is.EqualTo(ItemTypeConstants.Armor), $"{armor.Name} {armor.Magic.Curse}");
            Assert.That(armor.NameMatches(itemName), Is.True, $"{armor.Name} {armor.Magic.Curse}");
            Assert.That(armor.Size, Is.EqualTo(size), $"{armor.Name} {armor.Magic.Curse}");
            Assert.That(armor.Traits, Does.Not.Contain(size)
                .And.Contains("my trait"), $"{armor.Name} {armor.Magic.Curse}");
        }

        [TestCase(ArmorConstants.HeavySteelShield, PowerConstants.Minor, TraitConstants.Sizes.Colossal)]
        [TestCase(ArmorConstants.HeavySteelShield, PowerConstants.Minor, TraitConstants.Sizes.Gargantuan)]
        [TestCase(ArmorConstants.HeavySteelShield, PowerConstants.Minor, TraitConstants.Sizes.Huge)]
        [TestCase(ArmorConstants.HeavySteelShield, PowerConstants.Minor, TraitConstants.Sizes.Large)]
        [TestCase(ArmorConstants.HeavySteelShield, PowerConstants.Minor, TraitConstants.Sizes.Medium)]
        [TestCase(ArmorConstants.HeavySteelShield, PowerConstants.Minor, TraitConstants.Sizes.Small)]
        [TestCase(ArmorConstants.HeavySteelShield, PowerConstants.Minor, TraitConstants.Sizes.Tiny)]
        [TestCase(ArmorConstants.HeavySteelShield, PowerConstants.Medium, TraitConstants.Sizes.Colossal)]
        [TestCase(ArmorConstants.HeavySteelShield, PowerConstants.Medium, TraitConstants.Sizes.Gargantuan)]
        [TestCase(ArmorConstants.HeavySteelShield, PowerConstants.Medium, TraitConstants.Sizes.Huge)]
        [TestCase(ArmorConstants.HeavySteelShield, PowerConstants.Medium, TraitConstants.Sizes.Large)]
        [TestCase(ArmorConstants.HeavySteelShield, PowerConstants.Medium, TraitConstants.Sizes.Medium)]
        [TestCase(ArmorConstants.HeavySteelShield, PowerConstants.Medium, TraitConstants.Sizes.Small)]
        [TestCase(ArmorConstants.HeavySteelShield, PowerConstants.Medium, TraitConstants.Sizes.Tiny)]
        [TestCase(ArmorConstants.HeavySteelShield, PowerConstants.Major, TraitConstants.Sizes.Colossal)]
        [TestCase(ArmorConstants.HeavySteelShield, PowerConstants.Major, TraitConstants.Sizes.Gargantuan)]
        [TestCase(ArmorConstants.HeavySteelShield, PowerConstants.Major, TraitConstants.Sizes.Huge)]
        [TestCase(ArmorConstants.HeavySteelShield, PowerConstants.Major, TraitConstants.Sizes.Large)]
        [TestCase(ArmorConstants.HeavySteelShield, PowerConstants.Major, TraitConstants.Sizes.Medium)]
        [TestCase(ArmorConstants.HeavySteelShield, PowerConstants.Major, TraitConstants.Sizes.Small)]
        [TestCase(ArmorConstants.HeavySteelShield, PowerConstants.Major, TraitConstants.Sizes.Tiny)]
        public void GenerateShieldOfSize(string itemName, string power, string size)
        {
            var item = ArmorGenerator.Generate(power, itemName, "my trait", size);
            itemVerifier.AssertItem(item);
            Assert.That(item, Is.InstanceOf<Armor>());

            var armor = item as Armor;
            Assert.That(armor.ItemType, Is.EqualTo(ItemTypeConstants.Armor), $"{armor.Name} {armor.Magic.Curse}");
            Assert.That(armor.NameMatches(itemName), Is.True, $"{armor.Name} {armor.Magic.Curse}");
            Assert.That(armor.Size, Is.EqualTo(size), $"{armor.Name} {armor.Magic.Curse}");
            Assert.That(armor.Traits, Does.Not.Contain(size)
                .And.Contains("my trait"), $"{armor.Name} {armor.Magic.Curse}");
            Assert.That(armor.Attributes, Contains.Item(AttributeConstants.Shield), $"{armor.Name} {armor.Magic.Curse}");
        }

        [TestCase(PowerConstants.Minor)]
        [TestCase(PowerConstants.Medium)]
        [TestCase(PowerConstants.Major)]
        public void BUG_DragonhideCastersShieldRemovesWoodAndMetalAsAttributes(string power)
        {
            var shield = ArmorGenerator.Generate(power, ArmorConstants.CastersShield, TraitConstants.SpecialMaterials.Dragonhide);
            itemVerifier.AssertItem(shield);
            Assert.That(shield.Traits, Contains.Item(TraitConstants.SpecialMaterials.Dragonhide));
            Assert.That(shield.Attributes, Does.Not.Contain(AttributeConstants.Wood)
                .And.Not.Contain(AttributeConstants.Metal));
        }
    }
}
