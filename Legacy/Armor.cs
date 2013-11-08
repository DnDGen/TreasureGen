using System;
using System.Collections.Generic;
using System.Text;

namespace Dungeon_Maker
{
    class Armor
    {
        public static string Generate(MagicItems.POWER Power, ref Random random)
        {
            return GenerateHelper(Power, 0, ref random);
        }

        private static string GenerateHelper(MagicItems.POWER Power, int Abilities, ref Random random)
        {
            int bonus = 0; string output;

            switch (Power)
            {
                case MagicItems.POWER.MINOR:
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
                        case 15:
                        case 16:
                        case 17:
                        case 18:
                        case 19:
                        case 20:
                        case 21:
                        case 22:
                        case 23:
                        case 24:
                        case 25:
                        case 26:
                        case 27:
                        case 28:
                        case 29:
                        case 30:
                        case 31:
                        case 32:
                        case 33:
                        case 34:
                        case 35:
                        case 36:
                        case 37:
                        case 38:
                        case 39:
                        case 40:
                        case 41:
                        case 42:
                        case 43:
                        case 44:
                        case 45:
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
                        case 60:
                            bonus = 1;
                            if (Abilities > 0)
                                return String.Format("+{0} {1} of {2} ({3})", bonus, ShieldType(ref random), ShieldSpecialAbility(Power, Abilities, ref bonus, ref random), MagicItems.SpecialQualities(false, bonus, ref random));
                            return output = String.Format("+{0} {1} ({2})", bonus, ShieldType(ref random), MagicItems.SpecialQualities(false, bonus, ref random));
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
                        case 75:
                        case 76:
                        case 77:
                        case 78:
                        case 79:
                        case 80:
                            bonus = 1;
                            if (Abilities > 0)
                                return String.Format("+{0} {1} of {2} ({3})", bonus, ArmorType(ref random), ArmorSpecialAbility(Power, Abilities, ref bonus, ref random), MagicItems.SpecialQualities(false, bonus, ref random));
                            return output = String.Format("+{0} {1} ({2})", bonus, ArmorType(ref random), MagicItems.SpecialQualities(false, bonus, ref random));
                        case 81:
                        case 82:
                        case 83:
                        case 84:
                        case 85:
                            bonus = 2;
                            if (Abilities > 0)
                                return String.Format("+{0} {1} of {2} ({3})", bonus, ShieldType(ref random), ShieldSpecialAbility(Power, Abilities, ref bonus, ref random), MagicItems.SpecialQualities(false, bonus, ref random));
                            return String.Format("+{0} {1} ({2})", bonus, ShieldType(ref random), MagicItems.SpecialQualities(false, bonus, ref random));
                        case 86:
                        case 87:
                            bonus = 2;
                            if (Abilities > 0)
                                return String.Format("+{0} {1} of {2} ({3})", bonus, ArmorType(ref random), ArmorSpecialAbility(Power, Abilities, ref bonus, ref random), MagicItems.SpecialQualities(false, bonus, ref random));
                            return String.Format("+{0} {1} ({2})", bonus, ArmorType(ref random), MagicItems.SpecialQualities(false, bonus, ref random));
                        case 88:
                        case 89:
                        case 90:
                        case 91:
                        case 92:
                        case 93:
                        case 94:
                        case 95:
                        case 96:
                        case 97:
                        case 98:
                        case 99:
                        case 100: return GenerateHelper(Power, Abilities + 1, ref random);
                        default: return "[Error: Minor Armor out of range.  Armor.160]";

                    }
                case MagicItems.POWER.MEDIUM:
                    switch (Dice.Percentile(ref random))
                    {
                        case 1:
                        case 2:
                        case 3:
                        case 4:
                        case 5:
                            bonus = 1;
                            if (Abilities > 0)
                                return String.Format("+{0} {1} of {2} ({3})", bonus, ShieldType(ref random), ShieldSpecialAbility(Power, Abilities, ref bonus, ref random), MagicItems.SpecialQualities(false, bonus, ref random));
                            return String.Format("+{0} {1} ({2})", bonus, ShieldType(ref random), MagicItems.SpecialQualities(false, bonus, ref random));
                        case 6:
                        case 7:
                        case 8:
                        case 9:
                        case 10:
                            bonus = 1;
                            if (Abilities > 0)
                                return String.Format("+{0} {1} of {2} ({3})", bonus, ArmorType(ref random), ArmorSpecialAbility(Power, Abilities, ref bonus, ref random), MagicItems.SpecialQualities(false, bonus, ref random));
                            return String.Format("+{0} {1} ({2})", bonus, ArmorType(ref random), MagicItems.SpecialQualities(false, bonus, ref random));
                        case 11:
                        case 12:
                        case 13:
                        case 14:
                        case 15:
                        case 16:
                        case 17:
                        case 18:
                        case 19:
                        case 20:
                            bonus = 2;
                            if (Abilities > 0)
                                return String.Format("+{0} {1} of {2} ({3})", bonus, ShieldType(ref random), ShieldSpecialAbility(Power, Abilities, ref bonus, ref random), MagicItems.SpecialQualities(false, bonus, ref random));
                            return String.Format("+{0} {1} ({2})", bonus, ShieldType(ref random), MagicItems.SpecialQualities(false, bonus, ref random));
                        case 21:
                        case 22:
                        case 23:
                        case 24:
                        case 25:
                        case 26:
                        case 27:
                        case 28:
                        case 29:
                        case 30:
                            bonus = 2;
                            if (Abilities > 0)
                                return String.Format("+{0} {1} of {2} ({3})", bonus, ArmorType(ref random), ArmorSpecialAbility(Power, Abilities, ref bonus, ref random), MagicItems.SpecialQualities(false, bonus, ref random));
                            return String.Format("+{0} {1} ({2})", bonus, ArmorType(ref random), MagicItems.SpecialQualities(false, bonus, ref random));
                        case 31:
                        case 32:
                        case 33:
                        case 34:
                        case 35:
                        case 36:
                        case 37:
                        case 38:
                        case 39:
                        case 40:
                            bonus = 3;
                            if (Abilities > 0)
                                return String.Format("+{0} {1} of {2} ({3})", bonus, ShieldType(ref random), ShieldSpecialAbility(Power, Abilities, ref bonus, ref random), MagicItems.SpecialQualities(false, bonus, ref random));
                            return String.Format("+{0} {1} ({2})", bonus, ShieldType(ref random), MagicItems.SpecialQualities(false, bonus, ref random));
                        case 41:
                        case 42:
                        case 43:
                        case 44:
                        case 45:
                        case 46:
                        case 47:
                        case 48:
                        case 49:
                        case 50:
                            bonus = 3;
                            if (Abilities > 0)
                                return String.Format("+{0} {1} of {2} ({3})", bonus, ArmorType(ref random), ArmorSpecialAbility(Power, Abilities, ref bonus, ref random), MagicItems.SpecialQualities(false, bonus, ref random));
                            return String.Format("+{0} {1} ({2})", bonus, ArmorType(ref random), MagicItems.SpecialQualities(false, bonus, ref random)); ;
                        case 51:
                        case 52:
                        case 53:
                        case 54:
                        case 55:
                            bonus = 4;
                            if (Abilities > 0)
                                return String.Format("+{0} {1} of {2} ({3})", bonus, ShieldType(ref random), ShieldSpecialAbility(Power, Abilities, ref bonus, ref random), MagicItems.SpecialQualities(false, bonus, ref random));
                            return String.Format("+{0} {1} ({2})", bonus, ShieldType(ref random), MagicItems.SpecialQualities(false, bonus, ref random));
                        case 56:
                        case 57:
                            bonus = 4;
                            if (Abilities > 0)
                                return String.Format("+{0} {1} of {2} ({3})", bonus, ArmorType(ref random), ArmorSpecialAbility(Power, Abilities, ref bonus, ref random), MagicItems.SpecialQualities(false, bonus, ref random));
                            return String.Format("+{0} {1} ({2})", bonus, ArmorType(ref random), MagicItems.SpecialQualities(false, bonus, ref random));
                        case 58:
                        case 59:
                        case 60: return String.Format("{0} ({1})", SpecificArmor(Power, ref bonus, ref random), MagicItems.SpecialQualities(false, bonus, ref random));
                        case 61:
                        case 62:
                        case 63: return String.Format("{0} ({1})", SpecificShield(Power, ref bonus, ref random), MagicItems.SpecialQualities(false, bonus, ref random));
                        default: return GenerateHelper(Power, Abilities + 1, ref random);
                    }
                case MagicItems.POWER.MAJOR:
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
                            bonus = 3;
                            if (Abilities > 0)
                                return String.Format("+{0} {1} of {2} ({3})", bonus, ShieldType(ref random), ShieldSpecialAbility(Power, Abilities, ref bonus, ref random), MagicItems.SpecialQualities(false, bonus, ref random));
                            return String.Format("+{0} {1} ({2})", bonus, ShieldType(ref random), MagicItems.SpecialQualities(false, bonus, ref random));
                        case 9:
                        case 10:
                        case 11:
                        case 12:
                        case 13:
                        case 14:
                        case 15:
                        case 16:
                            bonus = 3;
                            if (Abilities > 0)
                                return String.Format("+{0} {1} of {2} ({3})", bonus, ArmorType(ref random), ArmorSpecialAbility(Power, Abilities, ref bonus, ref random), MagicItems.SpecialQualities(false, bonus, ref random));
                            return String.Format("+{0} {1} ({2})", bonus, ArmorType(ref random), MagicItems.SpecialQualities(false, bonus, ref random));
                        case 17:
                        case 18:
                        case 19:
                        case 20:
                        case 21:
                        case 22:
                        case 23:
                        case 24:
                        case 25:
                        case 26:
                        case 27:
                            bonus = 4;
                            if (Abilities > 0)
                                return String.Format("+{0} {1} of {2} ({3})", bonus, ShieldType(ref random), ShieldSpecialAbility(Power, Abilities, ref bonus, ref random), MagicItems.SpecialQualities(false, bonus, ref random));
                            return String.Format("+{0} {1} ({2})", bonus, ShieldType(ref random), MagicItems.SpecialQualities(false, bonus, ref random));
                        case 28:
                        case 29:
                        case 30:
                        case 31:
                        case 32:
                        case 33:
                        case 34:
                        case 35:
                        case 36:
                        case 37:
                        case 38:
                            bonus = 4;
                            if (Abilities > 0)
                                return String.Format("+{0} {1} of {2} ({3})", bonus, ArmorType(ref random), ArmorSpecialAbility(Power, Abilities, ref bonus, ref random), MagicItems.SpecialQualities(false, bonus, ref random));
                            return String.Format("+{0} {1} ({2})", bonus, ArmorType(ref random), MagicItems.SpecialQualities(false, bonus, ref random));
                        case 39:
                        case 40:
                        case 41:
                        case 42:
                        case 43:
                        case 44:
                        case 45:
                        case 46:
                        case 47:
                        case 48:
                        case 49:
                            bonus = 5;
                            if (Abilities > 0)
                                return String.Format("+{0} {1} of {2} ({3})", bonus, ShieldType(ref random), ShieldSpecialAbility(Power, Abilities, ref bonus, ref random), MagicItems.SpecialQualities(false, bonus, ref random));
                            return String.Format("+{0} {1} ({2})", bonus, ShieldType(ref random), MagicItems.SpecialQualities(false, bonus, ref random));
                        case 50:
                        case 51:
                        case 52:
                        case 53:
                        case 54:
                        case 55:
                        case 56:
                        case 57:
                            bonus = 5;
                            if (Abilities > 0)
                                return String.Format("+{0} {1} of {2} ({3})", bonus, ArmorType(ref random), ArmorSpecialAbility(Power, Abilities, ref bonus, ref random), MagicItems.SpecialQualities(false, bonus, ref random));
                            return String.Format("+{0} {1} ({2})", bonus, ArmorType(ref random), MagicItems.SpecialQualities(false, bonus, ref random));
                        case 58:
                        case 59:
                        case 60: return String.Format("{0} ({1})", SpecificArmor(Power, ref bonus, ref random), MagicItems.SpecialQualities(false, bonus, ref random));
                        case 61:
                        case 62:
                        case 63: return String.Format("{0} ({1})", SpecificShield(Power, ref bonus, ref random), MagicItems.SpecialQualities(false, bonus, ref random));
                        default: return GenerateHelper(Power, Abilities + 1, ref random);
                    }
                default: return ArmorType(ref random);
            }
        }

        private static string ArmorType(ref Random random)
        {
            switch (Dice.Percentile(ref random))
            {
                case 1: return "padded armor";
                case 2: return "leather armor";
                case 3:
                case 4:
                case 5:
                case 6:
                case 7:
                case 8:
                case 9:
                case 10:
                case 11:
                case 12: return "hide armor";
                case 13:
                case 14:
                case 15:
                case 16:
                case 17:
                case 18:
                case 19:
                case 20:
                case 21:
                case 22:
                case 23:
                case 24:
                case 25:
                case 26:
                case 27: return "studded leather armor";
                case 28:
                case 29:
                case 30:
                case 31:
                case 32:
                case 33:
                case 34:
                case 35:
                case 36:
                case 37:
                case 38:
                case 39:
                case 40:
                case 41:
                case 42: return "chain shirt";
                case 43: return "scale mail";
                case 44: return "chainmail";
                case 45:
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
                case 57: return "breastplate";
                case 58: return "splint mail";
                case 59: return "banded mail";
                case 60: return "half-plate";
                default: return "full plate";
            }
        }

        private static string ShieldType(ref Random random)
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
                case 10: return "buckler";
                case 11:
                case 12:
                case 13:
                case 14:
                case 15: return "small wooden shield";
                case 16:
                case 17:
                case 18:
                case 19:
                case 20: return "small steel shield";
                case 21:
                case 22:
                case 23:
                case 24:
                case 25:
                case 26:
                case 27:
                case 28:
                case 29:
                case 30: return "large wooden shield";
                case 96:
                case 97:
                case 98:
                case 99:
                case 100: return "tower shield";
                default: return "large steel shield";
            }
        }

        private static string ArmorSpecialAbility(MagicItems.POWER Power, int Quantity, ref int bonus, ref Random random)
        {
            string output = "";

            while (Quantity > 0)
            {
                switch (Power)
                {
                    case MagicItems.POWER.MINOR:
                        switch (Dice.Percentile(ref random))
                        {
                            case 31:
                            case 32:
                            case 33:
                            case 34:
                            case 35:
                            case 36:
                            case 37:
                            case 38:
                            case 39:
                            case 40:
                            case 41:
                            case 42:
                            case 43:
                            case 44:
                            case 45:
                            case 46:
                            case 47:
                            case 48:
                            case 49:
                            case 50:
                            case 51:
                            case 52:
                                if (bonus + 1 < 11)
                                {
                                    if (output != "")
                                        output += ", ";
                                    output += "slick";
                                    bonus++;
                                    Quantity--;
                                }
                                break;
                            case 53:
                            case 54:
                            case 55:
                            case 56:
                            case 57:
                            case 58:
                            case 59:
                            case 60:
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
                                if (bonus + 1 < 11)
                                {
                                    if (output != "")
                                        output += ", ";
                                    output += "shadow";
                                    bonus++;
                                    Quantity--;
                                }
                                break;
                            case 75:
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
                            case 90:
                            case 91:
                            case 92:
                            case 93:
                            case 94:
                            case 95:
                            case 96:
                                if (bonus + 1 < 11)
                                {
                                    if (output != "")
                                        output += ", ";
                                    output += "silent moves";
                                    bonus++;
                                    Quantity--;
                                }
                                break;
                            case 97:
                            case 98:
                                if (bonus + 3 < 11)
                                {
                                    if (output != "")
                                        output += ", ";
                                    output += "moderate fortification";
                                    bonus += 3;
                                    Quantity--;
                                }
                                break;
                            case 99:
                            case 100: Quantity++; break;
                            default:
                                if (bonus + 1 < 11)
                                {
                                    if (output != "")
                                        output += ", ";
                                    output += "glamered";
                                    bonus++;
                                    Quantity--;
                                }
                                break;
                        } break;
                    case MagicItems.POWER.MEDIUM:
                        switch (Dice.Percentile(ref random))
                        {
                            case 1:
                            case 2:
                                if (bonus + 1 < 11)
                                {
                                    if (output != "")
                                        output += ", ";
                                    output += "light fortification";
                                    bonus++;
                                    Quantity--;
                                }
                                break;
                            case 3:
                            case 4:
                            case 5:
                            case 6:
                            case 7:
                                if (bonus + 1 < 11)
                                {
                                    if (output != "")
                                        output += ", ";
                                    output += "glamered";
                                    bonus++;
                                    Quantity--;
                                }
                                break;
                            case 8:
                            case 9:
                            case 10:
                            case 11:
                            case 12:
                            case 13:
                            case 14:
                            case 15:
                            case 16:
                            case 17:
                            case 18:
                            case 19:
                                if (bonus + 1 < 11)
                                {
                                    if (output != "")
                                        output += ", ";
                                    output += "slick";
                                    bonus++;
                                    Quantity--;
                                }
                                break;
                            case 20:
                            case 21:
                            case 22:
                            case 23:
                            case 24:
                            case 25:
                            case 26:
                            case 27:
                            case 28:
                            case 29:
                            case 30:
                                if (bonus + 1 < 11)
                                {
                                    if (output != "")
                                        output += ", ";
                                    output += "shadow";
                                    bonus++;
                                    Quantity--;
                                }
                                break;
                            case 50:
                                if (bonus + 2 < 11)
                                {
                                    if (output != "")
                                        output += ", ";
                                    output += "spell resistance (13)";
                                    bonus += 2;
                                    Quantity--;
                                }
                                break;
                            case 51:
                            case 52:
                            case 53:
                            case 54:
                            case 55:
                            case 56:
                            case 57:
                            case 58:
                            case 59:
                            case 60:
                                if (bonus + 3 < 11)
                                {
                                    if (output != "")
                                        output += ", ";
                                    output += "ghost touch";
                                    bonus += 3;
                                    Quantity--;
                                }
                                break;
                            case 61:
                            case 62:
                            case 63:
                            case 64:
                            case 65:
                                if (bonus + 3 < 11)
                                {
                                    if (output != "")
                                        output += ", ";
                                    output += "moderate fortification";
                                    bonus += 3;
                                    Quantity--;
                                }
                                break;
                            case 66:
                                if (bonus + 3 < 11)
                                {
                                    if (output != "")
                                        output += ", ";
                                    output += "spell resistance (15)";
                                    bonus += 3;
                                    Quantity--;
                                }
                                break;
                            case 67:
                            case 68:
                            case 69:
                            case 70:
                            case 71:
                                if (bonus + 3 < 11)
                                {
                                    if (output != "")
                                        output += ", ";
                                    output += "acid resistance";
                                    bonus += 3;
                                    Quantity--;
                                }
                                break;
                            case 72:
                            case 73:
                            case 74:
                            case 75:
                            case 76:
                                if (bonus + 3 < 11)
                                {
                                    if (output != "")
                                        output += ", ";
                                    output += "cold resistance";
                                    bonus += 3;
                                    Quantity--;
                                }
                                break;
                            case 77:
                            case 78:
                            case 79:
                            case 80:
                            case 81:
                                if (bonus + 3 < 11)
                                {
                                    if (output != "")
                                        output += ", ";
                                    output += "fire resistance";
                                    bonus += 3;
                                    Quantity--;
                                }
                                break;
                            case 82:
                            case 83:
                            case 84:
                            case 85:
                            case 86:
                                if (bonus + 3 < 11)
                                {
                                    if (output != "")
                                        output += ", ";
                                    output += "lightning resistance";
                                    bonus += 3;
                                    Quantity--;
                                }
                                break;
                            case 87:
                            case 88:
                            case 89:
                            case 90:
                            case 91:
                                if (bonus + 3 < 11)
                                {
                                    if (output != "")
                                        output += ", ";
                                    output += "sonic resistance";
                                    bonus += 3;
                                    Quantity--;
                                }
                                break;
                            case 92:
                            case 93:
                            case 94:
                                if (bonus + 4 < 11)
                                {
                                    if (output != "")
                                        output += ", ";
                                    output += "spell resistance (17)";
                                    bonus += 4;
                                    Quantity--;
                                }
                                break;
                            case 95:
                                if (bonus + 5 < 11)
                                {
                                    if (output != "")
                                        output += ", ";
                                    output += "etherealness";
                                    bonus += 5;
                                    Quantity--;
                                }
                                break;
                            case 96:
                            case 97:
                            case 98:
                                if (bonus + 5 < 11)
                                {
                                    if (output != "")
                                        output += ", ";
                                    output += "heavy fortification";
                                    bonus += 5;
                                    Quantity--;
                                }
                                break;
                            case 99:
                            case 100: Quantity++; break;
                            default:
                                if (bonus + 1 < 11)
                                {
                                    if (output != "")
                                        output += ", ";
                                    output += "silent moves";
                                    bonus++;
                                    Quantity--;
                                }
                                break;
                        } break;
                    case MagicItems.POWER.MAJOR:
                        switch (Dice.Percentile(ref random))
                        {
                            case 1:
                            case 2:
                                if (bonus + 1 < 11)
                                {
                                    if (output != "")
                                        output += ", ";
                                    output += "light fortification";
                                    bonus++;
                                    Quantity--;
                                }
                                break;
                            case 3:
                            case 4:
                            case 5:
                            case 6:
                            case 7:
                            case 8:
                                if (bonus + 1 < 11)
                                {
                                    if (output != "")
                                        output += ", ";
                                    output += "glamered";
                                    bonus++;
                                    Quantity--;
                                }
                                break;
                            case 9:
                                if (bonus + 1 < 11)
                                {
                                    if (output != "")
                                        output += ", ";
                                    output += "slick";
                                    bonus++;
                                    Quantity--;
                                }
                                break;
                            case 10:
                            case 11:
                                if (bonus + 1 < 11)
                                {
                                    if (output != "")
                                        output += ", ";
                                    output += "shadow";
                                    bonus++;
                                    Quantity--;
                                }
                                break;
                            case 12:
                            case 13:
                            case 14:
                                if (bonus + 1 < 11)
                                {
                                    if (output != "")
                                        output += ", ";
                                    output += "silent moves";
                                    bonus++;
                                    Quantity--;
                                }
                                break;
                            case 15:
                            case 16:
                                if (bonus + 2 < 11)
                                {
                                    if (output != "")
                                        output += ", ";
                                    output += "spell resistance (13)";
                                    bonus += 2;
                                    Quantity--;
                                }
                                break;
                            case 17:
                            case 18:
                            case 19:
                            case 20:
                            case 21:
                                if (bonus + 3 < 11)
                                {
                                    if (output != "")
                                        output += ", ";
                                    output += "ghost touch";
                                    bonus += 3;
                                    Quantity--;
                                }
                                break;
                            case 22:
                            case 23:
                                if (bonus + 3 < 11)
                                {
                                    if (output != "")
                                        output += ", ";
                                    output += "invulnerability";
                                    bonus += 3;
                                    Quantity--;
                                }
                                break;
                            case 24:
                            case 25:
                            case 26:
                            case 27:
                                if (bonus + 3 < 11)
                                {
                                    if (output != "")
                                        output += ", ";
                                    output += "moderate fortification";
                                    bonus += 3;
                                    Quantity--;
                                }
                                break;
                            case 28:
                            case 29:
                                if (bonus + 3 < 11)
                                {
                                    if (output != "")
                                        output += ", ";
                                    output += "spell resistance (15)";
                                    bonus += 3;
                                    Quantity--;
                                }
                                break;
                            case 30:
                            case 31:
                                if (bonus + 3 < 11)
                                {
                                    if (output != "")
                                        output += ", ";
                                    output += "acid resistance";
                                    bonus += 3;
                                    Quantity--;
                                }
                                break;
                            case 32:
                            case 33:
                            case 34:
                            case 35:
                            case 36:
                            case 37:
                            case 38:
                            case 39:
                            case 40:
                            case 41:
                                if (bonus + 3 < 11)
                                {
                                    if (output != "")
                                        output += ", ";
                                    output += "cold resistance";
                                    bonus += 3;
                                    Quantity--;
                                }
                                break;
                            case 42:
                            case 43:
                            case 44:
                            case 45:
                            case 46:
                            case 47:
                            case 48:
                            case 49:
                            case 50:
                            case 51:
                                if (bonus + 3 < 11)
                                {
                                    if (output != "")
                                        output += ", ";
                                    output += "fire resistance";
                                    bonus += 3;
                                    Quantity--;
                                }
                                break;
                            case 52:
                            case 53:
                            case 54:
                            case 55:
                            case 56:
                            case 57:
                            case 58:
                            case 59:
                            case 60:
                            case 61:
                                if (bonus + 3 < 11)
                                {
                                    if (output != "")
                                        output += ", ";
                                    output += "lightning resistance";
                                    bonus += 3;
                                    Quantity--;
                                }
                                break;
                            case 62:
                            case 63:
                            case 64:
                                if (bonus + 3 < 11)
                                {
                                    if (output != "")
                                        output += ", ";
                                    output += "sonic resistance";
                                    bonus += 3;
                                    Quantity--;
                                }
                                break;
                            case 65:
                            case 66:
                            case 67:
                                if (bonus + 4 < 11)
                                {
                                    if (output != "")
                                        output += ", ";
                                    output += "spell resistance (17)";
                                    bonus += 4;
                                    Quantity--;
                                }
                                break;
                            case 68:
                            case 69:
                                if (bonus + 5 < 11)
                                {
                                    if (output != "")
                                        output += ", ";
                                    output += "etherealness";
                                    bonus += 5;
                                    Quantity--;
                                }
                                break;
                            case 70:
                            case 71:
                            case 72:
                                if (bonus + 5 < 11)
                                {
                                    if (output != "")
                                        output += ", ";
                                    output += "heavy fortification";
                                    bonus += 5;
                                    Quantity--;
                                }
                                break;
                            case 73:
                            case 74:
                                if (bonus + 5 < 11)
                                {
                                    if (output != "")
                                        output += ", ";
                                    output += "spell resistance (19)";
                                    bonus += 5;
                                    Quantity--;
                                }
                                break;
                            default: Quantity++; break;
                        } break;
                    default: return "[ERROR: Nonpowered armor special ability.]";
                }

                if (bonus == 10)
                    return output;
            }

            return output;
        }

        private static string ShieldSpecialAbility(MagicItems.POWER Power, int Quantity, ref int bonus, ref Random random)
        {
            string output = "";

            while (Quantity > 0)
            {
                switch (Power)
                {
                    case MagicItems.POWER.MINOR:
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
                            case 15:
                            case 16:
                            case 17:
                            case 18:
                            case 19:
                            case 20:
                            case 21:
                            case 22:
                            case 23:
                            case 24:
                            case 25:
                            case 26:
                            case 27:
                            case 28:
                            case 29:
                            case 30:
                                if (bonus + 1 < 11)
                                {
                                    if (output != "")
                                        output += ", ";
                                    output += "bashing";
                                    bonus++;
                                    Quantity--;
                                }
                                break;
                            case 31:
                            case 32:
                            case 33:
                            case 34:
                            case 35:
                            case 36:
                            case 37:
                            case 38:
                            case 39:
                            case 40:
                            case 41:
                            case 42:
                            case 43:
                            case 44:
                            case 45:
                            case 46:
                            case 47:
                            case 48:
                            case 49:
                            case 50:
                                if (bonus + 1 < 11)
                                {
                                    if (output != "")
                                        output += ", ";
                                    output += "blinding";
                                    bonus++;
                                    Quantity--;
                                }
                                break;
                            case 51:
                            case 52:
                            case 53:
                            case 54:
                            case 55:
                            case 56:
                            case 57:
                            case 58:
                            case 59:
                            case 60:
                                if (bonus + 1 < 11)
                                {
                                    if (output != "")
                                        output += ", ";
                                    output += "light fortification";
                                    bonus++;
                                    Quantity--;
                                }
                                break;
                            case 100: Quantity++; break;
                            default:
                                if (bonus + 2 < 11)
                                {
                                    if (output != "")
                                        output += ", ";
                                    output += "arrow deflection";
                                    bonus += 2;
                                    Quantity--;
                                }
                                break;
                        } break;
                    case MagicItems.POWER.MEDIUM:
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
                                if (bonus + 2 < 11)
                                {
                                    if (output != "")
                                        output += ", ";
                                    output += "arrow deflection";
                                    bonus += 2;
                                    Quantity--;
                                }
                                break;
                            case 11:
                            case 12:
                            case 13:
                            case 14:
                            case 15:
                            case 16:
                                if (bonus + 2 < 11)
                                {
                                    if (output != "")
                                        output += ", ";
                                    output += "animated";
                                    bonus += 2;
                                    Quantity--;
                                }
                                break;
                            case 17:
                            case 18:
                            case 19:
                            case 20:
                                if (bonus + 2 < 11)
                                {
                                    if (output != "")
                                        output += ", ";
                                    output += "spell resistance (13)";
                                    bonus += 2;
                                    Quantity--;
                                }
                                break;
                            case 21:
                            case 22:
                            case 23:
                            case 24:
                            case 25:
                                if (bonus + 3 < 11)
                                {
                                    if (output != "")
                                        output += ", ";
                                    output += "ghost touch";
                                    bonus += 3;
                                    Quantity--;
                                }
                                break;
                            case 26:
                            case 27:
                            case 28:
                            case 29:
                            case 30:
                                if (bonus + 3 < 11)
                                {
                                    if (output != "")
                                        output += ", ";
                                    output += "moderate fortification";
                                    bonus += 3;
                                    Quantity--;
                                }
                                break;
                            case 31:
                            case 32:
                            case 33:
                            case 34:
                            case 35:
                            case 36:
                            case 37:
                            case 38:
                            case 39:
                            case 40:
                                if (bonus + 3 < 11)
                                {
                                    if (output != "")
                                        output += ", ";
                                    output += "acid resistance";
                                    bonus += 3;
                                    Quantity--;
                                }
                                break;
                            case 41:
                            case 42:
                            case 43:
                            case 44:
                            case 45:
                            case 46:
                            case 47:
                            case 48:
                            case 49:
                            case 50:
                                if (bonus + 3 < 11)
                                {
                                    if (output != "")
                                        output += ", ";
                                    output += "cold resistance";
                                    bonus += 3;
                                    Quantity--;
                                }
                                break;
                            case 51:
                            case 52:
                            case 53:
                            case 54:
                            case 55:
                            case 56:
                            case 57:
                            case 58:
                            case 59:
                            case 60:
                                if (bonus + 3 < 11)
                                {
                                    if (output != "")
                                        output += ", ";
                                    output += "fire resistance";
                                    bonus += 3;
                                    Quantity--;
                                }
                                break;
                            case 71:
                            case 72:
                            case 73:
                            case 74:
                            case 75:
                            case 76:
                            case 77:
                            case 78:
                            case 79:
                            case 80:
                                if (bonus + 3 < 11)
                                {
                                    if (output != "")
                                        output += ", ";
                                    output += "sonic resistance";
                                    bonus += 3;
                                    Quantity--;
                                }
                                break;
                            case 81:
                            case 82:
                            case 83:
                            case 84:
                            case 85:
                            case 86:
                            case 87:
                            case 88:
                            case 89:
                            case 90:
                                if (bonus + 5 < 11)
                                {
                                    if (output != "")
                                        output += ", ";
                                    output += "reflecting";
                                    bonus += 5;
                                    Quantity--;
                                }
                                break;
                            case 91:
                            case 92:
                            case 93:
                            case 94:
                            case 95:
                            case 96:
                            case 97:
                            case 98:
                            case 99:
                            case 100: Quantity++; break;
                            default:
                                if (bonus + 3 < 11)
                                {
                                    if (output != "")
                                        output += ", ";
                                    output += "lightning resistance";
                                    bonus += 3;
                                    Quantity--;
                                }
                                break;
                        } break;
                    case MagicItems.POWER.MAJOR:
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
                            case 15:
                                if (bonus + 2 < 11)
                                {
                                    if (output != "")
                                        output += ", ";
                                    output += "animated";
                                    bonus += 2;
                                    Quantity--;
                                }
                                break;
                            case 16:
                            case 17:
                            case 18:
                            case 19:
                            case 20:
                                if (bonus + 2 < 11)
                                {
                                    if (output != "")
                                        output += ", ";
                                    output += "spell resistance (13)";
                                    bonus += 2;
                                    Quantity--;
                                }
                                break;
                            case 21:
                            case 22:
                            case 23:
                            case 24:
                            case 25:
                                if (bonus + 3 < 11)
                                {
                                    if (output != "")
                                        output += ", ";
                                    output += "ghost touch";
                                    bonus += 3;
                                    Quantity--;
                                }
                                break;
                            case 26:
                            case 27:
                            case 28:
                            case 29:
                            case 30:
                            case 31:
                            case 32:
                            case 33:
                            case 34:
                            case 35:
                                if (bonus + 3 < 11)
                                {
                                    if (output != "")
                                        output += ", ";
                                    output += "moderate fortification";
                                    bonus += 3;
                                    Quantity--;
                                }
                                break;
                            case 36:
                            case 37:
                            case 38:
                                if (bonus + 3 < 11)
                                {
                                    if (output != "")
                                        output += ", ";
                                    output += "acid resistance";
                                    bonus += 3;
                                    Quantity--;
                                }
                                break;
                            case 39:
                            case 40:
                            case 41:
                                if (bonus + 3 < 11)
                                {
                                    if (output != "")
                                        output += ", ";
                                    output += "cold resistance";
                                    bonus += 3;
                                    Quantity--;
                                }
                                break;
                            case 42:
                            case 43:
                            case 44:
                                if (bonus + 3 < 11)
                                {
                                    if (output != "")
                                        output += ", ";
                                    output += "fire resistance";
                                    bonus += 3;
                                    Quantity--;
                                }
                                break;
                            case 45:
                            case 46:
                            case 47:
                                if (bonus + 3 < 11)
                                {
                                    if (output != "")
                                        output += ", ";
                                    output += "lightning resistance";
                                    bonus += 3;
                                    Quantity--;
                                }
                                break;
                            case 48:
                            case 49:
                            case 50:
                                if (bonus + 3 < 11)
                                {
                                    if (output != "")
                                        output += ", ";
                                    output += "sonic resistance";
                                    bonus += 3;
                                    Quantity--;
                                }
                                break;
                            case 51:
                            case 52:
                            case 53:
                            case 54:
                            case 55:
                                if (bonus + 3 < 11)
                                {
                                    if (output != "")
                                        output += ", ";
                                    output += "spell resistance (15)";
                                    bonus += 3;
                                    Quantity--;
                                }
                                break;
                            case 56:
                            case 57:
                            case 58:
                            case 59:
                            case 60:
                                if (bonus + 4 < 11)
                                {
                                    if (output != "")
                                        output += ", ";
                                    output += "spell resistance (17)";
                                    bonus += 4;
                                    Quantity--;
                                }
                                break;
                            case 61:
                            case 62:
                            case 63:
                            case 64:
                            case 65:
                                if (bonus + 5 < 11)
                                {
                                    if (output != "")
                                        output += ", ";
                                    output += "heavy fortification";
                                    bonus += 5;
                                    Quantity--;
                                }
                                break;
                            case 66:
                            case 67:
                            case 68:
                            case 69:
                            case 70:
                                if (bonus + 5 < 11)
                                {
                                    if (output != "")
                                        output += ", ";
                                    output += "reflecting";
                                    bonus += 5;
                                    Quantity--;
                                }
                                break;
                            case 71:
                            case 72:
                            case 73:
                            case 74:
                            case 75:
                            case 76:
                            case 77:
                            case 78:
                            case 79:
                            case 80:
                                if (bonus + 5 < 11)
                                {
                                    if (output != "")
                                        output += ", ";
                                    output += "spell resistance (19)";
                                    bonus += 5;
                                    Quantity--;
                                }
                                break;
                            default: Quantity++; break;
                        } break;
                    default: return "[ERROR: Nonpowered shield special ability]";
                }

                if (bonus == 10)
                    return output;
            }

            return output;
        }

        private static string SpecificArmor(MagicItems.POWER Power, ref int bonus, ref Random random)
        {
            switch (Power)
            {
                case MagicItems.POWER.MEDIUM:
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
                        case 10: return "mithral shirt";
                        case 11:
                        case 12:
                        case 13:
                        case 14:
                        case 15:
                        case 16:
                        case 17:
                        case 18:
                        case 19:
                        case 20:
                        case 21:
                        case 22:
                        case 23:
                        case 24:
                        case 25: return "elven chain";
                        case 26:
                        case 27:
                        case 28:
                        case 29:
                        case 30:
                        case 31:
                        case 32:
                        case 33:
                        case 34:
                        case 35:
                            bonus = 2;
                            return "Rhino hide";
                        case 36:
                        case 37:
                        case 38:
                        case 39:
                        case 40:
                        case 41:
                        case 42:
                        case 43:
                        case 44:
                        case 45: return "adamantine breastplate";
                        case 71:
                        case 72:
                        case 73:
                        case 74:
                        case 75:
                        case 76:
                        case 77:
                        case 78:
                        case 79:
                        case 80:
                            bonus = 4;
                            return "plate armor of the deep";
                        case 81:
                        case 82:
                        case 83:
                        case 84:
                        case 85:
                        case 86:
                        case 87:
                        case 88:
                        case 89:
                        case 90:
                            bonus = 4;
                            return "banded mail of luck";
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
                            bonus = 4;
                            return "breastplate of command";
                        default:
                            bonus = 3;
                            return "dwarven plate";
                    }
                case MagicItems.POWER.MAJOR:
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
                            bonus = 4;
                            return "plate armor of the deep";
                        case 41:
                        case 42:
                        case 43:
                        case 44:
                        case 45:
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
                        case 60:
                            bonus = 4;
                            return "breastplate of command";
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
                        case 75:
                        case 76:
                        case 77:
                        case 78:
                        case 79:
                        case 80:
                            bonus = 5;
                            return "celestial armor";
                        case 81:
                        case 82:
                        case 83:
                        case 84:
                        case 85:
                        case 86:
                        case 87:
                        case 88:
                        case 89:
                        case 90:
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
                            bonus = 6;
                            return "demon armor";
                        default:
                            bonus = 4;
                            return "banded mail of luck";
                    }
                default: return "[ERROR: Minor or nonpowered specific armor  Armor.1780]";
            }
        }

        private static string SpecificShield(MagicItems.POWER Power, ref int bonus, ref Random random)
        {
            switch (Power)
            {
                case MagicItems.POWER.MEDIUM:
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
                        case 10: return "darkwood shield";
                        case 11:
                        case 12:
                        case 13:
                        case 14:
                        case 15:
                        case 16:
                        case 17:
                        case 18: return "mithral large shield";
                        case 19:
                        case 20:
                        case 21:
                        case 22:
                        case 23:
                        case 24:
                        case 25: return "adamantine shield";
                        case 26:
                        case 27:
                        case 28:
                        case 29:
                        case 30:
                        case 31:
                        case 32:
                        case 33:
                        case 34:
                        case 35:
                        case 36:
                        case 37:
                        case 38:
                        case 39:
                        case 40:
                        case 41:
                        case 42:
                        case 43:
                        case 44:
                        case 45:
                            bonus = 1;
                            return "spined shield";
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
                        case 60:
                        case 61:
                        case 62:
                        case 63:
                        case 64:
                        case 65:
                            string spell = "";
                            if (Dice.Percentile(ref random) <= 50)
                            {
                                if (Dice.Percentile(ref random) <= 80)
                                    spell = String.Format(" (has {0})", Scrolls.RandomSpell(ref random, 9, Scrolls.SPELLTYPE.DIVINE));
                                else
                                    spell = String.Format(" (has {0})", Scrolls.RandomSpell(ref random, 9, Scrolls.SPELLTYPE.ARCANE));
                            }
                            bonus = 1;
                            return String.Format("caster's shield{0}", spell);
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
                            bonus = 3;
                            return "winged shield";
                        default:
                            bonus = 3;
                            return "lion's shield";
                    }
                case MagicItems.POWER.MAJOR:
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
                        case 15:
                        case 16:
                        case 17:
                        case 18:
                        case 19:
                        case 20:
                            bonus = 1;
                            return "spined shield";
                        case 21:
                        case 22:
                        case 23:
                        case 24:
                        case 25:
                        case 26:
                        case 27:
                        case 28:
                        case 29:
                        case 30:
                        case 31:
                        case 32:
                        case 33:
                        case 34:
                        case 35:
                        case 36:
                        case 37:
                        case 38:
                        case 39:
                        case 40:
                            string spell = "";
                            if (Dice.Percentile(ref random) <= 50)
                            {
                                if (Dice.Percentile(ref random) <= 80)
                                    spell = String.Format(" (has {0})", Scrolls.RandomSpell(ref random, 9, Scrolls.SPELLTYPE.DIVINE));
                                else
                                    spell = String.Format(" (has {0})", Scrolls.RandomSpell(ref random, 9, Scrolls.SPELLTYPE.ARCANE));
                            }
                            bonus = 1;
                            return String.Format("caster's shield{0}", spell);
                        case 41:
                        case 42:
                        case 43:
                        case 44:
                        case 45:
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
                        case 60:
                            bonus = 3;
                            return "lion's shield";
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
                        case 75:
                        case 76:
                        case 77:
                        case 78:
                        case 79:
                        case 80:
                            bonus = 3;
                            return "winged shield";
                        default:
                            bonus = 7;
                            return "absorbing shield";
                    }
                default: return "[ERROR: minor or nonpowered specific shield.  Armor.1788]";
            }
        }            
    }
}