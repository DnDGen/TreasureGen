using System;
using System.Collections.Generic;
using System.Text;

namespace Dungeon_Maker
{
    class Treasure
    {
        public static string Generate(int Level, ref Random random)
        {
            return String.Format("{0}, {1}, {2}", Coin(Level, ref random), Goods(Level, ref random), Items(Level, ref random));
        }
        
        public static string Generate(bool contained, bool trapped, bool hidden, int Level, ref Random random)
        {
            string output = String.Format("{0}, {1}, {2}", Coin(Level, ref random), Goods(Level, ref random), Items(Level, ref random));

            if (contained)
                output = String.Format("{0} {1}", output, Container(ref random));

            if (trapped)
                output = String.Format("{0} protected by {1}", output, Trap.Generate(Level, ref random));

            if (hidden)
                output = String.Format("{0} {1}", output, Hidden(ref random));

            return output;
        }

        private static string Coin(int Level, ref Random random)
        {
            int Roll = Dice.Percentile(ref random);;

            switch(Level)
            {
                case 1:
                    if (Roll < 15)
                        return "";
                    if (Roll < 30)
                        return String.Format("{0} cp", Dice.d6(ref random) * 1000);
                    if (Roll < 53)
                        return String.Format("{0} sp", Dice.d8(ref random) * 100);
                    if (Roll < 96)
                        return String.Format("{0} gp", Dice.Roll(2, 8, 0, ref random) * 10);
                    return String.Format("{0} pp", Dice.d4(ref random) * 10);
                case 2:
                    if (Roll < 14)
                        return "";
                    if (Roll < 24)
                        return String.Format("{0} cp", Dice.d10(ref random) * 1000);
                    if (Roll < 44)
                        return String.Format("{0} sp", Dice.Roll(2, 10, 0, ref random) * 100);
                    if (Roll < 96)
                        return String.Format("{0} gp", Dice.Roll(4, 10, 0, ref random) * 10);
                    return String.Format("{0} pp", Dice.Roll(2, 8, 0, ref random) * 10);
                case 3:
                    if (Roll < 12)
                        return "";
                    if (Roll < 22)
                        return String.Format("{0} cp", Dice.Roll(2, 10, 0, ref random) * 1000);
                    if (Roll < 42)
                        return String.Format("{0} sp", Dice.Roll(4, 8, 0, ref random) * 100);
                    if (Roll < 96)
                        return String.Format("{0} gp", Dice.d4(ref random) * 100);
                    return String.Format("{0} pp", Dice.d10(ref random) * 10);
                case 4:
                    if (Roll < 12)
                        return "";
                    if (Roll < 22)
                        return String.Format("{0} cp", Dice.Roll(3, 10, 0, ref random) * 1000);
                    if (Roll < 42)
                        return String.Format("{0} sp", Dice.Roll(4, 12, 0, ref random) * 1000);
                    if (Roll < 96)
                        return String.Format("{0} gp", Dice.d6(ref random) * 100);
                    return String.Format("{0} pp", Dice.d8(ref random) * 10);
                case 5:
                    if (Roll < 11)
                        return "";
                    if (Roll < 20)
                        return String.Format("{0} cp", Dice.d4(ref random) * 10000);
                    if (Roll < 39)
                        return String.Format("{0} sp", Dice.d6(ref random) * 1000);
                    if (Roll < 96)
                        return String.Format("{0} gp", Dice.d8(ref random) * 100);
                    return String.Format("{0} pp", Dice.d10(ref random) * 10);
                case 6:
                    if (Roll < 11)
                        return "";
                    if (Roll < 19)
                        return String.Format("{0} cp", Dice.d6(ref random) * 10000);
                    if (Roll < 38)
                        return String.Format("{0} sp", Dice.d8(ref random) * 1000);
                    if (Roll < 96)
                        return String.Format("{0} gp", Dice.d10(ref random) * 100);
                    return String.Format("{0} pp", Dice.d12(ref random) * 10);
                case 7:
                    if (Roll < 12)
                        return "";
                    if (Roll < 19)
                        return String.Format("{0} cp", Dice.d10(ref random) * 10000);
                    if (Roll < 36)
                        return String.Format("{0} sp", Dice.d12(ref random) * 1000);
                    if (Roll < 94)
                        return String.Format("{0} gp", Dice.Roll(2, 6, 0, ref random) * 100);
                    return String.Format("{0} pp", Dice.Roll(3, 4, 0, ref random) * 10);
                case 8:
                    if (Roll < 11)
                        return "";
                    if (Roll < 16)
                        return String.Format("{0} cp", Dice.d12(ref random) * 10000);
                    if (Roll < 30)
                        return String.Format("{0} sp", Dice.Roll(2, 6, 0, ref random) * 1000);
                    if (Roll < 88)
                        return String.Format("{0} gp", Dice.Roll(2, 8, 0, ref random) * 100);
                    return String.Format("{0} pp", Dice.Roll(3, 6, 0, ref random) * 10);
                case 9:
                    if (Roll < 11)
                        return "";
                    if (Roll < 16)
                        return String.Format("{0} cp", Dice.Roll(2, 6, 0, ref random) * 10000);
                    if (Roll < 30)
                        return String.Format("{0} sp", Dice.Roll(2, 8, 0, ref random) * 1000);
                    if (Roll < 86)
                        return String.Format("{0} gp", Dice.Roll(5, 4, 0, ref random) * 100);
                    return String.Format("{0} pp", Dice.Roll(2, 12, 0, ref random) * 10);
                case 10:
                    if (Roll < 11)
                        return "";
                    if (Roll < 25)
                        return String.Format("{0} sp", Dice.Roll(2, 10, 0, ref random) * 1000);
                    if (Roll < 80)
                        return String.Format("{0} gp", Dice.Roll(6, 4, 0, ref random) * 100);
                    return String.Format("{0} pp", Dice.Roll(5, 6, 0, ref random) * 10);
                case 11:
                    if (Roll < 9)
                        return "";
                    if (Roll < 15)
                        return String.Format("{0} sp", Dice.Roll(3, 10, 0, ref random) * 1000);
                    if (Roll < 76)
                        return String.Format("{0} gp", Dice.Roll(4, 8, 0, ref random) * 1000);
                    return String.Format("{0} pp", Dice.Roll(4, 10, 0, ref random) * 10);
                case 12:
                    if (Roll < 9)
                        return "";
                    if (Roll < 15)
                        return String.Format("{0} sp", Dice.Roll(3, 12, 0, ref random) * 1000);
                    if (Roll < 76)
                        return String.Format("{0} gp", Dice.d4(ref random) * 1000);
                    return String.Format("{0} pp", Dice.d4(ref random) * 100);
                case 13:
                    if (Roll < 9)
                        return "";
                    if (Roll < 76)
                        return String.Format("{0} gp", Dice.d4(ref random) * 1000);
                    return String.Format("{0} pp", Dice.d10(ref random) * 100);
                case 14:
                    if (Roll < 9)
                        return "";
                    if (Roll < 76)
                        return String.Format("{0} gp", Dice.d6(ref random) * 1000);
                    return String.Format("{0} pp", Dice.d12(ref random) * 100);
                case 15:
                    if (Roll < 4)
                        return "";
                    if (Roll < 75)
                        return String.Format("{0} gp", Dice.d8(ref random) * 1000);
                    return String.Format("{0} pp", Dice.Roll(3, 4, 0, ref random) * 100);
                case 16:
                    if (Roll < 4)
                        return "";
                    if (Roll < 75)
                        return String.Format("{0} gp", Dice.d12(ref random) * 1000);
                    return String.Format("{0} pp", Dice.Roll(3, 4, 0, ref random) * 100);
                case 17:
                    if (Roll < 4)
                        return "";
                    if (Roll < 69)
                        return String.Format("{0} gp", Dice.Roll(3, 4, 0, ref random) * 1000);
                    return String.Format("{0} pp", Dice.Roll(2, 10, 0, ref random) * 100);
                case 18:
                    if (Roll < 3)
                        return "";
                    if (Roll < 66)
                        return String.Format("{0} gp", Dice.Roll(3, 6, 0, ref random) * 1000);
                    return String.Format("{0} pp", Dice.Roll(5, 4, 0, ref random) * 100);
                case 19:
                    if (Roll < 3)
                        return "";
                    if (Roll < 66)
                        return String.Format("{0} gp", Dice.Roll(3, 8, 0, ref random) * 1000);
                    return String.Format("{0} pp", Dice.Roll(3, 10, 0, ref random) * 100);
                default:
                    if (Roll < 3)
                        return "";
                    if (Roll < 66)
                        return String.Format("{0} gp", Dice.Roll(4, 8, 0, ref random) * 1000);
                    return String.Format("{0} pp", Dice.Roll(4, 10, 0, ref random) * 100);
            }
        }

        private static string Goods(int Level, ref Random random)
        {
            int Roll = Dice.Percentile(ref random);

            switch (Level)
            {
                case 1:
                    if (Roll < 91)
                        return "";
                    else if (Roll < 96)
                        return Gems(ref random);
                    return ArtObject(ref random);
                case 2:
                    if (Roll < 82)
                        return "";
                    else if (Roll < 96)
                        return Gems(Dice.Roll(1, 3, 0, ref random), ref random);
                    return ArtObject(Dice.Roll(1, 3, 0, ref random), ref random);
                case 3:
                    if (Roll < 78)
                        return "";
                    else if (Roll < 96)
                        return Gems(Dice.Roll(1, 3, 0, ref random), ref random);
                    return ArtObject(Dice.Roll(1, 3, 0, ref random), ref random);
                case 4:
                    if (Roll < 71)
                        return "";
                    else if (Roll < 96)
                        return Gems(Dice.d4(ref random), ref random);
                    return ArtObject(Dice.Roll(1, 3, 0, ref random), ref random);
                case 5:
                    if (Roll < 61)
                        return "";
                    else if (Roll < 96)
                        return Gems(Dice.d4(ref random), ref random);
                    return ArtObject(Dice.d4(ref random), ref random);
                case 6:
                    if (Roll < 57)
                        return "";
                    else if (Roll < 93)
                        return Gems(Dice.d4(ref random), ref random);
                    return ArtObject(Dice.d4(ref random), ref random);
                case 7:
                    if (Roll < 49)
                        return "";
                    else if (Roll < 89)
                        return Gems(Dice.d4(ref random), ref random);
                    return ArtObject(Dice.d4(ref random), ref random);
                case 8:
                    if (Roll < 46)
                        return "";
                    else if (Roll < 86)
                        return Gems(Dice.d6(ref random), ref random);
                    return ArtObject(Dice.d4(ref random), ref random);
                case 9:
                    if (Roll < 41)
                        return "";
                    else if (Roll < 81)
                        return Gems(Dice.d8(ref random), ref random);
                    return ArtObject(Dice.d4(ref random), ref random);
                case 10:
                    if (Roll < 36)
                        return "";
                    else if (Roll < 80)
                        return Gems(Dice.d8(ref random), ref random);
                    return ArtObject(Dice.d6(ref random), ref random);
                case 11:
                    if (Roll < 25)
                        return "";
                    else if (Roll < 75)
                        return Gems(Dice.d10(ref random), ref random);
                    return ArtObject(Dice.d6(ref random), ref random);
                case 12:
                    if (Roll < 18)
                        return "";
                    else if (Roll < 71)
                        return Gems(Dice.d10(ref random), ref random);
                    return ArtObject(Dice.d8(ref random), ref random);
                case 13:
                    if (Roll < 12)
                        return "";
                    else if (Roll < 67)
                        return Gems(Dice.d12(ref random), ref random);
                    return ArtObject(Dice.d10(ref random), ref random);
                case 14:
                    if (Roll < 12)
                        return "";
                    else if (Roll < 67)
                        return Gems(Dice.Roll(2, 8, 0, ref random), ref random);
                    return ArtObject(Dice.Roll(2, 6, 0, ref random), ref random);
                case 15:
                    if (Roll < 10)
                        return "";
                    else if (Roll < 66)
                        return Gems(Dice.Roll(2, 10, 0, ref random), ref random);
                    return ArtObject(Dice.Roll(2, 8, 0, ref random), ref random);
                case 16:
                    if (Roll < 8)
                        return "";
                    else if (Roll < 65)
                        return Gems(Dice.Roll(4, 6, 0, ref random), ref random);
                    return ArtObject(Dice.Roll(2, 10, 0, ref random), ref random);
                case 17:
                    if (Roll < 5)
                        return "";
                    else if (Roll < 64)
                        return Gems(Dice.Roll(4, 8, 0, ref random), ref random);
                    return ArtObject(Dice.Roll(3, 8, 0, ref random), ref random);
                case 18:
                    if (Roll < 5)
                        return "";
                    else if (Roll < 55)
                        return Gems(Dice.Roll(3, 12, 0, ref random), ref random);
                    return ArtObject(Dice.Roll(3, 10, 0, ref random), ref random);
                case 19:
                    if (Roll < 4)
                        return "";
                    else if (Roll < 51)
                        return Gems(Dice.Roll(6, 6, 0, ref random), ref random);
                    return ArtObject(Dice.Roll(6, 6, 0, ref random), ref random);
                default:
                    if (Roll < 3)
                        return "";
                    else if (Roll < 39)
                        return Gems(Dice.Roll(4, 10, 0, ref random), ref random);
                    return ArtObject(Dice.Roll(7, 6, 0, ref random), ref random);
            }
        }

        public static string Gems(int Quantity, ref Random random)
        {
            string output = "";
            
            while (Quantity > 0)
            {
                if (output != "")
                    output += ", ";
                output += Gems(ref random);
                Quantity--;
            }

            return output;
        }

        public static string Gems(ref Random random)
        {
            string gem; int price;

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
                    price = Dice.Roll(4, 4, 0, ref random);
                    switch (Dice.d12(ref random))
                    {
                        case 1: gem = "a banded agate"; break;
                        case 2: gem = "an eye agate"; break;
                        case 3: gem = "a moss agate"; break;
                        case 4: gem = "an azurite"; break;
                        case 5: gem = "a blue quartz"; break;
                        case 6: gem = "a hematite"; break;
                        case 7: gem = "a lapis lazuli"; break;
                        case 8: gem = "a malachite"; break;
                        case 9: gem = "an obsidian"; break;
                        case 10: gem = "a rhodochrosite"; break;
                        case 11: gem = "a tiger eye turquoise"; break;
                        default: gem = "an irregular freshwater pearl"; break;
                    }
                    return String.Format("{0} ({1} gp)", gem, price);
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
                    price = Dice.Roll(2, 4, 0, ref random) * 10;
                    switch (Dice.Roll(1, 17, 0, ref random))
                    {
                        case 1: gem = "a bloodstone"; break;
                        case 2: gem = "a carnelian"; break;
                        case 3: gem = "a chalcedony"; break;
                        case 4: gem = "a chrysoprase"; break;
                        case 5: gem = "a citrine"; break;
                        case 6: gem = "an iolite"; break;
                        case 7: gem = "a jasper"; break;
                        case 8: gem = "a moonstone"; break;
                        case 9: gem = "an onyx"; break;
                        case 10: gem = "a peridot"; break;
                        case 11: gem = "a clear quartz rock crystal"; break;
                        case 12: gem = "a sard"; break;
                        case 13: gem = "a sardonyx"; break;
                        case 14: gem = "a rose quartz"; break;
                        case 15: gem = "a smoky quartz"; break;
                        case 16: gem = "a star quartz"; break;
                        default: gem = "a zircon"; break;
                    }
                    return String.Format("{0} ({1} gp)", gem, price);
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
                    price = Dice.Roll(4, 4, 0, ref random) * 10;
                    switch (Dice.Roll(1, 16, 0, ref random))
                    {
                        case 1: gem = "an amber"; break;
                        case 2: gem = "an amethyst"; break;
                        case 3: gem = "a chrysoberyl"; break;
                        case 4: gem = "a coral"; break;
                        case 5: gem = "a red garnet"; break;
                        case 6: gem = "a brown-green garnet"; break;
                        case 7: gem = "a jade"; break;
                        case 8: gem = "a jet"; break;
                        case 9: gem = "a white pearl"; break;
                        case 10: gem = "a golden pearl"; break;
                        case 11: gem = "a pink pearl"; break;
                        case 12: gem = "a silver pearl"; break;
                        case 13: gem = "a red spinel"; break;
                        case 14: gem = "a red-brown spinel"; break;
                        case 15: gem = "a deep green spinel"; break;
                        default: gem = "a tourmaline"; break;
                    }
                    return String.Format("{0} ({1} gp)", gem, price);
                case 91:
                case 92:
                case 93:
                case 94:
                case 95:
                case 96:
                case 97:
                case 98:
                case 99:
                    price = Dice.Roll(4, 4, 0, ref random) * 100;
                    switch (Dice.d10(ref random))
                    {
                        case 1: gem = "an emerald"; break;
                        case 2: gem = "a white opal"; break;
                        case 3: gem = "a black opal"; break;
                        case 4: gem = "a fire opal"; break;
                        case 5: gem = "a blue sapphire"; break;
                        case 6: gem = "a fiery yellow corundum"; break;
                        case 7: gem = "a rich purple corundum"; break;
                        case 8: gem = "a blue star sapphire"; break;
                        case 9: gem = "a black star sapphire"; break;
                        default: gem = "a star ruby"; break;
                    }
                    return String.Format("{0} ({1} gp)", gem, price);
                case 100:
                    price = Dice.Roll(2, 4, 0, ref random) * 1000;
                    switch (Dice.Roll(1, 7, 0, ref random))
                    {
                        case 1: gem = "a clearest bright green emerald"; break;
                        case 2: gem = "a blue-white diamond"; break;
                        case 3: gem = "a canary diamond"; break;
                        case 4: gem = "a pink diamond"; break;
                        case 5: gem = "a brown diamond"; break;
                        case 6: gem = "a blue diamond"; break;
                        default: gem = "a jacinth"; break;
                    }
                    return String.Format("{0} ({1} gp)", gem, price);
                default:
                    price = Dice.Roll(2, 4, 0, ref random) * 100;
                    switch (Dice.d6(ref random))
                    {
                        case 1: gem = "an alexandrite"; break;
                        case 2: gem = "an aquamarine"; break;
                        case 3: gem = "a violet garnet"; break;
                        case 4: gem = "a black pearl"; break;
                        case 5: gem = "a deep blue spinel"; break;
                        default: gem = "a golden yellow topaz"; break;
                    }
                    return String.Format("{0} ({1} gp)", gem, price);
            }
        }

        private static string ArtObject(int Quantity, ref Random random)
        {
            string output = "";

            while (Quantity > 0)
            {
                if (output != "")
                    output += ", ";
                output += ArtObject(ref random);

                Quantity--;
            }

            return output;
        }

        private static string ArtObject(ref Random random)
        {
            string art; int price;

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
                    price = Dice.d10(ref random) * 10;
                    switch (Dice.d4(ref random))
                    {
                        case 1: art = "a silver ewer"; break;
                        case 2: art = "a carved bone statuette"; break;
                        case 3: art = "an ivory statuette"; break;
                        default: art = "a finely-wrought small gold bracelet"; break;
                    }
                    return String.Format("{0} ({1} gp)", art, price);
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
                    price = Dice.d6(ref random) * 100;
                    if (Dice.Roll(1, 2, 0, ref random) == 1)
                        art = "a large well-done wool tapestry";
                    else
                        art = "a brass mug with jade inlays";
                    return String.Format("{0} ({1} gp)", art, price);
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
                    price = Dice.d10(ref random) * 100;
                    if (Dice.Roll(1, 2, 0, ref random) == 1)
                        art = "a silver comb with moonstones";
                    else
                        art = "a silver-plated steel longsward with a jet jewel in the hilt";
                    return String.Format("{0} ({1} gp)", art, price);
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
                    price = Dice.Roll(2, 6, 0, ref random) * 100;
                    if (Dice.Roll(1, 2, 0, ref random) == 1)
                        art = "a carved harp of exotic wood and with ivory inlay and zircon gems";
                    else
                        art = "a solid gold idol (10 lb.)";
                    return String.Format("{0} ({1} gp)", art, price);
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
                    price = Dice.Roll(3, 6, 0, ref random) * 100;
                    switch (Dice.Roll(1, 3, 0, ref random))
                    {
                        case 1: art = "a gold dragon comb with red garnet eye"; break;
                        case 2: art = "a gold and topaz bottle stopper cork"; break;
                        default: art = "a ceremonial electrum dagger with a star ruby in the pommel"; break;
                    }
                    return String.Format("{0} ({1} gp)", art, price);
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
                    price = Dice.Roll(4, 6, 0, ref random) * 100;
                    switch (Dice.Roll(1, 3, 0, ref random))
                    {
                        case 1: art = "an eyepatch with a mock eye of sapphire and moonstone"; break;
                        case 2: art = "a fire opal pendant on a fine gold chain"; break;
                        default: art = "an old masterpiece painting"; break;
                    }
                    return String.Format("{0} ({1} gp)", art, price);
                case 81:
                case 82:
                case 83:
                case 84:
                case 85:
                    price = Dice.Roll(5, 6, 0, ref random) * 100;
                    if (Dice.Roll(1, 2, 0, ref random) == 1)
                        art = "an embroidered silk and velvet mantle with numerous moonstones";
                    else
                        art = "a sapphire pendant on a gold chain";
                    return String.Format("{0} ({1} gp)", art, price);
                case 86:
                case 87:
                case 88:
                case 89:
                case 90:
                    price = Dice.d4(ref random) * 1000;
                    switch (Dice.Roll(1, 3, 0, ref random))
                    {
                        case 1: art = "an embroidered and bejeweled glove"; break;
                        case 2: art = "a jeweled anklet"; break;
                        default: art = "a gold music box"; break;
                    }
                    return String.Format("{0} ({1} gp)", art, price);
                case 91:
                case 92:
                case 93:
                case 94:
                case 95:
                    price = Dice.d6(ref random) * 1000;
                    if (Dice.Roll(1, 2, 0, ref random) == 1)
                        art = "a golden circlet with four aquamarines";
                    else
                        art = "a necklace of small pink pearls";
                    return String.Format("{0} ({1} gp)", art, price);
                case 96:
                case 97:
                case 98:
                case 99:
                    price = Dice.Roll(2, 4, 0, ref random) * 1000;
                    if (Dice.Roll(1, 2, 0, ref random) == 1)
                        art = "a jeweled gold crown";
                    else
                        art = "a jeweled electrum ring";
                    return String.Format("{0} ({1} gp)", art, price);
                case 100:
                    price = Dice.Roll(2, 6, 0, ref random) * 1000;
                    if (Dice.Roll(1, 2, 0, ref random) == 1)
                        art = "a gold and ruby ring";
                    else
                        art = "a gold cup set with emeralds";
                    return String.Format("{0} ({1} gp)", art, price);
                default:
                    price = Dice.Roll(3, 6, 0, ref random) * 10;
                    switch (Dice.Roll(1, 3, 0, ref random))
                    {
                        case 1: art = "cloth of gold vestments"; break;
                        case 2: art = "a black velvet mask with numerous citrines"; break;
                        default: art = "a silver chalice with lapis lazuli gems"; break;
                    }
                    return String.Format("{0} ({1} gp)", art, price);
            }
        }

        public static string Items(int Level, ref Random random)
        {
            int Roll = Dice.Percentile(ref random);

            switch (Level)
            {
                case 1:
                    if (Roll < 72)
                        return "";
                    else if (Roll < 96)
                        return MundaneItems(ref random);
                    return MagicItems.Generate(MagicItems.POWER.MINOR, ref random);
                case 2:
                    if (Roll < 50)
                        return "";
                    else if (Roll < 86)
                        return MundaneItems(ref random);
                    return MagicItems.Generate(MagicItems.POWER.MINOR, ref random);
                case 3:
                    if (Roll < 50)
                        return "";
                    else if (Roll < 80)
                        return MundaneItems(Dice.Roll(1, 3, 0, ref random), ref random);
                    return MagicItems.Generate(MagicItems.POWER.MINOR, ref random);
                case 4:
                    if (Roll < 43)
                        return "";
                    else if (Roll < 63)
                        return MundaneItems(Dice.d4(ref random), ref random);
                    return MagicItems.Generate(MagicItems.POWER.MINOR, ref random);
                case 5:
                    if (Roll < 58)
                        return "";
                    else if (Roll < 68)
                        return MundaneItems(Dice.d4(ref random), ref random);
                    return MagicItems.Generate(ref random, MagicItems.POWER.MINOR, Dice.Roll(1, 3, 0, ref random));
                case 6:
                    if (Roll < 55)
                        return "";
                    else if (Roll < 60)
                        return MundaneItems(Dice.d4(ref random), ref random);
                    else if (Roll < 100)
                        return MagicItems.Generate(ref random, MagicItems.POWER.MINOR, Dice.Roll(1, 3, 0, ref random));
                    return MagicItems.Generate(MagicItems.POWER.MEDIUM, ref random);
                case 7:
                    if (Roll < 52)
                        return "";
                    else if (Roll < 98)
                        return MagicItems.Generate(ref random, MagicItems.POWER.MINOR, Dice.Roll(1, 3, 0, ref random));
                    return MagicItems.Generate(MagicItems.POWER.MEDIUM, ref random);
                case 8:
                    if (Roll < 49)
                        return "";
                    else if (Roll < 97)
                        return MagicItems.Generate(ref random, MagicItems.POWER.MINOR, Dice.d4(ref random));
                    return MagicItems.Generate(MagicItems.POWER.MEDIUM, ref random);
                case 9:
                    if (Roll < 44)
                        return "";
                    else if (Roll < 92)
                        return MagicItems.Generate(ref random, MagicItems.POWER.MINOR, Dice.d4(ref random));
                    return MagicItems.Generate(MagicItems.POWER.MEDIUM, ref random);
                case 10:
                    if (Roll < 41)
                        return "";
                    else if (Roll < 89)
                        return MagicItems.Generate(ref random, MagicItems.POWER.MINOR, Dice.d4(ref random));
                    else if (Roll < 100)
                        return MagicItems.Generate(MagicItems.POWER.MEDIUM, ref random);
                    return MagicItems.Generate(MagicItems.POWER.MAJOR, ref random);
                case 11:
                    if (Roll < 32)
                        return "";
                    else if (Roll < 85)
                        return MagicItems.Generate(ref random, MagicItems.POWER.MINOR, Dice.d4(ref random));
                    else if (Roll < 99)
                        return MagicItems.Generate(MagicItems.POWER.MEDIUM, ref random);
                    return MagicItems.Generate(MagicItems.POWER.MAJOR, ref random);
                case 12:
                    if (Roll < 28)
                        return "";
                    else if (Roll < 83)
                        return MagicItems.Generate(ref random, MagicItems.POWER.MINOR, Dice.d6(ref random));
                    else if (Roll < 98)
                        return MagicItems.Generate(MagicItems.POWER.MEDIUM, ref random);
                    return MagicItems.Generate(MagicItems.POWER.MAJOR, ref random);
                case 13:
                    if (Roll < 20)
                        return "";
                    else if (Roll < 74)
                        return MagicItems.Generate(ref random, MagicItems.POWER.MINOR, Dice.d6(ref random));
                    else if (Roll < 96)
                        return MagicItems.Generate(MagicItems.POWER.MEDIUM, ref random);
                    return MagicItems.Generate(MagicItems.POWER.MAJOR, ref random);
                case 14:
                    if (Roll < 20)
                        return "";
                    else if (Roll < 59)
                        return MagicItems.Generate(ref random, MagicItems.POWER.MINOR, Dice.d6(ref random));
                    else if (Roll < 93)
                        return MagicItems.Generate(MagicItems.POWER.MEDIUM, ref random);
                    return MagicItems.Generate(MagicItems.POWER.MAJOR, ref random);
                case 15:
                    if (Roll < 12)
                        return "";
                    else if (Roll < 47)
                        return MagicItems.Generate(ref random, MagicItems.POWER.MINOR, Dice.d10(ref random));
                    else if (Roll < 91)
                        return MagicItems.Generate(MagicItems.POWER.MEDIUM, ref random);
                    return MagicItems.Generate(MagicItems.POWER.MAJOR, ref random);
                case 16:
                    if (Roll < 41)
                        return "";
                    else if (Roll < 47)
                        return MagicItems.Generate(ref random, MagicItems.POWER.MINOR, Dice.d10(ref random));
                    else if (Roll < 91)
                        return MagicItems.Generate(ref random, MagicItems.POWER.MEDIUM, Dice.Roll(1, 3, 0, ref random));
                    return MagicItems.Generate(MagicItems.POWER.MAJOR, ref random);
                case 17:
                    if (Roll < 34)
                        return "";
                    else if (Roll < 84)
                        return MagicItems.Generate(ref random, MagicItems.POWER.MEDIUM, Dice.Roll(1, 3, 0, ref random));
                    return MagicItems.Generate(MagicItems.POWER.MAJOR, ref random);
                case 18:
                    if (Roll < 25)
                        return "";
                    else if (Roll < 81)
                        return MagicItems.Generate(ref random, MagicItems.POWER.MEDIUM, Dice.d4(ref random));
                    return MagicItems.Generate(MagicItems.POWER.MAJOR, ref random);
                case 19:
                    if (Roll < 5)
                        return "";
                    else if (Roll < 71)
                        return MagicItems.Generate(ref random, MagicItems.POWER.MEDIUM, Dice.d4(ref random));
                    return MagicItems.Generate(MagicItems.POWER.MAJOR, ref random);
                case 20:
                    if (Roll < 26)
                        return "";
                    else if (Roll < 66)
                        return MagicItems.Generate(ref random, MagicItems.POWER.MEDIUM, Dice.d4(ref random));
                    return MagicItems.Generate(ref random, MagicItems.POWER.MAJOR, Dice.Roll(1, 3, 0, ref random));
                case 21: return String.Format("{0}, {1}", Items(20, ref random), MagicItems.Generate(ref random, MagicItems.POWER.MAJOR, 1));
                case 22: return String.Format("{0}, {1}", Items(20, ref random), MagicItems.Generate(ref random, MagicItems.POWER.MAJOR, 2));
                case 23: return String.Format("{0}, {1}", Items(20, ref random), MagicItems.Generate(ref random, MagicItems.POWER.MAJOR, 4));
                case 24: return String.Format("{0}, {1}", Items(20, ref random), MagicItems.Generate(ref random, MagicItems.POWER.MAJOR, 6));
                case 25: return String.Format("{0}, {1}", Items(20, ref random), MagicItems.Generate(ref random, MagicItems.POWER.MAJOR, 9));
                case 26: return String.Format("{0}, {1}", Items(20, ref random), MagicItems.Generate(ref random, MagicItems.POWER.MAJOR, 12));
                case 27: return String.Format("{0}, {1}", Items(20, ref random), MagicItems.Generate(ref random, MagicItems.POWER.MAJOR, 17));
                case 28: return String.Format("{0}, {1}", Items(20, ref random), MagicItems.Generate(ref random, MagicItems.POWER.MAJOR, 23));
                case 29: return String.Format("{0}, {1}", Items(20, ref random), MagicItems.Generate(ref random, MagicItems.POWER.MAJOR, 31));
                default: return String.Format("{0}, {1}", Items(20, ref random), MagicItems.Generate(ref random, MagicItems.POWER.MAJOR, 42));
            }
        }

        private static string MundaneItems(int Quantity, ref Random random)
        {
            string output = "";

            while (Quantity > 0)
            {
                if (output != "")
                    output += ", ";
                output += MundaneItems(ref random);
                Quantity--;
            }

            return output;
        }

        private static string MundaneItems(ref Random random)
        {
            switch (Dice.Percentile(ref random))
            {
                case 1:
                case 2:
                case 3:
                case 4:
                case 5: return String.Format("{0} flasks of alchemist's fire", Dice.d4(ref random));
                case 6:
                case 7:
                case 8:
                case 9:
                case 10: return String.Format("{0} flasks of acid", Dice.Roll(2, 4, 0, ref random));
                case 11:
                case 12: return String.Format("{0} smokesticks", Dice.d4(ref random));
                case 13:
                case 14:
                case 15:
                case 16:
                case 17:
                case 18: return String.Format("{0} flasks of holy water", Dice.d4(ref random));
                case 19:
                case 20: return String.Format("{0} thunderstones", Dice.d4(ref random));
                case 21:
                case 22:
                    if (Dice.d10(ref random) == 1)
                        return "small chain shirt";
                    return "medium-size chain shirt";
                case 23:
                case 24:
                case 25:
                case 26:
                case 27: return String.Format("{0} vials of antitoxin", Dice.d4(ref random));
                case 28:
                case 29: return String.Format("{0} tanglefoot bags", Dice.d4(ref random));
                case 30:
                case 31:
                case 32:
                case 33:
                case 34:
                    if (Dice.Roll(1, 2, 0, ref random) == 1)
                        return "small suit of masterwork studded leather armor";
                    return "medium-size suit of masterwork studded leather armor";
                case 35:
                case 36:
                case 37:
                case 38:
                case 39:
                    if (Dice.d10(ref random) < 7)
                        return "Mighty +1 composite shortbow";
                    return "Mighty +2 composite shortbow";
                case 40:
                case 41:
                case 42:
                case 43:
                    if (Dice.d10(ref random) == 1)
                        return "small breastplate";
                    return "medium-size breastplate";
                case 44:
                case 45:
                case 46:
                case 47:
                case 48:
                    if (Dice.d10(ref random) == 1)
                        return "small suit of banded mail";
                    return "medium-size suit of banded mail";
                case 67:
                case 68: return "a masterwork " + Weapons.Uncommon(0, MagicItems.POWER.NONE, 0, ref random);
                case 69:
                case 70:
                case 71:
                case 72:
                case 73: return "a masterwork " + Weapons.Ranged(0, MagicItems.POWER.NONE, 0, ref random);
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
                    switch (Dice.Percentile(ref random))
                    {
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
                        case 66:
                        case 67:
                        case 68:
                        case 69:
                        case 70:
                        case 71:
                        case 72:
                        case 73:
                        case 74:
                        case 75: return "Mighty +2 Composite Longbow";
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
                        case 90: return "Mighty +3 Composite Longbow";
                        case 91:
                        case 92:
                        case 93:
                        case 94:
                        case 95:
                        case 96:
                        case 97:
                        case 98:
                        case 99:
                        case 100: return "Mighty +4 Composite Longbow";
                        default: return "Mighty +1 Composite Longbow";
                    }
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
                    if (Dice.d10(ref random) == 1)
                        return "small suit of half-plate";
                    return "medium-size suit of half-plate";
                case 94:
                case 95:
                case 96:
                case 97:
                case 98:
                case 99:
                case 100:
                    if (Dice.d10(ref random) == 1)
                        return "a small suit of full plate";
                    return "a medium-size suit of full plate";
                default: return "a masterwork " + Weapons.Common(0, MagicItems.POWER.NONE, 0, ref random);
            }
        }

        private static string Container(ref Random random)
        {
            switch (Dice.d20(ref random))
            {
                case 1:
                case 2: return " is contained in bags.";
                case 3:
                case 4: return " is contained in sacks.";
                case 5:
                case 6: return " is contained in small coffers.";
                case 7:
                case 8: return " is contained in chests.";
                case 9:
                case 10: return " is contained in huge chests.";
                case 11:
                case 12: return " is contained in pottery jars.";
                case 13:
                case 14: return " is contained in metal urns.";
                case 15:
                case 16: return " is contained in stone containers.";
                case 17:
                case 18: return " is contained in iron trunks.";
                default: return "";
            }
        }

        private static string Hidden(ref Random random)
        {
            switch (Dice.d20(ref random))
            {
                case 1:
                case 2:
                case 3: return " is hidden by an invisibility spell.";
                case 4:
                case 5: return " is hidden by an illusion.";
                case 6: return " is hidden in a secret space under the container.";
                case 7:
                case 8: return " is hidden in a secret compartment in the container.";
                case 9: return " is hidden inside an oridnary item in plain view.";
                case 10: return " is disguised to appear as something else.";
                case 11: return " is hidden under a heap of trash/dung.";
                case 12:
                case 13: return " is hidden under a loose stone in the floor.";
                case 14:
                case 15: return " is hidden behind a loose stone in the wall.";
                default: return " is hidden in a secret room nearby.";
            }
        }
    }
}