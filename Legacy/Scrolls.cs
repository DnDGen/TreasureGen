using System;
using System.Collections.Generic;
using System.Text;

namespace Dungeon_Maker
{
    class Scrolls
    {
        public enum SPELLTYPE { ARCANE, DIVINE };

        public static string Generate(MagicItems.POWER Power, ref Random random)
        {
            if (Dice.Percentile(ref random) < 71)
                return String.Format("An arcane scroll ({0})", Spells(SPELLTYPE.ARCANE, Power, ref random));
            return String.Format("A divine scroll ({0})", Spells(SPELLTYPE.DIVINE, Power, ref random));
        }

        public static string Generate(ref Random random, MagicItems.POWER Power, int SpellLimit)
        {
            if (Dice.Percentile(ref random) < 71)
                return String.Format("arcane ({0})", Spells(ref random, SPELLTYPE.ARCANE, Power, SpellLimit));
            return String.Format("divine ({0})", Spells(ref random, SPELLTYPE.DIVINE, Power, SpellLimit));
        }

        private static string Spells(ref Random random, SPELLTYPE SpellType, MagicItems.POWER Power, int SpellLimit)
        {
            string output = ""; int Roll;

            switch (Power)
            {
                case MagicItems.POWER.MINOR:
                    for (int i = Dice.Roll(1, 3, 0, ref random); i > 0; i--)
                    {
                        Roll = Dice.Percentile(ref random);

                        if (Roll < 51)
                        {
                            if (SpellLimit - 1 >= 0)
                            {
                                output += String.Format("{0}, ", Level1(ref random, SpellType));
                                SpellLimit--;
                            }
                            else
                                return output;
                        }
                        else if (Roll < 96)
                        {
                            if (SpellLimit - 2 >= 0)
                            {
                                output += String.Format("{0}, ", Level2(ref random, SpellType));
                                SpellLimit -= 2;
                            }
                            else
                                return output;
                        }
                        else
                        {
                            if (SpellLimit - 3 >= 0)
                            {
                                output += String.Format("{0}, ", Level3(ref random, SpellType));
                                SpellLimit -= 3;
                            }
                            else
                                return output;
                        }
                    }
                    return output;
                case MagicItems.POWER.MEDIUM:
                    for (int i = Dice.d4(ref random); i > 0; i--)
                    {
                        Roll = Dice.Percentile(ref random);

                        if (Roll < 6)
                        {
                            if (SpellLimit - 2 >= 0)
                            {
                                output += String.Format("{0}, ", Level2(ref random, SpellType));
                                SpellLimit -= 2;
                            }
                            else
                                return output;
                        }
                        else if (Roll < 66)
                        {
                            if (SpellLimit - 3 >= 0)
                            {
                                output += String.Format("{0}, ", Level3(ref random, SpellType));
                                SpellLimit -= 3;
                            }
                            else
                                return output;
                        }
                        else if (Roll < 96)
                        {
                            if (SpellLimit - 4 >= 0)
                            {
                                output += String.Format("{0}, ", Level4(ref random, SpellType));
                                SpellLimit -= 4;
                            }
                            else
                                return output;
                        }
                        else
                        {
                            if (SpellLimit - 5 >= 0)
                            {
                                output += String.Format("{0}, ", Level5(ref random, SpellType));
                                SpellLimit -= 5;
                            }
                            else
                                return output;
                        }
                    }
                    return output;
                case MagicItems.POWER.MAJOR:
                    for (int i = Dice.d6(ref random); i > 0; i--)
                    {
                        Roll = Dice.Percentile(ref random);

                        if (Roll < 6)
                        {
                            if (SpellLimit - 4 >= 0)
                            {
                                output += String.Format("{0}, ", Level4(ref random, SpellType));
                                SpellLimit -= 4;
                            }
                            else
                                return output;
                        }
                        else if (Roll < 51)
                        {
                            if (SpellLimit - 5 >= 0)
                            {
                                output += String.Format("{0}, ", Level5(ref random, SpellType));
                                SpellLimit -= 5;
                            }
                            else
                                return output;
                        }
                        else if (Roll < 71)
                        {
                            if (SpellLimit - 6 >= 0)
                            {
                                output += String.Format("{0}, ", Level6(ref random, SpellType));
                                SpellLimit -= 6;
                            }
                            else
                                return output;
                        }
                        else if (Roll < 86)
                        {
                            if (SpellLimit - 7 >= 0)
                            {
                                output += String.Format("{0}, ", Level7(ref random, SpellType));
                                SpellLimit -= 7;
                            }
                            else
                                return output;
                        }
                        else if (Roll < 96)
                        {
                            if (SpellLimit - 8 >= 0)
                            {
                                output += String.Format("{0}, ", Level8(ref random, SpellType));
                                SpellLimit -= 8;
                            }
                            else
                                return output;
                        }
                        else
                        {
                            if (SpellLimit - 9 >= 0)
                            {
                                output += String.Format("{0}, ", Level9(ref random, SpellType));
                                SpellLimit -= 9;
                            }
                            else
                                return output;
                        }
                    }
                    return output;
                default: return "";
            }
        }

        private static string Spells(SPELLTYPE SpellType, MagicItems.POWER Power, ref Random random)
        {
            string output = ""; int Roll;

            switch (Power)
            {
                case MagicItems.POWER.MINOR:
                    for (int i = Dice.Roll(1, 3, 0, ref random); i > 0; i--)
                    {
                        Roll = Dice.Percentile(ref random);

                        if (Roll < 51)
                            output += String.Format("{0}, ", Level1(ref random, SpellType));
                        else if (Roll < 96)
                            output += String.Format("{0}, ", Level2(ref random, SpellType));
                        else
                            output += String.Format("{0}, ", Level3(ref random, SpellType));
                    }
                    return output;
                case MagicItems.POWER.MEDIUM:
                    for (int i = Dice.d4(ref random); i > 0; i--)
                    {
                        Roll = Dice.Percentile(ref random);

                        if (Roll < 6)
                            output += String.Format("{0}, ", Level2(ref random, SpellType));
                        else if (Roll < 66)
                            output += String.Format("{0}, ", Level3(ref random, SpellType));
                        else if (Roll < 96)
                            output += String.Format("{0}, ", Level4(ref random, SpellType));
                        else
                            output += String.Format("{0}, ", Level5(ref random, SpellType));
                    }
                    return output;
                case MagicItems.POWER.MAJOR:
                    for (int i = Dice.d6(ref random); i > 0; i--)
                    {
                        Roll = Dice.Percentile(ref random);

                        if (Roll < 6)
                            output += String.Format("{0}, ", Level4(ref random, SpellType));
                        else if (Roll < 51)
                            output += String.Format("{0}, ", Level5(ref random, SpellType));
                        else if (Roll < 71)
                            output += String.Format("{0}, ", Level6(ref random, SpellType));
                        else if (Roll < 86)
                            output += String.Format("{0}, ", Level7(ref random, SpellType));
                        else if (Roll < 96)
                            output += String.Format("{0}, ", Level8(ref random, SpellType));
                        else
                            output += String.Format("{0}, ", Level9(ref random, SpellType));
                    }
                    return output;
                default: return "";
            }
        }

        private static string Level1(ref Random random, SPELLTYPE SpellType)
        {
            int Level = 1;
            while (true)
            {
                switch (SpellType)
                {
                    case SPELLTYPE.DIVINE:
                        switch (Dice.Percentile(ref random))
                        {
                            case 1:
                            case 2:
                            case 3:
                            case 4:
                            case 5: return String.Format("bless ({0})", Level);
                            case 6:
                            case 7:
                            case 8:
                            case 9:
                            case 10: return String.Format("calm animals ({0})", Level);
                            case 11:
                            case 12:
                            case 13:
                            case 14: return String.Format("command ({0})", Level);
                            case 15:
                            case 16:
                            case 17:
                            case 18:
                            case 19: return String.Format("cure light wounds ({0})", Level);
                            case 20:
                            case 21:
                            case 22: return String.Format("detect chaos ({0})", Level);
                            case 23:
                            case 24:
                            case 25: return String.Format("detect evil ({0})", Level);
                            case 26:
                            case 27:
                            case 28: return String.Format("detect good ({0})", Level);
                            case 29:
                            case 30:
                            case 31: return String.Format("detect law ({0})", Level);
                            case 32:
                            case 33:
                            case 34: return String.Format("detect snares and pits ({0})", Level);
                            case 35:
                            case 36:
                            case 37:
                            case 38:
                            case 39: return String.Format("doom ({0})", Level);
                            case 40:
                            case 41:
                            case 42:
                            case 43:
                            case 44: return String.Format("entangle ({0})", Level);
                            case 45:
                            case 46:
                            case 47:
                            case 48:
                            case 49: return String.Format("faerie fire ({0})", Level);
                            case 50:
                            case 51:
                            case 52:
                            case 53:
                            case 54: return String.Format("inflict light wounds ({0})", Level);
                            case 55:
                            case 56:
                            case 57:
                            case 58:
                            case 59: return String.Format("invisibility to animals ({0})", Level);
                            case 60:
                            case 61:
                            case 62:
                            case 63:
                            case 64: return String.Format("invisibility to undead ({0})", Level);
                            case 65:
                            case 66:
                            case 67: return String.Format("magic fang ({0})", Level);
                            case 68:
                            case 69:
                            case 70: return String.Format("magic stone ({0})", Level);
                            case 71:
                            case 72:
                            case 73: return String.Format("magic weapon ({0})", Level);
                            case 74:
                            case 75:
                            case 76:
                            case 77: return String.Format("sanctuary ({0})", Level);
                            case 78:
                            case 79:
                            case 80:
                            case 81:
                            case 82: return String.Format("shillelagh ({0})", Level);
                            case 83:
                            case 84:
                            case 85:
                            case 86: return String.Format("summon monster I ({0})", Level);
                            case 87:
                            case 88:
                            case 89:
                            case 90: return String.Format("summon nature's ally I ({0})", Level);
                            default: Level++; break;
                        } break;
                    default:
                        switch (Dice.Percentile(ref random))
                        {
                            case 1:
                            case 2:
                            case 3:
                            case 4:
                            case 5: return String.Format("burning hands ({0})", Level);
                            case 6:
                            case 7:
                            case 8:
                            case 9:
                            case 10: return String.Format("change self ({0})", Level);
                            case 11:
                            case 12:
                            case 13:
                            case 14:
                            case 15: return String.Format("charm person ({0})", Level);
                            case 16:
                            case 17:
                            case 18: return String.Format("color spray ({0})", Level);
                            case 19:
                            case 20:
                            case 21:
                            case 22: return String.Format("detect secret doors ({0})", Level);
                            case 23:
                            case 24:
                            case 25: return String.Format("detect undead ({0})", Level);
                            case 26:
                            case 27:
                            case 28: return String.Format("enlarge ({0})", Level);
                            case 29:
                            case 30:
                            case 31: return String.Format("erase ({0})", Level);
                            case 32:
                            case 33:
                            case 34:
                            case 35:
                            case 36: return String.Format("feather fall ({0})", Level);
                            case 37:
                            case 38:
                            case 39: return String.Format("grease ({0})", Level);
                            case 40:
                            case 41:
                            case 42:
                            case 43:
                            case 44: return String.Format("identify ({0})", Level);
                            case 45:
                            case 46:
                            case 47: return String.Format("jump ({0})", Level);
                            case 48:
                            case 49:
                            case 50:
                            case 51: return String.Format("mage armor ({0})", Level);
                            case 52:
                            case 53:
                            case 54: return String.Format("magic weapon ({0})", Level);
                            case 55:
                            case 56:
                            case 57: return String.Format("mount ({0})", Level);
                            case 58:
                            case 59:
                            case 60: return String.Format("ray of enfeeblement ({0})", Level);
                            case 61:
                            case 62:
                            case 63: return String.Format("reduce ({0})", Level);
                            case 64:
                            case 65:
                            case 66: return String.Format("shield ({0})", Level);
                            case 67:
                            case 68:
                            case 69: return String.Format("shocking grasp ({0})", Level);
                            case 70:
                            case 71:
                            case 72:
                            case 73: return String.Format("silent image ({0})", Level);
                            case 74:
                            case 75:
                            case 76:
                            case 77:
                            case 78: return String.Format("sleep ({0})", Level);
                            case 79:
                            case 80:
                            case 81: return String.Format("spider climb ({0})", Level);
                            case 82:
                            case 83:
                            case 84: return String.Format("summon monster I ({0})", Level);
                            case 85:
                            case 86:
                            case 87: return String.Format("floating disk ({0})", Level);
                            case 88:
                            case 89:
                            case 90:
                            case 91:
                            case 92: return String.Format("unseen servant ({0})", Level);
                            case 93:
                            case 94:
                            case 95: return String.Format("ventriloquism ({0})", Level);
                            default: Level++; break;
                        } break;
                }
            }
        }

        private static string Level2(ref Random random, SPELLTYPE SpellType)
        {
            int Level = 3;

            while (true)
            {
                switch (SpellType)
                {
                    case SPELLTYPE.DIVINE:
                        switch (Dice.Percentile(ref random))
                        {
                            case 1:
                            case 2:
                            case 3:
                            case 4:
                            case 5: return String.Format("aid ({0})", Level);
                            case 6:
                            case 7:
                            case 8:
                            case 9:
                            case 10: return String.Format("augury ({0})", Level);
                            case 11:
                            case 12:
                            case 13:
                            case 14:
                            case 15: return String.Format("barkskin ({0})", Level);
                            case 16:
                            case 17:
                            case 18:
                            case 19:
                            case 20: return String.Format("bull's strength ({0})", Level);
                            case 21:
                            case 22:
                            case 23:
                            case 24:
                            case 25: return String.Format("charm person or animal ({0})", Level);
                            case 26:
                            case 27:
                            case 28: return String.Format("chill metal ({0})", Level);
                            case 29:
                            case 30:
                            case 31: return String.Format("cure moderate wounds ({0})", Level);
                            case 32:
                            case 33:
                            case 34:
                            case 35:
                            case 36: return String.Format("delay poison ({0})", Level);
                            case 37:
                            case 38:
                            case 39: return String.Format("flame blade ({0})", Level);
                            case 40:
                            case 41:
                            case 42: return String.Format("flaming sphere ({0})", Level);
                            case 43:
                            case 44:
                            case 45:
                            case 46:
                            case 47: return String.Format("heat metal ({0})", Level);
                            case 48:
                            case 49:
                            case 50: return String.Format("hold animal ({0})", Level);
                            case 51:
                            case 52:
                            case 53:
                            case 54:
                            case 55: return String.Format("hold person ({0})", Level);
                            case 56:
                            case 57:
                            case 58: return String.Format("inflict moderate wounds ({0})", Level);
                            case 59:
                            case 60:
                            case 61:
                            case 62:
                            case 63: return String.Format("lesser restoration ({0})", Level);
                            case 64:
                            case 65:
                            case 66:
                            case 67: return String.Format("silence ({0})", Level);
                            case 68:
                            case 69:
                            case 70: return String.Format("speak with animals ({0})", Level);
                            case 71:
                            case 72:
                            case 73:
                            case 74:
                            case 75: return String.Format("spiritual weapon ({0})", Level);
                            case 76:
                            case 77:
                            case 78:
                            case 79: return String.Format("summon monster II ({0})", Level);
                            case 80:
                            case 81:
                            case 82:
                            case 83: return String.Format("summon nature's ally II ({0})", Level);
                            case 84:
                            case 85: return String.Format("summon swarm ({0})", Level);
                            case 86:
                            case 87:
                            case 88:
                            case 89:
                            case 90: return String.Format("undetectable alignment ({0})", Level);
                            default: Level++; break;
                        } break;
                    default:
                        switch (Dice.Percentile(ref random))
                        {
                            case 1:
                            case 2:
                            case 3: return String.Format("arcane lock ({0})", Level);
                            case 4:
                            case 5:
                            case 6:
                            case 7:
                            case 8: return String.Format("blindness/deafness ({0})", Level);
                            case 9:
                            case 10:
                            case 11:
                            case 12:
                            case 13: return String.Format("blur ({0})", Level);
                            case 14:
                            case 15:
                            case 16:
                            case 17:
                            case 18: return String.Format("bull's strength ({0})", Level);
                            case 19:
                            case 20:
                            case 21:
                            case 22: return String.Format("cat's grace ({0})", Level);
                            case 23:
                            case 24:
                            case 25: return String.Format("darkvision ({0})", Level);
                            case 26:
                            case 27:
                            case 28:
                            case 29:
                            case 30: return String.Format("detect thoughts ({0})", Level);
                            case 31:
                            case 32:
                            case 33: return String.Format("flaming sphere ({0})", Level);
                            case 34:
                            case 35:
                            case 36:
                            case 37:
                            case 38: return String.Format("invisibility ({0})", Level);
                            case 39:
                            case 40:
                            case 41: return String.Format("knock ({0})", Level);
                            case 42:
                            case 43:
                            case 44:
                            case 45:
                            case 46: return String.Format("levitate ({0})", Level);
                            case 47:
                            case 48:
                            case 49:
                            case 50:
                            case 51: return String.Format("locate object ({0})", Level);
                            case 52:
                            case 53:
                            case 54: return String.Format("acid arrow ({0})", Level);
                            case 55:
                            case 56:
                            case 57:
                            case 58:
                            case 59: return String.Format("minor image ({0})", Level);
                            case 60:
                            case 61:
                            case 62:
                            case 63:
                            case 64: return String.Format("mirror image ({0})", Level);
                            case 65:
                            case 66:
                            case 67:
                            case 68:
                            case 69: return String.Format("misdirection ({0})", Level);
                            case 70:
                            case 71:
                            case 72: return String.Format("protection from arrows ({0})", Level);
                            case 73:
                            case 74:
                            case 75:
                            case 76:
                            case 77: return String.Format("see invisibility ({0})", Level);
                            case 78:
                            case 79:
                            case 80: return String.Format("spectral hand ({0})", Level);
                            case 81:
                            case 82:
                            case 83: return String.Format("stinking cloud ({0})", Level);
                            case 84:
                            case 85:
                            case 86:
                            case 87: return String.Format("summon monster II ({0})", Level);
                            case 88:
                            case 89:
                            case 90:
                            case 91:
                            case 92: return String.Format("summon swarm ({0})", Level);
                            case 93:
                            case 94:
                            case 95:
                            case 96: return String.Format("web ({0})", Level);
                            default: Level++; break;
                        } break;
                }
            }
        }

        private static string Level3(ref Random random, SPELLTYPE SpellType)
        {
            int Level = 5;

            while (true)
            {
                switch (SpellType)
                {
                    case SPELLTYPE.DIVINE:
                        switch (Dice.Percentile(ref random))
                        {
                            case 1:
                            case 2: return String.Format("call lightning ({0})", Level);
                            case 3:
                            case 4:
                            case 5:
                            case 6:
                            case 7:
                            case 8:
                            case 9: return String.Format("cure serious wounds ({0})", Level);
                            case 10:
                            case 11:
                            case 12:
                            case 13: return String.Format("dispel magic ({0})", Level);
                            case 14:
                            case 15: return String.Format("dominate animal ({0})", Level);
                            case 16:
                            case 17: return String.Format("greater magic fang ({0})", Level);
                            case 18:
                            case 19: return String.Format("inflict serious wounds ({0})", Level);
                            case 20:
                            case 21:
                            case 22: return String.Format("invisibility purge ({0})", Level);
                            case 23:
                            case 24:
                            case 25:
                            case 26: return String.Format("locate object ({0})", Level);
                            case 27:
                            case 28: return String.Format("magic circle against chaos ({0})", Level);
                            case 29:
                            case 30: return String.Format("magic circle against evil ({0})", Level);
                            case 31:
                            case 32: return String.Format("magic circle against good ({0})", Level);
                            case 33:
                            case 34: return String.Format("magic circle against law ({0})", Level);
                            case 35:
                            case 36:
                            case 37:
                            case 38: return String.Format("negative energy protection ({0})", Level);
                            case 39:
                            case 40:
                            case 41: return String.Format("neutralize poison ({0})", Level);
                            case 42:
                            case 43: return String.Format("plant growth ({0})", Level);
                            case 44:
                            case 45:
                            case 46: return String.Format("prayer ({0})", Level);
                            case 47:
                            case 48:
                            case 49:
                            case 50:
                            case 51: return String.Format("protection from elements ({0})", Level);
                            case 52:
                            case 53: return String.Format("remove blindness/deafness ({0})", Level);
                            case 54:
                            case 55:
                            case 56: return String.Format("remove curse ({0})", Level);
                            case 57:
                            case 58:
                            case 59: return String.Format("remove disease ({0})", Level);
                            case 60:
                            case 61:
                            case 62: return String.Format("searing light ({0})", Level);
                            case 63:
                            case 64:
                            case 65: return String.Format("speak with dead ({0})", Level);
                            case 66:
                            case 67: return String.Format("spike growth ({0})", Level);
                            case 68:
                            case 69:
                            case 70:
                            case 71:
                            case 72: return String.Format("stone shape ({0})", Level);
                            case 73:
                            case 74:
                            case 75: return String.Format("summon monster III ({0})", Level);
                            case 76:
                            case 77:
                            case 78: return String.Format("summon nature's ally III ({0})", Level);
                            case 79:
                            case 80: return String.Format("water breathing ({0})", Level);
                            case 81:
                            case 82:
                            case 83:
                            case 84:
                            case 85:
                            case 86:
                            case 87:
                            case 88:
                            case 89:
                            case 90: return String.Format("water walk ({0})", Level);
                            default: Level++; break;
                        } break;
                    default:
                        switch (Dice.Percentile(ref random))
                        {
                            case 1:
                            case 2:
                            case 3:
                            case 4:
                            case 5: return String.Format("blink ({0})", Level);
                            case 6:
                            case 7:
                            case 8:
                            case 9:
                            case 10: return String.Format("clairaudience/clairvoyance ({0})", Level);
                            case 11:
                            case 12:
                            case 13:
                            case 14:
                            case 15: return String.Format("dispel magic ({0})", Level);
                            case 16:
                            case 17:
                            case 18:
                            case 19:
                            case 20: return String.Format("displacement ({0})", Level);
                            case 21:
                            case 22:
                            case 23:
                            case 24:
                            case 25: return String.Format("fireball ({0})", Level);
                            case 26:
                            case 27:
                            case 28: return String.Format("flame arrow ({0})", Level);
                            case 29:
                            case 30:
                            case 31: return String.Format("fly ({0})", Level);
                            case 32:
                            case 33: return String.Format("gaseous form ({0})", Level);
                            case 34:
                            case 35:
                            case 36: return String.Format("greater magic weapon ({0})", Level);
                            case 37:
                            case 38:
                            case 39: return String.Format("halt undead ({0})", Level);
                            case 40:
                            case 41:
                            case 42: return String.Format("haste ({0})", Level);
                            case 43:
                            case 44:
                            case 45: return String.Format("hold person ({0})", Level);
                            case 46:
                            case 47: return String.Format("invisibility sphere ({0})", Level);
                            case 48:
                            case 49:
                            case 50:
                            case 51:
                            case 52:
                            case 53: return String.Format("lightning bolt ({0})", Level);
                            case 54: return String.Format("magic circle against chaos ({0})", Level);
                            case 55: return String.Format("magic circle against evil ({0})", Level);
                            case 56: return String.Format("magic circle against good ({0})", Level);
                            case 57: return String.Format("magic circle against law ({0})", Level);
                            case 58:
                            case 59:
                            case 60: return String.Format("nondetection ({0})", Level);
                            case 61:
                            case 62:
                            case 63:
                            case 64:
                            case 65: return String.Format("slow ({0})", Level);
                            case 66:
                            case 67:
                            case 68:
                            case 69:
                            case 70: return String.Format("spectral hand ({0})", Level);
                            case 71:
                            case 72:
                            case 73:
                            case 74:
                            case 75: return String.Format("suggestion ({0})", Level);
                            case 76:
                            case 77:
                            case 78:
                            case 79: return String.Format("summon monster III ({0})", Level);
                            case 80:
                            case 81:
                            case 82:
                            case 83:
                            case 84: return String.Format("tongues ({0})", Level);
                            case 85:
                            case 86:
                            case 87: return String.Format("vampiric touch ({0})", Level);
                            case 88:
                            case 89:
                            case 90: return String.Format("water breathing ({0})", Level);
                            default: Level++; break;
                        } break;
                }
            }
        }

        private static string Level4(ref Random random, SPELLTYPE SpellType)
        {
            int Level = 7;

            while (true)
            {
                switch (SpellType)
                {
                    case SPELLTYPE.DIVINE:
                        switch (Dice.Percentile(ref random))
                        {
                            case 1:
                            case 2: return String.Format("antiplant shell ({0})", Level);
                            case 3:
                            case 4:
                            case 5: return String.Format("control water ({0})", Level);
                            case 6:
                            case 7:
                            case 8:
                            case 9:
                            case 10:
                            case 11:
                            case 12: return String.Format("cure critical wounds ({0})", Level);
                            case 13:
                            case 14:
                            case 15:
                            case 16:
                            case 17:
                            case 18:
                            case 19: return String.Format("discern lies ({0})", Level);
                            case 20:
                            case 21:
                            case 22:
                            case 23:
                            case 24: return String.Format("dispel magic ({0})", Level);
                            case 25:
                            case 26:
                            case 27: return String.Format("divine power ({0})", Level);
                            case 28:
                            case 29:
                            case 30:
                            case 31:
                            case 32:
                            case 33:
                            case 34: return String.Format("flame strike ({0})", Level);
                            case 35:
                            case 36:
                            case 37:
                            case 38:
                            case 39:
                            case 40:
                            case 41: return String.Format("freedom of movement ({0})", Level);
                            case 42:
                            case 43:
                            case 44:
                            case 45:
                            case 46:
                            case 47: return String.Format("giant vermin ({0})", Level);
                            case 48:
                            case 49:
                            case 50: return String.Format("greater magic weapon ({0})", Level);
                            case 51:
                            case 52:
                            case 53: return String.Format("inflict critical wounds ({0})", Level);
                            case 54:
                            case 55: return String.Format("lesser planar ally ({0})", Level);
                            case 56: 
                            case 57:
                            case 58:
                            case 59: 
                            case 60:
                            case 61:
                            case 62: return String.Format("neutralize poison ({0})", Level);
                            case 63:
                            case 64:
                            case 65:
                            case 66: return String.Format("quench ({0})", Level);
                            case 67:
                            case 68: return String.Format("restoration ({0})", Level);
                            case 69:
                            case 70:
                            case 71: return String.Format("rusting grasp ({0})", Level);
                            case 72: 
                            case 73:
                            case 74: return String.Format("spell immunity ({0})", Level);
                            case 75:
                            case 76: return String.Format("spike stones ({0})", Level);
                            case 77:
                            case 78: 
                            case 79:
                            case 80: return String.Format("summon monster IV ({0})", Level);
                            case 81:
                            case 82: return String.Format("summon nature's ally IV ({0})", Level);
                            case 83:
                            case 84:
                            case 85:
                            case 86:
                            case 87:
                            case 88:
                            case 89:
                            case 90: return String.Format("tongues ({0})", Level);
                            default: Level++; break;
                        } break;
                    default:
                        switch (Dice.Percentile(ref random))
                        {
                            case 1:
                            case 2:
                            case 3:
                            case 4:
                            case 5: return String.Format("charm monster ({0})", Level);
                            case 6:
                            case 7:
                            case 8:
                            case 9:
                            case 10: return String.Format("confusion ({0})", Level);
                            case 11:
                            case 12:
                            case 13:
                            case 14:
                            case 15: return String.Format("contagion ({0})", Level);
                            case 16:
                            case 17:
                            case 18:
                            case 19:
                            case 20: return String.Format("detect scrying ({0})", Level);
                            case 21:
                            case 22:
                            case 23: return String.Format("dimensional anchor ({0})", Level);
                            case 24:
                            case 25:
                            case 26:
                            case 27:
                            case 28: return String.Format("dimension door ({0})", Level);
                            case 29:
                            case 30:
                            case 31: 
                            case 32:
                            case 33: return String.Format("emotion ({0})", Level);
                            case 34:
                            case 35:
                            case 36: return String.Format("enervation ({0})", Level);
                            case 37:
                            case 38:
                            case 39: return String.Format("Evard's black tentacles ({0})", Level);
                            case 40:
                            case 41:
                            case 42: 
                            case 43:
                            case 44: return String.Format("fear ({0})", Level);
                            case 45: 
                            case 46:
                            case 47: return String.Format("fire shield ({0})", Level);
                            case 48:
                            case 49:
                            case 50: return String.Format("ice storm ({0})", Level);
                            case 51:
                            case 52:
                            case 53: 
                            case 54:
                            case 55: return String.Format("improved invisibility ({0})", Level);
                            case 56: 
                            case 57:
                            case 58: return String.Format("lesser geas ({0})", Level);
                            case 59:
                            case 60:
                            case 61: return String.Format("minor globe of invulnerability ({0})", Level);
                            case 62:
                            case 63:
                            case 64:
                            case 65: 
                            case 66:
                            case 67: return String.Format("phantasmal killer ({0})", Level);
                            case 68:
                            case 69:
                            case 70: return String.Format("polymorph other ({0})", Level);
                            case 71:
                            case 72:
                            case 73: return String.Format("polymorph self ({0})", Level);
                            case 74:
                            case 75:
                            case 76: return String.Format("remove curse ({0})", Level);
                            case 77:
                            case 78:
                            case 79: return String.Format("shadow conjuration ({0})", Level);
                            case 80:
                            case 81:
                            case 82: return String.Format("stoneskin ({0})", Level);
                            case 83:
                            case 84: return String.Format("summon monster IV ({0})", Level);
                            case 85:
                            case 86:
                            case 87: return String.Format("wall of fire ({0})", Level);
                            case 88:
                            case 89:
                            case 90: return String.Format("wall of ice ({0})", Level);
                            default: Level++; break;
                        } break;
                }
            }
        }

        private static string Level5(ref Random random, SPELLTYPE SpellType)
        {
            int Level = 9;

            while (true)
            {
                switch (SpellType)
                {
                    case SPELLTYPE.DIVINE:
                        switch (Dice.Percentile(ref random))
                        {
                            case 1:
                            case 2: 
                            case 3:
                            case 4:
                            case 5: 
                            case 6:
                            case 7: return String.Format("break enchantment ({0})", Level);
                            case 8:
                            case 9:
                            case 10:
                            case 11:
                            case 12:
                            case 13: return String.Format("commune ({0})", Level);
                            case 14:
                            case 15: return String.Format("control winds ({0})", Level);
                            case 16:
                            case 17:
                            case 18:
                            case 19:
                            case 20:
                            case 21:
                            case 22: return String.Format("cure critical wounds ({0})", Level);
                            case 23:
                            case 24: 
                            case 25:
                            case 26: return String.Format("dispel evil ({0})", Level);
                            case 27: 
                            case 28:
                            case 29: return String.Format("dispel good ({0})", Level);
                            case 30:
                            case 31:
                            case 32:
                            case 33:
                            case 34:
                            case 35: return String.Format("flame strike ({0})", Level);
                            case 36:
                            case 37:
                            case 38: return String.Format("greater command ({0})", Level);
                            case 39:
                            case 40: return String.Format("hallow ({0})", Level);
                            case 41: 
                            case 42:
                            case 43: return String.Format("healing circle ({0})", Level);
                            case 44:
                            case 45: return String.Format("ice storm ({0})", Level);
                            case 46:
                            case 47: 
                            case 48:
                            case 49:
                            case 50: return String.Format("insect plague ({0})", Level);
                            case 51:
                            case 52:
                            case 53: 
                            case 54:
                            case 55: 
                            case 56:
                            case 57: return String.Format("raise dead ({0})", Level);
                            case 58:
                            case 59:
                            case 60: return String.Format("righteous might ({0})", Level);
                            case 61:
                            case 62:
                            case 63: return String.Format("slay living ({0})", Level);
                            case 64:
                            case 65: return String.Format("spell resistance ({0})", Level);
                            case 66:
                            case 67: return String.Format("summon monster V ({0})", Level);
                            case 68:
                            case 69: return String.Format("summon nature's ally V ({0})", Level);
                            case 70:
                            case 71:
                            case 72: return String.Format("transmute rock to mud ({0})", Level);
                            case 73:
                            case 74: return String.Format("true seeing ({0})", Level);
                            case 75: return String.Format("unhallow ({0})", Level);
                            case 76: 
                            case 77:
                            case 78: return String.Format("wall of fire ({0})", Level);
                            case 79:
                            case 80: return String.Format("wall of stone ({0})", Level);
                            case 81:
                            case 82: 
                            case 83:
                            case 84:
                            case 85:
                            case 86:
                            case 87:
                            case 88:
                            case 89:
                            case 90: return String.Format("wall of thorns ({0})", Level);
                            default: Level++; break;
                        } break;
                    default:
                        switch (Dice.Percentile(ref random))
                        {
                            case 1:
                            case 2:
                            case 3:
                            case 4: return String.Format("interposing hand ({0})", Level);
                            case 5: 
                            case 6:
                            case 7:
                            case 8: return String.Format("cloudkill ({0})", Level);
                            case 9:
                            case 10: 
                            case 11:
                            case 12:
                            case 13: return String.Format("cone of cold ({0})", Level);
                            case 14:
                            case 15: 
                            case 16:
                            case 17: return String.Format("dismissal ({0})", Level);
                            case 18:
                            case 19:
                            case 20:
                            case 21: return String.Format("domination ({0})", Level);
                            case 22:
                            case 23:
                            case 24: return String.Format("feeblemind ({0})", Level);
                            case 25:
                            case 26:
                            case 27: return String.Format("greater shadow conjuration ({0})", Level);
                            case 28: 
                            case 29:
                            case 30:
                            case 31: return String.Format("hold monster ({0})", Level);
                            case 32:
                            case 33:
                            case 34:
                            case 35: return String.Format("major creation ({0})", Level);
                            case 36: 
                            case 37:
                            case 38:
                            case 39:
                            case 40: return String.Format("mind fog ({0})", Level);
                            case 41:
                            case 42:
                            case 43:
                            case 44: return String.Format("passwall ({0})", Level);
                            case 45:
                            case 46:
                            case 47: 
                            case 48:
                            case 49: return String.Format("persistent image ({0})", Level);
                            case 50: 
                            case 51:
                            case 52:
                            case 53: return String.Format("shadow evocation ({0})", Level);
                            case 54:
                            case 55:
                            case 56: return String.Format("stone shape ({0})", Level);
                            case 57:
                            case 58: 
                            case 59:
                            case 60: return String.Format("summon monster V ({0})", Level);
                            case 61: 
                            case 62:
                            case 63:
                            case 64: return String.Format("telekinesis ({0})", Level);
                            case 65:
                            case 66:
                            case 67: 
                            case 68:
                            case 69: return String.Format("teleport ({0})", Level);
                            case 70: 
                            case 71:
                            case 72:
                            case 73: return String.Format("transmute mud to rock ({0})", Level);
                            case 74:
                            case 75:
                            case 76:
                            case 77: return String.Format("transmute rock to mud ({0})", Level);
                            case 78:
                            case 79: 
                            case 80:
                            case 81: return String.Format("wall of force ({0})", Level);
                            case 82: 
                            case 83:
                            case 84:
                            case 85:
                            case 86: return String.Format("wall of iron ({0})", Level);
                            case 87: 
                            case 88:
                            case 89:
                            case 90: return String.Format("wall of stone ({0})", Level);
                            default: Level++; break;
                        } break;
                }
            }
        }

        private static string Level6(ref Random random, SPELLTYPE SpellType)
        {
            int Level = 11;

            while (true)
            {
                switch (SpellType)
                {
                    case SPELLTYPE.DIVINE:
                        switch (Dice.Percentile(ref random))
                        {
                            case 1:
                            case 2:
                            case 3:
                            case 4:
                            case 5:
                            case 6:
                            case 7:
                            case 8: return String.Format("antilife shell ({0})", Level);
                            case 9:
                            case 10:
                            case 11:
                            case 12:
                            case 13:
                            case 14: return String.Format("blade barrier ({0})", Level);
                            case 15: 
                            case 16:
                            case 17:
                            case 18:
                            case 19: return String.Format("find the path ({0})", Level);
                            case 20:
                            case 21:
                            case 22:
                            case 23: return String.Format("fire seeds ({0})", Level);
                            case 24:
                            case 25:
                            case 26: 
                            case 27:
                            case 28: return String.Format("Geas/Quest ({0})", Level);
                            case 29: 
                            case 30:
                            case 31:
                            case 32:
                            case 33:
                            case 34: return String.Format("harm ({0})", Level);
                            case 35: 
                            case 36:
                            case 37:
                            case 38: 
                            case 39:
                            case 40:
                            case 41: return String.Format("heal ({0})", Level);
                            case 42:
                            case 43: 
                            case 44:
                            case 45:
                            case 46:
                            case 47: return String.Format("heroes' feast ({0})", Level);
                            case 48:
                            case 49:
                            case 50:
                            case 51:
                            case 52:
                            case 53:
                            case 54:
                            case 55: return String.Format("planar ally ({0})", Level);
                            case 56:
                            case 57: return String.Format("repel wood ({0})", Level);
                            case 58:
                            case 59:
                            case 60: return String.Format("stone tell ({0})", Level);
                            case 61:
                            case 62:
                            case 63: 
                            case 64:
                            case 65: 
                            case 66:
                            case 67:
                            case 68: return String.Format("summon monster VI ({0})", Level);
                            case 69:
                            case 70:
                            case 71: return String.Format("transport via plants ({0})", Level);
                            case 72: 
                            case 73:
                            case 74: 
                            case 75: 
                            case 76:
                            case 77: return String.Format("wall of stone ({0})", Level);
                            case 78: 
                            case 79:
                            case 80: return String.Format("wind walk ({0})", Level);
                            case 81:
                            case 82:
                            case 83:
                            case 84:
                            case 85:
                            case 86:
                            case 87:
                            case 88:
                            case 89:
                            case 90: return String.Format("word of recall ({0})", Level);
                            default: Level++; break;
                        } break;
                    default:
                        switch (Dice.Percentile(ref random))
                        {
                            case 1:
                            case 2:
                            case 3:
                            case 4: return String.Format("acid fog ({0})", Level);
                            case 5:
                            case 6:
                            case 7: return String.Format("analyze dweomer ({0})", Level);
                            case 8: 
                            case 9:
                            case 10:
                            case 11: return String.Format("antimagic field ({0})", Level);
                            case 12:
                            case 13: 
                            case 14:
                            case 15: return String.Format("forceful hand ({0})", Level);
                            case 16:
                            case 17: 
                            case 18:
                            case 19: return String.Format("chain lightning ({0})", Level);
                            case 20:
                            case 21: 
                            case 22:
                            case 23: return String.Format("circle of death ({0})", Level);
                            case 24: 
                            case 25:
                            case 26: return String.Format("control water ({0})", Level);
                            case 27: 
                            case 28:
                            case 29:
                            case 30: return String.Format("disintegrate ({0})", Level);
                            case 31: 
                            case 32:
                            case 33: return String.Format("eyebite ({0})", Level);
                            case 34:
                            case 35:
                            case 36:
                            case 37: return String.Format("flesh to stone ({0})", Level);
                            case 38:
                            case 39:
                            case 40:
                            case 41: return String.Format("globe of invulnerability ({0})", Level);
                            case 42:
                            case 43:
                            case 44:
                            case 45: return String.Format("greater shadow evocation ({0})", Level);
                            case 46:
                            case 47:
                            case 48:
                            case 49: return String.Format("mass suggestion ({0})", Level);
                            case 50:
                            case 51:
                            case 52: return String.Format("mislead ({0})", Level);
                            case 53: 
                            case 54:
                            case 55:
                            case 56:
                            case 57: return String.Format("move earth ({0})", Level);
                            case 58:
                            case 59:
                            case 60:
                            case 61: return String.Format("freezing sphere ({0})", Level);
                            case 62:
                            case 63:
                            case 64:
                            case 65: return String.Format("programmed image ({0})", Level);
                            case 66:
                            case 67:
                            case 68:
                            case 69:
                            case 70: return String.Format("project image ({0})", Level);
                            case 71:
                            case 72:
                            case 73: 
                            case 74:
                            case 75: return String.Format("repulsion ({0})", Level);
                            case 76:
                            case 77:
                            case 78: return String.Format("shades ({0})", Level);
                            case 79:
                            case 80:
                            case 81:
                            case 82: return String.Format("stone to flesh ({0})", Level);
                            case 83:
                            case 84:
                            case 85:
                            case 86: return String.Format("summon monster VI ({0})", Level);
                            case 87:
                            case 88:
                            case 89:
                            case 90: return String.Format("true seeing ({0})", Level);
                            default: Level++; break;
                        } break;
                }
            }
        }

        private static string Level7(ref Random random, SPELLTYPE SpellType)
        {
            int Level = 13;

            while (true)
            {
                switch (SpellType)
                {
                    case SPELLTYPE.DIVINE:
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
                            case 11: return String.Format("control weather ({0})", Level);
                            case 12:
                            case 13:
                            case 14: 
                            case 15:
                            case 16:
                            case 17:
                            case 18: return String.Format("creeping doom ({0})", Level);
                            case 19: 
                            case 20:
                            case 21:
                            case 22:
                            case 23:
                            case 24:
                            case 25: return String.Format("destruction ({0})", Level);
                            case 26:
                            case 27:
                            case 28: 
                            case 29:
                            case 30:
                            case 31:
                            case 32: return String.Format("dictum ({0})", Level);
                            case 33:
                            case 34: 
                            case 35:
                            case 36: return String.Format("fire storm ({0})", Level);
                            case 37:
                            case 38:
                            case 39:
                            case 40: return String.Format("greater restoration ({0})", Level);
                            case 41: 
                            case 42:
                            case 43:
                            case 44:
                            case 45:
                            case 46:
                            case 47: return String.Format("holy word ({0})", Level);
                            case 48:
                            case 49:
                            case 50:
                            case 51:
                            case 52:
                            case 53:
                            case 54: return String.Format("regenerate ({0})", Level);
                            case 55: 
                            case 56:
                            case 57: 
                            case 58:
                            case 59:
                            case 60:
                            case 61: return String.Format("repulsion ({0})", Level);
                            case 62:
                            case 63:
                            case 64:
                            case 65:
                            case 66:
                            case 67:
                            case 68: return String.Format("resurrection ({0})", Level);
                            case 69:
                            case 70:
                            case 71:
                            case 72: return String.Format("summon monster VII ({0})", Level);
                            case 73:
                            case 74:
                            case 75:
                            case 76: return String.Format("transmute metal to wood ({0})", Level);
                            case 77: 
                            case 78:
                            case 79:
                            case 80: return String.Format("true seeing ({0})", Level);
                            case 81:
                            case 82:
                            case 83:
                            case 84:
                            case 85:
                            case 86:
                            case 87:
                            case 88:
                            case 89:
                            case 90: return String.Format("word of chaos ({0})", Level);
                            default: Level++; break;
                        } break;
                    default:
                        switch (Dice.Percentile(ref random))
                        {
                            case 1:
                            case 2:
                            case 3:
                            case 4:
                            case 5: return String.Format("grasping hand ({0})", Level);
                            case 6:
                            case 7: 
                            case 8:
                            case 9:
                            case 10: return String.Format("control undead ({0})", Level);
                            case 11: 
                            case 12:
                            case 13:
                            case 14:
                            case 15: return String.Format("forceful hand ({0})", Level);
                            case 16:
                            case 17:
                            case 18:
                            case 19: return String.Format("chain lightning ({0})", Level);
                            case 20:
                            case 21:
                            case 22:
                            case 23: return String.Format("circle of death ({0})", Level);
                            case 24:
                            case 25:
                            case 26: return String.Format("control water ({0})", Level);
                            case 27:
                            case 28:
                            case 29:
                            case 30: return String.Format("disintegrate ({0})", Level);
                            case 31:
                            case 32:
                            case 33: return String.Format("eyebite ({0})", Level);
                            case 34:
                            case 35:
                            case 36:
                            case 37: return String.Format("flesh to stone ({0})", Level);
                            case 38:
                            case 39:
                            case 40:
                            case 41: return String.Format("globe of invulnerability ({0})", Level);
                            case 42:
                            case 43:
                            case 44:
                            case 45: return String.Format("greater shadow evocation ({0})", Level);
                            case 46:
                            case 47:
                            case 48:
                            case 49: return String.Format("mass suggestion ({0})", Level);
                            case 50:
                            case 51:
                            case 52: return String.Format("mislead ({0})", Level);
                            case 53:
                            case 54:
                            case 55:
                            case 56:
                            case 57: return String.Format("move earth ({0})", Level);
                            case 58:
                            case 59:
                            case 60:
                            case 61: return String.Format("freezing sphere ({0})", Level);
                            case 62:
                            case 63:
                            case 64:
                            case 65: return String.Format("programmed image ({0})", Level);
                            case 66:
                            case 67:
                            case 68:
                            case 69:
                            case 70: return String.Format("project image ({0})", Level);
                            case 71:
                            case 72:
                            case 73:
                            case 74:
                            case 75: return String.Format("repulsion ({0})", Level);
                            case 76:
                            case 77:
                            case 78: return String.Format("shades ({0})", Level);
                            case 79:
                            case 80:
                            case 81:
                            case 82: return String.Format("stone to flesh ({0})", Level);
                            case 83:
                            case 84:
                            case 85:
                            case 86: return String.Format("summon monster VI ({0})", Level);
                            case 87:
                            case 88:
                            case 89:
                            case 90: return String.Format("true seeing ({0})", Level);
                            default: Level++; break;
                        } break;
                }
            }
        }

        private static string Level8(ref Random random, SPELLTYPE SpellType)
        {
            int Level = 15;

            while (true)
            {
                switch (SpellType)
                {
                    case SPELLTYPE.DIVINE:
                        switch (Dice.Percentile(ref random))
                        {
                            case 1:
                            case 2:
                            case 3:
                            case 4:
                            case 5:
                            case 6: return String.Format("antimagic field ({0})", Level);
                            case 7:
                            case 8: 
                            case 9:
                            case 10:
                            case 11:
                            case 12: return String.Format("creeping doom ({0})", Level);
                            case 13:
                            case 14:
                            case 15:
                            case 16:
                            case 17:
                            case 18: return String.Format("discern location ({0})", Level);
                            case 19:
                            case 20:
                            case 21:
                            case 22:
                            case 23:
                            case 24:
                            case 25: return String.Format("earthquake ({0})", Level);
                            case 26:
                            case 27:
                            case 28:
                            case 29:
                            case 30: return String.Format("finger of death ({0})", Level);
                            case 31:
                            case 32: 
                            case 33:
                            case 34:
                            case 35: return String.Format("fire storm ({0})", Level);
                            case 36:
                            case 37:
                            case 38:
                            case 39:
                            case 40: 
                            case 41:
                            case 42:
                            case 43:
                            case 44: return String.Format("holy aura ({0})", Level);
                            case 45:
                            case 46:
                            case 47: 
                            case 48:
                            case 49:
                            case 50: return String.Format("mass heal ({0})", Level);
                            case 51:
                            case 52:
                            case 53:
                            case 54:
                            case 55:
                            case 56: return String.Format("repel metal or stone ({0})", Level);
                            case 57:
                            case 58:
                            case 59:
                            case 60:
                            case 61:
                            case 62: return String.Format("reverse gravity ({0})", Level);
                            case 63:
                            case 64:
                            case 65:
                            case 66:
                            case 67:
                            case 68: return String.Format("summon monster VIII ({0})", Level);
                            case 69:
                            case 70:
                            case 71:
                            case 72: 
                            case 73:
                            case 74: return String.Format("sunburst ({0})", Level);
                            case 75:
                            case 76: 
                            case 77:
                            case 78:
                            case 79:
                            case 80: return String.Format("unholy aura ({0})", Level);
                            case 81:
                            case 82:
                            case 83:
                            case 84:
                            case 85:
                            case 86:
                            case 87:
                            case 88:
                            case 89:
                            case 90: return String.Format("whirlwind ({0})", Level);
                            default: Level++; break;
                        } break;
                    default:
                        switch (Dice.Percentile(ref random))
                        {
                            case 1:
                            case 2:
                            case 3: return String.Format("antipathy ({0})", Level);
                            case 4:
                            case 5: 
                            case 6:
                            case 7:
                            case 8: return String.Format("clenched fist ({0})", Level);
                            case 9:
                            case 10: 
                            case 11:
                            case 12:
                            case 13: return String.Format("clone ({0})", Level);
                            case 14:
                            case 15: 
                            case 16:
                            case 17:
                            case 18: return String.Format("demand ({0})", Level);
                            case 19: 
                            case 20:
                            case 21:
                            case 22:
                            case 23: return String.Format("horrid wilting ({0})", Level);
                            case 24:
                            case 25:
                            case 26:
                            case 27:
                            case 28: return String.Format("incendiary cloud ({0})", Level);
                            case 29:
                            case 30: 
                            case 31:
                            case 32:
                            case 33: return String.Format("mass charm ({0})", Level);
                            case 34:
                            case 35:
                            case 36:
                            case 37:
                            case 38: return String.Format("maze ({0})", Level);
                            case 39:
                            case 40:
                            case 41: 
                            case 42:
                            case 43: return String.Format("mind blank ({0})", Level);
                            case 44:
                            case 45:
                            case 46:
                            case 47:
                            case 48: return String.Format("telekinetic sphere ({0})", Level);
                            case 49: 
                            case 50:
                            case 51:
                            case 52:
                            case 53: return String.Format("irresistable dance ({0})", Level);
                            case 54:
                            case 55:
                            case 56:
                            case 57:
                            case 58: return String.Format("polymorph any object ({0})", Level);
                            case 59:
                            case 60:
                            case 61: 
                            case 62:
                            case 63: return String.Format("power word, blind ({0})", Level);
                            case 64:
                            case 65: 
                            case 66:
                            case 67:
                            case 68: return String.Format("prismatic wall ({0})", Level);
                            case 69:
                            case 70: 
                            case 71:
                            case 72:
                            case 73: return String.Format("protection from spells ({0})", Level);
                            case 74:
                            case 75: 
                            case 76:
                            case 77:
                            case 78: return String.Format("screen ({0})", Level);
                            case 79:
                            case 80:
                            case 81:
                            case 82:
                            case 83: return String.Format("summon monster VII ({0})", Level);
                            case 84:
                            case 85:
                            case 86: 
                            case 87:
                            case 88: return String.Format("sunburst ({0})", Level);
                            case 89:
                            case 90: return String.Format("sympathy ({0})", Level);
                            default: Level++; break;
                        } break;
                }
            }
        }

        private static string Level9(ref Random random, SPELLTYPE SpellType)
        {
            int Level = 17;

            while (true)
            {
                switch (SpellType)
                {
                    case SPELLTYPE.DIVINE:
                        switch (Dice.Percentile(ref random))
                        {
                            case 1:
                            case 2:
                            case 3:
                            case 4: return String.Format("antipathy ({0})", Level);
                            case 5:
                            case 6:
                            case 7: return String.Format("astral projection ({0})", Level);
                            case 8:
                            case 9:
                            case 10:
                            case 11:
                            case 12:
                            case 13: return String.Format("elemental swarm ({0})", Level);
                            case 14:
                            case 15:
                            case 16:
                            case 17:
                            case 18:
                            case 19: return String.Format("energy drain ({0})", Level);
                            case 20:
                            case 21:
                            case 22:
                            case 23:
                            case 24:
                            case 25: return String.Format("etherealness ({0})", Level);
                            case 26:
                            case 27:
                            case 28:
                            case 29:
                            case 30:
                            case 31: return String.Format("foresight ({0})", Level);
                            case 32:
                            case 33:
                            case 34:
                            case 35: 
                            case 36:
                            case 37: return String.Format("gate ({0})", Level);
                            case 38:
                            case 39:
                            case 40:
                            case 41:
                            case 42:
                            case 43:
                            case 44: 
                            case 45:
                            case 46: return String.Format("mass heal ({0})", Level);
                            case 47:
                            case 48:
                            case 49:
                            case 50: 
                            case 51:
                            case 52:
                            case 53: return String.Format("implosion ({0})", Level);
                            case 54:
                            case 55: return String.Format("miracle ({0})", Level);
                            case 56: 
                            case 57:
                            case 58:
                            case 59:
                            case 60:
                            case 61: return String.Format("regenerate ({0})", Level);
                            case 62: 
                            case 63:
                            case 64:
                            case 65:
                            case 66: return String.Format("shambler ({0})", Level);
                            case 67:
                            case 68: 
                            case 69:
                            case 70:
                            case 71:
                            case 72: return String.Format("shapechange ({0})", Level);
                            case 73:
                            case 74: 
                            case 75:
                            case 76:
                            case 77: return String.Format("soul bind ({0})", Level);
                            case 78:
                            case 79:
                            case 80: 
                            case 81:
                            case 82:
                            case 83: return String.Format("storm of vengeance ({0})", Level);
                            case 84:
                            case 85:
                            case 86:
                            case 87:
                            case 88:
                            case 89: return String.Format("summon monster IX ({0})", Level);
                            case 90:
                            case 91:
                            case 92:
                            case 93:
                            case 94:
                            case 95: return String.Format("summon nature's ally IX ({0})", Level);
                            case 96:
                            case 97:
                            case 98:
                            case 99: return String.Format("sympathy ({0})", Level);
                            case 100: return String.Format("true resurrection ({0})", Level);
                            default: return "[Error: 9th level divine out of range.  Scrolls.1980]";
                        }
                    default:
                        switch (Dice.Percentile(ref random))
                        {
                            case 1:
                            case 2:
                            case 3: return String.Format("astral projection ({0})", Level);
                            case 4:
                            case 5:
                            case 6:
                            case 7: return String.Format("crushing hand ({0})", Level);
                            case 8: 
                            case 9:
                            case 10:
                            case 11:
                            case 12: return String.Format("dominate monster ({0})", Level);
                            case 13:
                            case 14: 
                            case 15:
                            case 16: return String.Format("energy drain ({0})", Level);
                            case 17:
                            case 18:
                            case 19:
                            case 20:
                            case 21: return String.Format("etherealness ({0})", Level);
                            case 22:
                            case 23: 
                            case 24:
                            case 25: return String.Format("foresight ({0})", Level);
                            case 26:
                            case 27:
                            case 28: 
                            case 29:
                            case 30:
                            case 31: return String.Format("freedom ({0})", Level);
                            case 32:
                            case 33: 
                            case 34:
                            case 35:
                            case 36: return String.Format("gate ({0})", Level);
                            case 37:
                            case 38: 
                            case 39:
                            case 40: return String.Format("mass hold monster ({0})", Level);
                            case 41:
                            case 42:
                            case 43:
                            case 44: return String.Format("imprisonment ({0})", Level);
                            case 45:
                            case 46:
                            case 47:
                            case 48:
                            case 49: return String.Format("meteor swarm ({0})", Level);
                            case 50:
                            case 51:
                            case 52:
                            case 53: return String.Format("mage's disjunction ({0})", Level);
                            case 54:
                            case 55:
                            case 56:
                            case 57:
                            case 58: return String.Format("power word kill ({0})", Level);
                            case 59:
                            case 60:
                            case 61:
                            case 62: return String.Format("prismatic sphere ({0})", Level);
                            case 63: 
                            case 64:
                            case 65:
                            case 66: return String.Format("refuge ({0})", Level);
                            case 67:
                            case 68:
                            case 69:
                            case 70: return String.Format("shades ({0})", Level);
                            case 71:
                            case 72:
                            case 73: 
                            case 74:
                            case 75:
                            case 76: return String.Format("shapechange ({0})", Level);
                            case 77:
                            case 78:
                            case 79: return String.Format("soul bind ({0})", Level);
                            case 80:
                            case 81:
                            case 82:
                            case 83: return String.Format("Summon monster IX ({0})", Level);
                            case 84:
                            case 85:
                            case 86: return String.Format("teleportation circle ({0})", Level);
                            case 87:
                            case 88: 
                            case 89:
                            case 90:
                            case 91: return String.Format("time stop ({0})", Level);
                            case 92:
                            case 93:
                            case 94:
                            case 95: return String.Format("wail of the banshee ({0})", Level);
                            case 96:
                            case 97:
                            case 98:
                            case 99: return String.Format("weird ({0})", Level);
                            case 100: return String.Format("wish ({0})", Level);
                            default: return "[Error: 9th-level Arcane out of range.  Scrolls.2085]";
                        }
                }
            }
        }

        public static string RandomSpell(ref Random random, int MaxLevel)
        {
            switch (Dice.Roll(1, MaxLevel, 0, ref random))
            {
                case 1: return Level1(ref random, RandomSpellType(ref random));
                case 2: return Level2(ref random, RandomSpellType(ref random));
                case 3: return Level3(ref random, RandomSpellType(ref random));
                case 4: return Level4(ref random, RandomSpellType(ref random));
                case 5: return Level5(ref random, RandomSpellType(ref random));
                case 6: return Level6(ref random, RandomSpellType(ref random));
                case 7: return Level7(ref random, RandomSpellType(ref random));
                case 8: return Level8(ref random, RandomSpellType(ref random));
                default: return Level9(ref random, RandomSpellType(ref random));
            }
        }

        private static SPELLTYPE RandomSpellType(ref Random random)
        {
            return (SPELLTYPE)Dice.Roll(1, 2, -1, ref random);
        }

        public static string RandomSpell(ref Random random, int MaxLevel, SPELLTYPE SpellType)
        {
            switch (Dice.Roll(1, MaxLevel, 0, ref random))
            {
                case 1: return Level1(ref random, SpellType);
                case 2: return Level2(ref random, SpellType);
                case 3: return Level3(ref random, SpellType);
                case 4: return Level4(ref random, SpellType);
                case 5: return Level5(ref random, SpellType);
                case 6: return Level6(ref random, SpellType);
                case 7: return Level7(ref random, SpellType);
                case 8: return Level8(ref random, SpellType);
                default: return Level9(ref random, SpellType);
            }
        }
    }
}
