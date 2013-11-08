using System;
using System.Collections.Generic;
using System.Text;

namespace Dungeon_Maker
{
    class Weapons
    {
        private enum WEAPONTYPE { SLASH, PIERCE, BLUNT };

        public static string Generate(MagicItems.POWER Power, ref Random random)
        {
            return GenerateHelper(Power, 0, ref random);
        }

        private static string GenerateHelper(MagicItems.POWER Power, int Abilities, ref Random random)
        {
            switch (Power)
            {
                case MagicItems.POWER.MINOR:
                    switch (Dice.Percentile(ref random))
                    {
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
                        case 85: return String.Format("+2 {0}", WeaponType(Abilities, Power, 2, ref random));
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
                        case 100: return GenerateHelper(Power, Abilities + 1, ref random);
                        default: return String.Format("+1 {0}", WeaponType(Abilities, Power, 1, ref random));
                    }
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
                        case 10: return String.Format("+1 {0}", WeaponType(Abilities, Power, 1, ref random));
                        case 11:
                        case 12:
                        case 13:
                        case 14:
                        case 15:
                        case 16:
                        case 17:
                        case 18:
                        case 19:
                        case 20: return String.Format("+2 {0}", WeaponType(Abilities, Power, 2, ref random));
                        case 59:
                        case 60:
                        case 61:
                        case 62: return String.Format("+4 {0}", WeaponType(Abilities, Power, 4, ref random));
                        case 63:
                        case 64:
                        case 65:
                        case 66:
                        case 67:
                        case 68: return SpecificWeapon(Power, ref random);
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
                        case 96:
                        case 97:
                        case 98:
                        case 99:
                        case 100: return GenerateHelper(Power, Abilities + 1, ref random);
                        default: return String.Format("+3 {0}", WeaponType(Abilities, Power, 3, ref random));
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
                        case 20: return String.Format("+3 {0}", WeaponType(Abilities, Power, 3, ref random));
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
                        case 38: return String.Format("+4 {0}", WeaponType(Abilities, Power, 4, ref random));
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
                        case 49: return String.Format("+5 {0}", WeaponType(Abilities, Power, 5, ref random));
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
                        case 63: return SpecificWeapon(Power, ref random);
                        default: return GenerateHelper(Power, Abilities + 1, ref random);
                    }
                default: return WeaponType(0, Power, 0, ref random);
            }
        }

        private static string WeaponType(int Abilities, MagicItems.POWER Power, int bonus, ref Random random)
        {
            int Roll = Dice.Percentile(ref random);

            if (Roll < 71)
                return Common(Abilities, Power, bonus, ref random);
            if (Roll < 81)
                return Uncommon(Abilities, Power, bonus, ref random);
            return Ranged(Abilities, Power, bonus, ref random);
        }

        public static string Melee(int bonus, ref Random random)
        {
            if (Dice.d8(ref random) < 8)
                return Common(0, MagicItems.POWER.NONE, bonus, ref random);
            return Uncommon(0, MagicItems.POWER.NONE, bonus, ref random);
        }

        public static string Ranged(int bonus, ref Random random)
        {
            return Ranged(0, MagicItems.POWER.NONE, bonus, ref random);
        }

        public static string Common(int Abilities, MagicItems.POWER Power, int bonus, ref Random random)
        {
            switch (Dice.Percentile(ref random))
            {
                case 1:
                case 2:
                case 3:
                case 4:
                    if (bonus > 0)
                    {
                        if (Abilities > 0)
                            return String.Format("dagger of {0} ({1})", MeleeSpecialAbilities(ref random, Abilities, Power, WEAPONTYPE.SLASH, ref bonus), MeleeSpecialQualities(bonus, ref random));
                        return String.Format("dagger ({0})", MeleeSpecialQualities(bonus, ref random));
                    }
                    return "dagger";
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
                    if (bonus > 0)
                    {
                        if (Abilities > 0)
                            return String.Format("greataxe of {0} ({1})", MeleeSpecialAbilities(ref random, Abilities, Power, WEAPONTYPE.SLASH, ref bonus), MeleeSpecialQualities(bonus, ref random));
                        return String.Format("greataxe ({0})", MeleeSpecialQualities(bonus, ref random));
                    }
                    return "greataxe";
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
                    if (bonus > 0)
                    {
                        if (Abilities > 0)
                            return String.Format("greatsword of {0} ({1})", MeleeSpecialAbilities(ref random, Abilities, Power, WEAPONTYPE.SLASH, ref bonus), MeleeSpecialQualities(bonus, ref random));
                        return String.Format("greatsword ({0})", MeleeSpecialQualities(bonus, ref random));
                    }
                    return "greatsword";
                case 25:
                case 26:
                case 27:
                case 28:
                    if (bonus > 0)
                    {
                        if (Abilities > 0)
                            return String.Format("kama of {0} ({1})", MeleeSpecialAbilities(ref random, Abilities, Power, WEAPONTYPE.SLASH, ref bonus), MeleeSpecialQualities(bonus, ref random));
                        return String.Format("kama ({0})", MeleeSpecialQualities(bonus, ref random));
                    }
                    return "kama";
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
                    if (bonus > 0)
                    {
                        if (Abilities > 0)
                            return String.Format("longsword of {0} ({1})", MeleeSpecialAbilities(ref random, Abilities, Power, WEAPONTYPE.SLASH, ref bonus), MeleeSpecialQualities(bonus, ref random));
                        return String.Format("longsword ({0})", MeleeSpecialQualities(bonus, ref random));
                    }
                    return "longsword";
                case 42:
                case 43:
                case 44:
                case 45:
                    if (bonus > 0)
                    {
                        if (Abilities > 0)
                            return String.Format("light mace of {0} ({1})", MeleeSpecialAbilities(ref random, Abilities, Power, WEAPONTYPE.BLUNT, ref bonus), MeleeSpecialQualities(bonus, ref random));
                        return String.Format("light mace ({0})", MeleeSpecialQualities(bonus, ref random));
                    }
                    return "light mace";
                case 46:
                case 47:
                case 48:
                case 49:
                case 50:
                    if (bonus > 0)
                    {
                        if (Abilities > 0)
                            return String.Format("heavy mace of {0} ({1})", MeleeSpecialAbilities(ref random, Abilities, Power, WEAPONTYPE.BLUNT, ref bonus), MeleeSpecialQualities(bonus, ref random));
                        return String.Format("heavy mace ({0})", MeleeSpecialQualities(bonus, ref random));
                    }
                    return "heavy mace";
                case 51:
                case 52:
                case 53:
                case 54:
                    if (bonus > 0)
                    {
                        if (Abilities > 0)
                            return String.Format("nunchaku of {0} ({1})", MeleeSpecialAbilities(ref random, Abilities, Power, WEAPONTYPE.BLUNT, ref bonus), MeleeSpecialQualities(bonus, ref random));
                        return String.Format("nunchaku ({0})", MeleeSpecialQualities(bonus, ref random));
                    }
                    return "nunchaku";
                case 55:
                case 56:
                case 57:
                    if (bonus == 0)
                        return "quarterstaff";
                    if (Dice.Percentile(ref random) < 51)
                    {
                        if (Abilities > 0)
                            return String.Format("quarterstaff of {0} ({1})", MeleeSpecialAbilities(ref random, Abilities, Power, WEAPONTYPE.BLUNT, ref bonus), MeleeSpecialQualities(bonus, ref random));
                        return String.Format("quarterstaff ({0})", MeleeSpecialQualities(bonus, ref random));
                    }
                    if (Abilities > 0)
                        return String.Format("quarterstaff (one end +{0}, no abilities) of {1} ({2})", bonus - 1, MeleeSpecialAbilities(ref random, Abilities, Power, WEAPONTYPE.BLUNT, ref bonus), MeleeSpecialQualities(bonus, ref random));
                    return String.Format("quarterstaff (one end +{0}, no abilities) ({1})", bonus - 1, MeleeSpecialQualities(bonus, ref random));
                case 58:
                case 59:
                case 60:
                case 61:
                    if (bonus > 0)
                    {
                        if (Abilities > 0)
                            return String.Format("rapier of {0} ({1})", MeleeSpecialAbilities(ref random, Abilities, Power, WEAPONTYPE.PIERCE, ref bonus), MeleeSpecialQualities(bonus, ref random));
                        return String.Format("rapier ({0})", MeleeSpecialQualities(bonus, ref random));
                    }
                    return "rapier";
                case 62:
                case 63:
                case 64:
                case 65:
                case 66:
                    if (bonus > 0)
                    {
                        if (Abilities > 0)
                            return String.Format("scimitar of {0} ({1})", MeleeSpecialAbilities(ref random, Abilities, Power, WEAPONTYPE.SLASH, ref bonus), MeleeSpecialQualities(bonus, ref random));
                        return String.Format("scimitar ({0})", MeleeSpecialQualities(bonus, ref random));
                    }
                    return "scimitar";
                case 67:
                case 68:
                case 69:
                case 70:
                    if (bonus > 0)
                    {
                        if (Abilities > 0)
                            return String.Format("shortspear of {0} ({1})", MeleeSpecialAbilities(ref random, Abilities, Power, WEAPONTYPE.PIERCE, ref bonus), MeleeSpecialQualities(bonus, ref random));
                        return String.Format("shortspear ({0})", MeleeSpecialQualities(bonus, ref random));
                    }
                    return "shortspear";
                case 71:
                case 72:
                case 73:
                case 74:
                    if (bonus > 0)
                    {
                        if (Abilities > 0)
                            return String.Format("siangham of {0} ({1})", MeleeSpecialAbilities(ref random, Abilities, Power, WEAPONTYPE.PIERCE, ref bonus), MeleeSpecialQualities(bonus, ref random));
                        return String.Format("siangham ({0})", MeleeSpecialQualities(bonus, ref random));
                    }
                    return "siangham";
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
                    if (bonus > 0)
                    {
                        if (Abilities > 0)
                            return String.Format("bastard sword of {0} ({1})", MeleeSpecialAbilities(ref random, Abilities, Power, WEAPONTYPE.SLASH, ref bonus), MeleeSpecialQualities(bonus, ref random));
                        return String.Format("bastard sword ({0})", MeleeSpecialQualities(bonus, ref random));
                    }
                    return "bastard sword";
                case 85:
                case 86:
                case 87:
                case 88:
                case 89:
                    if (bonus > 0)
                    {
                        if (Abilities > 0)
                            return String.Format("short sword of {0} ({1})", MeleeSpecialAbilities(ref random, Abilities, Power, WEAPONTYPE.SLASH, ref bonus), MeleeSpecialQualities(bonus, ref random));
                        return String.Format("short sword ({0})", MeleeSpecialQualities(bonus, ref random));
                    }
                    return "short sword";
                default:
                    if (bonus > 0)
                    {
                        if (Abilities > 0)
                            return String.Format("dwarven waraxe of {0} ({1})", MeleeSpecialAbilities(ref random, Abilities, Power, WEAPONTYPE.SLASH, ref bonus), MeleeSpecialQualities(bonus, ref random));
                        return String.Format("dwarven waraxe ({0})", MeleeSpecialQualities(bonus, ref random));
                    }
                    return "dwarven waraxe";
            }
        }

        public static string Uncommon(int Abilities, MagicItems.POWER Power, int bonus, ref Random random)
        {
            switch (Dice.Percentile(ref random))
            {
                case 1:
                case 2:
                case 3:
                    if (bonus == 0)
                        return "orc double axe";
                    if (Dice.Percentile(ref random) < 51)
                    {
                        if (Abilities > 0)
                            return String.Format("orc double axe of {0} ({1})", MeleeSpecialAbilities(ref random, Abilities, Power, WEAPONTYPE.SLASH, ref bonus), MeleeSpecialQualities(bonus, ref random));
                        return String.Format("orc double axe ({0})", MeleeSpecialQualities(bonus, ref random));
                    }
                    if (Abilities > 0)
                        return String.Format("orc double axe (one end +{0}, no abilities) of {1} ({2})", bonus - 1, MeleeSpecialAbilities(ref random, Abilities, Power, WEAPONTYPE.SLASH, ref bonus), MeleeSpecialQualities(bonus, ref random));
                    return String.Format("orc double axe (one end +{0}, no abilities) ({1})", bonus - 1, MeleeSpecialQualities(bonus, ref random));
                case 4:
                case 5:
                case 6:
                case 7:
                    if (bonus > 0)
                    {
                        if (Abilities > 0)
                            return String.Format("battleaxe of {0} ({1})", MeleeSpecialAbilities(ref random, Abilities, Power, WEAPONTYPE.SLASH, ref bonus), MeleeSpecialQualities(bonus, ref random));
                        return String.Format("battleaxe ({0})", MeleeSpecialQualities(bonus, ref random));
                    }
                    return "battleaxe";
                case 8:
                case 9:
                case 10:
                    if (bonus > 0)
                    {
                        if (Abilities > 0)
                            return String.Format("spiked chain of {0} ({1})", MeleeSpecialAbilities(ref random, Abilities, Power, WEAPONTYPE.PIERCE, ref bonus), MeleeSpecialQualities(bonus, ref random));
                        return String.Format("spiked chain ({0})", MeleeSpecialQualities(bonus, ref random));
                    }
                    return "spiked chain";
                case 11:
                case 12:
                    if (bonus > 0)
                    {
                        if (Abilities > 0)
                            return String.Format("club of {0} ({1})", MeleeSpecialAbilities(ref random, Abilities, Power, WEAPONTYPE.BLUNT, ref bonus), MeleeSpecialQualities(bonus, ref random));
                        return String.Format("club ({0})", MeleeSpecialQualities(bonus, ref random));
                    }
                    return "club";
                case 13:
                case 14:
                case 15:
                case 16:
                    if (bonus > 0)
                    {
                        if (Abilities > 0)
                            return String.Format("hand crossbow of {0} ({1})", RangedSpecialAbilities(ref random, Abilities, Power, ref bonus), RangedSpecialQualities(bonus, false, ref random));
                        return String.Format("hand crossbow ({0})", RangedSpecialQualities(bonus, false, ref random));
                    }
                    return "hand crossbow";
                case 17:
                case 18:
                case 19:
                    if (bonus > 0)
                    {
                        if (Abilities > 0)
                            return String.Format("repeating crossbow of {0} ({1})", RangedSpecialAbilities(ref random, Abilities, Power, ref bonus), RangedSpecialQualities(bonus, false, ref random));
                        return String.Format("repeating crossbow ({0})", RangedSpecialQualities(bonus, false, ref random));
                    }
                    return "repeating crossbow";
                case 20:
                case 21:
                    if (bonus > 0)
                    {
                        if (Abilities > 0)
                            return String.Format("punching dagger of {0} ({1})", MeleeSpecialAbilities(ref random, Abilities, Power, WEAPONTYPE.PIERCE, ref bonus), MeleeSpecialQualities(bonus, ref random));
                        return String.Format("punching dagger ({0})", MeleeSpecialQualities(bonus, ref random));
                    }
                    return "punching dagger";
                case 22:
                case 23:
                    if (bonus > 0)
                    {
                        if (Abilities > 0)
                            return String.Format("falchion of {0} ({1})", MeleeSpecialAbilities(ref random, Abilities, Power, WEAPONTYPE.SLASH, ref bonus), MeleeSpecialQualities(bonus, ref random));
                        return String.Format("falchion ({0})", MeleeSpecialQualities(bonus, ref random));
                    }
                    return "falchion";
                case 24:
                case 25:
                case 26:
                    if (bonus == 0)
                        return "dire flail";
                    if (Dice.Percentile(ref random) < 51)
                    {
                        if (Abilities > 0)
                            return String.Format("dire flail of {0} ({1})", MeleeSpecialAbilities(ref random, Abilities, Power, WEAPONTYPE.BLUNT, ref bonus), MeleeSpecialQualities(bonus, ref random));
                        return String.Format("dire flail ({0})", MeleeSpecialQualities(bonus, ref random));
                    }
                    if (Abilities > 0)
                        return String.Format("dire flail (one end +{0}, no abilities) of {1} ({2})", bonus - 1, MeleeSpecialAbilities(ref random, Abilities, Power, WEAPONTYPE.BLUNT, ref bonus), MeleeSpecialQualities(bonus, ref random));
                    return String.Format("dire flail (one end +{0}, no abilities) ({1})", bonus - 1, MeleeSpecialQualities(bonus, ref random));
                case 27:
                case 28:
                case 29:
                case 30:
                case 31:
                    if (bonus > 0)
                    {
                        if (Abilities > 0)
                            return String.Format("heavy flail of {0} ({1})", MeleeSpecialAbilities(ref random, Abilities, Power, WEAPONTYPE.BLUNT, ref bonus), MeleeSpecialQualities(bonus, ref random));
                        return String.Format("heavy flail ({0})", MeleeSpecialQualities(bonus, ref random));
                    }
                    return "heavy flail";
                case 32:
                case 33:
                case 34:
                case 35:
                    if (bonus > 0)
                    {
                        if (Abilities > 0)
                            return String.Format("light flail of {0} ({1})", MeleeSpecialAbilities(ref random, Abilities, Power, WEAPONTYPE.BLUNT, ref bonus), MeleeSpecialQualities(bonus, ref random));
                        return String.Format("light flail ({0})", MeleeSpecialQualities(bonus, ref random));
                    }
                    return "light flail";
                case 36:
                case 37:
                    if (bonus > 0)
                    {
                        if (Abilities > 0)
                            return String.Format("gauntlet of {0} ({1})", MeleeSpecialAbilities(ref random, Abilities, Power, WEAPONTYPE.BLUNT, ref bonus), MeleeSpecialQualities(bonus, ref random));
                        return String.Format("gauntlet ({0})", MeleeSpecialQualities(bonus, ref random));
                    }
                    return "gauntlet";
                case 38:
                case 39:
                    if (bonus > 0)
                    {
                        if (Abilities > 0)
                            return String.Format("spiked gauntlet of {0} ({1})", MeleeSpecialAbilities(ref random, Abilities, Power, WEAPONTYPE.PIERCE, ref bonus), MeleeSpecialQualities(bonus, ref random));
                        return String.Format("spiked gauntlet ({0})", MeleeSpecialQualities(bonus, ref random));
                    }
                    return "spiked gauntlet";
                case 40:
                case 41:
                    if (bonus > 0)
                    {
                        if (Abilities > 0)
                            return String.Format("glaive of {0} ({1})", MeleeSpecialAbilities(ref random, Abilities, Power, WEAPONTYPE.SLASH, ref bonus), MeleeSpecialQualities(bonus, ref random));
                        return String.Format("glaive ({0})", MeleeSpecialQualities(bonus, ref random));
                    }
                    return "glaive";
                case 42:
                case 43:
                    if (bonus > 0)
                    {
                        if (Abilities > 0)
                            return String.Format("greatclub of {0} ({1})", MeleeSpecialAbilities(ref random, Abilities, Power, WEAPONTYPE.BLUNT, ref bonus), MeleeSpecialQualities(bonus, ref random));
                        return String.Format("greatclub ({0})", MeleeSpecialQualities(bonus, ref random));
                    }
                    return "greatclub";
                case 44:
                case 45:
                    if (bonus > 0)
                    {
                        if (Abilities > 0)
                            return String.Format("guisarme of {0} ({1})", MeleeSpecialAbilities(ref random, Abilities, Power, WEAPONTYPE.SLASH, ref bonus), MeleeSpecialQualities(bonus, ref random));
                        return String.Format("guisarme ({0})", MeleeSpecialQualities(bonus, ref random));
                    }
                    return "guisarme";
                case 46:
                case 47:
                case 48:
                    if (bonus > 0)
                    {
                        if (Abilities > 0)
                            return String.Format("halberd of {0} ({1})", MeleeSpecialAbilities(ref random, Abilities, Power, WEAPONTYPE.SLASH, ref bonus), MeleeSpecialQualities(bonus, ref random));
                        return String.Format("halberd ({0})", MeleeSpecialQualities(bonus, ref random));
                    }
                    return "halberd";
                case 49:
                case 50:
                case 51:
                    if (bonus > 0)
                    {
                        if (Abilities > 0)
                            return String.Format("halfspear of {0} ({1})", MeleeSpecialAbilities(ref random, Abilities, Power, WEAPONTYPE.PIERCE, ref bonus), MeleeSpecialQualities(bonus, ref random));
                        return String.Format("halfspear ({0})", MeleeSpecialQualities(bonus, ref random));
                    }
                    return "halfspear";
                case 52:
                case 53:
                case 54:
                    if (bonus == 0)
                        return "gnome hooked hammer";
                    if (Dice.Percentile(ref random) < 51)
                    {
                        if (Abilities > 0)
                            return String.Format("gnome hooked hammer of {0} ({1})", MeleeSpecialAbilities(ref random, Abilities, Power, WEAPONTYPE.BLUNT, ref bonus), MeleeSpecialQualities(bonus, ref random));
                        return String.Format("gnome hooked hammer ({0})", MeleeSpecialQualities(bonus, ref random));
                    }
                    if (Abilities > 0)
                        return String.Format("gnome hooked hammer (one end +{0}, no abilities) of {1} ({2})", bonus - 1, MeleeSpecialAbilities(ref random, Abilities, Power, WEAPONTYPE.BLUNT, ref bonus), MeleeSpecialQualities(bonus, ref random));
                    return String.Format("gnome hooked hammer (one end +{0}, no abilities) ({1})", bonus - 1, MeleeSpecialQualities(bonus, ref random));
                case 55:
                case 56:
                    if (bonus > 0)
                    {
                        if (Abilities > 0)
                            return String.Format("light hammer of {0} ({1})", MeleeSpecialAbilities(ref random, Abilities, Power, WEAPONTYPE.BLUNT, ref bonus), MeleeSpecialQualities(bonus, ref random));
                        return String.Format("light hammer ({0})", MeleeSpecialQualities(bonus, ref random));
                    }
                    return "light hammer";
                case 57:
                case 58:
                    if (bonus > 0)
                    {
                        if (Abilities > 0)
                            return String.Format("handaxe of {0} ({1})", MeleeSpecialAbilities(ref random, Abilities, Power, WEAPONTYPE.SLASH, ref bonus), MeleeSpecialQualities(bonus, ref random));
                        return String.Format("handaxe ({0})", MeleeSpecialQualities(bonus, ref random));
                    }
                    return "handaxe";
                case 59:
                case 60:
                case 61:
                    if (bonus > 0)
                    {
                        if (Abilities > 0)
                            return String.Format("kukri of {0} ({1})", MeleeSpecialAbilities(ref random, Abilities, Power, WEAPONTYPE.SLASH, ref bonus), MeleeSpecialQualities(bonus, ref random));
                        return String.Format("kukri ({0})", MeleeSpecialQualities(bonus, ref random));
                    }
                    return "kukri";
                case 62:
                case 63:
                    if (bonus > 0)
                    {
                        if (Abilities > 0)
                            return String.Format("heavy lance of {0} ({1})", MeleeSpecialAbilities(ref random, Abilities, Power, WEAPONTYPE.PIERCE, ref bonus), MeleeSpecialQualities(bonus, ref random));
                        return String.Format("heavy lance ({0})", MeleeSpecialQualities(bonus, ref random));
                    }
                    return "heavy lance";
                case 64:
                case 65:
                    if (bonus > 0)
                    {
                        if (Abilities > 0)
                            return String.Format("light lance of {0} ({1})", MeleeSpecialAbilities(ref random, Abilities, Power, WEAPONTYPE.PIERCE, ref bonus), MeleeSpecialQualities(bonus, ref random));
                        return String.Format("light lance ({0})", MeleeSpecialQualities(bonus, ref random));
                    }
                    return "light lance";
                case 66:
                case 67:
                    if (bonus > 0)
                    {
                        if (Abilities > 0)
                            return String.Format("longspear of {0} ({1})", MeleeSpecialAbilities(ref random, Abilities, Power, WEAPONTYPE.PIERCE, ref bonus), MeleeSpecialQualities(bonus, ref random));
                        return String.Format("longspear ({0})", MeleeSpecialQualities(bonus, ref random));
                    }
                    return "longspear";
                case 68:
                case 69:
                case 70:
                    if (bonus > 0)
                    {
                        if (Abilities > 0)
                            return String.Format("morningstar of {0} ({1})", MeleeSpecialAbilities(ref random, Abilities, Power, WEAPONTYPE.BLUNT, ref bonus), MeleeSpecialQualities(bonus, ref random));
                        return String.Format("morningstar ({0})", MeleeSpecialQualities(bonus, ref random));
                    }
                    return "morningstar";
                case 71:
                case 72:
                    if (bonus > 0)
                    {
                        if (Abilities > 0)
                            return String.Format("net of {0} ({1})", RangedSpecialAbilities(ref random, Abilities, Power, ref bonus), RangedSpecialQualities(bonus, false, ref random));
                        return String.Format("net ({0})", RangedSpecialQualities(bonus, false, ref random));
                    }
                    return "net";
                case 73:
                case 74:
                    if (bonus > 0)
                    {
                        if (Abilities > 0)
                            return String.Format("heavy pick of {0} ({1})", MeleeSpecialAbilities(ref random, Abilities, Power, WEAPONTYPE.PIERCE, ref bonus), MeleeSpecialQualities(bonus, ref random));
                        return String.Format("heavy pick({0})", MeleeSpecialQualities(bonus, ref random));
                    }
                    return "heavy pick";
                case 75:
                case 76:
                    if (bonus > 0)
                    {
                        if (Abilities > 0)
                            return String.Format("light pick of {0} ({1})", MeleeSpecialAbilities(ref random, Abilities, Power, WEAPONTYPE.PIERCE, ref bonus), MeleeSpecialQualities(bonus, ref random));
                        return String.Format("light pick ({0})", MeleeSpecialQualities(bonus, ref random));
                    }
                    return "light pick";
                case 77:
                case 78:
                    if (bonus > 0)
                    {
                        if (Abilities > 0)
                            return String.Format("ranseur of {0} ({1})", MeleeSpecialAbilities(ref random, Abilities, Power, WEAPONTYPE.PIERCE, ref bonus), MeleeSpecialQualities(bonus, ref random));
                        return String.Format("ranseur ({0})", MeleeSpecialQualities(bonus, ref random));
                    }
                    return "ranseur";
                case 79:
                case 80:
                    if (bonus > 0)
                    {
                        if (Abilities > 0)
                            return String.Format("sap of {0} ({1})", MeleeSpecialAbilities(ref random, Abilities, Power, WEAPONTYPE.BLUNT, ref bonus), MeleeSpecialQualities(bonus, ref random));
                        return String.Format("sap ({0})", MeleeSpecialQualities(bonus, ref random));
                    }
                    return "sap";
                case 81:
                case 82:
                    if (bonus > 0)
                    {
                        if (Abilities > 0)
                            return String.Format("scythe of {0} ({1})", MeleeSpecialAbilities(ref random, Abilities, Power, WEAPONTYPE.SLASH, ref bonus), MeleeSpecialQualities(bonus, ref random));
                        return String.Format("scythe ({0})", MeleeSpecialQualities(bonus, ref random));
                    }
                    return "scythe";
                case 83:
                case 84:
                    if (bonus > 0)
                    {
                        if (Abilities > 0)
                            return String.Format("shuriken of {0} ({1})", RangedSpecialAbilities(ref random, Abilities, Power, ref bonus), RangedSpecialQualities(bonus, false, ref random));
                        return String.Format("shuriken ({0})", RangedSpecialQualities(bonus, false, ref random));
                    }
                    return "shuriken";
                case 85:
                case 86:
                    if (bonus > 0)
                    {
                        if (Abilities > 0)
                            return String.Format("sickle of {0} ({1})", MeleeSpecialAbilities(ref random, Abilities, Power, WEAPONTYPE.SLASH, ref bonus), MeleeSpecialQualities(bonus, ref random));
                        return String.Format("sickle ({0})", MeleeSpecialQualities(bonus, ref random));
                    }
                    return "sickle";
                case 87:
                case 88:
                case 89:
                    if (bonus == 0)
                        return "two-bladed sword";
                    if (Dice.Percentile(ref random) < 51)
                    {
                        if (Abilities > 0)
                            return String.Format("two-bladed sword of {0} ({1})", MeleeSpecialAbilities(ref random, Abilities, Power, WEAPONTYPE.SLASH, ref bonus), MeleeSpecialQualities(bonus, ref random));
                        return String.Format("two-bladed sword ({0})", MeleeSpecialQualities(bonus, ref random));
                    }
                    if (Abilities > 0)
                        return String.Format("two-bladed sword (one end +{0}, no abilities) of {1} ({2})", bonus - 1, MeleeSpecialAbilities(ref random, Abilities, Power, WEAPONTYPE.SLASH, ref bonus), MeleeSpecialQualities(bonus, ref random));
                    return String.Format("two-bladed sword (one end +{0}, no abilities) ({1})", bonus - 1, MeleeSpecialQualities(bonus, ref random));
                case 90:
                case 91:
                    if (bonus > 0)
                    {
                        if (Abilities > 0)
                            return String.Format("trident of {0} ({1})", MeleeSpecialAbilities(ref random, Abilities, Power, WEAPONTYPE.PIERCE, ref bonus), MeleeSpecialQualities(bonus, ref random));
                        return String.Format("trident ({0})", MeleeSpecialQualities(bonus, ref random));
                    }
                    return "trident";
                case 92:
                case 93:
                case 94:
                    if (bonus == 0)
                        return "dwarven urgrosh";
                    if (Dice.Percentile(ref random) < 51)
                    {
                        if (Abilities > 0)
                            return String.Format("dwarven urgrosh of {0} ({1})", MeleeSpecialAbilities(ref random, Abilities, Power, WEAPONTYPE.SLASH, ref bonus), MeleeSpecialQualities(bonus, ref random));
                        return String.Format("dwarven urgrosh ({0})", MeleeSpecialQualities(bonus, ref random));
                    }
                    if (Abilities > 0)
                        return String.Format("dwarven urgrosh (one end +{0}, no abilities) of {1} ({2})", bonus - 1, MeleeSpecialAbilities(ref random, Abilities, Power, WEAPONTYPE.SLASH, ref bonus), MeleeSpecialQualities(bonus, ref random));
                    return String.Format("dwarven urgrosh (one end +{0}, no abilities) ({1})", bonus - 1, MeleeSpecialQualities(bonus, ref random));
                case 95:
                case 96:
                case 97:
                    if (bonus > 0)
                    {
                        if (Abilities > 0)
                            return String.Format("warhammer of {0} ({1})", MeleeSpecialAbilities(ref random, Abilities, Power, WEAPONTYPE.BLUNT, ref bonus), MeleeSpecialQualities(bonus, ref random));
                        return String.Format("warhammer ({0})", MeleeSpecialQualities(bonus, ref random));
                    }
                    return "warhammer";
                default:
                    if (bonus > 0)
                    {
                        if (Abilities > 0)
                            return String.Format("whip of {0} ({1})", MeleeSpecialAbilities(ref random, Abilities, Power, WEAPONTYPE.SLASH, ref bonus), MeleeSpecialQualities(bonus, ref random));
                        return String.Format("whip ({0})", MeleeSpecialQualities(bonus, ref random));
                    }
                    return "whip";
            }
        }

        public static string Ranged(int Abilities, MagicItems.POWER Power, int bonus, ref Random random)
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
                    string ammo; int Roll = Dice.Percentile(ref random);
                    if (Roll < 51)
                    {
                        ammo = "arrows";
                        if (bonus == 0)
                            return String.Format("{0} x50", ammo);
                    }
                    else if (Roll < 81)
                    {
                        ammo = "crossbow bolts";
                        if (bonus == 0)
                            return String.Format("{0} x50", ammo);
                    }
                    else
                    {
                        ammo = "sling bullets";
                        if (bonus == 0)
                            return String.Format("{0} x50", ammo);
                    }
                    if (Abilities > 0)
                        return String.Format("{0} x50 of {1} ({2})", ammo, RangedSpecialAbilities(ref random, Abilities, Power, ref bonus), RangedSpecialQualities(bonus, true, ref random));
                    return String.Format("{0} x50 ({1})", ammo, RangedSpecialQualities(bonus, true, ref random));
                case 11:
                case 12:
                case 13:
                case 14:
                case 15:
                    if (bonus > 0)
                    {
                        if (Abilities > 0)
                            return String.Format("throwing axe of {0} ({1})", RangedSpecialAbilities(ref random, Abilities, Power, ref bonus), RangedSpecialQualities(bonus, false, ref random));
                        return String.Format("throwing axe ({0})", RangedSpecialQualities(bonus, false, ref random));
                    }
                    return "throwing axe";
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
                    if (bonus > 0)
                    {
                        if (Abilities > 0)
                            return String.Format("heavy crossbow of {0} ({1})", RangedSpecialAbilities(ref random, Abilities, Power, ref bonus), RangedSpecialQualities(bonus, false, ref random));
                        return String.Format("heavy crossbow ({0})", RangedSpecialQualities(bonus, false, ref random));
                    }
                    return "heavy crossbow";
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
                    if (bonus > 0)
                    {
                        if (Abilities > 0)
                            return String.Format("light crossbow of {0} ({1})", RangedSpecialAbilities(ref random, Abilities, Power, ref bonus), RangedSpecialQualities(bonus, false, ref random));
                        return String.Format("light crossbow ({0})", RangedSpecialQualities(bonus, false, ref random));
                    }
                    return "light crossbow";
                case 36:
                case 37:
                case 38:
                case 39:
                    if (Abilities > 0)
                        return String.Format("dart of {0} ({1})", RangedSpecialAbilities(ref random, Abilities, Power, ref bonus), RangedSpecialQualities(bonus, true, ref random));
                    if (bonus > 0)
                        return String.Format("dart ({0})", RangedSpecialQualities(bonus, true, ref random));
                    return "dart";
                case 40:
                case 41:
                    if (bonus > 0)
                    {
                        if (Abilities > 0)
                            return String.Format("javelin of {0} ({1})", RangedSpecialAbilities(ref random, Abilities, Power, ref bonus), RangedSpecialQualities(bonus, false, ref random));
                        return String.Format("javelin ({0})", RangedSpecialQualities(bonus, false, ref random));
                    }
                    return "javelin";
                case 42:
                case 43:
                case 44:
                case 45:
                case 46:
                    if (bonus > 0)
                    {
                        if (Abilities > 0)
                            return String.Format("shortbow of {0} ({1})", RangedSpecialAbilities(ref random, Abilities, Power, ref bonus), RangedSpecialQualities(bonus, false, ref random));
                        return String.Format("shortbow ({0})", RangedSpecialQualities(bonus, false, ref random));
                    }
                    return "shortbow";
                case 47:
                case 48:
                case 49:
                case 50:
                case 51:
                    if (bonus > 0)
                    {
                        if (Abilities > 0)
                            return String.Format("composite shortbow of {0} ({1})", RangedSpecialAbilities(ref random, Abilities, Power, ref bonus), RangedSpecialQualities(bonus, false, ref random));
                        return String.Format("composite shortbow ({0})", RangedSpecialQualities(bonus, false, ref random));
                    }
                    return "composite shortbow";
                case 52:
                case 53:
                case 54:
                case 55:
                case 56:
                    if (bonus > 0)
                    {
                        if (Abilities > 0)
                            return String.Format("mighty +1 composite shortbow of {0} ({1})", RangedSpecialAbilities(ref random, Abilities, Power, ref bonus), RangedSpecialQualities(bonus, false, ref random));
                        return String.Format("mighty +1 composite shortbow ({0})", RangedSpecialQualities(bonus, false, ref random));
                    }
                    return "mighty +1 composite shortbow";
                case 57:
                case 58:
                case 59:
                case 60:
                case 61:
                    if (bonus > 0)
                    {
                        if (Abilities > 0)
                            return String.Format("mighty +2 composite shortbow of {0} ({1})", RangedSpecialAbilities(ref random, Abilities, Power, ref bonus), RangedSpecialQualities(bonus, false, ref random));
                        return String.Format("mighty +2 composite shortbow ({0})", RangedSpecialQualities(bonus, false, ref random));
                    }
                    return "mighty +2 composite shortbow";
                case 62:
                case 63:
                case 64:
                case 65:
                    if (bonus > 0)
                    {
                        if (Abilities > 0)
                            return String.Format("sling of {0} ({1})", RangedSpecialAbilities(ref random, Abilities, Power, ref bonus), RangedSpecialQualities(bonus, false, ref random));
                        return String.Format("sling ({0})", RangedSpecialQualities(bonus, false, ref random));
                    }
                    return "sling";
                case 76:
                case 77:
                case 78:
                case 79:
                case 80:
                    if (bonus > 0)
                    {
                        if (Abilities > 0)
                            return String.Format("composite longbow of {0} ({1})", RangedSpecialAbilities(ref random, Abilities, Power, ref bonus), RangedSpecialQualities(bonus, false, ref random));
                        return String.Format("composite longbow ({0})", RangedSpecialQualities(bonus, false, ref random));
                    }
                    return "composite longbow";
                case 81:
                case 82:
                case 83:
                case 84:
                case 85:
                    if (bonus > 0)
                    {
                        if (Abilities > 0)
                            return String.Format("mighty +1 composite longbow of {0} ({1})", RangedSpecialAbilities(ref random, Abilities, Power, ref bonus), RangedSpecialQualities(bonus, false, ref random));
                        return String.Format("mighty +1 composite longbow ({0})", RangedSpecialQualities(bonus, false, ref random));
                    }
                    return "mighty +1 composite longbow";
                case 86:
                case 87:
                case 88:
                case 89:
                case 90:
                    if (bonus > 0)
                    {
                        if (Abilities > 0)
                            return String.Format("mighty +2 composite longbow of {0} ({1})", RangedSpecialAbilities(ref random, Abilities, Power, ref bonus), RangedSpecialQualities(bonus, false, ref random));
                        return String.Format("mighty +2 composite longbow ({0})", RangedSpecialQualities(bonus, false, ref random));
                    }
                    return "mighty +2 composite longbow";
                case 91:
                case 92:
                case 93:
                case 94:
                case 95:
                    if (bonus > 0)
                    {
                        if (Abilities > 0)
                            return String.Format("mighty +3 composite longbow of {0} ({1})", RangedSpecialAbilities(ref random, Abilities, Power, ref bonus), RangedSpecialQualities(bonus, false, ref random));
                        return String.Format("mighty +3 composite longbow ({0})", RangedSpecialQualities(bonus, false, ref random));
                    }
                    return "mighty +3 composite longbow";
                case 96:
                case 97:
                case 98:
                case 99:
                case 100:
                    if (bonus > 0)
                    {
                        if (Abilities > 0)
                            return String.Format("mighty +4 composite longbow of {0} ({1})", RangedSpecialAbilities(ref random, Abilities, Power, ref bonus), RangedSpecialQualities(bonus, false, ref random));
                        return String.Format("mighty +4 composite longbow ({0})", RangedSpecialQualities(bonus, false, ref random));
                    }
                    return "mighty +4 composite longbow";
                default:
                    if (bonus > 0)
                    {
                        if (Abilities > 0)
                            return String.Format("longbow of {0} ({1})", RangedSpecialAbilities(ref random, Abilities, Power, ref bonus), RangedSpecialQualities(bonus, false, ref random));
                        return String.Format("longbow ({0})", RangedSpecialQualities(bonus, false, ref random));
                    }
                    return "longbow";
            }
        }

        private static string MeleeSpecialAbilities(ref Random random, int Quantity, MagicItems.POWER Power, WEAPONTYPE Type, ref int bonus)
        {
            string output = ""; string StoredSpell;

            while (Quantity > 0)
            {
                StoredSpell = "";
                switch (Power)
                {
                    case MagicItems.POWER.MINOR:
                        switch (Dice.Percentile(ref random))
                        {
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
                                if (bonus + 1 < 11)
                                {
                                    output += "flaming, ";
                                    bonus++;
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
                                if (bonus + 1 < 11)
                                {
                                    output += "frost, ";
                                    bonus++;
                                    Quantity--;
                                }
                                break;
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
                                if (bonus + 1 < 11)
                                {
                                    output += "shock, ";
                                    bonus++;
                                    Quantity--;
                                }
                                break;
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
                                if (bonus + 1 < 11)
                                {
                                    output += "ghost touch, ";
                                    bonus++;
                                    Quantity--;
                                }
                                break;
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
                                if (Type == WEAPONTYPE.SLASH && bonus + 1 < 11)
                                {
                                    output += "keen, ";
                                    bonus++;
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
                                if (bonus + 1 < 11)
                                {
                                    output += "mighty cleaving, ";
                                    bonus++;
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
                                if (bonus + 1 < 11)
                                {
                                    if (Dice.Percentile(ref random) <= 50)
                                        StoredSpell = String.Format(" (contains {0}", Scrolls.RandomSpell(ref random, 3));
                                    output += String.Format("spell storing{0}, ", StoredSpell);
                                    bonus++;
                                    Quantity--;
                                }
                                break;
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
                                if (bonus + 1 < 11)
                                {
                                    output += "throwing, ";
                                    bonus++;
                                    Quantity--;
                                }
                                break;
                            case 100: Quantity++; break;
                            default:
                                if (bonus + 1 < 11)
                                {
                                    output += "defending, ";
                                    bonus++;
                                    Quantity--;
                                }
                                break;
                        }
                        break;
                    case MagicItems.POWER.MEDIUM:
                        switch (Dice.Percentile(ref random))
                        {
                            case 11:
                            case 12:
                            case 13:
                            case 14:
                            case 15:
                                if (bonus + 1 < 11)
                                {
                                    output += "flaming, ";
                                    bonus++;
                                    Quantity--;
                                }
                                break;
                            case 16:
                            case 17:
                            case 18:
                            case 19:
                            case 20:
                                if (bonus + 1 < 11)
                                {
                                    output += "frost, ";
                                    bonus++;
                                    Quantity--;
                                }
                                break;
                            case 21:
                            case 22:
                            case 23:
                            case 24:
                            case 25:
                                if (bonus + 1 < 11)
                                {
                                    output += "shock, ";
                                    bonus++;
                                    Quantity--;
                                }
                                break;
                            case 26:
                            case 27:
                            case 28:
                            case 29:
                            case 30:
                                if (bonus + 1 < 11)
                                {
                                    output += "ghost touch, ";
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
                                if (Type == WEAPONTYPE.SLASH && bonus + 1 < 11)
                                {
                                    output += "keen, ";
                                    bonus++;
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
                                if (bonus + 1 < 11)
                                {
                                    output += "mighty cleaving, ";
                                    bonus++;
                                    Quantity--;
                                }
                                break;
                            case 51:
                                if (bonus + 1 < 11)
                                {
                                    if (Dice.Percentile(ref random) <= 50)
                                        StoredSpell = String.Format(" (contains {0}", Scrolls.RandomSpell(ref random, 3));
                                    output += String.Format("spell storing{0}, ", StoredSpell);
                                    bonus++;
                                    Quantity--;
                                }
                                break;
                            case 52:
                            case 53:
                            case 54:
                            case 55:
                            case 56:
                                if (bonus + 1 < 11)
                                {
                                    output += "throwing, ";
                                    bonus++;
                                    Quantity--;
                                }
                                break;
                            case 57:
                            case 58:
                            case 59:
                                if (bonus + 2 < 11)
                                {
                                    output += String.Format("bane ({0}), ", Character.CreatureType(ref random));
                                    bonus += 2;
                                    Quantity--;
                                }
                                break;
                            case 60:
                            case 61:
                            case 62:
                                if (Type == WEAPONTYPE.BLUNT && bonus + 2 < 11)
                                {
                                    output += "disruption, ";
                                    bonus += 2;
                                    Quantity--;
                                }
                                break;
                            case 63:
                            case 64:
                            case 65:
                                if (bonus + 2 < 11)
                                {
                                    output += "flaming burst, ";
                                    bonus += 2;
                                    Quantity--;
                                }
                                break;
                            case 66:
                            case 67:
                            case 68:
                                if (bonus + 2 < 11)
                                {
                                    output += "icy burst, ";
                                    bonus += 2;
                                    Quantity--;
                                }
                                break;
                            case 69:
                            case 70:
                            case 71:
                                if (bonus + 2 < 11)
                                {
                                    output += "shocking burst, ";
                                    bonus += 2;
                                    Quantity--;
                                }
                                break;
                            case 72:
                            case 73:
                            case 74:
                            case 75:
                            case 76:
                                if (bonus + 2 < 11)
                                {
                                    output += "thundering, ";
                                    bonus += 2;
                                    Quantity--;
                                }
                                break;
                            case 77:
                            case 78:
                            case 79:
                                if (bonus + 2 < 11)
                                {
                                    output += "wounding, ";
                                    bonus += 2;
                                    Quantity--;
                                }
                                break;
                            case 80:
                            case 81:
                            case 82:
                                if (bonus + 2 < 11)
                                {
                                    output += "holy, ";
                                    bonus += 2;
                                    Quantity--;
                                }
                                break;
                            case 83:
                            case 84:
                            case 85:
                                if (bonus + 2 < 11)
                                {
                                    output += "unholy, ";
                                    bonus += 2;
                                    Quantity--;
                                }
                                break;
                            case 86:
                            case 87:
                            case 88:
                                if (bonus + 2 < 11)
                                {
                                    output += "lawful, ";
                                    bonus += 2;
                                    Quantity--;
                                }
                                break;
                            case 89:
                            case 90:
                            case 91:
                                if (bonus + 2 < 11)
                                {
                                    output += "chaotic, ";
                                    bonus += 2;
                                    Quantity--;
                                }
                                break;
                            case 92:
                                if (bonus + 4 < 11)
                                {
                                    output += "brilliant energy, ";
                                    bonus += 4;
                                    Quantity--;
                                }
                                break;
                            case 93:
                                if (bonus + 4 < 11)
                                {
                                    output += "dancing, ";
                                    bonus += 4;
                                    Quantity--;
                                }
                                break;
                            case 94:
                            case 95:
                                if (bonus + 4 < 11)
                                {
                                    output += "speed, ";
                                    bonus += 4;
                                    Quantity--;
                                }
                                break;
                            case 96:
                            case 97:
                            case 98:
                            case 99:
                            case 100: Quantity++; break;
                            default:
                                if (bonus + 1 < 11)
                                {
                                    output += "defending, ";
                                    bonus++;
                                    Quantity--;
                                }
                                break;
                        }
                        break;
                    case MagicItems.POWER.MAJOR:
                        switch (Dice.Percentile(ref random))
                        {
                            case 1:
                            case 2:
                            case 3:
                                if (bonus + 1 < 11)
                                {
                                    output += "flaming, ";
                                    bonus++;
                                    Quantity--;
                                }
                                break;
                            case 4:
                            case 5:
                            case 6:
                                if (bonus + 1 < 11)
                                {
                                    output += "frost, ";
                                    bonus++;
                                    Quantity--;
                                }
                                break;
                            case 7:
                            case 8:
                            case 9:
                                if (bonus + 1 < 11)
                                {
                                    output += "shock, ";
                                    bonus++;
                                    Quantity--;
                                }
                                break;
                            case 10:
                            case 11:
                            case 12:
                                if (bonus + 1 < 11)
                                {
                                    output += "ghost touch, ";
                                    bonus++;
                                    Quantity--;
                                }
                                break;
                            case 13:
                            case 14:
                            case 15:
                            case 16:
                            case 17:
                                if (bonus + 1 < 11)
                                {
                                    output += "mighty cleaving, ";
                                    bonus++;
                                    Quantity--;
                                }
                                break;
                            case 18:
                            case 19:
                                if (bonus + 1 < 11)
                                {
                                    if (Dice.Percentile(ref random) <= 50)
                                        StoredSpell = String.Format(" (contains {0}", Scrolls.RandomSpell(ref random, 3));
                                    output += String.Format("spell storing{0}, ", StoredSpell);
                                    bonus++;
                                    Quantity--;
                                }
                                break;
                            case 20:
                            case 21:
                                if (bonus + 1 < 11)
                                {
                                    output += "throwing, ";
                                    bonus++;
                                    Quantity--;
                                }
                                break;
                            case 22:
                            case 23:
                            case 24:
                            case 25:
                            case 26:
                                if (bonus + 2 < 11)
                                {
                                    output += String.Format("bane ({0}), ", Character.CreatureType(ref random));
                                    bonus += 2;
                                    Quantity--;
                                }
                                break;
                            case 27:
                            case 28:
                            case 29:
                                if (Type == WEAPONTYPE.BLUNT && bonus + 2 < 11)
                                {
                                    output += "disruption, ";
                                    bonus += 2;
                                    Quantity--;
                                }
                                break;
                            case 30:
                            case 31:
                            case 32:
                            case 33:
                                if (bonus + 2 < 11)
                                {
                                    output += "flaming burst, ";
                                    bonus += 2;
                                    Quantity--;
                                }
                                break;
                            case 34:
                            case 35:
                            case 36:
                            case 37:
                                if (bonus + 2 < 11)
                                {
                                    output += "icy burst, ";
                                    bonus += 2;
                                    Quantity--;
                                }
                                break;
                            case 38:
                            case 39:
                            case 40:
                            case 41:
                                if (bonus + 2 < 11)
                                {
                                    output += "shocking burst, ";
                                    bonus += 2;
                                    Quantity--;
                                }
                                break;
                            case 42:
                            case 43:
                            case 44:
                                if (bonus + 2 < 11)
                                {
                                    output += "thundering, ";
                                    bonus += 2;
                                    Quantity--;
                                }
                                break;
                            case 45:
                            case 46:
                            case 47:
                                if (bonus + 2 < 11)
                                {
                                    output += "wounding, ";
                                    bonus += 2;
                                    Quantity--;
                                }
                                break;
                            case 48:
                            case 49:
                            case 50:
                            case 51:
                            case 52:
                                if (bonus + 2 < 11)
                                {
                                    output += "holy, ";
                                    bonus += 2;
                                    Quantity--;
                                }
                                break;
                            case 53:
                            case 54:
                            case 55:
                            case 56:
                            case 57:
                                if (bonus + 2 < 11)
                                {
                                    output += "unholy, ";
                                    bonus += 2;
                                    Quantity--;
                                }
                                break;
                            case 58:
                            case 59:
                            case 60:
                            case 61:
                            case 62:
                                if (bonus + 2 < 11)
                                {
                                    output += "lawful, ";
                                    bonus += 2;
                                    Quantity--;
                                }
                                break;
                            case 63:
                            case 64:
                            case 65:
                            case 66:
                            case 67:
                                if (bonus + 2 < 11)
                                {
                                    output += "chaotic, ";
                                    bonus += 2;
                                    Quantity--;
                                }
                                break;
                            case 68:
                            case 69:
                            case 70:
                            case 71:
                                if (bonus + 4 < 11)
                                {
                                    output += "brilliant energy, ";
                                    bonus += 4;
                                    Quantity--;
                                }
                                break;
                            case 72:
                            case 73:
                                if (bonus + 4 < 11)
                                {
                                    output += "dancing, ";
                                    bonus += 4;
                                    Quantity--;
                                }
                                break;
                            case 74:
                            case 75:
                            case 76:
                                if (bonus + 4 < 11)
                                {
                                    output += "speed, ";
                                    bonus += 4;
                                    Quantity--;
                                }
                                break;
                            case 77:
                            case 78:
                            case 79:
                            case 80:
                                if (Type == WEAPONTYPE.SLASH && bonus + 5 < 11)
                                {
                                    output += "vorpal, ";
                                    bonus += 5;
                                    Quantity--;
                                }
                                break;
                            default: Quantity++; break;
                        }
                        break;
                    default: return "ERROR: NONPOWERED MELEE WEAPON ABILITY.  Weapons.1574";
                }

                if (bonus == 10)
                    return output;
            }

            return output;
        }

        private static string RangedSpecialAbilities(ref Random random, int Quantity, MagicItems.POWER Power, ref int bonus)
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
                                if (bonus + 1 < 11)
                                {
                                    output += "returning, ";
                                    bonus++;
                                    Quantity--;
                                }
                                break;
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
                                if (bonus + 1 < 11)
                                {
                                    output += "distance, ";
                                    bonus++;
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
                                    output += "flaming, ";
                                    bonus++;
                                    Quantity--;
                                }
                                break;
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
                                if (bonus + 1 < 11)
                                {
                                    output += "shock, ";
                                    bonus++;
                                    Quantity--;
                                }
                                break;
                            default:
                                if (bonus + 1 < 11)
                                {
                                    output += "frost, ";
                                    bonus++;
                                    Quantity--;
                                }
                                break;
                        }
                        break;
                    case MagicItems.POWER.MEDIUM:
                        switch (Dice.Percentile(ref random))
                        {
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
                                    output += "distance, ";
                                    bonus++;
                                    Quantity--;
                                }
                                break;
                            case 31:
                            case 32:
                            case 33:
                            case 34:
                            case 35:
                                if (bonus + 1 < 11)
                                {
                                    output += "flaming, ";
                                    bonus++;
                                    Quantity--;
                                }
                                break;
                            case 36:
                            case 37:
                            case 38:
                            case 39:
                            case 40:
                                if (bonus + 1 < 11)
                                {
                                    output += "shock, ";
                                    bonus++;
                                    Quantity--;
                                }
                                break;
                            case 41:
                            case 42:
                            case 43:
                            case 44:
                            case 45:
                                if (bonus + 1 < 11)
                                {
                                    output += "frost, ";
                                    bonus++;
                                    Quantity--;
                                }
                                break;
                            case 46:
                            case 47:
                            case 48:
                            case 49:
                            case 50:
                                if (bonus + 2 < 11)
                                {
                                    output += "flaming burst, ";
                                    bonus += 2;
                                    Quantity--;
                                }
                                break;
                            case 51:
                            case 52:
                            case 53:
                            case 54:
                            case 55:
                                if (bonus + 2 < 11)
                                {
                                    output += "icy burst, ";
                                    bonus += 2;
                                    Quantity--;
                                }
                                break;
                            case 56:
                            case 57:
                            case 58:
                            case 59:
                            case 60:
                                if (bonus + 2 < 11)
                                {
                                    output += "shocking burst, ";
                                    bonus += 2;
                                    Quantity--;
                                }
                                break;
                            case 61:
                            case 62:
                            case 63:
                            case 64:
                            case 65:
                            case 66:
                                if (bonus + 2 < 11)
                                {
                                    output += String.Format("bane ({0}), ", Character.CreatureType(ref random));
                                    bonus += 2;
                                    Quantity--;
                                }
                                break;
                            case 67:
                            case 68:
                            case 69:
                            case 70:
                            case 71:
                            case 72:
                            case 73:
                            case 74:
                                if (bonus + 2 < 11)
                                {
                                    output += "holy, ";
                                    bonus += 2;
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
                                if (bonus + 2 < 11)
                                {
                                    output += "unholy, ";
                                    bonus += 2;
                                    Quantity--;
                                }
                                break;
                            case 83:
                            case 84:
                            case 85:
                            case 86:
                            case 87:
                            case 88:
                            case 89:
                            case 90:
                                if (bonus + 2 < 11)
                                {
                                    output += "lawful, ";
                                    bonus += 2;
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
                                if (bonus + 2 < 11)
                                {
                                    output += "chaotic, ";
                                    bonus += 2;
                                    Quantity--;
                                }
                                break;
                            case 99:
                            case 100: Quantity++; break;
                            default:
                                if (bonus + 1 < 11)
                                {
                                    output += "returning, ";
                                    bonus++;
                                    Quantity--;
                                }
                                break;
                        }
                        break;
                    case MagicItems.POWER.MAJOR:
                        switch(Dice.Percentile(ref random))
                        {
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
                                if (bonus + 1 < 11)
                                {
                                    output += "shock, ";
                                    bonus++;
                                    Quantity--;
                                }
                                break;
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
                                    output += "frost, ";
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
                                if (bonus + 2 < 11)
                                {
                                    output += "flaming burst, ";
                                    bonus += 2;
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
                                if (bonus + 2 < 11)
                                {
                                    output += "icy burst, ";
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
                                if (bonus + 2 < 11)
                                {
                                    output += "shocking burst, ";
                                    bonus += 2;
                                    Quantity--;
                                }
                                break;
                            case 61:
                            case 62:
                            case 63:
                            case 64:
                            case 65:
                                if (bonus + 2 < 11)
                                {
                                    output += String.Format("bane ({0}), ", Character.CreatureType(ref random));
                                    bonus += 2;
                                    Quantity--;
                                }
                                break;
                            case 66:
                            case 67:
                            case 68:
                            case 69:
                            case 70:
                                if (bonus + 2 < 11)
                                {
                                    output += "holy, ";
                                    bonus += 2;
                                    Quantity--;
                                }
                                break;
                            case 71:
                            case 72:
                            case 73:
                            case 74:
                            case 75:
                                if (bonus + 2 < 11)
                                {
                                    output += "unholy, ";
                                    bonus += 2;
                                    Quantity--;
                                }
                                break;
                            case 76:
                            case 77:
                            case 78:
                            case 79:
                            case 80:
                                if (bonus + 2 < 11)
                                {
                                    output += "lawful, ";
                                    bonus += 2;
                                    Quantity--;
                                }
                                break;
                            case 81:
                            case 82:
                            case 83:
                            case 84:
                            case 85:
                                if (bonus + 2 < 11)
                                {
                                    output += "chaotic, ";
                                    bonus += 2;
                                    Quantity--;
                                }
                                break;
                            case 86:
                            case 87:
                            case 88:
                            case 89:
                            case 90:
                                if (bonus + 4 < 11)
                                {
                                    output += "speed, ";
                                    bonus += 4;
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
                                if (bonus + 4 < 11)
                                {
                                    output += "brilliant energy, ";
                                    bonus += 4;
                                    Quantity--;
                                }
                                break;
                            case 98:
                            case 99:
                            case 100: Quantity++; break;
                            default:
                                if (bonus + 1 < 11)
                                {
                                    output += "flaming, ";
                                    bonus++;
                                    Quantity--;
                                }
                                break;
                        }
                        break;
                    default: return "ERROR: NONPOWERED RANGED WEAPON ABILITY.  Weapons.2082";        
                }

                if (bonus == 10)
                    return output;
            }

            return output;
        }

        private static string MeleeSpecialQualities(int bonus, ref Random random)
        {
            int Roll = Dice.Percentile(ref random);

            if (Roll < 21)
                return "Sheds light";
            if (Roll < 26)
                return Intelligence.Generate(bonus, ref random);
            if (Roll < 36)
                return String.Format("Sheds light, {0}", Intelligence.Generate(bonus, ref random));
            if (Roll < 51)
                return "Markings";
            return "";
        }

        private static string RangedSpecialQualities(int bonus, bool Ammunition, ref Random random)
        {
            int Roll = Dice.Percentile(ref random);

            if (Roll < 6 && !Ammunition)
                return Intelligence.Generate(bonus, ref random);
            if (Roll < 26)
                return "Markings";
            return "";
        }

        private static string SpecificWeapon(MagicItems.POWER Power, ref Random random)
        {
            int bonus;

            switch (Power)
            {
                case MagicItems.POWER.MEDIUM:
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
                            bonus = 0;
                            return String.Format("screaming bolt ({0})", RangedSpecialQualities(bonus, true, ref random));
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
                            bonus = 0;
                            return String.Format("javelin of lightning ({0})", RangedSpecialQualities(bonus, true, ref random));
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
                            bonus = 1;
                            return String.Format("slaying arrow ({0}, {1})", Character.CreatureType(ref random), RangedSpecialQualities(bonus, true, ref random));
                        case 66:
                        case 67:
                        case 68:
                        case 69:
                        case 70:
                            bonus = 0;
                            return "adamantine dagger";
                        case 71:
                        case 72:
                            bonus = 1;
                            return String.Format("trident of fish command ({0})", MeleeSpecialQualities(bonus, ref random));
                        case 73:
                        case 74:
                            bonus = 2;
                            return String.Format("dagger of venom ({0})", MeleeSpecialQualities(bonus, ref random));
                        case 75:
                        case 76:
                            bonus = 0;
                            return "adamantine battleaxe";
                        case 77:
                        case 78:
                        case 79:
                            bonus = 2;
                            return String.Format("trident of warning ({0})", MeleeSpecialQualities(bonus, ref random));
                        case 80:
                        case 81:
                        case 82:
                            bonus = 2;
                            return String.Format("assassin's dagger ({0})", MeleeSpecialQualities(bonus, ref random));
                        case 83:
                        case 84:
                        case 85:
                            bonus = 2;
                            return String.Format("sword of subtlety ({0})", MeleeSpecialQualities(bonus, ref random));
                        case 86:
                        case 87:
                        case 88:
                            bonus = 2;
                            return String.Format("mace of terror ({0})", MeleeSpecialQualities(bonus, ref random));
                        case 89:
                        case 90:
                        case 91:
                            bonus = 3;
                            return String.Format("nine lives stealer ({0} charges left, {1})", Dice.Roll(1, 10, -1, ref random), MeleeSpecialQualities(bonus, ref random));
                        case 92:
                        case 93:
                        case 94:
                            bonus = 3;
                            return String.Format("oathbow ({0})", RangedSpecialQualities(bonus, false, ref random));
                        case 95:
                        case 96:
                            bonus = 3;
                            return String.Format("sword of life stealing ({0})", MeleeSpecialQualities(bonus, ref random));
                        case 97:
                        case 98:
                            bonus = 4;
                            return String.Format("flame tongue ({0})", MeleeSpecialQualities(bonus, ref random));
                        case 99:
                        case 100:
                            bonus = 4;
                            return String.Format("life-drinker ({0})", MeleeSpecialQualities(bonus, ref random));
                        default:
                            bonus = 0;
                            return String.Format("sleep arrow ({0})", RangedSpecialQualities(bonus, true, ref random));
                    }
                case MagicItems.POWER.MAJOR:
                    switch (Dice.Percentile(ref random))
                    {
                        case 1:
                        case 2:
                        case 3:
                        case 4:
                            bonus = 0;
                            return String.Format("javelin of lightning ({0})", RangedSpecialQualities(bonus, true, ref random));
                        case 5:
                        case 6:
                        case 7:
                        case 8:
                        case 9:
                            bonus = 1;
                            return String.Format("slaying arrow ({0}, {1})", Character.CreatureType(ref random), RangedSpecialQualities(bonus, true, ref random));
                        case 10:
                        case 11:
                            bonus = 1;
                            return String.Format("trident of fish command ({0})", MeleeSpecialQualities(bonus, ref random));
                        case 12:
                        case 13:
                            bonus = 1;
                            return String.Format("greater slaying arrow ({0}, {1})", Character.CreatureType(ref random), RangedSpecialQualities(bonus, true, ref random));
                        case 14:
                        case 15:
                        case 16:
                        case 17:
                            bonus = 2;
                            return String.Format("dagger of venom ({0})", MeleeSpecialQualities(bonus, ref random));
                        case 18:
                        case 19:
                        case 20:
                            bonus = 0;
                            return "adamantine battleaxe";
                        case 21:
                        case 22:
                        case 23:
                        case 24:
                        case 25:
                            bonus = 2;
                            return String.Format("trident of warning ({0})", MeleeSpecialQualities(bonus, ref random));
                        case 26:
                        case 27:
                        case 28:
                        case 29:
                        case 30:
                            bonus = 2;
                            return String.Format("assassin's dagger ({0})", MeleeSpecialQualities(bonus, ref random));
                        case 31:
                        case 32:
                        case 33:
                        case 34:
                        case 35:
                            bonus = 2;
                            return String.Format("sword of subtlety ({0})", MeleeSpecialQualities(bonus, ref random));
                        case 36:
                        case 37:
                        case 38:
                        case 39:
                        case 40:
                            bonus = 2;
                            return String.Format("mace of terror ({0})", MeleeSpecialQualities(bonus, ref random));
                        case 41:
                        case 42:
                        case 43:
                        case 44:
                        case 45:
                            bonus = 3;
                            return String.Format("nine lives stealer ({0} charges left, {1})", Dice.Roll(1, 10, -1, ref random), MeleeSpecialQualities(bonus, ref random));
                        case 46:
                        case 47:
                        case 48:
                        case 49:
                        case 50:
                            bonus = 3;
                            return String.Format("oathbow ({0})", RangedSpecialQualities(bonus, false, ref random));
                        case 51:
                        case 52:
                        case 53:
                        case 54:
                        case 55:
                            bonus = 3;
                            return String.Format("sword of life stealing ({0})", MeleeSpecialQualities(bonus, ref random));
                        case 56:
                        case 57:
                        case 58:
                        case 59:
                        case 60:
                            bonus = 4;
                            return String.Format("flame tongue ({0})", MeleeSpecialQualities(bonus, ref random));
                        case 61:
                        case 62:
                        case 63:
                        case 64:
                        case 65:
                        case 66:
                            bonus = 4;
                            return String.Format("life-drinker ({0})", MeleeSpecialQualities(bonus, ref random));
                        case 67:
                        case 68:
                        case 69:
                        case 70:
                        case 71:
                        case 72:
                            bonus = 4;
                            return String.Format("frost brand ({0})", MeleeSpecialQualities(bonus, ref random));
                        case 73:
                        case 74:
                        case 75:
                        case 76:
                        case 77:
                        case 78:
                            bonus = 5;
                            return String.Format("rapier of puncturing ({0})", MeleeSpecialQualities(bonus, ref random));
                        case 79:
                        case 80:
                        case 81:
                            bonus = 5;
                            return String.Format("sun blade ({0})", MeleeSpecialQualities(bonus, ref random));
                        case 82:
                        case 83:
                            bonus = 5;
                            return String.Format("sword of the planes ({0})", MeleeSpecialQualities(bonus, ref random));
                        case 84:
                        case 85:
                            bonus = 5;
                            return String.Format("sylvan scimitar ({0})", MeleeSpecialQualities(bonus, ref random));
                        case 86:
                        case 87:
                            bonus = 5;
                            return String.Format("dwarven thrower ({0})", MeleeSpecialQualities(bonus, ref random));
                        case 88:
                        case 89:
                        case 90:
                            bonus = 6;
                            return String.Format("mace of smiting ({0})", MeleeSpecialQualities(bonus, ref random));
                        case 91:
                        case 92:
                        case 93:
                        case 94:
                        case 95:
                        case 96:
                            bonus = 7;
                            return String.Format("holy avenger ({0})", MeleeSpecialQualities(bonus, ref random));
                        default:
                            bonus = 9;
                            return String.Format("luck blade ({0} wishes, {1})", Dice.Roll(1, 6, -1, ref random), MeleeSpecialQualities(bonus, ref random));
                    }
                default: return "ERROR: NONPOWERED OR MINOR SPECIFIC WEAPON.  Weapons.3407";
            }
        }
    }
}