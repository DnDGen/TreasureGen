using System;
using EquipmentGen.Common.Items;
using EquipmentGen.Tables.Interfaces;
using NUnit.Framework;

namespace EquipmentGen.Tests.Integration.Tables.Items.Magical.Intelligence
{
    [TestFixture]
    public class ItemAlignmentRequirementsTests : AttributesTests
    {
        protected override String tableName
        {
            get { return TableNameConstants.Attributes.Set.ItemAlignmentRequirements; }
        }

        [TestCase(ArmorConstants.CelestialArmor, IntelligenceAlignmentConstants.Evil)]
        [TestCase(ArmorConstants.DemonArmor, IntelligenceAlignmentConstants.Evil)]
        [TestCase(WeaponConstants.AssassinsDagger, IntelligenceAlignmentConstants.Evil)]
        [TestCase(WeaponConstants.NineLivesStealer, IntelligenceAlignmentConstants.Evil)]
        [TestCase(WeaponConstants.SunBlade, IntelligenceAlignmentConstants.Good)]
        [TestCase(RodConstants.Python, IntelligenceAlignmentConstants.Good)]
        [TestCase(RodConstants.Viper, IntelligenceAlignmentConstants.Evil)]
        [TestCase(WondrousItemConstants.ChaosDiamond, IntelligenceAlignmentConstants.Chaotic)]
        [TestCase(WondrousItemConstants.Darkskull, IntelligenceAlignmentConstants.Evil)]
        [TestCase(WondrousItemConstants.AmuletOfInescapableLocation, IntelligenceAlignmentConstants.Evil)]
        [TestCase(ArmorConstants.ArmorOfArrowAttraction, IntelligenceAlignmentConstants.Evil)]
        [TestCase(ArmorConstants.ArmorOfRage, IntelligenceAlignmentConstants.Evil)]
        [TestCase(WondrousItemConstants.BootsOfDancing, IntelligenceAlignmentConstants.Evil)]
        [TestCase(WondrousItemConstants.BracersOfDefenselessness, IntelligenceAlignmentConstants.Evil)]
        [TestCase(WondrousItemConstants.BroomOfAnimatedAttack, IntelligenceAlignmentConstants.Evil)]
        [TestCase(WondrousItemConstants.CloakOfPoisonousness, IntelligenceAlignmentConstants.Evil)]
        [TestCase(WondrousItemConstants.CrystalBall_Hypnosis, IntelligenceAlignmentConstants.Evil)]
        [TestCase(WondrousItemConstants.GauntletsOfFumbling, IntelligenceAlignmentConstants.Evil)]
        [TestCase(WondrousItemConstants.MedallionOfThoughtProjection, IntelligenceAlignmentConstants.Evil)]
        [TestCase(WondrousItemConstants.NecklaceOfStrangulation, IntelligenceAlignmentConstants.Evil)]
        [TestCase(WondrousItemConstants.PeriaptOfFoulRotting, IntelligenceAlignmentConstants.Evil)]
        [TestCase(WondrousItemConstants.RobeOfPowerlessness, IntelligenceAlignmentConstants.Evil)]
        [TestCase(WondrousItemConstants.RobeOfVermin, IntelligenceAlignmentConstants.Evil)]
        [TestCase(RingConstants.Clumsiness, IntelligenceAlignmentConstants.Evil)]
        [TestCase(WondrousItemConstants.ScarabOfDeath, IntelligenceAlignmentConstants.Evil)]
        [TestCase(WeaponConstants.CursedBackbiterSpear, IntelligenceAlignmentConstants.Evil)]
        [TestCase(WondrousItemConstants.StoneOfWeight_Loadstone, IntelligenceAlignmentConstants.Evil)]
        [TestCase(WondrousItemConstants.VacousGrimoire, IntelligenceAlignmentConstants.Evil)]
        [TestCase(WeaponConstants.CursedMinus2Sword, IntelligenceAlignmentConstants.Evil)]
        public override void Attributes(String name, params String[] attributes)
        {
            base.Attributes(name, attributes);
        }

        [Test]
        public void HolyAvengerAlignmentRequirement()
        {
            var attributes = new[] { IntelligenceAlignmentConstants.LawfulGood };
            base.Attributes(WeaponConstants.HolyAvenger, attributes);
        }

        [Test]
        public void MaceOfBloodAlignmentRequirement()
        {
            var attributes = new[] { IntelligenceAlignmentConstants.ChaoticEvil };
            base.Attributes(WeaponConstants.MaceOfBlood, attributes);
        }

        [Test]
        public void ItemsWithAlignmentRequirements()
        {
            var items = new[]
            {
                ArmorConstants.CelestialArmor,
                ArmorConstants.DemonArmor,
                WeaponConstants.AssassinsDagger,
                WeaponConstants.HolyAvenger,
                WeaponConstants.NineLivesStealer,
                WeaponConstants.SunBlade,
                RodConstants.Python,
                RodConstants.Viper,
                WondrousItemConstants.ChaosDiamond,
                WondrousItemConstants.Darkskull,
                WondrousItemConstants.AmuletOfInescapableLocation,
                ArmorConstants.ArmorOfArrowAttraction,
                ArmorConstants.ArmorOfRage,
                WondrousItemConstants.BootsOfDancing,
                WondrousItemConstants.BracersOfDefenselessness,
                WondrousItemConstants.BroomOfAnimatedAttack,
                WondrousItemConstants.CloakOfPoisonousness,
                WondrousItemConstants.CrystalBall_Hypnosis,
                WondrousItemConstants.GauntletsOfFumbling,
                WeaponConstants.MaceOfBlood,
                WondrousItemConstants.MedallionOfThoughtProjection,
                WondrousItemConstants.NecklaceOfStrangulation,
                WondrousItemConstants.PeriaptOfFoulRotting,
                WondrousItemConstants.RobeOfPowerlessness,
                WondrousItemConstants.RobeOfVermin,
                RingConstants.Clumsiness,
                WondrousItemConstants.ScarabOfDeath,
                WeaponConstants.CursedBackbiterSpear,
                WondrousItemConstants.StoneOfWeight_Loadstone,
                WondrousItemConstants.VacousGrimoire,
                WeaponConstants.CursedMinus2Sword
            };

            base.Attributes("Items", items);
        }
    }
}