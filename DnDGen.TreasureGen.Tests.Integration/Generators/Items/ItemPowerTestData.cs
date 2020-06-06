using DnDGen.TreasureGen.Items;
using DnDGen.TreasureGen.Items.Magical;
using NUnit.Framework;
using System.Collections;
using System.Collections.Generic;

namespace DnDGen.TreasureGen.Tests.Integration.Generators.Items
{
    public class ItemPowerTestData
    {
        private static IEnumerable<string> powers = new[]
        {
            PowerConstants.Minor,
            PowerConstants.Medium,
            PowerConstants.Major,
        };

        public static IEnumerable Armors
        {
            get
            {
                var armors = ArmorConstants.GetAllArmorsAndShields(true);

                foreach (var armor in armors)
                {
                    foreach (var power in powers)
                    {
                        yield return new TestCaseData(armor, power);
                    }
                }
            }
        }

        public static IEnumerable Potions
        {
            get
            {
                var potions = PotionConstants.GetAllPotions(true);

                foreach (var potion in potions)
                {
                    foreach (var power in powers)
                    {
                        yield return new TestCaseData(potion, power);
                    }
                }
            }
        }

        public static IEnumerable Rings
        {
            get
            {
                var rings = RingConstants.GetAllRings();

                foreach (var ring in rings)
                {
                    foreach (var power in powers)
                    {
                        yield return new TestCaseData(ring, power);
                    }
                }
            }
        }

        public static IEnumerable Rods
        {
            get
            {
                var rods = RodConstants.GetAllRods();

                foreach (var rod in rods)
                {
                    foreach (var power in powers)
                    {
                        yield return new TestCaseData(rod, power);
                    }
                }
            }
        }

        public static IEnumerable Staffs
        {
            get
            {
                var staffs = StaffConstants.GetAllStaffs();

                foreach (var staff in staffs)
                {
                    foreach (var power in powers)
                    {
                        yield return new TestCaseData(staff, power);
                    }
                }
            }
        }

        public static IEnumerable Weapons
        {
            get
            {
                var weapons = WeaponConstants.GetAllWeapons(true, true);

                foreach (var weapon in weapons)
                {
                    foreach (var power in powers)
                    {
                        yield return new TestCaseData(weapon, power);
                    }
                }
            }
        }

        public static IEnumerable WondrousItems
        {
            get
            {
                var wondrousItems = WondrousItemConstants.GetAllWondrousItems();

                foreach (var wondrousItem in wondrousItems)
                {
                    foreach (var power in powers)
                    {
                        yield return new TestCaseData(wondrousItem, power);
                    }
                }
            }
        }
    }
}
