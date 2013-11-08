using System;
using System.Collections.Generic;
using System.Text;

namespace Dungeon_Maker
{
    class Trap
    {
        public static string Generate(int Level, ref Random random)
        {
            
            
            if (Level < 4 || Dice.Percentile(ref random) <= 50)
                return LowLevelTrap(Level, ref random);
            return HighLevelTrap(Level, ref random);
        }
        
        private static string LowLevelTrap(int DungeonLevel, ref Random random)
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
                    int CR = 1;
                    return String.Format(" Arrow trap (CR {0}, DC {1}), BA: +10, 1d6/x3.", CR, 10 + CR + DungeonLevel);
                case 11:
                case 12:
                case 13:
                case 14:
                case 15:
                    CR = 2;
                    return String.Format(" Spear trap (CR {0}, DC {1}), BA: +12, 1d8/x3.", CR, 10 + CR + DungeonLevel);
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
                    CR = 1;
                    return String.Format(" Pit trap, 20' (CR {0}, DC {1}), Ref avoids.", CR, 10 + CR + DungeonLevel);
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
                    CR = 2;
                    return String.Format(" Spiked pit trap, 20' (CR {0}, DC {1}), Ref avoids.  Falling damage, BA: +10, 1d4 spikes for 1d4+4 each hit.", CR, 10 + CR + DungeonLevel);
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
                    CR = 2;
                    return String.Format(" Pit trap, 40' (CR {0}, DC {1}), Ref avoids.", CR, 10 + CR + DungeonLevel);
                case 46:
                case 47:
                case 48:
                case 49:
                case 50:
                    CR = 3;
                    return String.Format(" Spiked pit trap, 40' (CR {0}, DC {1}), Ref avoids.  Falling damage, BA: +10, 1d4 spikes for 1d4+4 each hit.", CR, 10 + CR + DungeonLevel);
                case 51:
                case 52:
                case 53:
                case 54:
                case 55:
                    CR = 3;
                    return String.Format(" Pit trap, 60' (CR {0}, DC {1}), Ref avoids.", CR, 10 + CR + DungeonLevel);
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
                    CR = 2;
                    return String.Format(" Poison needle trap (CR {0}, DC {1}, Search 2 more), BA +8, 1 point of damage plus {2}", CR, 10 + CR + DungeonLevel, InjuryPoison(ref random));
                case 66:
                case 67:
                case 68:
                case 69:
                case 70:
                    CR = 1;
                    return String.Format(" Hail of needle trap (CR {0}, DC {1}, Search 2 more), BA +20, 2d4", CR, 10 + CR + DungeonLevel);
                case 71:
                case 72:
                case 73:
                case 74:
                case 75:
                    CR = 1;
                    return String.Format(" Scything blade trap (CR {0}, DC {1}, Search 1 more), BA +8, 1d8/x3", CR, 10 + CR + DungeonLevel);
                case 76:
                case 77:
                case 78:
                case 79:
                case 80:
                    CR = 1;
                    return String.Format(" Large net trap (CR {0}, DC {1}), BA +5, ref DC 14 avoid, grapple Str 18", CR, 10 + CR + DungeonLevel);
                case 81:
                case 82:
                case 83:
                case 84:
                case 85:
                    CR = 2;
                    return String.Format(" Portcullis trap (CR {0}, DC {1}, Search 2 more), BA +10, 3d6/x3, blocks passageway", CR, 10 + CR + DungeonLevel);
                case 86:
                case 87:
                case 88:
                case 89:
                case 90:
                    CR = 2;
                    return String.Format(" Flame jet trap (CR {0}, DC {1}, Disable Device 1 more), 50' stream of fire, 3d6, ref DC 13 avoid", CR, 10 + CR + DungeonLevel);
                case 91:
                case 92:
                case 93:
                case 94:
                case 95:
                    CR = 3;
                    return String.Format(" Lightning blast trap (CR {0}, DC {1}, Search 1 more), 50' stream of fire, 3d6, ref DC 13 avoid", CR, 10 + CR + DungeonLevel);
                case 96:
                case 97:
                case 98:
                case 99:
                case 100:
                    CR = 3;
                    return String.Format(" Illusion over a spiked pit, 20' (CR {0}, DC {1}), falling damage, BA +10, 1d4 spikes for 1d4+2 each hit.  Ref DC 15 avoid", CR, 10 + CR + DungeonLevel);
                default: return "[Error: Low-Level Trap out of range.  Trap.152]";
            }
        }

        private static string HighLevelTrap(int DungeonLevel, ref Random random)
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
                    int CR = 4;
                    return String.Format(" Spiked pit trap, 60' (CR {0}, DC {1}), Ref avoids.  Falling damage, BA: +10, 1d4 spikes for 1d4+4 each hit.", CR, 10 + CR + DungeonLevel);
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
                    CR = 4;
                    return String.Format(" Pit trap, 80' (CR {0}, DC {1}), Ref avoids.", CR, 10 + CR + DungeonLevel);
                case 21:
                case 22:
                case 23:
                case 24:
                case 25:
                    CR = 5;
                    return String.Format(" Spiked pit trap, 80' (CR {0}, DC {1}), Ref avoids.  Falling damage, BA: +10, 1d4 spikes for 1d4+4 each hit.", CR, 10 + CR + DungeonLevel);
                case 26:
                case 27:
                case 28:
                case 29:
                case 30:
                    CR = 5;
                    return String.Format(" Pit trap, 100' (CR {0}, DC {1}), Ref avoids.", CR, 10 + CR + DungeonLevel);
                case 31:
                case 32:
                case 33:
                case 34:
                case 35:
                    CR = 6;
                    return String.Format(" Spiked pit trap, 100' (CR {0}, DC {1}), Ref avoids.  Falling damage, BA: +10, 1d4 spikes for 1d4+4 each hit.", CR, 10 + CR + DungeonLevel);
                case 36:
                case 37:
                case 38:
                    CR = 10;
                    return String.Format(" Crushing wall trap, (CR {0}, DC {1}, Disable Device 5 more), 20d6", CR, 10 + CR + DungeonLevel);
                case 39:
                case 40:
                case 41:
                case 42:
                case 43:
                    CR = 5;
                    return String.Format(" Falling block trap, (CR {0}, DC {1}, Disable Device 5 more), BA +15, 6d6", CR, 10 + CR + DungeonLevel);
                case 44:
                case 45:
                    CR = 10;
                    return String.Format(" Poison gas trap (CR {0}, DC {1}, Disable Device 4 more), " + InhalationPoison(ref random), CR, 10 + CR + DungeonLevel);
                case 46:
                case 47:
                case 48:
                case 49:
                case 50:
                    CR = 5;
                    return String.Format(" Flooding room trap (CR {0}, DC {1}, Disable Device 5 more), room floods in 4 rounds", CR, 10 + CR + DungeonLevel);
                case 51:
                case 52:
                case 53:
                case 54:
                case 55:
                    CR = 4;
                    return String.Format(" Globe of cold trap (CR {0}, DC {1}, Search 2 more), 20-ft radius, 5d6, ref DC 15 avoids", CR, 10 + CR + DungeonLevel);
                case 56:
                case 57:
                case 58:
                case 59:
                case 60:
                    CR = 4;
                    return String.Format(" Electrified floor trap (CR {0}, DC {1}), 3d10, ref DC 14 for half damage", CR, 10 + CR + DungeonLevel);
                case 61:
                case 62:
                case 63:
                case 64:
                case 65:
                    CR = 5;
                    return String.Format(" Air sucked out of room trap (CR {0}, DC {1}, Disable Device 2 more), deals suffocating damage (DMG, p. 88)", CR, 10 + CR + DungeonLevel);
                case 66:
                case 67:
                case 68:
                case 69:
                case 70:
                    CR = 6;
                    return String.Format(" Floor transforms into acid trap (CR {0}, DC {1}, Disable Device 2 more), 10d6, ref DC 16 negates", CR, 10 + CR + DungeonLevel);
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
                case 96:
                case 97:
                case 98:
                case 99:
                case 100: return SpellTrap(ref random);
                default: return "[Error: High-Level Trap out of range.  Trap.286]";
            }
        }

        private static string SpellTrap(ref Random random)
        {
            switch (Dice.Percentile(ref random))
            {
                case 1: return " an Acid Fog spell trap (DC 31), ref DC 19 avoid";
                case 2: return " an Alarm spell trap (DC 26), ref DC 12 avoid";
                case 3: return " an Animate Object spell trap (DC 31), ref DC 19 avoid";
                case 4: return " an Antimagic Field spell trap (DC 31), ref DC 19 avoid";
                case 5: return " a Clenched Fist spell trap (DC 33), ref DC 22 avoid";
                case 6: return " a Forceful Hand spell trap (DC 31), ref DC 19 avoid";
                case 7: return " a Grasping Hand spell trap (DC 32), ref DC 21 avoid";
                case 8: return " a Binding spell trap (DC 33), ref DC 22 avoid";
                case 9: return " a Blade Barrier spell trap (DC 31), ref DC 19 avoid";
                case 10: return " a Blindness/Deafness spell trap (DC 27), ref DC 13 avoid";
                case 11: return " a Circle of Death spell trap (DC 31), ref DC 19 avoid";
                case 12: return " a Color Spray spell trap (DC 26), ref DC 12 avoid";
                case 13: return " a Confusion spell trap (DC 29), ref DC 16 avoid";
                case 14: return " a Contagion spell trap (DC 28), ref DC 15 avoid";
                case 15: return " a Darkness spell trap (DC 27), ref DC 13 avoid";
                case 16: return " a Disintegration spell trap (DC 31), ref DC 19 avoid";
                case 17: return " a Dispel Good spell trap (DC 30), ref DC 18 avoid";
                case 18: return " a Dispel Magic spell trap (DC 28), ref DC 15 avoid";
                case 19: return " a Dominate Person spell trap (DC 30), ref DC 18 avoid";
                case 20: return " a Doom spell trap (DC 26), ref DC 12 avoid";
                case 21: return " an Energy Drain spell trap (DC 34), ref DC 24 avoid";
                case 22: return " an Enervation spell trap (DC 29), ref DC 16 avoid";
                case 23: return " an Enlarge spell trap (DC 26), ref DC 12 avoid";
                case 24: return " an Explosive Runes spell trap (DC 28), ref DC 15 avoid";
                case 25: return " an Eyebite spell trap (DC 31), ref DC 19 avoid";
                case 26: return " a False Vision spell trap (DC 30), ref DC 18 avoid";
                case 27: return " a Fear spell trap (DC 29), ref DC 16 avoid";
                case 28: return " a Feeblemind spell trap (DC 30), ref DC 18 avoid";
                case 29: return " a Fireball spell trap (DC 28), ref DC 15 avoid";
                case 30: return " a Fire Trap spell trap (DC 29), ref DC 16 avoid";
                case 31: return " a Flaming Sphere spell trap (DC 27), ref DC 13 avoid";
                case 32: return " a Flesh to Stone spell trap (DC 31), ref DC 19 avoid";
                case 33: return " a Forbiddance spell trap (DC 31), ref DC 19 avoid";
                case 34: return " a Forcecage spell trap (DC 32), ref DC 21 avoid";
                case 35: return " a Gate spell trap (DC 34), ref DC 24 avoid";
                case 36: return " a Geas/Quest spell trap (DC 31), ref DC 19 avoid";
                case 37: return " a Giant Vermin spell trap (DC 29), ref DC 16 avoid";
                case 38: return " a Glyph of warding spell trap (DC 28), ref DC 15 avoid";
                case 39: return " a Grease spell trap (DC 26), ref DC 12 avoid";
                case 40: return " a Harm spell trap (DC 31), ref DC 19 avoid";
                case 41: return " a Hold Monster spell trap (DC 30), ref DC 18 avoid";
                case 42: return " a Hold Person spell trap (DC 31), ref DC 19 avoid";
                case 43: return " an Imprisonment spell trap (DC 34), ref DC 24 avoid";
                case 44: return " an Inflict Critical Wounds spell trap (DC 31), ref DC 19 avoid";
                case 45: return " an Inflict Light Wounds spell trap (DC 26), ref DC 12 avoid";
                case 46: return " an Inflict Moderate Wounds spell trap (DC 27), ref DC 13 avoid";
                case 47: return " an Inflict Serious Wounds spell trap (DC 28), ref DC 15 avoid";
                case 48: return " an Invisibility spell trap (DC 27), ref DC 13 avoid";
                case 49: return " a Levitate spell trap (DC 27), ref DC 13 avoid";
                case 50: return " a Lightning Bolt spell trap (DC 28), ref DC 15 avoid";
                case 51: return " a Magic Jar spell trap (DC 30), ref DC 18 avoid";
                case 52: return " a Magic Missile spell trap (DC 26), ref DC 12 avoid";
                case 53: return " a Mass Suggestion spell trap (DC 31), ref DC 19 avoid";
                case 54: return " an Acid Arrow spell trap (DC 27), ref DC 13 avoid";
                case 55: return " a Mind Fog spell trap (DC 30), ref DC 18 avoid";
                case 56: return " a Mage's Disjunction spell trap (DC 34), ref DC 24 avoid";
                case 57: return " a Nightmare spell trap (DC 30), ref DC 18 avoid";
                case 58: return " a Telekinetic Sphere spell trap (DC 33), ref DC 22 avoid";
                case 59: return " a Permanency spell trap (DC 30), ref DC 18 avoid";
                case 60: return " a Permanent Image spell trap (DC 31), ref DC 19 avoid";
                case 61: return " a Plane Shift spell trap (DC 32), ref DC 21 avoid";
                case 62: return " a Polymorph Any Object spell trap (DC 33), ref DC 22 avoid";
                case 63: return " a Power Word, Kill spell trap (DC 34), ref DC 24 avoid";
                case 64: return " a Prismatic Spray spell trap (DC 32), ref DC 21 avoid";
                case 65: return " a Programmed Image spell trap (DC 31), ref DC 19 avoid";
                case 66: return " a Reduce spell trap (DC 29), ref DC 16 avoid";
                case 67: return " a Repulsion spell trap (DC 32), ref DC 21 avoid";
                case 68: return " a Reverse Gravity spell trap (DC 33), ref DC 22 avoid";
                case 69: return " a Screen spell trap (DC 33), ref DC 22 avoid";
                case 70: return " a Sepia Snake Sigil spell trap (DC 28), ref DC 15 avoid";
                case 71: return " a Silence spell trap (DC 27), ref DC 13 avoid";
                case 72: return " a Slay Living spell trap (DC 30), ref DC 18 avoid";
                case 73: return " a Slow spell trap (DC 28), ref DC 15 avoid";
                case 74: return " a Spell Turning spell trap (DC 32), ref DC 21 avoid";
                case 75: return " a Suggestion spell trap (DC 28), ref DC 15 avoid";
                case 76: return " a Summon Monster I spell trap (DC 26), ref DC 12 avoid";
                case 77: return " a Shatter spell trap (DC 27), ref DC 13 avoid";
                case 78: return " a Summon Monster II spell trap (DC 27), ref DC 13 avoid";
                case 79: return " a Summon Monster III spell trap (DC 28), ref DC 15 avoid";
                case 80: return " a Summon Monster IV spell trap (DC 29), ref DC 16 avoid";
                case 81: return " a Summon Monster V spell trap (DC 30), ref DC 18 avoid";
                case 82: return " a Summon Monster VI spell trap (DC 31), ref DC 19 avoid";
                case 83: return " a Summon Monster VII spell trap (DC 32), ref DC 21 avoid";
                case 84: return " a Summon Monster VIII spell trap (DC 33), ref DC 22 avoid";
                case 86: return " a Word of Chaos spell trap (DC 32), ref DC 21 avoid";
                case 87: return SymbolSpellTrap(ref random);
                case 88: return " a Hideous Laughter spell trap (DC 27), ref DC 13 avoid";
                case 89: return " a Telekinesis spell trap (DC 30), ref DC 18 avoid";
                case 90: return " a Teleport spell trap (DC 30), ref DC 18 avoid";
                case 91: return " a Temporal Stasis spell trap (DC 33), ref DC 22 avoid";
                case 92: return " a Trap the Soul spell trap (DC 33), ref DC 22 avoid";
                case 93: return " a Teleport Object spell trap (DC 32), ref DC 21 avoid";
                case 94: return " a Wall of Fire spell trap (DC 29), ref DC 16 avoid";
                case 95: return " a Wall of Force spell trap (DC 30), ref DC 18 avoid";
                case 96: return " a Wall of Iron spell trap (DC 31), ref DC 19 avoid";
                case 97: return " a Wall of Stone spell trap (DC 30), ref DC 18 avoid";
                case 98: return " a Web spell trap (DC 27), ref DC 13 avoid";
                case 99: return " a Weird spell trap (DC 34), ref DC 24 avoid";
                case 100: return " a Summon Monster IX spell trap (DC 34), ref DC 24 avoid";
                default: return "[Error: Spell Trap out of range.  Trap.393]";
            }
        }

        private static string SymbolSpellTrap(ref Random random)
        {
            switch (Dice.d8(ref random))
            {
                case 1: return " a Symbol of Death spell trap (DC 33), ref DC 22 avoid";
                case 2: return " a Symbol of Fear spell trap (DC 31), ref DC 19 avoid";
                case 3: return " a Symbol of Insanity spell trap (DC 33), ref DC 22 avoid";
                case 4: return " a Symbol of Pain spell trap (DC 30), ref DC 18 avoid";
                case 5: return " a Symbol of Persuasion spell trap (DC 31), ref DC 19 avoid";
                case 6: return " a Symbol of Sleep spell trap (DC 30), ref DC 18 avoid";
                case 7: return " a Symbol of Stunning spell trap (DC 32), ref DC 21 avoid";
                case 8: return " a Symbol of Weakness spell trap (DC 32), ref DC 21 avoid";
                default: return "[Error: Symbol Spell Trap out of range.  Trap.409]";
            } 
        }

        public static string Poison(ref Random random)
        {
            switch (Dice.Roll(1, 28, 0, ref random))
            {
                case 1:
                case 2:
                case 3:
                case 4:
                case 5:
                case 6:
                case 7: return ContactPoison(ref random);
                case 8:
                case 9:
                case 10:
                case 11:
                case 12:
                case 13: return IngestionPoison(ref random);
                case 14:
                case 15:
                case 16: return InhalationPoison(ref random);
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
                case 28: return InjuryPoison(ref random);
                default: return "[Error: Poison out of range.  Trap.445]";
                    
            }
        }

        public static string ContactPoison(ref Random random)
        {
            switch (Dice.Roll(1, 7, 0, ref random))
            {
                case 1: return "Malyss root paste poison (Contact DC 16)";
                case 2: return "Nitharit poison (Contact DC 13)";
                case 3: return "Dragin bile poison (Contact DC 26)";
                case 4: return "Sassone leaf residue poison (Contact DC 16)";
                case 5: return "Terinav root poison (Contact DC 16)";
                case 6: return "Carrion crawler brain juice poison (Contact DC 13)";
                case 7: return "Black lotus extract poison (Contact DC 20)";
                default: return "[Error: Contact Poison out of range.  Trap.461]";
            }
        }

        public static string InjuryPoison(ref Random random)
        {
            switch (Dice.d12(ref random))
            {
                case 1: return "Greenblood oil poison (Injury DC 13)";
                case 2: return "Medium-size spider venom (Injury DC 14)";
                case 3: return "Bloodroot poison (Injury DC 12)";
                case 4: return "Purple worm poison (Injury DC 24)";
                case 5: return "Large scorpion venom (Injury DC 18)";
                case 6: return "Wyvern poison (Injury DC 17)";
                case 7: return "Blue whinnis poison (Injury DC 14)";
                case 8: return "Giant wasp poison (Injury DC 18)";
                case 9: return "Shadow essence poison (Injury DC 17)";
                case 10: return "Black adder venom (Injury DC 12)";
                case 11: return "Small centipede poison (Injury DC 11)";
                case 12: return "Deathblade poison (Injury DC 20)";
                default: return "[Error: Injury Poison out of range.  Trap.481]";
            }
        }

        public static string InhalationPoison(ref Random random)
        {
            switch (Dice.Roll(1, 3, 0, ref random))
           {
               case 1: return "Ungol dust poison (Inhalation DC 15)";
               case 2: return "Burnt othur fumes poison (Inhalation DC 18)";
               case 3: return "Insanity mist poison (Inhalation DC 15)";
               default: return "[Error: Inhalation Poison out of range.  Trap.492]";
           }
        }

        public static string IngestionPoison(ref Random random)
        {
            switch (Dice.d6(ref random))
            {
                case 1: return "Oil of taggit poison (Ingestion DC 15)";
                case 2: return "Id moss poison (Ingestion DC 14)";
                case 3: return "Striped toadstool poison (Ingestion DC 11)";
                case 4: return "Arsenic poison (Ingestion DC 13)";
                case 5: return "Lick dust poison (Ingestion DC 17)";
                case 6: return "Dark reaver powder poison (Ingestion DC 18)";
                default: return "[Error: Ingestion Poison out of range.  Trap.506]";
            }
        }
    }
}
