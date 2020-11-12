using DnDGen.TreasureGen.Tables;
using NUnit.Framework;

namespace DnDGen.TreasureGen.Tests.Unit.Tables
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

        [TestCase(DataIndexConstants.Weapon.ThreatRange, 0)]
        [TestCase(DataIndexConstants.Weapon.Ammunition, 2)]
        [TestCase(DataIndexConstants.Weapon.CriticalMultiplier, 1)]
        [TestCase(DataIndexConstants.Weapon.SecondaryCriticalMultiplier, 3)]
        public void WeaponDataIndex(int constant, int value)
        {
            Assert.That(constant, Is.EqualTo(value));
        }

        [TestCase(DataIndexConstants.Weapon.DamageData.RollIndex, 0)]
        [TestCase(DataIndexConstants.Weapon.DamageData.TypeIndex, 1)]
        [TestCase(DataIndexConstants.Weapon.DamageData.ConditionIndex, 2)]
        public void DamageDataIndex(int constant, int value)
        {
            Assert.That(constant, Is.EqualTo(value));
        }

        [Test]
        public void InitializeDamageDataArray()
        {
            var data = DataIndexConstants.Weapon.DamageData.InitializeData();
            Assert.That(data, Has.Length.EqualTo(3).And.All.Empty);
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
