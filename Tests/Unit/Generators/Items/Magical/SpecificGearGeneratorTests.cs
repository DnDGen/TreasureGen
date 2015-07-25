using Moq;
using NUnit.Framework;
using System;
using System.Linq;
using TreasureGen.Common.Items;
using TreasureGen.Generators.Domain.Items.Magical;
using TreasureGen.Generators.Items.Magical;
using TreasureGen.Selectors;
using TreasureGen.Selectors.Results;
using TreasureGen.Tables;

namespace TreasureGen.Tests.Unit.Generators.Items.Magical
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
        private String power;
        private String gearType;

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
            power = "power";
            gearType = "gear type";

            result.Type = "specific gear";
            result.Amount = 0;
            mockTypeAndAmountPercentileSelector.Setup(s => s.SelectFrom(It.IsAny<String>())).Returns(result);

            generator = new SpecificGearGenerator(mockTypeAndAmountPercentileSelector.Object, mockAttributesSelector.Object, mockSpecialAbilitiesAttributesSelector.Object
                , mockChargesGenerator.Object, mockPercentileSelector.Object, mockSpellGenerator.Object, mockBooleanPercentileSelector.Object);
        }

        [Test]
        public void ReturnGear()
        {
            var gear = generator.GenerateFrom(power, gearType);
            Assert.That(gear, Is.Not.Null);
        }

        [TestCase(ItemTypeConstants.Armor, ItemTypeConstants.Armor)]
        [TestCase(AttributeConstants.Shield, ItemTypeConstants.Armor)]
        [TestCase(ItemTypeConstants.Weapon, ItemTypeConstants.Weapon)]
        public void CorrectItemType(String gearType, String itemType)
        {
            var gear = generator.GenerateFrom(power, gearType);
            Assert.That(gear.ItemType, Is.EqualTo(itemType));
        }

        [Test]
        public void GetGearNameAndBonusFromSelector()
        {
            var newResult = new TypeAndAmountPercentileResult();
            newResult.Type = "new specific gear";
            newResult.Amount = 42;
            var tableName = String.Format(TableNameConstants.Percentiles.Formattable.POWERSpecificITEMTYPEs, power, gearType);
            mockTypeAndAmountPercentileSelector.Setup(s => s.SelectFrom(tableName)).Returns(newResult);

            var gear = generator.GenerateFrom(power, gearType);
            Assert.That(gear.Name, Is.EqualTo("new specific gear"));
            Assert.That(gear.Magic.Bonus, Is.EqualTo(42));
        }

        [Test]
        public void JavelinOfLightningIsMagical()
        {
            result.Type = "Javelin of lightning";
            var gear = generator.GenerateFrom(power, gearType);
            Assert.That(gear.IsMagical, Is.True);
        }

        [Test]
        public void GetAttributesFromSelector()
        {
            var attributes = new[] { "attribute 1", "attribute 2" };
            var tableName = String.Format(TableNameConstants.Attributes.Formattable.SpecificITEMTYPEAttributes, gearType);
            mockAttributesSelector.Setup(s => s.SelectFrom(tableName, "specific gear")).Returns(attributes);

            var gear = generator.GenerateFrom(power, gearType);
            Assert.That(gear.Attributes, Is.EqualTo(attributes));
        }

        [Test]
        public void GetTraitsFromSelector()
        {
            var traits = new[] { "trait 1", "trait 2" };
            var tableName = String.Format(TableNameConstants.Attributes.Formattable.SpecificITEMTYPETraits, gearType);
            mockAttributesSelector.Setup(s => s.SelectFrom(tableName, "specific gear")).Returns(traits);

            var gear = generator.GenerateFrom(power, gearType);

            foreach (var trait in traits)
                Assert.That(gear.Traits, Contains.Item(trait));

            Assert.That(gear.Traits.Count, Is.EqualTo(traits.Count()));
        }

        [Test]
        public void GetSpecialAbilitiesFromSelector()
        {
            var specialAbilities = new[] { "ability 1", "ability 2" };
            var tableName = String.Format(TableNameConstants.Attributes.Formattable.SpecificITEMTYPESpecialAbilities, gearType);
            mockAttributesSelector.Setup(s => s.SelectFrom(tableName, "specific gear")).Returns(specialAbilities);
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
            mockSpecialAbilitiesAttributesSelector.Setup(s => s.SelectFrom(TableNameConstants.Attributes.Set.SpecialAbilityAttributes, "ability 1")).Returns(ability1Result);
            mockSpecialAbilitiesAttributesSelector.Setup(s => s.SelectFrom(TableNameConstants.Attributes.Set.SpecialAbilityAttributes, "ability 2")).Returns(ability2Result);
            mockAttributesSelector.Setup(s => s.SelectFrom(TableNameConstants.Attributes.Set.SpecialAbilityAttributeRequirements, "base name")).Returns(ability1Requirements);
            mockAttributesSelector.Setup(s => s.SelectFrom(TableNameConstants.Attributes.Set.SpecialAbilityAttributeRequirements, "base name 2")).Returns(ability2Requirements);

            var gear = generator.GenerateFrom(power, gearType);
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
            var tableName = String.Format(TableNameConstants.Attributes.Formattable.SpecificITEMTYPEAttributes, gearType);
            mockAttributesSelector.Setup(s => s.SelectFrom(tableName, "specific gear")).Returns(attributes);
            mockChargesGenerator.Setup(g => g.GenerateFor(gearType, "specific gear")).Returns(9266);

            var gear = generator.GenerateFrom(power, gearType);
            Assert.That(gear.Magic.Charges, Is.EqualTo(9266));
        }

        [Test]
        public void IfNotCharged_DoNotGetChargesFromGenerator()
        {
            var attributes = new[] { "not charged" };
            var tableName = String.Format(TableNameConstants.Attributes.Formattable.SpecificITEMTYPEAttributes, gearType);
            mockAttributesSelector.Setup(s => s.SelectFrom(tableName, "specific gear")).Returns(attributes);
            mockChargesGenerator.Setup(g => g.GenerateFor(gearType, "specific gear")).Returns(9266);

            var gear = generator.GenerateFrom(power, gearType);
            Assert.That(gear.Magic.Charges, Is.EqualTo(0));
        }

        [Test]
        public void SilverDaggerRenamedDagger()
        {
            result.Type = WeaponConstants.SilverDagger;
            var gear = generator.GenerateFrom(power, gearType);
            Assert.That(gear.Name, Is.EqualTo(WeaponConstants.Dagger));
        }

        [TestCase(WeaponConstants.LuckBlade0)]
        [TestCase(WeaponConstants.LuckBlade1)]
        [TestCase(WeaponConstants.LuckBlade2)]
        [TestCase(WeaponConstants.LuckBlade3)]
        public void LuckBladeWithChargeRenamedLuckBlade(String luckBlade)
        {
            result.Type = luckBlade;
            var gear = generator.GenerateFrom(power, gearType);
            Assert.That(gear.Name, Is.EqualTo(WeaponConstants.LuckBlade));
        }

        [Test]
        public void CastersShieldHasNoSpellIfSelectorSaysSo()
        {
            result.Type = ArmorConstants.CastersShield;
            mockPercentileSelector.Setup(s => s.SelectFrom(TableNameConstants.Percentiles.Set.CastersShieldSpellTypes)).Returns("spell type");
            mockSpellGenerator.Setup(g => g.GenerateLevel(PowerConstants.Medium)).Returns(42);
            mockSpellGenerator.Setup(g => g.Generate("spell type", 42)).Returns("spell");
            mockBooleanPercentileSelector.Setup(s => s.SelectFrom(TableNameConstants.Percentiles.Set.CastersShieldContainsSpell)).Returns(false);

            var gear = generator.GenerateFrom(power, gearType);
            Assert.That(gear.Name, Is.EqualTo(ArmorConstants.CastersShield));
            Assert.That(gear.Contents, Is.Empty);
        }

        [Test]
        public void CastersShieldHasSpellIfSelectorSaysSo()
        {
            result.Type = ArmorConstants.CastersShield;
            mockPercentileSelector.Setup(s => s.SelectFrom(TableNameConstants.Percentiles.Set.CastersShieldSpellTypes)).Returns("spell type");
            mockSpellGenerator.Setup(g => g.GenerateLevel(PowerConstants.Medium)).Returns(42);
            mockSpellGenerator.Setup(g => g.Generate("spell type", 42)).Returns("spell");
            mockBooleanPercentileSelector.Setup(s => s.SelectFrom(TableNameConstants.Percentiles.Set.CastersShieldContainsSpell)).Returns(true);

            var gear = generator.GenerateFrom(power, gearType);
            Assert.That(gear.Name, Is.EqualTo(ArmorConstants.CastersShield));
            Assert.That(gear.Contents, Contains.Item("spell (spell type, 42)"));
        }

        [Test]
        public void SlayingArrowHasDesignatedFoe()
        {
            result.Type = WeaponConstants.SlayingArrow;
            mockPercentileSelector.Setup(s => s.SelectFrom(TableNameConstants.Percentiles.Set.DesignatedFoes)).Returns("foe");

            var gear = generator.GenerateFrom(power, gearType);
            Assert.That(gear.Name, Is.EqualTo("Slaying arrow (foe)"));
        }

        [Test]
        public void GreaterSlayingArrowHasDesignatedFoe()
        {
            result.Type = WeaponConstants.GreaterSlayingArrow;
            mockPercentileSelector.Setup(s => s.SelectFrom(TableNameConstants.Percentiles.Set.DesignatedFoes)).Returns("foe");

            var gear = generator.GenerateFrom(power, gearType);
            Assert.That(gear.Name, Is.EqualTo("Greater slaying arrow (foe)"));
        }
    }
}