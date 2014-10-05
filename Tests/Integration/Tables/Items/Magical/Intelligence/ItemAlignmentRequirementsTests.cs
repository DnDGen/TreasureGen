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
        [TestCase("Rod of the python", IntelligenceAlignmentConstants.Good)]
        [TestCase("Rod of the viper", IntelligenceAlignmentConstants.Evil)]
        [TestCase(WondrousItemConstants.ChaosDiamond, IntelligenceAlignmentConstants.Chaotic)]
        [TestCase(WondrousItemConstants.Darkskull, IntelligenceAlignmentConstants.Evil)]
        [TestCase("Amulet of inescapable location", IntelligenceAlignmentConstants.Evil)]
        [TestCase("Armor of arrow attraction", IntelligenceAlignmentConstants.Evil)]
        [TestCase("Armor of rage", IntelligenceAlignmentConstants.Evil)]
        [TestCase("Boots of dancing", IntelligenceAlignmentConstants.Evil)]
        [TestCase("Bracers of defenselessness", IntelligenceAlignmentConstants.Evil)]
        [TestCase("Broom of animated attack", IntelligenceAlignmentConstants.Evil)]
        [TestCase("Cloak of poisonousness", IntelligenceAlignmentConstants.Evil)]
        [TestCase("Crystal hypnosis ball", IntelligenceAlignmentConstants.Evil)]
        [TestCase("Gauntlets of fumbling", IntelligenceAlignmentConstants.Evil)]
        [TestCase("Medallion of thought projection", IntelligenceAlignmentConstants.Evil)]
        [TestCase("Necklace of strangulation", IntelligenceAlignmentConstants.Evil)]
        [TestCase("Periapt of foul rotting", IntelligenceAlignmentConstants.Evil)]
        [TestCase("Robe of powerlessness", IntelligenceAlignmentConstants.Evil)]
        [TestCase("Robe of vermin", IntelligenceAlignmentConstants.Evil)]
        [TestCase("Ring of clumsiness", IntelligenceAlignmentConstants.Evil)]
        [TestCase("Scarab of death", IntelligenceAlignmentConstants.Evil)]
        [TestCase("Cursed backbiter spear", IntelligenceAlignmentConstants.Evil)]
        [TestCase("Stone of weight", IntelligenceAlignmentConstants.Evil)]
        [TestCase("Vacuous grimoire", IntelligenceAlignmentConstants.Evil)]
        [TestCase("Cursed -2 sword", IntelligenceAlignmentConstants.Evil)]
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
            base.Attributes("Mace of blood", attributes);
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
                "Rod of the python",
                "Rod of the viper",
                WondrousItemConstants.ChaosDiamond,
                WondrousItemConstants.Darkskull,
                "Amulet of inescapable location",
                "Armor of arrow attraction",
                "Armor of rage",
                "Boots of dancing",
                "Bracers of defenselessness",
                "Broom of animated attack",
                "Cloak of poisonousness",
                "Crystal hypnosis ball",
                "Gauntlets of fumbling",
                "Mace of blood",
                "Medallion of thought projection",
                "Necklace of strangulation",
                "Periapt of foul rotting",
                "Robe of powerlessness",
                "Robe of vermin",
                "Ring of clumsiness",
                "Scarab of death",
                "Cursed backbiter spear",
                "Stone of weight",
                "Vacuous grimoire",
                "Cursed -2 sword"
            };

            base.Attributes("Items", items);
        }
    }
}