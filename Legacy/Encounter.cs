using System;
using System.Collections.Generic;
using System.Text;

namespace Dungeon_Maker
{
    class Encounter
    {
        public static string Generate(int Level, ref Random random)
        {
            switch (Dice.Percentile(ref random))
            {
                case 1:
                case 2:
                case 3:
                case 4:
                case 5:
                    switch (Level)
                    {
                        case 1: return Level1(null, ref random);
                        case 2: return Level1("2", ref random);
                        case 3: return Level1("3", ref random);
                        case 4: return Level1("4", ref random);
                        case 5:
                        case 6: return Level2("4", ref random);
                        case 7: return Level3("4", ref random);
                        case 8: return Level4("4", ref random);
                        case 9: return Level5("4", ref random);
                        case 10: return Level6("4", ref random);
                        case 11: return Level7("4", ref random);
                        case 12: return Level8("4", ref random);
                        case 13: return Level9("4", ref random);
                        case 14: return Level10("4", ref random);
                        case 15: return Level11("4", ref random);
                        case 16: return Level12("4", ref random);
                        case 17: return Level13("4", ref random);
                        case 18: return Level14("4", ref random);
                        case 19: return Level15("4", ref random);
                        case 20: return Level16("4", ref random);
                        case 21: return Level17("4", ref random);
                        case 22: return Level18("4", ref random);
                        case 23: return Level19("4", ref random);
                        case 24: return Level20("4", ref random);
                        default: return String.Format("Level {0} epic encounter", Level);
                    }
                case 6:
                case 7:
                case 8:
                case 9:
                case 10:
                    switch (Level)
                    {
                        case 1: return Level1(null, ref random);
                        case 2: return Level1("2", ref random);
                        case 3: return Level1("3", ref random);
                        case 4: return Level1("4", ref random);
                        case 5: return Level2("3", ref random);
                        case 6: return Level3("3", ref random);
                        case 7: return Level4("3", ref random);
                        case 8: return Level5("3", ref random);
                        case 9: return Level6("3", ref random);
                        case 10: return Level7("3", ref random);
                        case 11: return Level8("3", ref random);
                        case 12: return Level9("3", ref random);
                        case 13: return Level10("3", ref random);
                        case 14: return Level11("3", ref random);
                        case 15: return Level12("3", ref random);
                        case 16: return Level13("3", ref random);
                        case 17: return Level14("3", ref random);
                        case 18: return Level15("3", ref random);
                        case 19: return Level16("3", ref random);
                        case 20: return Level17("3", ref random);
                        case 21: return Level18("3", ref random);
                        case 22: return Level19("3", ref random);
                        case 23: return Level20("3", ref random);
                        default: return String.Format("Level {0} epic encounter", Level);
                    }
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
                    switch (Level)
                    {
                        case 1: return Level1(null, ref random);
                        case 2: return Level1("2", ref random);
                        case 3: return Level2("3/2", ref random);
                        case 4: return Level2("2", ref random);
                        case 5: return Level3("2", ref random);
                        case 6: return Level4("2", ref random);
                        case 7: return Level5("2", ref random);
                        case 8: return Level6("2", ref random);
                        case 9: return Level7("2", ref random);
                        case 10: return Level8("2", ref random);
                        case 11: return Level9("2", ref random);
                        case 12: return Level10("2", ref random);
                        case 13: return Level11("2", ref random);
                        case 14: return Level12("2", ref random);
                        case 15: return Level13("2", ref random);
                        case 16: return Level14("2", ref random);
                        case 17: return Level15("2", ref random);
                        case 18: return Level16("2", ref random);
                        case 19: return Level17("2", ref random);
                        case 20: return Level18("2", ref random);
                        case 21: return Level19("2", ref random);
                        case 22: return Level20("2", ref random);
                        default: return String.Format("Level {0} epic encounter", Level);
                    }
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
                    switch (Level)
                    {
                        case 1: return Level1(null, ref random);
                        case 2: return Level2(null, ref random);
                        case 3: return Level2("3/2", ref random);
                        case 4: return Level3("3/2", ref random);
                        case 5: return Level4("3/2", ref random);
                        case 6: return Level5("3/2", ref random);
                        case 7: return Level6("3/2", ref random);
                        case 8: return Level7("3/2", ref random);
                        case 9: return Level8("3/2", ref random);
                        case 10: return Level9("3/2", ref random);
                        case 11: return Level10("3/2", ref random);
                        case 12: return Level11("3/2", ref random);
                        case 13: return Level12("3/2", ref random);
                        case 14: return Level13("3/2", ref random);
                        case 15: return Level14("3/2", ref random);
                        case 16: return Level15("3/2", ref random);
                        case 17: return Level16("3/2", ref random);
                        case 18: return Level17("3/2", ref random);
                        case 19: return Level18("3/2", ref random);
                        case 20: return Level19("3/2", ref random);
                        case 21: return Level20("3/2", ref random);
                        default: return String.Format("Level {0} epic encounter", Level);
                    }
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
                    switch (Level)
                    {
                        case 1: return Level2("1/2", ref random);
                        case 2: return Level3("2/3", ref random);
                        case 3: return Level4("2/3", ref random);
                        case 4: return Level5("2/3", ref random);
                        case 5: return Level6("2/3", ref random);
                        case 6: return Level7("2/3", ref random);
                        case 7: return Level8("2/3", ref random);
                        case 8: return Level9("2/3", ref random);
                        case 9: return Level10("2/3", ref random);
                        case 10: return Level11("2/3", ref random);
                        case 11: return Level12("2/3", ref random);
                        case 12: return Level13("2/3", ref random);
                        case 13: return Level14("2/3", ref random);
                        case 14: return Level15("2/3", ref random);
                        case 15: return Level16("2/3", ref random);
                        case 16: return Level17("2/3", ref random);
                        case 17: return Level18("2/3", ref random);
                        case 18: return Level19("2/3", ref random);
                        case 19: return Level19(null, ref random);
                        case 20: return Level20(null, ref random);
                        default: return String.Format("Level {0} epic encounter", Level);
                    }
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
                    switch (Level)
                    {
                        case 1: return Level2("1/2", ref random);
                        case 2: return Level4("1/2", ref random);
                        case 3: return Level5("1/2", ref random);
                        case 4: return Level6("1/2", ref random);
                        case 5: return Level7("1/2", ref random);
                        case 6: return Level8("1/2", ref random);
                        case 7: return Level9("1/2", ref random);
                        case 8: return Level10("1/2", ref random);
                        case 9: return Level11("1/2", ref random);
                        case 10: return Level12("1/2", ref random);
                        case 11: return Level13("1/2", ref random);
                        case 12: return Level14("1/2", ref random);
                        case 13: return Level15("1/2", ref random);
                        case 14: return Level16("1/2", ref random);
                        case 15: return Level17("1/2", ref random);
                        case 16: return Level18("1/2", ref random);
                        case 17: return Level19("1/2", ref random);
                        case 18: return Level20("1/2", ref random);
                        case 19: return Level20("2/3", ref random);
                        case 20: return Level20(null, ref random);
                        default: return String.Format("Level {0} epic encounter", Level);
                    }
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
                    switch (Level)
                    {
                        case 1: return Level3("1/3", ref random);
                        case 2: return Level5("1/3", ref random);
                        case 3: return Level6("1/3", ref random);
                        case 4: return Level7("1/3", ref random);
                        case 5: return Level8("1/3", ref random);
                        case 6: return Level9("1/3", ref random);
                        case 7: return Level10("1/3", ref random);
                        case 8: return Level11("1/3", ref random);
                        case 9: return Level12("1/3", ref random);
                        case 10: return Level13("1/3", ref random);
                        case 11: return Level14("1/3", ref random);
                        case 12: return Level15("1/3", ref random);
                        case 13: return Level16("1/3", ref random);
                        case 14: return Level17("1/3", ref random);
                        case 15: return Level18("1/3", ref random);
                        case 16: return Level19("1/3", ref random);
                        case 17: return Level20("1/3", ref random);
                        case 18: return Level20("1/2", ref random);
                        case 19: return Level20("2/3", ref random);
                        case 20: return Level20(null, ref random);
                        default: return String.Format("Level {0} epic encounter", Level);
                    }
                default:
                    switch (Level)
                    {
                        case 1: return Level1(null, ref random);
                        case 2: return Level2(null, ref random);
                        case 3: return Level3(null, ref random);
                        case 4: return Level4(null, ref random);
                        case 5: return Level5(null, ref random);
                        case 6: return Level6(null, ref random);
                        case 7: return Level7(null, ref random);
                        case 8: return Level8(null, ref random);
                        case 9: return Level9(null, ref random);
                        case 10: return Level10(null, ref random);
                        case 11: return Level11(null, ref random);
                        case 12: return Level12(null, ref random);
                        case 13: return Level13(null, ref random);
                        case 14: return Level14(null, ref random);
                        case 15: return Level15(null, ref random);
                        case 16: return Level16(null, ref random);
                        case 17: return Level17(null, ref random);
                        case 18: return Level18(null, ref random);
                        case 19: return Level19(null, ref random);
                        case 20: return Level20(null, ref random);
                        default: return String.Format("Level {0} epic encounter", Level);
                    }
            }
        }

        private static string Level1(string Modifier, ref Random random)
        {
            switch (Dice.Percentile(ref random))
            {
                case 1:
                case 2:
                case 3:
                case 4:
                    string output = String.Format("{0} medium-size monstrous centipedes", Dice.Roll(3, 0, Modifier, ref random));
                    if (Dice.Percentile(ref random) <= 20)
                        return String.Format("{0} with {1}", output, Treasure.Generate(1, ref random));
                    return output;
                case 5:
                case 6:
                case 7:
                case 8:
                case 9:
                    output = String.Format("{0} dire rats", Dice.Roll(3, 1, Modifier, ref random));
                    if (Dice.Percentile(ref random) <= 20)
                        return String.Format("{0} with {1}", output, Treasure.Generate(1, ref random));
                    return output;
                case 10:
                case 11:
                case 12:
                case 13:
                case 14:
                    output = String.Format("{0} giant fire beetles", Dice.Roll(3, 1, Modifier, ref random));
                    if (Dice.Percentile(ref random) <= 20)
                        return String.Format("{0} with {1}", output, Treasure.Generate(1, ref random));
                    return output;
                case 15:
                case 16:
                case 17:
                    output = String.Format("{0} small monstrous scorpions", Dice.Roll(3, 0, Modifier, ref random));
                    if (Dice.Percentile(ref random) <= 20)
                        return String.Format("{0} with {1}", output, Treasure.Generate(1, ref random));
                    return output;
                case 18:
                case 19:
                case 20:
                    output = String.Format("{0} small monstrous spiders", Dice.Roll(3, 0, Modifier, ref random));
                    if (Dice.Percentile(ref random) <= 20)
                        return String.Format("{0} with {1}", output, Treasure.Generate(1, ref random));
                    return output;
                case 21:
                case 22:
                case 23:
                case 24:
                case 25:
                    output = String.Format("{0} {1}", Dice.Roll(1, 0, Modifier, ref random), Dragon(1, ref random));
                    if (Dice.Percentile(ref random) <= 80)
                        return String.Format("{0} with {1}", output, Treasure.Generate(3, ref random));
                    return output;
                case 26:
                case 27:
                case 28:
                case 29:
                case 30:
                    output = String.Format("{0} dwarven warriors", Dice.Roll(3, 0, Modifier, ref random));
                    if (Dice.Percentile(ref random) <= 80)
                        return String.Format("{0} with {1}", output, Treasure.Generate(2, ref random));
                    return output;
                case 31:
                case 32:
                case 33:
                case 34:
                case 35:
                    output = String.Format("{0} elven warriors", Dice.Roll(3, 0, Modifier, ref random));
                    if (Dice.Percentile(ref random) <= 80)
                        return String.Format("{0} with {1}", output, Treasure.Generate(2, ref random));
                    return output;
                case 36:
                case 37:
                case 38:
                case 39:
                case 40:
                    output = "";
                    for (int i = Dice.Roll(1, 0, Modifier, ref random); i > 0; i--)
                        output += String.Format(" {0},", Character.Generate(1, false, ref random));
                    return output;
                case 41:
                case 42:
                case 43:
                case 44:
                case 45:
                    output = String.Format("{0} darkmantle", Dice.Roll(1, 0, Modifier, ref random));
                    if (Dice.Percentile(ref random) <= 50)
                        return String.Format("{0} with {1}", output, Treasure.Generate(2, ref random));
                    return output;
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
                    output = String.Format("{0} krenshar", Dice.Roll(1, 0, Modifier, ref random));
                    if (Dice.Percentile(ref random) <= 50)
                        return String.Format("{0} with {1}", output, Treasure.Generate(2, ref random));
                    return output;
                case 56:
                case 57:
                case 58:
                case 59:
                case 60:
                    output = String.Format("{0} lemure", Dice.Roll(1, 0, Modifier, ref random));
                    if (Dice.Percentile(ref random) <= 50)
                        return String.Format("{0} with {1}", output, Treasure.Generate(2, ref random));
                    return output;
                case 61:
                case 62:
                case 63:
                case 64:
                case 65:
                    if (Dice.Roll(4, 2, Modifier, ref random) != 0)
                    {
                        output = String.Format("{0} goblins", Dice.Roll(4, 2, Modifier, ref random));
                        if (Dice.Percentile(ref random) <= 80)
                            return String.Format("{0} with {1}", output, Treasure.Generate(2, ref random));
                        return output;
                    }
                    else
                        return Level1(Modifier, ref random);
                case 66:
                case 67:
                case 68:
                case 69:
                case 70:
                    output = String.Format("{0} hobgoblins and {1} goblins", Dice.Roll(1, 0, Modifier, ref random), Dice.Roll(3, 0, Modifier, ref random));
                    if (Dice.Percentile(ref random) <= 80)
                        return String.Format("{0} with {1}", output, Treasure.Generate(2, ref random));
                    return output;
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
                    if (Dice.Roll(6, 3, Modifier, ref random) != 0)
                    {
                        output = String.Format("{0} kobolds", Dice.Roll(6, 3, Modifier, ref random));
                        if (Dice.Percentile(ref random) <= 80)
                            return String.Format("{0} with {1}", output, Treasure.Generate(2, ref random));
                        return output;
                    }
                    else
                        return Level1(Modifier, ref random);
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
                    output = String.Format("{0} medium-sized skeletons", Dice.Roll(3, 1, Modifier, ref random));
                    if (Dice.Percentile(ref random) <= 50)
                        return String.Format("{0} with {1}", output, Treasure.Generate(1, ref random));
                    return output;
                default:
                    output = String.Format("{0} human medium-sized zombies", Dice.Roll(3, 0, Modifier, ref random));
                    if (Dice.Percentile(ref random) <= 50)
                        return String.Format("{0} with {1}", output, Treasure.Generate(1, ref random));
                    return output;
            }
        }

        private static string Level2(string Modifier, ref Random random)
        {
            switch (Dice.Percentile(ref random))
            {
                case 1:
                case 2:
                case 3:
                case 4:
                case 5:
                    string output = String.Format("{0} large monstrous centipedes", Dice.Roll(3, 0, Modifier, ref random));
                    if (Dice.Percentile(ref random) <= 20)
                        return String.Format("{0} with {1}", output, Treasure.Generate(2, ref random));
                    return output;
                case 6:
                case 7:
                case 8:
                case 9:
                case 10:
                    output = String.Format("{0} giant ants", Dice.Roll(3, 0, Modifier, ref random));
                    if (Dice.Percentile(ref random) <= 20)
                        return String.Format("{0} with {1}", output, Treasure.Generate(2, ref random));
                    return output;
                case 11:
                case 12:
                case 13:
                case 14:
                case 15:
                    output = String.Format("{0} medium-sized monstrous scorpions", Dice.Roll(3, 0, Modifier, ref random));
                    if (Dice.Percentile(ref random) <= 20)
                        return String.Format("{0} with {1}", output, Treasure.Generate(2, ref random));
                    return output;
                case 16:
                case 17:
                case 18:
                case 19:
                case 20:
                    output = String.Format("{0} medium-sized monstrous spiders", Dice.Roll(3, 0, Modifier, ref random));
                    if (Dice.Percentile(ref random) <= 20)
                        return String.Format("{0} with {1}", output, Treasure.Generate(2, ref random));
                    return output;
                case 21:
                case 22:
                case 23:
                case 24:
                case 25:
                    output = String.Format("{0} {1}", Dice.Roll(1, 0, Modifier, ref random), Dragon(2, ref random));
                    if (Dice.Percentile(ref random) <= 80)
                        return String.Format("{0} with {1}", output, Treasure.Generate(6, ref random));
                    return output;
                case 26:
                case 27:
                case 28:
                case 29:
                case 30:
                    if (Dice.Roll(4, 2, Modifier, ref random) != 0)
                    {
                        output = String.Format("{0} elven warriors", Dice.Roll(4, 2, Modifier, ref random));
                        if (Dice.Percentile(ref random) <= 80)
                            return String.Format("{0} with {1}", output, Treasure.Generate(4, ref random));
                        return output;
                    }
                    else
                        return Level2(Modifier, ref random);
                case 31:
                case 32:
                case 33:
                case 34:
                case 35:
                    output = "";
                    for (int i = Dice.Roll(3, 0, Modifier, ref random); i > 0; i--)
                        output += String.Format(" {0},", Character.Generate(1, false, ref random));
                    return output;
                case 36:
                case 37:
                    output = String.Format("{0} choker", Dice.Roll(1, 0, Modifier, ref random));
                    if (Dice.Percentile(ref random) <= 20)
                        return String.Format("{0} with {1}", output, Treasure.Generate(2, ref random));
                    return output;
                case 38:
                case 39:
                case 40:
                case 41:
                case 42:
                    output = String.Format("{0} ethereal marauder", Dice.Roll(1, 0, Modifier, ref random));
                    if (Dice.Percentile(ref random) <= 20)
                        return String.Format("{0} with {1}", output, Treasure.Generate(2, ref random));
                    return output;
                case 43:
                case 44:
                case 45:
                    output = String.Format("{0} shriekers", Dice.Roll(3, 0, Modifier, ref random));
                    if (Dice.Percentile(ref random) <= 20)
                        return String.Format("{0} with {1}", output, Treasure.Generate(2, ref random));
                    return output;
                case 46:
                case 47:
                case 48:
                case 49:
                case 50:
                    if (Dice.Roll(4, 2, Modifier, ref random) != 0)
                    {
                        output = String.Format("{0} formian workers", Dice.Roll(4, 2, Modifier, ref random));
                        if (Dice.Percentile(ref random) <= 80)
                            return String.Format("{0} with {1}", output, Treasure.Generate(4, ref random));
                        return output;
                    }
                    else
                        return Level2(Modifier, ref random);
                case 51:
                case 52:
                case 53:
                case 54:
                case 55:
                    if (Dice.Roll(4, 2, Modifier, ref random) != 0)
                    {
                        output = String.Format("{0} hobgoblins", Dice.Roll(4, 2, Modifier, ref random));
                        if (Dice.Percentile(ref random) <= 80)
                            return String.Format("{0} with {1}", output, Treasure.Generate(4, ref random));
                        return output;
                    }
                    else
                        return Level2(Modifier, ref random);
                case 56:
                case 57:
                case 58:
                case 59:
                case 60:
                    if (Dice.Roll(4, 2, Modifier, ref random) != 0)
                    {
                        output = String.Format("{0} hobgoblins and {1} goblins", Dice.Roll(3, 0, Modifier, ref random), Dice.Roll(4, 2, Modifier, ref random));
                        if (Dice.Percentile(ref random) <= 80)
                            return String.Format("{0} with {1}", output, Treasure.Generate(4, ref random));
                        return output;
                    }
                    else
                        return Level2(Modifier, ref random);
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
                    output = String.Format("{0} lizardfolk", Dice.Roll(3, 0, Modifier, ref random));
                    if (Dice.Percentile(ref random) <= 80)
                        return String.Format("{0} with {1}", output, Treasure.Generate(4, ref random));
                    return output;
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
                    if (Dice.Roll(4, 2, Modifier, ref random) != 0)
                    {
                        output = String.Format("{0} orcs", Dice.Roll(4, 2, Modifier, ref random));
                        if (Dice.Percentile(ref random) <= 80)
                            return String.Format("{0} with {1}", output, Treasure.Generate(4, ref random));
                        return output;
                    }
                    else
                        return Level2(Modifier, ref random);
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
                    if (Dice.Roll(4, 2, Modifier, ref random) != 0)
                    {
                        output = String.Format("{0} human medium-sized zombies", Dice.Roll(4, 2, Modifier, ref random));
                        if (Dice.Percentile(ref random) <= 50)
                            return String.Format("{0} with {1}", output, Treasure.Generate(2, ref random));
                        return output;
                    }
                    else
                        return Level2(Modifier, ref random);
                default:
                    output = String.Format("{0} ghouls", Dice.Roll(3, 0, Modifier, ref random));
                    if (Dice.Percentile(ref random) <= 50)
                        return String.Format("{0} with {1}", output, Treasure.Generate(2, ref random));
                    return output;
            }
        }

        private static string Level3(string Modifier, ref Random random)
        {
            switch (Dice.Percentile(ref random))
            {
                case 1:
                case 2:
                    string output = String.Format("{0} giant bombardier beetles", Dice.Roll(2, 0, Modifier, ref random));
                    if (Dice.Percentile(ref random) <= 20)
                        return String.Format("{0} with {1}", output, Treasure.Generate(3, ref random));
                    return output;
                case 3:
                case 4:
                    output = String.Format("{0} huge monstrous centipedes", Dice.Roll(2, 0, Modifier, ref random));
                    if (Dice.Percentile(ref random) <= 20)
                        return String.Format("{0} with {1}", output, Treasure.Generate(3, ref random));
                    return output;
                case 5:
                case 6:
                    output = String.Format("{0} dire badgers", Dice.Roll(2, 0, Modifier, ref random));
                    if (Dice.Percentile(ref random) <= 20)
                        return String.Format("{0} with {1}", output, Treasure.Generate(3, ref random));
                    return output;
                case 7:
                case 8:
                    output = String.Format("{0} dire bats", Dice.Roll(2, 0, Modifier, ref random));
                    if (Dice.Percentile(ref random) <= 20)
                        return String.Format("{0} with {1}", output, Treasure.Generate(3, ref random));
                    return output;
                case 9:
                case 10:
                case 11:
                    output = String.Format("{0} gelatinous cube", Dice.Roll(1, 0, Modifier, ref random));
                    if (Dice.Percentile(ref random) <= 20)
                        return String.Format("{0} with {1}", output, Treasure.Generate(3, ref random));
                    return output;
                case 12:
                case 13:
                    output = String.Format("{0} giant praying mantises", Dice.Roll(2, 0, Modifier, ref random));
                    if (Dice.Percentile(ref random) <= 20)
                        return String.Format("{0} with {1}", output, Treasure.Generate(3, ref random));
                    return output;
                case 14:
                    output = String.Format("{0} large monstrous scorpions", Dice.Roll(2, 0, Modifier, ref random));
                    if (Dice.Percentile(ref random) <= 20)
                        return String.Format("{0} with {1}", output, Treasure.Generate(3, ref random));
                    return output;
                case 15:
                    output = String.Format("{0} large monstrous spiders", Dice.Roll(2, 0, Modifier, ref random));
                    if (Dice.Percentile(ref random) <= 20)
                        return String.Format("{0} with {1}", output, Treasure.Generate(3, ref random));
                    return output;
                case 16:
                case 17:
                case 18:
                case 19:
                case 20:
                    output = String.Format("{0} {1}", Dice.Roll(1, 0, Modifier, ref random), Dragon(3, ref random));
                    if (Dice.Percentile(ref random) <= 80)
                        return String.Format("{0} with {1}", output, Treasure.Generate(7, ref random));
                    return output;
                case 21:
                case 22:
                case 23:
                case 24:
                case 25:
                    output = String.Format("{0} imps", Dice.Roll(2, 0, Modifier, ref random));
                    if (Dice.Percentile(ref random) <= 80)
                        return String.Format("{0} with {1}", output, Treasure.Generate(6, ref random));
                    return output;
                case 26:
                case 27:
                case 28:
                case 29:
                case 30:
                    output = String.Format("{0} wererat and {1} dire rats", Dice.Roll(1, 0, Modifier, ref random), Dice.Roll(3, 1, Modifier, ref random));
                    if (Dice.Percentile(ref random) <= 80)
                        return String.Format("{0} with {1}", output, Treasure.Generate(6, ref random));
                    return output;
                case 31:
                case 32:
                case 33:
                case 34:
                case 35:
                    if (Dice.Roll(6, 3, Modifier, ref random) != 0)
                    {
                        output = String.Format("{0} dwarven warriors", Dice.Roll(6, 3, Modifier, ref random));
                        if (Dice.Percentile(ref random) <= 80)
                            return String.Format("{0} with {1}", output, Treasure.Generate(6, ref random));
                        return output;
                    }
                    else
                        return Level3(Modifier, ref random);
                case 36:
                case 37:
                case 38:
                case 39:
                case 40:
                    output = "";
                    for (int i = Dice.Roll(3, 1, Modifier, ref random); i > 0; i--)
                        output += String.Format(" {0},", Character.Generate(1, false, ref random));
                    return output;
                case 41:
                case 42:
                case 43:
                case 44:
                    output = String.Format("{0} dretches", Dice.Roll(2, 0, Modifier, ref random));
                    if (Dice.Percentile(ref random) <= 50)
                        return String.Format("{0} with {1}", output, Treasure.Generate(3, ref random));
                    return output;
                case 45:
                case 46:
                case 47:
                case 48:
                    output = String.Format("{0} ethereal filcher", Dice.Roll(1, 0, Modifier, ref random));
                    if (Dice.Percentile(ref random) <= 50)
                        return String.Format("{0} with {1}", output, Treasure.Generate(3, ref random));
                    return output;
                case 49:
                case 50:
                case 51:
                case 52:
                    output = String.Format("{0} phantom fungus", Dice.Roll(1, 0, Modifier, ref random));
                    if (Dice.Percentile(ref random) <= 20)
                        return String.Format("{0} with {1}", output, Treasure.Generate(3, ref random));
                    return output;
                case 53:
                case 54:
                case 55:
                case 56:
                    output = String.Format("{0} thoqquas", Dice.Roll(2, 0, Modifier, ref random));
                    if (Dice.Percentile(ref random) <= 20)
                        return String.Format("{0} with {1}", output, Treasure.Generate(3, ref random));
                    return output;
                case 57:
                case 58:
                case 59:
                case 60:
                    output = String.Format("{0} vargouilles", Dice.Roll(2, 0, Modifier, ref random));
                    if (Dice.Percentile(ref random) <= 50)
                        return String.Format("{0} with {1}", output, Treasure.Generate(3, ref random));
                    return output;
                case 61:
                case 62:
                    output = String.Format("{0} bugbear and {1} goblins", Dice.Roll(1, 0, Modifier, ref random), Dice.Roll(4, 2, Modifier, ref random));
                    if (Dice.Percentile(ref random) <= 80)
                        return String.Format("{0} with {1}", output, Treasure.Generate(6, ref random));
                    return output;
                case 63:
                case 64:
                case 65:
                case 66:
                case 67:
                    output = String.Format("{0} gnolls", Dice.Roll(3, 1, Modifier, ref random));
                    if (Dice.Percentile(ref random) <= 80)
                        return String.Format("{0} with {1}", output, Treasure.Generate(6, ref random));
                    return output;
                case 68:
                case 69:
                    if (Dice.Roll(4, 2, Modifier, ref random) != 0)
                    {
                        output = String.Format("{0} goblins and {1} wolves", Dice.Roll(4, 2, Modifier, ref random), Dice.Roll(3, 0, Modifier, ref random));
                        if (Dice.Percentile(ref random) <= 80)
                            return String.Format("{0} with {1}", output, Treasure.Generate(6, ref random));
                        return output;
                    }
                    else
                        return Level3(Modifier, ref random);
                case 70:
                case 71:
                    output = String.Format("{0} hobgoblins and {1} wolves", Dice.Roll(3, 0, Modifier, ref random), Dice.Roll(3, 0, Modifier, ref random));
                    if (Dice.Percentile(ref random) <= 80)
                        return String.Format("{0} with {1}", output, Treasure.Generate(6, ref random));
                    return output;
                case 72:
                case 73:
                case 74:
                case 75:
                    if (Dice.Roll(6, 3, Modifier, ref random) != 0)
                    {
                        output = String.Format("{0} kobolds and {1} dire weasel", Dice.Roll(6, 3, Modifier, ref random), Dice.Roll(1, 0, Modifier, ref random));
                        if (Dice.Percentile(ref random) <= 80)
                            return String.Format("{0} with {1}", output, Treasure.Generate(6, ref random));
                        return output;
                    }
                    else
                        return Level3(Modifier, ref random);
                case 76:
                case 77:
                case 78:
                case 79:
                case 80:
                    output = String.Format("{0} troglodytes", Dice.Roll(3, 1, Modifier, ref random));
                    if (Dice.Percentile(ref random) <= 80)
                        return String.Format("{0} with {1}", output, Treasure.Generate(6, ref random));
                    return output;
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
                    output = String.Format("{0} shadow", Dice.Roll(1, 0, Modifier, ref random));
                    if (Dice.Percentile(ref random) <= 50)
                        return String.Format("{0} with {1}", output, Treasure.Generate(3, ref random));
                    return output;
                default:
                    output = String.Format("{0} ogre large skeletons", Dice.Roll(3, 1, Modifier, ref random));
                    if (Dice.Percentile(ref random) <= 50)
                        return String.Format("{0} with {1}", output, Treasure.Generate(3, ref random));
                    return output;
            }
        }

        private static string Level4(string Modifier, ref Random random)
        {
            switch (Dice.Percentile(ref random))
            {
                case 1:
                case 2:
                case 3:
                case 4:
                    string output = String.Format("{0} ankhegs", Dice.Roll(2, 0, Modifier, ref random));
                    if (Dice.Percentile(ref random) <= 20)
                        return String.Format("{0} with {1}", output, Treasure.Generate(4, ref random));
                    return output;
                case 5:
                case 6:
                case 7:
                case 8:
                    output = String.Format("{0} dire weasels", Dice.Roll(3, 0, Modifier, ref random));
                    if (Dice.Percentile(ref random) <= 20)
                        return String.Format("{0} with {1}", output, Treasure.Generate(4, ref random));
                    return output;
                case 9:
                case 10:
                case 11:
                case 12:
                    output = String.Format("{0} gray ooze", Dice.Roll(1, 0, Modifier, ref random));
                    if (Dice.Percentile(ref random) <= 20)
                        return String.Format("{0} with {1}", output, Treasure.Generate(4, ref random));
                    return output;
                case 13:
                case 14:
                case 15:
                    output = String.Format("{0} huge viper snakes", Dice.Roll(2, 0, Modifier, ref random));
                    if (Dice.Percentile(ref random) <= 20)
                        return String.Format("{0} with {1}", output, Treasure.Generate(4, ref random));
                    return output;
                case 16:
                case 17:
                case 18:
                case 19:
                case 20:
                    output = String.Format("{0} {1}", Dice.Roll(1, 0, Modifier, ref random), Dragon(4, ref random));
                    if (Dice.Percentile(ref random) <= 80)
                        return String.Format("{0} with {1}", output, Treasure.Generate(8, ref random));
                    return output;
                case 21:
                case 22:
                case 23:
                    output = String.Format("{0} formian workers", Dice.Roll(3, 1, Modifier, ref random));
                    if (Dice.Percentile(ref random) <= 80)
                        return String.Format("{0} with {1}", output, Treasure.Generate(7, ref random));
                    return output;
                case 24:
                case 25:
                case 26:
                    output = String.Format("{0} imp and {1} lemures", Dice.Roll(1, 0, Modifier, ref random), Dice.Roll(3, 0, Modifier, ref random));
                    if (Dice.Percentile(ref random) <= 80)
                        return String.Format("{0} with {1}", output, Treasure.Generate(7, ref random));
                    return output;
                case 27:
                case 28:
                case 29:
                case 30:
                    output = String.Format("{0} quasits", Dice.Roll(2, 0, Modifier, ref random));
                    if (Dice.Percentile(ref random) <= 80)
                        return String.Format("{0} with {1}", output, Treasure.Generate(7, ref random));
                    return output;
                case 31:
                case 32:
                case 33:
                case 34:
                case 35:
                    output = String.Format("{0} lantern archons", Dice.Roll(3, 0, Modifier, ref random));
                    if (Dice.Percentile(ref random) <= 50)
                        return String.Format("{0} with {1}", output, Treasure.Generate(6, ref random));
                    return output;
                case 36:
                case 37:
                case 38:
                case 39:
                case 40:
                    output = "";
                    for (int i = Dice.Roll(3, 0, Modifier, ref random); i > 0; i--)
                        output += String.Format(" {0},", Character.Generate(2, false, ref random));
                    return output;
                case 41:
                case 42:
                case 43:
                case 44:
                case 45:
                    output = String.Format("{0} carrion crawlers", Dice.Roll(1, 0, Modifier, ref random));
                    if (Dice.Percentile(ref random) <= 20)
                        return String.Format("{0} with {1}", output, Treasure.Generate(4, ref random));
                    return output;
                case 46:
                case 47:
                case 48:
                case 49:
                case 50:
                    output = String.Format("{0} mimic", Dice.Roll(1, 0, Modifier, ref random));
                    if (Dice.Percentile(ref random) <= 50)
                        return String.Format("{0} with {1}", output, Treasure.Generate(4, ref random));
                    return output;
                case 51:
                case 52:
                case 53:
                case 54:
                case 55:
                    output = String.Format("{0} rust monsters", Dice.Roll(2, 0, Modifier, ref random));
                    if (Dice.Percentile(ref random) <= 20)
                        return String.Format("{0} with {1}", output, Treasure.Generate(4, ref random));
                    return output;
                case 56:
                case 57:
                case 58:
                case 59:
                case 60:
                    output = String.Format("{0} violet fungi", Dice.Roll(2, 0, Modifier, ref random));
                    if (Dice.Percentile(ref random) <= 20)
                        return String.Format("{0} with {1}", output, Treasure.Generate(4, ref random));
                    return output;
                case 61:
                case 62:
                    if (Dice.Roll(6, 3, Modifier, ref random) != 0)
                    {
                        output = String.Format("{0} bugbear and {1} hobgoblins", Dice.Roll(1, 0, Modifier, ref random), Dice.Roll(6, 3, Modifier, ref random));
                        if (Dice.Percentile(ref random) <= 80)
                            return String.Format("{0} with {1}", output, Treasure.Generate(7, ref random));
                        return output;
                    }
                    else
                        return Level4(Modifier, ref random);
                case 63:
                case 64:
                case 65:
                    output = String.Format("{0} ettercap", Dice.Roll(1, 0, Modifier, ref random));
                    if (Dice.Percentile(ref random) <= 80)
                        return String.Format("{0} with {1}", output, Treasure.Generate(7, ref random));
                    return output;
                case 66:
                case 67:
                    output = String.Format("{0} gnolls and {1} hyenas (wolf)", Dice.Roll(3, 0, Modifier, ref random), Dice.Roll(3, 0, Modifier, ref random));
                    if (Dice.Percentile(ref random) <= 80)
                        return String.Format("{0} with {1}", output, Treasure.Generate(7, ref random));
                    return output;
                case 68:
                case 69:
                case 70:
                    output = String.Format("{0} lizardfolk and {1} giant lizard", Dice.Roll(3, 0, Modifier, ref random), Dice.Roll(1, 0, Modifier, ref random));
                    if (Dice.Percentile(ref random) <= 80)
                        return String.Format("{0} with {1}", output, Treasure.Generate(7, ref random));
                    return output;
                case 71:
                case 72:
                case 73:
                    output = String.Format("{0} magmins", Dice.Roll(2, 0, Modifier, ref random));
                    if (Dice.Percentile(ref random) <= 80)
                        return String.Format("{0} with {1}", output, Treasure.Generate(7, ref random));
                    return output;
                case 74:
                case 75:
                case 76:
                    if (Dice.Roll(4, 2, Modifier, ref random) != 0)
                    {
                        output = String.Format("{0} ogre and {1} orcs", Dice.Roll(1, 0, Modifier, ref random), Dice.Roll(4, 2, Modifier, ref random));
                        if (Dice.Percentile(ref random) <= 80)
                            return String.Format("{0} with {1}", output, Treasure.Generate(7, ref random));
                        return output;
                    }
                    else
                        return Level4(Modifier, ref random);
                case 77:
                case 78:
                    output = String.Format("{0} orcs and {1} dire boars", Dice.Roll(3, 0, Modifier, ref random), Dice.Roll(2, 0, Modifier, ref random));
                    if (Dice.Percentile(ref random) <= 80)
                        return String.Format("{0} with {1}", output, Treasure.Generate(7, ref random));
                    return output;
                case 79:
                case 80:
                    if (Dice.Roll(4, 2, Modifier, ref random) != 0)
                    {
                        output = String.Format("{0} worgs and {1} goblins", Dice.Roll(2, 0, Modifier, ref random), Dice.Roll(4, 2, Modifier, ref random));
                        if (Dice.Percentile(ref random) <= 80)
                            return String.Format("{0} with {1}", output, Treasure.Generate(7, ref random));
                        return output;
                    }
                    else
                        return Level4(Modifier, ref random);
                case 81:
                case 82:
                case 83:
                case 84:
                case 85:
                    output = String.Format("{0} allips", Dice.Roll(2, 0, Modifier, ref random));
                    if (Dice.Percentile(ref random) <= 50)
                        return String.Format("{0} with {1}", output, Treasure.Generate(4, ref random));
                    return output;
                case 86:
                case 87:
                case 88:
                case 89:
                case 90:
                    output = "";
                    for (int i = Dice.Roll(1, 0, Modifier, ref random); i > 0; i--)
                        output += String.Format("1 ghost {0}, ", Character.Generate(Dice.Roll(1, 3, 0, ref random), false, ref random));
                    if (Dice.Percentile(ref random) <= 50)
                        return String.Format("{0} with {1}", output, Treasure.Generate(4, ref random));
                    return output;
                case 91:
                case 92:
                case 93:
                case 94:
                case 95:
                    output = String.Format("{0} vampire spawn", Dice.Roll(1, 0, Modifier, ref random));
                    if (Dice.Percentile(ref random) <= 50)
                        return String.Format("{0} with {1}", output, Treasure.Generate(4, ref random));
                    return output;
                default:
                    output = String.Format("{0} wights", Dice.Roll(2, 0, Modifier, ref random));
                    if (Dice.Percentile(ref random) <= 50)
                        return String.Format("{0} with {1}", output, Treasure.Generate(4, ref random));
                    return output;
            }
        }

        private static string Level5(string Modifier, ref Random random)
        {
            string output;

            switch (Dice.Percentile(ref random))
            {
                case 1:
                case 2:
                    if (Dice.Roll(4, 2, Modifier, ref random) != 0)
                    {
                        output = String.Format("{0} giant soldier ants and {1} giant worker ants", Dice.Roll(1, 0, Modifier, ref random), Dice.Roll(4, 2, Modifier, ref random));
                        if (Dice.Percentile(ref random) <= 20)
                            return String.Format("{0} with {1}", output, Treasure.Generate(5, ref random));
                        return output;
                    }
                    else
                        return Level5(Modifier, ref random);
                case 3:
                case 4:
                case 5:
                    output = String.Format("{0} dire wolverines", Dice.Roll(2, 0, Modifier, ref random));
                    if (Dice.Percentile(ref random) <= 20)
                        return String.Format("{0} with {1}", output, Treasure.Generate(5, ref random));
                    return output;
                case 6:
                case 7:
                case 8:
                case 9:
                    output = String.Format("{0} ochre jelly", Dice.Roll(1, 0, Modifier, ref random));
                    if (Dice.Percentile(ref random) <= 20)
                        return String.Format("{0} with {1}", output, Treasure.Generate(5, ref random));
                    return output;
                case 10:
                case 11:
                    output = String.Format("{0} giant constrictor snake", Dice.Roll(1, 0, Modifier, ref random));
                    if (Dice.Percentile(ref random) <= 20)
                        return String.Format("{0} with {1}", output, Treasure.Generate(5, ref random));
                    return output;
                case 12:
                    output = String.Format("{0} huge monstrous spiders", Dice.Roll(2, 0, Modifier, ref random));
                    if (Dice.Percentile(ref random) <= 20)
                        return String.Format("{0} with {1}", output, Treasure.Generate(5, ref random));
                    return output;
                case 13:
                case 14:
                case 15:
                    output = String.Format("{0} spider eater", Dice.Roll(1, 0, Modifier, ref random));
                    if (Dice.Percentile(ref random) <= 20)
                        return String.Format("{0} with {1}", output, Treasure.Generate(5, ref random));
                    return output;
                case 16:
                case 17:
                case 18:
                case 19:
                case 20:
                    output = String.Format("{0} {1}", Dice.Roll(1, 0, Modifier, ref random), Dragon(5, ref random));
                    if (Dice.Percentile(ref random) <= 80)
                        return String.Format("{0} with {1}", output, Treasure.Generate(9, ref random));
                    return output;
                case 21:
                case 22:
                case 23:
                    output = String.Format("{0} doppelgangers", Dice.Roll(3, 0, Modifier, ref random));
                    if (Dice.Percentile(ref random) <= 80)
                        return String.Format("{0} with {1}", output, Treasure.Generate(8, ref random));
                    return output;
                case 24:
                case 25:
                    output = String.Format("{0} greenhag", Dice.Roll(1, 0, Modifier, ref random));
                    if (Dice.Percentile(ref random) <= 80)
                        return String.Format("{0} with {1}", output, Treasure.Generate(8, ref random));
                    return output;
                case 26:
                case 27:
                    output = String.Format("{0} mephits", Dice.Roll(3, 0, Modifier, ref random));
                    if (Dice.Percentile(ref random) <= 80)
                        return String.Format("{0} with {1}", output, Treasure.Generate(8, ref random));
                    return output;
                case 28:
                case 29:
                case 30:
                    output = String.Format("{0} wererats", Dice.Roll(3, 1, Modifier, ref random));
                    if (Dice.Percentile(ref random) <= 80)
                        return String.Format("{0} with {1}", output, Treasure.Generate(8, ref random));
                    return output;
                case 31:
                case 32:
                case 33:
                case 34:
                case 35:
                    output = String.Format("{0} blink dogs", Dice.Roll(3, 1, Modifier, ref random));
                    if (Dice.Percentile(ref random) <= 50)
                        return String.Format("{0} with {1}", output, Treasure.Generate(7, ref random));
                    return output;
                case 36:
                case 37:
                case 38:
                case 39:
                case 40:
                    output = "";
                    for (int i = Dice.Roll(3, 1, Modifier, ref random); i > 0; i--)
                        output += String.Format(" {0},", Character.Generate(2, false, ref random));
                    return output;
                case 41:
                case 42:
                case 43:
                    output = String.Format("{0} cockatrices", Dice.Roll(3, 0, Modifier, ref random));
                    if (Dice.Percentile(ref random) <= 20)
                        return String.Format("{0} with {1}", output, Treasure.Generate(5, ref random));
                    return output;
                case 44:
                case 45:
                case 46:
                case 47:
                    output = String.Format("{0} gibbering mouther", Dice.Roll(1, 0, Modifier, ref random));
                    if (Dice.Percentile(ref random) <= 20)
                        return String.Format("{0} with {1}", output, Treasure.Generate(5, ref random));
                    return output;
                case 48:
                case 49:
                case 50:
                    output = String.Format("{0} gricks", Dice.Roll(3, 0, Modifier, ref random));
                    if (Dice.Percentile(ref random) <= 20)
                        return String.Format("{0} with {1}", output, Treasure.Generate(5, ref random));
                    return output;
                case 51:
                case 52:
                    output = String.Format("{0} {1}-headed hydra", Dice.Roll(1, 0, Modifier, ref random), Dice.Roll(1, 3, 4, ref random));
                    if (Dice.Percentile(ref random) <= 20)
                        return String.Format("{0} with {1}", output, Treasure.Generate(5, ref random));
                    return output;
                case 53:
                case 54:
                case 55:
                    output = String.Format("{0} nightmare", Dice.Roll(1, 0, Modifier, ref random));
                    if (Dice.Percentile(ref random) <= 20)
                        return String.Format("{0} with {1}", output, Treasure.Generate(5, ref random));
                    return output;
                case 56:
                case 57:
                case 58:
                    output = String.Format("{0} shocker lizards", Dice.Roll(3, 1, Modifier, ref random));
                    if (Dice.Percentile(ref random) <= 20)
                        return String.Format("{0} with {1}", output, Treasure.Generate(5, ref random));
                    return output;
                case 59:
                case 60:
                    output = String.Format("{0} violet fungus and {1} shriekers", Dice.Roll(1, 0, Modifier, ref random), Dice.Roll(3, 1, Modifier, ref random));
                    if (Dice.Percentile(ref random) <= 20)
                        return String.Format("{0} with {1}", output, Treasure.Generate(5, ref random));
                    return output;
                case 61:
                case 62:
                case 63:
                case 64:
                    output = String.Format("{0} azers", Dice.Roll(3, 1, Modifier, ref random));
                    if (Dice.Percentile(ref random) <= 80)
                        return String.Format("{0} with {1}", output, Treasure.Generate(8, ref random));
                    return output;
                case 65:
                case 66:
                case 67:
                    output = String.Format("{0} bugbears", Dice.Roll(3, 1, Modifier, ref random));
                    if (Dice.Percentile(ref random) <= 80)
                        return String.Format("{0} with {1}", output, Treasure.Generate(8, ref random));
                    return output;
                case 68:
                case 69:
                    output = String.Format("{0} ettercap and {1} medium-size monstrous spiders", Dice.Roll(1, 0, Modifier, ref random), Dice.Roll(3, 0, Modifier, ref random));
                    if (Dice.Percentile(ref random) <= 80)
                        return String.Format("{0} with {1}", output, Treasure.Generate(8, ref random));
                    return output;
                case 70:
                case 71:
                case 72:
                    output = String.Format("{0} ogres", Dice.Roll(3, 1, Modifier, ref random));
                    if (Dice.Percentile(ref random) <= 80)
                        return String.Format("{0} with {1}", output, Treasure.Generate(8, ref random));
                    return output;
                case 73:
                case 74:
                case 75:
                    output = String.Format("{0} small salamanders", Dice.Roll(3, 1, Modifier, ref random));
                    if (Dice.Percentile(ref random) <= 80)
                        return String.Format("{0} with {1}", output, Treasure.Generate(8, ref random));
                    return output;
                case 76:
                case 77:
                    output = String.Format("{0} troglodytes and {1} giant lizards", Dice.Roll(3, 1, Modifier, ref random), Dice.Roll(2, 0, Modifier, ref random));
                    if (Dice.Percentile(ref random) <= 80)
                        return String.Format("{0} with {1}", output, Treasure.Generate(8, ref random));
                    return output;
                case 78:
                case 79:
                case 80:
                    output = String.Format("{0} worgs", Dice.Roll(3, 1, Modifier, ref random));
                    if (Dice.Percentile(ref random) <= 80)
                        return String.Format("{0} with {1}", output, Treasure.Generate(8, ref random));
                    return output;
                case 81:
                case 82:
                case 83:
                case 84:
                case 85:
                    output = String.Format("{0} ghast and {1} ghouls", Dice.Roll(1, 0, Modifier, ref random), Dice.Roll(3, 0, Modifier, ref random));
                    if (Dice.Percentile(ref random) <= 50)
                        return String.Format("{0} with {1}", output, Treasure.Generate(5, ref random));
                    return output;
                case 86:
                case 87:
                case 88:
                case 89:
                case 90:
                    output = String.Format("{0} mummies", Dice.Roll(3, 0, Modifier, ref random));
                    if (Dice.Percentile(ref random) <= 50)
                        return String.Format("{0} with {1}", output, Treasure.Generate(5, ref random));
                    return output;
                case 91:
                case 92:
                case 93:
                case 94:
                case 95:
                    output = String.Format("{0} giant huge skeletons", Dice.Roll(3, 1, Modifier, ref random));
                    if (Dice.Percentile(ref random) <= 50)
                        return String.Format("{0} with {1}", output, Treasure.Generate(5, ref random));
                    return output;
                default:
                    output = String.Format("{0} wraith", Dice.Roll(1, 0, Modifier, ref random));
                    if (Dice.Percentile(ref random) <= 50)
                        return String.Format("{0} with {1}", output, Treasure.Generate(5, ref random));
                    return output;
            }
        }

        private static string Level6(string Modifier, ref Random random)
        {
            switch (Dice.Percentile(ref random))
            {
                case 1:
                case 2:
                    string output = String.Format("{0} digester", Dice.Roll(1, 0, Modifier, ref random));
                    if (Dice.Percentile(ref random) <= 20)
                        return String.Format("{0} with {1}", output, Treasure.Generate(6, ref random));
                    return output;
                case 3:
                case 4:
                    output = String.Format("{0} dire apes", Dice.Roll(3, 1, Modifier, ref random));
                    if (Dice.Percentile(ref random) <= 20)
                        return String.Format("{0} with {1}", output, Treasure.Generate(6, ref random));
                    return output;
                case 5:
                case 6:
                    output = String.Format("{0} dire wolves", Dice.Roll(3, 1, Modifier, ref random));
                    if (Dice.Percentile(ref random) <= 20)
                        return String.Format("{0} with {1}", output, Treasure.Generate(6, ref random));
                    return output;
                case 7:
                    output = String.Format("{0} giant stag beetles", Dice.Roll(3, 0, Modifier, ref random));
                    if (Dice.Percentile(ref random) <= 20)
                        return String.Format("{0} with {1}", output, Treasure.Generate(6, ref random));
                    return output;
                case 8:
                case 9:
                    output = String.Format("{0} giant wasp", Dice.Roll(3, 1, Modifier, ref random));
                    if (Dice.Percentile(ref random) <= 20)
                        return String.Format("{0} with {1}", output, Treasure.Generate(6, ref random));
                    return output;
                case 10:
                case 11:
                case 12:
                    output = String.Format("{0} owlbears", Dice.Roll(3, 0, Modifier, ref random));
                    if (Dice.Percentile(ref random) <= 20)
                        return String.Format("{0} with {1}", output, Treasure.Generate(6, ref random));
                    return output;
                case 13:
                case 14:
                case 15:
                    output = String.Format("{0} shambling mound", Dice.Roll(1, 0, Modifier, ref random));
                    if (Dice.Percentile(ref random) <= 20)
                        return String.Format("{0} with {1}", output, Treasure.Generate(6, ref random));
                    return output;
                case 16:
                case 17:
                case 18:
                case 19:
                case 20:
                    output = String.Format("{0} {1}", Dice.Roll(1, 0, Modifier, ref random), Dragon(6, ref random));
                    if (Dice.Percentile(ref random) <= 80)
                        return String.Format("{0} with {1}", output, Treasure.Generate(10, ref random));
                    return output;
                case 21:
                case 22:
                    output = String.Format("{0} annis", Dice.Roll(1, 0, Modifier, ref random));
                    if (Dice.Percentile(ref random) <= 80)
                        return String.Format("{0} with {1}", output, Treasure.Generate(9, ref random));
                    return output;
                case 23:
                case 24:
                case 25:
                    output = String.Format("{0} harpies", Dice.Roll(3, 0, Modifier, ref random));
                    if (Dice.Percentile(ref random) <= 80)
                        return String.Format("{0} with {1}", output, Treasure.Generate(9, ref random));
                    return output;
                case 26:
                    output = String.Format("{0} quasit and {1} dretches", Dice.Roll(1, 0, Modifier, ref random), Dice.Roll(2, 0, Modifier, ref random));
                    if (Dice.Percentile(ref random) <= 80)
                        return String.Format("{0} with {1}", output, Treasure.Generate(9, ref random));
                    return output;
                case 27:
                case 28:
                    output = String.Format("{0} wereboars", Dice.Roll(3, 1, Modifier, ref random));
                    if (Dice.Percentile(ref random) <= 80)
                        return String.Format("{0} with {1}", output, Treasure.Generate(9, ref random));
                    return output;
                case 29:
                case 30:
                    output = String.Format("{0} werewolves", Dice.Roll(3, 1, Modifier, ref random));
                    if (Dice.Percentile(ref random) <= 80)
                        return String.Format("{0} with {1}", output, Treasure.Generate(9, ref random));
                    return output;
                case 31:
                case 32:
                case 33:
                case 34:
                case 35:
                    output = String.Format("{0} werebears", Dice.Roll(2, 0, Modifier, ref random));
                    if (Dice.Percentile(ref random) <= 80)
                        return String.Format("{0} with {1}", output, Treasure.Generate(9, ref random));
                    return output;
                case 36:
                case 37:
                case 38:
                case 39:
                case 40:
                    output = "";
                    for (int i = Dice.Roll(3, 1, Modifier, ref random); i > 0; i--)
                        output += String.Format(" {0},", Character.Generate(3, false, ref random));
                    return output;
                case 41:
                case 42:
                case 43:
                    output = String.Format("{0} small arrowhawks", Dice.Roll(3, 1, Modifier, ref random));
                    if (Dice.Percentile(ref random) <= 20)
                        return String.Format("{0} with {1}", output, Treasure.Generate(6, ref random));
                    return output;
                case 44:
                case 45:
                case 46:
                    output = String.Format("{0} basilisks", Dice.Roll(2, 0, Modifier, ref random));
                    if (Dice.Percentile(ref random) <= 20)
                        return String.Format("{0} with {1}", output, Treasure.Generate(6, ref random));
                    return output;
                case 47:
                case 48:
                case 49:
                case 50:
                    output = String.Format("{0} displacer beasts", Dice.Roll(3, 0, Modifier, ref random));
                    if (Dice.Percentile(ref random) <= 20)
                        return String.Format("{0} with {1}", output, Treasure.Generate(6, ref random));
                    return output;
                case 51:
                case 52:
                case 53:
                    output = String.Format("{0} gargoyles", Dice.Roll(3, 0, Modifier, ref random));
                    if (Dice.Percentile(ref random) <= 20)
                        return String.Format("{0} with {1}", output, Treasure.Generate(6, ref random));
                    return output;
                case 54:
                case 55:
                case 56:
                    output = String.Format("{0} hell hounds", Dice.Roll(3, 1, Modifier, ref random));
                    if (Dice.Percentile(ref random) <= 20)
                        return String.Format("{0} with {1}", output, Treasure.Generate(6, ref random));
                    return output;
                case 57:
                case 58:
                case 59:
                    output = String.Format("{0} howlers", Dice.Roll(3, 1, Modifier, ref random));
                    if (Dice.Percentile(ref random) <= 20)
                        return String.Format("{0} with {1}", output, Treasure.Generate(6, ref random));
                    return output;
                case 60:
                case 61:
                case 62:
                    output = String.Format("{0} otyughs", Dice.Roll(3, 0, Modifier, ref random));
                    if (Dice.Percentile(ref random) <= 20)
                        return String.Format("{0} with {1}", output, Treasure.Generate(6, ref random));
                    return output;
                case 63:
                case 64:
                case 65:
                    output = String.Format("{0} ravid and {1} large animated object", Dice.Roll(1, 0, Modifier, ref random), Dice.Roll(1, 0, Modifier, ref random));
                    if (Dice.Percentile(ref random) <= 20)
                        return String.Format("{0} with {1}", output, Treasure.Generate(6, ref random));
                    return output;
                case 66:
                case 67:
                    int roll = Dice.Roll(3, 1, Modifier, ref random);
                    output = String.Format("{0} small xorns with", roll);
                    for (int i = roll; i > 0; i--)
                        output += String.Format(" {0},", Treasure.Gems(Dice.d6(ref random), ref random));
                    if (Dice.Percentile(ref random) <= 20)
                        return String.Format("{0} and {1}", output, Treasure.Generate(6, ref random));
                    return output;
                case 68:
                case 69:
                case 70:
                    output = String.Format("{0} yeth hounds", Dice.Roll(3, 1, Modifier, ref random));
                    if (Dice.Percentile(ref random) <= 20)
                        return String.Format("{0} with {1}", output, Treasure.Generate(6, ref random));
                    return output;
                case 71:
                case 72:
                case 73:
                case 74:
                case 75:
                case 76:
                case 77:
                    if (Dice.Roll(6, 3, Modifier, ref random) != 0)
                    {
                        output = String.Format("{0} ettin and {1} orcs", Dice.Roll(1, 0, Modifier, ref random), Dice.Roll(6, 3, Modifier, ref random));
                        if (Dice.Percentile(ref random) <= 80)
                            return String.Format("{0} with {1}", output, Treasure.Generate(9, ref random));
                        return output;
                    }
                    else
                        return Level6(Modifier, ref random);
                case 78:
                case 79:
                case 80:
                case 81:
                case 82:
                    output = String.Format("{0} ogres and {1} boars", Dice.Roll(3, 0, Modifier, ref random), Dice.Roll(3, 0, Modifier, ref random));
                    if (Dice.Percentile(ref random) <= 80)
                        return String.Format("{0} with {1}", output, Treasure.Generate(9, ref random));
                    return output;
                case 83:
                case 84:
                case 85:
                case 86:
                case 87:
                case 88:
                case 89:
                case 90:
                    output = String.Format("{0} weretigers", Dice.Roll(2, 0, Modifier, ref random));
                    if (Dice.Percentile(ref random) <= 80)
                        return String.Format("{0} with {1}", output, Treasure.Generate(9, ref random));
                    return output;
                default:
                    output = String.Format("{0} giant huge zombies", Dice.Roll(3, 1, Modifier, ref random));
                    if (Dice.Percentile(ref random) <= 50)
                        return String.Format("{0} with {1}", output, Treasure.Generate(6, ref random));
                    return output;
            }
        }

        private static string Level7(string Modifier, ref Random random)
        {
            switch (Dice.Percentile(ref random))
            {
                case 1:
                case 2:
                case 3:
                case 4:
                    string output = String.Format("{0} black pudding", Dice.Roll(1, 0, Modifier, ref random));
                    if (Dice.Percentile(ref random) <= 20)
                        return String.Format("{0} with {1}", output, Treasure.Generate(7, ref random));
                    return output;
                case 5:
                    output = String.Format("{0} gargantuan monstrous centipedes", Dice.Roll(2, 0, Modifier, ref random));
                    if (Dice.Percentile(ref random) <= 20)
                        return String.Format("{0} with {1}", output, Treasure.Generate(7, ref random));
                    return output;
                case 6:
                case 7:
                case 8:
                    output = String.Format("{0} criosphinx", Dice.Roll(1, 0, Modifier, ref random));
                    if (Dice.Percentile(ref random) <= 20)
                        return String.Format("{0} with {1}", output, Treasure.Generate(7, ref random));
                    return output;
                case 9:
                case 10:
                    output = String.Format("{0} dire boars", Dice.Roll(3, 1, Modifier, ref random));
                    if (Dice.Percentile(ref random) <= 20)
                        return String.Format("{0} with {1}", output, Treasure.Generate(7, ref random));
                    return output;
                case 11:
                case 12:
                case 13:
                case 14:
                    output = String.Format("{0} remorhaz", Dice.Roll(1, 0, Modifier, ref random));
                    if (Dice.Percentile(ref random) <= 20)
                        return String.Format("{0} with {1}", output, Treasure.Generate(7, ref random));
                    return output;
                case 15:
                    output = String.Format("{0} huge monstrous scorpions", Dice.Roll(2, 0, Modifier, ref random));
                    if (Dice.Percentile(ref random) <= 20)
                        return String.Format("{0} with {1}", output, Treasure.Generate(7, ref random));
                    return output;
                case 16:
                case 17:
                case 18:
                case 19:
                case 20:
                    output = String.Format("{0} {1}", Dice.Roll(1, 0, Modifier, ref random), Dragon(7, ref random));
                    if (Dice.Percentile(ref random) <= 80)
                        return String.Format("{0} with {1}", output, Treasure.Generate(11, ref random));
                    return output;
                case 21:
                case 22:
                    output = String.Format("{0} araneas", Dice.Roll(3, 1, Modifier, ref random));
                    if (Dice.Percentile(ref random) <= 80)
                        return String.Format("{0} with {1}", output, Treasure.Generate(10, ref random));
                    return output;
                case 23:
                case 24:
                    output = String.Format("{0} medium-size barghests", Dice.Roll(3, 1, Modifier, ref random));
                    if (Dice.Percentile(ref random) <= 80)
                        return String.Format("{0} with {1}", output, Treasure.Generate(10, ref random));
                    return output;
                case 25:
                case 26:
                    output = String.Format("{0} djinn", Dice.Roll(3, 0, Modifier, ref random));
                    if (Dice.Percentile(ref random) <= 80)
                        return String.Format("{0} with {1}", output, Treasure.Generate(10, ref random));
                    return output;
                case 27:
                case 28:
                    output = String.Format("{0} formian taskmaster and {1} minotaur", Dice.Roll(1, 0, Modifier, ref random), Dice.Roll(1, 0, Modifier, ref random));
                    if (Dice.Percentile(ref random) <= 80)
                        return String.Format("{0} with {1}", output, Treasure.Generate(10, ref random));
                    return output;
                case 29:
                case 30:
                    output = String.Format("{0} jann", Dice.Roll(3, 1, Modifier, ref random));
                    if (Dice.Percentile(ref random) <= 80)
                        return String.Format("{0} with {1}", output, Treasure.Generate(10, ref random));
                    return output;
                case 31:
                case 32:
                case 33:
                case 34:
                case 35:
                    output = String.Format("{0} hound archon", Dice.Roll(3, 1, Modifier, ref random));
                    if (Dice.Percentile(ref random) <= 80)
                        return String.Format("{0} with {1}", output, Treasure.Generate(10, ref random));
                    return output;
                case 36:
                case 37:
                case 38:
                case 39:
                case 40:
                    output = "";
                    for (int i = Dice.Roll(3, 1, Modifier, ref random); i > 0; i--)
                        output += String.Format(" {0},", Character.Generate(4, false, ref random));
                    return output;
                case 41:
                case 42:
                case 43:
                case 44:
                case 45:
                    output = String.Format("{0} cloakers", Dice.Roll(3, 0, Modifier, ref random));
                    if (Dice.Percentile(ref random) <= 20)
                        return String.Format("{0} with {1}", output, Treasure.Generate(7, ref random));
                    return output;
                case 46:
                case 47:
                case 48:
                    output = String.Format("{0} {1}-headed cryohydra", Dice.Roll(1, 0, Modifier, ref random), Dice.Roll(1, 3, 4, ref random));
                    if (Dice.Percentile(ref random) <= 20)
                        return String.Format("{0} with {1}", output, Treasure.Generate(7, ref random));
                    return output;
                case 49:
                case 50:
                case 51:
                case 52:
                    if (Dice.Roll(4, 2, Modifier, ref random) != 0)
                    {
                        output = String.Format("{0} formian workers", Dice.Roll(4, 2, Modifier, ref random));
                        if (Dice.Percentile(ref random) <= 80)
                            return String.Format("{0} with {1}", output, Treasure.Generate(10, ref random));
                        return output;
                    }
                    else
                        return Level7(Modifier, ref random);
                case 53:
                case 54:
                case 55:
                case 56:
                case 57:
                    output = String.Format("{0} invisible stalker", Dice.Roll(1, 0, Modifier, ref random));
                    if (Dice.Percentile(ref random) <= 20)
                        return String.Format("{0} with {1}", output, Treasure.Generate(7, ref random));
                    return output;
                case 58:
                case 59:
                case 60:
                    output = String.Format("{0} {1}-headed pyrohydra", Dice.Roll(1, 0, Modifier, ref random), Dice.Roll(1, 3, 4, ref random));
                    if (Dice.Percentile(ref random) <= 20)
                        return String.Format("{0} with {1}", output, Treasure.Generate(7, ref random));
                    return output;
                case 61:
                case 62:
                case 63:
                case 64:
                case 65:
                    output = String.Format("{0} bugbears and {1} wolves", Dice.Roll(3, 1, Modifier, ref random), Dice.Roll(3, 1, Modifier, ref random));
                    if (Dice.Percentile(ref random) <= 80)
                        return String.Format("{0} with {1}", output, Treasure.Generate(10, ref random));
                    return output;
                case 66:
                case 67:
                case 68:
                case 69:
                case 70:
                    output = String.Format("{0} ettin and {1} brown bears", Dice.Roll(1, 0, Modifier, ref random), Dice.Roll(2, 0, Modifier, ref random));
                    if (Dice.Percentile(ref random) <= 80)
                        return String.Format("{0} with {1}", output, Treasure.Generate(10, ref random));
                    return output;
                case 71:
                case 72:
                case 73:
                case 74:
                case 75:
                    output = String.Format("{0} minotaurs", Dice.Roll(3, 1, Modifier, ref random));
                    if (Dice.Percentile(ref random) <= 50)
                        return String.Format("{0} with {1}", output, Treasure.Generate(7, ref random));
                    return output;
                case 76:
                case 77:
                case 78:
                case 79:
                case 80:
                    output = String.Format("{0} medium-size salamander and {1} small salamanders", Dice.Roll(1, 0, Modifier, ref random), Dice.Roll(3, 1, Modifier, ref random));
                    if (Dice.Percentile(ref random) <= 80)
                        return String.Format("{0} with {1}", output, Treasure.Generate(10, ref random));
                    return output;
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
                    output = "";
                    for (int i = Dice.Roll(1, 0, Modifier, ref random); i > 0; i--)
                        output += String.Format("1 ghost {0}, ", Character.Generate(Dice.Roll(1, 3, 3, ref random), false, ref random));
                    if (Dice.Percentile(ref random) <= 50)
                        return String.Format("{0} with {1}", output, Treasure.Generate(4, ref random));
                    return output;
                default:
                    output = "";
                    for (int i = Dice.Roll(1, 0, Modifier, ref random); i > 0; i--)
                        output += String.Format("1 vampire {0}, ", Character.Generate(Dice.Roll(1, 2, 4, ref random), true, ref random));
                    return output;
            }
        }

        private static string Level8(string Modifier, ref Random random)
        {
            string output;

            switch (Dice.Percentile(ref random))
            {
                case 1:
                case 2:
                case 3:
                    if (Dice.Roll(6, 5, Modifier, ref random) != 0)
                    {
                        output = String.Format("{0} giant soldier ants", Dice.Roll(6, 5, Modifier, ref random));
                        if (Dice.Percentile(ref random) <= 20)
                            return String.Format("{0} with {1}", output, Treasure.Generate(8, ref random));
                        return output;
                    }
                    else
                        return Level8(Modifier, ref random);
                case 4:
                case 5:
                case 6:
                case 7:
                case 8:
                    if (Dice.Roll(6, 5, Modifier, ref random) != 0)
                    {
                        output = String.Format("{0} dire bats", Dice.Roll(6, 5, Modifier, ref random));
                        if (Dice.Percentile(ref random) <= 20)
                            return String.Format("{0} with {1}", output, Treasure.Generate(8, ref random));
                        return output;
                    }
                    else
                        return Level8(Modifier, ref random);
                case 9:
                case 10:
                    output = String.Format("{0} gargantuan monstrous spiders", Dice.Roll(2, 0, Modifier, ref random));
                    if (Dice.Percentile(ref random) <= 20)
                        return String.Format("{0} with {1}", output, Treasure.Generate(8, ref random));
                    return output;
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
                    output = String.Format("{0} {1}", Dice.Roll(1, 0, Modifier, ref random), Dragon(8, ref random));
                    if (Dice.Percentile(ref random) <= 80)
                        return String.Format("{0} with {1}", output, Treasure.Generate(12, ref random));
                    return output;
                case 21:
                case 22:
                    output = String.Format("{0} aboleth and {1} skums", Dice.Roll(1, 0, Modifier, ref random), Dice.Roll(3, 1, Modifier, ref random));
                    if (Dice.Percentile(ref random) <= 80)
                        return String.Format("{0} with {1}", output, Treasure.Generate(11, ref random));
                    return output;
                case 23:
                case 24:
                    output = String.Format("{0} large barghests", Dice.Roll(3, 1, Modifier, ref random));
                    if (Dice.Percentile(ref random) <= 80)
                        return String.Format("{0} with {1}", output, Treasure.Generate(11, ref random));
                    return output;
                case 25:
                case 26:
                    output = String.Format("{0} erinyes", Dice.Roll(2, 0, Modifier, ref random));
                    if (Dice.Percentile(ref random) <= 80)
                        return String.Format("{0} with {1}", output, Treasure.Generate(11, ref random));
                    return output;
                case 27:
                case 28:
                    if (Dice.Roll(6, 3, Modifier, ref random) != 0)
                    {
                        output = String.Format("{0} medusa and {1} grimlocks", Dice.Roll(1, 0, Modifier, ref random), Dice.Roll(6, 3, Modifier, ref random));
                        if (Dice.Percentile(ref random) <= 80)
                            return String.Format("{0} with {1}", output, Treasure.Generate(11, ref random));
                        return output;
                    }
                    else
                        return Level8(Modifier, ref random);
                case 29:
                case 30:
                    output = String.Format("{0} mind flayer", Dice.Roll(1, 0, Modifier, ref random));
                    if (Dice.Percentile(ref random) <= 80)
                        return String.Format("{0} with {1}", output, Treasure.Generate(11, ref random));
                    return output;
                case 31:
                case 32:
                case 33:
                    output = String.Format("{0} ogre mage", Dice.Roll(1, 0, Modifier, ref random));
                    if (Dice.Percentile(ref random) <= 80)
                        return String.Format("{0} with {1}", output, Treasure.Generate(11, ref random));
                    return output;
                case 34:
                case 35:
                    output = String.Format("{0} yuan-ti halfblood and {1} yuan-ti purebloods", Dice.Roll(1, 0, Modifier, ref random), Dice.Roll(3, 0, Modifier, ref random));
                    if (Dice.Percentile(ref random) <= 80)
                        return String.Format("{0} with {1}", output, Treasure.Generate(11, ref random));
                    return output;
                case 36:
                case 37:
                case 38:
                case 39:
                case 40:
                    output = String.Format("{0} lammasu", Dice.Roll(1, 0, Modifier, ref random));
                    if (Dice.Percentile(ref random) <= 80)
                        return String.Format("{0} with {1}", output, Treasure.Generate(11, ref random));
                    return output;
                case 41:
                case 42:
                case 43:
                case 44:
                case 45:
                    output = "";
                    for (int i = Dice.Roll(3, 1, Modifier, ref random); i > 0; i--)
                        output += String.Format(" {0},", Character.Generate(5, false, ref random));
                    return output;
                case 46:
                case 47:
                    output = String.Format("{0} achaierais", Dice.Roll(3, 1, Modifier, ref random));
                    if (Dice.Percentile(ref random) <= 20)
                        return String.Format("{0} with {1}", output, Treasure.Generate(8, ref random));
                    return output;
                case 48:
                    output = String.Format("{0} medium-size arrowhawks", Dice.Roll(3, 1, Modifier, ref random));
                    if (Dice.Percentile(ref random) <= 20)
                        return String.Format("{0} with {1}", output, Treasure.Generate(8, ref random));
                    return output;
                case 49:
                case 50:
                    output = String.Format("{0} girallons", Dice.Roll(3, 1, Modifier, ref random));
                    if (Dice.Percentile(ref random) <= 20)
                        return String.Format("{0} with {1}", output, Treasure.Generate(8, ref random));
                    return output;
                case 51:
                case 52:
                    output = String.Format("{0} flesh golems", Dice.Roll(2, 0, Modifier, ref random));
                    if (Dice.Percentile(ref random) <= 20)
                        return String.Format("{0} with {1}", output, Treasure.Generate(8, ref random));
                    return output;
                case 53:
                case 54:
                    output = String.Format("{0} gray render", Dice.Roll(1, 0, Modifier, ref random));
                    if (Dice.Percentile(ref random) <= 20)
                        return String.Format("{0} with {1}", output, Treasure.Generate(8, ref random));
                    return output;
                case 55:
                case 56:
                    output = String.Format("{0} hieracosphinxes", Dice.Roll(3, 1, Modifier, ref random));
                    if (Dice.Percentile(ref random) <= 20)
                        return String.Format("{0} with {1}", output, Treasure.Generate(8, ref random));
                    return output;
                case 57:
                case 58:
                case 59:
                    output = String.Format("{0} {1}-headed hydra", Dice.Roll(1, 0, Modifier, ref random), Dice.Roll(1, 3, 7, ref random));
                    if (Dice.Percentile(ref random) <= 20)
                        return String.Format("{0} with {1}", output, Treasure.Generate(8, ref random));
                    return output;
                case 60:
                    output = String.Format("{0} {1}-headed Lernaean hydra", Dice.Roll(1, 0, Modifier, ref random), Dice.Roll(1, 3, 4, ref random));
                    if (Dice.Percentile(ref random) <= 20)
                        return String.Format("{0} with {1}", output, Treasure.Generate(8, ref random));
                    return output;
                case 61:
                case 62:
                    output = String.Format("{0} phase spiders", Dice.Roll(3, 1, Modifier, ref random));
                    if (Dice.Percentile(ref random) <= 20)
                        return String.Format("{0} with {1}", output, Treasure.Generate(8, ref random));
                    return output;
                case 63:
                case 64:
                    output = String.Format("{0} rasts", Dice.Roll(3, 1, Modifier, ref random));
                    if (Dice.Percentile(ref random) <= 20)
                        return String.Format("{0} with {1}", output, Treasure.Generate(8, ref random));
                    return output;
                case 65:
                case 66:
                    output = String.Format("{0} shadow mastiffs", Dice.Roll(3, 1, Modifier, ref random));
                    if (Dice.Percentile(ref random) <= 20)
                        return String.Format("{0} with {1}", output, Treasure.Generate(8, ref random));
                    return output;
                case 67:
                case 68:
                    output = String.Format("{0} winter wolves", Dice.Roll(3, 1, Modifier, ref random));
                    if (Dice.Percentile(ref random) <= 20)
                        return String.Format("{0} with {1}", output, Treasure.Generate(8, ref random));
                    return output;
                case 69:
                case 70:
                    int roll = Dice.Roll(3, 0, Modifier, ref random);
                    output = String.Format("{0} medium-size xorns with", roll);
                    for (int i = roll; i > 0; i--)
                        output += String.Format(" {0},", Treasure.Gems(Dice.Roll(2, 6, 0, ref random), ref random));
                    if (Dice.Percentile(ref random) <= 20)
                        return String.Format("{0} and {1}", output, Treasure.Generate(6, ref random));
                    return output;
                case 71:
                case 72:
                case 73:
                case 74:
                    output = String.Format("{0} drider with {1} large monstrous spiders", Dice.Roll(1, 0, Modifier, ref random), Dice.Roll(3, 1, Modifier, ref random));
                    if (Dice.Percentile(ref random) <= 80)
                        return String.Format("{0} with {1}", output, Treasure.Generate(10, ref random));
                    return output;
                case 75:
                case 76:
                case 77:
                case 78:
                    output = String.Format("{0} ettins", Dice.Roll(3, 1, Modifier, ref random));
                    if (Dice.Percentile(ref random) <= 80)
                        return String.Format("{0} with {1}", output, Treasure.Generate(10, ref random));
                    return output;
                case 79:
                case 80:
                case 81:
                case 82:
                    output = String.Format("{0} manticores", Dice.Roll(3, 1, Modifier, ref random));
                    if (Dice.Percentile(ref random) <= 80)
                        return String.Format("{0} with {1}", output, Treasure.Generate(10, ref random));
                    return output;
                case 83:
                case 84:
                case 85:
                case 86:
                    output = String.Format("{0} medium-size salamanders", Dice.Roll(3, 1, Modifier, ref random));
                    if (Dice.Percentile(ref random) <= 80)
                        return String.Format("{0} with {1}", output, Treasure.Generate(10, ref random));
                    return output;
                case 87:
                case 88:
                case 89:
                case 90:
                    output = String.Format("{0} trolls", Dice.Roll(3, 1, Modifier, ref random));
                    if (Dice.Percentile(ref random) <= 80)
                        return String.Format("{0} with {1}", output, Treasure.Generate(10, ref random));
                    return output;
                default:
                    output = String.Format("{0} spectres", Dice.Roll(2, 0, Modifier, ref random));
                    if (Dice.Percentile(ref random) <= 50)
                        return String.Format("{0} with {1}", output, Treasure.Generate(8, ref random));
                    return output;
            }
        }

        private static string Level9(string Modifier, ref Random random)
        {
            switch (Dice.Percentile(ref random))
            {
                case 1:
                case 2:
                case 3:
                case 4:
                case 5:
                    string output = String.Format("{0} bulettes", Dice.Roll(3, 0, Modifier, ref random));
                    if (Dice.Percentile(ref random) <= 20)
                        return String.Format("{0} with {1}", output, Treasure.Generate(9, ref random));
                    return output;
                case 6:
                case 7:
                case 8:
                case 9:
                case 10:
                    if (Dice.Roll(4, 2, Modifier, ref random) != 0)
                    {
                        output = String.Format("{0} dire lions", Dice.Roll(4, 2, Modifier, ref random));
                        if (Dice.Percentile(ref random) <= 20)
                            return String.Format("{0} with {1}", output, Treasure.Generate(9, ref random));
                        return output;
                    }
                    return Level9(Modifier, ref random);
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
                    output = String.Format("{0} {1}", Dice.Roll(1, 0, Modifier, ref random), Dragon(9, ref random));
                    if (Dice.Percentile(ref random) <= 80)
                        return String.Format("{0} with {1}", output, Treasure.Generate(12, ref random));
                    return output;
                case 21:
                    output = String.Format("{0} bebilith", Dice.Roll(1, 0, Modifier, ref random));
                    if (Dice.Percentile(ref random) <= 80)
                        return String.Format("{0} with {1}", output, Treasure.Generate(11, ref random));
                    return output;
                case 22:
                    output = String.Format("{0} lamias", Dice.Roll(3, 1, Modifier, ref random));
                    if (Dice.Percentile(ref random) <= 80)
                        return String.Format("{0} with {1}", output, Treasure.Generate(11, ref random));
                    return output;
                case 23:
                case 24:
                    output = String.Format("{0} mind flayer and {1} (charmed)", Dice.Roll(1, 0, Modifier, ref random), Level6(Modifier, ref random));
                    if (Dice.Percentile(ref random) <= 80)
                        return String.Format("{0} with {1}", output, Treasure.Generate(11, ref random));
                    return output;
                case 25:
                case 26:
                    output = String.Format("{0} night hag", Dice.Roll(1, 0, Modifier, ref random));
                    if (Dice.Percentile(ref random) <= 80)
                        return String.Format("{0} with {1}", output, Treasure.Generate(11, ref random));
                    return output;
                case 27:
                case 28:
                    if (Dice.Roll(4, 2, Modifier, ref random) != 0)
                    {
                        output = String.Format("{0} ogre mage and {1} ogres", Dice.Roll(1, 0, Modifier, ref random), Dice.Roll(4, 2, Modifier, ref random));
                        if (Dice.Percentile(ref random) <= 80)
                            return String.Format("{0} with {1}", output, Treasure.Generate(11, ref random));
                        return output;
                    }
                    return Level9(Modifier, ref random);
                case 29:
                case 30:
                    output = String.Format("{0} rakshasa", Dice.Roll(1, 0, Modifier, ref random));
                    if (Dice.Percentile(ref random) <= 80)
                        return String.Format("{0} with {1}", output, Treasure.Generate(11, ref random));
                    return output;
                case 31:
                case 32:
                    output = String.Format("{0} succubus", Dice.Roll(1, 0, Modifier, ref random));
                    if (Dice.Percentile(ref random) <= 80)
                        return String.Format("{0} with {1}", output, Treasure.Generate(11, ref random));
                    return output;
                case 33:
                case 34:
                    string genre = "civilized";
                    if (Dice.Percentile(ref random) <= 50)
                        genre = "barbaric";
                    output = String.Format("{0} {1} xill", Dice.Roll(1, 0, Modifier, ref random), genre);
                    if (Dice.Percentile(ref random) <= 80)
                        return String.Format("{0} with {1}", output, Treasure.Generate(11, ref random));
                    return output;
                case 35:
                    genre = "half-blood";
                    if (Dice.Percentile(ref random) <= 50)
                        genre = "pureblood";
                    output = String.Format("{0} {1} yuan-ti", Dice.Roll(1, 0, Modifier, ref random), genre);
                    if (Dice.Percentile(ref random) <= 80)
                        return String.Format("{0} with {1}", output, Treasure.Generate(11, ref random));
                    return output;
                case 36:
                case 37:
                case 38:
                case 39:
                case 40:
                    output = String.Format("{0} androsphinx", Dice.Roll(1, 0, Modifier, ref random));
                    if (Dice.Percentile(ref random) <= 80)
                        return String.Format("{0} with {1}", output, Treasure.Generate(11, ref random));
                    return output;
                case 41:
                case 42:
                case 43:
                case 44:
                case 45:
                    output = "";
                    for (int i = Dice.Roll(3, 1, Modifier, ref random); i > 0; i--)
                        output += String.Format(" {0},", Character.Generate(6, false, ref random));
                    return output;
                case 46:
                case 47:
                    output = String.Format("{0} behirs", Dice.Roll(1, 0, Modifier, ref random));
                    if (Dice.Percentile(ref random) <= 20)
                        return String.Format("{0} with {1}", output, Treasure.Generate(9, ref random));
                    return output;
                case 48:
                case 49:
                    output = String.Format("{0} belkers", Dice.Roll(3, 1, Modifier, ref random));
                    if (Dice.Percentile(ref random) <= 20)
                        return String.Format("{0} with {1}", output, Treasure.Generate(9, ref random));
                    return output;
                case 50:
                    output = String.Format("{0} {1}-headed cryohydra", Dice.Roll(1, 0, Modifier, ref random), Dice.Roll(1, 3, 6, ref random));
                    if (Dice.Percentile(ref random) <= 20)
                        return String.Format("{0} with {1}", output, Treasure.Generate(9, ref random));
                    return output;
                case 51:
                case 52:
                    output = String.Format("{0} delver", Dice.Roll(1, 0, Modifier, ref random));
                    if (Dice.Percentile(ref random) <= 20)
                        return String.Format("{0} with {1}", output, Treasure.Generate(9, ref random));
                    return output;
                case 53:
                case 54:
                    output = String.Format("{0} dragon turtle", Dice.Roll(1, 0, Modifier, ref random));
                    if (Dice.Percentile(ref random) <= 20)
                        return String.Format("{0} with {1}", output, Treasure.Generate(9, ref random));
                    return output;
                case 55:
                    output = String.Format("{0} {1}-headed pyrohydra", Dice.Roll(1, 0, Modifier, ref random), Dice.Roll(1, 3, 6, ref random));
                    if (Dice.Percentile(ref random) <= 20)
                        return String.Format("{0} with {1}", output, Treasure.Generate(9, ref random));
                    return output;
                case 56:
                case 57:
                    output = String.Format("{0} will-o'-wisps", Dice.Roll(3, 1, Modifier, ref random));
                    if (Dice.Percentile(ref random) <= 20)
                        return String.Format("{0} with {1}", output, Treasure.Generate(9, ref random));
                    return output;
                case 58:
                case 59:
                case 60:
                    output = String.Format("{0} wyverns", Dice.Roll(3, 1, Modifier, ref random));
                    if (Dice.Percentile(ref random) <= 20)
                        return String.Format("{0} with {1}", output, Treasure.Generate(9, ref random));
                    return output;
                case 61:
                case 62:
                case 63:
                case 64:
                    output = String.Format("{0} barbazu and {1} osyluths", Dice.Roll(1, 0, Modifier, ref random), Dice.Roll(2, 0, Modifier, ref random));
                    if (Dice.Percentile(ref random) <= 80)
                        return String.Format("{0} with {1}", output, Treasure.Generate(11, ref random));
                    return output;
                case 65:
                case 66:
                case 67:
                case 68:
                    output = String.Format("{0} hill giant and {1} dire wolves", Dice.Roll(1, 0, Modifier, ref random), Dice.Roll(3, 0, Modifier, ref random));
                    if (Dice.Percentile(ref random) <= 80)
                        return String.Format("{0} with {1}", output, Treasure.Generate(11, ref random));
                    return output;
                case 69:
                case 70:
                case 71:
                case 72:
                    output = String.Format("{0} kytons", Dice.Roll(3, 1, Modifier, ref random));
                    if (Dice.Percentile(ref random) <= 80)
                        return String.Format("{0} with {1}", output, Treasure.Generate(11, ref random));
                    return output;
                case 73:
                case 74:
                case 75:
                case 76:
                    output = String.Format("{0} osyluths", Dice.Roll(3, 1, Modifier, ref random));
                    if (Dice.Percentile(ref random) <= 80)
                        return String.Format("{0} with {1}", output, Treasure.Generate(11, ref random));
                    return output;
                case 77:
                case 78:
                case 79:
                case 80:
                    output = String.Format("{0} trolls and {1} dire boars", Dice.Roll(3, 1, Modifier, ref random), Dice.Roll(3, 0, Modifier, ref random));
                    if (Dice.Percentile(ref random) <= 80)
                        return String.Format("{0} with {1}", output, Treasure.Generate(11, ref random));
                    return output;
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
                    output = String.Format("{0} bodaks", Dice.Roll(2, 0, Modifier, ref random));
                    if (Dice.Percentile(ref random) <= 50)
                        return String.Format("{0} with {1}", output, Treasure.Generate(9, ref random));
                    return output;
                default:
                    output = "";
                    for (int i = Dice.Roll(1, 0, Modifier, ref random); i > 0; i--)
                        output += String.Format("1 vampire {0}, ", Character.Generate(Dice.Roll(1, 2, 6, ref random), true, ref random));
                    return output;
            }
        }

        private static string Level10(string Modifier, ref Random random)
        {
            switch (Dice.Percentile(ref random))
            {
                case 1:
                case 2:
                case 3:
                case 4:
                case 5:
                    string output = String.Format("{0} dire bears", Dice.Roll(3, 1, Modifier, ref random));
                    if (Dice.Percentile(ref random) <= 20)
                        return String.Format("{0} with {1}", output, Treasure.Generate(10, ref random));
                    return output;
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
                    output = String.Format("{0} {1}", Dice.Roll(1, 0, Modifier, ref random), Dragon(10, ref random));
                    if (Dice.Percentile(ref random) <= 80)
                        return String.Format("{0} with {1}", output, Treasure.Generate(13, ref random));
                    return output;
                case 16:
                case 17:
                    output = String.Format("{0} aboleths", Dice.Roll(3, 1, Modifier, ref random));
                    if (Dice.Percentile(ref random) <= 80)
                        return String.Format("{0} with {1}", output, Treasure.Generate(12, ref random));
                    return output;
                case 18:
                case 19:
                    output = String.Format("{0} athachs", Dice.Roll(3, 1, Modifier, ref random));
                    if (Dice.Percentile(ref random) <= 80)
                        return String.Format("{0} with {1}", output, Treasure.Generate(12, ref random));
                    return output;
                case 20:
                case 21:
                    output = String.Format("{0} frmian myrmarch", Dice.Roll(1, 0, Modifier, ref random));
                    if (Dice.Percentile(ref random) <= 80)
                        return String.Format("{0} with {1}", output, Treasure.Generate(12, ref random));
                    return output;
                case 22:
                case 23:
                case 24:
                    output = String.Format("{0} medusas", Dice.Roll(3, 1, Modifier, ref random));
                    if (Dice.Percentile(ref random) <= 80)
                        return String.Format("{0} with {1}", output, Treasure.Generate(12, ref random));
                    return output;
                case 25:
                case 26:
                    output = String.Format("{0} water nagas", Dice.Roll(3, 1, Modifier, ref random));
                    if (Dice.Percentile(ref random) <= 80)
                        return String.Format("{0} with {1}", output, Treasure.Generate(12, ref random));
                    return output;
                case 27:
                case 28:
                    output = String.Format("{0} night hag and {1} nightmare", Dice.Roll(1, 0, Modifier, ref random), Dice.Roll(1, 0, Modifier, ref random));
                    if (Dice.Percentile(ref random) <= 80)
                        return String.Format("{0} with {1}", output, Treasure.Generate(12, ref random));
                    return output;
                case 29:
                case 30:
                    output = String.Format("{0} large salamander and {1} medium-size salamanders", Dice.Roll(1, 0, Modifier, ref random), Dice.Roll(3, 0, Modifier, ref random));
                    if (Dice.Percentile(ref random) <= 80)
                        return String.Format("{0} with {1}", output, Treasure.Generate(12, ref random));
                    return output;
                case 31:
                case 32:
                    output = String.Format("{0} yuan-ti abominations", Dice.Roll(3, 1, Modifier, ref random));
                    if (Dice.Percentile(ref random) <= 80)
                        return String.Format("{0} with {1}", output, Treasure.Generate(12, ref random));
                    return output;
                case 33:
                case 34:
                case 35:
                case 36:
                case 37:
                    output = String.Format("{0} lillends", Dice.Roll(3, 1, Modifier, ref random));
                    if (Dice.Percentile(ref random) <= 80)
                        return String.Format("{0} with {1}", output, Treasure.Generate(12, ref random));
                    return output;
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
                    output = "";
                    for (int i = Dice.Roll(3, 1, Modifier, ref random); i > 0; i--)
                        output += String.Format(" {0},", Character.Generate(7, false, ref random));
                    return output;
                case 48:
                case 49:
                    output = String.Format("{0} chaos beasts", Dice.Roll(3, 1, Modifier, ref random));
                    if (Dice.Percentile(ref random) <= 20)
                        return String.Format("{0} with {1}", output, Treasure.Generate(10, ref random));
                    return output;
                case 50:
                case 51:
                    output = String.Format("{0} chimeras", Dice.Roll(3, 1, Modifier, ref random));
                    if (Dice.Percentile(ref random) <= 20)
                        return String.Format("{0} with {1}", output, Treasure.Generate(10, ref random));
                    return output;
                case 52:
                case 53:
                    output = String.Format("{0} chuuls", Dice.Roll(3, 1, Modifier, ref random));
                    if (Dice.Percentile(ref random) <= 20)
                        return String.Format("{0} with {1}", output, Treasure.Generate(10, ref random));
                    return output;
                case 54:
                    output = String.Format("{0} {1}-headed Lernaean cryohydra", Dice.Roll(1, 0, Modifier, ref random), Dice.Roll(1, 4, 4, ref random));
                    if (Dice.Percentile(ref random) <= 20)
                        return String.Format("{0} with {1}", output, Treasure.Generate(10, ref random));
                    return output;
                case 55:
                case 56:
                    output = String.Format("{0} dragonnes", Dice.Roll(3, 1, Modifier, ref random));
                    if (Dice.Percentile(ref random) <= 20)
                        return String.Format("{0} with {1}", output, Treasure.Generate(10, ref random));
                    return output;
                case 57:
                case 58:
                    output = String.Format("{0} hellcats", Dice.Roll(3, 1, Modifier, ref random));
                    if (Dice.Percentile(ref random) <= 20)
                        return String.Format("{0} with {1}", output, Treasure.Generate(10, ref random));
                    return output;
                case 59:
                    output = String.Format("{0} {1}-headed hydra", Dice.Roll(1, 0, Modifier, ref random), Dice.Roll(1, 3, 9, ref random));
                    if (Dice.Percentile(ref random) <= 20)
                        return String.Format("{0} with {1}", output, Treasure.Generate(10, ref random));
                    return output;
                case 60:
                    output = String.Format("{0} phasm", Dice.Roll(1, 0, Modifier, ref random));
                    if (Dice.Percentile(ref random) <= 20)
                        return String.Format("{0} with {1}", output, Treasure.Generate(10, ref random));
                    return output;
                case 61:
                    output = String.Format("{0} {1}-headed Lernaean pyrohydra", Dice.Roll(1, 0, Modifier, ref random), Dice.Roll(1, 4, 4, ref random));
                    if (Dice.Percentile(ref random) <= 20)
                        return String.Format("{0} with {1}", output, Treasure.Generate(10, ref random));
                    return output;
                case 62:
                case 63:
                    output = String.Format("{0} retriever", Dice.Roll(1, 0, Modifier, ref random));
                    if (Dice.Percentile(ref random) <= 20)
                        return String.Format("{0} with {1}", output, Treasure.Generate(10, ref random));
                    return output;
                case 64:
                case 65:
                    output = String.Format("{0} red slaadi", Dice.Roll(3, 1, Modifier, ref random));
                    if (Dice.Percentile(ref random) <= 80)
                        return String.Format("{0} with {1}", output, Treasure.Generate(12, ref random));
                    return output;
                case 66:
                case 67:
                    output = String.Format("{0} umber hulks", Dice.Roll(3, 1, Modifier, ref random));
                    if (Dice.Percentile(ref random) <= 20)
                        return String.Format("{0} with {1}", output, Treasure.Generate(10, ref random));
                    return output;
                case 68:
                case 69:
                case 70:
                case 71:
                    output = String.Format("{0} barbazu", Dice.Roll(3, 1, Modifier, ref random));
                    if (Dice.Percentile(ref random) <= 80)
                        return String.Format("{0} with {1}", output, Treasure.Generate(12, ref random));
                    return output;
                case 72:
                case 73:
                case 74:
                case 75:
                    output = String.Format("{0} driders", Dice.Roll(3, 1, Modifier, ref random));
                    if (Dice.Percentile(ref random) <= 80)
                        return String.Format("{0} with {1}", output, Treasure.Generate(12, ref random));
                    return output;
                case 76:
                case 77:
                case 78:
                case 79:
                    output = String.Format("{0} frost giant and {1} winter wolves", Dice.Roll(1, 0, Modifier, ref random), Dice.Roll(3, 1, Modifier, ref random));
                    if (Dice.Percentile(ref random) <= 80)
                        return String.Format("{0} with {1}", output, Treasure.Generate(12, ref random));
                    return output;
                case 80:
                case 81:
                case 82:
                case 83:
                    output = String.Format("{0} stone giant and {1} dire bears", Dice.Roll(1, 0, Modifier, ref random), Dice.Roll(3, 1, Modifier, ref random));
                    if (Dice.Percentile(ref random) <= 80)
                        return String.Format("{0} with {1}", output, Treasure.Generate(12, ref random));
                    return output;
                case 84:
                case 85:
                case 86:
                case 87:
                    output = String.Format("{0} hill giants", Dice.Roll(3, 1, Modifier, ref random));
                    if (Dice.Percentile(ref random) <= 80)
                        return String.Format("{0} with {1}", output, Treasure.Generate(12, ref random));
                    return output;
                case 88:
                case 89:
                case 90:
                    output = String.Format("{0} hamatula and {1} barbazu", Dice.Roll(1, 0, Modifier, ref random), Dice.Roll(2, 0, Modifier, ref random));
                    if (Dice.Percentile(ref random) <= 80)
                        return String.Format("{0} with {1}", output, Treasure.Generate(12, ref random));
                    return output;
                default:
                    output = "";
                    for (int i = Dice.Roll(1, 0, Modifier, ref random); i > 0; i--)
                        output += String.Format("1 ghost {0}, ", Character.Generate(Dice.Roll(1, 3, 6, ref random), false, ref random));
                    if (Dice.Percentile(ref random) <= 50)
                        return String.Format("{0} with {1}", output, Treasure.Generate(10, ref random));
                    return output;
            }
        }

        private static string Level11(string Modifier, ref Random random)
        {
            switch (Dice.Percentile(ref random))
            {
                case 1:
                case 2:
                case 3:
                case 4:
                case 5:
                    string output = String.Format("{0} dire tigers", Dice.Roll(3, 0, Modifier, ref random));
                    if (Dice.Percentile(ref random) <= 20)
                        return String.Format("{0} with {1}", output, Treasure.Generate(11, ref random));
                    return output;
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
                    output = String.Format("{0} {1}", Dice.Roll(1, 0, Modifier, ref random), Dragon(11, ref random));
                    if (Dice.Percentile(ref random) <= 80)
                        return String.Format("{0} with {1}", output, Treasure.Generate(14, ref random));
                    return output;
                case 16:
                case 17:
                case 18:
                    if (Dice.Roll(4, 2, Modifier, ref random) != 0)
                    {
                        output = String.Format("{0} covey of hags (each covey: {1} green hag, {2} annis, {3} sea hag, {4} ogres, {5} hill giants)", Dice.Roll(1, 0, Modifier, ref random), Dice.Roll(1, 0, Modifier, ref random), Dice.Roll(1, 0, Modifier, ref random), Dice.Roll(1, 0, Modifier, ref random), Dice.Roll(4, 2, Modifier, ref random), Dice.Roll(3, 0, Modifier, ref random));
                        if (Dice.Percentile(ref random) <= 80)
                            return String.Format("{0} with {1}", output, Treasure.Generate(12, ref random));
                        return output;
                    }
                    return Level11(Modifier, ref random);
                case 19:
                case 20:
                case 21:
                    output = String.Format("{0} efreet", Dice.Roll(3, 1, Modifier, ref random));
                    if (Dice.Percentile(ref random) <= 80)
                        return String.Format("{0} with {1}", output, Treasure.Generate(12, ref random));
                    return output;
                case 22:
                case 23:
                case 24:
                    if (Dice.Roll(6, 3, Modifier, ref random) != 0)
                    {
                        output = String.Format("{0} formian myrmarch and {1} formian warriors", Dice.Roll(1, 0, Modifier, ref random), Dice.Roll(6, 3, Modifier, ref random));
                        if (Dice.Percentile(ref random) <= 80)
                            return String.Format("{0} with {1}", output, Treasure.Generate(12, ref random));
                        return output;
                    }
                    return Level11(Modifier, ref random);
                case 25:
                case 26:
                case 27:
                    output = String.Format("{0} gynosphinxes", Dice.Roll(3, 1, Modifier, ref random));
                    if (Dice.Percentile(ref random) <= 80)
                        return String.Format("{0} with {1}", output, Treasure.Generate(12, ref random));
                    return output;
                case 28:
                case 29:
                case 30:
                    output = String.Format("{0} dark nagas", Dice.Roll(3, 1, Modifier, ref random));
                    if (Dice.Percentile(ref random) <= 80)
                        return String.Format("{0} with {1}", output, Treasure.Generate(12, ref random));
                    return output;
                case 31:
                case 32:
                case 33:
                case 34:
                case 35:
                    output = String.Format("{0} avoral guardinal", Dice.Roll(3, 0, Modifier, ref random));
                    if (Dice.Percentile(ref random) <= 80)
                        return String.Format("{0} with {1}", output, Treasure.Generate(12, ref random));
                    return output;
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
                    output = "";
                    for (int i = Dice.Roll(3, 1, Modifier, ref random); i > 0; i--)
                        output += String.Format(" {0},", Character.Generate(8, false, ref random));
                    return output;
                case 46:
                case 47:
                case 48:
                    output = String.Format("{0} large arrowhawks", Dice.Roll(3, 1, Modifier, ref random));
                    if (Dice.Percentile(ref random) <= 20)
                        return String.Format("{0} with {1}", output, Treasure.Generate(11, ref random));
                    return output;
                case 49:
                case 50:
                case 51:
                    output = String.Format("{0} destrachans", Dice.Roll(3, 1, Modifier, ref random));
                    if (Dice.Percentile(ref random) <= 20)
                        return String.Format("{0} with {1}", output, Treasure.Generate(11, ref random));
                    return output;
                case 52:
                case 53:
                case 54:
                    output = String.Format("{0} clay golems", Dice.Roll(2, 0, Modifier, ref random));
                    if (Dice.Percentile(ref random) <= 20)
                        return String.Format("{0} with {1}", output, Treasure.Generate(11, ref random));
                    return output;
                case 55:
                case 56:
                case 57:
                    output = String.Format("{0} gorgons", Dice.Roll(3, 1, Modifier, ref random));
                    if (Dice.Percentile(ref random) <= 20)
                        return String.Format("{0} with {1}", output, Treasure.Generate(11, ref random));
                    return output;
                case 58:
                case 59:
                    output = String.Format("{0} {1}-headed Lernaean hydra", Dice.Roll(1, 0, Modifier, ref random), Dice.Roll(1, 3, 7, ref random));
                    if (Dice.Percentile(ref random) <= 20)
                        return String.Format("{0} with {1}", output, Treasure.Generate(11, ref random));
                    return output;
                case 60:
                case 61:
                case 62:
                    output = String.Format("{0} blue slaadi", Dice.Roll(3, 1, Modifier, ref random));
                    if (Dice.Percentile(ref random) <= 80)
                        return String.Format("{0} with {1}", output, Treasure.Generate(12, ref random));
                    return output;
                case 63:
                case 64:
                case 65:
                    int roll = Dice.Roll(3, 1, Modifier, ref random);
                    output = String.Format("{0} large xorns with", roll);
                    for (int i = roll; i > 0; i--)
                        output += String.Format(" {0},", Treasure.Gems(Dice.Roll(4, 6, 0, ref random), ref random));
                    if (Dice.Percentile(ref random) <= 20)
                        return String.Format("{0} and {1}", output, Treasure.Generate(11, ref random));
                    return output;
                case 66:
                case 67:
                case 68:
                case 69:
                case 70:
                    if (Dice.Roll(6, 3, Modifier, ref random) != 0)
                    {
                        output = String.Format("{0} fire giant and {1} hell hounds", Dice.Roll(1, 0, Modifier, ref random), Dice.Roll(6, 3, Modifier, ref random));
                        if (Dice.Percentile(ref random) <= 80)
                            return String.Format("{0} with {1}", output, Treasure.Generate(12, ref random));
                        return output;
                    }
                    return Level11(Modifier, ref random);
                case 71:
                case 72:
                case 73:
                case 74:
                case 75:
                    output = String.Format("{0} stone giants", Dice.Roll(3, 1, Modifier, ref random));
                    if (Dice.Percentile(ref random) <= 80)
                        return String.Format("{0} with {1}", output, Treasure.Generate(12, ref random));
                    return output;
                case 76:
                case 77:
                case 78:
                case 79:
                case 80:
                    output = String.Format("{0} hamatulas", Dice.Roll(3, 1, Modifier, ref random));
                    if (Dice.Percentile(ref random) <= 80)
                        return String.Format("{0} with {1}", output, Treasure.Generate(12, ref random));
                    return output;
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
                    output = String.Format("{0} devourer", Dice.Roll(1, 0, Modifier, ref random));
                    if (Dice.Percentile(ref random) <= 50)
                        return String.Format("{0} with {1}", output, Treasure.Generate(11, ref random));
                    return output;
                default:
                    output = String.Format("{0} mohrgs", Dice.Roll(3, 1, Modifier, ref random));
                    if (Dice.Percentile(ref random) <= 50)
                        return String.Format("{0} with {1}", output, Treasure.Generate(11, ref random));
                    return output;
            }
        }

        private static string Level12(string Modifier, ref Random random)
        {
            switch (Dice.Percentile(ref random))
            {
                case 1:
                case 2:
                case 3:
                case 4:
                    string output = String.Format("{0} purple worm", Dice.Roll(1, 0, Modifier, ref random));
                    if (Dice.Percentile(ref random) <= 20)
                        return String.Format("{0} with {1}", output, Treasure.Generate(12, ref random));
                    return output;
                case 5:
                    output = String.Format("{0} colossal monstrous scorpions", Dice.Roll(2, 0, Modifier, ref random));
                    if (Dice.Percentile(ref random) <= 20)
                        return String.Format("{0} with {1}", output, Treasure.Generate(12, ref random));
                    return output;
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
                    output = String.Format("{0} {1}", Dice.Roll(1, 0, Modifier, ref random), Dragon(12, ref random));
                    if (Dice.Percentile(ref random) <= 80)
                        return String.Format("{0} with {1}", output, Treasure.Generate(15, ref random));
                    return output;
                case 16:
                case 17:
                case 18:
                case 19:
                case 20:
                    if (Dice.Roll(4, 2, Modifier, ref random) != 0)
                    {
                        output = String.Format("an inquisition of {0} mind flayers", Dice.Roll(4, 2, Modifier, ref random));
                        if (Dice.Percentile(ref random) <= 50)
                            return String.Format("{0} with {1}", output, Treasure.Generate(13, ref random));
                        return output;
                    }
                    return Level12(Modifier, ref random);
                case 21:
                case 22:
                case 23:
                case 24:
                case 25:
                    output = String.Format("{0} spirit nagas", Dice.Roll(3, 1, Modifier, ref random));
                    if (Dice.Percentile(ref random) <= 50)
                        return String.Format("{0} with {1}", output, Treasure.Generate(13, ref random));
                    return output;
                case 26:
                case 27:
                case 28:
                case 29:
                case 30:
                    output = String.Format("{0} green slaadi", Dice.Roll(3, 1, Modifier, ref random));
                    if (Dice.Percentile(ref random) <= 50)
                        return String.Format("{0} with {1}", output, Treasure.Generate(13, ref random));
                    return output;
                case 31:
                case 32:
                case 33:
                case 34:
                case 35:
                    if (Dice.Roll(4, 2, Modifier, ref random) != 0)
                    {
                        output = String.Format("{0} good cloud giant and {1} dire lions", Dice.Roll(1, 0, Modifier, ref random), Dice.Roll(4, 2, Modifier, ref random));
                        if (Dice.Percentile(ref random) <= 50)
                            return String.Format("{0} with {1}", output, Treasure.Generate(13, ref random));
                        return output;
                    }
                    return Level12(Modifier, ref random);
                case 51:
                case 52:
                case 53:
                case 54:
                case 55:
                    output = String.Format("{0} {1}-headed cryohydra", Dice.Roll(1, 0, Modifier, ref random), Dice.Roll(1, 3, 9, ref random));
                    if (Dice.Percentile(ref random) <= 20)
                        return String.Format("{0} with {1}", output, Treasure.Generate(12, ref random));
                    return output;
                case 56:
                case 57:
                case 58:
                case 59:
                case 60:
                    output = String.Format("{0} stone golems", Dice.Roll(2, 0, Modifier, ref random));
                    if (Dice.Percentile(ref random) <= 20)
                        return String.Format("{0} with {1}", output, Treasure.Generate(12, ref random));
                    return output;
                case 61:
                case 62:
                case 63:
                case 64:
                case 65:
                    output = String.Format("{0} {1}-headed pyrohydra", Dice.Roll(1, 0, Modifier, ref random), Dice.Roll(1, 3, 9, ref random));
                    if (Dice.Percentile(ref random) <= 20)
                        return String.Format("{0} with {1}", output, Treasure.Generate(12, ref random));
                    return output;
                case 66:
                case 67:
                case 68:
                case 69:
                case 70:
                    output = String.Format("{0} yrthaks", Dice.Roll(3, 1, Modifier, ref random));
                    if (Dice.Percentile(ref random) <= 20)
                        return String.Format("{0} with {1}", output, Treasure.Generate(12, ref random));
                    return output;
                case 71:
                case 72:
                case 73:
                case 74:
                case 75:
                    output = String.Format("{0} cornugon and {1} hamatulas", Dice.Roll(1, 0, Modifier, ref random), Dice.Roll(3, 0, Modifier, ref random));
                    if (Dice.Percentile(ref random) <= 50)
                        return String.Format("{0} with {1}", output, Treasure.Generate(13, ref random));
                    return output;
                case 76:
                case 77:
                case 78:
                case 79:
                case 80:
                    if (Dice.Roll(4, 2, Modifier, ref random) != 0)
                    {
                        output = String.Format("{0} evil cloud giant and {1} dire lions", Dice.Roll(1, 0, Modifier, ref random), Dice.Roll(4, 2, Modifier, ref random));
                        if (Dice.Percentile(ref random) <= 50)
                            return String.Format("{0} with {1}", output, Treasure.Generate(13, ref random));
                        return output;
                    }
                    return Level12(Modifier, ref random);
                case 81:
                case 82:
                case 83:
                case 84:
                case 85:
                    output = String.Format("{0} frost giants", Dice.Roll(3, 1, Modifier, ref random));
                    if (Dice.Percentile(ref random) <= 50)
                        return String.Format("{0} with {1}", output, Treasure.Generate(13, ref random));
                    return output;
                case 86:
                case 87:
                case 88:
                case 89:
                case 90:
                    output = String.Format("{0} large salamanders", Dice.Roll(3, 1, Modifier, ref random));
                    if (Dice.Percentile(ref random) <= 50)
                        return String.Format("{0} with {1}", output, Treasure.Generate(13, ref random));
                    return output;
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
                    output = "";
                    for (int i = Dice.Roll(1, 0, Modifier, ref random); i > 0; i--)
                        output += String.Format("1 vampire {0}, ", Character.Generate(Dice.Roll(1, 3, 8, ref random), true, ref random));
                    return output;
                default:
                    output = "";
                    for (int i = Dice.Roll(3, 1, Modifier, ref random); i > 0; i--)
                        output += String.Format(" {0},", Character.Generate(9, false, ref random));
                    return output;
            }
        }

        private static string Level13(string Modifier, ref Random random)
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
                case 15:
                    string output = String.Format("{0} {1}", Dice.Roll(1, 0, Modifier, ref random), Dragon(13, ref random));
                    if (Dice.Percentile(ref random) <= 80)
                        return String.Format("{0} with {1}", output, Treasure.Generate(16, ref random));
                    return output;
                case 16:
                case 17:
                case 18:
                case 19:
                case 20:
                    output = String.Format("{0} beholder", Dice.Roll(1, 0, Modifier, ref random));
                    if (Dice.Percentile(ref random) <= 50)
                        return String.Format("{0} with {1}", output, Treasure.Generate(14, ref random));
                    return output;
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
                    output = String.Format("{0} night hags and {1} nightmares", Dice.Roll(3, 0, Modifier, ref random), Dice.Roll(3, 0, Modifier, ref random));
                    if (Dice.Percentile(ref random) <= 50)
                        return String.Format("{0} with {1}", output, Treasure.Generate(14, ref random));
                    return output;
                case 31:
                case 32:
                case 33:
                case 34:
                case 35:
                    output = String.Format("{0} gray slaadi", Dice.Roll(3, 1, Modifier, ref random));
                    if (Dice.Percentile(ref random) <= 50)
                        return String.Format("{0} with {1}", output, Treasure.Generate(14, ref random));
                    return output;
                case 36:
                case 37:
                case 38:
                case 39:
                case 40:
                    output = String.Format("{0} couatls", Dice.Roll(3, 1, Modifier, ref random));
                    if (Dice.Percentile(ref random) <= 50)
                        return String.Format("{0} with {1}", output, Treasure.Generate(14, ref random));
                    return output;
                case 41:
                case 42:
                case 43:
                case 44:
                case 45:
                    output = String.Format("{0} guardian nagas", Dice.Roll(3, 1, Modifier, ref random));
                    if (Dice.Percentile(ref random) <= 50)
                        return String.Format("{0} with {1}", output, Treasure.Generate(14, ref random));
                    return output;
                case 61:
                case 62:
                case 63:
                case 64:
                case 65:
                case 66:
                case 67:
                    output = String.Format("{0} frost worms", Dice.Roll(2, 0, Modifier, ref random));
                    if (Dice.Percentile(ref random) <= 20)
                        return String.Format("{0} with {1}", output, Treasure.Generate(13, ref random));
                    return output;
                case 68:
                case 69:
                case 70:
                case 71:
                case 72:
                case 73:
                    output = String.Format("{0} {1}-headed Lernaean hydra", Dice.Roll(1, 0, Modifier, ref random), Dice.Roll(1, 3, 9, ref random));
                    if (Dice.Percentile(ref random) <= 20)
                        return String.Format("{0} with {1}", output, Treasure.Generate(13, ref random));
                    return output;
                case 74:
                case 75:
                case 76:
                case 77:
                case 78:
                case 79:
                case 80:
                    output = String.Format("{0} ropers", Dice.Roll(3, 1, Modifier, ref random));
                    if (Dice.Percentile(ref random) <= 20)
                        return String.Format("{0} with {1}", output, Treasure.Generate(13, ref random));
                    return output;
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
                    output = String.Format("{0} cornugons", Dice.Roll(3, 1, Modifier, ref random));
                    if (Dice.Percentile(ref random) <= 50)
                        return String.Format("{0} with {1}", output, Treasure.Generate(14, ref random));
                    return output;
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
                    output = "";
                    for (int i = Dice.Roll(1, 0, Modifier, ref random); i > 0; i--)
                        output += String.Format("1 ghost {0}, ", Character.Generate(Dice.Roll(1, 3, 9, ref random), false, ref random));
                    if (Dice.Percentile(ref random) <= 50)
                        return String.Format("{0} with {1}", output, Treasure.Generate(13, ref random));
                    return output;
                default:
                    output = "";
                    for (int i = Dice.Roll(3, 1, Modifier, ref random); i > 0; i--)
                        output += String.Format(" {0},", Character.Generate(10, false, ref random));
                    return output;
            }
        }

        private static string Level14(string Modifier, ref Random random)
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
                case 15:
                    string output = String.Format("{0} {1}", Dice.Roll(1, 0, Modifier, ref random), Dragon(14, ref random));
                    if (Dice.Percentile(ref random) <= 80)
                        return String.Format("{0} with {1}", output, Treasure.Generate(16, ref random));
                    return output;
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
                    output = String.Format("{0} beholder and (charmed) {1}", Dice.Roll(1, 0, Modifier, ref random), Level11(Modifier, ref random));
                    if (Dice.Percentile(ref random) <= 50)
                        return String.Format("{0} with {1}", output, Treasure.Generate(15, ref random));
                    return output;
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
                    output = String.Format("{0} death slaadi", Dice.Roll(2, 0, Modifier, ref random));
                    if (Dice.Percentile(ref random) <= 50)
                        return String.Format("{0} with {1}", output, Treasure.Generate(15, ref random));
                    return output;
                case 36:
                case 37:
                case 38:
                case 39:
                case 40:
                    output = String.Format("{0} good cloud giant", Dice.Roll(3, 1, Modifier, ref random));
                    if (Dice.Percentile(ref random) <= 50)
                        return String.Format("{0} with {1}", output, Treasure.Generate(15, ref random));
                    return output;
                case 56:
                case 57:
                case 58:
                case 59:
                case 60:
                    output = String.Format("{0} {1}-headed Lernaean cryohydra", Dice.Roll(1, 0, Modifier, ref random), Dice.Roll(1, 4, 8, ref random));
                    if (Dice.Percentile(ref random) <= 20)
                        return String.Format("{0} with {1}", output, Treasure.Generate(14, ref random));
                    return output;
                case 61:
                case 62:
                case 63:
                case 64:
                case 65:
                    output = String.Format("{0} iron golems", Dice.Roll(2, 0, Modifier, ref random));
                    if (Dice.Percentile(ref random) <= 50)
                        return String.Format("{0} with {1}", output, Treasure.Generate(14, ref random));
                    return output;
                case 66:
                case 67:
                case 68:
                case 69:
                case 70:
                    output = String.Format("{0} {1}-headed Lernaean pyrohydra", Dice.Roll(1, 0, Modifier, ref random), Dice.Roll(1, 4, 8, ref random));
                    if (Dice.Percentile(ref random) <= 20)
                        return String.Format("{0} with {1}", output, Treasure.Generate(14, ref random));
                    return output;
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
                    output = String.Format("{0} evil cloud giants", Dice.Roll(3, 1, Modifier, ref random));
                    if (Dice.Percentile(ref random) <= 50)
                        return String.Format("{0} with {1}", output, Treasure.Generate(15, ref random));
                    return output;
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
                    if (Dice.Roll(4, 2, Modifier, ref random) != 0)
                    {
                        output = String.Format("{0} storm giant and {1} griffons", Dice.Roll(1, 0, Modifier, ref random), Dice.Roll(4, 2, Modifier, ref random));
                        if (Dice.Percentile(ref random) <= 50)
                            return String.Format("{0} with {1}", output, Treasure.Generate(15, ref random));
                        return output;
                    }
                    return Level14(Modifier, ref random);
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
                    int Roll; string NPCclass; output = "";
                    for (int i = Dice.Roll(1, 0, Modifier, ref random); i > 0; i--)
                    {
                        Roll = Dice.Percentile(ref random);
                        if (Roll <= 10)
                            NPCclass = String.Format("cleric {0}", Character.EvilRace((int)Character.CLASS.CLERIC, Dice.Roll(1, 3, 10, ref random), 100, ref random));
                        else if (Roll <= 30)
                            NPCclass = String.Format("sorcerer {0}", Character.EvilRace((int)Character.CLASS.SORCERER, Dice.Roll(1, 3, 10, ref random), 100, ref random));
                        else
                            NPCclass = String.Format("wizard {0}", Character.EvilRace((int)Character.CLASS.WIZARD, Dice.Roll(1, 3, 10, ref random), 100, ref random));

                        output += String.Format("1 lich {1}", NPCclass);
                    }
                    return output;
                default:
                    output = "";
                    for (int i = Dice.Roll(3, 1, Modifier, ref random); i > 0; i--)
                        output += String.Format(" {0},", Character.Generate(11, false, ref random));
                    return output;
            }
        }

        private static string Level15(string Modifier, ref Random random)
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
                case 15:
                case 16:
                case 17:
                case 18:
                case 19:
                case 20:
                    string output = String.Format("{0} {1}", Dice.Roll(1, 0, Modifier, ref random), Dragon(15, ref random));
                    if (Dice.Percentile(ref random) <= 80)
                        return String.Format("{0} with {1}", output, Treasure.Generate(16, ref random));
                    return output;
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
                    output = String.Format("{0} beholders", Dice.Roll(3, 0, Modifier, ref random));
                    if (Dice.Percentile(ref random) <= 50)
                        return String.Format("{0} with {1}", output, Treasure.Generate(15, ref random));
                    return output;
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
                    output = String.Format("{0} death slaadi and {1} green slaadi", Dice.Roll(2, 0, Modifier, ref random), Dice.Roll(3, 1, Modifier, ref random));
                    if (Dice.Percentile(ref random) <= 50)
                        return String.Format("{0} with {1}", output, Treasure.Generate(15, ref random));
                    return output;
                case 41:
                case 42:
                case 43:
                case 44:
                case 45:
                    output = String.Format("{0} ghaeles", Dice.Roll(3, 0, Modifier, ref random));
                    if (Dice.Percentile(ref random) <= 80)
                        return String.Format("{0} with {1}", output, Treasure.Generate(15, ref random));
                    return output;
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
                    output = String.Format("{0} hezrous", Dice.Roll(2, 0, Modifier, ref random));
                    if (Dice.Percentile(ref random) <= 50)
                        return String.Format("{0} with {1}", output, Treasure.Generate(15, ref random));
                    return output;
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
                    output = String.Format("{0} gelugon and {1} cornugons", Dice.Roll(1, 0, Modifier, ref random), Dice.Roll(3, 1, Modifier, ref random));
                    if (Dice.Percentile(ref random) <= 50)
                        return String.Format("{0} with {1}", output, Treasure.Generate(15, ref random));
                    return output;
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
                    output = "";
                    for (int i = Dice.Roll(1, 0, Modifier, ref random); i > 0; i--)
                        output += String.Format("1 vampire {0}, ", Character.Generate(Dice.Roll(1, 3, 11, ref random), true, ref random));
                    return output;
                default:
                    output = "";
                    for (int i = Dice.Roll(3, 1, Modifier, ref random); i > 0; i--)
                        output += String.Format(" {0},", Character.Generate(12, false, ref random));
                    return output;
            }
        }

        private static string Level16(string Modifier, ref Random random)
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
                case 15:
                case 16:
                case 17:
                case 18:
                case 19:
                case 20:
                    string output = String.Format("{0} {1}", Dice.Roll(1, 0, Modifier, ref random), Dragon(16, ref random));
                    if (Dice.Percentile(ref random) <= 80)
                        return String.Format("{0} with {1}", output, Treasure.Generate(17, ref random));
                    return output;
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
                    output = String.Format("{0} pit fiend", Dice.Roll(1, 0, Modifier, ref random));
                    if (Dice.Percentile(ref random) <= 50)
                        return String.Format("{0} with {1}", output, Treasure.Generate(16, ref random));
                    return output;
                case 31:
                case 32:
                case 33:
                case 34:
                case 35:
                    output = String.Format("{0} astral devas", Dice.Roll(3, 0, Modifier, ref random));
                    if (Dice.Percentile(ref random) <= 50)
                        return String.Format("{0} with {1}", output, Treasure.Generate(16, ref random));
                    return output;
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
                    output = String.Format("{0} gelugons", Dice.Roll(3, 1, Modifier, ref random));
                    if (Dice.Percentile(ref random) <= 50)
                        return String.Format("{0} with {1}", output, Treasure.Generate(15, ref random));
                    return output;
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
                    output = String.Format("{0} storm giants", Dice.Roll(3, 1, Modifier, ref random));
                    if (Dice.Percentile(ref random) <= 50)
                        return String.Format("{0} with {1}", output, Treasure.Generate(15, ref random));
                    return output;
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
                    output = String.Format("{0} vrocks", Dice.Roll(3, 1, Modifier, ref random));
                    if (Dice.Percentile(ref random) <= 50)
                        return String.Format("{0} with {1}", output, Treasure.Generate(15, ref random));
                    return output;
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
                    output = "";
                    for (int i = Dice.Roll(1, 0, Modifier, ref random); i > 0; i--)
                        output += String.Format("1 ghost {0}, ", Character.Generate(Dice.Roll(1, 3, 12, ref random), false, ref random));
                    if (Dice.Percentile(ref random) <= 20)
                        return String.Format("{0} with {1}", output, Treasure.Generate(16, ref random));
                    return output;
                default:
                    output = "";
                    for (int i = Dice.Roll(3, 1, Modifier, ref random); i > 0; i--)
                        output += String.Format(" {0},", Character.Generate(13, false, ref random));
                    return output;
            }
        }

        private static string Level17(string Modifier, ref Random random)
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
                case 15:
                case 16:
                case 17:
                case 18:
                case 19:
                case 20:
                    string output = String.Format("{0} {1}", Dice.Roll(1, 0, Modifier, ref random), Dragon(17, ref random));
                    if (Dice.Percentile(ref random) <= 80)
                        return String.Format("{0} with {1}", output, Treasure.Generate(18, ref random));
                    return output;
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
                    output = String.Format("{0} marilith", Dice.Roll(1, 0, Modifier, ref random));
                    if (Dice.Percentile(ref random) <= 50)
                        return String.Format("{0} with {1}", output, Treasure.Generate(17, ref random));
                    return output;
                case 31:
                case 32:
                case 33:
                case 34:
                case 35:
                    output = String.Format("{0} trumpet archons", Dice.Roll(3, 1, Modifier, ref random));
                    if (Dice.Percentile(ref random) <= 50)
                        return String.Format("{0} with {1}", output, Treasure.Generate(17, ref random));
                    return output;
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
                    output = String.Format("{0} glabrezu", Dice.Roll(3, 0, Modifier, ref random));
                    if (Dice.Percentile(ref random) <= 50)
                        return String.Format("{0} with {1}", output, Treasure.Generate(17, ref random));
                    return output;
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
                    output = String.Format("{0} hezrous", Dice.Roll(3, 0, Modifier, ref random));
                    if (Dice.Percentile(ref random) <= 50)
                        return String.Format("{0} with {1}", output, Treasure.Generate(17, ref random));
                    return output;
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
                    int Roll; string NPCclass; output = "";
                    for (int i = Dice.Roll(1, 0, Modifier, ref random); i > 0; i--)
                    {
                        Roll = Dice.Percentile(ref random);
                        if (Roll <= 10)
                            NPCclass = String.Format("cleric {0}", Character.EvilRace((int)Character.CLASS.CLERIC, Dice.Roll(1, 3, 13, ref random), 100, ref random));
                        else if (Roll <= 30)
                            NPCclass = String.Format("sorcerer {0}", Character.EvilRace((int)Character.CLASS.SORCERER, Dice.Roll(1, 3, 13, ref random), 100, ref random));
                        else
                            NPCclass = String.Format("wizard {0}", Character.EvilRace((int)Character.CLASS.WIZARD, Dice.Roll(1, 3, 13, ref random), 100, ref random));

                        output += String.Format("1 lich {1}", NPCclass);
                    }
                    return output;
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
                    output = String.Format("{0} nightwings", Dice.Roll(3, 1, Modifier, ref random));
                    if (Dice.Percentile(ref random) <= 20)
                        return String.Format("{0} with {1}", output, Treasure.Generate(17, ref random));
                    return output;
                default:
                    output = "";
                    for (int i = Dice.Roll(3, 1, Modifier, ref random); i > 0; i--)
                        output += String.Format(" {0},", Character.Generate(14, false, ref random));
                    return output;
            }
        }

        private static string Level18(string Modifier, ref Random random)
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
                case 15:
                case 16:
                case 17:
                case 18:
                case 19:
                case 20:
                    string output = String.Format("{0} {1}", Dice.Roll(1, 0, Modifier, ref random), Dragon(18, ref random));
                    if (Dice.Percentile(ref random) <= 80)
                        return String.Format("{0} with {1}", output, Treasure.Generate(19, ref random));
                    return output;
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
                    output = String.Format("{0} balors", Dice.Roll(3, 0, Modifier, ref random));
                    if (Dice.Percentile(ref random) <= 50)
                        return String.Format("{0} with {1}", output, Treasure.Generate(18, ref random));
                    return output;
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
                    output = String.Format("{0} pit fiend and {1} gelugons", Dice.Roll(1, 0, Modifier, ref random), Dice.Roll(3, 1, Modifier, ref random));
                    if (Dice.Percentile(ref random) <= 50)
                        return String.Format("{0} with {1}", output, Treasure.Generate(18, ref random));
                    return output;
                case 41:
                case 42:
                case 43:
                case 44:
                case 45:
                    output = String.Format("{0} planetars", Dice.Roll(3, 0, Modifier, ref random));
                    if (Dice.Percentile(ref random) <= 50)
                        return String.Format("{0} with {1}", output, Treasure.Generate(18, ref random));
                    return output;
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
                    output = String.Format("{0} glabrezu", Dice.Roll(3, 1, Modifier, ref random));
                    if (Dice.Percentile(ref random) <= 50)
                        return String.Format("{0} with {1}", output, Treasure.Generate(18, ref random));
                    return output;
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
                    output = "";
                    for (int i = Dice.Roll(1, 0, Modifier, ref random); i > 0; i--)
                        output += String.Format("1 vampire {0}, ", Character.Generate(Dice.Roll(1, 3, 14, ref random), true, ref random));
                    return output;
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
                    output = String.Format("{0} nightwalkers", Dice.Roll(3, 1, Modifier, ref random));
                    if (Dice.Percentile(ref random) <= 20)
                        return String.Format("{0} with {1}", output, Treasure.Generate(18, ref random));
                    return output;
                default:
                    output = "";
                    for (int i = Dice.Roll(3, 1, Modifier, ref random); i > 0; i--)
                        output += String.Format(" {0},", Character.Generate(15, false, ref random));
                    return output;
            }
        }

        private static string Level19(string Modifier, ref Random random)
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
                case 15:
                case 16:
                case 17:
                case 18:
                case 19:
                case 20:
                    string output = String.Format("{0} {1}", Dice.Roll(1, 0, Modifier, ref random), Dragon(19, ref random));
                    if (Dice.Percentile(ref random) <= 80)
                        return String.Format("{0} with {1}", output, Treasure.Generate(20, ref random));
                    return output;
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
                    output = String.Format("{0} marilith and {1} glabrezu", Dice.Roll(1, 0, Modifier, ref random), Dice.Roll(3, 0, Modifier, ref random));
                    if (Dice.Percentile(ref random) <= 50)
                        return String.Format("{0} with {1}", output, Treasure.Generate(19, ref random));
                    return output;
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
                    output = String.Format("{0} pit fiends", Dice.Roll(3, 1, Modifier, ref random));
                    if (Dice.Percentile(ref random) <= 50)
                        return String.Format("{0} with {1}", output, Treasure.Generate(19, ref random));
                    return output;
                case 41:
                case 42:
                case 43:
                case 44:
                case 45:
                    output = String.Format("{0} solar", Dice.Roll(1, 0, Modifier, ref random));
                    if (Dice.Percentile(ref random) <= 50)
                        return String.Format("{0} with {1}", output, Treasure.Generate(19, ref random));
                    return output;
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
                    output = String.Format("{0} nalfeshnees", Dice.Roll(3, 1, Modifier, ref random));
                    if (Dice.Percentile(ref random) <= 50)
                        return String.Format("{0} with {1}", output, Treasure.Generate(19, ref random));
                    return output;
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
                    output = "";
                    for (int i = Dice.Roll(1, 0, Modifier, ref random); i > 0; i--)
                        output += String.Format("1 ghost {0}, ", Character.Generate(Dice.Roll(1, 3, 15, ref random), false, ref random));
                    if (Dice.Percentile(ref random) <= 20)
                        return String.Format("{0} with {1}", output, Treasure.Generate(19, ref random));
                    return output;
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
                    output = String.Format("{0} nightcrawlers", Dice.Roll(3, 0, Modifier, ref random));
                    if (Dice.Percentile(ref random) <= 20)
                        return String.Format("{0} with {1}", output, Treasure.Generate(19, ref random));
                    return output;
                default:
                    output = "";
                    for (int i = Dice.Roll(3, 1, Modifier, ref random); i > 0; i--)
                        output += String.Format(" {0},", Character.Generate(16, false, ref random));
                    return output;
            }
        }

        private static string Level20(string Modifier, ref Random random)
        {
            switch (Dice.Percentile(ref random))
            {
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
                    string output = String.Format("{0} balors", Dice.Roll(3, 0, Modifier, ref random));
                    if (Dice.Percentile(ref random) <= 50)
                        return String.Format("{0} with {1}", output, Treasure.Generate(20, ref random));
                    return output;
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
                    output = String.Format("{0} mariliths", Dice.Roll(3, 1, Modifier, ref random));
                    if (Dice.Percentile(ref random) <= 50)
                        return String.Format("{0} with {1}", output, Treasure.Generate(20, ref random));
                    return output;
                case 41:
                case 42:
                case 43:
                case 44:
                case 45:
                    output = String.Format("{0} solar and {1} planetars", Dice.Roll(1, 0, Modifier, ref random), Dice.Roll(2, 0, Modifier, ref random));
                    if (Dice.Percentile(ref random) <= 50)
                        return String.Format("{0} with {1}", output, Treasure.Generate(20, ref random));
                    return output;
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
                    output = "";
                    for (int i = Dice.Roll(3, 1, Modifier, ref random); i > 0; i--)
                        output += String.Format(" {0},", Character.Generate(17, false, ref random));
                    return output;
                case 56:
                case 57:
                case 58:
                case 59:
                case 60:
                    output = "";
                    for (int i = Dice.Roll(3, 0, Modifier, ref random); i > 0; i--)
                        output += String.Format(" {0},", Character.Generate(18, false, ref random));
                    return output;
                case 61:
                case 62:
                case 63:
                case 64:
                case 65:
                    output = "";
                    for (int i = Dice.Roll(2, 0, Modifier, ref random); i > 0; i--)
                        output += String.Format(" {0},", Character.Generate(19, false, ref random));
                    return output;
                case 66:
                case 67:
                case 68:
                case 69:
                case 70:
                    output = "";
                    for (int i = Dice.Roll(1, 0, Modifier, ref random); i > 0; i--)
                        output += String.Format(" {0},", Character.Generate(20, false, ref random));
                    return output;
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
                    output = String.Format("{0} nalfeshnees and {1} hezrous", Dice.Roll(3, 1, Modifier, ref random), Dice.Roll(3, 1, Modifier, ref random));
                    if (Dice.Percentile(ref random) <= 20)
                        return String.Format("{0} with {1}", output, Treasure.Generate(20, ref random));
                    return output;
                case 81:
                case 82:
                case 83:
                case 84:
                case 85:
                    output = "";
                    for (int i = Dice.Roll(1, 0, Modifier, ref random); i > 0; i--)
                        output += String.Format("1 ghost {0}, ", Character.Generate(Dice.Roll(1, 2, 18, ref random), false, ref random));
                    if (Dice.Percentile(ref random) <= 20)
                        return String.Format("{0} with {1}", output, Treasure.Generate(20, ref random));
                    return output;
                case 86:
                case 87:
                case 88:
                case 89:
                case 90:
                    int Roll; string NPCclass; output = "";
                    for (int i = Dice.Roll(1, 0, Modifier, ref random); i > 0; i--)
                    {
                        Roll = Dice.Percentile(ref random);
                        if (Roll <= 10)
                            NPCclass = String.Format("cleric {0}", Character.EvilRace((int)Character.CLASS.CLERIC, Dice.Roll(1, 3, 17, ref random), 100, ref random));
                        else if (Roll <= 30)
                            NPCclass = String.Format("sorcerer {0}", Character.EvilRace((int)Character.CLASS.SORCERER, Dice.Roll(1, 3, 17, ref random), 100, ref random));
                        else
                            NPCclass = String.Format("wizard {0}", Character.EvilRace((int)Character.CLASS.WIZARD, Dice.Roll(1, 3, 17, ref random), 100, ref random));

                        output += String.Format("1 lich {1}", NPCclass);
                    }
                    return output;
                case 91:
                case 92:
                case 93:
                case 94:
                case 95:
                    output = String.Format("{0} nightcrawlers", Dice.Roll(3, 0, Modifier, ref random));
                    if (Dice.Percentile(ref random) <= 20)
                        return String.Format("{0} with {1}", output, Treasure.Generate(20, ref random));
                    return output;
                case 96:
                case 97:
                case 98:
                case 99:
                case 100:
                    output = "";
                    for (int i = Dice.Roll(1, 0, Modifier, ref random); i > 0; i--)
                        output += String.Format("1 vampire {0}, ", Character.Generate(Dice.Roll(1, 3, 17, ref random), true, ref random));
                    return output;
                default:
                    output = String.Format("{0} {1}", Dice.Roll(1, 0, Modifier, ref random), Dragon(20, ref random));
                    if (Dice.Percentile(ref random) <= 80)
                        return String.Format("{0} with {1}", output, Treasure.Generate(21, ref random));
                    return output;
            }
        }

        private static string Dragon(int Level, ref Random random)
        {
            switch (Dice.Percentile(ref random))
            {
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
                    switch (Level)
                    {
                        case 1:
                        case 2: return "a wyrmling black dragon";
                        case 3: return "a very young black dragon";
                        case 4: return "a young black dragon";
                        case 5:
                        case 6: return "a juvenile black dragon";
                        case 7:
                        case 8: return "a young adult black dragon";
                        case 9:
                        case 10: return "an adult black dragon";
                        case 11:
                        case 12:
                        case 13: return "a mature adult black dragon";
                        case 14:
                        case 15: return "an old black dragon";
                        case 16: return "a very old black dragon";
                        case 17:
                        case 18: return "an ancient black dragon";
                        case 19: return "a wyrm black dragon";
                        default: return "a great wyrm black dragon";
                    }
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
                    switch (Level)
                    {
                        case 1:
                        case 2: return "a wyrmling green dragon";
                        case 3: return "a very young green dragon";
                        case 4:
                        case 5: return "a young green dragon";
                        case 6:
                        case 7: return "a juvenile green dragon";
                        case 8:
                        case 9:
                        case 10: return "a young adult green dragon";
                        case 11:
                        case 12: return "an adult green dragon";
                        case 13:
                        case 14:
                        case 15: return "a mature adult green dragon";
                        case 16:
                        case 17: return "an old green dragon";
                        case 18: return "a very old green dragon";
                        case 19:
                        case 20: return "an ancient green dragon";
                        case 21: return "a wyrm green dragon";
                        default: return "a great wyrm green dragon";
                    }
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
                    switch (Level)
                    {
                        case 1:
                        case 2: return "a wyrmling blue dragon";
                        case 3: return "a very young blue dragon";
                        case 4:
                        case 5: return "a young blue dragon";
                        case 6:
                        case 7: return "a juvenile blue dragon";
                        case 8:
                        case 9:
                        case 10: return "a young adult blue dragon";
                        case 11:
                        case 12:
                        case 13: return "an adult blue dragon";
                        case 14:
                        case 15: return "a mature adult blue dragon";
                        case 16:
                        case 17: return "an old blue dragon";
                        case 18: return "a very old blue dragon";
                        case 19:
                        case 20: return "an ancient blue dragon";
                        case 21: return "a wyrm blue dragon";
                        default: return "a great wyrm blue dragon";
                    }
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
                    switch (Level)
                    {
                        case 1:
                        case 2:
                        case 3: return "a wyrmling red dragon";
                        case 4: return "a very young red dragon";
                        case 5:
                        case 6: return "a young red dragon";
                        case 7:
                        case 8:
                        case 9: return "a juvenile red dragon";
                        case 10:
                        case 11:
                        case 12: return "a young adult red dragon";
                        case 13:
                        case 14: return "an adult red dragon";
                        case 15:
                        case 16:
                        case 17: return "a mature adult red dragon";
                        case 18:
                        case 19: return "an old red dragon";
                        case 20: return "a very old red dragon";
                        case 21:
                        case 22: return "an ancient red dragon";
                        case 23: return "a wyrm red dragon";
                        default: return "a great wyrm red dragon";
                    }
                case 81:
                case 82:
                case 83:
                case 84:
                    switch (Level)
                    {
                        case 1:
                        case 2: return "a wyrmling brass dragon";
                        case 3: return "a very young brass dragon";
                        case 4:
                        case 5: return "a young brass dragon";
                        case 6:
                        case 7: return "a juvenile brass dragon";
                        case 8:
                        case 9: return "a young adult brass dragon";
                        case 10:
                        case 11: return "an adult brass dragon";
                        case 12:
                        case 13:
                        case 14: return "a mature adult brass dragon";
                        case 15:
                        case 16: return "an old brass dragon";
                        case 17:
                        case 18: return "a very old brass dragon";
                        case 19: return "an ancient brass dragon";
                        case 20: return "a wyrm brass dragon";
                        default: return "a great wyrm brass dragon";
                    }
                case 85:
                case 86:
                case 87:
                case 88:
                    switch (Level)
                    {
                        case 1:
                        case 2: return "a wyrmling copper dragon";
                        case 3:
                        case 4: return "a very young copper dragon";
                        case 5:
                        case 6: return "a young copper dragon";
                        case 7:
                        case 8: return "a juvenile copper dragon";
                        case 9:
                        case 10: return "a young adult copper dragon";
                        case 11:
                        case 12:
                        case 13: return "an adult copper dragon";
                        case 14:
                        case 15: return "an mature adult copper dragon";
                        case 16:
                        case 17:
                        case 18: return "an old copper dragon";
                        case 19: return "a very old copper dragon";
                        case 20:
                        case 21: return "an ancient copper dragon";
                        case 22: return "a wyrm copper dragon";
                        default: return "a great wyrm copper dragon";
                    }
                case 89:
                case 90:
                case 91:
                    switch (Level)
                    {
                        case 1:
                        case 2: return "a wyrmling bronze dragon";
                        case 3:
                        case 4: return "a very young bronze dragon";
                        case 5:
                        case 6: return "a young bronze dragon";
                        case 7:
                        case 8: return "a juvenile bronze dragon";
                        case 9:
                        case 10:
                        case 11: return "a young adult bronze dragon";
                        case 12:
                        case 13:
                        case 14: return "an adult bronze dragon";
                        case 15:
                        case 16: return "a mature adult bronze dragon";
                        case 17:
                        case 18: return "an old bronze dragon";
                        case 19: return "a very old bronze dragon";
                        case 20:
                        case 21: return "an ancient bronze dragon";
                        case 22: return "a wyrm bronze dragon";
                        default: return "a great wyrm bronze dragon";
                    }
                case 92:
                case 93:
                case 94:
                case 95:
                case 96:
                    switch (Level)
                    {
                        case 1:
                        case 2:
                        case 3: return "a wyrmling silver dragon";
                        case 4: return "a very young silver dragon";
                        case 5:
                        case 6: return "a young silver dragon";
                        case 7:
                        case 8:
                        case 9: return "a juvenile silver dragon";
                        case 10:
                        case 11:
                        case 12: return "a young adult silver dragon";
                        case 13:
                        case 14: return "an adult silver dragon";
                        case 15:
                        case 16:
                        case 17: return "a mature adult silver dragon";
                        case 18:
                        case 19: return "an old silver dragon";
                        case 20: return "a very old silver dragon";
                        case 21:
                        case 22: return "an ancient silver dragon";
                        case 23: return "a wyrm silver dragon";
                        default: return "a great wyrm silver dragon";
                    }
                case 97:
                case 98:
                case 99:
                case 100:
                    switch (Level)
                    {
                        case 1:
                        case 2:
                        case 3:
                        case 4: return "a wyrmling gold dragon";
                        case 5:
                        case 6: return "a very young gold dragon";
                        case 7:
                        case 8: return "a young gold dragon";
                        case 9:
                        case 10: return "a juvenile gold dragon";
                        case 11:
                        case 12:
                        case 13: return "a young adult gold dragon";
                        case 14:
                        case 15: return "an adult gold dragon";
                        case 16:
                        case 17:
                        case 18: return "a mature adult gold dragon";
                        case 19:
                        case 20: return "an old gold dragon";
                        case 21:
                        case 22: return "a very old gold dragon";
                        case 23:
                        case 24: return "an ancient gold dragon";
                        case 25: return "a wyrm gold dragon";
                        default: return "a great wyrm gold dragon";
                    }
                default:
                    switch (Level)
                    {
                        case 1: return "a wyrmling white dragon";
                        case 2: return "a very young white dragon";
                        case 3: return "a young white dragon";
                        case 4:
                        case 5: return "a juvenile white dragon";
                        case 6:
                        case 7: return "a young adult white dragon";
                        case 8:
                        case 9: return "an adult white dragon";
                        case 10:
                        case 11: return "a mature adult white dragon";
                        case 12:
                        case 13:
                        case 14: return "an old white dragon";
                        case 15:
                        case 16: return "a very old white dragon";
                        case 17: return "an ancient white dragon";
                        case 18: return "a wyrm white dragon";
                        default: return "a great wyrm white dragon";
                    }
            }
        }
    }
}