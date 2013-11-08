using System;
using System.Collections.Generic;
using System.Text;

namespace Dungeon_Maker
{
    class CursedItem
    {
        public static string Generate(ref bool SpecificCursedItem, ref Random random)
        {
            if (Dice.Percentile(ref random) <= 5)
            {
                switch (Dice.Percentile(ref random))
                {
                    case 1:
                    case 2:
                    case 3:
                    case 4:
                    case 5:
                    case 6:
                    case 7:
                    case 8:
                    case 9:
                    case 10:
                    case 11:
                    case 12:
                    case 13:
                    case 14:
                    case 15: return "cursed (delusion) ";
                    case 36:
                    case 37:
                    case 38:
                    case 39:
                    case 40:
                    case 41:
                    case 42:
                    case 43:
                    case 44:
                    case 45: return String.Format("cursed ({0}) ", IntermittentFuctioning(ref random));
                    case 46:
                    case 47:
                    case 48:
                    case 49:
                    case 50:
                    case 51:
                    case 52:
                    case 53:
                    case 54:
                    case 55:
                    case 56:
                    case 57:
                    case 58:
                    case 59:
                    case 60: return String.Format("cursed ({0}) ", Requirement(ref random));
                    case 61:
                    case 62:
                    case 63:
                    case 64:
                    case 65:
                    case 66:
                    case 67:
                    case 68:
                    case 69:
                    case 70:
                    case 71:
                    case 72:
                    case 73:
                    case 74:
                    case 75: return String.Format("cursed ({0}) ", Drawback(ref random));
                    case 76:
                    case 77:
                    case 78:
                    case 79:
                    case 80:
                    case 81:
                    case 82:
                    case 83:
                    case 84:
                    case 85:
                    case 86:
                    case 87:
                    case 88:
                    case 89:
                    case 90: return String.Format("cursed (different effect: {0}) ", DifferentEffect(ref random));
                    case 91:
                    case 92:
                    case 93:
                    case 94:
                    case 95:
                    case 96:
                    case 97:
                    case 98:
                    case 99:
                    case 100:
                        SpecificCursedItem = true;
                        return String.Format("{0}, ", Specific(ref random));
                    default: return "cursed (opposite effect or target) ";
                }
            }
            return "";
        }
        
        private static string IntermittentFuctioning(ref Random random)
        {
            switch (Dice.Roll(1, 3, 0, ref random))
            {
                case 1: return String.Format("unreliable: {0}%", Dice.d10(ref random));
                case 2: return String.Format("dependent: {0}", Dependent(ref random));
                default: return String.Format("requirement: {0}", Requirement(ref random));
            }
        }

        private static string Dependent(ref Random random)
        {
            switch (Dice.Percentile(ref random))
            {
                case 1:
                case 2:
                case 3: return "temperature below freezing";
                case 4:
                case 5: return "temperature above freezing";
                case 6:
                case 7:
                case 8:
                case 9:
                case 10: return "during the day";
                case 16:
                case 17:
                case 18:
                case 19:
                case 20: return "in direct sunlight";
                case 21:
                case 22:
                case 23:
                case 24:
                case 25: return "out of direct sunlight";
                case 26:
                case 27:
                case 28:
                case 29:
                case 30:
                case 31:
                case 32:
                case 33:
                case 34: return "underwater";
                case 35:
                case 36:
                case 37: return "out of water";
                case 38:
                case 39:
                case 40:
                case 41:
                case 42:
                case 43:
                case 44:
                case 45: return "underground";
                case 46:
                case 47:
                case 48:
                case 49:
                case 50:
                case 51:
                case 52:
                case 53:
                case 54:
                case 55: return "aboveground";
                case 56:
                case 57:
                case 58:
                case 59:
                case 60: return String.Format("within 10' of {0}", Character.CreatureType(ref random));
                case 61:
                case 62:
                case 63:
                case 64: return String.Format("within 10' of {0}", Character.HumanoidSubtype(ref random));
                case 65:
                case 66:
                case 67:
                case 68:
                case 69:
                case 70:
                case 71:
                case 72: return "within 10' of an arcane spellcaster";
                case 73:
                case 74:
                case 75:
                case 76:
                case 77:
                case 78:
                case 79:
                case 80: return "within 10' of a divine spellcaster";
                case 81:
                case 82:
                case 83:
                case 84:
                case 85: return "in the hands of a nonspellcaster";
                case 86:
                case 87:
                case 88:
                case 89:
                case 90: return "in the hands of a spellcaster";
                case 91:
                case 92:
                case 93:
                case 94:
                case 95: return String.Format("in the hands of a {0} creature", Character.RandomAlignment(ref random));
                case 96: return String.Format("in the hands of a {0}", Character.RandomGender(ref random, false));
                case 97:
                case 98:
                case 99: return "on nonholy days or during particular atrological events";
                case 100: return "more than 100 miles from a particular site (holy, magical, etc.)";
                default: return "tduring the night";
            }
        }

        private static string Requirement(ref Random random)
        {
            switch (Dice.Roll(1, 19, 0, ref random))
            {
                case 1: return "character must eat twice as much as normal";
                case 2: return "character must sleep twice as much as normal";
                case 3: return "character must undergo a specific one-time quest";
                case 4: return "character must sacrifice (destroy) 100gp worth of valuables per day";
                case 5: return "character must sacrifice (destroy) 2,000gp worth of magic items each week";
                case 6: return "character must swear fealty to a particular noble or his family";
                case 7: return "character must discard all other magical items";
                case 8: return "character must worship a particular deity";
                case 9: return "character must change their name to a specific name";
                case 10: return String.Format("character must change their class to {0}", Character.RandomClass(ref random));
                case 11: return "character must have a minimum number of ranks in a particular skill";
                case 12: return "character must sacrifice 2 points of Constitution";
                case 13: return "item must be cleansed in holy water each day";
                case 14: return "item must be used to kill a living creature each day";
                case 15: return "item must be bathed in volcanic lava once per month";
                case 16: return "item must be used once per day";
                case 17: return "item needs blood";
                case 18: return String.Format("item must have {0} cast on it", Scrolls.RandomSpell(ref random, 9));
                default: return String.Format("{0}, {1}", Requirement(ref random), Requirement(ref random));
            }
        }

        private static string Drawback(ref Random random)
        {
            switch (Dice.Percentile(ref random))
            {
                case 1:
                case 2:
                case 3:
                case 4: return "character's hair grow 1 inch longer";
                case 5:
                case 6:
                case 7:
                case 8:
                case 9:
                    if (Dice.Percentile(ref random) <= 50)
                        return "character shrinks 1 inch";
                    return "character grows 1 inch";
                case 10:
                case 11:
                case 12:
                case 13: return "temperature around the item is 10 degrees cooler than normal";
                case 14:
                case 15:
                case 16:
                case 17: return "temperature around the item is 10 degrees warmer than normal";
                case 18:
                case 19:
                case 20:
                case 21: return "character's hair color changes";
                case 22:
                case 23:
                case 24:
                case 25: return "character's skin color changes";
                case 26:
                case 27:
                case 28:
                case 29: return "character now bears some identifying mark (tattoo, strange glow, etc.)";
                case 30:
                case 31:
                case 32: return "character's gender changes";
                case 33:
                case 34: return "character's race or kind changes";
                case 35: return "character is afflicted with a ref random disease that cannot be cured";
                case 36:
                case 37:
                case 38:
                case 39:
                    string noise;
                    switch (Dice.d8(ref random))
                    {
                        case 1: noise = "moaning"; break;
                        case 2: noise = "weeping"; break;
                        case 3: noise = "screaming"; break;
                        case 4: noise = "cursing"; break;
                        case 5: noise = "hideous laughter"; break;
                        case 6: noise = "a high-pitched squeel"; break;
                        case 7: noise = "an echo at full volume"; break;
                        default: noise = "insults"; break;
                    }
                    return String.Format("item continually emits {0}", noise);
                case 40: return "item looks ridiculous (garishly colored, silly shape, glows bright pink, etc.)";
                case 46:
                case 47:
                case 48:
                case 49: return "character becomes paranoid about losing the item and afraid of damage occurring to it";
                case 50:
                case 51: return "character's alignment changes";
                case 52:
                case 53:
                case 54: return "5% chance each day that character must attack nearest creature"; 
                case 55:
                case 56:
                case 57: return "character is stunned for 1d4 rounds once item function is finished, or ref randomly 1/day";
                case 58:
                case 59:
                case 60: return "character's vision is blurred (-2 on attacks, saves, skill checks requiring vision)";
                case 61:
                case 62:
                case 63:
                case 64: return "character gains one negative level";
                case 65: return "character gains two negative levels";
                case 66:
                case 67:
                case 68:
                case 69:
                case 70: return "character must make a Will save DC 15 each day or temporarily lose 1 point of Intelligence";
                case 71:
                case 72:
                case 73:
                case 74:
                case 75: return "character must make a Will save DC 15 each day or temporarily lose 1 point of Wisdom";
                case 76:
                case 77:
                case 78:
                case 79:
                case 80: return "character must make a Will save DC 15 each day or temporarily lose 1 point of Charisma";
                case 81:
                case 82:
                case 83:
                case 84:
                case 85: return "character must make a Fortitude save DC 15 each day or temporarily lose 1 point of Constitution";
                case 86:
                case 87:
                case 88:
                case 89:
                case 90: return "character must make a Fortitude save DC 15 each day or temporarily lose 1 point of Strength";
                case 91:
                case 92:
                case 93:
                case 94:
                case 95: return "character must make a Fortitude save DC 15 each day or temporarily lose 1 point of Dexterity";
                case 96: return "5% chance each day that character polymorphs into a " + Encounter.Generate(Dice.d20(ref random), ref random) + " (ignore treasure result and quantity of monster)";
                case 97: return "character cannot cast arcane spells";
                case 98: return "character cannot cast divine spells";
                case 99: return "character cast any spells";
                case 100: return String.Format("{0}, {1}", Drawback(ref random), Drawback(ref random));
                default: return "character becomes selfishly possessive about the item";
            }
        }

        private static string Specific(ref Random random)
        {
            switch (Dice.Percentile(ref random))
            {
                case 1: return "Introverted Boots of Eternal Nudity (think you're naked, but not)";
                case 2:
                case 3:
                case 4:
                case 5: return "Incense of Obsession";
                case 16:
                case 17:
                case 18:
                case 19:
                case 20: return "Amulet of Inescapable Location";
                case 21:
                case 22:
                case 23:
                case 24:
                case 25: return "Stone of Weight";
                case 26:
                case 27:
                case 28:
                case 29:
                case 30: return "Bracers of Defenselessness";
                case 31:
                case 32:
                case 33:
                case 34:
                case 35: return "Gauntlets of Fumbling";
                case 36:
                case 37:
                case 38:
                case 39:
                case 40: return "Cursed -2 Sword";
                case 41:
                case 42:
                case 43: return "Armor of Rage";
                case 44:
                case 45:
                case 46: return "Medallion of Thought Projection";
                case 47:
                case 48:
                case 49:
                case 50: return "Cursed Backbiter Spear";
                case 51:
                case 52:
                case 53:
                case 54:
                case 55: return "Flask of Curses";
                case 56:
                case 57: return "Dust of Sneezing and Choking";
                case 58: return "Helm of Opposite Alignment";
                case 59:
                case 60:
                case 61:
                case 62:
                case 63:
                case 64: return "Potion of Poison";
                case 65: return "Broom of Animated Attack";
                case 66:
                case 67: return "Robe of Powerlessness";
                case 68: return "Vacuous Grimoire";
                case 69:
                case 70: return "Armor of Arrow Attraction";
                case 71:
                case 72: return "Net of Snaring";
                case 73:
                case 74:
                case 75: return "Bag of Devouring";
                case 76:
                case 77: return "Bag of Searching (bag of holding, Type IV, but cannot find a given item unless it is the only item in the bag.  Can only remove other items at rate of 1 item per round)";
                case 78:
                case 79:
                case 80: return "Mace of Blood";
                case 81:
                case 82: return "Bastard Sword of Chaos (on a given swing, the sword has a bonus of 1d20 - 11, negatives allowed)";
                case 83:
                case 84:
                case 85: return "Robe of Vermin";
                case 86:
                case 87:
                case 88: return "Periapt of Foul Rotting";
                case 89:
                case 90:
                case 91:
                case 92: return "Berserking Sword";
                case 93: return "Extroverted Boots of Eternal Nudity (you're naked, no equipment at all, but don't realize/believe)";
                case 94:
                case 95:
                case 96: return "Boots of Dancing";
                case 97:
                case 98: return "Necklace of Strangulation";
                case 99: return "Cloak of Poisonousness";
                case 100: return "Scarab of Death";
                default: return "Ring of Clumsiness";
            }
        }

        private static string DifferentEffect(ref Random random)
        {
            switch (Dice.Percentile(ref random))
            {
                case 1: return "unaffected by restorative or curative magic";
                case 2:
                case 3: return "succumbs to physical harm (opponent hits, trap works, etc.)";
                case 4:
                case 5: return "Strength is 3";
                case 6:
                case 7: return "Dexterity is 3";
                case 8:
                case 9: return "Intelligence is 3";
                case 10:
                case 11: return "Constitutino is 3";
                case 12:
                case 13: return "Wisdom is 3";
                case 14:
                case 15: return "Charisma is 3";
                case 16: return "raincloud hovers over player, always rains on player";
                case 17: return "becomes vampire/lich (dependant on character class)";
                case 18: return "succumbs to fever (1 point of Constitution damage per use, recovers at 1/day)";
                case 19:
                case 20:
                case 21: return "character is silenced";
                case 22:
                case 23: return "uncontrollable fear of small animals";
                case 24:
                case 25: return "forget all weapon proficiencies";
                case 26: return "immobile obesity";
                case 27:
                case 28:
                case 29: return "bright 1’ aura surrounds the possessor (opponents are +2 to hit, negate invisibility bonuses)";
                case 30:
                case 31: return String.Format("possessor becomes {0}-gendered", Character.RandomGender(ref random, true));
                case 32: return String.Format("possessor becomes {0}", Character.RandomAlignment(ref random));
                case 33:
                case 34: return "all other items vanish";
                case 35: return "another magical item on the possessor inverts itself";
                case 36:
                case 37:
                case 38:
                case 39: return "possessor takes 1 point of damage";
                case 40: return String.Format("possessor becomes a {0} (stats adjust accordingly)", Character.HumanoidSubtype(ref random));
                case 41: return "all other possessor's magical items negated";
                case 42:
                case 43:
                    string appendage;
                    switch (Dice.d6(ref random))
                    {
                        case 1: appendage = "arm"; break;
                        case 2: appendage = "head"; break;
                        case 3: appendage = "leg"; break;
                        case 4: appendage = "hand"; break;
                        case 5: appendage = "foot"; break;
                        default: appendage = "genitalia"; break;
                    }
                    return String.Format("grow useless {0}, location at DM's discretion", appendage);
                case 44:
                case 45: return "polymorph self (ref random monster encounter, ref random level)";
                case 46:
                case 47: return "colored spots appear on all surfaces";
                case 48:
                case 49:
                case 50: return "age doubles";
                case 51: return "Wisdom and Intelligence stats switch";
                case 52:
                    string emotion;
                    switch (Dice.d10(ref random))
                    {
                        case 1: emotion = "anger"; break;
                        case 2: emotion = "sadness"; break;
                        case 3: emotion = "guilt"; break;
                        case 4: emotion = "love"; break;
                        case 5: emotion = "dread"; break;
                        case 6: emotion = "belligerence"; break;
                        case 7: emotion = "whininess"; break;
                        case 8: emotion = "hunger"; break;
                        case 9: emotion = "nausea"; break;
                        default: emotion = "hyperness"; break;
                    }
                    return String.Format("overcome with {0}", emotion);
                case 53:
                case 54: return "Sneezes violently (incapacitating)";
                case 55:
                case 56:
                case 57:
                case 58:
                case 59:
                case 60:
                case 61: return "falls unconscious with 0 HP";
                case 62:
                case 63:
                case 64: return "cannot speak intelligibly";
                case 65:
                case 66:
                case 67: return "summons a ref random, hostile elemental";
                case 68:
                case 69:
                case 70:
                case 71:
                case 72:
                case 73: return "level is halved";
                case 74:
                case 75:
                case 76:
                case 77:
                case 78: return "insomnia";
                case 79:
                case 80:
                case 81:
                    string phobia;
                    switch (Dice.d10(ref random))
                    {
                        case 1: phobia = "spiders"; break;
                        case 2: phobia = "darkness"; break;
                        case 3: phobia = "people"; break;
                        case 4: phobia = "heights"; break;
                        case 5: phobia = "cramped spaces"; break;
                        case 6: phobia = "magic"; break;
                        case 7: phobia = "the sun"; break;
                        case 8: phobia = "water"; break;
                        case 9: phobia = "outside"; break;
                        default: phobia = "blood"; break;
                    }
                    return String.Format("intense fear of {0}", phobia);
                case 82:
                case 83:
                case 84:
                case 85: return "loses control of bladder and bowels";
                case 86:
                case 87: return "cannot stop dancing";
                case 88:
                    string love;
                    switch (Dice.d4(ref random))
                    {
                        case 1: love = "brotherly"; break;
                        case 2: love = "pet-like"; break;
                        case 3: love = "lustful"; break;
                        default: love = "romantic"; break;
                    }
                    return String.Format("falls in {0} love with closest creature", love);
                case 89: return "wishes to kill all living things within 10'";
                case 90:
                case 91:
                case 92:
                case 93: return "is unable to find any object for which the character actively searches";
                case 94:
                case 95:
                case 96:
                case 97: return "height is halved (weight remains the same)";
                case 98: return "height doubles (weight remains the same)";
                case 99: return "target is enraged";
                default: return "wielder turns to stone";
            }
        }
    }
}