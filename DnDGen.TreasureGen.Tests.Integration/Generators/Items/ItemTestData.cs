using DnDGen.TreasureGen.Items;
using DnDGen.TreasureGen.Items.Magical;
using DnDGen.TreasureGen.Items.Mundane;
using NUnit.Framework;
using System.Collections;

namespace DnDGen.TreasureGen.Tests.Integration.Generators.Items
{
    public class ItemTestData
    {
        public static IEnumerable AlchemicalItems
        {
            get
            {
                var alchemicalItems = AlchemicalItemConstants.GetAllAlchemicalItems();

                foreach (var alchemicalItem in alchemicalItems)
                {
                    yield return new TestCaseData(alchemicalItem);
                }
            }
        }

        public static IEnumerable Armors
        {
            get
            {
                var armors = ArmorConstants.GetAllArmorsAndShields(true);

                foreach (var armor in armors)
                {
                    yield return new TestCaseData(armor);
                }
            }
        }

        public static IEnumerable Potions
        {
            get
            {
                var potions = PotionConstants.GetAllPotions();

                foreach (var potion in potions)
                {
                    yield return new TestCaseData(potion);
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
                    yield return new TestCaseData(ring);
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
                    yield return new TestCaseData(rod);
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
                    yield return new TestCaseData(staff);
                }
            }
        }

        public static IEnumerable Tools
        {
            get
            {
                var tools = ToolConstants.GetAllTools();

                foreach (var tool in tools)
                {
                    yield return new TestCaseData(tool);
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
                    yield return new TestCaseData(weapon);
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
                    yield return new TestCaseData(wondrousItem);
                }
            }
        }
    }
}
