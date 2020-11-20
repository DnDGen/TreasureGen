using DnDGen.TreasureGen.Items;
using DnDGen.TreasureGen.Items.Magical;
using DnDGen.TreasureGen.Items.Mundane;
using NUnit.Framework;
using System.Collections;
using System.Linq;

namespace DnDGen.TreasureGen.Tests.Integration.Generators.Items
{
    public class ItemTestData
    {
        public static IEnumerable AlchemicalItems => AlchemicalItemConstants.GetAllAlchemicalItems().Select(i => new TestCaseData(i));
        public static IEnumerable Armors => ArmorConstants.GetAllArmorsAndShields(true).Select(i => new TestCaseData(i));
        public static IEnumerable ArmorsNoSpecific => ArmorConstants.GetAllArmorsAndShields(false).Select(i => new TestCaseData(i));
        public static IEnumerable Potions => PotionConstants.GetAllPotions(true).Select(i => new TestCaseData(i));
        public static IEnumerable Rings => RingConstants.GetAllRings().Select(i => new TestCaseData(i));
        public static IEnumerable Rods => RodConstants.GetAllRods().Select(i => new TestCaseData(i));
        public static IEnumerable Staffs => StaffConstants.GetAllStaffs().Select(i => new TestCaseData(i));
        public static IEnumerable Tools => ToolConstants.GetAllTools().Select(i => new TestCaseData(i));
        public static IEnumerable Weapons => WeaponConstants.GetAllWeapons(true, true).Select(i => new TestCaseData(i));
        public static IEnumerable WeaponsNoSpecific => WeaponConstants.GetAllWeapons(false, true).Select(i => new TestCaseData(i));
        public static IEnumerable WondrousItems => WondrousItemConstants.GetAllWondrousItems().Select(i => new TestCaseData(i));
    }
}
