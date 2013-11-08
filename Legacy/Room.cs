using System;
using System.Collections.Generic;
using System.Text;

namespace Dungeon_Maker
{
    class Room
    {
        public static string GenerateRoom(int Level, ref Random random)
        {
            switch (Dice.d20(ref random))
            {
                case 1:
                case 2: return String.Format("10 x 10 room.\n\nExits:\n{0}\n\ncontains:\n{1}", Exits(100, false, Level, ref random), Contents(Level, ref random));
                case 3:
                case 4: return String.Format("20 x 20 room.\n\nExits:\n{0}\n\ncontains:\n{1}", Exits(400, false, Level, ref random), Contents(Level, ref random));
                case 5:
                case 6: return String.Format("30 x 30 room.\n\nExits:\n{0}\n\ncontains:\n{1}", Exits(900, false, Level, ref random), Contents(Level, ref random));
                case 7:
                case 8: return String.Format("40 x 40 room.\n\nExits:\n{0}\n\ncontains:\n{1}", Exits(1600, false, Level, ref random), Contents(Level, ref random));
                case 9:
                case 10: return String.Format("10 x 20 room.\n\nExits:\n{0}\n\ncontains:\n{1}", Exits(200, false, Level, ref random), Contents(Level, ref random));
                case 11:
                case 12:
                case 13: return String.Format("20 x 30 room.\n\nExits:\n{0}\n\ncontains:\n{1}", Exits(600, false, Level, ref random), Contents(Level, ref random));
                case 14:
                case 15: return String.Format("20 x 40 room.\n\nExits:\n{0}\n\ncontains:\n{1}", Exits(800, false, Level, ref random), Contents(Level, ref random));
                case 16:
                case 17: return String.Format("30 x 40 room.\n\nExits:\n{0}\n\ncontains:\n{1}", Exits(1200, false, Level, ref random), Contents(Level, ref random));
                case 18:
                case 19:
                case 20: return SpecialRoom(false, Level, ref random);
                default: return "[Error: Generate Room out of range.  Room.33";
            }
        }

        private static string SpecialRoom(bool Chamber, int Level, ref Random random)
        {
            string RoomOrChamber; string output;

            if (Chamber)
                RoomOrChamber = "chamber";
            else
                RoomOrChamber = "room";

            switch (Dice.d20(ref random))
            {
                case 1:
                case 2:
                case 3:
                case 4:
                case 5: output = String.Format("Circular {0}, {1}", RoomOrChamber, Pool(Level, ref random)); break;
                case 6:
                case 7:
                case 8: output = "Triangular " + RoomOrChamber; break;
                case 9:
                case 10:
                case 11: output = "Trapezoidal " + RoomOrChamber; break;
                case 12:
                case 13: output = "Odd-shaped (whatever you want) " + RoomOrChamber; break;
                case 14:
                case 15: output = "Ovular " + RoomOrChamber; break;
                case 16:
                case 17: output = "Hexagonal " + RoomOrChamber; break;
                case 18:
                case 19: output = "Octagonal " + RoomOrChamber; break;
                case 20: return Cave(Level, ref random);
                default: return "[Error: Unusual Shape out of range.  Room.68]";
            }
            int size = 0; bool RollAgain;
            do
            {
                RollAgain = false;
                switch (Dice.d20(ref random))
                {
                    case 1:
                    case 2:
                    case 3: size += 500; break;
                    case 4:
                    case 5:
                    case 6: size += 900; break;
                    case 7:
                    case 8: size += 1300; break;
                    case 9:
                    case 10: size += 2000; break;
                    case 11:
                    case 12: size += 2700; break;
                    case 13:
                    case 14: size += 3400; break;
                    case 15:
                    case 16:
                    case 17:
                    case 18:
                    case 19:
                    case 20: RollAgain = true; size += 2000; break;
                    default: return "[Error: Unusual Room size out of range.  Room.96]";
                }
            } while (RollAgain);

            return String.Format("{0} of about {1} square feet.\n\nExits:\n{2}\n\nContains:\n{3}", output, size, Exits(size, Chamber, Level, ref random), Contents(Level, ref random));
        }

        private static string Exits(int Size, bool Chamber, int Level, ref Random random)
        {
            int NumberOfExits; string output = "";
            switch (Dice.d20(ref random))
            {
                case 1:
                case 2:
                case 3:
                    if (Size <= 600)
                        NumberOfExits = 1;
                    else
                        NumberOfExits = 2;
                    break;
                case 4:
                case 5:
                case 6:
                    if (Size <= 600)
                        NumberOfExits = 2;
                    else
                        NumberOfExits = 3;
                    break;
                case 7:
                case 8:
                case 9:
                    if (Size <= 600)
                        NumberOfExits = 3;
                    else
                        NumberOfExits = 4;
                    break;
                case 10:
                case 11:
                case 12:
                    if (Size <= 1200)
                        NumberOfExits = 0;
                    else
                        NumberOfExits = 1;
                    break;
                case 13:
                case 14:
                case 15:
                    if (Size <= 1600)
                        NumberOfExits = 0;
                    else
                        NumberOfExits = 1;
                    break;
                case 16:
                case 17:
                case 18: NumberOfExits = Dice.d4(ref random); break;
                case 19:
                case 20:
                    NumberOfExits = 1;
                    Chamber = !Chamber;
                    break;
                default: return "[Error: Exit Number out of range.  Room.156]";
            }

            if (NumberOfExits == 0)
                return "Check for secret doors along mapped walls";

            while (NumberOfExits > 0)
            {
                NumberOfExits--;
                if (Chamber)
                {
                    switch (Dice.d20(ref random))
                    {
                        case 1:
                        case 2:
                        case 3:
                        case 4:
                        case 5:
                        case 6:
                        case 7: output += String.Format("\tOne {0} is on the opposite wall ", Dungeon.PassageWidth(ref random)); break;
                        case 8:
                        case 9:
                        case 10:
                        case 11:
                        case 12: output += String.Format("\tOne {0} is on the left wall ", Dungeon.PassageWidth(ref random)); break;
                        case 13:
                        case 14:
                        case 15:
                        case 16:
                        case 17: output += String.Format("\tOne {0} is on the right wall ", Dungeon.PassageWidth(ref random)); break;
                        case 18:
                        case 19:
                        case 20: output += String.Format("\tOne {0} is on the same wall ", Dungeon.PassageWidth(ref random)); break;
                        default: return "[Error: Exit Location out of range.  Room.189]";
                    }
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
                        case 12:
                        case 13:
                        case 14:
                        case 15:
                        case 16: output += "straight ahead.\n"; break;
                        case 17:
                        case 18: output += "45 degrees left/right.\n"; break;
                        case 19:
                        case 20: output += "45 degrees right/left.\n"; break;
                        default: return "[Error: Exit direction out of range.  Room.213]";
                    }
                }
                else
                {
                    switch (Dice.d20(ref random))
                    {
                        case 1:
                        case 2:
                        case 3:
                        case 4:
                        case 5:
                        case 6:
                        case 7: output += "\t" + Dungeon.DoorType(Level, ref random) + " is on the opposite wall.\n"; break;
                        case 8:
                        case 9:
                        case 10:
                        case 11:
                        case 12: output += "\t" + Dungeon.DoorType(Level, ref random) + " is on the left wall.\n"; break;
                        case 13:
                        case 14:
                        case 15:
                        case 16:
                        case 17: output += " \t" + Dungeon.DoorType(Level, ref random) + " is on the right wall.\n"; break;
                        case 18:
                        case 19:
                        case 20: output += " \t" + Dungeon.DoorType(Level, ref random) + " is on the same wall.\n"; break;
                        default: return "[Error: Door location out of range.  Room.240]";
                    }
                }
            }

            return output;
        }

        private static string Contents(int Level, ref Random random)
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
                case 18: return String.Format("\t{0}", Encounter.Generate(Level, ref random));
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
                case 44: return String.Format("\t{0}\n\t{1}", Encounter.Generate(Level, ref random), Features(ref random));
                case 45: return String.Format("\t{0}\n\t{1}", Encounter.Generate(Level, ref random), Treasure.Generate(true, false, true, Level, ref random));
                case 46: return String.Format("\t{0}\n\t{1}", Encounter.Generate(Level, ref random), Trap.Generate(Level, ref random));
                case 47: return String.Format("\t{0}\n\t{1}\n\t{2}", Encounter.Generate(Level, ref random), Features(ref random), Treasure.Generate(true, false, true, Level, ref random));
                case 48: return String.Format("\t{0}\n\t{1}\n\t{2}", Encounter.Generate(Level, ref random), Features(ref random), Trap.Generate(Level, ref random));
                case 49: return String.Format("\t{0}\n\t{1}", Encounter.Generate(Level, ref random), Treasure.Generate(true, true, true, Level, ref random));
                case 50: return String.Format("\t{0}\n\t{1}\n\t{2}", Encounter.Generate(Level, ref random), Features(ref random), Treasure.Generate(true, true, true, Level, ref random));
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
                case 70:
                case 71:
                case 72:
                case 73:
                case 74:
                case 75:
                case 76: return String.Format("\t{0}", Features(ref random));
                case 77: return String.Format("\t{0}\n\t{1}", Features(ref random), Treasure.Generate(true, false, true, Level, ref random));
                case 78: return String.Format("\t{0}\n\t{1}", Features(ref random), Trap.Generate(Level, ref random));
                case 79: return String.Format("\t{0}\n\t{1}", Features(ref random), Treasure.Generate(true, true, true, Level, ref random));
                case 80: return String.Format("\t{0}", Treasure.Generate(true, false, true, Level, ref random));
                case 81: return String.Format("\t{0}", Treasure.Generate(true, true, true, Level, ref random));
                case 82: return String.Format("\t{0}", Trap.Generate(Level, ref random));
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
                case 100: return "\tThe room is empty.";
                default: return "[Error: room contents out of range.  Room.352]";
            }
        }

        private static string Features(ref Random random)
        {
            switch (Dice.d10(ref random))
            {
                case 1:
                case 2:
                case 3:
                case 4: return MinorFeatures(Dice.d4(ref random), ref random);
                case 5:
                case 6:
                case 7:
                case 8: return MajorFeatures(Dice.d4(ref random), ref random);
                case 9:
                case 10: return MinorFeatures(Dice.d4(ref random), ref random) + MajorFeatures(Dice.d4(ref random), ref random);
                default: return "[Error: Features out of range.  Room.370]";
            }
        }

        private static string MinorFeatures(int Quantity, ref Random random)
        {
            string output = "";

            while (Quantity > 0)
            {
                switch (Dice.Percentile(ref random))
                {
                    case 1: output += "an anvil, "; break;
                    case 2: output += "ash, "; break;
                    case 3: output += "a backpack, "; break;
                    case 4: output += "a bale of straw, "; break;
                    case 5: output += "bellows, "; break;
                    case 6: output += "a belt, "; break;
                    case 7: output += "bits of fur, "; break;
                    case 8: output += "a blanket, "; break;
                    case 9: output += "a bloodstain, "; break;
                    case 10: output += "humanoid bones, "; break;
                    case 11: output += "nonhumanoid bones, "; break;
                    case 12: output += "books, "; break;
                    case 13: output += "boots, "; break;
                    case 14: output += "a bottle, "; break;
                    case 15: output += "a box, "; break;
                    case 16: output += "a branding iron, "; break;
                    case 17: output += "broken glass, "; break;
                    case 18: output += "a bucket, "; break;
                    case 19: output += "a candle, "; break;
                    case 20: output += "a candelabra, "; break;
                    case 21: output += "playing cards, "; break;
                    case 22: output += "chains, "; break;
                    case 23: output += "claw marks, "; break;
                    case 24: output += "a cleaver, "; break;
                    case 25: output += "clothing, "; break;
                    case 26: output += "cobwebs, "; break;
                    case 27: output += "a cold spot, "; break;
                    case 28: output += "an adventurer's corpse, "; break;
                    case 29: output += "a monster's corpse, "; break;
                    case 30: output += "cracks, "; break;
                    case 31: output += "dice, "; break;
                    case 32: output += "discarded weapons, "; break;
                    case 33: output += "dishes, "; break;
                    case 34: output += "dripping water, "; break;
                    case 35: output += "a drum, "; break;
                    case 36: output += "dust, "; break;
                    case 37: output += "an engraving, "; break;
                    case 38: output += "broken equipment, "; break;
                    case 39: output += "usable equipment, "; break;
                    case 40: output += "a flask, "; break;
                    case 41: output += "flint and tinder, "; break;
                    case 42: output += "spoiled foodstuffs, "; break;
                    case 43: output += "edible foodstuffs, "; break;
                    case 44: output += "fungus, "; break;
                    case 45: output += "a grinder, "; break;
                    case 46: output += "a hook, "; break;
                    case 47: output += "a horn, "; break;
                    case 48: output += "an hourglass, "; break;
                    case 49: output += "insects, "; break;
                    case 50: output += "a jar, "; break;
                    case 51: output += "a keg, "; break;
                    case 52: output += "a key, "; break;
                    case 53: output += "a lamp, "; break;
                    case 54: output += "a lantern, "; break;
                    case 55: output += "markings, "; break;
                    case 56: output += "mold, "; break;
                    case 57: output += "mud, "; break;
                    case 58: output += "a mug, "; break;
                    case 59: output += "a musical instrument, "; break;
                    case 60: output += "a mysterious stain, "; break;
                    case 61: output += "an animal nest, "; break;
                    case 62: output += "an unidentifiable odor, "; break;
                    case 63: output += "oil for fuel, "; break;
                    case 64: output += "scented oil, "; break;
                    case 65: output += "paint, "; break;
                    case 66: output += "paper, "; break;
                    case 67: output += "pillows, "; break;
                    case 68: output += "a smoking pipe, "; break;
                    case 69: output += "a pole, "; break;
                    case 70: output += "a pot, "; break;
                    case 71: output += "a pottery shard, "; break;
                    case 72: output += "a pouch, "; break;
                    case 73: output += "a puddle of water, "; break;
                    case 74: output += "rags, "; break;
                    case 75: output += "a razor, "; break;
                    case 76: output += "a rivulet, "; break;
                    case 77: output += "ropes, "; break;
                    case 78: output += "runes, "; break;
                    case 79: output += "a sack, "; break;
                    case 80: output += "scattered stones, "; break;
                    case 81: output += "scorch marks, "; break;
                    case 82: output += "a nonmagical scroll, "; break;
                    case 83: output += "an empty scroll case, "; break;
                    case 84: output += "a skull, "; break;
                    case 85: output += "slime, "; break;
                    case 86: output += "an unexplained sound, "; break;
                    case 87: output += "spices, "; break;
                    case 88: output += "a spike, "; break;
                    case 89: output += "teeth, "; break;
                    case 90: output += "tongs, "; break;
                    case 91: output += "tools, "; break;
                    case 92: output += "a torch stub, "; break;
                    case 93: output += "a tray, "; break;
                    case 94: output += "a trophy, "; break;
                    case 95: output += "twine, "; break;
                    case 96: output += "an urn, "; break;
                    case 97: output += "utensils, "; break;
                    case 98: output += "a whetstone, "; break;
                    case 99: output += "scraps of wood, "; break;
                    case 100: output += "scrawled words, "; break;
                    default: return "Error: Minor Features out of range.  Room.482]";
                }

                Quantity--;
            }

            return output;
        }

        private static string MajorFeatures(int Quantity, ref Random random)
        {
            string output = "";

            while (Quantity > 0)
            {
                switch (Dice.Percentile(ref random))
                {
                    case 1: output += "an alcove, "; break;
                    case 2: output += "an altar, "; break;
                    case 3: output += "an arch, "; break;
                    case 4: output += "an arrow slit in the wall/murder hole in the ceiling, "; break;
                    case 5: output += "a balcony, "; break;
                    case 6: output += "a barrel, "; break;
                    case 7: output += "a bed, "; break;
                    case 8: output += "a bench, "; break;
                    case 9: output += "a bookcase, "; break;
                    case 10: output += "a brazier, "; break;
                    case 11: output += "a cage, "; break;
                    case 12: output += "a caldron, "; break;
                    case 13: output += "a carpet, "; break;
                    case 14: output += "a carving, "; break;
                    case 15: output += "a casket, "; break;
                    case 16: output += "a catwalk, "; break;
                    case 17: output += "a chair, "; break;
                    case 18: output += "a chandelier, "; break;
                    case 19: output += "a charcoal bin, "; break;
                    case 20: output += "a chasm, "; break;
                    case 21: output += "a chest, "; break;
                    case 22: output += "a chest of drawers, "; break;
                    case 23: output += "a chute, "; break;
                    case 24: output += "a coat rack, "; break;
                    case 25: output += "a collapsed wall, "; break;
                    case 26: output += "a crate, "; break;
                    case 27: output += "a cupboard, "; break;
                    case 28: output += "a curtain, "; break;
                    case 29: output += "a divan, "; break;
                    case 30: output += "a dome, "; break;
                    case 31: output += "a broken door, "; break;
                    case 32: output += "a dung heap, "; break;
                    case 33: output += "an evil symbol, "; break;
                    case 34: output += "fallen stones, "; break;
                    case 35: output += "a firepit, "; break;
                    case 36: output += "a fireplace, "; break;
                    case 37: output += "a font, "; break;
                    case 38: output += "a forge, "; break;
                    case 39: output += "a fountain, "; break;
                    case 40: output += "broken furniture, "; break;
                    case 41: output += "a gong, "; break;
                    case 42: output += "a pile of hay, "; break;
                    case 43: output += "a hole, "; break;
                    case 44: output += "a blasted hole, "; break;
                    case 45: output += "an idol, "; break;
                    case 46: output += "iron bars, "; break;
                    case 47: output += "an iron maiden, "; break;
                    case 48: output += "a kiln, "; break;
                    case 49: output += "a ladder, "; break;
                    case 50: output += "a ledge, "; break;
                    case 51: output += "a loom, "; break;
                    case 52: output += "loose masonry, "; break;
                    case 53: output += "manacles, "; break;
                    case 54: output += "a manger, "; break;
                    case 55: output += "a mirror, "; break;
                    case 56: output += "a mosaic, "; break;
                    case 57: output += "a mound of rubble, "; break;
                    case 58: output += "an oven, "; break;
                    case 59: output += "an overhang, "; break;
                    case 60: output += "a painting, "; break;
                    case 61: output += "a partially collapsed ceiling, "; break;
                    case 62: output += "a pedestal, "; break;
                    case 63: output += "a peephole, "; break;
                    case 64: output += "a pillar, "; break;
                    case 65: output += "a pillory, "; break;
                    case 66: output += "a shallow pit, "; break;
                    case 67: output += "a platform, "; break;
                    case 68: output += "a pool, "; break;
                    case 69: output += "a portcullis, "; break;
                    case 70: output += "a rack, "; break;
                    case 71: output += "a ramp, "; break;
                    case 72: output += "a recess, "; break;
                    case 73: output += "a relief, "; break;
                    case 74: output += "a sconce, "; break;
                    case 75: output += "a screen, "; break;
                    case 76: output += "a shaft, "; break;
                    case 77: output += "a shelf, "; break;
                    case 78: output += "a shrine, "; break;
                    case 79: output += "a spinning wheel, "; break;
                    case 80: output += "a stall or pen, "; break;
                    case 81: output += "a statue, "; break;
                    case 82: output += "a toppled statue, "; break;
                    case 83: output += "steps, "; break;
                    case 84: output += "a stool, "; break;
                    case 85: output += "a stuffed beast, "; break;
                    case 86: output += "a sunken area, "; break;
                    case 87: output += "a large table, "; break;
                    case 88: output += "a small table, "; break;
                    case 89: output += "a tapestry, "; break;
                    case 90: output += "a throne, "; break;
                    case 91: output += "a pile of trash, "; break;
                    case 92: output += "a tripod, "; break;
                    case 93: output += "a trough, "; break;
                    case 94: output += "a tub, "; break;
                    case 95: output += "a wall basin, "; break;
                    case 96: output += "a wardrobe, "; break;
                    case 97: output += "a weapon rack, "; break;
                    case 98: output += "a well, "; break;
                    case 99: output += "a winch and pulley, "; break;
                    case 100: output += "a workbench, "; break;
                    default: return "[Error: Major Features out of range.  Room.599]";
                }

                Quantity--;
            }

            return output;
        }

        public static string GenerateChamber(int Level, ref Random random)
        {
            switch (Dice.d20(ref random))
            {
                case 1:
                case 2:
                case 3:
                case 4: return String.Format("20 x 20 chamber.\n\nExits:\n{0}\n\nContains:\n{1}", Exits(400, true, Level, ref random), Contents(Level, ref random));
                case 5:
                case 6: return String.Format("30 x 30 chamber.\n\nExits:\n{0}\n\nContains:\n{1}", Exits(900, true, Level, ref random), Contents(Level, ref random));
                case 7:
                case 8: return String.Format("40 x 40 chamber.\n\nExits:\n{0}\n\nContains:\n{1}", Exits(1600, true, Level, ref random), Contents(Level, ref random));
                case 9:
                case 10:
                case 11:
                case 12:
                case 13: return String.Format("20 x 30 chamber.\n\nExits:\n{0}\n\nContains:\n{1}", Exits(600, true, Level, ref random), Contents(Level, ref random));
                case 14:
                case 15: return String.Format("30 x 50 chamber.\n\nExits:\n{0}\n\nContains:\n{1}", Exits(1500, true, Level, ref random), Contents(Level, ref random));
                case 16:
                case 17: return String.Format("40 x 60 chamber.\n\nExits:\n{0}\n\nContains:\n{1}", Exits(2400, true, Level, ref random), Contents(Level, ref random));
                case 18:
                case 19:
                case 20: return SpecialRoom(true, Level, ref random);
                default: return "[Error: Generate Chambver out of range.  Room.632]";
            }
        }

        private static string Cave(int Level, ref Random random)
        {
            switch (Dice.d20(ref random))
            {
                case 1:
                case 2:
                case 3:
                case 4:
                case 5: return String.Format("Cave about 40' x 60'.  {0}.  Contains:\n{1}", Exits(2400, true, Level, ref random), Contents(Level, ref random));
                case 6:
                case 7: return String.Format("Cave about 50' x 75'.  {0}.  Contains:\n{1}", Exits(3750, true, Level, ref random), Contents(Level, ref random));
                case 8:
                case 9: return String.Format("Double cave: 20' x 30' ({0}.  Contains:\n{1}), 60' x 60' ({2}.  Contains:\n{3})", Exits(600, true, Level, ref random), Contents(Level, ref random), Exits(3600, true, Level, ref random), Contents(Level, ref random));
                case 10:
                case 11: return String.Format("Double cave: 35' x 50' ({0}.  Contains:\n{1})), 80' x 90' {2} ({3}.  Contains:\n{4})", Exits(1750, true, Level, ref random), Contents(Level, ref random), Pool(Level, ref random), Exits(7200, true, Level, ref random), Contents(Level, ref random));
                case 12:
                case 13:
                case 14: return String.Format("Cavern about 95' x 125' {0}.  {1}.  Contains:\n{2}", Pool(Level, ref random), Exits(11875, true, Level, ref random), Contents(Level, ref random));
                case 15:
                case 16: return String.Format("Cavern about 125' x 150'.  {0}.  Contains:\n{1}", Exits(18750, true, Level, ref random), Contents(Level, ref random));
                case 17:
                case 18: return String.Format("Cavern about 150' x 200'.  {0}.  Contains:\n{1}", Exits(30000, true, Level, ref random), Contents(Level, ref random));
                case 19:
                case 20:
                    int width = 250 + 5 * Dice.Roll(1, 11, -1, ref random);
                    int depth = 350 + 5 * Dice.Roll(1, 11, -1, ref random);
                    return String.Format("Mammoth cavern about {0}' x {1}' {2}.  {3}.  Contains:\n{4}", width, depth, Lake(Level, ref random), Exits(width * depth, true, Level, ref random), Contents(Level, ref random));
                default: return "[Error: Cave out of range.  Room.663]";
            }
        }

        private static string Lake(int Level, ref Random random)
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
                case 10: return "";
                case 11:
                case 12:
                case 13:
                case 14:
                case 15: return " with a lake.";
                case 16:
                case 17:
                case 18: return " with a lake and " + Encounter.Generate(Level, ref random);
                case 19:
                case 20:
                    string output = " with an enchanted lake leading to a different dimension/special temple/map.";
                    if (Dice.Percentile(ref random) <= 90)
                        output += String.Format("{0} guarding the lake.", Encounter.Generate(Level, ref random));
                    return output;
                default: return "[Error: Lake out of range.  Room.691]";
            }
        }

        private static string Pool(int Level, ref Random random)
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
                case 8: return "";
                case 9:
                case 10: return " with a pool";
                case 11:
                case 12: return String.Format(" with a pool and {0}", Encounter.Generate(Level, ref random));
                case 13:
                case 14:
                case 15:
                case 16:
                case 17:
                case 18: return String.Format(" with a pool, {0}, and {1}", Encounter.Generate(Level, ref random), Treasure.Generate(true, false, false, Level, ref random));
                case 19:
                case 20: return String.Format(" with {0}", MagicPool(ref random));
                default: return "[Error: Pools out of range.  Room.719]";
            }
        }

        private static string MagicPool(ref Random random)
        {
            string output = "magic pool";
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
                    if (Dice.Roll(1, 2, 0, ref random) == 1)
                        return output + " (turns gold to lead, one time only)";
                    return output + " (turns gold to platinum, one time only)";
                case 9:
                case 10:
                case 11:
                case 12:
                case 13:
                case 14:
                case 15: return output + " (For each character, changes a random stat.  50% Raise, 50% lower.  1d6 for stat.  1d3 points.  One time per character)";
                case 16:
                case 17:
                    output += " (Talking pool, grants one wish to characters of ";
                    switch (Dice.d20(ref random))
                    {
                        case 1:
                        case 2:
                        case 3:
                        case 4:
                        case 5:
                        case 6: output += "Lawful Good"; break;
                        case 7:
                        case 8:
                        case 9: output += "Lawful Evil"; break;
                        case 10:
                        case 11:
                        case 12: output += "Chaotic Good"; break;
                        case 13:
                        case 14:
                        case 15:
                        case 16:
                        case 17: output += "Chaotic Evil"; break;
                        case 18:
                        case 19:
                        case 20: output += "a neutral"; break;
                        default: return "[Error: Magic pool alignment out of range.  Room.775]";
                    }
                    output += " alignment.  Deals 1d20 points of damage to all who speak to the pool not of its alignment.)";
                    return output;
                case 18:
                case 19:
                case 20:
                    output += " (Teleporter pool";
                    switch (Dice.d20(ref random))
                    {
                        case 1:
                        case 2:
                        case 3:
                        case 4:
                        case 5:
                        case 6:
                        case 7: return output + " back to surface)";
                        case 8:
                        case 9:
                        case 10:
                        case 11:
                        case 12: return output + " somewhere on the level)";
                        case 13:
                        case 14:
                        case 15:
                        case 16: return output + " down 1 level)";
                        case 17:
                        case 18:
                        case 19:
                        case 20: return output + " 100 miles away, outdoors)";
                        default: return "[Error: Magic Teleporter pool out of range.  Room.805]";
                    }
                default: return "[Error: Magic Pool out of range.  Room.807]";
            }
        }
    }
}