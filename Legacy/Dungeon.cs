using System;
using System.Collections.Generic;
using System.Text;

namespace Dungeon_Maker
{
    class Dungeon
    {        
        public static string GenerateFromHall(int Level, ref Random random)
        {
            switch (Dice.d20(ref random))
            {
                case 1:
                case 2: return "Hall continues 60'.";
                case 3: 
                case 4:
                case 5: return Door(Level, ref random);
                case 6: 
                case 7:
                case 8:
                case 9:
                case 10: return String.Format("{0}\n\nHalls continue 30'.", SidePassage(ref random));
                case 11:
                case 12:
                case 13: return String.Format("{0}\n\nHall continues 30'.", Turn(ref random));
                case 14:
                case 15:
                case 16: return Room.GenerateChamber(Level, ref random);
                case 17: return Stairs(Level, ref random);
                case 18: return "Dead end.  Check for secret doors along already mapped walls.";
                case 19: return String.Format("{0}\n\nHall continues 30'.", Trap.Generate(Level, ref random));
                case 20: return String.Format("{1}\n\n{0}", Encounter.Generate(Level, ref random), GenerateFromHall(Level, ref random));
                default: return "[Error: Generate from Hall out of Range.  Dungeon.33]";
            }
        }

        public static string GenerateFromDoor(int Level, ref Random random)
        {
            switch (Dice.d20(ref random))
            {
                case 1:
                case 2:
                case 3:
                case 4: return String.Format("Parallel passage 30' in each direction, {0}", PassageWidth(ref random));
                case 5:
                case 6:
                case 7:
                case 8: return String.Format("Passage straight ahead, {0}", PassageWidth(ref random));
                case 9: return String.Format("Passage 45 degrees left/right, {0}", PassageWidth(ref random));
                case 10: return String.Format("Passage 45 degrees right/left, {0}", PassageWidth(ref random));
                case 11:
                case 12: 
                case 13:
                case 14:
                case 15:
                case 16:
                case 17:
                case 18: return Room.GenerateRoom(Level, ref random);
                case 19:
                case 20: return Room.GenerateChamber(Level, ref random);
                default: return "{Error: Generate from Door out of range.  Dungeon.61]";
            }
        }

        private static string Stairs(int Level, ref Random random)
        {
            switch (Dice.d20(ref random))
            {
                case 1:
                case 2:
                case 3:
                case 4:
                case 5:
                    string output = String.Format("Stairs down one level (to level {0}).", Level + 1);
                    if (Dice.d20(ref random) <= 1)
                        return String.Format("{0}  Dead end at the bottom.", output);
                    return output;
                case 6:
                    output = String.Format("Stairs down two levels (to level {0}).", Level + 2);
                    if (Dice.d20(ref random) <= 2)
                        return String.Format("{0}  Dead end at the bottom.", output);
                    return output;
                case 7:
                    output = String.Format("Stairs down three levels (to level {0}).", Level + 3);
                    if (Dice.d20(ref random) <= 3)
                        return String.Format("{0}  Dead end at the bottom.", output);
                    return output;
                case 8:
                    if (Level > 1)
                        return String.Format("Stairs up one level (to level {0}).", Level - 1);
                    return "Dead end.  Check for secret doors along already mapped walls.";
                case 9:
                    if (Level > 1)
                    {
                        output = String.Format("Stairs up one level (to level {0}) ending in a dead end.", Level - 1);
                        if (Dice.d6(ref random) <= 1)
                            return String.Format("{1}  Chute goes down two levels (to level {0}).", Level + 1, output);
                        return output;
                    }
                    return "Dead end.  Check for secret doors along already mapped walls.";
                case 10:
                    output = String.Format("Stairs down one level (to level {0}) ending in a dead end.", Level + 1);
                    if (Dice.d6(ref random) <= 1)
                        return String.Format("{0}  Chute goes down one level (to level {1}).", output, Level + 2);
                    return output;
                case 11:
                    if (Level > 1)
                        return String.Format("Chimney up one level (to level {0}), passage continues.", Level - 1);
                    return "Dead end.  Check for secret doors along already mapped walls.";
                case 12:
                    if (Level > 2)
                        return String.Format("Chimney up two levels (to level {0}), passage continues.", Level - 2);
                    return "Dead end.  Check for secret doors along already mapped walls.";
                case 13: return String.Format("Chimney down two levels (to level {0}), passage continues.", Level + 2);
                case 14:
                case 15:
                case 16: return String.Format("Trap door down one level (to level {0}), passage continues.", Level + 1);
                case 17: return String.Format("Trap door down two levels (to level {0}), passage continues.", Level + 2);
                case 18:
                case 19:
                case 20:
                    if (Level > 1)
                        return String.Format("Stairs up one level (to level {0}), then down two (to level {1}).\n\nAt the end is {2}", Level - 1, Level + 1, Room.GenerateChamber(Level + 1, ref random));
                    return "Dead end.  Check for secret doors along already mapped walls.";
                default: return "[Error: Stairs out of range.  Dungeon.109]";
            }
        }

        private static string Turn(ref Random random)
        {
            switch (Dice.d20(ref random))
            {
                case 1:
                case 2:
                case 3:
                case 4:
                case 5:
                case 6:
                case 7:
                case 8: return String.Format("Turn left 90 degrees, {0}", PassageWidth(ref random));
                case 9: return String.Format("Turn left 45 degrees ahead, {0}", PassageWidth(ref random));
                case 10: return String.Format("Turn left 45 degrees behind, {0}", PassageWidth(ref random));
                case 11: 
                case 12:
                case 13:
                case 14:
                case 15:
                case 16:
                case 17:
                case 18: return String.Format("Turn right 90 degrees, {0}", PassageWidth(ref random));
                case 19: return String.Format("Turn right 45 degrees ahead, {0}", PassageWidth(ref random));
                case 20: return String.Format("Turn right 45 degrees behind, {0}", PassageWidth(ref random));
                default: return "[Error: Turn out of range.  Dungeon.137]";
            }
        }

        private static string SidePassage(ref Random random)
        {
            switch (Dice.d20(ref random))
            {
                case 1:
                case 2: return String.Format("Side passage left 90 degrees, {0}", PassageWidth(ref random));
                case 3:
                case 4: return String.Format("Side passage right 90 degrees, {0}", PassageWidth(ref random));
                case 5:
                case 9: return String.Format("Side passage left 45 degrees ahead, {0}", PassageWidth(ref random));
                case 6:
                case 10: return String.Format("Side passage right 45 degrees ahead, {0}", PassageWidth(ref random));
                case 7: return String.Format("Side passage left 45 degrees behind, {0}", PassageWidth(ref random));
                case 8: return String.Format("Side passage right 45 degrees behind, {0}", PassageWidth(ref random));
                case 11:
                case 12:
                case 13: return String.Format("Passage T's.  Left is {0}, right is {1}", PassageWidth(ref random), PassageWidth(ref random));
                case 14:
                case 15: return String.Format("Passage Y's.  Left is {0}, right is {1}", PassageWidth(ref random), PassageWidth(ref random));
                case 16:
                case 17:
                case 18:
                case 19: return String.Format("Four-way intersection.  Left is {0}, ahead is {1}, right is {2}", PassageWidth(ref random), PassageWidth(ref random), PassageWidth(ref random));
                case 20: return String.Format("Passage X's.  Close left is {0}, far left is {1}, far right is {2}, and near right is {3}", PassageWidth(ref random), PassageWidth(ref random), PassageWidth(ref random), PassageWidth(ref random));
                default: return "[Error: Side passage out of range.  Dungeon.165]";
            }
        }

        private static string Door(int Level, ref Random random)
        {
            string output = "";
            do
            {
                switch (Dice.d20(ref random))
                {
                    case 1:
                    case 2:
                    case 3:
                    case 4:
                    case 5:
                    case 6:
                        if (!output.Contains(" on left\n"))
                            output += DoorType(Level, ref random) + " on left\n";
                        break;
                    case 7:
                    case 8:
                    case 9:
                    case 10:
                    case 11:
                    case 12:
                        if (!output.Contains(" on right\n"))
                            output += DoorType(Level, ref random) + " on right\n";
                        break;
                    case 13:
                    case 14:
                    case 15:
                    case 16:
                    case 17:
                    case 18:
                    case 19:
                    case 20:
                        if (!output.Contains(" ahead\n"))
                            output += DoorType(Level, ref random) + " ahead\n";
                        break;
                    default: return "[Error: Door out of range.  Dungon.205]";
                }
            } while (Dice.d20(ref random) <= 3);

            return output;
        }

        public static string DoorType(int Level, ref Random random)
        {
            bool stop; int limit = 100; int DC = 0; string output = "";
            do
            {
                stop = true;
                switch (Dice.Roll(1, limit, 0, ref random))
                {
                    case 1:
                    case 2:
                    case 3:
                    case 4:
                    case 5:
                    case 6:
                    case 7:
                    case 8: return String.Format("{0} simple wooden door", output);
                    case 9: return String.Format("{0} simple wooden door, with {1}", output, Trap.Generate(Level, ref random));
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
                        DC += 13;
                        return String.Format("{0} simple wooden door, stuck (Break DC {1})", output, DC);
                    case 24:
                        if (DC != 30)
                            DC += 13;
                        return String.Format("{0} simple wooden door, stuck (Break DC {1}) with {2}", output, DC, Trap.Generate(Level, ref random));
                    case 25:
                    case 26:
                    case 27:
                    case 28:
                    case 29:
                        if (DC != 30)
                            DC += 13;
                        return String.Format("{0} simple wooden door, locked (Break DC {1})", output, DC);
                    case 30:
                        if (DC != 30)
                            DC += 13;
                        return String.Format("{0} simple wooden door, locked (Break DC {1}) with {2}", output, DC, Trap.Generate(Level, ref random));
                    case 31:
                    case 32:
                    case 33:
                    case 34:
                    case 35: return String.Format("{0} good wooden door", output);
                    case 36: return String.Format("{0} good wooden door, with {1}", output, Trap.Generate(Level, ref random));
                    case 37:
                    case 38:
                    case 39:
                    case 40:
                    case 41:
                    case 42:
                    case 43:
                    case 44:
                        if (DC != 30)
                            DC += 18;
                        return String.Format("{0} good wooden door, stuck (Break DC {1})", output, DC);
                    case 45:
                        if (DC != 30)
                            DC += 18;
                        return String.Format("{0} good wooden door, stuck (Break DC {1}) with {2}", output, DC, Trap.Generate(Level, ref random));
                    case 46:
                    case 47:
                    case 48:
                    case 49:
                        if (DC != 30)
                            DC += 18;
                        return String.Format("{0} good wooden door, locked (Break DC {1})", output, DC);
                    case 50:
                        if (DC != 30)
                            DC += 18;
                        return String.Format("{0} good wooden door, locked (Break DC {1}) with {2}", output, DC, Trap.Generate(Level, ref random));
                    case 51:
                    case 52:
                    case 53:
                    case 54:
                    case 55: return String.Format("{0} strong wooden door", output);
                    case 56: return String.Format("{0} strong wooden door, with {1}", output, Trap.Generate(Level, ref random));
                    case 57:
                    case 58:
                    case 59:
                    case 60:
                    case 61:
                    case 62:
                    case 63:
                    case 64:
                        if (DC != 30)
                            DC += 23;
                        return String.Format("{0} strong wooden door, stuck (Break DC {1})", output, DC);
                    case 65:
                        if (DC != 30)
                            DC += 23;
                        return String.Format("{0} strong wooden door, stuck (Break DC {1}) with {2}", output, DC, Trap.Generate(Level, ref random));
                    case 66:
                    case 67:
                    case 68:
                    case 69:
                        if (DC != 30)
                            DC += 23;
                        return String.Format("{0} strong wooden door, locked (Break DC {1})", output, DC);
                    case 70:
                        if (DC != 30)
                            DC += 23;
                        return String.Format("{0} strong wooden door, locked (Break DC {1}) with {2}", output, DC, Trap.Generate(Level, ref random));
                    case 71: return String.Format("{0} stone door", output);
                    case 72: return String.Format("{0} stone door, with {1}", output, Trap.Generate(Level, ref random));
                    case 73:
                    case 74:
                    case 75:
                        if (DC != 30)
                            DC += 28;
                        else
                            DC = 40;
                        return String.Format("{0} stone door, stuck (Break DC {1})", output, DC);
                    case 76:
                        if (DC != 30)
                            DC += 28;
                        else
                            DC = 40;
                        return String.Format("{0} stone door, stuck (Break DC {1}) with {2}", output, DC, Trap.Generate(Level, ref random));
                    case 77:
                    case 78:
                    case 79:
                        if (DC != 30)
                            DC += 28;
                        else
                            DC = 40;
                        return String.Format("{0} stone door, locked (Break DC {1})", output, DC);
                    case 80:
                        if (DC != 30)
                            DC += 28;
                        else
                            DC = 40;
                        return String.Format("{0} stone door, locked (Break DC {1}) with {2}", output, DC, Trap.Generate(Level, ref random));
                    case 81: return String.Format("{0} iron door", output);
                    case 82: return String.Format("{0} iron door, with {1}", output, Trap.Generate(Level, ref random));
                    case 83:
                    case 84:
                    case 85:
                        if (DC != 30)
                            DC += 28;
                        else
                            DC = 40;
                        return String.Format("{0} iron door, stuck (Break DC {1})", output, DC);
                    case 86:
                        if (DC != 30)
                            DC += 28;
                        else
                            DC = 40;
                        return String.Format("{0} iron door, stuck (Break DC {1}) with {2}", output, DC, Trap.Generate(Level, ref random));
                    case 87:
                    case 88:
                    case 89:
                        if (DC != 30)
                            DC += 28;
                        else
                            DC = 40;
                        return String.Format("{0} iron door, locked (Break DC {1})", output, DC);
                    case 90:
                        if (DC != 30)
                            DC += 28;
                        else
                            DC = 40;
                        return String.Format("{0} stone door, locked (Break DC {1}) with {2}", output, DC, Trap.Generate(Level, ref random));
                    case 91:
                    case 92:
                    case 93:
                        limit = 90;
                        DC += 1;
                        output += " side-sliding";
                        stop = false;
                        break;
                    case 94:
                    case 95:
                    case 96:
                        limit = 90;
                        DC += 1;
                        output += " down-sliding";
                        stop = false;
                        break;
                    case 97:
                    case 98:
                    case 99:
                        limit = 90;
                        DC += 2;
                        output += "n up-sliding";
                        stop = false;
                        break;
                    case 100:
                        limit = 90;
                        DC = 30;
                        output += " magically-reinforced";
                        stop = false;
                        break;
                    default: return "[Error: door type out of range.  Dungeon.413]";
                }
            } while (!stop);

            return "[Um, how the hell did this happen?  DoorType somehow jumped the switch loop.  Dungeon.419]";
        }

        public static string PassageWidth(ref Random random)
        {
            switch (Dice.d20(ref random))
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
                case 12: return "10' wide passage";
                case 13:
                case 14:
                case 15:
                case 16: return "20' wide passage";
                case 17: return "30' wide passage";
                case 18: return "5' wide passage";
                case 19:
                case 20: return SpecialPassageWidth(ref random);
                default: return "[Error: Passage Width out of range.  Dungeon.446]";
            }
        }

        private static string SpecialPassageWidth(ref Random random)
        {
            switch (Dice.d20(ref random))
            {
                case 1:
                case 2:
                case 3:
                case 4: return "40' wide passage, columns down center";
                case 5:
                case 6:
                case 7: return "40' wide passage, double row of columns";
                case 8:
                case 9:
                case 10: return "50' wide passage, double row of columns";
                case 11:
                case 12:
                    string output = "50' wide passage, columns 10' right and left support 10' wide upper galleries 20' above";
                    if (Dice.d4(ref random) == 1)
                    {
                        output += " (Stairs up to the galleries are at the beginning of the hall)";
                        if (Dice.Roll(1, 2, 0, ref random) == 1)
                            output += " (Stairs also at end of hall)";
                    }
                    else
                        output += " (Stairs up to the galleries are at the end of the hall)";
                    return output;
                case 13:
                case 14:
                case 15:
                    output = "10' wide stream ";
                    if (Dice.d4(ref random) != 1)
                        output += "(bridged) ";
                    return output + "bisects the passage (same width as previous or 10')";
                case 16:
                case 17:
                    output = "20' wide river";
                    if (Dice.d4(ref random) <= 3)
                        output += " (bridged)";
                    else
                        output += " (boat)";
                    return output + " bisects the passage (same width as previous or 10')";
                case 18:
                    output = "40' wide river";
                    if (Dice.d4(ref random) <= 3)
                        output += " (bridged)";
                    else
                        output += " (boat)";
                    return output + " bisects the passage (same width as previous or 10')";
                case 19:
                    output = "60' wide river";
                    if (Dice.d4(ref random) <= 3)
                        output += " (bridged)";
                    else
                        output += " (boat)";
                    return output + " bisects the passage (same width as previous or 10')";
                case 20:
                    output = "20' wide chasm";
                    if (Dice.d4(ref random) <= 3)
                        output += " (bridged)";
                    else
                        output += " (jumping place, 5'-10' wide)";
                    return output + " bisects the passage (same width as previous or 10')";
                default: return "[Error: Special Passage out of range.  Dungeon.512]";
            }
        }
    }
}
