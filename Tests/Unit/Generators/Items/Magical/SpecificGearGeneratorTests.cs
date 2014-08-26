using System;
using System.Linq;
using EquipmentGen.Common.Items;
using EquipmentGen.Generators.Interfaces.Items.Magical;
using EquipmentGen.Generators.Items.Magical;
using EquipmentGen.Selectors.Interfaces;
using EquipmentGen.Selectors.Interfaces.Objects;
using Moq;
using NUnit.Framework;

namespace EquipmentGen.Tests.Unit.Generators.Items.Magical
{
    [TestFixture]
    public class SpecificGearGeneratorTests
    {
        private ISpecificGearGenerator generator;
        private Mock<ITypeAndAmountPercentileSelector> mockTypeAndAmountPercentileSelector;
        private Mock<IAttributesSelector> mockAttributesSelector;
        private Mock<ISpecialAbilityAttributesSelector> mockSpecialAbilitiesAttributesSelector;
        private Mock<IChargesGenerator> mockChargesGenerator;
        private Mock<ISpellGenerator> mockSpellGenerator;
        private Mock<IPercentileSelector> mockPercentileSelector;
        private Mock<IBooleanPercentileSelector> mockBooleanPercentileSelector;
        private TypeAndAmountPercentileResult result;

        [SetUp]
        public void Setup()
        {
            mockTypeAndAmountPercentileSelector = new Mock<ITypeAndAmountPercentileSelector>();
            mockAttributesSelector = new Mock<IAttributesSelector>();
            mockSpecialAbilitiesAttributesSelector = new Mock<ISpecialAbilityAttributesSelector>();
            mockChargesGenerator = new Mock<IChargesGenerator>();
            mockSpellGenerator = new Mock<ISpellGenerator>();
            mockPercentileSelector = new Mock<IPercentileSelector>();
            mockBooleanPercentileSelector = new Mock<IBooleanPercentileSelector>();
            result = new TypeAndAmountPercentileResult();

            result.Type = "specific gear";
            result.Amount = 0;
            mockTypeAndAmountPercentileSelector.Setup(s => s.SelectFrom(It.IsAny<String>())).Returns(result);

            generator = new SpecificGearGenerator(mockTypeAndAmountPercentileSelector.Object, mockAttributesSelector.Object, mockSpecialAbilitiesAttributesSelector.Object
                , mockChargesGenerator.Object, mockPercentileSelector.Object, mockSpellGenerator.Object, mockBooleanPercentileSelector.Object);
        }

        [Test]
        public void ReturnGear()
        {
            var gear = generator.GenerateFrom("power", "Specific gear type");
            Assert.That(gear, Is.Not.Null);
        }

        [Test]
        public void ItemTypeIsArmorIfArmor()
        {
            var gear = generator.GenerateFrom("power", "SpecificArmor");
            Assert.That(gear.ItemType, Is.EqualTo(ItemTypeConstants.Armor));
        }

        [Test]
        public void ItemTypeIsArmorIfShield()
        {
            var gear = generator.GenerateFrom("power", "SpecificShield");
            Assert.That(gear.ItemType, Is.EqualTo(ItemTypeConstants.Armor));
        }

        [Test]
        public void ItemTypeIsWeaponIfWeapon()
        {
            var gear = generator.GenerateFrom("power", "SpecificWeapon");
            Assert.That(gear.ItemType, Is.EqualTo(ItemTypeConstants.Weapon));
        }

        [Test]
        public void GetGearNameAndBonusFromSelector()
        {
            var newResult = new TypeAndAmountPercentileResult();
            newResult.Type = "new specific gear";
            newResult.Amount = 42;
            mockTypeAndAmountPercentileSelector.Setup(s => s.SelectFrom("powerSpecific gear type")).Returns(newResult);

            var gear = generator.GenerateFrom("power", "Specific gear type");
            Assert.That(gear.Name, Is.EqualTo("new specific gear"));
            Assert.That(gear.Magic.Bonus, Is.EqualTo(42));
        }

        [Test]
        public void JavelinOfLightningIsMagical()
        {
            result.Type = "Javelin of lightning";
            var gear = generator.GenerateFrom("power", "Specific gear type");
            Assert.That(gear.IsMagical, Is.True);
        }

        [Test]
        public void GetAttributesFromSelector()
        {
            var attributes = new[] { "attribute 1", "attribute 2" };
            mockAttributesSelector.Setup(s => s.SelectFrom("Specific gear typeAttributes", "specific gear")).Returns(attributes);

            var gear = generator.GenerateFrom("power", "Specific gear type");
            Assert.That(gear.Attributes, Is.EqualTo(attributes));
        }

        [Test]
        public void GetTraitsFromSelector()
        {
            var traits = new[] { "trait 1", "trait 2" };
            mockAttributesSelector.Setup(s => s.SelectFrom("Specific gear typeTraits", "specific gear")).Returns(traits);

            var gear = generator.GenerateFrom("power", "Specific gear type");

            foreach (var trait in traits)
                Assert.That(gear.Traits, Contains.Item(trait));

            Assert.That(gear.Traits.Count, Is.EqualTo(traits.Count()));
        }

        [Test]
        public void GetSpecialAbilitiesFromSelector()
        {
            var specialAbilities = new[] { "ability 1", "ability 2" };
            mockAttributesSelector.Setup(s => s.SelectFrom("Specific gear typeSpecialAbilities", "specific gear")).Returns(specialAbilities);
            var ability1Result = new SpecialAbilityAttributesResult();
            ability1Result.BaseName = "base name";
            ability1Result.BonusEquivalent = 9266;
            ability1Result.Strength = 42;
            var ability1Requirements = new[] { "req 1", "req 2" };
            var ability2Result = new SpecialAbilityAttributesResult();
            ability2Result.BaseName = "base name 2";
            ability2Result.BonusEquivalent = 6629;
            ability2Result.Strength = 24;
            var ability2Requirements = new[] { "req a", "req b" };
            mockSpecialAbilitiesAttributesSelector.Setup(s => s.SelectFrom("SpecialAbilityAttributes", "ability 1")).Returns(ability1Result);
            mockSpecialAbilitiesAttributesSelector.Setup(s => s.SelectFrom("SpecialAbilityAttributes", "ability 2")).Returns(ability2Result);
            mockAttributesSelector.Setup(s => s.SelectFrom("SpecialAbilityAttributeRequirements", "base name")).Returns(ability1Requirements);
            mockAttributesSelector.Setup(s => s.SelectFrom("SpecialAbilityAttributeRequirements", "base name 2")).Returns(ability2Requirements);

            var gear = generator.GenerateFrom("power", "Specific gear type");
            var ability1 = gear.Magic.SpecialAbilities.First();
            var ability2 = gear.Magic.SpecialAbilities.Last();
            Assert.That(ability1.Name, Is.EqualTo("ability 1"));
            Assert.That(ability1.BaseName, Is.EqualTo(ability1Result.BaseName));
            Assert.That(ability1.AttributeRequirements, Is.EqualTo(ability1Requirements));
            Assert.That(ability1.BonusEquivalent, Is.EqualTo(ability1Result.BonusEquivalent));
            Assert.That(ability1.Strength, Is.EqualTo(ability1Result.Strength));
            Assert.That(ability2.Name, Is.EqualTo("ability 2"));
            Assert.That(ability2.BaseName, Is.EqualTo(ability2Result.BaseName));
            Assert.That(ability2.AttributeRequirements, Is.EqualTo(ability2Requirements));
            Assert.That(ability2.BonusEquivalent, Is.EqualTo(ability2Result.BonusEquivalent));
            Assert.That(ability2.Strength, Is.EqualTo(ability2Result.Strength));
            Assert.That(gear.Magic.SpecialAbilities.Count(), Is.EqualTo(2));
        }

        [Test]
        public void IfCharged_GetChargesFromGenerator()
        {
            var attributes = new[] { AttributeConstants.Charged };
            mockAttributesSelector.Setup(s => s.SelectFrom("Specific gear typeAttributes", "specific gear")).Returns(attributes);
            mockChargesGenerator.Setup(g => g.GenerateFor(" gear type", "specific gear")).Returns(9266);

            var gear = generator.GenerateFrom("power", "Specific gear type");
            Assert.That(gear.Magic.Charges, Is.EqualTo(9266));
        }

        [Test]
        public void IfNotCharged_DoNotGetChargesFromGenerator()
        {
            var attributes = new[] { "not charged" };
            mockAttributesSelector.Setup(s => s.SelectFrom("Specific gear typesAttributes", "specific gear")).Returns(attributes);
            mockChargesGenerator.Setup(g => g.GenerateFor(" gear type", "specific gear")).Returns(9266);

            var gear = generator.GenerateFrom("power", "Specific gear types");
            Assert.That(gear.Magic.Charges, Is.EqualTo(0));
        }

        [Test]
        public void SilverDaggerBecomesDaggerWithAlchemicalSilverTrait()
        {
            result.Type = WeaponConstants.SilverDagger;
            var traits = new[] { TraitConstants.AlchemicalSilver };
            mockAttributesSelector.Setup(s => s.SelectFrom("Specific gear typeTraits", result.Type)).Returns(traits);

            var gear = generator.GenerateFrom("power", "Specific gear type");

            Assert.That(gear.Traits, Contains.Item(TraitConstants.AlchemicalSilver));
            Assert.That(gear.Name, Is.EqualTo(WeaponConstants.Dagger));
        }

        [Test]
        public void LuckBlade0BecomesLuckBladeWithChargeOf0()
        {
            result.Type = WeaponConstants.LuckBlade0;
            var attributes = new[] { AttributeConstants.Charged };
            mockAttributesSelector.Setup(s => s.SelectFrom("Specific gear typeAttributes", result.Type)).Returns(attributes);
            mockChargesGenerator.Setup(g => g.GenerateFor(" gear type", result.Type)).Returns(0);

            var gear = generator.GenerateFrom("power", "Specific gear type");

            Assert.That(gear.Magic.Charges, Is.EqualTo(0));
            Assert.That(gear.Name, Is.EqualTo(WeaponConstants.LuckBlade));
        }

        [Test]
        public void LuckBlade1BecomesLuckBladeWithChargeOf1()
        {
            result.Type = WeaponConstants.LuckBlade1;
            var attributes = new[] { AttributeConstants.Charged };
            mockAttributesSelector.Setup(s => s.SelectFrom("Specific gear typeAttributes", result.Type)).Returns(attributes);
            mockChargesGenerator.Setup(g => g.GenerateFor(" gear type", result.Type)).Returns(1);

            var gear = generator.GenerateFrom("power", "Specific gear type");

            Assert.That(gear.Magic.Charges, Is.EqualTo(1));
            Assert.That(gear.Name, Is.EqualTo(WeaponConstants.LuckBlade));
        }

        [Test]
        public void LuckBlade2BecomesLuckBladeWithChargeOf2()
        {
            result.Type = WeaponConstants.LuckBlade2;
            var attributes = new[] { AttributeConstants.Charged };
            mockAttributesSelector.Setup(s => s.SelectFrom("Specific gear typeAttributes", result.Type)).Returns(attributes);
            mockChargesGenerator.Setup(g => g.GenerateFor(" gear type", result.Type)).Returns(2);

            var gear = generator.GenerateFrom("power", "Specific gear type");

            Assert.That(gear.Magic.Charges, Is.EqualTo(2));
            Assert.That(gear.Name, Is.EqualTo(WeaponConstants.LuckBlade));
        }

        [Test]
        public void LuckBlade3BecomesLuckBladeWithChargeOf3()
        {
            result.Type = WeaponConstants.LuckBlade3;
            var attributes = new[] { AttributeConstants.Charged };
            mockAttributesSelector.Setup(s => s.SelectFrom("Specific gear typeAttributes", result.Type)).Returns(attributes);
            mockChargesGenerator.Setup(g => g.GenerateFor(" gear type", result.Type)).Returns(3);

            var gear = generator.GenerateFrom("power", "Specific gear type");

            Assert.That(gear.Magic.Charges, Is.EqualTo(3));
            Assert.That(gear.Name, Is.EqualTo(WeaponConstants.LuckBlade));
        }

        [Test]
        public void CastersShieldHasNoSpellIfSelectorSaysSo()
        {
            result.Type = ArmorConstants.CastersShield;
            mockPercentileSelector.Setup(s => s.SelectFrom("CastersShieldSpellTypes")).Returns("spell type");
            mockSpellGenerator.Setup(g => g.GenerateLevel(PowerConstants.Medium)).Returns(42);
            mockSpellGenerator.Setup(g => g.Generate("spell type", 42)).Returns("spell");
            mockBooleanPercentileSelector.Setup(s => s.SelectFrom("CastersShieldContainsSpell")).Returns(false);

            var gear = generator.GenerateFrom("power", "Specific gear type");
            Assert.That(gear.Name, Is.EqualTo(ArmorConstants.CastersShield));
            Assert.That(gear.Contents, Is.Empty);
        }

        [Test]
        public void CastersShieldHasSpellIfSelectorSaysSo()
        {
            result.Type = ArmorConstants.CastersShield;
            mockPercentileSelector.Setup(s => s.SelectFrom("CastersShieldSpellTypes")).Returns("spell type");
            mockSpellGenerator.Setup(g => g.GenerateLevel(PowerConstants.Medium)).Returns(42);
            mockSpellGenerator.Setup(g => g.Generate("spell type", 42)).Returns("spell");
            mockBooleanPercentileSelector.Setup(s => s.SelectFrom("CastersShieldContainsSpell")).Returns(true);

            var gear = generator.GenerateFrom("power", "Specific gear type");
            Assert.That(gear.Name, Is.EqualTo(ArmorConstants.CastersShield));
            Assert.That(gear.Contents, Contains.Item("spell (spell type, 42)"));
        }

        [Test]
        public void SlayingArrowHasDesignatedFoe()
        {
            result.Type = WeaponConstants.SlayingArrow;
            mockPercentileSelector.Setup(s => s.SelectFrom("DesignatedFoes")).Returns("foe");

            var gear = generator.GenerateFrom("power", "Specific gear type");
            Assert.That(gear.Name, Is.EqualTo("Slaying arrow (foe)"));
        }

        [Test]
        public void GreaterSlayingArrowHasDesignatedFoe()
        {
            result.Type = WeaponConstants.GreaterSlayingArrow;
            mockPercentileSelector.Setup(s => s.SelectFrom("DesignatedFoes")).Returns("foe");

            var gear = generator.GenerateFrom("power", "Specific gear type");
            Assert.That(gear.Name, Is.EqualTo("Greater slaying arrow (foe)"));
        }
    }
}