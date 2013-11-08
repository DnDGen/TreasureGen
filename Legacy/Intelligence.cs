using System;
using System.Collections.Generic;
using System.Text;

namespace Dungeon_Maker
{
    class Intelligence
    {
        public static string Generate(ref Random random, int bonus)
        {
            int Intelligence; int Wisdom; int Charisma; string Speech; string Abilities; string Alignment; int Ego = bonus;
            int[] Rolls = new int[3];

            switch (Dice.Percentile(ref random))
            {

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
                    Rolls[0] = Dice.Roll(2, 6, 6, ref random);
                    Rolls[1] = Dice.Roll(2, 6, 6, ref random);
                    Rolls[2] = Dice.Roll(3, 6, 0, ref random);
                    Speech = "Empathy";
                    Abilities = PrimaryAbility(ref random, 2, ref Ego);
                    break;
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
                    Rolls[0] = Dice.Roll(2, 6, 7, ref random);
                    Rolls[1] = Dice.Roll(2, 6, 7, ref random);
                    Rolls[2] = Dice.Roll(3, 6, 0, ref random);
                    Speech = "Speech";
                    Abilities = PrimaryAbility(ref random, 2, ref Ego);
                    break;
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
                    Rolls[0] = Dice.Roll(2, 6, 8, ref random);
                    Rolls[1] = Dice.Roll(2, 6, 8, ref random);
                    Rolls[2] = Dice.Roll(3, 6, 0, ref random);
                    Speech = "Speech";
                    Abilities = PrimaryAbility(ref random, 3, ref Ego);
                    break;
                case 92:
                case 93:
                case 94:
                case 95:
                case 96:
                case 97:
                    Rolls[0] = Dice.Roll(2, 6, 9, ref random);
                    Rolls[1] = Dice.Roll(2, 6, 9, ref random);
                    Rolls[2] = Dice.Roll(3, 6, 0, ref random);
                    Speech = "Speech, read languages"; Ego += 1;
                    Abilities = PrimaryAbility(ref random, 3, ref Ego);
                    break;
                case 98:
                    Rolls[0] = Dice.Roll(2, 6, 10, ref random);
                    Rolls[1] = Dice.Roll(2, 6, 10, ref random);
                    Rolls[2] = Dice.Roll(3, 6, 0, ref random);
                    Speech = "Speech, telepathy, read languages"; Ego += 2;
                    Abilities = String.Format("{0} and {1}", PrimaryAbility(ref random, 3, ref Ego), ExtraordinaryAbility(ref random, 1, ref Ego));
                    break;
                case 99:
                    Rolls[0] = Dice.Roll(2, 6, 11, ref random);
                    Rolls[1] = Dice.Roll(2, 6, 11, ref random);
                    Rolls[2] = Dice.Roll(3, 6, 0, ref random);
                    Speech = "Speech, telepathy, read all languages, read magic"; Ego += 3;
                    Abilities = String.Format("{0} and {1}", PrimaryAbility(ref random, 3, ref Ego), ExtraordinaryAbility(ref random, 2, ref Ego));
                    break;
                case 100:
                    Rolls[0] = Dice.Roll(2, 6, 12, ref random);
                    Rolls[1] = Dice.Roll(2, 6, 12, ref random);
                    Rolls[2] = Dice.Roll(3, 6, 0, ref random);
                    Speech = "Speech, telepathy, read all languages, read magic"; Ego += 3;
                    Abilities = String.Format("{0} and {1}", PrimaryAbility(ref random, 4, ref Ego), ExtraordinaryAbility(ref random, 2, ref Ego));
                    break;
                default:
                    Rolls[0] = Dice.Roll(2, 6, 5, ref random);
                    Rolls[1] = Dice.Roll(2, 6, 5, ref random);
                    Rolls[2] = Dice.Roll(3, 6, 0, ref random);
                    Speech = "Semiempathy";
                    Abilities = PrimaryAbility(ref random, 1, ref Ego);
                    break;
            }

            foreach (int roll in Rolls)
                Ego += (roll - 10) / 2;

            Array.Sort(Rolls);
            switch (Dice.d4(ref random))
            {
                case 1:
                    Charisma = Rolls[1];
                    Intelligence = Rolls[2];
                    Wisdom = Rolls[0];
                    break;
                case 2:
                    Charisma = Rolls[0];
                    Intelligence = Rolls[2];
                    Wisdom = Rolls[1];
                    break;
                case 3:
                    Charisma = Rolls[0];
                    Intelligence = Rolls[1];
                    Wisdom = Rolls[2];
                    break;
                default:
                    Charisma = Rolls[2];
                    Intelligence = Rolls[1];
                    Wisdom = Rolls[0];
                    break;
            }

            switch (Dice.Percentile(ref random))
            {
                case 1:
                case 2:
                case 3:
                case 4:
                case 5: Alignment = "Chaotic good"; break;
                case 6:
                case 7:
                case 8:
                case 9:
                case 10:
                case 11:
                case 12:
                case 13:
                case 14:
                case 15: Alignment = "Chaotic neutral"; break;
                case 16:
                case 17:
                case 18:
                case 19:
                case 20: Alignment = "chaotic evil"; break;
                case 21:
                case 22:
                case 23:
                case 24:
                case 25: Alignment = "Neutral evil"; break;
                case 26:
                case 27:
                case 28:
                case 29:
                case 30: Alignment = "lawful evil"; break;
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
                case 55: Alignment = "lawful good"; break;
                case 56:
                case 57:
                case 58:
                case 59:
                case 60: Alignment = "lawful neutral"; break;
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
                case 80: Alignment = "neutral good"; break;
                default: Alignment = "Neutral"; break;
            }
            
            return String.Format("INT {0}, WIS {1}, CHA {2}, {3}, Ego of {4}.  {5}.  {6}.", Intelligence, Wisdom, Charisma, Alignment, Ego, Speech, Abilities);
        }

        public static string Generate(int bonus, ref Random random)
        {
            int Intelligence; int Wisdom; int Charisma; string Speech; string Abilities; string Alignment; int Ego = bonus;
            int[] Rolls = new int[3];

            switch (Dice.Percentile(ref random))
            {

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
                    Rolls[0] = Dice.Roll(2, 6, 6, ref random);
                    Rolls[1] = Dice.Roll(2, 6, 6, ref random);
                    Rolls[2] = Dice.Roll(3, 6, 0, ref random);
                    Speech = "Empathy";
                    Abilities = PrimaryAbility(ref random, 2, ref Ego);
                    break;
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
                    Rolls[0] = Dice.Roll(2, 6, 7, ref random);
                    Rolls[1] = Dice.Roll(2, 6, 7, ref random);
                    Rolls[2] = Dice.Roll(3, 6, 0, ref random);
                    Speech = "Speech";
                    Abilities = PrimaryAbility(ref random, 2, ref Ego);
                    break;
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
                    Rolls[0] = Dice.Roll(2, 6, 8, ref random);
                    Rolls[1] = Dice.Roll(2, 6, 8, ref random);
                    Rolls[2] = Dice.Roll(3, 6, 0, ref random);
                    Speech = "Speech";
                    Abilities = PrimaryAbility(ref random, 3, ref Ego);
                    break;
                case 92:
                case 93:
                case 94:
                case 95:
                case 96:
                case 97:
                    Rolls[0] = Dice.Roll(2, 6, 9, ref random);
                    Rolls[1] = Dice.Roll(2, 6, 9, ref random);
                    Rolls[2] = Dice.Roll(3, 6, 0, ref random);
                    Speech = "Speech, read languages"; Ego += 1;
                    Abilities = PrimaryAbility(ref random, 3, ref Ego);
                    break;
                case 98:
                    Rolls[0] = Dice.Roll(2, 6, 10, ref random);
                    Rolls[1] = Dice.Roll(2, 6, 10, ref random);
                    Rolls[2] = Dice.Roll(3, 6, 0, ref random);
                    Speech = "Speech, telepathy, read languages"; Ego += 2;
                    Abilities = String.Format("{0} and {1}", PrimaryAbility(ref random, 3, ref Ego), ExtraordinaryAbility(ref random, 1, ref Ego));
                    break;
                case 99:
                    Rolls[0] = Dice.Roll(2, 6, 11, ref random);
                    Rolls[1] = Dice.Roll(2, 6, 11, ref random);
                    Rolls[2] = Dice.Roll(3, 6, 0, ref random);
                    Speech = "Speech, telepathy, read all languages, read magic"; Ego += 3;
                    Abilities = String.Format("{0} and {1}", PrimaryAbility(ref random, 3, ref Ego), ExtraordinaryAbility(ref random, 2, ref Ego));
                    break;
                case 100:
                    Rolls[0] = Dice.Roll(2, 6, 12, ref random);
                    Rolls[1] = Dice.Roll(2, 6, 12, ref random);
                    Rolls[2] = Dice.Roll(3, 6, 0, ref random);
                    Speech = "Speech, telepathy, read all languages, read magic"; Ego += 3;
                    Abilities = String.Format("{0} and {1}", PrimaryAbility(ref random, 4, ref Ego), ExtraordinaryAbility(ref random, 2, ref Ego));
                    break;
                default:
                    Rolls[0] = Dice.Roll(2, 6, 5, ref random);
                    Rolls[1] = Dice.Roll(2, 6, 5, ref random);
                    Rolls[2] = Dice.Roll(3, 6, 0, ref random);
                    Speech = "Semiempathy";
                    Abilities = PrimaryAbility(ref random, 1, ref Ego);
                    break;
            }

            foreach (int roll in Rolls)
                Ego += (roll - 10) / 2;

            Array.Sort(Rolls);
            switch (Dice.d4(ref random))
            {
                case 1:
                    Charisma = Rolls[1];
                    Intelligence = Rolls[2];
                    Wisdom = Rolls[0];
                    break;
                case 2:
                    Charisma = Rolls[0];
                    Intelligence = Rolls[2];
                    Wisdom = Rolls[1];
                    break;
                case 3:
                    Charisma = Rolls[0];
                    Intelligence = Rolls[1];
                    Wisdom = Rolls[2];
                    break;
                default:
                    Charisma = Rolls[2];
                    Intelligence = Rolls[1];
                    Wisdom = Rolls[0];
                    break;
            }

            switch (Dice.Percentile(ref random))
            {
                case 1:
                case 2:
                case 3:
                case 4:
                case 5: Alignment = "Chaotic good"; break;
                case 6:
                case 7:
                case 8:
                case 9:
                case 10:
                case 11:
                case 12:
                case 13:
                case 14:
                case 15: Alignment = "Chaotic neutral"; break;
                case 16:
                case 17:
                case 18:
                case 19:
                case 20: Alignment = "chaotic evil"; break;
                case 21:
                case 22:
                case 23:
                case 24:
                case 25: Alignment = "Neutral evil"; break;
                case 26:
                case 27:
                case 28:
                case 29:
                case 30: Alignment = "lawful evil"; break;
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
                case 55: Alignment = "lawful good"; break;
                case 56:
                case 57:
                case 58:
                case 59:
                case 60: Alignment = "lawful neutral"; break;
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
                case 80: Alignment = "neutral good"; break;
                default: Alignment = "Neutral"; break;
            }

            return String.Format("INT {0}, WIS {1}, CHA {2}, {3}, Ego of {4}.  {5}.  {6}.", Intelligence, Wisdom, Charisma, Alignment, Ego, Speech, Abilities);
        }

        private static string PrimaryAbility(ref Random random, int Quantity, ref int Ego)
        {
            string output = "";

            while (Quantity > 0)
            {
                switch (Dice.Percentile(ref random))
                {
                    case 1:
                    case 2:
                    case 3:
                    case 4:
                        output += "Item can Intuit Direction (10 ranks), ";
                        Ego++;
                        break;
                    case 5:
                    case 6:
                    case 7:
                    case 8:
                        output += "Item can Sense Motive (10 ranks), ";
                        Ego++;
                        break;
                    case 9:
                    case 10:
                    case 11:
                    case 12:
                        output += "Wielder has free use of Combat Reflexes, ";
                        Ego++;
                        break;
                    case 13:
                    case 14:
                    case 15:
                    case 16:
                        output += "Wielder has free use of Blind-Fight, ";
                        Ego++;
                        break;
                    case 17:
                    case 18:
                    case 19:
                    case 20:
                        output += "Wielder has free use of Improved Initiative, ";
                        Ego++;
                        break;
                    case 21:
                    case 22:
                    case 23:
                    case 24:
                        output += "Wielder has free use of Mobility, ";
                        Ego++;
                        break;
                    case 25:
                    case 26:
                    case 27:
                    case 28:
                        output += "Wielder has free use of Sunder, ";
                        Ego++;
                        break;
                    case 29:
                    case 30:
                    case 31:
                    case 32:
                        output += "Wielder has free use of Expertise, ";
                        Ego++;
                        break;
                    case 33:
                    case 34:
                    case 35:
                    case 36:
                    case 37:
                    case 38:
                    case 39:
                        output += "Detect opposing alignment at will, ";
                        Ego++;
                        break;
                    case 40:
                    case 41:
                    case 42:
                        output += "Find traps at will, ";
                        Ego++;
                        break;
                    case 43:
                    case 44:
                    case 45:
                    case 46:
                    case 47:
                        output += "Detect secret doors at will, ";
                        Ego++;
                        break;
                    case 48:
                    case 49:
                    case 50:
                    case 51:
                    case 52:
                    case 53:
                    case 54:
                        output += "Detect magic at will, ";
                        Ego++;
                        break;
                    case 55:
                    case 56:
                    case 57:
                        output += "Wielder has free use of Uncanny Dodge (Barbarian 5), ";
                        Ego++;
                        break;
                    case 58:
                    case 59:
                    case 60:
                        output += "Wielder has free sue of evasion, ";
                        Ego++;
                        break;
                    case 61:
                    case 62:
                    case 63:
                    case 64:
                    case 65:
                        output += "Wielder can see invisible at will, ";
                        Ego++;
                        break;
                    case 66:
                    case 67:
                    case 68:
                    case 69:
                    case 70:
                        output += "Cure light wounds (1d8+5) on wielder 1/day, ";
                        Ego++;
                        break;
                    case 71:
                    case 72:
                    case 73:
                    case 74:
                    case 75:
                        output += "feather fall on wielder 1/day, ";
                        Ego++;
                        break;
                    case 76:
                        output += "locate object in 120-ft radius, ";
                        Ego++;
                        break;
                    case 77:
                        output += "Wielder does not need sleep, ";
                        Ego++;
                        break;
                    case 78:
                        output += "Wielder does not need to breathe, ";
                        Ego++;
                        break;
                    case 79:
                        output += "Jump (20 min duration) on wielder 1/day, ";
                        Ego++;
                        break;
                    case 80:
                        output += "Spider climb (20 min duration) on wielder 1/day, ";
                        Ego++;
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
                    case 90: Quantity += 2; break;
                    default: output += ExtraordinaryAbility(ref random, 1, ref Ego); break;
                }
                
                Quantity--;
            }

            return output;
        }

        private static string ExtraordinaryAbility(ref Random random, int Quantity, ref int Ego)
        {
            string output = "";

            while (Quantity > 0)
            {
                switch (Dice.Percentile(ref random))
                {
                    case 1:
                    case 2:
                    case 3:
                    case 4:
                    case 5:
                        output += "charm person (DC 11) on contact 3/day, ";
                        Ego += 2;
                        break;
                    case 6:
                    case 7:
                    case 8:
                    case 9:
                    case 10:
                        output += "clairvoyance/clairaudience (100-ft range, 1 minute) 3/day, ";
                        Ego += 2;
                        break;
                    case 11:
                    case 12:
                    case 13:
                    case 14:
                    case 15:
                        output += "magic missile (200-ft range, 3 missiles) 3/day, ";
                        Ego += 2;
                        break;
                    case 16:
                    case 17:
                    case 18:
                    case 19:
                    case 20:
                        output += "Shield on wielder 3/day, ";
                        Ego += 2;
                        break;
                    case 21:
                    case 22:
                    case 23:
                    case 24:
                    case 25:
                        output += "Detect thoughts (100-ft range, 1 minute) 3/day, ";
                        Ego += 2;
                        break;
                    case 26:
                    case 27:
                    case 28:
                    case 29:
                    case 30:
                        output += "Levitation (wielder only, 10 minutes) 3/day, ";
                        Ego += 2;
                        break;
                    case 31:
                    case 32:
                    case 33:
                    case 34:
                    case 35:
                        output += "Invisibility (wielder only, 30 minutes) 3/day, ";
                        Ego += 2;
                        break;
                    case 36:
                    case 37:
                    case 38:
                    case 39:
                    case 40:
                        output += "Fly (30 minutes) 2/day, ";
                        Ego += 2;
                        break;
                    case 41:
                    case 42:
                    case 43:
                    case 44:
                    case 45:
                        output += "Lightning bolt (8d6, 200-ft range, DC 13) 1/day, ";
                        Ego += 2;
                        break;
                    case 46:
                    case 47:
                    case 48:
                    case 49:
                    case 50:
                        output += "Summon monster III 1/day, ";
                        Ego += 2;
                        break;
                    case 51:
                    case 52:
                    case 53:
                    case 54:
                    case 55:
                        output += "Telepathy (100-ft range) 2/day, ";
                        Ego += 2;
                        break;
                    case 56:
                    case 57:
                    case 58:
                    case 59:
                    case 60:
                        output += "Cat's grace (wielder only) 1/day, ";
                        Ego += 2;
                        break;
                    case 61:
                    case 62:
                    case 63:
                    case 64:
                    case 65:
                        output += "bull's strength (wielder only) 1/day, ";
                        Ego += 2;
                        break;
                    case 66:
                    case 67:
                    case 68:
                    case 69:
                    case 70:
                        output += "haste (wielder only, 10 rounds) 1/day, ";
                        Ego += 2;
                        break;
                    case 71:
                    case 72:
                    case 73:
                        output += "Telekinesis (250 lb, 1 minute) 2/day, ";
                        Ego += 2;
                        break;
                    case 74:
                    case 75:
                    case 76:
                        output += "Heal 1/day, ";
                        Ego += 2;
                        break;
                    case 77:
                        output += "Teleport (600 lb) 1/day, ";
                        Ego += 2;
                        break;
                    case 78:
                        output += "Globe of invulnerability 1/day, ";
                        Ego += 2;
                        break;
                    case 79:
                        output += "Stoneskin (wielder only, 10 minutes) 2/day, ";
                        Ego += 2;
                        break;
                    case 80:
                        output += "Feeblemind by touch 2/day, ";
                        Ego += 2;
                        break;
                    case 81:
                        output += "True Seeing at will, ";
                        Ego += 2;
                        break;
                    case 82:
                        output += "Wall of force 1/day, ";
                        Ego += 2;
                        break;
                    case 83:
                        output += "Summon monster VI 1/day, ";
                        Ego += 2;
                        break;
                    case 84:
                        output += "Finger of Death (100 ft, DC 17) 1/day, ";
                        Ego += 2;
                        break;
                    case 85:
                        output += "Passwall at will, ";
                        Ego += 2;
                        break;
                    case 86:
                    case 87:
                    case 88:
                    case 89:
                    case 90: Quantity += 2; break;
                    default:
                        Quantity++;
                        Ego += 4;
                        output += String.Format("Purpose to {0}, ", Purpose(ref random));
                        break;
                }

                Quantity--;
            }

            return output;
        }

        private static string Purpose(ref Random random)
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
                case 30: return String.Format("defeat/slay arcane spellcasters (including spellcasting monsters and those that use spell-like abilities), with purpose power {0}", PurposePower(ref random));
                case 31:
                case 32:
                case 33:
                case 34:
                case 35:
                case 36:
                case 37:
                case 38:
                case 39:
                case 40: return String.Format("defeat/slay divine spellcasters (including divine entities and servitors), with purpose power {0}", PurposePower(ref random));
                case 41:
                case 42:
                case 43:
                case 44:
                case 45:
                case 46:
                case 47:
                case 48:
                case 49:
                case 50: return String.Format("defeat/slay nonspellcasters, with purpose power {0}", PurposePower(ref random));
                case 51:
                case 52:
                case 53:
                case 54:
                case 55: return String.Format("defeat/slay {0}, with purpose power {1}", Character.CreatureType(ref random), PurposePower(ref random));
                case 56:
                case 57:
                case 58:
                case 59:
                case 60: return String.Format("defeat/slay {0}, with purpose power {1}", Character.HumanoidSubtype(ref random), PurposePower(ref random));
                case 61:
                case 62:
                case 63:
                case 64:
                case 65:
                case 66:
                case 67:
                case 68:
                case 69:
                case 70: return String.Format("defend {0}, with purpose power {1}", Character.CreatureType(ref random), PurposePower(ref random));
                case 71:
                case 72:
                case 73:
                case 74:
                case 75:
                case 76:
                case 77:
                case 78:
                case 79:
                case 80: return String.Format("defeat/slay the servants of a specific deity, with purpose power {0}", PurposePower(ref random));
                case 81:
                case 82:
                case 83:
                case 84:
                case 85:
                case 86:
                case 87:
                case 88:
                case 89:
                case 90: return String.Format("defend the servants and interests of a specific deity, with purpose power {0}", PurposePower(ref random));
                case 91:
                case 92:
                case 93:
                case 94:
                case 95: return String.Format("defeat/slay all (other than the item and the wielder), with purpose power {0}", PurposePower(ref random));
                case 96:
                case 97:
                case 98:
                case 99:
                case 100: return String.Format("character's choice, with purpose power {0}", PurposePower(ref random));
                default: return String.Format("defeat/slay diametrically opposed alignment, with purpose power {0}", PurposePower(ref random));
            }
        }

        private static string PurposePower(ref Random random)
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
                case 10: return "Blindness (DC 12) for 2d6 rounds";
                case 11:
                case 12:
                case 13:
                case 14:
                case 15:
                case 16:
                case 17:
                case 18:
                case 19:
                case 20: return "Confusion (DC 14) for 2d6 rounds";
                case 21:
                case 22:
                case 23:
                case 24:
                case 25: return "Fear (DC 14) for 1d4 rounds";
                case 56:
                case 57:
                case 58:
                case 59:
                case 60: 
                case 61:
                case 62:
                case 63:
                case 64:
                case 65: return "Slay living (DC 15)";
                case 66:
                case 67:
                case 68:
                case 69:
                case 70: 
                case 71:
                case 72:
                case 73:
                case 74:
                case 75: return "Disintegrate (DC 16)";
                case 76:
                case 77:
                case 78:
                case 79:
                case 80: return "True Resurrection on wielder, 1 time only";
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
                case 100: return "+2 luck bonus on all saving throws, +2 deflection AC bonus, spell resistance 15";
                default: return "Hold Monster (DC 14) for 1d4 rounds";
            }
        }
    }
}
