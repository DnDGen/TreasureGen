using System;
using NUnit.Framework;

namespace EquipmentGen.Tests.Integration.Tables.Items.Magical.Curses
{
    [TestFixture]
    public class CurseDrawbacksTests : PercentileTests
    {
        protected override String tableName
        {
            get { return "CurseDrawbacks"; }
        }

        [TestCase("Character's hair grows 1 inch longer. Only happens once.", 1, 4)]
        [TestCase("Character HEIGHTs 1/2 inch. Only happens once.", 5, 9)]
        [TestCase("Temperature around item is 10 degrees cooler than normal", 10, 13)]
        [TestCase("Temperature around item is 10 degrees warmer than normal", 14, 17)]
        [TestCase("Character's hair color changes", 18, 21)]
        [TestCase("Character's skin color changes", 22, 25)]
        [TestCase("Character now bears an identifying mark (tattoo, weird glow, or the like)", 26, 29)]
        [TestCase("Character's gender changes", 30, 32)]
        [TestCase("Character's race or kind changes", 33, 34)]
        [TestCase("Item continually emits a disturbing sound (moaning, weeping, screaming, cursing, insults, etc.)", 36, 39)]
        [TestCase("Character becomes selfishly possessive of the item", 41, 45)]
        [TestCase("Character becomes paranoid about losing the item and afraid of damage occurring to it", 46, 49)]
        [TestCase("Character's alignment changes", 50, 51)]
        [TestCase("Character must attack nearest creature (5% chance each day)", 52, 54)]
        [TestCase("Character is stunned for 1d4 rounds once item function is finished (or randomly 1/day)", 55, 57)]
        [TestCase("Character's vision is blurry (-2 penalty on attack rolls, saves, and skill checks requiring vision)", 58, 60)]
        [TestCase("Character gains one negative level", 61, 64)]
        [TestCase("Character must make a Will save (DC 20) each day or take 1 point of Intelligence damage", 66, 70)]
        [TestCase("Character must make a Will save (DC 20) each day or take 1 point of Wisdom damage", 71, 75)]
        [TestCase("Character must make a Will save (DC 20) each day or take 1 point of Charisma damage", 76, 80)]
        [TestCase("Character must make a Fortitude save (DC 20) each day or take 1 point of Constitution damage", 81, 85)]
        [TestCase("Character must make a Fortitude save (DC 20) each day or take 1 point of Strength damage", 86, 90)]
        [TestCase("Character must make a Fortitude save (DC 20) each day or take 1 point of Dexterity damage", 91, 95)]
        public void Percentile(String content, Int32 lower, Int32 upper)
        {
            AssertPercentile(content, lower, upper);
        }

        [TestCase("Character is afflicted with a random disease that cannot be cured", 35)]
        [TestCase("Item looks ridiculous (garishly colored, silly shape, glows bright pink, etc.)", 40)]
        [TestCase("Character gains two negative levels", 65)]
        [TestCase("Character is polymorphed into a specific creature (5% chance each day)", 96)]
        [TestCase("Character cannot cast arcane spells", 97)]
        [TestCase("Character cannot cast divine spells", 98)]
        [TestCase("Character cannot cast any spells", 99)]
        [TestCase("Item casts Harm on the wielder 1/day", 100)]
        public void Percentile(String content, Int32 roll)
        {
            AssertPercentile(content, roll);
        }
    }
}