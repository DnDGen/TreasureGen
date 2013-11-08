using System;
using System.Collections.Generic;
using System.Text;

namespace Dungeon_Maker
{
    class Artifact
    {
        public static string Generate(ref Random random)
        {
            switch (Dice.Roll(1, 3, 0, ref random))
            {
                case 1:
                case 2: return MinorArtifact(ref random);
                case 3: return MajorArtifact(ref random);
                default: return "[Error: Artifact Generate out of range.  Artifact.16]";
            }
        }

        private static string MinorArtifact(ref Random random)
        {
            switch (Dice.Roll(1, 13, 0, ref random))
            {
                case 1: return "a Book of Infinite Spells (minor artifact)";
                case 2: return "a Deck of Many Things (minor artifact)";
                case 3: return "a Hammer of Thunderbolts (minor artifact)";
                case 4: return "a Philosopher's Stone (minor artifact)";
                case 5: return "a Sphere of Annihilation (minor artifact)";
                case 6: return "a Staff of the Magi (minor artifact)";
                case 7: return "a Talisman of Pure Good (minor artifact)";
                case 8: return "a Taisman of the Sphere (minor artifact)";
                case 9: return "a Talisman of Reluctant Wishes (minor artifact)";
                case 10: return "a Talisman of Ultimate Evil (minor artifact)";
                case 11: return "a Book of Exalted Deeds (minor artifact)";
                case 12: return "a Book of Vile Darkness (minor artifact)";
                case 13: return "a Talisman of Zagy (minor artifact)";
                default: return "[Error: Minor Artifact out of range.  Artifact.37]";
            }
        }

        private static string MajorArtifact(ref Random random)
        {
            switch (Dice.Roll(1, 7, 0, ref random))
            {
                case 1: return "The Moaning Diamond (major artifact)";
                case 2: return OrbsofDragonkind(ref random);
                case 3: return "The Saint's Mace (major artifact)";
                case 4: return "The Shadowstaff (major artifact)";
                case 5: return "The Shield of the Sun (major artifact)";
                case 6:
                    if (Dice.Roll(1, 2, 0, ref random) == 1)
                        return "The Hand of Vecna (major artifact)";
                    return "The Eye of Vecna (major artifact)";
                case 7: return "The Sword of Kas (major artifact)";
                default: return "[Error, Major Artifact out of range.  Artifact.55]";
            }
        }

        private static string OrbsofDragonkind(ref Random random)
        {
            switch (Dice.d10(ref random))
            {
                case 1: return "The Black Dragon Orb of Dragonkind (major artifact)";
                case 2: return "The Blue Dragon Orb of Dragonkind (major artifact)";
                case 3: return "the Brass Dragon Orb of Dragonkind (major artifact)";
                case 4: return "the Bronze Dragon Orb of Dragonkind (major artifact)";
                case 5: return "the Copper Dragon Orb of Dragonkind (major artifact)";
                case 6: return "the Gold Dragon Orb of Dragonkind (major artifact)";
                case 7: return "the Green Dragon Orb of Dragonkind (major artifact)";
                case 8: return "the Red Dragon Orb of Dragonkind (major artifact)";
                case 9: return "the Silver Dragon Orb of Dragonkind (major artifact)";
                case 10: return "the White Dragon Orb of Dragonkind (major artifact)";
                default: return "[Error, Orbs of Dragonkind out of range.  Artifact.73]";
            }
        }
    }
}
