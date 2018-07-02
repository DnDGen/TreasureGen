using NUnit.Framework;
using TreasureGen.Tables;
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

        [TestCase(ArmorConstants.ArmorOfArrowAttraction,
            AttributeConstants.Specific,
            AttributeConstants.Metal)]
        [TestCase(ArmorConstants.ArmorOfRage,
            AttributeConstants.Metal,
            AttributeConstants.Specific)]
        [TestCase(PotionConstants.Poison,
            AttributeConstants.Specific,
            AttributeConstants.OneTimeUse)]
        [TestCase(RingConstants.Clumsiness, AttributeConstants.Specific)]
        [TestCase(WeaponConstants.BerserkingSword,
            AttributeConstants.Specific,
            AttributeConstants.Melee,
            AttributeConstants.Metal,
            AttributeConstants.TwoHanded)]
        [TestCase(WeaponConstants.CursedBackbiterSpear,
            AttributeConstants.Specific,
            AttributeConstants.Melee,
            AttributeConstants.Wood,
            AttributeConstants.Metal,
            AttributeConstants.Ranged,
            AttributeConstants.Thrown)]
        [TestCase(WeaponConstants.CursedMinus2Sword,
            AttributeConstants.Specific,
            AttributeConstants.Melee,
            AttributeConstants.Metal)]
        [TestCase(WeaponConstants.MaceOfBlood,
            AttributeConstants.Specific,
            AttributeConstants.Melee)]
        [TestCase(WeaponConstants.NetOfSnaring,
            AttributeConstants.Specific,
            AttributeConstants.Ranged,
            AttributeConstants.Thrown,
            AttributeConstants.TwoHanded)]
        [TestCase(WondrousItemConstants.AmuletOfInescapableLocation, AttributeConstants.Specific)]
        [TestCase(WondrousItemConstants.BagOfDevouring, AttributeConstants.Specific)]
        [TestCase(WondrousItemConstants.BootsOfDancing, AttributeConstants.Specific)]
        [TestCase(WondrousItemConstants.BracersOfDefenselessness, AttributeConstants.Specific)]
        [TestCase(WondrousItemConstants.BroomOfAnimatedAttack, AttributeConstants.Specific)]
        [TestCase(WondrousItemConstants.CloakOfPoisonousness, AttributeConstants.Specific)]
        [TestCase(WondrousItemConstants.CrystalBall_Hypnosis, AttributeConstants.Specific)]
        [TestCase(WondrousItemConstants.DustOfSneezingAndChoking,
            AttributeConstants.Specific,
            AttributeConstants.OneTimeUse)]
        [TestCase(WondrousItemConstants.FlaskOfCurses,
            AttributeConstants.Specific,
            AttributeConstants.OneTimeUse)]
        [TestCase(WondrousItemConstants.GauntletsOfFumbling, AttributeConstants.Specific)]
        [TestCase(WondrousItemConstants.HelmOfOppositeAlignment, AttributeConstants.Specific)]
        [TestCase(WondrousItemConstants.IncenseOfObsession,
            AttributeConstants.OneTimeUse,
            AttributeConstants.Specific)]
        [TestCase(WondrousItemConstants.MedallionOfThoughtProjection, AttributeConstants.Specific)]
        [TestCase(WondrousItemConstants.NecklaceOfStrangulation, AttributeConstants.Specific)]
        [TestCase(WondrousItemConstants.PeriaptOfFoulRotting, AttributeConstants.Specific)]
        [TestCase(WondrousItemConstants.RobeOfPowerlessness, AttributeConstants.Specific)]
        [TestCase(WondrousItemConstants.RobeOfVermin, AttributeConstants.Specific)]
        [TestCase(WondrousItemConstants.ScarabOfDeath, AttributeConstants.Specific)]
        [TestCase(WondrousItemConstants.StoneOfWeight_Loadstone, AttributeConstants.Specific)]
        [TestCase(WondrousItemConstants.VacousGrimoire, AttributeConstants.Specific)]
        public void SpecificCursedItemAttributes(string name, params string[] attributes)
        {
            base.Collections(name, attributes);
        }
    }
}