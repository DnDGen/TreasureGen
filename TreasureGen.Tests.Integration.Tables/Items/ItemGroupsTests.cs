using NUnit.Framework;
using TreasureGen.Domain.Tables;
using TreasureGen.Items;
using TreasureGen.Items.Magical;

namespace TreasureGen.Tests.Integration.Tables.Items
{
    [TestFixture]
    public class ItemGroupsTests : CollectionsTests
    {
        protected override string tableName
        {
            get
            {
                return TableNameConstants.Collections.Set.ItemGroups;
            }
        }

        [TestCase(AttributeConstants.Shield,
            ArmorConstants.AbsorbingShield,
            ArmorConstants.CastersShield,
            ArmorConstants.LionsShield,
            ArmorConstants.SpinedShield,
            ArmorConstants.WingedShield)]
        [TestCase(ItemTypeConstants.Armor,
            ArmorConstants.ArmorOfArrowAttraction,
            ArmorConstants.ArmorOfRage,
            ArmorConstants.BandedMailOfLuck,
            ArmorConstants.BreastplateOfCommand,
            ArmorConstants.CelestialArmor,
            ArmorConstants.DemonArmor,
            ArmorConstants.DwarvenPlate,
            ArmorConstants.ElvenChain,
            ArmorConstants.FullPlateOfSpeed,
            ArmorConstants.PlateArmorOfTheDeep,
            ArmorConstants.RhinoHide,
            ArmorConstants.AbsorbingShield,
            ArmorConstants.CastersShield,
            ArmorConstants.LionsShield,
            ArmorConstants.SpinedShield,
            ArmorConstants.WingedShield)]
        public void ItemGroup(string name, params string[] items)
        {
            base.Collections(name, items);
        }

        [Test]
        public void WeaponGroup()
        {
            var items = new[]
            {
                WeaponConstants.AssassinsDagger,
                WeaponConstants.BerserkingSword,
                WeaponConstants.CursedBackbiterSpear,
                WeaponConstants.CursedMinus2Sword,
                WeaponConstants.DaggerOfVenom,
                WeaponConstants.DwarvenThrower,
                WeaponConstants.FlameTongue,
                WeaponConstants.FrostBrand,
                WeaponConstants.GreaterSlayingArrow,
                WeaponConstants.HolyAvenger,
                WeaponConstants.JavelinOfLightning,
                WeaponConstants.LifeDrinker,
                WeaponConstants.LuckBlade,
                WeaponConstants.MaceOfBlood,
                WeaponConstants.MaceOfSmiting,
                WeaponConstants.MaceOfTerror,
                WeaponConstants.NetOfSnaring,
                WeaponConstants.NineLivesStealer,
                WeaponConstants.RapierOfPuncturing,
                WeaponConstants.ScreamingBolt,
                WeaponConstants.Shatterspike,
                WeaponConstants.ShiftersSorrow,
                WeaponConstants.SlayingArrow,
                WeaponConstants.SleepArrow,
                WeaponConstants.SunBlade,
                WeaponConstants.SwordOfLifeStealing,
                WeaponConstants.SwordOfSubtlety,
                WeaponConstants.SwordOfThePlanes,
                WeaponConstants.SylvanScimitar,
                WeaponConstants.TridentOfFishCommand,
                WeaponConstants.TridentOfWarning,
                WeaponConstants.Oathbow
            };

            base.Collections(ItemTypeConstants.Weapon, items);
        }

        [Test]
        public void SpecificItems()
        {
            var items = new[]
            {
                ArmorConstants.AbsorbingShield,
                ArmorConstants.ArmorOfArrowAttraction,
                ArmorConstants.ArmorOfRage,
                ArmorConstants.BandedMailOfLuck,
                ArmorConstants.BreastplateOfCommand,
                ArmorConstants.CastersShield,
                ArmorConstants.CelestialArmor,
                ArmorConstants.DemonArmor,
                ArmorConstants.DwarvenPlate,
                ArmorConstants.ElvenChain,
                ArmorConstants.FullPlateOfSpeed,
                ArmorConstants.LionsShield,
                ArmorConstants.PlateArmorOfTheDeep,
                ArmorConstants.RhinoHide,
                ArmorConstants.SpinedShield,
                ArmorConstants.WingedShield,
                WeaponConstants.AssassinsDagger,
                WeaponConstants.BerserkingSword,
                WeaponConstants.CursedBackbiterSpear,
                WeaponConstants.CursedMinus2Sword,
                WeaponConstants.DaggerOfVenom,
                WeaponConstants.DwarvenThrower,
                WeaponConstants.FlameTongue,
                WeaponConstants.FrostBrand,
                WeaponConstants.GreaterSlayingArrow,
                WeaponConstants.HolyAvenger,
                WeaponConstants.JavelinOfLightning,
                WeaponConstants.LifeDrinker,
                WeaponConstants.LuckBlade,
                WeaponConstants.MaceOfBlood,
                WeaponConstants.MaceOfSmiting,
                WeaponConstants.MaceOfTerror,
                WeaponConstants.NetOfSnaring,
                WeaponConstants.NineLivesStealer,
                WeaponConstants.RapierOfPuncturing,
                WeaponConstants.ScreamingBolt,
                WeaponConstants.Shatterspike,
                WeaponConstants.ShiftersSorrow,
                WeaponConstants.SlayingArrow,
                WeaponConstants.SleepArrow,
                WeaponConstants.SunBlade,
                WeaponConstants.SwordOfLifeStealing,
                WeaponConstants.SwordOfSubtlety,
                WeaponConstants.SwordOfThePlanes,
                WeaponConstants.SylvanScimitar,
                WeaponConstants.TridentOfFishCommand,
                WeaponConstants.TridentOfWarning,
                WeaponConstants.Oathbow,
                RingConstants.Clumsiness,
                WondrousItemConstants.AmuletOfInescapableLocation,
                WondrousItemConstants.BagOfDevouring,
                WondrousItemConstants.BracersOfDefenselessness,
                WondrousItemConstants.BroomOfAnimatedAttack,
                WondrousItemConstants.CloakOfPoisonousness,
                WondrousItemConstants.DustOfSneezingAndChoking,
                WondrousItemConstants.RobeOfVermin,
                WondrousItemConstants.CrystalBall_Hypnosis,
                WondrousItemConstants.ScarabOfDeath,
                WondrousItemConstants.NecklaceOfStrangulation,
                WondrousItemConstants.BootsOfDancing,
                WondrousItemConstants.StoneOfWeight_Loadstone,
                WondrousItemConstants.PeriaptOfFoulRotting,
                WondrousItemConstants.GauntletsOfFumbling,
                WondrousItemConstants.VacousGrimoire,
                WondrousItemConstants.MedallionOfThoughtProjection,
                WondrousItemConstants.IncenseOfObsession,
                WondrousItemConstants.HelmOfOppositeAlignment,
                WondrousItemConstants.FlaskOfCurses,
                WondrousItemConstants.RobeOfPowerlessness,
                WeaponConstants.MaceOfBlood
            };

            base.Collections(AttributeConstants.Specific, items);
        }

        [Test]
        public void SpecificCursedItems()
        {
            var items = new[]
            {
                ArmorConstants.ArmorOfArrowAttraction,
                ArmorConstants.ArmorOfRage,
                WeaponConstants.BerserkingSword,
                WeaponConstants.CursedBackbiterSpear,
                WeaponConstants.CursedMinus2Sword,
                WeaponConstants.NetOfSnaring,
                RingConstants.Clumsiness,
                WondrousItemConstants.AmuletOfInescapableLocation,
                WondrousItemConstants.BagOfDevouring,
                WondrousItemConstants.BracersOfDefenselessness,
                WondrousItemConstants.BroomOfAnimatedAttack,
                WondrousItemConstants.CloakOfPoisonousness,
                WondrousItemConstants.DustOfSneezingAndChoking,
                WondrousItemConstants.RobeOfVermin,
                WondrousItemConstants.CrystalBall_Hypnosis,
                WondrousItemConstants.ScarabOfDeath,
                WondrousItemConstants.NecklaceOfStrangulation,
                WondrousItemConstants.BootsOfDancing,
                WondrousItemConstants.StoneOfWeight_Loadstone,
                WondrousItemConstants.PeriaptOfFoulRotting,
                WondrousItemConstants.GauntletsOfFumbling,
                WondrousItemConstants.VacousGrimoire,
                WondrousItemConstants.MedallionOfThoughtProjection,
                WondrousItemConstants.IncenseOfObsession,
                WondrousItemConstants.HelmOfOppositeAlignment,
                WondrousItemConstants.FlaskOfCurses,
                WondrousItemConstants.RobeOfPowerlessness,
                WeaponConstants.MaceOfBlood
            };

            base.Collections(CurseConstants.SpecificCursedItem, items);
        }
    }
}
