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

        [TestCase(ArmorConstants.CelestialArmor, "Good")]
        [TestCase(ArmorConstants.DemonArmor, "Evil")]
        [TestCase(WeaponConstants.AssassinsDagger, "Evil")]
        [TestCase(WeaponConstants.HolyAvenger, "Lawful Good")]
        [TestCase(WeaponConstants.NineLivesStealer, "Evil")]
        [TestCase(WeaponConstants.SunBlade, "Good")]
        [TestCase("Rod of the python", "Good")]
        [TestCase("Rod of the viper", "Evil")]
        [TestCase("Chaos diamond", "Chaotic")]
        [TestCase("Darkskull", "Evil")]
        [TestCase("Amulet of Inescapable Location", "Evil")]
        [TestCase("Armor of arrow attraction", "Evil")]
        [TestCase("Armor of rage", "Evil")]
        [TestCase("Boots of dancing", "Evil")]
        [TestCase("Bracers of defenselessness", "Evil")]
        [TestCase("Broom of animated attack", "Evil")]
        [TestCase("Cloak of poisonousness", "Evil")]
        [TestCase("Crystal hypnosis ball", "Evil")]
        [TestCase("Gauntlets of fumbling", "Evil")]
        [TestCase("Mace of Blood", "Chaotic Evil")]
        [TestCase("Medallion of thought projection", "Evil")]
        [TestCase("Necklace of strangulation", "Evil")]
        [TestCase("Periapt of foul rotting", "Evil")]
        [TestCase("Robe of powerlessness", "Evil")]
        [TestCase("Robe of vermin", "Evil")]
        [TestCase("Ring of clumsiness", "Evil")]
        [TestCase("Scarab of death", "Evil")]
        [TestCase("Cursed backbiter spear", "Evil")]
        [TestCase("Boots of Dancing", "Evil")]
        [TestCase("Boots of Dancing", "Evil")]
        [TestCase("Boots of Dancing", "Evil")]
        public override void Attributes(String name, params String[] attributes)
        {
            base.Attributes(name, attributes);
        }
    }
}