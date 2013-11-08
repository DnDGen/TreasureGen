using System;
using System.Collections.Generic;
using System.Text;

namespace Dungeon_Maker
{
    class Character
    {
        public enum CLASS { BARBARIAN, BARD, CLERIC, DRUID, FIGHTER, MONK, PALADIN, RANGER, ROGUE, SORCERER, WIZARD };

        private enum ALIGN { EVIL, NEUTRAL, GOOD };
        
        public static string Generate(int Level, bool SetToEvil, ref Random random)
        {
            if (SetToEvil)
                return String.Format("An evil {0}", Class((int)ALIGN.EVIL, Level, ref random));
            
            int roll = Dice.Percentile(ref random);

            if (roll <= 20)
                return String.Format("A good {0}", Class((int)ALIGN.GOOD, Level, ref random));
            if (roll <= 50)
                return String.Format("A neutral {0}", Class((int)ALIGN.NEUTRAL, Level, ref random));
            return String.Format("An evil {0}", Class((int)ALIGN.EVIL, Level, ref random));

        }

        private static string Class(int alignment, int Level, ref Random random)
        {
            switch (alignment)
            {
                case (int)ALIGN.GOOD:
                    switch (Dice.Percentile(ref random))
                    {
                        case 1:
                        case 2:
                        case 3:
                        case 4:
                        case 5: return String.Format("barbarian, {0}", GoodRace((int)CLASS.BARBARIAN, Level, 100, ref random));
                        case 6:
                        case 7:
                        case 8:
                        case 9:
                        case 10: return String.Format("bard, {0}", GoodRace((int)CLASS.BARD, Level, 100, ref random));
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
                        case 30: return String.Format("cleric, {0}", GoodRace((int)CLASS.CLERIC, Level, 100, ref random));
                        case 31:
                        case 32:
                        case 33:
                        case 34:
                        case 35: return String.Format("druid, {0}", GoodRace((int)CLASS.DRUID, Level, 100, ref random));
                        case 36:
                        case 37:
                        case 38:
                        case 39:
                        case 40:
                        case 41:
                        case 42:
                        case 43:
                        case 44:
                        case 45: return String.Format("fighter, {0}", GoodRace((int)CLASS.FIGHTER, Level, 100, ref random));
                        case 46:
                        case 47:
                        case 48:
                        case 49:
                        case 50: return String.Format("monk, {0}", GoodRace((int)CLASS.MONK, Level, 100, ref random));
                        case 51:
                        case 52:
                        case 53:
                        case 54:
                        case 55: return String.Format("paladin, {0}", GoodRace((int)CLASS.PALADIN, Level, 100, ref random));
                        case 56:
                        case 57:
                        case 58:
                        case 59:
                        case 60:
                        case 61:
                        case 62:
                        case 63:
                        case 64:
                        case 65: return String.Format("ranger, {0}", GoodRace((int)CLASS.RANGER, Level, 100, ref random));
                        case 66:
                        case 67:
                        case 68:
                        case 69:
                        case 70:
                        case 71:
                        case 72:
                        case 73:
                        case 74:
                        case 75: return String.Format("rogue, {0}", GoodRace((int)CLASS.ROGUE, Level, 100, ref random));
                        case 76:
                        case 77:
                        case 78:
                        case 79:
                        case 80: return String.Format("sorcerer, {0}", GoodRace((int)CLASS.SORCERER, Level, 100, ref random));
                        default: return String.Format("wizard, {0}", GoodRace((int)CLASS.WIZARD, Level, 100, ref random));
                    }
                case (int)ALIGN.NEUTRAL:
                    switch (Dice.Percentile(ref random))
                    {
                        case 1:
                        case 2:
                        case 3:
                        case 4:
                        case 5: return String.Format("barbarian, {0}", NeutralRace((int)CLASS.BARBARIAN, Level, 100, ref random));
                        case 6:
                        case 7:
                        case 8:
                        case 9:
                        case 10: return String.Format("bard, {0}", NeutralRace((int)CLASS.BARD, Level, 100, ref random));
                        case 11:
                        case 12:
                        case 13:
                        case 14:
                        case 15: return String.Format("cleric, {0}", NeutralRace((int)CLASS.CLERIC, Level, 100, ref random));
                        case 16:
                        case 17:
                        case 18:
                        case 19:
                        case 20:
                        case 21:
                        case 22:
                        case 23:
                        case 24:
                        case 25: return String.Format("druid, {0}", NeutralRace((int)CLASS.DRUID, Level, 100, ref random));
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
                        case 45: return String.Format("fighter, {0}", NeutralRace((int)CLASS.FIGHTER, Level, 100, ref random));
                        case 46:
                        case 47:
                        case 48:
                        case 49:
                        case 50: return String.Format("monk, {0}", NeutralRace((int)CLASS.MONK, Level, 100, ref random));
                        case 51:
                        case 52:
                        case 53:
                        case 54:
                        case 55: return String.Format("ranger, {0}", NeutralRace((int)CLASS.RANGER, Level, 100, ref random));
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
                        case 75: return String.Format("rogue, {0}", NeutralRace((int)CLASS.ROGUE, Level, 100, ref random));
                        case 76:
                        case 77:
                        case 78:
                        case 79:
                        case 80: return String.Format("sorcerer, {0}", NeutralRace((int)CLASS.SORCERER, Level, 100, ref random));
                        default: return String.Format("wizard, {0}", NeutralRace((int)CLASS.WIZARD, Level, 100, ref random));
                    }
                default:
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
                        case 10: return String.Format("barbarian, {0}", EvilRace((int)CLASS.BARBARIAN, Level, 100, ref random));
                        case 11:
                        case 12:
                        case 13:
                        case 14:
                        case 15: return String.Format("bard, {0}", EvilRace((int)CLASS.BARD, Level, 100, ref random));
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
                        case 35: return String.Format("cleric, {0}", EvilRace((int)CLASS.CLERIC, Level, 100, ref random));
                        case 36:
                        case 37:
                        case 38:
                        case 39:
                        case 40: return String.Format("druid, {0}", EvilRace((int)CLASS.DRUID, Level, 100, ref random));
                        case 41:
                        case 42:
                        case 43:
                        case 44:
                        case 45:
                        case 46:
                        case 47:
                        case 48:
                        case 49:
                        case 50: return String.Format("fighter, {0}", EvilRace((int)CLASS.FIGHTER, Level, 100, ref random));
                        case 51:
                        case 52:
                        case 53:
                        case 54:
                        case 55: return String.Format("monk, {0}", EvilRace((int)CLASS.MONK, Level, 100, ref random));
                        case 56:
                        case 57:
                        case 58:
                        case 59:
                        case 60: return String.Format("ranger, {0}", EvilRace((int)CLASS.RANGER, Level, 100, ref random));
                        case 81:
                        case 82:
                        case 83:
                        case 84:
                        case 85: return String.Format("sorcerer, {0}", EvilRace((int)CLASS.SORCERER, Level, 100, ref random));
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
                        case 100: return String.Format("wizard, {0}", EvilRace((int)CLASS.WIZARD, Level, 100, ref random));
                        default: return String.Format("rogue, {0}", EvilRace((int)CLASS.ROGUE, Level, 100, ref random));
                    }
            }
        }

        private static string GoodRace(int NPCclass, int Level, int Limit, ref Random random)
        {
            switch (NPCclass)
            {
                case (int)CLASS.BARBARIAN:
                    switch (Dice.Roll(1, Limit, 0, ref random))
                    {
                        case 1:
                        case 2: return String.Format("hill dwarf (Level {0})", Level);
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
                        case 32: return String.Format("wild elf (Level {0})", Level);
                        case 33:
                        case 34: return String.Format("wood elf (Level {0})", Level);
                        case 35: return String.Format("half-elf (Level {0})", Level);
                        case 36: return String.Format("lightfoot halfling (Level {0})", Level);
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
                        case 61: return String.Format("half-orc (Level {0})", Level);
                        case 99:
                            if (Level - 1 > 0)
                                return String.Format("half-celestial {0}", GoodRace((int)CLASS.CLERIC, Level - 1, 98, ref random));
                            else
                                return GoodRace((int)CLASS.BARBARIAN, Level, 98, ref random);
                        case 100:
                            if (Level - 2 > 0)
                                return String.Format("half-dragon {0}", GoodRace((int)CLASS.CLERIC, Level - 2, 96, ref random));
                            else
                                return GoodRace((int)CLASS.BARBARIAN, Level, 99, ref random);
                        default: return String.Format("human (Level {0})", Level);
                    }
                case (int)CLASS.BARD:
                    switch (Dice.Roll(1, Limit, 0, ref random))
                    {
                        case 1: return String.Format("aasimar (Level {0})", Level);
                        case 2:
                        case 3:
                        case 4:
                        case 5:
                        case 6: return String.Format("hill dwarf (Level {0})", Level);
                        case 7:
                        case 8:
                        case 9:
                        case 10:
                        case 11: return String.Format("gray elf (Level {0})", Level);
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
                        case 36: return String.Format("high elf (Level {0})", Level);
                        case 37: return String.Format("wild elf (Level {0})", Level);
                        case 38: return String.Format("wood elf (Level {0})", Level);
                        case 39: return String.Format("forest gnome (Level {0})", Level);
                        case 40:
                        case 41:
                        case 42:
                        case 43:
                        case 44: return String.Format("rock gnome (Level {0})", Level);
                        case 45:
                        case 46:
                        case 47:
                        case 48:
                        case 49:
                        case 50:
                        case 51:
                        case 52:
                        case 53: return String.Format("half-elf (Level {0})", Level);
                        case 54: return String.Format("lightfoot halfling (Level {0})", Level);
                        case 55: return String.Format("deep halfling (Level {0})", Level);
                        case 56: return String.Format("tallfellow halfling (Level {0})", Level);
                        case 57: return String.Format("half-orc (Level {0})", Level);
                        case 98: 
                            if (Level - 1 > 0)
                                return String.Format("svirfneblin (Level {0})", Level - 1);
                            else
                                return GoodRace((int)CLASS.BARD, Level, 97, ref random);
                        case 99:
                            if (Level - 1 > 0)
                                return String.Format("half-celestial {0}", GoodRace((int)CLASS.BARD, Level - 1, 98, ref random));
                            else
                                return GoodRace((int)CLASS.BARD, Level, 97, ref random);
                        case 100:
                            if (Level - 2 > 0)
                                return String.Format("half-dragon {0}", GoodRace((int)CLASS.BARD, Level - 2, 99, ref random));
                            else
                                return GoodRace((int)CLASS.BARD, Level, 99, ref random);
                        default: return String.Format("human (Level {0})", Level);
                    }
                case (int)CLASS.CLERIC:
                    switch (Dice.Roll(1, Limit, 0, ref random))
                    {
                        case 1: return String.Format("aasimar (Level {0})", Level);
                        case 2: return String.Format("deep dwarf (Level {0})", Level);
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
                        case 22: return String.Format("hill dwarf (Level {0})", Level);
                        case 23:
                        case 24: return String.Format("mountain dwarf (Level {0})", Level);
                        case 25: return String.Format("gray elf (Level {0})", Level);
                        case 26:
                        case 27:
                        case 28:
                        case 29:
                        case 30:
                        case 31:
                        case 32:
                        case 33:
                        case 34:
                        case 35: return String.Format("high elf (Level {0})", Level);
                        case 36:
                        case 37:
                        case 38:
                        case 39:
                        case 40: return String.Format("wild elf (Level {0})", Level);
                        case 41: return String.Format("wood elf (Level {0})", Level);
                        case 42: return String.Format("forest gnome (Level {0})", Level);
                        case 43:
                        case 44:
                        case 45:
                        case 46:
                        case 47:
                        case 48:
                        case 49:
                        case 50:
                        case 51: return String.Format("rock gnome (Level {0})", Level);
                        case 52:
                        case 53:
                        case 54:
                        case 55:
                        case 56: return String.Format("half-elf (Level {0})", Level);
                        case 57:
                        case 58:
                        case 59:
                        case 60:
                        case 61:
                        case 62:
                        case 63:
                        case 64:
                        case 65:
                        case 66: return String.Format("lightfoot halfling (Level {0})", Level);
                        case 67: return String.Format("deep halfling (Level {0})", Level);
                        case 68:
                        case 69: return String.Format("tallfellow halfling (Level {0})", Level);
                        case 70: return String.Format("half-orc (Level {0})", Level);
                        case 96:
                            if (Level - 1 > 0)
                                return String.Format("svirfneblin (Level {0})", Level - 1);
                            else
                                return GoodRace((int)CLASS.CLERIC, Level, 95, ref random);
                        case 97:
                        case 98:
                            if (Level - 1 > 0)
                                return String.Format("half-celestial {0}", GoodRace((int)CLASS.CLERIC, Level - 1, 96, ref random));
                            else
                                return GoodRace((int)CLASS.CLERIC, Level, 95, ref random);
                        case 99:
                            if (Level - 2 > 0)
                                return String.Format("half-dragon {0}", GoodRace((int)CLASS.CLERIC, Level - 2, 96, ref random));
                            else
                                return GoodRace((int)CLASS.CLERIC, Level, 98, ref random);
                        case 100:
                            if (Level - 2 > 0)
                                return String.Format("werebear {0}", GoodRace((int)CLASS.CLERIC, Level - 2, 96, ref random));
                            else
                                return GoodRace((int)CLASS.CLERIC, Level, 98, ref random);
                        default: return String.Format("human (Level {0})", Level);
                    }
                case (int)CLASS.DRUID:
                    switch (Dice.Roll(1, Limit, 0, ref random))
                    {
                        case 1: return String.Format("gray elf (Level {0})", Level);
                        case 2:
                        case 3:
                        case 4:
                        case 5:
                        case 6:
                        case 7:
                        case 8:
                        case 9:
                        case 10:
                        case 11: return String.Format("high elf (Level {0})", Level);
                        case 12:
                        case 13:
                        case 14:
                        case 15:
                        case 16:
                        case 17:
                        case 18:
                        case 19:
                        case 20:
                        case 21: return String.Format("wild elf (Level {0})", Level);
                        case 22:
                        case 23:
                        case 24:
                        case 25:
                        case 26:
                        case 27:
                        case 28:
                        case 29:
                        case 30:
                        case 31: return String.Format("wood elf (Level {0})", Level);
                        case 32:
                        case 33:
                        case 34:
                        case 35:
                        case 36: return String.Format("forest gnome (Level {0})", Level);
                        case 37: return String.Format("rock gnome (Level {0})", Level);
                        case 38:
                        case 39:
                        case 40:
                        case 41:
                        case 42:
                        case 43:
                        case 44:
                        case 45:
                        case 46: return String.Format("half-elf (Level {0})", Level);
                        case 47: return String.Format("lightfoot halfling (Level {0})", Level);
                        case 48: return String.Format("tallfellow halfling (Level {0})", Level);
                        case 49: return String.Format("half-orc (Level {0})", Level);
                        case 100:
                            if (Level - 1 > 0)
                                return String.Format("half-celestial {0}", GoodRace((int)CLASS.DRUID, Level - 1, 99, ref random));
                            else
                                return GoodRace((int)CLASS.DRUID, Level, 99, ref random);
                        default: return String.Format("human (Level {0})", Level);
                    }
                case (int)CLASS.FIGHTER:
                    switch (Dice.Roll(1, Limit, 0, ref random))
                    {
                        case 1:
                        case 2:
                        case 3: return String.Format("deep dwarf (Level {0})", Level);
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
                        case 33: return String.Format("hill dwarf (Level {0})", Level);
                        case 34:
                        case 35:
                        case 36:
                        case 37:
                        case 38:
                        case 39:
                        case 40:
                        case 41: return String.Format("mountain dwarf (Level {0})", Level);
                        case 42: return String.Format("gray elf (Level {0})", Level);
                        case 43:
                        case 44:
                        case 45:
                        case 46:
                        case 47: return String.Format("high elf (Level {0})", Level);
                        case 48: return String.Format("rock gnome (Level {0})", Level);
                        case 49:
                        case 50: return String.Format("half-elf (Level {0})", Level);
                        case 51: return String.Format("lightfoot halfling (Level {0})", Level);
                        case 52: return String.Format("deep halfling (Level {0})", Level);
                        case 53:
                        case 54:
                        case 55:
                        case 56:
                        case 57: return String.Format("half-orc (Level {0})", Level);
                        case 98:
                            if (Level - 1 > 0)
                                return String.Format("half-celestial {0}", GoodRace((int)CLASS.FIGHTER, Level - 1, 97, ref random));
                            else
                                return GoodRace((int)CLASS.FIGHTER, Level, 97, ref random);
                        case 99:
                            if (Level - 2 > 0)
                                return String.Format("half-dragon {0}", GoodRace((int)CLASS.FIGHTER, Level - 2, 97, ref random));
                            else
                                return GoodRace((int)CLASS.FIGHTER, Level, 98, ref random);
                        case 100:
                            if (Level - 2 > 0)
                                return String.Format("werebear {0}", GoodRace((int)CLASS.FIGHTER, Level - 2, 97, ref random));
                            else
                                return GoodRace((int)CLASS.FIGHTER, Level, 98, ref random);
                        default: return String.Format("human (Level {0})", Level);
                    }
                case (int)CLASS.MONK:
                    switch (Dice.Roll(1, Limit, 0, ref random))
                    {
                        case 1:
                        case 2: return String.Format("aasimar (Level {0})", Level);
                        case 3: return String.Format("hill dwarf (Level {0})", Level);
                        case 4:
                        case 5:
                        case 6:
                        case 7:
                        case 8:
                        case 9:
                        case 10:
                        case 11:
                        case 12:
                        case 13: return String.Format("high elf (Level {0})", Level);
                        case 14:
                        case 15:
                        case 16:
                        case 17:
                        case 18: return String.Format("half-elf (Level {0})", Level);
                        case 19: return String.Format("lightfoot halfling (Level {0})", Level);
                        case 20: return String.Format("deep halfling (Level {0})", Level);
                        case 21:
                        case 22:
                        case 23:
                        case 24:
                        case 25: return String.Format("half-orc (Level {0})", Level);
                        case 98:
                            if (Level - 1 > 0)
                                return String.Format("half-celestial {0}", GoodRace((int)CLASS.MONK, Level - 1, 97, ref random));
                            else
                                return GoodRace((int)CLASS.MONK, Level, 97, ref random);
                        case 99:
                            if (Level - 2 > 0)
                                return String.Format("half-dragon {0}", GoodRace((int)CLASS.MONK, Level - 2, 97, ref random));
                            else
                                return GoodRace((int)CLASS.MONK, Level, 98, ref random);
                        case 100:
                            if (Level - 2 > 0)
                                return String.Format("werebear {0}", GoodRace((int)CLASS.MONK, Level - 2, 97, ref random));
                            else
                                return GoodRace((int)CLASS.MONK, Level, 98, ref random);
                        default: return String.Format("human (Level {0})", Level);
                    }
                case (int)CLASS.PALADIN:
                    switch (Dice.Roll(1, Limit, 0, ref random))
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
                        case 10: return String.Format("aasimar (Level {0})", Level);
                        case 11:
                        case 12:
                        case 13:
                        case 14:
                        case 15:
                        case 16:
                        case 17:
                        case 18:
                        case 19:
                        case 20: return String.Format("hill dwarf (Level {0})", Level);
                        case 21: return String.Format("mountain dwarf (Level {0})", Level);
                        case 22: return String.Format("rock gnome (Level {0})", Level);
                        case 23:
                        case 24:
                        case 25:
                        case 26:
                        case 27: return String.Format("half-elf (Level {0})", Level);
                        case 28: return String.Format("lightfoot halfling (Level {0})", Level);
                        case 29: return String.Format("deep halfling (Level {0})", Level);
                        case 30: return String.Format("half-orc (Level {0})", Level);
                        case 98:
                            if (Level - 1 > 0)
                                return String.Format("half-celestial {0}", GoodRace((int)CLASS.PALADIN, Level - 1, 97, ref random));
                            else
                                return GoodRace((int)CLASS.PALADIN, Level, 97, ref random);
                        case 99:
                            if (Level - 2 > 0)
                                return String.Format("half-dragon {0}", GoodRace((int)CLASS.PALADIN, Level - 2, 97, ref random));
                            else
                                return GoodRace((int)CLASS.PALADIN, Level, 98, ref random);
                        case 100:
                            if (Level - 2 > 0)
                                return String.Format("werebear {0}", GoodRace((int)CLASS.PALADIN, Level - 2, 97, ref random));
                            else
                                return GoodRace((int)CLASS.PALADIN, Level, 98, ref random);
                        default: return String.Format("human (Level {0})", Level);
                    }
                case (int)CLASS.RANGER:
                    switch (Dice.Roll(1, Limit, 0, ref random))
                    {
                        case 1:
                        case 2:
                        case 3:
                        case 4:
                        case 5: return String.Format("hill dwarf (Level {0})", Level);
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
                        case 20: return String.Format("high elf (Level {0})", Level);
                        case 21: return String.Format("wild elf (Level {0})", Level);
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
                        case 36: return String.Format("wood elf (Level {0})", Level);
                        case 37:
                        case 38:
                        case 39:
                        case 40:
                        case 41: return String.Format("forest gnome (Level {0})", Level);
                        case 42: return String.Format("rock gnome (Level {0})", Level);
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
                        case 57: return String.Format("half-elf (Level {0})", Level);
                        case 58: return String.Format("lightfoot halfling (Level {0})", Level);
                        case 59: return String.Format("tallfellow halfling (Level {0})", Level);
                        case 60:
                        case 61:
                        case 62:
                        case 63:
                        case 64: return String.Format("half-orc (Level {0})", Level);
                        case 98:
                            if (Level - 1 > 0)
                                return String.Format("half-celestial {0}", GoodRace((int)CLASS.RANGER, Level - 1, 97, ref random));
                            else
                                return GoodRace((int)CLASS.RANGER, Level, 97, ref random);
                        case 99:
                            if (Level - 2 > 0)
                                return String.Format("half-dragon {0}", GoodRace((int)CLASS.RANGER, Level - 2, 97, ref random));
                            else
                                return GoodRace((int)CLASS.RANGER, Level, 98, ref random);
                        case 100:
                            if (Level - 2 > 0)
                                return String.Format("werebear {0}", GoodRace((int)CLASS.RANGER, Level - 2, 97, ref random));
                            else
                                return GoodRace((int)CLASS.RANGER, Level, 98, ref random);
                        default: return String.Format("human (Level {0})", Level);
                    }
                case (int)CLASS.ROGUE:
                    switch (Dice.Roll(1, Limit, 0, ref random))
                    {
                        case 1:
                        case 2:
                        case 3:
                        case 4:
                        case 5: return String.Format("hill dwarf (Level {0})", Level);
                        case 6: return String.Format("mountain dwarf (Level {0})", Level);
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
                        case 19: return String.Format("high elf (Level {0})", Level);
                        case 20: return String.Format("forest gnome (Level {0})", Level);
                        case 21:
                        case 22:
                        case 23:
                        case 24:
                        case 25: return String.Format("rock gnome (Level {0})", Level);
                        case 26:
                        case 27:
                        case 28:
                        case 29:
                        case 30:
                        case 31:
                        case 32:
                        case 33:
                        case 34:
                        case 35: return String.Format("half-elf (Level {0})", Level);
                        case 61:
                        case 62:
                        case 63:
                        case 64:
                        case 65:
                        case 66: return String.Format("deep halfling (Level {0})", Level);
                        case 67:
                        case 68:
                        case 69:
                        case 70:
                        case 71:
                        case 72: return String.Format("tallfellow halfling (Level {0})", Level);
                        case 73:
                        case 74:
                        case 75:
                        case 76:
                        case 77: return String.Format("half-orc (Level {0})", Level);
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
                        case 96: return String.Format("human (Level {0})", Level);
                        case 97:
                            if (Level - 1 > 0)
                                return String.Format("svirfneblin (Level {0})", Level - 1);
                            else
                                return GoodRace((int)CLASS.ROGUE, Level, 96, ref random);
                        case 98:
                            if (Level - 1 > 0)
                                return String.Format("half-celestial {0}", GoodRace((int)CLASS.ROGUE, Level - 1, 97, ref random));
                            else
                                return GoodRace((int)CLASS.ROGUE, Level, 96, ref random);
                        case 99:
                            if (Level - 2 > 0)
                                return String.Format("half-dragon {0}", GoodRace((int)CLASS.ROGUE, Level - 2, 97, ref random));
                            else
                                return GoodRace((int)CLASS.ROGUE, Level, 96, ref random);
                        case 100:
                            if (Level - 2 > 0)
                                return String.Format("werebear {0}", GoodRace((int)CLASS.ROGUE, Level - 2, 97, ref random));
                            else
                                return GoodRace((int)CLASS.ROGUE, Level, 98, ref random);
                        default: return String.Format("lightfoot halfling (Level {0})", Level);
                    }
                case (int)CLASS.SORCERER:
                    switch (Dice.Roll(1, Limit, 0, ref random))
                    {
                        case 1:
                        case 2: return String.Format("aasimar (Level {0})", Level);
                        case 3: return String.Format("deep dwarf (Level {0})", Level);
                        case 4:
                        case 5: return String.Format("hill dwarf (Level {0})", Level);
                        case 6: return String.Format("mountain dwarf (Level {0})", Level);
                        case 7:
                        case 8: return String.Format("gray elf (Level {0})", Level);
                        case 9:
                        case 10:
                        case 11: return String.Format("high elf (Level {0})", Level);
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
                        case 36: return String.Format("wild elf (Level {0})", Level);
                        case 37: return String.Format("wood elf (Level {0})", Level);
                        case 38: return String.Format("forest gnome (Level {0})", Level);
                        case 39:
                        case 40: return String.Format("rock gnome (Level {0})", Level);
                        case 41:
                        case 42:
                        case 43:
                        case 44:
                        case 45: return String.Format("half-elf (Level {0})", Level);
                        case 46:
                        case 47:
                        case 48:
                        case 49:
                        case 50:
                        case 51:
                        case 52:
                        case 53:
                        case 54: return String.Format("lightfoot halfling (Level {0})", Level);
                        case 55: return String.Format("deep halfling (Level {0})", Level);
                        case 56: return String.Format("tallfellow halfling (Level {0})", Level);
                        case 57:
                        case 58: return String.Format("half-orc (Level {0})", Level);
                        case 96:
                            if (Level - 1 > 0)
                                return String.Format("svirfneblin (Level {0})", Level - 1);
                            else
                                return GoodRace((int)CLASS.SORCERER, Level, 95, ref random);
                        case 97:
                            if (Level - 1 > 0)
                                return String.Format("half-celestial {0}", GoodRace((int)CLASS.SORCERER, Level - 1, 96, ref random));
                            else
                                return GoodRace((int)CLASS.SORCERER, Level, 95, ref random);
                        case 98:
                        case 99:
                            if (Level - 2 > 0)
                                return String.Format("half-dragon {0}", GoodRace((int)CLASS.SORCERER, Level - 2, 96, ref random));
                            else
                                return GoodRace((int)CLASS.SORCERER, Level, 97, ref random);
                        case 100:
                            if (Level - 2 > 0)
                                return String.Format("werebear {0}", GoodRace((int)CLASS.SORCERER, Level - 2, 96, ref random));
                            else
                                return GoodRace((int)CLASS.SORCERER, Level, 97, ref random);
                        default: return String.Format("human (Level {0})", Level);
                    }
                default:
                    switch (Dice.Roll(1, Limit, 0, ref random))
                    {
                        case 1: return String.Format("aasimar (Level {0})", Level);
                        case 2: return String.Format("hill dwarf (Level {0})", Level);
                        case 3:
                        case 4:
                        case 5:
                        case 6:
                        case 7: return String.Format("gray elf (Level {0})", Level);
                        case 42: return String.Format("wood elf (Level {0})", Level);
                        case 43: return String.Format("forest gnome (Level {0})", Level);
                        case 44:
                        case 45:
                        case 46:
                        case 47:
                        case 48: return String.Format("rock gnome (Level {0})", Level);
                        case 49:
                        case 50:
                        case 51:
                        case 52:
                        case 53:
                        case 54:
                        case 55:
                        case 56:
                        case 57:
                        case 58: return String.Format("half-elf (Level {0})", Level);
                        case 59:
                        case 60:
                        case 61:
                        case 62:
                        case 63: return String.Format("lightfoot halfling (Level {0})", Level);
                        case 64: return String.Format("adeep halfling (Level {0})", Level);
                        case 65:
                        case 66:
                        case 67: return String.Format("tallfellow halfling (Level {0})", Level);
                        case 68: return String.Format("half-orc (Level {0})", Level);
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
                        case 96: return String.Format("human (Level {0})", Level);
                        case 97:
                            if (Level - 1 > 0)
                                return String.Format("svirfneblin (Level {0})", Level - 1);
                            else
                                return GoodRace((int)CLASS.WIZARD, Level, 96, ref random);
                        case 98:
                            if (Level - 1 > 0)
                                return String.Format("half-celestial {0}", GoodRace((int)CLASS.WIZARD, Level - 1, 97, ref random));
                            else
                                return GoodRace((int)CLASS.WIZARD, Level, 96, ref random);
                        case 99:
                            if (Level - 2 > 0)
                                return String.Format("half-dragon {0}", GoodRace((int)CLASS.WIZARD, Level - 2, 97, ref random));
                            else
                                return GoodRace((int)CLASS.WIZARD, Level, 98, ref random);
                        case 100:
                            if (Level - 2 > 0)
                                return String.Format("werebear {0}", GoodRace((int)CLASS.WIZARD, Level - 2, 97, ref random));
                            else
                                return GoodRace((int)CLASS.WIZARD, Level, 98, ref random);
                        default: return String.Format("high elf (Level {0})", Level);
                    }
            }
        }

        private static string NeutralRace(int NPCclass, int Level, int Limit, ref Random random)
        {
            switch (NPCclass)
            {
                case (int)CLASS.BARBARIAN:
                    switch (Dice.Roll(1, Limit, 0, ref random))
                    {
                        case 1: return String.Format("deep dwarf (Level {0})", Level);
                        case 2: return String.Format("hill dwarf (Level {0})", Level);
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
                        case 13: return String.Format("wild elf (Level {0})", Level);
                        case 14: return String.Format("wood elf (Level {0})", Level);
                        case 15:
                        case 16: return String.Format("half-elf (Level {0})", Level);
                        case 17:
                        case 18: return String.Format("lightfoot halfling (Level {0})", Level);
                        case 19: return String.Format("deep halfling (Level {0})", Level);
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
                        case 87: return String.Format("human (Level {0})", Level);
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
                        case 98: return String.Format("lizardfolk (Level {0})", Level);
                        case 99:
                            if (Level - 1 > 0)
                                return String.Format("wereboar {0}", NeutralRace((int)CLASS.BARBARIAN, Level - 1, 98, ref random));
                            else
                                return NeutralRace((int)CLASS.BARBARIAN, Level, 98, ref random);
                        case 100:
                            if (Level - 1 > 0)
                                return String.Format("weretiger {0}", NeutralRace((int)CLASS.BARBARIAN, Level - 1, 98, ref random));
                            else
                                return NeutralRace((int)CLASS.BARBARIAN, Level, 98, ref random);
                        default: return String.Format("half-orc (Level {0})", Level);
                    }
                case (int)CLASS.BARD:
                    switch (Dice.Roll(1, Limit, 0, ref random))
                    {
                        case 1: return String.Format("deep dwarf (Level {0})", Level);
                        case 2:
                        case 3: return String.Format("hill dwarf (Level {0})", Level);
                        case 4:
                        case 5: return String.Format("gray elf (Level {0})", Level);
                        case 6:
                        case 7:
                        case 8:
                        case 9:
                        case 10:
                        case 11:
                        case 12:
                        case 13:
                        case 14:
                        case 15: return String.Format("high elf (Level {0})", Level);
                        case 16: return String.Format("wild elf (Level {0})", Level);
                        case 17:
                        case 18:
                        case 19:
                        case 20:
                        case 21: return String.Format("wood elf (Level {0})", Level);
                        case 22:
                        case 23: return String.Format("rock gnome (Level {0})", Level);
                        case 24:
                        case 25:
                        case 26:
                        case 27:
                        case 28:
                        case 29:
                        case 30:
                        case 31:
                        case 32:
                        case 33: return String.Format("half-elf (Level {0})", Level);
                        case 34:
                        case 35:
                        case 36: return String.Format("lightfoot halfling (Level {0})", Level);
                        case 37: return String.Format("deep halfling (Level {0})", Level);
                        case 38: return String.Format("tallfellow halfling (Level {0})", Level);
                        case 39:
                        case 40: return String.Format("half-orc (Level {0})", Level);
                        case 99:
                            if (Level - 1 > 0)
                                return String.Format("wereboar {0}", NeutralRace((int)CLASS.BARD, Level - 1, 98, ref random));
                            else
                                return NeutralRace((int)CLASS.BARD, Level, 98, ref random);
                        case 100:
                            if (Level - 1 > 0)
                                return String.Format("weretiger {0}", NeutralRace((int)CLASS.BARD, Level - 1, 98, ref random));
                            else
                                return NeutralRace((int)CLASS.BARD, Level, 98, ref random);
                        default: return String.Format("human (Level {0})", Level);
                    }
                case (int)CLASS.CLERIC:
                    switch (Dice.Roll(1, Limit, 0, ref random))
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
                        case 15: return String.Format("deep dwarf (Level {0})", Level);
                        case 16:
                        case 17:
                        case 18:
                        case 19:
                        case 20:
                        case 21:
                        case 22:
                        case 23:
                        case 24:
                        case 25: return String.Format("hill dwarf (Level {0})", Level);
                        case 26: return String.Format("mountain dwarf (Level {0})", Level);
                        case 27: return String.Format("high elf (Level {0})", Level);
                        case 28: return String.Format("wild elf (Level {0})", Level);
                        case 29:
                        case 30:
                        case 31:
                        case 32:
                        case 33:
                        case 34:
                        case 35:
                        case 36:
                        case 37:
                        case 38: return String.Format("wood elf (Level {0})", Level);
                        case 39: return String.Format("rock gnome (Level {0})", Level);
                        case 40:
                        case 41:
                        case 42:
                        case 43:
                        case 44:
                        case 45:
                        case 46:
                        case 47:
                        case 48: return String.Format("half-elf (Level {0})", Level);
                        case 49:
                        case 50:
                        case 51:
                        case 52:
                        case 53:
                        case 54:
                        case 55:
                        case 56:
                        case 57:
                        case 58: return String.Format("lightfoot halfling (Level {0})", Level);
                        case 59: return String.Format("deep halfling (Level {0})", Level);
                        case 60: return String.Format("tallfellow halfling (Level {0})", Level);
                        case 61:
                        case 62: return String.Format("half-orc (Level {0})", Level);
                        case 91:
                        case 92:
                        case 93:
                        case 94:
                        case 95:
                        case 96:
                        case 97: return String.Format("lizardfolk (Level {0})", Level);
                        case 98:
                            if (Level - 3 > 0)
                                return String.Format("doppelganger (Level {0})", Level - 3);
                            else
                                return NeutralRace((int)CLASS.CLERIC, Level, Limit, ref random);
                        case 99:
                            if (Level - 1 > 0)
                                return String.Format("wereboar {0}", NeutralRace((int)CLASS.CLERIC, Level - 1, 98, ref random));
                            else
                                return NeutralRace((int)CLASS.CLERIC, Level, 97, ref random);
                        case 100:
                            if (Level - 1 > 0)
                                return String.Format("weretiger {0}", NeutralRace((int)CLASS.CLERIC, Level - 1, 98, ref random));
                            else
                                return NeutralRace((int)CLASS.CLERIC, Level, 97, ref random);
                        default: return String.Format("human (Level {0})", Level);
                    }
                case (int)CLASS.DRUID:
                    switch (Dice.Roll(1, Limit, 0, ref random))
                    {
                        case 1: return String.Format("gray elf (Level {0})", Level);
                        case 2:
                        case 3:
                        case 4:
                        case 5:
                        case 6: return String.Format("high elf (Level {0})", Level);
                        case 7:
                        case 8:
                        case 9:
                        case 10:
                        case 11: return String.Format("wild elf (Level {0})", Level);
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
                        case 31: return String.Format("wood elf (Level {0})", Level);
                        case 32: return String.Format("forest gnome (Level {0})", Level);
                        case 33:
                        case 34:
                        case 35:
                        case 36:
                        case 37: return String.Format("half-elf (Level {0})", Level);
                        case 38: return String.Format("lightfoot halfling (Level {0})", Level);
                        case 39: return String.Format("tallfellow halfling (Level {0})", Level);
                        case 40: return String.Format("half-orc (Level {0})", Level);
                        case 89:
                        case 90:
                        case 91:
                        case 92:
                        case 93:
                        case 94:
                        case 95:
                        case 96:
                        case 97:
                        case 98: return String.Format("lizardfolk (Level {0})", Level);
                        case 99:
                            if (Level - 1 > 0)
                                return String.Format("wereboar {0}", NeutralRace((int)CLASS.DRUID, Level - 1, 98, ref random));
                            else
                                return NeutralRace((int)CLASS.DRUID, Level, 98, ref random);
                        case 100:
                            if (Level - 1 > 0)
                                return String.Format("weretiger {0}", NeutralRace((int)CLASS.DRUID, Level - 1, 98, ref random));
                            else
                                return NeutralRace((int)CLASS.DRUID, Level, 98, ref random);
                        default: return String.Format("human (Level {0})", Level);
                    }
                case (int)CLASS.FIGHTER:
                    switch (Dice.Roll(1, Limit, 0, ref random))
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
                        case 10: return String.Format("deep dwarf (Level {0})", Level);
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
                        case 29: return String.Format("hill dwarf (Level {0})", Level);
                        case 30:
                        case 31:
                        case 32:
                        case 33:
                        case 34: return String.Format("mountain dwarf (Level {0})", Level);
                        case 35: return String.Format("high elf (Level {0})", Level);
                        case 36:
                        case 37:
                        case 38:
                        case 39:
                        case 40:
                        case 41: return String.Format("wood elf (Level {0})", Level);
                        case 42:
                        case 43:
                        case 44:
                        case 45:
                        case 46: return String.Format("half-elf (Level {0})", Level);
                        case 47: return String.Format("lightfoot halfling (Level {0})", Level);
                        case 48: return String.Format("deep halfling (Level {0})", Level);
                        case 49:
                        case 50:
                        case 51:
                        case 52:
                        case 53:
                        case 54:
                        case 55:
                        case 56:
                        case 57:
                        case 58: return String.Format("half-orc (Level {0})", Level);
                        case 97: return String.Format("lizardfolk (Level {0})", Level);
                        case 98:
                            if (Level - 3 > 0)
                                return String.Format("doppelganger (Level {0})", Level - 3);
                            else
                                return NeutralRace((int)CLASS.FIGHTER, Level, Limit, ref random);
                        case 99:
                            if (Level - 1 > 0)
                                return String.Format("wereboar {0}", NeutralRace((int)CLASS.FIGHTER, Level - 1, 98, ref random));
                            else
                                return NeutralRace((int)CLASS.FIGHTER, Level, 97, ref random);
                        case 100:
                            if (Level - 1 > 0)
                                return String.Format("weretiger {0}", NeutralRace((int)CLASS.FIGHTER, Level - 1, 98, ref random));
                            else
                                return NeutralRace((int)CLASS.FIGHTER, Level, 97, ref random);
                        default: return String.Format("human (Level {0})", Level);
                    }
                case (int)CLASS.MONK:
                    switch (Dice.Roll(1, Limit, 0, ref random))
                    {
                        case 1:
                        case 2: return String.Format("high elf (Level {0})", Level);
                        case 3: return String.Format("wood elf (Level {0})", Level);
                        case 4:
                        case 5:
                        case 6:
                        case 7:
                        case 8:
                        case 9:
                        case 10:
                        case 11:
                        case 12:
                        case 13: return String.Format("half-elf (Level {0})", Level);
                        case 14: return String.Format("lightfoot halfling (Level {0})", Level);
                        case 15: return String.Format("deep halfling (Level {0})", Level);
                        case 16:
                        case 17:
                        case 18:
                        case 19:
                        case 20:
                        case 21:
                        case 22:
                        case 23:
                        case 24:
                        case 25: return String.Format("half-orc (Level {0})", Level);
                        default: return String.Format("human (Level {0})", Level);
                    }
                case (int)CLASS.RANGER:
                    switch (Dice.Roll(1, Limit, 0, ref random))
                    {
                        case 1: return String.Format("hill dwarf (Level {0})", Level);
                        case 2:
                        case 3:
                        case 4:
                        case 5:
                        case 6: return String.Format("high elf (Level {0})", Level);
                        case 7: return String.Format("wild elf (Level {0})", Level);
                        case 37: return String.Format("forest gnome (Level {0})", Level);
                        case 38: return String.Format("rock gnome (Level {0})", Level);
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
                        case 55: return String.Format("half-elf (Level {0})", Level);
                        case 56: return String.Format("lightfoot halfling (Level {0})", Level);
                        case 57: return String.Format("tallfellow halfling (Level {0})", Level);
                        case 58:
                        case 59:
                        case 60:
                        case 61:
                        case 62:
                        case 63:
                        case 64:
                        case 65:
                        case 66:
                        case 67: return String.Format("half-orc (Level {0})", Level);
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
                        case 96: return String.Format("human (Level {0})", Level);
                        case 97:
                        case 98: return String.Format("lizardfolk (Level {0})", Level);
                        case 99:
                            if (Level - 1 > 0)
                                return String.Format("wereboar {0}", NeutralRace((int)CLASS.RANGER, Level - 1, 98, ref random));
                            else
                                return NeutralRace((int)CLASS.RANGER, Level, 98, ref random);
                        case 100:
                            if (Level - 1 > 0)
                                return String.Format("weretiger {0}", NeutralRace((int)CLASS.RANGER, Level - 1, 98, ref random));
                            else
                                return NeutralRace((int)CLASS.RANGER, Level, 98, ref random);
                        default: return String.Format("wood elf (Level {0})", Level);
                    }
                case (int)CLASS.ROGUE:
                    switch (Dice.Roll(1, Limit, 0, ref random))
                    {
                        case 1: return String.Format("deep dwarf (Level {0})", Level);
                        case 2:
                        case 3:
                        case 4: return String.Format("hill dwarf (Level {0})", Level);
                        case 5:
                        case 6:
                        case 7:
                        case 8: return String.Format("high elf (Level {0})", Level);
                        case 9: return String.Format("wood elf (Level {0})", Level);
                        case 10: return String.Format("rock gnome (Level {0})", Level);
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
                        case 25: return String.Format("half-elf (Level {0})", Level);
                        case 54:
                        case 55:
                        case 56:
                        case 57:
                        case 58: return String.Format("deep halfling (Level {0})", Level);
                        case 59:
                        case 60:
                        case 61:
                        case 62:
                        case 63: return String.Format("tallfellow halfling (Level {0})", Level);
                        case 64:
                        case 65:
                        case 66:
                        case 67:
                        case 68:
                        case 69:
                        case 70:
                        case 71:
                        case 72:
                        case 73: return String.Format("half-orc (Level {0})", Level);
                        case 74:
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
                        case 97: return String.Format("human (Level {0})", Level);
                        case 98:
                            if (Level - 3 > 0)
                                return String.Format("doppelganger (Level {0})", Level - 3);
                            else
                                return NeutralRace((int)CLASS.ROGUE, Level, Limit, ref random);
                        case 99:
                            if (Level - 1 > 0)
                                return String.Format("wereboar {0}", NeutralRace((int)CLASS.ROGUE, Level - 1, 98, ref random));
                            else
                                return NeutralRace((int)CLASS.ROGUE, Level, 97, ref random);
                        case 100:
                            if (Level - 1 > 0)
                                return String.Format("weretiger {0}", NeutralRace((int)CLASS.ROGUE, Level - 1, 98, ref random));
                            else
                                return NeutralRace((int)CLASS.ROGUE, Level, 97, ref random);
                        default: return String.Format("lightfoot halfling (Level {0})", Level);
                    }
                case (int)CLASS.SORCERER:
                    switch (Dice.Roll(1, Limit, 0, ref random))
                    {
                        case 1: return String.Format("hill dwarf (Level {0})", Level);
                        case 2: return String.Format("high elf (Level {0})", Level);
                        case 3:
                        case 4:
                        case 5:
                        case 6:
                        case 7:
                        case 8:
                        case 9:
                        case 10:
                        case 11:
                        case 12: return String.Format("wild elf (Level {0})", Level);
                        case 13:
                        case 14:
                        case 15: return String.Format("wood elf (Level {0})", Level);
                        case 16: return String.Format("rock gnome (Level {0})", Level);
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
                        case 31: return String.Format("half-elf (Level {0})", Level);
                        case 32:
                        case 33:
                        case 34:
                        case 35:
                        case 36:
                        case 37:
                        case 38:
                        case 39:
                        case 40:
                        case 41: return String.Format("lightfoot halfling (Level {0})", Level);
                        case 42: return String.Format("deep halfling (Level {0})", Level);
                        case 43: return String.Format("tallfellow halfling (Level {0})", Level);
                        case 44:
                        case 45:
                        case 46:
                        case 47:
                        case 48: return String.Format("half-orc (Level {0})", Level);
                        case 96:
                        case 97: return String.Format("lizardfolk (Level {0})", Level);
                        case 98:
                            if (Level - 3 > 0)
                                return String.Format("doppelganger (Level {0})", Level - 3);
                            else
                                return NeutralRace((int)CLASS.SORCERER, Level, Limit, ref random);
                        case 99:
                            if (Level - 1 > 0)
                                return String.Format("wereboar {0}", NeutralRace((int)CLASS.SORCERER, Level - 1, 98, ref random));
                            else
                                return NeutralRace((int)CLASS.SORCERER, Level, 97, ref random);
                        case 100:
                            if (Level - 1 > 0)
                                return String.Format("weretiger {0}", NeutralRace((int)CLASS.SORCERER, Level - 1, 98, ref random));
                            else
                                return NeutralRace((int)CLASS.SORCERER, Level, 97, ref random);
                        default: return String.Format("human (Level {0})", Level);
                    }
                default:
                    switch (Dice.Roll(1, Limit, 0, ref random))
                    {
                        case 1: return String.Format("gray elf (Level {0})", Level);
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
                        case 26: return String.Format("high elf (Level {0})", Level);
                        case 27:
                        case 28: return String.Format("wood elf (Level {0})", Level);
                        case 29: return String.Format("rock gnome (Level {0})", Level);
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
                        case 44: return String.Format("half-elf (Level {0})", Level);
                        case 45:
                        case 46:
                        case 47: return String.Format("lightfoot halfling (Level {0})", Level);
                        case 48:
                        case 49: return String.Format("tallfellow halfling (Level {0})", Level);
                        case 50: return String.Format("half-orc (Level {0})", Level);
                        case 98:
                            if (Level - 3 > 0)
                                return String.Format("doppelganger (Level {0})", Level - 3);
                            else
                                return NeutralRace((int)CLASS.WIZARD, Level, Limit, ref random);
                        case 99:
                            if (Level - 1 > 0)
                                return String.Format("wereboar {0}", NeutralRace((int)CLASS.WIZARD, Level - 1, 98, ref random));
                            else
                                return NeutralRace((int)CLASS.WIZARD, Level, 97, ref random);
                        case 100:
                            if (Level - 1 > 0)
                                return String.Format("weretiger {0}", NeutralRace((int)CLASS.WIZARD, Level - 1, 98, ref random));
                            else
                                return NeutralRace((int)CLASS.WIZARD, Level, 97, ref random);
                        default: return String.Format("human (Level {0})", Level);
                    }
            }
        }

        public static string EvilRace(int NPCclass, int Level, int Limit, ref Random random)
        {
            switch (NPCclass)
            {
                case (int)CLASS.BARBARIAN:
                    switch (Dice.Roll(1, Limit, 0, ref random))
                    {
                        case 1: return String.Format("wild elf (Level {0})", Level);
                        case 2:
                        case 3: return String.Format("wood elf (Level {0})", Level);
                        case 4: return String.Format("half-elf (Level {0})", Level);
                        case 5: return String.Format("lightfoot halfling (Level {0})", Level);
                        case 6: return String.Format("deep halfling (Level {0})", Level);
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
                        case 29: return String.Format("half-orc (Level {0})", Level);
                        case 30:
                        case 31:
                        case 32:
                        case 33:
                        case 34:
                        case 35:
                        case 36:
                        case 37:
                        case 38:
                        case 39: return String.Format("human (Level {0})", Level);
                        case 40:
                        case 41:
                        case 42:
                        case 43:
                        case 44: return String.Format("lizardfolk (Level {0})", Level);
                        case 45: return String.Format("goblin (Level {0})", Level);
                        case 46: return String.Format("hobgoblin (Level {0})", Level);
                        case 47: return String.Format("kobold (Level {0})", Level);
                        case 78: return String.Format("tiefling (Level {0})", Level);
                        case 79:
                        case 80:
                        case 81:
                        case 82:
                        case 83:
                            if (Level - 1 > 0)
                                return String.Format("gnoll (Level {0})", Level - 1);
                            else
                                return EvilRace((int)CLASS.BARBARIAN, Level, 78, ref random);
                        case 84:
                            if (Level - 1 > 0)
                                return String.Format("troglodyte (Level {0})", Level - 1);
                            else
                                return EvilRace((int)CLASS.BARBARIAN, Level, 78, ref random);
                        case 85:
                        case 86:
                            if (Level - 2 > 0)
                                return String.Format("bugbear (Level {0})", Level - 2);
                            else
                                return EvilRace((int)CLASS.BARBARIAN, Level, Limit, ref random);
                        case 87:
                        case 88:
                        case 89:
                        case 90:
                            if (Level - 2 > 0)
                                return String.Format("ogre (Level {0})", Level - 2);
                            else
                                return EvilRace((int)CLASS.BARBARIAN, Level, Limit, ref random);
                        case 91:
                        case 92:
                        case 93:
                        case 94:
                            if (Level - 4 > 0)
                                return String.Format("minotaur (Level {0})", Level - 4);
                            else
                                return EvilRace((int)CLASS.BARBARIAN, Level, Limit, ref random);
                        case 95:
                        case 96:
                            if (Level - 1 > 0)
                                return String.Format("werewolf {0}", EvilRace((int)CLASS.BARBARIAN, Level - 1, 94, ref random));
                            else
                                return EvilRace((int)CLASS.BARBARIAN, Level, 78, ref random);
                        case 97:
                        case 98:
                            if (Level - 2 > 0)
                                return String.Format("half-fiend {0}", EvilRace((int)CLASS.BARBARIAN, Level - 2, 94, ref random));
                            else
                                return EvilRace((int)CLASS.BARBARIAN, Level, 100, ref random);
                        case 99:
                        case 100:
                            if (Level - 2 > 0)
                                return String.Format("half-dragon {0}", EvilRace((int)CLASS.BARBARIAN, Level - 2, 94, ref random));
                            else
                                return EvilRace((int)CLASS.BARBARIAN, Level, 100, ref random);
                        default: return String.Format("orc (Level {0})", Level);
                    }
                case (int)CLASS.BARD:
                    switch (Dice.Roll(1, Limit, 0, ref random))
                    {
                        case 1: return String.Format("high elf (Level {0})", Level);
                        case 2: return String.Format("wood elf (Level {0})", Level);
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
                        case 17: return String.Format("half-elf (Level {0})", Level);
                        case 18: return String.Format("lightfoot halfling (Level {0})", Level);
                        case 19: return String.Format("deep halfling (Level {0})", Level);
                        case 20: return String.Format("tallfellow halfling (Level {0})", Level);
                        case 21:
                        case 22: return String.Format("half-orc (Level {0})", Level);
                        case 98: return String.Format("goblin (Level {0})", Level);
                        case 99: return String.Format("tiefling (Level {0})", Level);
                        case 100:
                            if (Level - 1 > 0)
                                return String.Format("werewolf {0}", EvilRace((int)CLASS.BARD, Level - 1, 99, ref random));
                            else
                                return EvilRace((int)CLASS.BARD, Level, 99, ref random);
                        default: return String.Format("human (Level {0})", Level);
                    }
                case (int)CLASS.CLERIC:
                    switch (Dice.Roll(1, Limit, 0, ref random))
                    {
                        case 1:
                        case 2: return String.Format("deep dwarf (Level {0})", Level);
                        case 3: return String.Format("hill dwarf (Level {0})", Level);
                        case 4: return String.Format("high elf (Level {0})", Level);
                        case 5: return String.Format("wild elf (Level {0})", Level);
                        case 6:
                        case 7:
                        case 8: return String.Format("wood elf (Level {0})", Level);
                        case 9:
                        case 10:
                        case 11:
                        case 12:
                        case 13:
                        case 14:
                        case 15:
                        case 16:
                        case 17:
                        case 18: return String.Format("half-elf (Level {0})", Level);
                        case 19:
                        case 20: return String.Format("lightfoot halfling (Level {0})", Level);
                        case 21: return String.Format("deep halfling (Level {0})", Level);
                        case 22: return String.Format("tallfellow halfling (Level {0})", Level);
                        case 23:
                        case 24:
                        case 25: return String.Format("half-orc (Level {0})", Level);
                        case 57:
                        case 58:
                        case 59:
                        case 60:
                        case 61:
                        case 62:
                        case 63: return String.Format("lizardfolk (Level {0})", Level);
                        case 64: return String.Format("goblin (Level {0})", Level);
                        case 65: return String.Format("hobgoblin (Level {0})", Level);
                        case 66: return String.Format("kobold (Level {0})", Level);
                        case 67: return String.Format("orc (Level {0})", Level);
                        case 68: return String.Format("tiefling (Level {0})", Level);
                        case 69:
                        case 70:
                        case 71:
                            if (Level - 1 > 0)
                                return String.Format("female drow (Level {0})", Level - 1);
                            else
                                return EvilRace((int)CLASS.CLERIC, Level, 68, ref random);
                        case 72:
                            if (Level - 1 > 0)
                                return String.Format("duergar (Level {0})", Level - 1);
                            else
                                return EvilRace((int)CLASS.CLERIC, Level, 68, ref random);
                        case 73:
                        case 74:
                            if (Level - 1 > 0)
                                return String.Format("gnoll (Level {0})", Level - 1);
                            else
                                return EvilRace((int)CLASS.CLERIC, Level, 68, ref random);
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
                            if (Level - 1 > 0)
                                return String.Format("troglodyte (Level {0})", Level - 1);
                            else
                                return EvilRace((int)CLASS.CLERIC, Level, 68, ref random);
                        case 90:
                        case 91:
                            if (Level - 2 > 0)
                                return String.Format("bugbear (Level {0})", Level - 2);
                            else
                                return EvilRace((int)CLASS.CLERIC, Level, Limit, ref random);
                        case 92:
                            if (Level - 2 > 0)
                                return String.Format("ogre (Level {0})", Level - 2);
                            else
                                return EvilRace((int)CLASS.CLERIC, Level, Limit, ref random);
                        case 93:
                            if (Level - 4 > 0)
                                return String.Format("minotaur (Level {0})", Level - 4);
                            else
                                return EvilRace((int)CLASS.CLERIC, Level, Limit, ref random);
                        case 94:
                            if (Level - 8 > 0)
                                return String.Format("mind flayer (Level {0})", Level - 8);
                            else
                                return EvilRace((int)CLASS.CLERIC, Level, Limit, ref random);
                        case 95:
                            if (Level - 8 > 0)
                                return String.Format("ogre mage (Level {0})", Level - 8);
                            else
                                return EvilRace((int)CLASS.CLERIC, Level, Limit, ref random);
                        case 96:
                            if (Level - 1 > 0)
                                return String.Format("wererat {0}", EvilRace((int)CLASS.CLERIC, Level - 1, 95, ref random));
                            else
                                return EvilRace((int)CLASS.CLERIC, Level, 68, ref random);
                        case 97:
                            if (Level - 1 > 0)
                                return String.Format("werewolf {0}", EvilRace((int)CLASS.CLERIC, Level - 1, 95, ref random));
                            else
                                return EvilRace((int)CLASS.CLERIC, Level, 68, ref random);
                        case 98:
                        case 99:
                            if (Level - 2 > 0)
                                return String.Format("half-fiend {0}", EvilRace((int)CLASS.CLERIC, Level - 2, 95, ref random));
                            else
                                return EvilRace((int)CLASS.CLERIC, Level, 97, ref random);
                        case 100:
                            if (Level - 2 > 0)
                                return String.Format("half-dragon {0}", EvilRace((int)CLASS.CLERIC, Level - 2, 95, ref random));
                            else
                                return EvilRace((int)CLASS.CLERIC, Level, 97, ref random);
                        default: return String.Format("human (Level {0})", Level);
                    }
                case (int)CLASS.DRUID:
                    switch (Dice.Roll(1, Limit, 0, ref random))
                    {
                        case 1:
                        case 2: return String.Format("wood elf (Level {0})", Level);
                        case 3: return String.Format("half-elf (Level {0})", Level);
                        case 4: return String.Format("tallfellow halfling (Level {0})", Level);
                        case 5:
                        case 6: return String.Format("half-orc (Level {0})", Level);
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
                        case 71: return String.Format("lizardfolk (Level {0})", Level);
                        case 72: return String.Format("goblin (Level {0})", Level);
                        case 73: return String.Format("hobgoblin (Level {0})", Level);
                        case 74: return String.Format("kobold (Level {0})", Level);
                        case 75: return String.Format("orc (Level {0})", Level);
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
                        case 97:
                        case 98:
                        case 99:
                        case 100:
                            if (Level - 1 > 0)
                                return String.Format("gnoll (Level {0})", Level - 1);
                            else
                                return EvilRace((int)CLASS.DRUID, Level, 75, ref random);
                        default: return String.Format("human (Level {0})", Level);
                    }
                case (int)CLASS.FIGHTER:
                    switch (Dice.Roll(1, Limit, 0, ref random))
                    {
                        case 1:
                        case 2: return String.Format("deep dwarf (Level {0})", Level);
                        case 3:
                        case 4: return String.Format("hill dwarf (Level {0})", Level);
                        case 5: return String.Format("high elf (Level {0})", Level);
                        case 6:
                        case 7: return String.Format("wood elf (Level {0})", Level);
                        case 8:
                        case 9:
                        case 10:
                        case 11:
                        case 12: return String.Format("half-elf (Level {0})", Level);
                        case 13: return String.Format("lightfoot halfling (Level {0})", Level);
                        case 14: return String.Format("deep halfling (Level {0})", Level);
                        case 15:
                        case 16:
                        case 17:
                        case 18:
                        case 19:
                        case 20:
                        case 21:
                        case 22:
                        case 23: return String.Format("half-orc (Level {0})", Level);
                        case 54: return String.Format("lizardfolk (Level {0})", Level);
                        case 55: return String.Format("goblin (Level {0})", Level);
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
                        case 75:
                        case 76:
                        case 77:
                        case 78:
                        case 79:
                        case 80: return String.Format("hobgoblin (Level {0})", Level);
                        case 81: return String.Format("kobold (Level {0})", Level);
                        case 82:
                        case 83:
                        case 84:
                        case 85:
                        case 86: return String.Format("orc (Level {0})", Level);
                        case 87:
                            if (Level - 1 > 0)
                                return String.Format("female drow (Level {0})", Level - 1);
                            else
                                return EvilRace((int)CLASS.FIGHTER, Level, 86, ref random);
                        case 88:
                            if (Level - 1 > 0)
                                return String.Format("male drow (Level {0})", Level - 1);
                            else
                                return EvilRace((int)CLASS.FIGHTER, Level, 86, ref random);
                        case 89:
                            if (Level - 1 > 0)
                                return String.Format("duergar (Level {0})", Level - 1);
                            else
                                return EvilRace((int)CLASS.FIGHTER, Level, 86, ref random);
                        case 90:
                            if (Level - 1 > 0)
                                return String.Format("derro dwarf (Level {0})", Level - 1);
                            else
                                return EvilRace((int)CLASS.FIGHTER, Level, 86, ref random);
                        case 91:
                            if (Level - 1 > 0)
                                return String.Format("gnoll (Level {0})", Level - 1);
                            else
                                return EvilRace((int)CLASS.FIGHTER, Level, 86, ref random);
                        case 92:
                            if (Level - 1 > 0)
                                return String.Format("troglodyte (Level {0})", Level - 1);
                            else
                                return EvilRace((int)CLASS.FIGHTER, Level, 86, ref random);
                        case 93:
                            if (Level - 2 > 0)
                                return String.Format("bugbear (Level {0})", Level - 2);
                            else
                                return EvilRace((int)CLASS.FIGHTER, Level, Limit, ref random);
                        case 94:
                            if (Level - 2 > 0)
                                return String.Format("ogre (Level {0})", Level - 2);
                            else
                                return EvilRace((int)CLASS.FIGHTER, Level, Limit, ref random);
                        case 95:
                            if (Level - 8 > 0)
                                return String.Format("mind flayer (Level {0})", Level - 8);
                            else
                                return EvilRace((int)CLASS.FIGHTER, Level, Limit, ref random);
                        case 96:
                            if (Level - 8 > 0)
                                return String.Format("ogre mage (Level {0})", Level - 8);
                            else
                                return EvilRace((int)CLASS.FIGHTER, Level, Limit, ref random);
                        case 97:
                            if (Level - 1 > 0)
                                return String.Format("wererat {0}", EvilRace((int)CLASS.FIGHTER, Level - 1, 96, ref random));
                            else
                                return EvilRace((int)CLASS.FIGHTER, Level, 86, ref random);
                        case 98:
                            if (Level - 1 > 0)
                                return String.Format("werewolf {0}", EvilRace((int)CLASS.FIGHTER, Level - 1, 96, ref random));
                            else
                                return EvilRace((int)CLASS.FIGHTER, Level, 86, ref random);
                        case 99:
                            if (Level - 2 > 0)
                                return String.Format("half-fiend {0}", EvilRace((int)CLASS.FIGHTER, Level - 2, 96, ref random));
                            else
                                return EvilRace((int)CLASS.FIGHTER, Level, 98, ref random);
                        case 100:
                            if (Level - 2 > 0)
                                return String.Format("half-dragon {0}", EvilRace((int)CLASS.FIGHTER, Level - 2, 96, ref random));
                            else
                                return EvilRace((int)CLASS.FIGHTER, Level, 98, ref random);
                        default: return String.Format("human (Level {0})", Level);
                    }
                case (int)CLASS.MONK:
                    switch (Dice.Roll(1, Limit, 0, ref random))
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
                        case 10: return String.Format("half-elf (Level {0})", Level);
                        case 11:
                        case 12:
                        case 13:
                        case 14:
                        case 15:
                        case 16:
                        case 17:
                        case 18:
                        case 19:
                        case 20: return String.Format("half-orc (Level {0})", Level);
                        case 91:
                        case 92:
                        case 93: return String.Format("hobgoblin (Level {0})", Level);
                        case 94: return String.Format("tiefling (Level {0})", Level);
                        case 95:
                        case 96:
                            if (Level - 8 > 0)
                                return String.Format("ogre mage (Level {0})", Level - 8);
                            else
                                return EvilRace((int)CLASS.MONK, Level, Limit, ref random);
                        case 97:
                        case 98:
                            if (Level - 1 > 0)
                                return String.Format("wererat {0}", EvilRace((int)CLASS.MONK, Level - 1, 96, ref random));
                            else
                                return EvilRace((int)CLASS.MONK, Level, 94, ref random);
                        case 99:
                            if (Level - 2 > 0)
                                return String.Format("half-fiend {0}", EvilRace((int)CLASS.MONK, Level - 2, 96, ref random));
                            else
                                return EvilRace((int)CLASS.MONK, Level, 98, ref random);
                        case 100:
                            if (Level - 2 > 0)
                                return String.Format("half-dragon {0}", EvilRace((int)CLASS.MONK, Level - 2, 96, ref random));
                            else
                                return EvilRace((int)CLASS.MONK, Level, 98, ref random);
                        default: return String.Format("human (Level {0})", Level);
                    }
                case (int)CLASS.RANGER:
                    switch (Dice.Roll(1, Limit, 0, ref random))
                    {
                        case 1: return String.Format("high elf (Level {0})", Level);
                        case 2:
                        case 3:
                        case 4:
                        case 5:
                        case 6:
                        case 7:
                        case 8:
                        case 9:
                        case 10:
                        case 11: return String.Format("wood elf (Level {0})", Level);
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
                        case 28: return String.Format("half-elf (Level {0})", Level);
                        case 29: return String.Format("lightfoot halfling (Level {0})", Level);
                        case 30: return String.Format("tallfellow halfling (Level {0})", Level);
                        case 31:
                        case 32:
                        case 33:
                        case 34:
                        case 35:
                        case 36:
                        case 37:
                        case 38:
                        case 39: return String.Format("half-orc (Level {0})", Level);
                        case 70:
                        case 71: return String.Format("lizardfolk (Level {0})", Level);
                        case 72: return String.Format("hobgoblins (Level {0})", Level);
                        case 73:
                        case 74:
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
                            if (Level - 1 > 0)
                                return String.Format("gnoll (Level {0})", Level - 1);
                            else
                                return EvilRace((int)CLASS.RANGER, Level, 72, ref random);
                        case 93:
                            if (Level - 1 > 0)
                                return String.Format("troglodyte (Level {0})", Level - 1);
                            else
                                return EvilRace((int)CLASS.RANGER, Level, 72, ref random);
                        case 94:
                            if (Level - 2 > 0)
                                return String.Format("bugbear (Level {0})", Level - 2);
                            else
                                return EvilRace((int)CLASS.RANGER, Level, Limit, ref random);
                        case 95:
                            if (Level - 2 > 0)
                                return String.Format("ogre (Level {0})", Level - 2);
                            else
                                return EvilRace((int)CLASS.RANGER, Level, Limit, ref random);
                        case 96:
                            if (Level - 1 > 0)
                                return String.Format("wererat {0}", EvilRace((int)CLASS.RANGER, Level - 1, 95, ref random));
                            else
                                return EvilRace((int)CLASS.RANGER, Level, 72, ref random);
                        case 97:
                        case 98:
                            if (Level - 1 > 0)
                                return String.Format("werewolf {0}", EvilRace((int)CLASS.RANGER, Level - 1, 95, ref random));
                            else
                                return EvilRace((int)CLASS.RANGER, Level, 72, ref random);
                        case 99:
                            if (Level - 2 > 0)
                                return String.Format("half-fiend {0}", EvilRace((int)CLASS.RANGER, Level - 2, 95, ref random));
                            else
                                return EvilRace((int)CLASS.RANGER, Level, 98, ref random);
                        case 100:
                            if (Level - 2 > 0)
                                return String.Format("half-dragon {0}", EvilRace((int)CLASS.RANGER, Level - 2, 95, ref random));
                            else
                                return EvilRace((int)CLASS.RANGER, Level, 98, ref random);
                        default: return String.Format("human (Level {0})", Level);
                    }
                case (int)CLASS.ROGUE:
                    switch (Dice.Roll(1, Limit, 0, ref random))
                    {
                        case 1: return String.Format("deep dwarf (Level {0})", Level);
                        case 2: return String.Format("high elf (Level {0})", Level);
                        case 3: return String.Format("wood elf (Level {0})", Level);
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
                        case 18: return String.Format("half-elf (Level {0})", Level);
                        case 39: return String.Format("deep halfling (Level {0})", Level);
                        case 40: return String.Format("tallfellow halfling (Level {0})", Level);
                        case 41:
                        case 42:
                        case 43:
                        case 44:
                        case 45:
                        case 46:
                        case 47:
                        case 48:
                        case 49:
                        case 50: return String.Format("half-orc (Level {0})", Level);
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
                        case 66:
                        case 67:
                        case 68:
                        case 69:
                        case 70: return String.Format("human (Level {0})", Level);
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
                        case 81:
                        case 82:
                        case 83:
                        case 84:
                        case 85: return String.Format("goblin (Level {0})", Level);
                        case 86: return String.Format("hobgoblin (Level {0})", Level);
                        case 87: return String.Format("kobold (Level {0})", Level);
                        case 88:
                        case 89: return String.Format("tiefling (Level {0})", Level);
                        case 90:
                        case 91:
                        case 92:
                        case 93:
                            if (Level - 2 > 0)
                                return String.Format("bugbear (Level {0})", Level - 2);
                            else
                                return EvilRace((int)CLASS.ROGUE, Level, Limit, ref random);
                        case 94:
                            if (Level - 8 > 0)
                                return String.Format("mind flayer (Level {0})", Level - 8);
                            else
                                return EvilRace((int)CLASS.ROGUE, Level, Limit, ref random);
                        case 95:
                        case 96:
                            if (Level - 1 > 0)
                                return String.Format("wererat {0}", EvilRace((int)CLASS.ROGUE, Level - 1, 94, ref random));
                            else
                                return EvilRace((int)CLASS.ROGUE, Level, 89, ref random);
                        case 97:
                            if (Level - 1 > 0)
                                return String.Format("werewolf {0}", EvilRace((int)CLASS.ROGUE, Level - 1, 94, ref random));
                            else
                                return EvilRace((int)CLASS.ROGUE, Level, 89, ref random);
                        case 98:
                        case 99:
                            if (Level - 2 > 0)
                                return String.Format("half-fiend {0}", EvilRace((int)CLASS.ROGUE, Level - 2, 94, ref random));
                            else
                                return EvilRace((int)CLASS.ROGUE, Level, 97, ref random);
                        case 100:
                            if (Level - 2 > 0)
                                return String.Format("half-dragon {0}", EvilRace((int)CLASS.ROGUE, Level - 2, 94, ref random));
                            else
                                return EvilRace((int)CLASS.ROGUE, Level, 97, ref random);
                        default: return String.Format("lightfoot halfling (Level {0})", Level);
                    }
                case (int)CLASS.SORCERER:
                    switch (Dice.Roll(1, Limit, 0, ref random))
                    {
                        case 1: return String.Format("wild elf (Level {0})", Level);
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
                        case 16: return String.Format("half-elf (Level {0})", Level);
                        case 17:
                        case 18:
                        case 19:
                        case 20:
                        case 21: return String.Format("lightfoot halfling (Level {0})", Level);
                        case 22: return String.Format("deep halfling (Level {0})", Level);
                        case 23: return String.Format("tallfellow halfling (Level {0})", Level);
                        case 24:
                        case 25:
                        case 26:
                        case 27:
                        case 28: return String.Format("half-orc (Level {0})", Level);
                        case 69: return String.Format("lizardfolk (Level {0})", Level);
                        case 70: return String.Format("goblin (Level {0})", Level);
                        case 71: return String.Format("hobgoblin (Level {0})", Level);
                        case 72:
                        case 73:
                        case 74:
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
                        case 86: return String.Format("kobold (Level {0})", Level);
                        case 87:
                            if (Level - 1 > 0)
                                return String.Format("gnoll (Level {0})", Level - 1);
                            else
                                return EvilRace((int)CLASS.SORCERER, Level, 86, ref random);
                        case 88:
                        case 89:
                        case 90:
                            if (Level - 1 > 0)
                                return String.Format("troglodyte (Level {0})", Level - 1);
                            else
                                return EvilRace((int)CLASS.SORCERER, Level, 86, ref random);
                        case 91:
                            if (Level - 2 > 0)
                                return String.Format("bugbear (Level {0})", Level - 2);
                            else
                                return EvilRace((int)CLASS.SORCERER, Level, Limit, ref random);
                        case 92:
                            if (Level - 2 > 0)
                                return String.Format("ogre (Level {0})", Level - 2);
                            else
                                return EvilRace((int)CLASS.SORCERER, Level, Limit, ref random);
                        case 93:
                            if (Level - 4 > 0)
                                return String.Format("minotaur (Level {0})", Level - 4);
                            else
                                return EvilRace((int)CLASS.SORCERER, Level, Limit, ref random);
                        case 94:
                            if (Level - 8 > 0)
                                return String.Format("mind flayer (Level {0})", Level - 8);
                            else
                                return EvilRace((int)CLASS.SORCERER, Level, Limit, ref random);
                        case 95:
                            if (Level - 8 > 0)
                                return String.Format("ogre mage (Level {0})", Level - 8);
                            else
                                return EvilRace((int)CLASS.SORCERER, Level, Limit, ref random);
                        case 96:
                            if (Level - 1 > 0)
                                return String.Format("wererat {0}", EvilRace((int)CLASS.SORCERER, Level - 1, 95, ref random));
                            else
                                return EvilRace((int)CLASS.SORCERER, Level, 86, ref random);
                        case 97:
                            if (Level - 1 > 0)
                                return String.Format("werewolf {0}", EvilRace((int)CLASS.SORCERER, Level - 1, 95, ref random));
                            else
                                return EvilRace((int)CLASS.SORCERER, Level, 86, ref random);
                        case 98:
                            if (Level - 2 > 0)
                                return String.Format("half-fiend {0}", EvilRace((int)CLASS.SORCERER, Level - 2, 95, ref random));
                            else
                                return EvilRace((int)CLASS.SORCERER, Level, 97, ref random);
                        case 99:
                        case 100:
                            if (Level - 2 > 0)
                                return String.Format("half-dragon {0}", EvilRace((int)CLASS.SORCERER, Level - 2, 95, ref random));
                            else
                                return EvilRace((int)CLASS.SORCERER, Level, 97, ref random);
                        default: return String.Format("human (Level {0})", Level);
                    }
                default:
                    switch (Dice.Roll(1, Limit, 0, ref random))
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
                        case 10: return String.Format("high elf (Level {0})", Level);
                        case 11: return String.Format("wood elf (Level {0})", Level);
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
                        case 26: return String.Format("half-elf (Level {0})", Level);
                        case 27: return String.Format("lightfoot halfling (Level {0})", Level);
                        case 28: return String.Format("tallfellow halfling (Level {0})", Level);
                        case 79:
                        case 80: return String.Format("hobgoblin (Level {0})", Level);
                        case 81: return String.Format("tiefling (Level {0})", Level);
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
                            if (Level - 1 > 0)
                                return String.Format("male drow (Level {0})", Level - 1);
                            else
                                return EvilRace((int)CLASS.WIZARD, Level, 81, ref random);
                        case 92:
                            if (Level - 1 > 0)
                                return String.Format("gnoll (Level {0})", Level - 1);
                            else
                                return EvilRace((int)CLASS.WIZARD, Level, 81, ref random);
                        case 93:
                            if (Level - 2 > 0)
                                return String.Format("bugbear (Level {0})", Level - 2);
                            else
                                return EvilRace((int)CLASS.WIZARD, Level, Limit, ref random);
                        case 94:
                            if (Level - 8 > 0)
                                return String.Format("mind flayer (Level {0})", Level - 8);
                            else
                                return EvilRace((int)CLASS.WIZARD, Level, Limit, ref random);
                        case 95:
                        case 96:
                            if (Level - 8 > 0)
                                return String.Format("ogre mage (Level {0})", Level - 8);
                            else
                                return EvilRace((int)CLASS.WIZARD, Level, Limit, ref random);
                        case 97:
                            if (Level - 1 > 0)
                                return String.Format("wererat {0}", EvilRace((int)CLASS.WIZARD, Level - 1, 96, ref random));
                            else
                                return EvilRace((int)CLASS.WIZARD, Level, 81, ref random);
                        case 98:
                            if (Level - 1 > 0)
                                return String.Format("werewolf {0}", EvilRace((int)CLASS.WIZARD, Level - 1, 96, ref random));
                            else
                                return EvilRace((int)CLASS.WIZARD, Level, 81, ref random);
                        case 99:
                            if (Level - 2 > 0)
                                return String.Format("half-fiend {0}", EvilRace((int)CLASS.WIZARD, Level - 2, 96, ref random));
                            else
                                return EvilRace((int)CLASS.WIZARD, Level, 98, ref random);
                        case 100:
                            if (Level - 2 > 0)
                                return String.Format("half-dragon {0}", EvilRace((int)CLASS.WIZARD, Level - 2, 96, ref random));
                            else
                                return EvilRace((int)CLASS.WIZARD, Level, 98, ref random);
                        default: return String.Format("human (Level {0})", Level);
                    }
            }
        }

        public static string RandomAlignment(ref Random random)
        {
            switch (Dice.Roll(1, 9, 0, ref random))
            {
                case 1: return "lawful good";
                case 2: return "neutral good";
                case 3: return "chaotic good";
                case 4: return "lawful neutral";
                case 5: return "true neutral";
                case 6: return "chaotic neutral";
                case 7: return "lawful evil";
                case 8: return "neutral evil";
                default: return "chaotic evil";
            }
        }

        public static string RandomGender(ref Random random, bool ExtraGenders)
        {
            int limit = 2;
            if (ExtraGenders)
                limit = 4;

            switch (Dice.Roll(1, limit, 0, ref random))
            {
                case 1: return "male";
                case 2: return "female";
                case 3: return "both";
                default: return "neither";
            }
        }

        public static string RandomClass(ref Random random)
        {
            switch (Dice.Roll(1, 11, 0, ref random))
            {
                case 1: return "barbarian";
                case 2: return "bard";
                case 3: return "cleric";
                case 4: return "druid";
                case 5: return "fighter";
                case 6: return "monk";
                case 7: return "paladin";
                case 8: return "ranger";
                case 9: return "rogue";
                case 10: return "sorcerer";
                default: return "wizard";
            }
        }

        public static string HumanoidSubtype(ref Random random)
        {
            switch (Dice.Roll(1, 510, 0, ref random))
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
                case 16: return "aasimar";
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
                case 32: return "deep dwarf";
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
                case 48: return "hill dwarf";
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
                case 64: return "mountain dwarf";
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
                case 80: return "gray elf";
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
                case 96: return "high elf";
                case 97:
                case 98:
                case 99:
                case 100:
                case 101:
                case 102:
                case 103:
                case 104:
                case 105:
                case 106:
                case 107:
                case 108:
                case 109:
                case 110:
                case 111:
                case 112: return "wild elf";
                case 113:
                case 114:
                case 115:
                case 116:
                case 117:
                case 118:
                case 119:
                case 120:
                case 121:
                case 122:
                case 123:
                case 124:
                case 125:
                case 126:
                case 127:
                case 128: return "wood elf";
                case 129:
                case 130:
                case 131:
                case 132:
                case 133:
                case 134:
                case 135:
                case 136:
                case 137:
                case 138:
                case 139:
                case 140:
                case 141:
                case 142:
                case 143:
                case 144: return "forest gnome";
                case 145:
                case 146:
                case 147:
                case 148:
                case 149:
                case 150:
                case 151:
                case 152:
                case 153:
                case 154:
                case 155:
                case 156:
                case 157:
                case 158:
                case 159:
                case 160: return "rock gnome";
                case 161:
                case 162:
                case 163:
                case 164:
                case 165:
                case 166:
                case 167:
                case 168:
                case 169:
                case 170:
                case 171:
                case 172:
                case 173:
                case 174:
                case 175:
                case 176: return "half-elf";
                case 177:
                case 178:
                case 179:
                case 180:
                case 181:
                case 182:
                case 183:
                case 184:
                case 185:
                case 186:
                case 187:
                case 188:
                case 189:
                case 190:
                case 191:
                case 192: return "lightfoot halfling";
                case 193:
                case 194:
                case 195:
                case 196:
                case 197:
                case 198:
                case 199:
                case 200:
                case 201:
                case 202:
                case 203:
                case 204:
                case 205:
                case 206:
                case 207:
                case 208: return "deep halfling";
                case 209:
                case 210:
                case 211:
                case 212:
                case 213:
                case 214:
                case 215:
                case 216:
                case 217:
                case 218:
                case 219:
                case 220:
                case 221:
                case 222:
                case 223:
                case 224: return "tallfellow halfling";
                case 225:
                case 226:
                case 227:
                case 228:
                case 229:
                case 230:
                case 231:
                case 232:
                case 233:
                case 234:
                case 235:
                case 236:
                case 237:
                case 238:
                case 239:
                case 240: return "half-orc";
                case 241:
                case 242:
                case 243:
                case 244:
                case 245:
                case 246:
                case 247:
                case 248:
                case 249:
                case 250:
                case 251:
                case 252:
                case 253:
                case 254:
                case 255:
                case 256: return "lizardfolk";
                case 257:
                case 258:
                case 259:
                case 260:
                case 261:
                case 262:
                case 263:
                case 264:
                case 265:
                case 266:
                case 267:
                case 268:
                case 269:
                case 270:
                case 271:
                case 272: return "goblin";
                case 273:
                case 274:
                case 275:
                case 276:
                case 277:
                case 278:
                case 279:
                case 280:
                case 281:
                case 282:
                case 283:
                case 284:
                case 285:
                case 286:
                case 287:
                case 288: return "hobgoblin";
                case 289:
                case 290:
                case 291:
                case 292:
                case 293:
                case 294:
                case 295:
                case 296:
                case 297:
                case 298:
                case 299:
                case 300:
                case 301:
                case 302:
                case 303:
                case 304: return "kobold";
                case 305:
                case 306:
                case 307:
                case 308:
                case 309:
                case 310:
                case 311:
                case 312:
                case 313:
                case 314:
                case 315:
                case 316:
                case 317:
                case 318:
                case 319:
                case 320: return "orc";
                case 321:
                case 322:
                case 323:
                case 324:
                case 325:
                case 326:
                case 327:
                case 328:
                case 329:
                case 330:
                case 331:
                case 332:
                case 333:
                case 334:
                case 335:
                case 336: return "tiefling";
                case 337:
                case 338:
                case 339:
                case 340: return "augmented";
                case 341:
                case 342:
                case 343:
                case 344:
                case 345:
                case 346:
                case 347:
                case 348:
                case 349:
                case 350:
                case 351:
                case 352:
                case 353:
                case 354:
                case 355:
                case 356: return "reptilian humanoid";
                case 357:
                case 358:
                case 359:
                case 360:
                case 361:
                case 362:
                case 363:
                case 364:
                case 365:
                case 366:
                case 367:
                case 368:
                case 369:
                case 370:
                case 371:
                case 372: return "goblinoid";
                case 373:
                case 374:
                case 375:
                case 376:
                case 377:
                case 378:
                case 379:
                case 380: return "svirfneblin";
                case 381:
                case 382:
                case 383:
                case 384:
                case 385:
                case 386:
                case 387:
                case 388: return "half-celestial";
                case 389:
                case 390:
                case 391:
                case 392: return "half-dragon";
                case 393:
                case 394:
                case 395:
                case 396:
                case 397:
                case 398:
                case 399:
                case 400: return "lycanthropes";
                case 401:
                case 402: return "doppelganger";
                case 403:
                case 404:
                case 405:
                case 406: return "werebear";
                case 407:
                case 408:
                case 409:
                case 410:
                case 411:
                case 412:
                case 413:
                case 414: return "wererat";
                case 415:
                case 416:
                case 417:
                case 418:
                case 419:
                case 420:
                case 421:
                case 422: return "wereboar";
                case 423:
                case 424:
                case 425:
                case 426:
                case 427:
                case 428:
                case 429:
                case 430: return "weretiger";
                case 431:
                case 432:
                case 433:
                case 434:
                case 435:
                case 436:
                case 437:
                case 438: return "werewolf";
                case 439:
                case 440:
                case 441:
                case 442: return "half-fiend";
                case 443:
                case 444:
                case 445:
                case 446:
                case 447:
                case 448:
                case 449:
                case 450: return "drow";
                case 451:
                case 452:
                case 453:
                case 454:
                case 455:
                case 456:
                case 457:
                case 458: return "duergar";
                case 459:
                case 460:
                case 461:
                case 462:
                case 463:
                case 464:
                case 465:
                case 466: return "derro dwarf";
                case 467:
                case 468:
                case 469:
                case 470:
                case 471:
                case 472:
                case 473:
                case 474: return "gnoll";
                case 475:
                case 476:
                case 477:
                case 478:
                case 479:
                case 480:
                case 481:
                case 482: return "troglodyte";
                case 483:
                case 484:
                case 485:
                case 486: return "bugbear";
                case 487:
                case 488:
                case 489:
                case 490: return "ogre";
                case 491:
                case 492: return "minotaur";
                case 493: return "mind flayer";
                case 494: return "ogre mage";
                default: return "human";
            }
        }

        public static string CreatureType(ref Random random)
        {
            switch (Dice.Percentile(ref random))
            {
                case 1:
                case 2:
                case 3:
                case 4:
                case 5: return "aberrations";
                case 6:
                case 7:
                case 8: return "animals";
                case 9:
                case 10:
                case 11:
                case 12:
                case 13: return "beasts";
                case 14:
                case 15:
                case 16:
                case 17:
                case 18:
                case 19:
                case 20: return "constructs";
                case 21:
                case 22:
                case 23:
                case 24:
                case 25: return "dragons";
                case 26:
                case 27:
                case 28:
                case 29:
                case 30: return "elementals";
                case 31:
                case 32:
                case 33:
                case 34:
                case 35: return "fey";
                case 36:
                case 37:
                case 38:
                case 39:
                case 40: return "giants";
                case 41:
                case 42:
                case 43:
                case 44:
                case 45: return "magical beasts";
                case 46:
                case 47:
                case 48:
                case 49:
                case 50: return "monstrous humanoids";
                case 51:
                case 52:
                case 53: return "oozes";
                case 54:
                case 55:
                case 56:
                case 57:
                case 58: return "chaotic outsiders";
                case 59:
                case 60:
                case 61:
                case 62:
                case 63:
                case 64:
                case 65: return "evil outsiders";
                case 66:
                case 67:
                case 68:
                case 69:
                case 70: return "good outsiders";
                case 71:
                case 72:
                case 73:
                case 74:
                case 75: return "lawful outsiders";
                case 76:
                case 77: return "plants";
                case 78:
                case 79:
                case 80:
                case 81:
                case 82:
                case 83:
                case 84:
                case 85: return "shapechangers";
                case 86:
                case 87:
                case 88:
                case 89:
                case 90:
                case 91:
                case 92: return "undead";
                case 93:
                case 94: return "vermin";
                default: return HumanoidSubtype(ref random);
            }
        }
    }
}