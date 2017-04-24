using Moq;
using NUnit.Framework;
using RollGen;
using System.Collections.Generic;
using TreasureGen.Domain.Generators.Items.Magical;
using TreasureGen.Domain.Selectors.Collections;
using TreasureGen.Domain.Selectors.Percentiles;
using TreasureGen.Domain.Selectors.Selections;
using TreasureGen.Domain.Tables;
using TreasureGen.Items;
using TreasureGen.Items.Magical;

namespace TreasureGen.Tests.Unit.Generators.Items.Magical
{
    [TestFixture]
    public class IntelligenceGeneratorTests
    {
        private IIntelligenceGenerator intelligenceGenerator;
        private Mock<Dice> mockDice;
        private Mock<IPercentileSelector> mockPercentileSelector;
        private Mock<ICollectionsSelector> mockCollectionsSelector;
        private Mock<IIntelligenceDataSelector> mockIntelligenceDataSelector;
        private Mock<IBooleanPercentileSelector> mockBooleanPercentileSelector;
        private List<string> attributes;
        private IntelligenceSelection intelligenceSelection;
        private Item item;
        private string itemType;

        [SetUp]
        public void Setup()
        {
            mockDice = new Mock<Dice>();
            mockPercentileSelector = new Mock<IPercentileSelector>();
            mockCollectionsSelector = new Mock<ICollectionsSelector>();
            mockIntelligenceDataSelector = new Mock<IIntelligenceDataSelector>();
            mockBooleanPercentileSelector = new Mock<IBooleanPercentileSelector>();
            intelligenceSelection = new IntelligenceSelection();
            attributes = new List<string>();
            item = new Item();
            itemType = "item type";

            var fillerValues = new[] { "0" };
            mockCollectionsSelector.Setup(s => s.SelectFrom(It.IsAny<string>(), It.IsAny<string>())).Returns(fillerValues);
            mockDice.Setup(d => d.Roll(1).d(4).AsSum()).Returns(4);
            mockPercentileSelector.Setup(s => s.SelectFrom(TableNameConstants.Percentiles.Set.IntelligenceStrongStats)).Returns("10");
            mockIntelligenceDataSelector.Setup(s => s.SelectFrom(It.IsAny<string>())).Returns(intelligenceSelection);
            mockPercentileSelector.Setup(s => s.SelectFrom(TableNameConstants.Percentiles.Set.IntelligenceAlignments)).Returns(string.Empty);

            intelligenceGenerator = new IntelligenceGenerator(mockDice.Object, mockPercentileSelector.Object,
                mockCollectionsSelector.Object, mockIntelligenceDataSelector.Object, mockBooleanPercentileSelector.Object);
        }

        [Test]
        public void DetermineIntelligentFromBooleanSelector()
        {
            var tableName = string.Format(TableNameConstants.Percentiles.Formattable.IsITEMTYPEIntelligent, itemType);
            mockBooleanPercentileSelector.Setup(s => s.SelectFrom(tableName)).Returns(true);

            var isIntelligent = intelligenceGenerator.IsIntelligent(itemType, attributes, true);
            Assert.That(isIntelligent, Is.True);
        }

        [Test]
        public void DetermineNotIntelligentFromBooleanSelector()
        {
            var tableName = string.Format(TableNameConstants.Percentiles.Formattable.IsITEMTYPEIntelligent, itemType);
            mockBooleanPercentileSelector.Setup(s => s.SelectFrom(tableName)).Returns(false);

            var isIntelligent = intelligenceGenerator.IsIntelligent(itemType, attributes, true);
            Assert.That(isIntelligent, Is.False);
        }

        [Test]
        public void DetermineMeleeIntelligence()
        {
            attributes.Add(AttributeConstants.Melee);
            var tableName = string.Format(TableNameConstants.Percentiles.Formattable.IsITEMTYPEIntelligent, AttributeConstants.Melee);
            mockBooleanPercentileSelector.Setup(s => s.SelectFrom(tableName)).Returns(true);

            var isIntelligent = intelligenceGenerator.IsIntelligent(itemType, attributes, true);
            Assert.That(isIntelligent, Is.True);
        }

        [Test]
        public void DetermineRangedIntelligence()
        {
            attributes.Add(AttributeConstants.Ranged);
            var tableName = string.Format(TableNameConstants.Percentiles.Formattable.IsITEMTYPEIntelligent, AttributeConstants.Ranged);
            mockBooleanPercentileSelector.Setup(s => s.SelectFrom(tableName)).Returns(true);

            var isIntelligent = intelligenceGenerator.IsIntelligent(itemType, attributes, true);
            Assert.That(isIntelligent, Is.True);
        }

        [Test]
        public void DetermineRangedAndMeleeIntelligence()
        {
            attributes.Add(AttributeConstants.Melee);
            attributes.Add(AttributeConstants.Ranged);
            var tableName = string.Format(TableNameConstants.Percentiles.Formattable.IsITEMTYPEIntelligent, AttributeConstants.Melee);
            mockBooleanPercentileSelector.Setup(s => s.SelectFrom(tableName)).Returns(true);

            var isIntelligent = intelligenceGenerator.IsIntelligent(itemType, attributes, true);
            Assert.That(isIntelligent, Is.True);
        }

        [Test]
        public void AmmunitionIsNotIntelligent()
        {
            attributes.Add(AttributeConstants.Ammunition);
            var tableName = string.Format(TableNameConstants.Percentiles.Formattable.IsITEMTYPEIntelligent, itemType);
            mockBooleanPercentileSelector.Setup(s => s.SelectFrom(tableName)).Returns(true);

            var isIntelligent = intelligenceGenerator.IsIntelligent(itemType, attributes, true);
            Assert.That(isIntelligent, Is.False);
        }

        [Test]
        public void OneTimeUseItemsAreNotIntelligent()
        {
            attributes.Add(AttributeConstants.OneTimeUse);
            var tableName = string.Format(TableNameConstants.Percentiles.Formattable.IsITEMTYPEIntelligent, itemType);
            mockBooleanPercentileSelector.Setup(s => s.SelectFrom(tableName)).Returns(true);

            var isIntelligent = intelligenceGenerator.IsIntelligent(itemType, attributes, true);
            Assert.That(isIntelligent, Is.False);
        }

        [Test]
        public void NonMagicalItemsAreNotIntelligent()
        {
            var tableName = string.Format(TableNameConstants.Percentiles.Formattable.IsITEMTYPEIntelligent, itemType);
            mockBooleanPercentileSelector.Setup(s => s.SelectFrom(tableName)).Returns(true);

            var isIntelligent = intelligenceGenerator.IsIntelligent(itemType, attributes, false);
            Assert.That(isIntelligent, Is.False);
        }

        [Test]
        public void ReturnIntelligence()
        {
            var intelligence = intelligenceGenerator.GenerateFor(item);
            Assert.That(intelligence, Is.Not.Null);
        }

        [Test]
        public void Roll1MeansCharismaIsWeakStat()
        {
            mockDice.Setup(d => d.Roll(1).d(3).AsSum()).Returns(1);
            mockPercentileSelector.Setup(s => s.SelectFrom(TableNameConstants.Percentiles.Set.IntelligenceStrongStats)).Returns("42");

            var intelligence = intelligenceGenerator.GenerateFor(item);
            Assert.That(intelligence.CharismaStat, Is.EqualTo(10));
            Assert.That(intelligence.IntelligenceStat, Is.EqualTo(42));
            Assert.That(intelligence.WisdomStat, Is.EqualTo(42));
        }

        [Test]
        public void Roll2MeansIntelligenceIsWeakStat()
        {
            mockDice.Setup(d => d.Roll(1).d(3).AsSum()).Returns(2);
            mockPercentileSelector.Setup(s => s.SelectFrom(TableNameConstants.Percentiles.Set.IntelligenceStrongStats)).Returns("42");

            var intelligence = intelligenceGenerator.GenerateFor(item);
            Assert.That(intelligence.CharismaStat, Is.EqualTo(42));
            Assert.That(intelligence.IntelligenceStat, Is.EqualTo(10));
            Assert.That(intelligence.WisdomStat, Is.EqualTo(42));
        }

        [Test]
        public void Roll3MeansWisdomIsWeakStat()
        {
            mockDice.Setup(d => d.Roll(1).d(3).AsSum()).Returns(3);
            mockPercentileSelector.Setup(s => s.SelectFrom(TableNameConstants.Percentiles.Set.IntelligenceStrongStats)).Returns("42");

            var intelligence = intelligenceGenerator.GenerateFor(item);
            Assert.That(intelligence.CharismaStat, Is.EqualTo(42));
            Assert.That(intelligence.IntelligenceStat, Is.EqualTo(42));
            Assert.That(intelligence.WisdomStat, Is.EqualTo(10));
        }

        [Test]
        public void GetCommunicationFromAttributesSelector()
        {
            var attributes = new[] { "talky" };
            mockPercentileSelector.Setup(s => s.SelectFrom(TableNameConstants.Percentiles.Set.IntelligenceStrongStats)).Returns("9266");
            mockCollectionsSelector.Setup(s => s.SelectFrom(TableNameConstants.Collections.Set.IntelligenceCommunication, "9266")).Returns(attributes);

            var intelligence = intelligenceGenerator.GenerateFor(item);
            Assert.That(intelligence.Communication, Is.EqualTo(attributes));
        }

        [Test]
        public void GetLanguagesIfSpeech()
        {
            var attributes = new[] { "Speech" };
            mockPercentileSelector.Setup(s => s.SelectFrom(TableNameConstants.Percentiles.Set.IntelligenceStrongStats)).Returns("10");
            mockCollectionsSelector.Setup(s => s.SelectFrom(TableNameConstants.Collections.Set.IntelligenceCommunication, "10")).Returns(attributes);

            var intelligence = intelligenceGenerator.GenerateFor(item);
            Assert.That(intelligence.Languages, Contains.Item("Common"));
        }

        [Test]
        public void GetNumberOfBonusLanguagesEqualToIntelligenceModifier()
        {
            var attributes = new[] { "Speech" };
            mockPercentileSelector.Setup(s => s.SelectFrom(TableNameConstants.Percentiles.Set.IntelligenceStrongStats)).Returns("14");
            mockCollectionsSelector.Setup(s => s.SelectFrom(TableNameConstants.Collections.Set.IntelligenceCommunication, "14")).Returns(attributes);
            mockPercentileSelector.SetupSequence(s => s.SelectFrom(TableNameConstants.Percentiles.Set.Languages)).Returns("english").Returns("german");

            var intelligence = intelligenceGenerator.GenerateFor(item);
            Assert.That(intelligence.Languages, Contains.Item("Common"));
            Assert.That(intelligence.Languages, Contains.Item("english"));
            Assert.That(intelligence.Languages, Contains.Item("german"));
            Assert.That(intelligence.Languages.Count, Is.EqualTo(3));
        }

        [Test]
        public void DoNotHaveDuplicateLanguages()
        {
            var attributes = new[] { "Speech" };
            mockPercentileSelector.Setup(s => s.SelectFrom(TableNameConstants.Percentiles.Set.IntelligenceStrongStats)).Returns("14");
            mockCollectionsSelector.Setup(s => s.SelectFrom(TableNameConstants.Collections.Set.IntelligenceCommunication, "14")).Returns(attributes);
            mockPercentileSelector.SetupSequence(s => s.SelectFrom(TableNameConstants.Percentiles.Set.Languages))
                .Returns("english").Returns("english").Returns("german");

            var intelligence = intelligenceGenerator.GenerateFor(item);
            Assert.That(intelligence.Languages, Contains.Item("Common"));
            Assert.That(intelligence.Languages, Contains.Item("english"));
            Assert.That(intelligence.Languages, Contains.Item("german"));
            Assert.That(intelligence.Languages.Count, Is.EqualTo(3));
        }

        [Test]
        public void GetSensesFromAttributesSelector()
        {
            intelligenceSelection.Senses = "sensy";
            var intelligence = intelligenceGenerator.GenerateFor(item);
            Assert.That(intelligence.Senses, Is.EqualTo(intelligenceSelection.Senses));
        }

        [Test]
        public void GetLesserPowersFromAttributesSelector()
        {
            intelligenceSelection.LesserPowersCount = 2;
            var tableName = string.Format(TableNameConstants.Percentiles.Formattable.IntelligencePOWERPowers, "Lesser");
            mockPercentileSelector.SetupSequence(s => s.SelectFrom(tableName)).Returns("power 1").Returns("power 2");

            var intelligence = intelligenceGenerator.GenerateFor(item);
            Assert.That(intelligence.Powers.Count, Is.EqualTo(2));
        }

        [Test]
        public void CannotHaveDuplicateLesserPowers()
        {
            intelligenceSelection.LesserPowersCount = 2;
            var tableName = string.Format(TableNameConstants.Percentiles.Formattable.IntelligencePOWERPowers, "Lesser");
            mockPercentileSelector.SetupSequence(s => s.SelectFrom(tableName)).Returns("power 1").Returns("power 1").Returns("power 2");

            var intelligence = intelligenceGenerator.GenerateFor(item);
            Assert.That(intelligence.Powers, Contains.Item("power 1"));
            Assert.That(intelligence.Powers, Contains.Item("power 2"));
            Assert.That(intelligence.Powers.Count, Is.EqualTo(2));
        }

        [Test]
        public void GetGreaterPowersFromAttributesSelector()
        {
            intelligenceSelection.GreaterPowersCount = 2;
            var tableName = string.Format(TableNameConstants.Percentiles.Formattable.IntelligencePOWERPowers, "Greater");
            mockPercentileSelector.SetupSequence(s => s.SelectFrom(tableName)).Returns("power 1").Returns("power 2");

            var intelligence = intelligenceGenerator.GenerateFor(item);
            Assert.That(intelligence.Powers.Count, Is.EqualTo(2));
        }

        [Test]
        public void CannotHaveDuplicateGreaterPowers()
        {
            intelligenceSelection.GreaterPowersCount = 2;
            var tableName = string.Format(TableNameConstants.Percentiles.Formattable.IntelligencePOWERPowers, "Greater");
            mockPercentileSelector.SetupSequence(s => s.SelectFrom(tableName)).Returns("power 1").Returns("power 1").Returns("power 2");

            var intelligence = intelligenceGenerator.GenerateFor(item);
            Assert.That(intelligence.Powers, Contains.Item("power 1"));
            Assert.That(intelligence.Powers, Contains.Item("power 2"));
            Assert.That(intelligence.Powers.Count, Is.EqualTo(2));
        }

        [Test]
        public void OneGreaterPowerMeans25PercentChanceForSpecialPurpose()
        {
            intelligenceSelection.GreaterPowersCount = 1;
            var tableName = string.Format(TableNameConstants.Percentiles.Formattable.IntelligencePOWERPowers, "Greater");
            mockPercentileSelector.Setup(s => s.SelectFrom(tableName)).Returns("greater power");
            mockDice.Setup(d => d.Roll(1).d(4).AsSum()).Returns(1);
            mockPercentileSelector.Setup(s => s.SelectFrom(TableNameConstants.Percentiles.Set.IntelligenceSpecialPurposes)).Returns("purpose");
            mockPercentileSelector.Setup(s => s.SelectFrom(TableNameConstants.Percentiles.Set.IntelligenceDedicatedPowers)).Returns("dedicated power");

            var intelligence = intelligenceGenerator.GenerateFor(item);
            Assert.That(intelligence.Powers, Is.Empty);
            Assert.That(intelligence.SpecialPurpose, Is.EqualTo("purpose"));
            Assert.That(intelligence.DedicatedPower, Is.EqualTo("dedicated power"));
        }

        [Test]
        public void OneGreaterPowerMeans75PercentChanceForGreaterPower()
        {
            intelligenceSelection.GreaterPowersCount = 1;
            var tableName = string.Format(TableNameConstants.Percentiles.Formattable.IntelligencePOWERPowers, "Greater");
            mockPercentileSelector.Setup(s => s.SelectFrom(tableName)).Returns("greater power");
            mockPercentileSelector.Setup(s => s.SelectFrom(TableNameConstants.Percentiles.Set.IntelligenceSpecialPurposes)).Returns("purpose");
            mockPercentileSelector.Setup(s => s.SelectFrom(TableNameConstants.Percentiles.Set.IntelligenceDedicatedPowers)).Returns("dedicated power");

            for (var roll = 4; roll > 1; roll--)
            {
                mockDice.Setup(d => d.Roll(1).d(4).AsSum()).Returns(roll);

                var intelligence = intelligenceGenerator.GenerateFor(item);
                Assert.That(intelligence.Powers, Contains.Item("greater power"));
                Assert.That(intelligence.Powers.Count, Is.EqualTo(1));
                Assert.That(intelligence.SpecialPurpose, Is.Empty);
                Assert.That(intelligence.DedicatedPower, Is.Empty);
            }
        }

        [Test]
        public void TwoGreaterPowerMeans50PercentChanceForSpecialPurpose()
        {
            intelligenceSelection.GreaterPowersCount = 2;
            mockPercentileSelector.Setup(s => s.SelectFrom(TableNameConstants.Percentiles.Set.IntelligenceSpecialPurposes)).Returns("purpose");
            mockPercentileSelector.Setup(s => s.SelectFrom(TableNameConstants.Percentiles.Set.IntelligenceDedicatedPowers)).Returns("dedicated power");

            for (var roll = 2; roll > 0; roll--)
            {
                var tableName = string.Format(TableNameConstants.Percentiles.Formattable.IntelligencePOWERPowers, "Greater");
                mockPercentileSelector.SetupSequence(s => s.SelectFrom(tableName)).Returns("greater power 1").Returns("greater power 2");
                mockDice.Setup(d => d.Roll(1).d(4).AsSum()).Returns(roll);

                var intelligence = intelligenceGenerator.GenerateFor(item);
                Assert.That(intelligence.Powers, Contains.Item("greater power 1"));
                Assert.That(intelligence.Powers.Count, Is.EqualTo(1));
                Assert.That(intelligence.SpecialPurpose, Is.EqualTo("purpose"));
                Assert.That(intelligence.DedicatedPower, Is.EqualTo("dedicated power"));
            }
        }

        [Test]
        public void TwoGreaterPowerMeans50PercentChanceForGreaterPower()
        {
            intelligenceSelection.GreaterPowersCount = 2;
            mockPercentileSelector.Setup(s => s.SelectFrom(TableNameConstants.Percentiles.Set.IntelligenceSpecialPurposes)).Returns("purpose");
            mockPercentileSelector.Setup(s => s.SelectFrom(TableNameConstants.Percentiles.Set.IntelligenceDedicatedPowers)).Returns("dedicated power");

            for (var roll = 4; roll > 2; roll--)
            {
                var tableName = string.Format(TableNameConstants.Percentiles.Formattable.IntelligencePOWERPowers, "Greater");
                mockPercentileSelector.SetupSequence(s => s.SelectFrom(tableName)).Returns("greater power 1").Returns("greater power 2");
                mockDice.Setup(d => d.Roll(1).d(4).AsSum()).Returns(roll);

                var intelligence = intelligenceGenerator.GenerateFor(item);
                Assert.That(intelligence.Powers, Contains.Item("greater power 1"));
                Assert.That(intelligence.Powers, Contains.Item("greater power 2"));
                Assert.That(intelligence.Powers.Count, Is.EqualTo(2));
                Assert.That(intelligence.SpecialPurpose, Is.Empty);
                Assert.That(intelligence.DedicatedPower, Is.Empty);
            }
        }

        [Test]
        public void ThreeGreaterPowerMeans75PercentChanceForSpecialPurpose()
        {
            intelligenceSelection.GreaterPowersCount = 3;
            mockPercentileSelector.Setup(s => s.SelectFrom(TableNameConstants.Percentiles.Set.IntelligenceSpecialPurposes)).Returns("purpose");
            mockPercentileSelector.Setup(s => s.SelectFrom(TableNameConstants.Percentiles.Set.IntelligenceDedicatedPowers)).Returns("dedicated power");

            for (var roll = 3; roll > 0; roll--)
            {
                var tableName = string.Format(TableNameConstants.Percentiles.Formattable.IntelligencePOWERPowers, "Greater");
                mockPercentileSelector.SetupSequence(s => s.SelectFrom(tableName))
                    .Returns("greater power 1").Returns("greater power 2").Returns("greater power 3");

                mockDice.Setup(d => d.Roll(1).d(4).AsSum()).Returns(roll);

                var intelligence = intelligenceGenerator.GenerateFor(item);
                Assert.That(intelligence.Powers, Contains.Item("greater power 1"));
                Assert.That(intelligence.Powers, Contains.Item("greater power 2"));
                Assert.That(intelligence.Powers.Count, Is.EqualTo(2));
                Assert.That(intelligence.SpecialPurpose, Is.EqualTo("purpose"));
                Assert.That(intelligence.DedicatedPower, Is.EqualTo("dedicated power"));
            }
        }

        [Test]
        public void ThreeGreaterPowerMeans25PercentChanceForGreaterPower()
        {
            intelligenceSelection.GreaterPowersCount = 3;
            mockPercentileSelector.Setup(s => s.SelectFrom(TableNameConstants.Percentiles.Set.IntelligenceSpecialPurposes)).Returns("purpose");
            mockPercentileSelector.Setup(s => s.SelectFrom(TableNameConstants.Percentiles.Set.IntelligenceDedicatedPowers)).Returns("dedicated power");

            for (var roll = 4; roll > 3; roll--)
            {
                var tableName = string.Format(TableNameConstants.Percentiles.Formattable.IntelligencePOWERPowers, "Greater");
                mockPercentileSelector.SetupSequence(s => s.SelectFrom(tableName))
                    .Returns("greater power 1").Returns("greater power 2").Returns("greater power 3");

                mockDice.Setup(d => d.Roll(1).d(4).AsSum()).Returns(roll);

                var intelligence = intelligenceGenerator.GenerateFor(item);
                Assert.That(intelligence.Powers, Contains.Item("greater power 1"));
                Assert.That(intelligence.Powers, Contains.Item("greater power 2"));
                Assert.That(intelligence.Powers, Contains.Item("greater power 3"));
                Assert.That(intelligence.Powers.Count, Is.EqualTo(3));
                Assert.That(intelligence.SpecialPurpose, Is.Empty);
                Assert.That(intelligence.DedicatedPower, Is.Empty);
            }
        }

        [Test]
        public void GetAlignmentFromPercentileSelector()
        {
            mockPercentileSelector.Setup(s => s.SelectFrom(TableNameConstants.Percentiles.Set.IntelligenceAlignments)).Returns("alignment");

            var intelligence = intelligenceGenerator.GenerateFor(item);
            Assert.That(intelligence.Alignment, Is.EqualTo("alignment"));
        }

        [TestCase(AlignmentConstants.Chaotic)]
        public void NonAxiomaticAlignments(string alignment)
        {
            var ability = new SpecialAbility { Name = SpecialAbilityConstants.Axiomatic };
            item.Magic.SpecialAbilities = new[] { ability };
            mockPercentileSelector.SetupSequence(s => s.SelectFrom(TableNameConstants.Percentiles.Set.IntelligenceAlignments))
                .Returns(alignment + " alignment").Returns("alignment");

            var intelligence = intelligenceGenerator.GenerateFor(item);
            Assert.That(intelligence.Alignment, Is.EqualTo("alignment"));
        }

        [TestCase(AlignmentConstants.Neutral)]
        [TestCase(AlignmentConstants.Lawful)]
        [TestCase("True")]
        public void AxiomaticAlignments(string alignment)
        {
            var ability = new SpecialAbility { Name = SpecialAbilityConstants.Axiomatic };
            item.Magic.SpecialAbilities = new[] { ability };
            mockPercentileSelector.SetupSequence(s => s.SelectFrom(TableNameConstants.Percentiles.Set.IntelligenceAlignments))
                .Returns(alignment + " alignment").Returns("alignment");

            var intelligence = intelligenceGenerator.GenerateFor(item);
            Assert.That(intelligence.Alignment, Is.EqualTo(alignment + " alignment"));
        }

        [TestCase(AlignmentConstants.Lawful)]
        public void NonAnarchicAlignments(string alignment)
        {
            var ability = new SpecialAbility { Name = SpecialAbilityConstants.Anarchic };
            item.Magic.SpecialAbilities = new[] { ability };
            mockPercentileSelector.SetupSequence(s => s.SelectFrom(TableNameConstants.Percentiles.Set.IntelligenceAlignments))
                .Returns(alignment + " alignment").Returns("alignment");

            var intelligence = intelligenceGenerator.GenerateFor(item);
            Assert.That(intelligence.Alignment, Is.EqualTo("alignment"));
        }

        [TestCase(AlignmentConstants.Neutral)]
        [TestCase(AlignmentConstants.Chaotic)]
        [TestCase("True")]
        public void AnarchicAlignments(string alignment)
        {
            var ability = new SpecialAbility { Name = SpecialAbilityConstants.Anarchic };
            item.Magic.SpecialAbilities = new[] { ability };
            mockPercentileSelector.SetupSequence(s => s.SelectFrom(TableNameConstants.Percentiles.Set.IntelligenceAlignments))
                .Returns(alignment + " alignment").Returns("alignment");

            var intelligence = intelligenceGenerator.GenerateFor(item);
            Assert.That(intelligence.Alignment, Is.EqualTo(alignment + " alignment"));
        }

        [TestCase(AlignmentConstants.Evil)]
        public void NonHolyAlignments(string alignment)
        {
            var ability = new SpecialAbility { Name = SpecialAbilityConstants.Holy };
            item.Magic.SpecialAbilities = new[] { ability };
            mockPercentileSelector.SetupSequence(s => s.SelectFrom(TableNameConstants.Percentiles.Set.IntelligenceAlignments))
                .Returns("alignment " + alignment).Returns("alignment");

            var intelligence = intelligenceGenerator.GenerateFor(item);
            Assert.That(intelligence.Alignment, Is.EqualTo("alignment"));
        }

        [TestCase(AlignmentConstants.Neutral)]
        [TestCase(AlignmentConstants.Good)]
        public void HolyAlignments(string alignment)
        {
            var ability = new SpecialAbility { Name = SpecialAbilityConstants.Holy };
            item.Magic.SpecialAbilities = new[] { ability };
            mockPercentileSelector.SetupSequence(s => s.SelectFrom(TableNameConstants.Percentiles.Set.IntelligenceAlignments))
                .Returns("alignment " + alignment).Returns("alignment");

            var intelligence = intelligenceGenerator.GenerateFor(item);
            Assert.That(intelligence.Alignment, Is.EqualTo("alignment " + alignment));
        }

        [TestCase(AlignmentConstants.Good)]
        public void NonUnholyAlignments(string alignment)
        {
            var ability = new SpecialAbility { Name = SpecialAbilityConstants.Unholy };
            item.Magic.SpecialAbilities = new[] { ability };
            mockPercentileSelector.SetupSequence(s => s.SelectFrom(TableNameConstants.Percentiles.Set.IntelligenceAlignments))
                .Returns("alignment " + alignment).Returns("alignment");

            var intelligence = intelligenceGenerator.GenerateFor(item);
            Assert.That(intelligence.Alignment, Is.EqualTo("alignment"));
        }

        [TestCase(AlignmentConstants.Neutral)]
        [TestCase(AlignmentConstants.Evil)]
        public void UnholyAlignments(string alignment)
        {
            var ability = new SpecialAbility { Name = SpecialAbilityConstants.Unholy };
            item.Magic.SpecialAbilities = new[] { ability };
            mockPercentileSelector.SetupSequence(s => s.SelectFrom(TableNameConstants.Percentiles.Set.IntelligenceAlignments))
                .Returns("alignment " + alignment).Returns("alignment");

            var intelligence = intelligenceGenerator.GenerateFor(item);
            Assert.That(intelligence.Alignment, Is.EqualTo("alignment " + alignment));
        }

        [Test]
        public void ItemWithSpecificAlignmentHasMatchingAlignment()
        {
            item.Name = "item name";
            mockCollectionsSelector.Setup(s => s.SelectFrom(TableNameConstants.Collections.Set.ItemAlignmentRequirements, "Items"))
                .Returns(new[] { item.Name, "other item name" });
            var alignment = "specific alignment";
            mockCollectionsSelector.Setup(s => s.SelectFrom(TableNameConstants.Collections.Set.ItemAlignmentRequirements, item.Name)).Returns(new[] { alignment });
            mockPercentileSelector.SetupSequence(s => s.SelectFrom(TableNameConstants.Percentiles.Set.IntelligenceAlignments))
                .Returns("alignment").Returns(alignment);

            var intelligence = intelligenceGenerator.GenerateFor(item);
            Assert.That(intelligence.Alignment, Is.EqualTo(alignment));
        }

        [Test]
        public void ItemWithNoSpecificAlignmentHasAnyAlignment()
        {
            item.Name = "item name";
            mockCollectionsSelector.Setup(s => s.SelectFrom(TableNameConstants.Collections.Set.ItemAlignmentRequirements, "Items")).Returns(new[] { "other item name" });
            mockCollectionsSelector.Setup(s => s.SelectFrom(TableNameConstants.Collections.Set.ItemAlignmentRequirements, item.Name)).Returns(new[] { "specific" });
            mockPercentileSelector.SetupSequence(s => s.SelectFrom(TableNameConstants.Percentiles.Set.IntelligenceAlignments))
                .Returns("alignment").Returns("specific alignment");

            var intelligence = intelligenceGenerator.GenerateFor(item);
            Assert.That(intelligence.Alignment, Is.EqualTo("alignment"));
        }

        [Test]
        public void ItemWithSpecificAlignmentBeginningHasMatchingAlignment()
        {
            item.Name = "item name";
            mockCollectionsSelector.Setup(s => s.SelectFrom(TableNameConstants.Collections.Set.ItemAlignmentRequirements, "Items"))
                .Returns(new[] { item.Name, "other item name" });
            var alignment = "specific";
            mockCollectionsSelector.Setup(s => s.SelectFrom(TableNameConstants.Collections.Set.ItemAlignmentRequirements, item.Name)).Returns(new[] { alignment });
            mockPercentileSelector.SetupSequence(s => s.SelectFrom(TableNameConstants.Percentiles.Set.IntelligenceAlignments))
                .Returns("alignment").Returns("specific alignment");

            var intelligence = intelligenceGenerator.GenerateFor(item);
            Assert.That(intelligence.Alignment, Is.EqualTo("specific alignment"));
        }

        [Test]
        public void ItemWithSpecificAlignmentEndingHasMatchingAlignment()
        {
            item.Name = "item name";
            mockCollectionsSelector.Setup(s => s.SelectFrom(TableNameConstants.Collections.Set.ItemAlignmentRequirements, "Items"))
                .Returns(new[] { item.Name, "other item name" });
            var alignment = "ending";
            mockCollectionsSelector.Setup(s => s.SelectFrom(TableNameConstants.Collections.Set.ItemAlignmentRequirements, item.Name)).Returns(new[] { alignment });
            mockPercentileSelector.SetupSequence(s => s.SelectFrom(TableNameConstants.Percentiles.Set.IntelligenceAlignments))
                .Returns("alignment").Returns("specific alignment ending");

            var intelligence = intelligenceGenerator.GenerateFor(item);
            Assert.That(intelligence.Alignment, Is.EqualTo("specific alignment ending"));
        }

        [Test]
        public void ItemWithPartOfAlignmentAsTraitUsesThatAsAlignmentRequirement()
        {
            item.Traits.Add(AlignmentConstants.Good);
            mockPercentileSelector.SetupSequence(s => s.SelectFrom(TableNameConstants.Percentiles.Set.IntelligenceAlignments))
                .Returns("alignment Evil").Returns("alignment Good");

            var intelligence = intelligenceGenerator.GenerateFor(item);
            Assert.That(intelligence.Alignment, Is.EqualTo("alignment Good"));
        }

        [Test]
        public void ItemWithPartOfAlignmentAsPartOfTraitUsesThatAsAlignmentRequirement()
        {
            var trait = string.Format("trait ({0})", AlignmentConstants.Good);
            item.Traits.Add(trait);
            mockPercentileSelector.SetupSequence(s => s.SelectFrom(TableNameConstants.Percentiles.Set.IntelligenceAlignments))
                .Returns("alignment Evil").Returns("alignment Good");

            var intelligence = intelligenceGenerator.GenerateFor(item);
            Assert.That(intelligence.Alignment, Is.EqualTo("alignment Good"));
        }

        [Test]
        public void ItemWithAlignmentAsTraitUsesThatAsAlignmentRequirement()
        {
            item.Traits.Add(AlignmentConstants.ChaoticNeutral);
            mockPercentileSelector.SetupSequence(s => s.SelectFrom(TableNameConstants.Percentiles.Set.IntelligenceAlignments))
                .Returns("alignment").Returns(AlignmentConstants.ChaoticNeutral);

            var intelligence = intelligenceGenerator.GenerateFor(item);
            Assert.That(intelligence.Alignment, Is.EqualTo(AlignmentConstants.ChaoticNeutral));
        }

        [Test]
        public void ItemWithAlignmentAsPartOfTraitUsesThatAsAlignmentRequirement()
        {
            var trait = string.Format("trait ({0})", AlignmentConstants.ChaoticNeutral);
            item.Traits.Add(trait);
            mockPercentileSelector.SetupSequence(s => s.SelectFrom(TableNameConstants.Percentiles.Set.IntelligenceAlignments))
                .Returns("alignment").Returns(AlignmentConstants.ChaoticNeutral);

            var intelligence = intelligenceGenerator.GenerateFor(item);
            Assert.That(intelligence.Alignment, Is.EqualTo(AlignmentConstants.ChaoticNeutral));
        }

        [Test]
        public void OnlyAlignmentsEndingInNeutralMatchNeutralRequirement()
        {
            item.Traits.Add(AlignmentConstants.Neutral);
            mockPercentileSelector.SetupSequence(s => s.SelectFrom(TableNameConstants.Percentiles.Set.IntelligenceAlignments))
                .Returns(AlignmentConstants.NeutralEvil).Returns(AlignmentConstants.ChaoticNeutral);

            var intelligence = intelligenceGenerator.GenerateFor(item);
            Assert.That(intelligence.Alignment, Is.EqualTo(AlignmentConstants.ChaoticNeutral));
        }

        [Test]
        public void TrueNeutralSatisfiesAllRequirements()
        {
            item.Magic.SpecialAbilities = new[]
            {
                new SpecialAbility { Name = SpecialAbilityConstants.Unholy },
                new SpecialAbility { Name = SpecialAbilityConstants.Holy },
                new SpecialAbility { Name = SpecialAbilityConstants.Axiomatic },
                new SpecialAbility { Name = SpecialAbilityConstants.Anarchic }
            };

            item.Traits.Add(AlignmentConstants.ChaoticEvil);
            item.Traits.Add($"trait ({AlignmentConstants.Good})");

            mockCollectionsSelector.Setup(s => s.SelectFrom(TableNameConstants.Collections.Set.ItemAlignmentRequirements, item.Name)).Returns(new[] { "specific" });
            mockPercentileSelector.SetupSequence(s => s.SelectFrom(TableNameConstants.Percentiles.Set.IntelligenceAlignments))
                .Returns(AlignmentConstants.ChaoticEvil)
                .Returns(AlignmentConstants.ChaoticGood)
                .Returns(AlignmentConstants.ChaoticNeutral)
                .Returns(AlignmentConstants.LawfulEvil)
                .Returns(AlignmentConstants.LawfulGood)
                .Returns(AlignmentConstants.LawfulNeutral)
                .Returns(AlignmentConstants.NeutralEvil)
                .Returns(AlignmentConstants.NeutralGood)
                .Returns(AlignmentConstants.TrueNeutral);

            var intelligence = intelligenceGenerator.GenerateFor(item);
            Assert.That(intelligence.Alignment, Is.EqualTo(AlignmentConstants.TrueNeutral));
        }

        [Test]
        public void EgoIncludesMagicBonus()
        {
            item.Magic.Bonus = 9266;

            var intelligence = intelligenceGenerator.GenerateFor(item);
            Assert.That(intelligence.Ego, Is.EqualTo(9266));
        }

        [Test]
        public void EgoIncludesSpecialAbilityBonuses()
        {
            item.Magic.SpecialAbilities = new[]
            {
                new SpecialAbility { BonusEquivalent = 9200 },
                new SpecialAbility { BonusEquivalent = 66 }
            };

            var intelligence = intelligenceGenerator.GenerateFor(item);
            Assert.That(intelligence.Ego, Is.EqualTo(9266));
        }

        [Test]
        public void EgoIncludesLesserPowers()
        {
            intelligenceSelection.LesserPowersCount = 2;
            var tableName = string.Format(TableNameConstants.Percentiles.Formattable.IntelligencePOWERPowers, "Lesser");
            mockPercentileSelector.SetupSequence(s => s.SelectFrom(tableName)).Returns("power 1").Returns("power 2");

            var intelligence = intelligenceGenerator.GenerateFor(item);
            Assert.That(intelligence.Ego, Is.EqualTo(2));
        }

        [Test]
        public void EgoIncludesGreaterPowers()
        {
            intelligenceSelection.GreaterPowersCount = 2;
            var tableName = string.Format(TableNameConstants.Percentiles.Formattable.IntelligencePOWERPowers, "Greater");
            mockPercentileSelector.SetupSequence(s => s.SelectFrom(tableName)).Returns("greater power 1").Returns("greater power 2");

            var intelligence = intelligenceGenerator.GenerateFor(item);
            Assert.That(intelligence.Ego, Is.EqualTo(4));
        }

        [Test]
        public void EgoIncludesDedicatedPower()
        {
            intelligenceSelection.GreaterPowersCount = 1;
            var tableName = string.Format(TableNameConstants.Percentiles.Formattable.IntelligencePOWERPowers, "Greater");
            mockPercentileSelector.Setup(s => s.SelectFrom(tableName)).Returns("greater power");
            mockDice.Setup(d => d.Roll(1).d(4).AsSum()).Returns(1);
            mockPercentileSelector.Setup(s => s.SelectFrom(TableNameConstants.Percentiles.Set.IntelligenceSpecialPurposes)).Returns("purpose");
            mockPercentileSelector.Setup(s => s.SelectFrom(TableNameConstants.Percentiles.Set.IntelligenceDedicatedPowers)).Returns("dedicated power");

            var intelligence = intelligenceGenerator.GenerateFor(item);
            Assert.That(intelligence.Ego, Is.EqualTo(4));
        }

        [Test]
        public void EgoIncludesTelepathy()
        {
            var attributes = new[] { "Telepathy" };
            mockCollectionsSelector.Setup(s => s.SelectFrom(TableNameConstants.Collections.Set.IntelligenceCommunication, "10")).Returns(attributes);

            var intelligence = intelligenceGenerator.GenerateFor(item);
            Assert.That(intelligence.Ego, Is.EqualTo(1));
        }

        [Test]
        public void EgoIncludesReading()
        {
            var attributes = new[] { "Read" };
            mockCollectionsSelector.Setup(s => s.SelectFrom(TableNameConstants.Collections.Set.IntelligenceCommunication, "10")).Returns(attributes);

            var intelligence = intelligenceGenerator.GenerateFor(item);
            Assert.That(intelligence.Ego, Is.EqualTo(1));
        }

        [Test]
        public void EgoIncludesReadMagic()
        {
            var attributes = new[] { "Read magic" };
            mockCollectionsSelector.Setup(s => s.SelectFrom(TableNameConstants.Collections.Set.IntelligenceCommunication, "10")).Returns(attributes);

            var intelligence = intelligenceGenerator.GenerateFor(item);
            Assert.That(intelligence.Ego, Is.EqualTo(1));
        }

        [TestCase(10, 0)]
        [TestCase(11, 0)]
        [TestCase(12, 2)]
        [TestCase(13, 2)]
        [TestCase(14, 4)]
        [TestCase(15, 4)]
        [TestCase(16, 6)]
        [TestCase(17, 6)]
        [TestCase(18, 8)]
        [TestCase(19, 8)]
        [TestCase(20, 10)]
        public void EgoIncludesStatBonuses(int strongStat, int egoBonus)
        {
            mockPercentileSelector.Setup(s => s.SelectFrom(TableNameConstants.Percentiles.Set.IntelligenceStrongStats)).Returns(strongStat.ToString());
            var intelligence = intelligenceGenerator.GenerateFor(item);
            Assert.That(intelligence.Ego, Is.EqualTo(egoBonus));
        }

        [Test]
        public void EgoSumsAllFactors()
        {
            var communication = new[] { "Read", "Read magic", "Telepathy" };
            mockPercentileSelector.Setup(s => s.SelectFrom(TableNameConstants.Percentiles.Set.IntelligenceStrongStats)).Returns("19");
            mockCollectionsSelector.Setup(s => s.SelectFrom(TableNameConstants.Collections.Set.IntelligenceCommunication, "19")).Returns(communication);
            intelligenceSelection.LesserPowersCount = 2;
            intelligenceSelection.GreaterPowersCount = 2;

            var tableName = string.Format(TableNameConstants.Percentiles.Formattable.IntelligencePOWERPowers, "Greater");
            mockPercentileSelector.SetupSequence(s => s.SelectFrom(tableName)).Returns("greater power 1").Returns("greater power 2");
            mockDice.Setup(d => d.Roll(1).d(4).AsSum()).Returns(1);
            mockPercentileSelector.Setup(s => s.SelectFrom(TableNameConstants.Percentiles.Set.IntelligenceSpecialPurposes)).Returns("purpose");
            mockPercentileSelector.Setup(s => s.SelectFrom(TableNameConstants.Percentiles.Set.IntelligenceDedicatedPowers)).Returns("dedicated power");

            tableName = string.Format(TableNameConstants.Percentiles.Formattable.IntelligencePOWERPowers, "Lesser");
            mockPercentileSelector.SetupSequence(s => s.SelectFrom(tableName)).Returns("power 1").Returns("power 2");

            var ability = new SpecialAbility();
            ability.BonusEquivalent = 92;
            item.Magic.SpecialAbilities = new[] { ability };
            item.Magic.Bonus = 66;

            var intelligence = intelligenceGenerator.GenerateFor(item);
            Assert.That(intelligence.Ego, Is.EqualTo(177));
        }

        [Test]
        public void IntelligenceHasPersonality()
        {
            mockPercentileSelector.Setup(s => s.SelectFrom(TableNameConstants.Percentiles.Set.PersonalityTraits)).Returns("personality");
            var intelligence = intelligenceGenerator.GenerateFor(item);
            Assert.That(intelligence.Personality, Is.EqualTo("personality"));
        }
    }
}