﻿using NUnit.Framework;
using TreasureGen.Domain.Tables;

namespace TreasureGen.Tests.Unit.Tables
{
    [TestFixture]
    public class DataIndexConstantsTests
    {
        [TestCase(DataIndexConstants.Armor.ArmorBonus, 0)]
        [TestCase(DataIndexConstants.Armor.ArmorCheckPenalty, 1)]
        [TestCase(DataIndexConstants.Armor.MaxDexterityBonus, 2)]
        public void ArmorDataIndex(int constant, int value)
        {
            Assert.That(constant, Is.EqualTo(value));
        }

        [TestCase(DataIndexConstants.Intelligence.GreaterPowersCount, 2)]
        [TestCase(DataIndexConstants.Intelligence.LesserPowersCount, 1)]
        [TestCase(DataIndexConstants.Intelligence.Senses, 0)]
        public void IntelligenceDataIndex(int constant, int value)
        {
            Assert.That(constant, Is.EqualTo(value));
        }

        [TestCase(DataIndexConstants.Range.Minimum, 0)]
        [TestCase(DataIndexConstants.Range.Maximum, 1)]
        public void RangeDataIndex(int constant, int value)
        {
            Assert.That(constant, Is.EqualTo(value));
        }

        [TestCase(DataIndexConstants.SpecialAbility.BaseName, 1)]
        [TestCase(DataIndexConstants.SpecialAbility.BonusEquivalent, 0)]
        [TestCase(DataIndexConstants.SpecialAbility.Power, 2)]
        public void SpecialAbilityDataIndex(int constant, int value)
        {
            Assert.That(constant, Is.EqualTo(value));
        }
    }
}