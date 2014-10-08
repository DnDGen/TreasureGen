using System;
using EquipmentGen.Common.Items;
using NUnit.Framework;

namespace EquipmentGen.Tests.Unit.Common.Items
{
    [TestFixture]
    public class CurseConstantsTests
    {
        [TestCase(CurseConstants.Delusion, "Delusion")]
        [TestCase(CurseConstants.OppositeEffect, "Opposite effect or target")]
        [TestCase(CurseConstants.Intermittent, "Intermittent Functioning")]
        [TestCase(CurseConstants.Requirement, "Requirement")]
        [TestCase(CurseConstants.Drawback, "Drawback")]
        [TestCase(CurseConstants.DifferentEffect, "Completely different effect")]
        [TestCase(CurseConstants.SpecificCursedItem, "This is a specific cursed item")]
        [TestCase(CurseConstants.Dependent.BelowFreezing, "Temperature below freezing")]
        [TestCase(CurseConstants.Dependent.AboveFreezing, "Temperature above freezing")]
        [TestCase(CurseConstants.Dependent.Day, "During the day")]
        [TestCase(CurseConstants.Dependent.Night, "During the night")]
        [TestCase(CurseConstants.Dependent.InSunlight, "In direct sunlight")]
        [TestCase(CurseConstants.Dependent.OutSunlight, "Out of direct sunlight")]
        [TestCase(CurseConstants.Dependent.Underwater, "Underwater")]
        [TestCase(CurseConstants.Dependent.OutOfWater, "Out of water")]
        [TestCase(CurseConstants.Dependent.Underground, "Underground")]
        [TestCase(CurseConstants.Dependent.Aboveground, "Aboveground")]
        [TestCase(CurseConstants.Dependent.CloseToDESIGNATEDFOE, "Within 10 feet of a DESIGNATEDFOE")]
        [TestCase(CurseConstants.Dependent.CloseToArcane, "Within 10 feet of an arcane spellcaster")]
        [TestCase(CurseConstants.Dependent.CloseToDivine, "Within 10 feet of a divine spellcaster")]
        [TestCase(CurseConstants.Dependent.HandsOfNonspellcaster, "In the hands of a nonspellcaster")]
        [TestCase(CurseConstants.Dependent.HandsOfSpellcaster, "In the hands of a spellcaster")]
        [TestCase(CurseConstants.Dependent.HandsOfALIGNMENT, "In the hands of a ALIGNMENT creature")]
        [TestCase(CurseConstants.Dependent.NonholyDays, "On nonholy days or during particular astrological events")]
        [TestCase(CurseConstants.Dependent.HandsOfGENDER, "In the hands of a GENDER")]
        [TestCase(CurseConstants.Dependent.MilesFromSite, "More than 100 miles from a particular site")]
        [TestCase(CurseConstants.Drawbacks.HairGrows, "Character's hair grows 1 inch longer. Only happens once.")]
        [TestCase(CurseConstants.Drawbacks.HEIGHTChanges, "Character HEIGHTs 1/2 inch. Only happens once.")]
        [TestCase(CurseConstants.Drawbacks.Cooler, "Temperature around item is 10 degrees cooler than normal")]
        [TestCase(CurseConstants.Drawbacks.Warmer, "Temperature around item is 10 degrees warmer than normal")]
        [TestCase(CurseConstants.Drawbacks.HairColorChanges, "Character's hair color changes")]
        [TestCase(CurseConstants.Drawbacks.SkinColorChanges, "Character's skin color changes")]
        [TestCase(CurseConstants.Drawbacks.IdentifyingMark, "Character now bears an identifying mark (tattoo, weird glow, or the like)")]
        [TestCase(CurseConstants.Drawbacks.GenderChanges, "Character's gender changes")]
        [TestCase(CurseConstants.Drawbacks.RaceChanges, "Character's race or kind changes")]
        [TestCase(CurseConstants.Drawbacks.EmitsSound, "Item continually emits a disturbing sound (moaning, weeping, screaming, cursing, insults, etc.)")]
        [TestCase(CurseConstants.Drawbacks.Possessive, "Character becomes selfishly possessive of the item")]
        [TestCase(CurseConstants.Drawbacks.Paranoid, "Character becomes paranoid about losing the item and afraid of damage occurring to it")]
        [TestCase(CurseConstants.Drawbacks.AlignmentChanges, "Character's alignment changes")]
        [TestCase(CurseConstants.Drawbacks.AttackNearestCreature, "Character must attack nearest creature (5% chance each day)")]
        [TestCase(CurseConstants.Drawbacks.Stunned, "Character is stunned for 1d4 rounds once item function is finished (or randomly 1/day)")]
        [TestCase(CurseConstants.Drawbacks.BlurryVision, "Character's vision is blurry (-2 penalty on attack rolls, saves, and skill checks requiring vision)")]
        [TestCase(CurseConstants.Drawbacks.NegativeLevel_1, "Character gains one negative level")]
        [TestCase(CurseConstants.Drawbacks.StatDamage_Intelligence, "Character must make a Will save (DC 20) each day or take 1 point of Intelligence damage")]
        [TestCase(CurseConstants.Drawbacks.StatDamage_Wisdom, "Character must make a Will save (DC 20) each day or take 1 point of Wisdom damage")]
        [TestCase(CurseConstants.Drawbacks.StatDamage_Charisma, "Character must make a Will save (DC 20) each day or take 1 point of Charisma damage")]
        [TestCase(CurseConstants.Drawbacks.StatDamage_Constitution, "Character must make a Fortitude save (DC 20) each day or take 1 point of Constitution damage")]
        [TestCase(CurseConstants.Drawbacks.StatDamage_Strength, "Character must make a Fortitude save (DC 20) each day or take 1 point of Strength damage")]
        [TestCase(CurseConstants.Drawbacks.StatDamage_Dexterity, "Character must make a Fortitude save (DC 20) each day or take 1 point of Dexterity damage")]
        [TestCase(CurseConstants.Drawbacks.Disease, "Character is afflicted with a random disease that cannot be cured")]
        [TestCase(CurseConstants.Drawbacks.Ridiculous, "Item looks ridiculous (garishly colored, silly shape, glows bright pink, etc.)")]
        [TestCase(CurseConstants.Drawbacks.NegativeLevel_2, "Character gains two negative levels")]
        [TestCase(CurseConstants.Drawbacks.Polymorphed, "Character is polymorphed into a specific creature (5% chance each day)")]
        [TestCase(CurseConstants.Drawbacks.NoSpells_Arcane, "Character cannot cast arcane spells")]
        [TestCase(CurseConstants.Drawbacks.NoSpells_Divine, "Character cannot cast divine spells")]
        [TestCase(CurseConstants.Drawbacks.NoSpells_Any, "Character cannot cast any spells")]
        [TestCase(CurseConstants.Drawbacks.Harm, "Item casts Harm on the wielder 1/day")]
        public void Constant(String constant, String value)
        {
            Assert.That(constant, Is.EqualTo(value));
        }

    }
}