using System;
using System.Collections.Generic;
using System.Linq;
using D20Dice;
using EquipmentGen.Common.Items;
using EquipmentGen.Generators.Interfaces.Items.Magical;
using EquipmentGen.Generators.Items.Magical;
using EquipmentGen.Selectors.Interfaces;
using Moq;
using NUnit.Framework;

namespace EquipmentGen.Tests.Unit.Generators.Items.Magical
{
    [TestFixture, System.Runtime.InteropServices.GuidAttribute("CE5B815C-3609-48E6-9DC1-8AC7A00A335A")]
    public class IntelligenceGeneratorTests
    {
        private IIntelligenceGenerator intelligenceGenerator;
        private Mock<IDice> mockDice;
        private Mock<IPercentileSelector> mockPercentileSelector;
        private Mock<IAttributesSelector> mockAttributesSelector;
        private List<String> attributes;
        private Dictionary<Magic, Object> magic;

        [SetUp]
        public void Setup()
        {
            mockDice = new Mock<IDice>();
            mockDice.Setup(d => d.d4(1)).Returns(4);

            mockPercentileSelector = new Mock<IPercentileSelector>();
            mockPercentileSelector.Setup(s => s.SelectFrom("IntelligenceStrongStat", It.IsAny<Int32>())).Returns("10");

            mockAttributesSelector = new Mock<IAttributesSelector>();
            var fillerValues = new[] { "0" };
            mockAttributesSelector.Setup(s => s.SelectFrom(It.IsAny<String>(), It.IsAny<String>())).Returns(fillerValues);

            attributes = new List<String>();
            magic = new Dictionary<Magic, Object>();
            magic[Magic.IsMagical] = true;

            intelligenceGenerator = new IntelligenceGenerator(mockDice.Object, mockPercentileSelector.Object,
                mockAttributesSelector.Object);
        }

        [Test]
        public void AlchemicalItemsAreNotIntelligent()
        {
            for (var roll = 100; roll > 0; roll--)
            {
                mockDice.Setup(d => d.Percentile(1)).Returns(roll);
                var isIntelligent = intelligenceGenerator.IsIntelligent(ItemTypeConstants.AlchemicalItem, attributes, magic);
                Assert.That(isIntelligent, Is.False);
            }
        }

        [Test]
        public void ArmorsAreIntelligentOnRollOf1()
        {
            mockDice.Setup(d => d.Percentile(1)).Returns(1);
            var isIntelligent = intelligenceGenerator.IsIntelligent(ItemTypeConstants.Armor, attributes, magic);
            Assert.That(isIntelligent, Is.True);
        }

        [Test]
        public void ArmorsAreNotIntelligentOnRollAbove1()
        {
            for (var roll = 100; roll > 1; roll--)
            {
                mockDice.Setup(d => d.Percentile(1)).Returns(roll);
                var isIntelligent = intelligenceGenerator.IsIntelligent(ItemTypeConstants.Armor, attributes, magic);
                Assert.That(isIntelligent, Is.False);
            }
        }

        [Test]
        public void PotionsAreNotIntelligent()
        {
            for (var roll = 100; roll > 0; roll--)
            {
                mockDice.Setup(d => d.Percentile(1)).Returns(roll);
                var isIntelligent = intelligenceGenerator.IsIntelligent(ItemTypeConstants.Potion, attributes, magic);
                Assert.That(isIntelligent, Is.False);
            }
        }

        [Test]
        public void RingsAreIntelligentOnRollOf1()
        {
            mockDice.Setup(d => d.Percentile(1)).Returns(1);
            var isIntelligent = intelligenceGenerator.IsIntelligent(ItemTypeConstants.Ring, attributes, magic);
            Assert.That(isIntelligent, Is.True);
        }

        [Test]
        public void RingsAreNotIntelligentOnRollAbove1()
        {
            for (var roll = 100; roll > 1; roll--)
            {
                mockDice.Setup(d => d.Percentile(1)).Returns(roll);
                var isIntelligent = intelligenceGenerator.IsIntelligent(ItemTypeConstants.Ring, attributes, magic);
                Assert.That(isIntelligent, Is.False);
            }
        }

        [Test]
        public void RodsAreIntelligentOnRollOf1()
        {
            mockDice.Setup(d => d.Percentile(1)).Returns(1);
            var isIntelligent = intelligenceGenerator.IsIntelligent(ItemTypeConstants.Rod, attributes, magic);
            Assert.That(isIntelligent, Is.True);
        }

        [Test]
        public void RodsAreNotIntelligentOnRollAbove1()
        {
            for (var roll = 100; roll > 1; roll--)
            {
                mockDice.Setup(d => d.Percentile(1)).Returns(roll);
                var isIntelligent = intelligenceGenerator.IsIntelligent(ItemTypeConstants.Rod, attributes, magic);
                Assert.That(isIntelligent, Is.False);
            }
        }

        [Test]
        public void ScrollsAreNotIntelligent()
        {
            for (var roll = 100; roll > 0; roll--)
            {
                mockDice.Setup(d => d.Percentile(1)).Returns(roll);
                var isIntelligent = intelligenceGenerator.IsIntelligent(ItemTypeConstants.Scroll, attributes, magic);
                Assert.That(isIntelligent, Is.False);
            }
        }

        [Test]
        public void StavesAreNotIntelligent()
        {
            for (var roll = 100; roll > 0; roll--)
            {
                mockDice.Setup(d => d.Percentile(1)).Returns(roll);
                var isIntelligent = intelligenceGenerator.IsIntelligent(ItemTypeConstants.Staff, attributes, magic);
                Assert.That(isIntelligent, Is.False);
            }
        }

        [Test]
        public void WandsAreNotIntelligent()
        {
            for (var roll = 100; roll > 0; roll--)
            {
                mockDice.Setup(d => d.Percentile(1)).Returns(roll);
                var isIntelligent = intelligenceGenerator.IsIntelligent(ItemTypeConstants.Wand, attributes, magic);
                Assert.That(isIntelligent, Is.False);
            }
        }

        [Test]
        public void WondrousItemsAreIntelligentOnRollOf1()
        {
            mockDice.Setup(d => d.Percentile(1)).Returns(1);
            var isIntelligent = intelligenceGenerator.IsIntelligent(ItemTypeConstants.WondrousItem, attributes, magic);
            Assert.That(isIntelligent, Is.True);
        }

        [Test]
        public void WondrousItemsAreNotIntelligentOnRollAbove1()
        {
            for (var roll = 100; roll > 1; roll--)
            {
                mockDice.Setup(d => d.Percentile(1)).Returns(roll);
                var isIntelligent = intelligenceGenerator.IsIntelligent(ItemTypeConstants.WondrousItem, attributes, magic);
                Assert.That(isIntelligent, Is.False);
            }
        }

        [Test]
        public void RangedWeaponsAreIntelligentOnRollOf1Through5()
        {
            for (var roll = 5; roll > 0; roll--)
            {
                mockDice.Setup(d => d.Percentile(1)).Returns(roll);
                var isIntelligent = intelligenceGenerator.IsIntelligent(AttributeConstants.Ranged, attributes, magic);
                Assert.That(isIntelligent, Is.True);
            }
        }

        [Test]
        public void RangedWeaponsAreNotIntelligentOnRollAbove5()
        {
            for (var roll = 100; roll > 5; roll--)
            {
                mockDice.Setup(d => d.Percentile(1)).Returns(roll);
                var isIntelligent = intelligenceGenerator.IsIntelligent(AttributeConstants.Ranged, attributes, magic);
                Assert.That(isIntelligent, Is.False);
            }
        }

        [Test]
        public void MeleeWeaponsAreIntelligentOnRollOf1Through15()
        {
            for (var roll = 15; roll > 0; roll--)
            {
                mockDice.Setup(d => d.Percentile(1)).Returns(roll);
                var isIntelligent = intelligenceGenerator.IsIntelligent(AttributeConstants.Melee, attributes, magic);
                Assert.That(isIntelligent, Is.True);
            }
        }

        [Test]
        public void MeleeWeaponsAreNotIntelligentOnRollAbove15()
        {
            for (var roll = 100; roll > 15; roll--)
            {
                mockDice.Setup(d => d.Percentile(1)).Returns(roll);
                var isIntelligent = intelligenceGenerator.IsIntelligent(AttributeConstants.Melee, attributes, magic);
                Assert.That(isIntelligent, Is.False);
            }
        }

        [Test]
        public void OneTimeUseItemsAreNotIntelligent()
        {
            mockDice.Setup(d => d.Percentile(1)).Returns(1);
            attributes.Add(AttributeConstants.OneTimeUse);

            var isIntelligent = intelligenceGenerator.IsIntelligent(AttributeConstants.Melee, attributes, magic);
            Assert.That(isIntelligent, Is.False);
        }

        [Test]
        public void NonMagicalItemsAreNotIntelligent()
        {
            mockDice.Setup(d => d.Percentile(1)).Returns(1);
            magic.Clear();

            var isIntelligent = intelligenceGenerator.IsIntelligent(AttributeConstants.Melee, attributes, magic);
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
            mockPercentileSelector.Setup(s => s.SelectFrom("IntelligenceStrongStat", 9266)).Returns("42");

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
            mockPercentileSelector.Setup(s => s.SelectFrom("IntelligenceStrongStat", 9266)).Returns("42");

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
            mockPercentileSelector.Setup(s => s.SelectFrom("IntelligenceStrongStat", 9266)).Returns("42");

            var intelligence = intelligenceGenerator.GenerateFor(magic);
            Assert.That(intelligence.CharismaStat, Is.EqualTo(42));
            Assert.That(intelligence.IntelligenceStat, Is.EqualTo(42));
            Assert.That(intelligence.WisdomStat, Is.EqualTo(10));
        }

        [Test]
        public void GetCommunicationFromAttributesSelector()
        {
            var attributes = new[] { "talky" };
            mockPercentileSelector.Setup(s => s.SelectFrom("IntelligenceStrongStat", It.IsAny<Int32>())).Returns("9266");
            mockAttributesSelector.Setup(s => s.SelectFrom("IntelligenceCommunication", "9266")).Returns(attributes);

            var intelligence = intelligenceGenerator.GenerateFor(magic);
            Assert.That(intelligence.Communication, Is.EqualTo(attributes));
        }

        [Test]
        public void GetLanguagesIfSpeech()
        {
            var attributes = new[] { "Speech" };
            mockPercentileSelector.Setup(s => s.SelectFrom("IntelligenceStrongStat", It.IsAny<Int32>())).Returns("10");
            mockAttributesSelector.Setup(s => s.SelectFrom("IntelligenceCommunication", "10")).Returns(attributes);

            var intelligence = intelligenceGenerator.GenerateFor(magic);
            Assert.That(intelligence.Languages, Contains.Item("Common"));
        }

        [Test]
        public void GetNumberOfLanguagesEqualToIntelligenceModifier()
        {
            var attributes = new[] { "Speech" };
            mockPercentileSelector.Setup(s => s.SelectFrom("IntelligenceStrongStat", It.IsAny<Int32>())).Returns("14");
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
            mockPercentileSelector.Setup(s => s.SelectFrom("IntelligenceStrongStat", It.IsAny<Int32>())).Returns("14");
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
            var attributes = new[] { "sensy" };
            mockPercentileSelector.Setup(s => s.SelectFrom("IntelligenceStrongStat", It.IsAny<Int32>())).Returns("9266");
            mockAttributesSelector.Setup(s => s.SelectFrom("IntelligenceSenses", "9266")).Returns(attributes);

            var intelligence = intelligenceGenerator.GenerateFor(magic);
            Assert.That(intelligence.Senses, Is.EqualTo(attributes.First()));
        }

        [Test]
        public void GetLesserPowersFromAttributesSelector()
        {
            var attributes = new[] { "2" };
            mockPercentileSelector.Setup(s => s.SelectFrom("IntelligenceStrongStat", It.IsAny<Int32>())).Returns("9266");
            mockAttributesSelector.Setup(s => s.SelectFrom("IntelligenceLesserPowersCount", "9266")).Returns(attributes);
            mockPercentileSelector.SetupSequence(s => s.SelectFrom("IntelligenceLesserPowers", It.IsAny<Int32>()))
                .Returns("power 1").Returns("power 2");

            var intelligence = intelligenceGenerator.GenerateFor(magic);
            Assert.That(intelligence.Powers.Count, Is.EqualTo(2));
        }

        [Test]
        public void CannotHaveDuplicateLesserPowers()
        {
            var attributes = new[] { "2" };
            mockPercentileSelector.Setup(s => s.SelectFrom("IntelligenceStrongStat", It.IsAny<Int32>())).Returns("9266");
            mockAttributesSelector.Setup(s => s.SelectFrom("IntelligenceLesserPowersCount", "9266")).Returns(attributes);
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
            var attributes = new[] { "2" };
            mockPercentileSelector.Setup(s => s.SelectFrom("IntelligenceStrongStat", It.IsAny<Int32>())).Returns("9266");
            mockAttributesSelector.Setup(s => s.SelectFrom("IntelligenceGreaterPowersCount", "9266")).Returns(attributes);
            mockPercentileSelector.SetupSequence(s => s.SelectFrom("IntelligenceGreaterPowers", It.IsAny<Int32>()))
                .Returns("power 1").Returns("power 2");

            var intelligence = intelligenceGenerator.GenerateFor(magic);
            Assert.That(intelligence.Powers.Count, Is.EqualTo(2));
        }

        [Test]
        public void CannotHaveDuplicateGreaterPowers()
        {
            var attributes = new[] { "2" };
            mockPercentileSelector.Setup(s => s.SelectFrom("IntelligenceStrongStat", It.IsAny<Int32>())).Returns("9266");
            mockAttributesSelector.Setup(s => s.SelectFrom("IntelligenceGreaterPowersCount", "9266")).Returns(attributes);
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
            var attributes = new[] { "1" };
            mockPercentileSelector.Setup(s => s.SelectFrom("IntelligenceStrongStat", It.IsAny<Int32>())).Returns("9266");
            mockAttributesSelector.Setup(s => s.SelectFrom("IntelligenceGreaterPowersCount", "9266")).Returns(attributes);
            mockPercentileSelector.Setup(s => s.SelectFrom("IntelligenceGreaterPowers", It.IsAny<Int32>())).Returns("greater power");
            mockDice.Setup(d => d.d4(1)).Returns(1);
            mockPercentileSelector.Setup(s => s.SelectFrom("IntelligenceSpecialPurpose", It.IsAny<Int32>())).Returns("purpose");
            mockPercentileSelector.Setup(s => s.SelectFrom("IntelligenceDedicatedPower", It.IsAny<Int32>()))
                .Returns("dedicated power");

            var intelligence = intelligenceGenerator.GenerateFor(magic);
            Assert.That(intelligence.Powers, Is.Empty);
            Assert.That(intelligence.SpecialPurpose, Is.EqualTo("purpose"));
            Assert.That(intelligence.DedicatedPower, Is.EqualTo("dedicated power"));
        }

        [Test]
        public void OneGreaterPowerMeans75PercentChanceForGreaterPower()
        {
            var attributes = new[] { "1" };
            mockPercentileSelector.Setup(s => s.SelectFrom("IntelligenceStrongStat", It.IsAny<Int32>())).Returns("9266");
            mockAttributesSelector.Setup(s => s.SelectFrom("IntelligenceGreaterPowersCount", "9266")).Returns(attributes);
            mockPercentileSelector.Setup(s => s.SelectFrom("IntelligenceGreaterPowers", It.IsAny<Int32>())).Returns("greater power");
            mockPercentileSelector.Setup(s => s.SelectFrom("IntelligenceSpecialPurpose", It.IsAny<Int32>())).Returns("purpose");
            mockPercentileSelector.Setup(s => s.SelectFrom("IntelligenceDedicatedPower", It.IsAny<Int32>()))
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
                var attributes = new[] { "2" };
                mockPercentileSelector.Setup(s => s.SelectFrom("IntelligenceStrongStat", It.IsAny<Int32>())).Returns("9266");
                mockAttributesSelector.Setup(s => s.SelectFrom("IntelligenceGreaterPowersCount", "9266")).Returns(attributes);
                mockPercentileSelector.SetupSequence(s => s.SelectFrom("IntelligenceGreaterPowers", It.IsAny<Int32>()))
                    .Returns("greater power 1").Returns("greater power 2");
                mockPercentileSelector.Setup(s => s.SelectFrom("IntelligenceSpecialPurpose", It.IsAny<Int32>())).Returns("purpose");
                mockPercentileSelector.Setup(s => s.SelectFrom("IntelligenceDedicatedPower", It.IsAny<Int32>()))
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
                var attributes = new[] { "2" };
                mockPercentileSelector.Setup(s => s.SelectFrom("IntelligenceStrongStat", It.IsAny<Int32>())).Returns("9266");
                mockAttributesSelector.Setup(s => s.SelectFrom("IntelligenceGreaterPowersCount", "9266")).Returns(attributes);
                mockPercentileSelector.SetupSequence(s => s.SelectFrom("IntelligenceGreaterPowers", It.IsAny<Int32>()))
                    .Returns("greater power 1").Returns("greater power 2");
                mockPercentileSelector.Setup(s => s.SelectFrom("IntelligenceSpecialPurpose", It.IsAny<Int32>())).Returns("purpose");
                mockPercentileSelector.Setup(s => s.SelectFrom("IntelligenceDedicatedPower", It.IsAny<Int32>()))
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
                var attributes = new[] { "3" };
                mockPercentileSelector.Setup(s => s.SelectFrom("IntelligenceStrongStat", It.IsAny<Int32>())).Returns("9266");
                mockAttributesSelector.Setup(s => s.SelectFrom("IntelligenceGreaterPowersCount", "9266")).Returns(attributes);
                mockPercentileSelector.SetupSequence(s => s.SelectFrom("IntelligenceGreaterPowers", It.IsAny<Int32>()))
                    .Returns("greater power 1").Returns("greater power 2").Returns("greater power 3");
                mockPercentileSelector.Setup(s => s.SelectFrom("IntelligenceSpecialPurpose", It.IsAny<Int32>())).Returns("purpose");
                mockPercentileSelector.Setup(s => s.SelectFrom("IntelligenceDedicatedPower", It.IsAny<Int32>()))
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
                var attributes = new[] { "3" };
                mockPercentileSelector.Setup(s => s.SelectFrom("IntelligenceStrongStat", It.IsAny<Int32>())).Returns("9266");
                mockAttributesSelector.Setup(s => s.SelectFrom("IntelligenceGreaterPowersCount", "9266")).Returns(attributes);
                mockPercentileSelector.SetupSequence(s => s.SelectFrom("IntelligenceGreaterPowers", It.IsAny<Int32>()))
                    .Returns("greater power 1").Returns("greater power 2").Returns("greater power 3");
                mockPercentileSelector.Setup(s => s.SelectFrom("IntelligenceSpecialPurpose", It.IsAny<Int32>())).Returns("purpose");
                mockPercentileSelector.Setup(s => s.SelectFrom("IntelligenceDedicatedPower", It.IsAny<Int32>()))
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
            magic[Magic.Bonus] = 9266;

            var intelligence = intelligenceGenerator.GenerateFor(magic);
            Assert.That(intelligence.Ego, Is.EqualTo(9266));
        }

        [Test]
        public void EgoIncludesSpecialAbilityBonuses()
        {
            var ability = new SpecialAbility();
            ability.BonusEquivalent = 9266;
            magic[Magic.Abilities] = new[] { ability };

            var intelligence = intelligenceGenerator.GenerateFor(magic);
            Assert.That(intelligence.Ego, Is.EqualTo(9266));
        }

        [Test]
        public void EgoIncludesLesserPowers()
        {
            var attributes = new[] { "2" };
            mockAttributesSelector.Setup(s => s.SelectFrom("IntelligenceLesserPowersCount", "10")).Returns(attributes);
            mockPercentileSelector.SetupSequence(s => s.SelectFrom("IntelligenceLesserPowers", It.IsAny<Int32>()))
                .Returns("power 1").Returns("power 2");

            var intelligence = intelligenceGenerator.GenerateFor(magic);
            Assert.That(intelligence.Ego, Is.EqualTo(2));
        }

        [Test]
        public void EgoIncludesGreaterPowers()
        {
            var attributes = new[] { "2" };
            mockAttributesSelector.Setup(s => s.SelectFrom("IntelligenceGreaterPowersCount", "10")).Returns(attributes);
            mockPercentileSelector.SetupSequence(s => s.SelectFrom("IntelligenceGreaterPowers", It.IsAny<Int32>()))
                .Returns("greater power 1").Returns("greater power 2");

            var intelligence = intelligenceGenerator.GenerateFor(magic);
            Assert.That(intelligence.Ego, Is.EqualTo(4));
        }

        [Test]
        public void EgoIncludesDedicatedPower()
        {
            var attributes = new[] { "1" };
            mockAttributesSelector.Setup(s => s.SelectFrom("IntelligenceGreaterPowersCount", "10")).Returns(attributes);
            mockPercentileSelector.Setup(s => s.SelectFrom("IntelligenceGreaterPowers", It.IsAny<Int32>())).Returns("greater power");
            mockDice.Setup(d => d.d4(1)).Returns(1);
            mockPercentileSelector.Setup(s => s.SelectFrom("IntelligenceSpecialPurpose", It.IsAny<Int32>())).Returns("purpose");
            mockPercentileSelector.Setup(s => s.SelectFrom("IntelligenceDedicatedPower", It.IsAny<Int32>()))
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
            mockPercentileSelector.Setup(s => s.SelectFrom("IntelligenceStrongStat", It.IsAny<Int32>())).Returns("19");

            var intelligence = intelligenceGenerator.GenerateFor(magic);
            Assert.That(intelligence.Ego, Is.EqualTo(8));
        }

        [Test]
        public void EgoSumsAllFactors()
        {
            var powerCount = new[] { "2" };
            var communication = new[] { "Read", "Read magic", "Telepathy" };
            mockPercentileSelector.Setup(s => s.SelectFrom("IntelligenceStrongStat", It.IsAny<Int32>())).Returns("19");
            mockAttributesSelector.Setup(s => s.SelectFrom("IntelligenceCommunication", "19")).Returns(communication);
            mockAttributesSelector.Setup(s => s.SelectFrom("IntelligenceGreaterPowersCount", "19")).Returns(powerCount);
            mockPercentileSelector.SetupSequence(s => s.SelectFrom("IntelligenceGreaterPowers", It.IsAny<Int32>()))
                .Returns("greater power 1").Returns("greater power 2");
            mockDice.Setup(d => d.d4(1)).Returns(1);
            mockPercentileSelector.Setup(s => s.SelectFrom("IntelligenceSpecialPurpose", It.IsAny<Int32>())).Returns("purpose");
            mockPercentileSelector.Setup(s => s.SelectFrom("IntelligenceDedicatedPower", It.IsAny<Int32>()))
                .Returns("dedicated power");
            mockAttributesSelector.Setup(s => s.SelectFrom("IntelligenceLesserPowersCount", "19")).Returns(powerCount);
            mockPercentileSelector.SetupSequence(s => s.SelectFrom("IntelligenceLesserPowers", It.IsAny<Int32>()))
                .Returns("power 1").Returns("power 2");
            var ability = new SpecialAbility();
            ability.BonusEquivalent = 92;
            magic[Magic.Abilities] = new[] { ability };
            magic[Magic.Bonus] = 66;

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
    }
}