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

        [TestCase(ArmorConstants.CelestialArmor, "good")]
        [TestCase(ArmorConstants.DemonArmor, "evil")]
        [TestCase(WeaponConstants.AssassinsDagger, "evil")]
        [TestCase(WeaponConstants.HolyAvenger, "Lawful good")]
        [TestCase(WeaponConstants.NineLivesStealer, "evil")]
        [TestCase(WeaponConstants.SunBlade, "good")]
        [TestCase("Rod of the python", "good")]
        [TestCase("Rod of the viper", "evil")]
        [TestCase("Chaos diamond", "Chaotic")]
        [TestCase("Darkskull", "evil")]
        [TestCase("Amulet of inescapable location", "evil")]
        [TestCase("Armor of arrow attraction", "evil")]
        [TestCase("Armor of rage", "evil")]
        [TestCase("Boots of dancing", "evil")]
        [TestCase("Bracers of defenselessness", "evil")]
        [TestCase("Broom of animated attack", "evil")]
        [TestCase("Cloak of poisonousness", "evil")]
        [TestCase("Crystal hypnosis ball", "evil")]
        [TestCase("Gauntlets of fumbling", "evil")]
        [TestCase("Mace of blood", "Chaotic evil")]
        [TestCase("Medallion of thought projection", "evil")]
        [TestCase("Necklace of strangulation", "evil")]
        [TestCase("Periapt of foul rotting", "evil")]
        [TestCase("Robe of powerlessness", "evil")]
        [TestCase("Robe of vermin", "evil")]
        [TestCase("Ring of clumsiness", "evil")]
        [TestCase("Scarab of death", "evil")]
        [TestCase("Cursed backbiter spear", "evil")]
        [TestCase("Stone of weight", "evil")]
        [TestCase("Vacuous grimoire", "evil")]
        [TestCase("Cursed -2 sword", "evil")]
        public override void Attributes(String name, params String[] attributes)
        {
            base.Attributes(name, attributes);
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
                "Chaos diamond",
                "Darkskull",
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