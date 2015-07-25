using System;

namespace TreasureGen.Common.Items
{
    public static class CurseConstants
    {
        public const String Delusion = "Delusion";
        public const String OppositeEffect = "Opposite effect or target";
        public const String Intermittent = "Intermittent Functioning";
        public const String Requirement = "Requirement";
        public const String Drawback = "Drawback";
        public const String DifferentEffect = "Completely different effect";
        public const String SpecificCursedItem = "This is a specific cursed item";

        public static class Dependent
        {
            public const String BelowFreezing = "Temperature below freezing";
            public const String AboveFreezing = "Temperature above freezing";
            public const String Day = "During the day";
            public const String Night = "During the night";
            public const String InSunlight = "In direct sunlight";
            public const String OutSunlight = "Out of direct sunlight";
            public const String Underwater = "Underwater";
            public const String OutOfWater = "Out of water";
            public const String Underground = "Underground";
            public const String Aboveground = "Aboveground";
            public const String CloseToDESIGNATEDFOE = "Within 10 feet of a DESIGNATEDFOE";
            public const String CloseToArcane = "Within 10 feet of an arcane spellcaster";
            public const String CloseToDivine = "Within 10 feet of a divine spellcaster";
            public const String HandsOfNonspellcaster = "In the hands of a nonspellcaster";
            public const String HandsOfSpellcaster = "In the hands of a spellcaster";
            public const String HandsOfPARTIALALIGNMENT = "In the hands of a PARTIALALIGNMENT creature";
            public const String HandsOfFULLALIGNMENT = "In the hands of a FULLALIGNMENT creature";
            public const String NonholyDays = "On nonholy days or during particular astrological events";
            public const String HandsOfGENDER = "In the hands of a GENDER";
            public const String MilesFromSite = "More than 100 miles from a particular site";
        }

        public static class Drawbacks
        {
            public const String HairGrows = "Character's hair grows 1 inch longer. Only happens once.";
            public const String HEIGHTChanges = "Character HEIGHTs 1/2 inch. Only happens once.";
            public const String Cooler = "Temperature around item is 10 degrees cooler than normal";
            public const String Warmer = "Temperature around item is 10 degrees warmer than normal";
            public const String HairColorChanges = "Character's hair color changes";
            public const String SkinColorChanges = "Character's skin color changes";
            public const String IdentifyingMark = "Character now bears an identifying mark (tattoo, weird glow, or the like)";
            public const String GenderChanges = "Character's gender changes";
            public const String RaceChanges = "Character's race or kind changes";
            public const String EmitsSound = "Item continually emits a disturbing sound (moaning, weeping, screaming, cursing, insults, etc.)";
            public const String Possessive = "Character becomes selfishly possessive of the item";
            public const String Paranoid = "Character becomes paranoid about losing the item and afraid of damage occurring to it";
            public const String AlignmentChanges = "Character's alignment changes";
            public const String AttackNearestCreature = "Character must attack nearest creature (5% chance each day)";
            public const String Stunned = "Character is stunned for 1d4 rounds once item function is finished (or randomly 1/day)";
            public const String BlurryVision = "Character's vision is blurry (-2 penalty on attack rolls, saves, and skill checks requiring vision)";
            public const String NegativeLevel_1 = "Character gains one negative level";
            public const String StatDamage_Intelligence = "Character must make a Will save (DC 20) each day or take 1 point of Intelligence damage";
            public const String StatDamage_Wisdom = "Character must make a Will save (DC 20) each day or take 1 point of Wisdom damage";
            public const String StatDamage_Charisma = "Character must make a Will save (DC 20) each day or take 1 point of Charisma damage";
            public const String StatDamage_Constitution = "Character must make a Fortitude save (DC 20) each day or take 1 point of Constitution damage";
            public const String StatDamage_Strength = "Character must make a Fortitude save (DC 20) each day or take 1 point of Strength damage";
            public const String StatDamage_Dexterity = "Character must make a Fortitude save (DC 20) each day or take 1 point of Dexterity damage";
            public const String Disease = "Character is afflicted with a random disease that cannot be cured";
            public const String Ridiculous = "Item looks ridiculous (garishly colored, silly shape, glows bright pink, etc.)";
            public const String NegativeLevel_2 = "Character gains two negative levels";
            public const String Polymorphed = "Character is polymorphed into a specific creature (5% chance each day)";
            public const String NoSpells_Arcane = "Character cannot cast arcane spells";
            public const String NoSpells_Divine = "Character cannot cast divine spells";
            public const String NoSpells_Any = "Character cannot cast any spells";
            public const String Harm = "Item casts Harm on the wielder 1/day";
        }
    }
}