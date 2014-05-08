using System;
using System.Collections.Generic;
using D20Dice;
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
    public class IntelligenceGeneratorTests
    {
        private IIntelligenceGenerator intelligenceGenerator;
        private Mock<IDice> mockDice;
        private Mock<IPercentileSelector> mockPercentileSelector;
        private Mock<IAttributesSelector> mockAttributesSelector;
        private Mock<IIntelligenceAttributesSelector> mockIntelligenceAttributesSelector;
        private Mock<IBooleanPercentileSelector> mockBooleanPercentileSelector;
        private List<String> attributes;
        private Magic magic;
        private IntelligenceAttributesResult intelligenceAttributesResult;

        [SetUp]
        public void Setup()
        {
            mockDice = new Mock<IDice>();
            mockPercentileSelector = new Mock<IPercentileSelector>();
            mockAttributesSelector = new Mock<IAttributesSelector>();
            mockIntelligenceAttributesSelector = new Mock<IIntelligenceAttributesSelector>();
            mockBooleanPercentileSelector = new Mock<IBooleanPercentileSelector>();
            intelligenceAttributesResult = new IntelligenceAttributesResult();
            attributes = new List<String>();
            magic = new Magic();

            var fillerValues = new[] { "0" };
            mockAttributesSelector.Setup(s => s.SelectFrom(It.IsAny<String>(), It.IsAny<String>())).Returns(fillerValues);
            mockDice.Setup(d => d.d4(1)).Returns(4);
            mockPercentileSelector.Setup(s => s.SelectFrom("IntelligenceStrongStats", It.IsAny<Int32>())).Returns("10");
            mockIntelligenceAttributesSelector.Setup(s => s.SelectFrom("IntelligenceAttributes", It.IsAny<String>())).Returns(intelligenceAttributesResult);

            intelligenceGenerator = new IntelligenceGenerator(mockDice.Object, mockPercentileSelector.Object,
                mockAttributesSelector.Object, mockIntelligenceAttributesSelector.Object, mockBooleanPercentileSelector.Object);
        }

        [Test]
        public void GetIntelligentFromBooleanSelector()
        {
            mockBooleanPercentileSelector.Setup(s => s.SelectFrom("Isitem typeIntelligent", It.IsAny<Int32>())).Returns(true);
            var isIntelligent = intelligenceGenerator.IsIntelligent("item type", attributes, true);
            Assert.That(isIntelligent, Is.True);
        }

        [Test]
        public void GetNotIntelligentFromBooleanSelector()
        {
            mockBooleanPercentileSelector.Setup(s => s.SelectFrom("Isitem typeIntelligent", It.IsAny<Int32>())).Returns(false);
            var isIntelligent = intelligenceGenerator.IsIntelligent("item type", attributes, true);
            Assert.That(isIntelligent, Is.False);
        }

        [Test]
        public void IfWeapon_GetMelee()
        {
            attributes.Add(AttributeConstants.Melee);
            mockBooleanPercentileSelector.Setup(s => s.SelectFrom("IsMeleeWeaponIntelligent", It.IsAny<Int32>())).Returns(true);
            var isIntelligent = intelligenceGenerator.IsIntelligent(ItemTypeConstants.Weapon, attributes, true);
            Assert.That(isIntelligent, Is.True);
        }

        [Test]
        public void IfWeapon_ThrowIfNotMeleeOrRanged()
        {
            mockBooleanPercentileSelector.Setup(s => s.SelectFrom("IsMeleeWeaponIntelligent", It.IsAny<Int32>())).Returns(true);
            Assert.That(() => intelligenceGenerator.IsIntelligent(ItemTypeConstants.Weapon, attributes, true), Throws.ArgumentException);
        }

        [Test]
        public void IfWeapon_GetRanged()
        {
            attributes.Add(AttributeConstants.Ranged);
            mockBooleanPercentileSelector.Setup(s => s.SelectFrom("IsRangedWeaponIntelligent", It.IsAny<Int32>())).Returns(true);
            var isIntelligent = intelligenceGenerator.IsIntelligent(ItemTypeConstants.Weapon, attributes, true);
            Assert.That(isIntelligent, Is.True);
        }

        [Test]
        public void IfWeaponBothMeleeAndRanged_GetMelee()
        {
            attributes.Add(AttributeConstants.Melee);
            attributes.Add(AttributeConstants.Ranged);
            mockBooleanPercentileSelector.Setup(s => s.SelectFrom("IsMeleeWeaponIntelligent", It.IsAny<Int32>())).Returns(true);
            var isIntelligent = intelligenceGenerator.IsIntelligent(ItemTypeConstants.Weapon, attributes, true);
            Assert.That(isIntelligent, Is.True);
        }

        [Test]
        public void AmmunitionIsNotIntelligent()
        {
            attributes.Add(AttributeConstants.Ammunition);

            var isIntelligent = intelligenceGenerator.IsIntelligent(AttributeConstants.Melee, attributes, true);
            Assert.That(isIntelligent, Is.False);
        }

        [Test]
        public void OneTimeUseItemsAreNotIntelligent()
        {
            attributes.Add(AttributeConstants.OneTimeUse);

            var isIntelligent = intelligenceGenerator.IsIntelligent(AttributeConstants.Melee, attributes, true);
            Assert.That(isIntelligent, Is.False);
        }

        [Test]
        public void NonMagicalItemsAreNotIntelligent()
        {
            var isIntelligent = intelligenceGenerator.IsIntelligent(AttributeConstants.Melee, attributes, false);
            Assert.That(isIntelligent, Is.False);
        }

        [Test]
        public void ReturnIntelligence()
        {
            var intelligence = intelligenceGenerator.GenerateFor(magic);
            Assert.That(intelligence, Is.Not.Null);
        }

        [Test]
        public void Roll1MeansCharismaIsWeakStat()
        {
            mockDice.Setup(d => d.Percentile(1)).Returns(9266);
            mockDice.Setup(d => d.d3(1)).Returns(1);
            mockPercentileSelector.Setup(s => s.SelectFrom("IntelligenceStrongStats", 9266)).Returns("42");

            var intelligence = intelligenceGenerator.GenerateFor(magic);
            Assert.That(intelligence.CharismaStat, Is.EqualTo(10));
            Assert.That(intelligence.IntelligenceStat, Is.EqualTo(42));
            Assert.That(intelligence.WisdomStat, Is.EqualTo(42));
        }

        [Test]
        public void Roll2MeansIntelligenceIsWeakStat()
        {
            mockDice.Setup(d => d.Percentile(1)).Returns(9266);
            mockDice.Setup(d => d.d3(1)).Returns(2);
            mockPercentileSelector.Setup(s => s.SelectFrom("IntelligenceStrongStats", 9266)).Returns("42");

            var intelligence = intelligenceGenerator.GenerateFor(magic);
            Assert.That(intelligence.CharismaStat, Is.EqualTo(42));
            Assert.That(intelligence.IntelligenceStat, Is.EqualTo(10));
            Assert.That(intelligence.WisdomStat, Is.EqualTo(42));
        }

        [Test]
        public void Roll3MeansWisdomIsWeakStat()
        {
            mockDice.Setup(d => d.Percentile(1)).Returns(9266);
            mockDice.Setup(d => d.d3(1)).Returns(3);
            mockPercentileSelector.Setup(s => s.SelectFrom("IntelligenceStrongStats", 9266)).Returns("42");

            var intelligence = intelligenceGenerator.GenerateFor(magic);
            Assert.That(intelligence.CharismaStat, Is.EqualTo(42));
            Assert.That(intelligence.IntelligenceStat, Is.EqualTo(42));
            Assert.That(intelligence.WisdomStat, Is.EqualTo(10));
        }

        [Test]
        public void GetCommunicationFromAttributesSelector()
        {
            var attributes = new[] { "talky" };
            mockPercentileSelector.Setup(s => s.SelectFrom("IntelligenceStrongStats", It.IsAny<Int32>())).Returns("9266");
            mockAttributesSelector.Setup(s => s.SelectFrom("IntelligenceCommunication", "9266")).Returns(attributes);

            var intelligence = intelligenceGenerator.GenerateFor(magic);
            Assert.That(intelligence.Communication, Is.EqualTo(attributes));
        }

        [Test]
        public void GetLanguagesIfSpeech()
        {
            var attributes = new[] { "Speech" };
            mockPercentileSelector.Setup(s => s.SelectFrom("IntelligenceStrongStats", It.IsAny<Int32>())).Returns("10");
            mockAttributesSelector.Setup(s => s.SelectFrom("IntelligenceCommunication", "10")).Returns(attributes);

            var intelligence = intelligenceGenerator.GenerateFor(magic);
            Assert.That(intelligence.Languages, Contains.Item("Common"));
        }

        [Test]
        public void GetNumberOfLanguagesEqualToIntelligenceModifier()
        {
            var attributes = new[] { "Speech" };
            mockPercentileSelector.Setup(s => s.SelectFrom("IntelligenceStrongStats", It.IsAny<Int32>())).Returns("14");
            mockAttributesSelector.Setup(s => s.SelectFrom("IntelligenceCommunication", "14")).Returns(attributes);
            mockPercentileSelector.SetupSequence(s => s.SelectFrom("Languages", It.IsAny<Int32>())).Returns("english")
                .Returns("german");

            var intelligence = intelligenceGenerator.GenerateFor(magic);
            Assert.That(intelligence.Languages, Contains.Item("Common"));
            Assert.That(intelligence.Languages, Contains.Item("english"));
            Assert.That(intelligence.Languages, Contains.Item("german"));
            Assert.That(intelligence.Languages.Count, Is.EqualTo(3));
        }

        [Test]
        public void DoNotHaveDuplicateLanguages()
        {
            var attributes = new[] { "Speech" };
            mockPercentileSelector.Setup(s => s.SelectFrom("IntelligenceStrongStats", It.IsAny<Int32>())).Returns("14");
            mockAttributesSelector.Setup(s => s.SelectFrom("IntelligenceCommunication", "14")).Returns(attributes);
            mockPercentileSelector.SetupSequence(s => s.SelectFrom("Languages", It.IsAny<Int32>())).Returns("english")
                .Returns("english").Returns("german");

            var intelligence = intelligenceGenerator.GenerateFor(magic);
            Assert.That(intelligence.Languages, Contains.Item("Common"));
            Assert.That(intelligence.Languages, Contains.Item("english"));
            Assert.That(intelligence.Languages, Contains.Item("german"));
            Assert.That(intelligence.Languages.Count, Is.EqualTo(3));
        }

        [Test]
        public void GetSensesFromAttributesSelector()
        {
            intelligenceAttributesResult.Senses = "sensy";
            var intelligence = intelligenceGenerator.GenerateFor(magic);
            Assert.That(intelligence.Senses, Is.EqualTo(intelligenceAttributesResult.Senses));
        }

        [Test]
        public void GetLesserPowersFromAttributesSelector()
        {
            intelligenceAttributesResult.LesserPowersCount = 2;
            mockPercentileSelector.SetupSequence(s => s.SelectFrom("IntelligenceLesserPowers", It.IsAny<Int32>()))
                .Returns("power 1").Returns("power 2");

            var intelligence = intelligenceGenerator.GenerateFor(magic);
            Assert.That(intelligence.Powers.Count, Is.EqualTo(2));
        }

        [Test]
        public void CannotHaveDuplicateLesserPowers()
        {
            intelligenceAttributesResult.LesserPowersCount = 2;
            mockPercentileSelector.SetupSequence(s => s.SelectFrom("IntelligenceLesserPowers", It.IsAny<Int32>()))
                .Returns("power 1").Returns("power 1").Returns("power 2");

            var intelligence = intelligenceGenerator.GenerateFor(magic);
            Assert.That(intelligence.Powers, Contains.Item("power 1"));
            Assert.That(intelligence.Powers, Contains.Item("power 2"));
            Assert.That(intelligence.Powers.Count, Is.EqualTo(2));
        }

        [Test]
        public void GetGreaterPowersFromAttributesSelector()
        {
            intelligenceAttributesResult.GreaterPowersCount = 2;
            mockPercentileSelector.SetupSequence(s => s.SelectFrom("IntelligenceGreaterPowers", It.IsAny<Int32>()))
                .Returns("power 1").Returns("power 2");

            var intelligence = intelligenceGenerator.GenerateFor(magic);
            Assert.That(intelligence.Powers.Count, Is.EqualTo(2));
        }

        [Test]
        public void CannotHaveDuplicateGreaterPowers()
        {
            intelligenceAttributesResult.GreaterPowersCount = 2;
            mockPercentileSelector.SetupSequence(s => s.SelectFrom("IntelligenceGreaterPowers", It.IsAny<Int32>()))
                .Returns("power 1").Returns("power 1").Returns("power 2");

            var intelligence = intelligenceGenerator.GenerateFor(magic);
            Assert.That(intelligence.Powers, Contains.Item("power 1"));
            Assert.That(intelligence.Powers, Contains.Item("power 2"));
            Assert.That(intelligence.Powers.Count, Is.EqualTo(2));
        }

        [Test]
        public void OneGreaterPowerMeans25PercentChanceForSpecialPurpose()
        {
            intelligenceAttributesResult.GreaterPowersCount = 1;
            mockPercentileSelector.Setup(s => s.SelectFrom("IntelligenceGreaterPowers", It.IsAny<Int32>())).Returns("greater power");
            mockDice.Setup(d => d.d4(1)).Returns(1);
            mockPercentileSelector.Setup(s => s.SelectFrom("IntelligenceSpecialPurposes", It.IsAny<Int32>())).Returns("purpose");
            mockPercentileSelector.Setup(s => s.SelectFrom("IntelligenceDedicatedPowers", It.IsAny<Int32>()))
                .Returns("dedicated power");

            var intelligence = intelligenceGenerator.GenerateFor(magic);
            Assert.That(intelligence.Powers, Is.Empty);
            Assert.That(intelligence.SpecialPurpose, Is.EqualTo("purpose"));
            Assert.That(intelligence.DedicatedPower, Is.EqualTo("dedicated power"));
        }

        [Test]
        public void OneGreaterPowerMeans75PercentChanceForGreaterPower()
        {
            intelligenceAttributesResult.GreaterPowersCount = 1;
            mockPercentileSelector.Setup(s => s.SelectFrom("IntelligenceGreaterPowers", It.IsAny<Int32>())).Returns("greater power");
            mockPercentileSelector.Setup(s => s.SelectFrom("IntelligenceSpecialPurposes", It.IsAny<Int32>())).Returns("purpose");
            mockPercentileSelector.Setup(s => s.SelectFrom("IntelligenceDedicatedPowers", It.IsAny<Int32>()))
                .Returns("dedicated power");

            for (var roll = 4; roll > 1; roll--)
            {
                mockDice.Setup(d => d.d4(1)).Returns(roll);

                var intelligence = intelligenceGenerator.GenerateFor(magic);
                Assert.That(intelligence.Powers, Contains.Item("greater power"));
                Assert.That(intelligence.Powers.Count, Is.EqualTo(1));
                Assert.That(intelligence.SpecialPurpose, Is.Empty);
                Assert.That(intelligence.DedicatedPower, Is.Empty);
            }
        }

        [Test]
        public void TwoGreaterPowerMeans50PercentChanceForSpecialPurpose()
        {
            for (var roll = 2; roll > 0; roll--)
            {
                intelligenceAttributesResult.GreaterPowersCount = 2;
                mockPercentileSelector.SetupSequence(s => s.SelectFrom("IntelligenceGreaterPowers", It.IsAny<Int32>()))
                    .Returns("greater power 1").Returns("greater power 2");
                mockPercentileSelector.Setup(s => s.SelectFrom("IntelligenceSpecialPurposes", It.IsAny<Int32>())).Returns("purpose");
                mockPercentileSelector.Setup(s => s.SelectFrom("IntelligenceDedicatedPowers", It.IsAny<Int32>()))
                    .Returns("dedicated power");

                mockDice.Setup(d => d.d4(1)).Returns(roll);

                var intelligence = intelligenceGenerator.GenerateFor(magic);
                Assert.That(intelligence.Powers, Contains.Item("greater power 1"));
                Assert.That(intelligence.Powers.Count, Is.EqualTo(1));
                Assert.That(intelligence.SpecialPurpose, Is.EqualTo("purpose"));
                Assert.That(intelligence.DedicatedPower, Is.EqualTo("dedicated power"));
            }
        }

        [Test]
        public void TwoGreaterPowerMeans50PercentChanceForGreaterPower()
        {
            for (var roll = 4; roll > 2; roll--)
            {
                intelligenceAttributesResult.GreaterPowersCount = 2;
                mockPercentileSelector.SetupSequence(s => s.SelectFrom("IntelligenceGreaterPowers", It.IsAny<Int32>()))
                    .Returns("greater power 1").Returns("greater power 2");
                mockPercentileSelector.Setup(s => s.SelectFrom("IntelligenceSpecialPurposes", It.IsAny<Int32>())).Returns("purpose");
                mockPercentileSelector.Setup(s => s.SelectFrom("IntelligenceDedicatedPowers", It.IsAny<Int32>()))
                    .Returns("dedicated power");

                mockDice.Setup(d => d.d4(1)).Returns(roll);

                var intelligence = intelligenceGenerator.GenerateFor(magic);
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
            for (var roll = 3; roll > 0; roll--)
            {
                intelligenceAttributesResult.GreaterPowersCount = 3;
                mockPercentileSelector.SetupSequence(s => s.SelectFrom("IntelligenceGreaterPowers", It.IsAny<Int32>()))
                    .Returns("greater power 1").Returns("greater power 2").Returns("greater power 3");
                mockPercentileSelector.Setup(s => s.SelectFrom("IntelligenceSpecialPurposes", It.IsAny<Int32>())).Returns("purpose");
                mockPercentileSelector.Setup(s => s.SelectFrom("IntelligenceDedicatedPowers", It.IsAny<Int32>()))
                    .Returns("dedicated power");

                mockDice.Setup(d => d.d4(1)).Returns(roll);

                var intelligence = intelligenceGenerator.GenerateFor(magic);
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
            for (var roll = 4; roll > 3; roll--)
            {
                intelligenceAttributesResult.GreaterPowersCount = 3;
                mockPercentileSelector.SetupSequence(s => s.SelectFrom("IntelligenceGreaterPowers", It.IsAny<Int32>()))
                    .Returns("greater power 1").Returns("greater power 2").Returns("greater power 3");
                mockPercentileSelector.Setup(s => s.SelectFrom("IntelligenceSpecialPurposes", It.IsAny<Int32>())).Returns("purpose");
                mockPercentileSelector.Setup(s => s.SelectFrom("IntelligenceDedicatedPowers", It.IsAny<Int32>()))
                    .Returns("dedicated power");

                mockDice.Setup(d => d.d4(1)).Returns(roll);

                var intelligence = intelligenceGenerator.GenerateFor(magic);
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
            mockPercentileSelector.Setup(s => s.SelectFrom("IntelligenceAlignments", It.IsAny<Int32>())).Returns("alignment");

            var intelligence = intelligenceGenerator.GenerateFor(magic);
            Assert.That(intelligence.Alignment, Is.EqualTo("alignment"));
        }

        [Test]
        public void EgoIncludesMagicBonus()
        {
            magic.Bonus = 9266;

            var intelligence = intelligenceGenerator.GenerateFor(magic);
            Assert.That(intelligence.Ego, Is.EqualTo(9266));
        }

        [Test]
        public void EgoIncludesSpecialAbilityBonuses()
        {
            var ability = new SpecialAbility();
            ability.BonusEquivalent = 9266;
            magic.SpecialAbilities = new[] { ability };

            var intelligence = intelligenceGenerator.GenerateFor(magic);
            Assert.That(intelligence.Ego, Is.EqualTo(9266));
        }

        [Test]
        public void EgoIncludesLesserPowers()
        {
            intelligenceAttributesResult.LesserPowersCount = 2;
            mockPercentileSelector.SetupSequence(s => s.SelectFrom("IntelligenceLesserPowers", It.IsAny<Int32>()))
                .Returns("power 1").Returns("power 2");

            var intelligence = intelligenceGenerator.GenerateFor(magic);
            Assert.That(intelligence.Ego, Is.EqualTo(2));
        }

        [Test]
        public void EgoIncludesGreaterPowers()
        {
            intelligenceAttributesResult.GreaterPowersCount = 2;
            mockPercentileSelector.SetupSequence(s => s.SelectFrom("IntelligenceGreaterPowers", It.IsAny<Int32>()))
                .Returns("greater power 1").Returns("greater power 2");

            var intelligence = intelligenceGenerator.GenerateFor(magic);
            Assert.That(intelligence.Ego, Is.EqualTo(4));
        }

        [Test]
        public void EgoIncludesDedicatedPower()
        {
            intelligenceAttributesResult.GreaterPowersCount = 1;
            mockPercentileSelector.Setup(s => s.SelectFrom("IntelligenceGreaterPowers", It.IsAny<Int32>())).Returns("greater power");
            mockDice.Setup(d => d.d4(1)).Returns(1);
            mockPercentileSelector.Setup(s => s.SelectFrom("IntelligenceSpecialPurposes", It.IsAny<Int32>())).Returns("purpose");
            mockPercentileSelector.Setup(s => s.SelectFrom("IntelligenceDedicatedPowers", It.IsAny<Int32>()))
                .Returns("dedicated power");

            var intelligence = intelligenceGenerator.GenerateFor(magic);
            Assert.That(intelligence.Ego, Is.EqualTo(4));
        }

        [Test]
        public void EgoIncludesTelepathy()
        {
            var attributes = new[] { "Telepathy" };
            mockAttributesSelector.Setup(s => s.SelectFrom("IntelligenceCommunication", "10")).Returns(attributes);

            var intelligence = intelligenceGenerator.GenerateFor(magic);
            Assert.That(intelligence.Ego, Is.EqualTo(1));
        }

        [Test]
        public void EgoIncludesReading()
        {
            var attributes = new[] { "Read" };
            mockAttributesSelector.Setup(s => s.SelectFrom("IntelligenceCommunication", "10")).Returns(attributes);

            var intelligence = intelligenceGenerator.GenerateFor(magic);
            Assert.That(intelligence.Ego, Is.EqualTo(1));
        }

        [Test]
        public void EgoIncludesReadMagic()
        {
            var attributes = new[] { "Read magic" };
            mockAttributesSelector.Setup(s => s.SelectFrom("IntelligenceCommunication", "10")).Returns(attributes);

            var intelligence = intelligenceGenerator.GenerateFor(magic);
            Assert.That(intelligence.Ego, Is.EqualTo(1));
        }

        [Test]
        public void EgoIncludesStatBonuses()
        {
            mockPercentileSelector.Setup(s => s.SelectFrom("IntelligenceStrongStats", It.IsAny<Int32>())).Returns("19");

            var intelligence = intelligenceGenerator.GenerateFor(magic);
            Assert.That(intelligence.Ego, Is.EqualTo(8));
        }

        [Test]
        public void EgoSumsAllFactors()
        {
            var communication = new[] { "Read", "Read magic", "Telepathy" };
            mockPercentileSelector.Setup(s => s.SelectFrom("IntelligenceStrongStats", It.IsAny<Int32>())).Returns("19");
            mockAttributesSelector.Setup(s => s.SelectFrom("IntelligenceCommunication", "19")).Returns(communication);
            intelligenceAttributesResult.LesserPowersCount = 2;
            intelligenceAttributesResult.GreaterPowersCount = 2;
            mockPercentileSelector.SetupSequence(s => s.SelectFrom("IntelligenceGreaterPowers", It.IsAny<Int32>()))
                .Returns("greater power 1").Returns("greater power 2");
            mockDice.Setup(d => d.d4(1)).Returns(1);
            mockPercentileSelector.Setup(s => s.SelectFrom("IntelligenceSpecialPurposes", It.IsAny<Int32>())).Returns("purpose");
            mockPercentileSelector.Setup(s => s.SelectFrom("IntelligenceDedicatedPowers", It.IsAny<Int32>()))
                .Returns("dedicated power");
            mockPercentileSelector.SetupSequence(s => s.SelectFrom("IntelligenceLesserPowers", It.IsAny<Int32>()))
                .Returns("power 1").Returns("power 2");
            var ability = new SpecialAbility();
            ability.BonusEquivalent = 92;
            magic.SpecialAbilities = new[] { ability };
            magic.Bonus = 66;

            var intelligence = intelligenceGenerator.GenerateFor(magic);
            Assert.That(intelligence.Ego, Is.EqualTo(177));
        }

        [Test]
        public void IntelligenceHasPersonality()
        {
            mockPercentileSelector.Setup(s => s.SelectFrom("PersonalityTraits", It.IsAny<Int32>())).Returns("personality");
            var intelligence = intelligenceGenerator.GenerateFor(magic);
            Assert.That(intelligence.Personality, Is.EqualTo("personality"));
        }

        [Test]
        public void ChooseCategoryForRanksInKnowledge()
        {
            intelligenceAttributesResult.LesserPowersCount = 1;
            mockPercentileSelector.Setup(s => s.SelectFrom("IntelligenceLesserPowers", It.IsAny<Int32>()))
                .Returns("this ability has Knowledge");
            mockPercentileSelector.Setup(s => s.SelectFrom("KnowledgeCategories", It.IsAny<Int32>())).Returns("category");

            var intelligence = intelligenceGenerator.GenerateFor(magic);
            Assert.That(intelligence.Powers, Contains.Item("this ability has Knowledge (category)"));
        }

        [Test]
        public void CanHaveRanksInDifferentKnowledge()
        {
            intelligenceAttributesResult.LesserPowersCount = 2;
            mockPercentileSelector.Setup(s => s.SelectFrom("IntelligenceLesserPowers", It.IsAny<Int32>()))
                .Returns("this ability has Knowledge");
            mockPercentileSelector.SetupSequence(s => s.SelectFrom("KnowledgeCategories", It.IsAny<Int32>())).Returns("category")
                .Returns("other category");

            var intelligence = intelligenceGenerator.GenerateFor(magic);
            Assert.That(intelligence.Powers, Contains.Item("this ability has Knowledge (category)"));
            Assert.That(intelligence.Powers, Contains.Item("this ability has Knowledge (other category)"));
            Assert.That(intelligence.Powers.Count, Is.EqualTo(2));
        }

        [Test]
        public void CannotHaveDuplicateKnowledgeCategories()
        {
            intelligenceAttributesResult.LesserPowersCount = 2;
            mockPercentileSelector.Setup(s => s.SelectFrom("IntelligenceLesserPowers", It.IsAny<Int32>()))
                .Returns("this ability has Knowledge");
            mockPercentileSelector.SetupSequence(s => s.SelectFrom("KnowledgeCategories", It.IsAny<Int32>())).Returns("category")
                .Returns("category").Returns("other category");

            var intelligence = intelligenceGenerator.GenerateFor(magic);
            Assert.That(intelligence.Powers, Contains.Item("this ability has Knowledge (category)"));
            Assert.That(intelligence.Powers, Contains.Item("this ability has Knowledge (other category)"));
            Assert.That(intelligence.Powers.Count, Is.EqualTo(2));
        }

        [Test]
        public void DesignatedFoesDetermined()
        {
            intelligenceAttributesResult.GreaterPowersCount = 1;
            mockPercentileSelector.Setup(s => s.SelectFrom("IntelligenceGreaterPowers", It.IsAny<Int32>())).Returns("greater power");
            mockDice.Setup(d => d.d4(1)).Returns(1);
            mockPercentileSelector.Setup(s => s.SelectFrom("IntelligenceSpecialPurposes", It.IsAny<Int32>())).Returns("purpose has DESIGNATEDFOE");
            mockPercentileSelector.Setup(s => s.SelectFrom("DesignatedFoes", It.IsAny<Int32>())).Returns("foe");

            var intelligence = intelligenceGenerator.GenerateFor(magic);
            Assert.That(intelligence.SpecialPurpose, Is.EqualTo("purpose has foe"));
        }
    }
}