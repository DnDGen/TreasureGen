using System;
using System.Collections.Generic;
using System.Text;

namespace Dungeon_Maker
{
    class Dice
    {
        public static int Roll(int Number, int dNumber, int Plus, ref Random random)
        {
            int total = 0;
            while (Number > 0)
            {
                total += random.Next(0, dNumber) + 1;
                Number--;
            }

            return total + Plus;
        }

        public static int Percentile(ref Random random)
        {
            return Roll(1, 100, 0, ref random);
        }

        public static int d20(ref Random random)
        {
            return Roll(1, 20, 0, ref random);
        }

        public static int d12(ref Random random)
        {
            return Roll(1, 12, 0, ref random);
        }

        public static int d10(ref Random random)
        {
            return Roll(1, 10, 0, ref random);
        }

        public static int d8(ref Random random)
        {
            return Roll(1, 8, 0, ref random);
        }

        public static int d6(ref Random random)
        {
            return Roll(1, 6, 0, ref random);
        }

        public static int d4(ref Random random)
        {
            return Roll(1, 4, 0, ref random);
        }

        public static int Roll(int dNumber, int Plus, string Modifier, ref Random random)
        {
            if (Modifier == null)
                return Roll(1, dNumber, Plus, ref random);

            switch (dNumber)
            {
                case 1:
                    switch (Modifier)
                    {
                        case "4": return Roll(1, 4, 2, ref random);
                        case "3/2": return Roll(1, 2, 0, ref random);
                        case "2": return Roll(1, 3, 0, ref random);
                        case "3": return Roll(1, 3, 1, ref random);
                        default: return 1;
                    }
                case 2:
                    switch (Modifier)
                    {
                        case "4": return Roll(1, 6, 3, ref random);
                        case "3/2": return Roll(1, 3, 0, ref random);
                        case "2": return Roll(1, 3, 1, ref random);
                        case "3": return Roll(1, 4, 2, ref random);
                        default: return 1;
                    }
                case 3:
                    if (Plus == 0)
                    {
                        switch (Modifier)
                        {
                            case "4": return Roll(1, 6, 5, ref random);
                            case "3/2": return Roll(1, 3, 1, ref random);
                            case "2": return Roll(1, 4, 2, ref random);
                            case "3": return Roll(1, 6, 3, ref random);
                            case "2/3": return Roll(1, 2, 0, ref random);
                            default: return 1;
                        }
                    }
                    else
                    {
                        switch (Modifier)
                        {
                            case "4": return Roll(1, 4, 10, ref random);
                            case "3/2": return Roll(1, 4, 2, ref random);
                            case "2": return Roll(1, 6, 3, ref random);
                            case "3": return Roll(1, 6, 5, ref random);
                            case "2/3": return Roll(1, 3, 0, ref random);
                            case "1/2": return Roll(1, 2, 0, ref random);
                            default: return 1;
                        }
                    }
                case 4:
                    switch (Modifier)
                    {
                        case "4": return 0;
                        case "3/2": return Roll(1, 6, 3, ref random);
                        case "2": return Roll(1, 6, 5, ref random);
                        case "3": return Roll(1, 4, 10, ref random);
                        case "2/3": return Roll(1, 3, 1, ref random);
                        case "1/2": return Roll(1, 3, 0, ref random);
                        default: return Roll(1, 2, 0, ref random);
                    }
                default:
                    if (Plus == 3)
                    {
                        switch (Modifier)
                        {
                            case "3/2": return Roll(1, 6, 5, ref random);
                            case "2": return Roll(1, 4, 10, ref random);
                            case "2/3": return Roll(1, 4, 2, ref random);
                            case "1/2": return Roll(1, 3, 1, ref random);
                            case "1/3": return Roll(1, 3, 0, ref random);
                            default: return 0;
                        }
                    }
                    else
                    {
                        switch (Modifier)
                        {
                            case "3/2": return Roll(1, 4, 10, ref random);
                            case "2/3": return Roll(1, 6, 5, ref random);
                            case "1/2": return Roll(1, 4, 2, ref random);
                            case "1/3": return Roll(1, 3, 1, ref random);
                            default: return 0;
                        }
                    }
            }
        }
    }
}