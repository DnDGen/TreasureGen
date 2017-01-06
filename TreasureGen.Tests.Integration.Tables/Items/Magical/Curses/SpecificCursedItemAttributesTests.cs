using NUnit.Framework;
using TreasureGen.Domain.Tables;
using TreasureGen.Items;
using TreasureGen.Items.Magical;

namespace TreasureGen.Tests.Integration.Tables.Items.Magical.Curses
{
    [TestFixture]
    public class SpecificCursedItemAttributesTests : CollectionsTests
    {
        protected override string tableName
        {
            get { return TableNameConstants.Collections.Set.SpecificCursedItemAttributes; }
        }

        [TestCase(WondrousItemConstants.IncenseOfObsession,
            AttributeConstants.OneTimeUse,
            AttributeConstants.Specific)]
        [TestCase(RingConstants.Clumsiness,
            AttributeConstants.Specific)]
        [TestCase(WondrousItemConstants.AmuletOfInescapableLocation,
            AttributeConstants.Specific)]
        [TestCase(WondrousItemConstants.StoneOfWeight_Loadstone,
            AttributeConstants.Specific)]
        [TestCase(WondrousItemConstants.BracersOfDefenselessness,
            AttributeConstants.Specific)]
        [TestCase(WondrousItemConstants.GauntletsOfFumbling,
            AttributeConstants.Specific)]
        [TestCase(WeaponConstants.CursedMinus2Sword,
            AttributeConstants.Specific,
            AttributeConstants.Melee,
            AttributeConstants.Metal,
            AttributeConstants.Slashing)]
        [TestCase(ArmorConstants.ArmorOfRage,
            AttributeConstants.Metal,
            AttributeConstants.Specific)]
        [TestCase(WondrousItemConstants.MedallionOfThoughtProjection,
            AttributeConstants.Specific)]
        [TestCase(WondrousItemConstants.FlaskOfCurses,
            AttributeConstants.Specific,
            AttributeConstants.OneTimeUse)]
        [TestCase(WondrousItemConstants.DustOfSneezingAndChoking,
            AttributeConstants.Specific,
            AttributeConstants.OneTimeUse)]
        [TestCase(PotionConstants.Poison,
            AttributeConstants.Specific,
            AttributeConstants.OneTimeUse)]
        [TestCase(WondrousItemConstants.RobeOfPowerlessness,
            AttributeConstants.Specific)]
        [TestCase(WeaponConstants.CursedBackbiterSpear,
            AttributeConstants.Specific,
            AttributeConstants.Melee,
            AttributeConstants.Metal,
            AttributeConstants.Piercing,
            AttributeConstants.Ranged,
            AttributeConstants.Thrown)]
        [TestCase(ArmorConstants.ArmorOfArrowAttraction,
            AttributeConstants.Specific,
            AttributeConstants.Metal)]
        [TestCase(WeaponConstants.NetOfSnaring,
            AttributeConstants.Specific,
            AttributeConstants.Ranged,
            AttributeConstants.Thrown,
            AttributeConstants.TwoHanded)]
        [TestCase(WondrousItemConstants.BagOfDevouring,
            AttributeConstants.Specific)]
        [TestCase(WeaponConstants.MaceOfBlood,
            AttributeConstants.Specific,
            AttributeConstants.Melee,
            AttributeConstants.Bludgeoning)]
        [TestCase(WondrousItemConstants.RobeOfVermin,
            AttributeConstants.Specific)]
        [TestCase(WondrousItemConstants.PeriaptOfFoulRotting,
            AttributeConstants.Specific)]
        [TestCase(WeaponConstants.BerserkingSword,
            AttributeConstants.Specific,
            AttributeConstants.Melee,
            AttributeConstants.Metal,
            AttributeConstants.Slashing,
            AttributeConstants.TwoHanded)]
        [TestCase(WondrousItemConstants.BootsOfDancing,
            AttributeConstants.Specific)]
        [TestCase(WondrousItemConstants.HelmOfOppositeAlignment,
            AttributeConstants.Specific)]
        [TestCase(WondrousItemConstants.BroomOfAnimatedAttack,
            AttributeConstants.Specific)]
        [TestCase(WondrousItemConstants.VacousGrimoire,
            AttributeConstants.Specific)]
        [TestCase(WondrousItemConstants.CrystalBall_Hypnosis,
            AttributeConstants.Specific)]
        [TestCase(WondrousItemConstants.NecklaceOfStrangulation,
            AttributeConstants.Specific)]
        [TestCase(WondrousItemConstants.CloakOfPoisonousness,
            AttributeConstants.Specific)]
        [TestCase(WondrousItemConstants.ScarabOfDeath,
            AttributeConstants.Specific)]
        public override void Collections(string name, params string[] attributes)
        {
            base.Collections(name, attributes);
        }
    }
}