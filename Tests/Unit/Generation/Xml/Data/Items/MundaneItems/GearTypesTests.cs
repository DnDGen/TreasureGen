using System;
using System.Collections.Generic;
using System.Linq;
using EquipmentGen.Core.Data.Items;
using EquipmentGen.Core.Generation.Xml.Parsers;
using NUnit.Framework;

namespace EquipmentGen.Tests.Unit.Generation.Xml.Data.Items.MundaneItems
{
    [TestFixture]
    public class GearTypesTests
    {
        private Dictionary<String, IEnumerable<String>> table;

        [SetUp]
        public void Setup()
        {
            var streamLoader = new EmbeddedResourceStreamLoader();
            var gearTypesXmlParser = new GearTypesXmlParser(streamLoader);
            table = gearTypesXmlParser.Parse("GearTypes.xml");
        }

        [Test]
        public void BucklerGearTypes()
        {
            AssertContent("Buckler", ItemsConstants.ItemTypes.Armor, ItemsConstants.Gear.Types.Wood);
        }

        [Test]
        public void LightWoodenShieldGearTypes()
        {
            AssertContent("Light wooden shield", ItemsConstants.ItemTypes.Armor, ItemsConstants.Gear.Types.Wood);
        }

        [Test]
        public void LightSteelShieldGearTypes()
        {
            AssertContent("Light steel shield", ItemsConstants.ItemTypes.Armor, ItemsConstants.Gear.Types.Metal);
        }

        [Test]
        public void HeavyWoodenShieldGearTypes()
        {
            AssertContent("Heavy wooden shield", ItemsConstants.ItemTypes.Armor, ItemsConstants.Gear.Types.Wood);
        }

        [Test]
        public void HeavySteelShieldGearTypes()
        {
            AssertContent("Heavy steel shield", ItemsConstants.ItemTypes.Armor, ItemsConstants.Gear.Types.Metal);
        }

        [Test]
        public void TowerShieldGearTypes()
        {
            AssertContent("Tower shield", ItemsConstants.ItemTypes.Armor, ItemsConstants.Gear.Types.Wood);
        }

        [Test]
        public void PaddedArmorGearTypes()
        {
            AssertContent("Padded armor", ItemsConstants.ItemTypes.Armor);
        }

        [Test]
        public void LeatherArmorGearTypes()
        {
            AssertContent("Leather armor", ItemsConstants.ItemTypes.Armor);
        }

        [Test]
        public void StuddedLeatherArmorGearTypes()
        {
            AssertContent("Studded leather armor", ItemsConstants.ItemTypes.Armor, ItemsConstants.Gear.Types.Metal);
        }

        [Test]
        public void ChainShirtArmorGearTypes()
        {
            AssertContent("Chain shirt", ItemsConstants.ItemTypes.Armor, ItemsConstants.Gear.Types.Metal);
        }

        [Test]
        public void HideArmorGearTypes()
        {
            AssertContent("Hide armor", ItemsConstants.ItemTypes.Armor);
        }

        [Test]
        public void ScaleMailGearTypes()
        {
            AssertContent("Scale mail", ItemsConstants.ItemTypes.Armor, ItemsConstants.Gear.Types.Metal);
        }

        [Test]
        public void ChainmailGearTypes()
        {
            AssertContent("Chainmail", ItemsConstants.ItemTypes.Armor, ItemsConstants.Gear.Types.Metal);
        }

        [Test]
        public void BreastplateGearTypes()
        {
            AssertContent("Breastplate", ItemsConstants.ItemTypes.Armor, ItemsConstants.Gear.Types.Metal);
        }

        [Test]
        public void SplintMailGearTypes()
        {
            AssertContent("Splint mail", ItemsConstants.ItemTypes.Armor, ItemsConstants.Gear.Types.Metal);
        }

        [Test]
        public void BandedMailGearTypes()
        {
            AssertContent("Banded mail", ItemsConstants.ItemTypes.Armor, ItemsConstants.Gear.Types.Metal);
        }

        [Test]
        public void HalfPlateGearTypes()
        {
            AssertContent("Half-plate", ItemsConstants.ItemTypes.Armor, ItemsConstants.Gear.Types.Metal);
        }

        [Test]
        public void FullPlateGearTypes()
        {
            AssertContent("Full plate", ItemsConstants.ItemTypes.Armor, ItemsConstants.Gear.Types.Metal);
        }

        [Test]
        public void DaggerGearTypes()
        {
            AssertContent("Dagger", ItemsConstants.ItemTypes.Weapon, ItemsConstants.Gear.Types.Metal, ItemsConstants.Gear.Types.CommonMelee, ItemsConstants.Gear.Types.Melee);
        }

        [Test]
        public void GreataxeGearTypes()
        {
            AssertContent("Greataxe", ItemsConstants.ItemTypes.Weapon, ItemsConstants.Gear.Types.Metal, ItemsConstants.Gear.Types.CommonMelee, ItemsConstants.Gear.Types.Melee);
        }

        [Test]
        public void GreatswordGearTypes()
        {
            AssertContent("Greatsword", ItemsConstants.ItemTypes.Weapon, ItemsConstants.Gear.Types.Metal, ItemsConstants.Gear.Types.CommonMelee, ItemsConstants.Gear.Types.Melee);
        }

        [Test]
        public void KamaGearTypes()
        {
            AssertContent("Kama", ItemsConstants.ItemTypes.Weapon, ItemsConstants.Gear.Types.Wood, ItemsConstants.Gear.Types.Metal, ItemsConstants.Gear.Types.CommonMelee, ItemsConstants.Gear.Types.Melee);
        }

        [Test]
        public void LongswordGearTypes()
        {
            AssertContent("Longsword", ItemsConstants.ItemTypes.Weapon, ItemsConstants.Gear.Types.Metal, ItemsConstants.Gear.Types.CommonMelee, ItemsConstants.Gear.Types.Melee);
        }

        [Test]
        public void LightMaceGearTypes()
        {
            AssertContent("Light mace", ItemsConstants.ItemTypes.Weapon, ItemsConstants.Gear.Types.Metal, ItemsConstants.Gear.Types.CommonMelee, ItemsConstants.Gear.Types.Melee);
        }

        [Test]
        public void HeavyMaceGearTypes()
        {
            AssertContent("Heavy mace", ItemsConstants.ItemTypes.Weapon, ItemsConstants.Gear.Types.Metal, ItemsConstants.Gear.Types.CommonMelee, ItemsConstants.Gear.Types.Melee);
        }

        [Test]
        public void NunchakuGearTypes()
        {
            AssertContent("Nunchaku", ItemsConstants.ItemTypes.Weapon, ItemsConstants.Gear.Types.Wood, ItemsConstants.Gear.Types.CommonMelee, ItemsConstants.Gear.Types.Melee);
        }

        [Test]
        public void QuarterstaffGearTypes()
        {
            AssertContent("Quarterstaff", ItemsConstants.ItemTypes.Weapon, ItemsConstants.Gear.Types.Wood, ItemsConstants.Gear.Types.CommonMelee, ItemsConstants.Gear.Types.DoubleWeapon, ItemsConstants.Gear.Types.Melee);
        }

        [Test]
        public void RapierGearTypes()
        {
            AssertContent("Rapier", ItemsConstants.ItemTypes.Weapon, ItemsConstants.Gear.Types.Metal, ItemsConstants.Gear.Types.CommonMelee, ItemsConstants.Gear.Types.Melee);
        }

        [Test]
        public void ScimitarGearTypes()
        {
            AssertContent("Scimitar", ItemsConstants.ItemTypes.Weapon, ItemsConstants.Gear.Types.Metal, ItemsConstants.Gear.Types.CommonMelee, ItemsConstants.Gear.Types.Melee);
        }

        [Test]
        public void ShortspearGearTypes()
        {
            AssertContent("Shortspear", ItemsConstants.ItemTypes.Weapon, ItemsConstants.Gear.Types.Wood, ItemsConstants.Gear.Types.Metal, ItemsConstants.Gear.Types.CommonMelee, ItemsConstants.Gear.Types.Melee);
        }

        [Test]
        public void SianghamGearTypes()
        {
            AssertContent("Siangham", ItemsConstants.ItemTypes.Weapon, ItemsConstants.Gear.Types.Metal, ItemsConstants.Gear.Types.CommonMelee, ItemsConstants.Gear.Types.Melee);
        }

        [Test]
        public void BastardSwordGearTypes()
        {
            AssertContent("Bastard sword", ItemsConstants.ItemTypes.Weapon, ItemsConstants.Gear.Types.Metal, ItemsConstants.Gear.Types.CommonMelee, ItemsConstants.Gear.Types.Melee);
        }

        [Test]
        public void ShortSwordGearTypes()
        {
            AssertContent("Short sword", ItemsConstants.ItemTypes.Weapon, ItemsConstants.Gear.Types.Metal, ItemsConstants.Gear.Types.CommonMelee, ItemsConstants.Gear.Types.Melee);
        }

        [Test]
        public void DwarvenWaraxeGearTypes()
        {
            AssertContent("Dwarven waraxe", ItemsConstants.ItemTypes.Weapon, ItemsConstants.Gear.Types.Metal, ItemsConstants.Gear.Types.CommonMelee, ItemsConstants.Gear.Types.Melee);
        }

        [Test]
        public void OrcDoubleAxeGearTypes()
        {
            AssertContent("Orc double axe", ItemsConstants.ItemTypes.Weapon, ItemsConstants.Gear.Types.Metal, ItemsConstants.Gear.Types.Uncommon, ItemsConstants.Gear.Types.DoubleWeapon, ItemsConstants.Gear.Types.Melee);
        }

        [Test]
        public void BattleaxeGearTypes()
        {
            AssertContent("Battleaxe", ItemsConstants.ItemTypes.Weapon, ItemsConstants.Gear.Types.Metal, ItemsConstants.Gear.Types.Uncommon, ItemsConstants.Gear.Types.Melee);
        }

        [Test]
        public void SpikedChainGearTypes()
        {
            AssertContent("Spiked chain", ItemsConstants.ItemTypes.Weapon, ItemsConstants.Gear.Types.Metal, ItemsConstants.Gear.Types.Uncommon, ItemsConstants.Gear.Types.Melee);
        }

        [Test]
        public void ClubGearTypes()
        {
            AssertContent("Club", ItemsConstants.ItemTypes.Weapon, ItemsConstants.Gear.Types.Wood, ItemsConstants.Gear.Types.Uncommon, ItemsConstants.Gear.Types.Melee);
        }

        [Test]
        public void HandCrossbowGearTypes()
        {
            AssertContent("Hand crossbow", ItemsConstants.ItemTypes.Weapon, ItemsConstants.Gear.Types.Metal, ItemsConstants.Gear.Types.Uncommon, ItemsConstants.Gear.Types.Ranged);
        }

        [Test]
        public void RepeatingCrossbowGearTypes()
        {
            AssertContent("Repeating crossbow", ItemsConstants.ItemTypes.Weapon, ItemsConstants.Gear.Types.Metal, ItemsConstants.Gear.Types.Uncommon, ItemsConstants.Gear.Types.Ranged);
        }

        [Test]
        public void PunchingDaggerGearTypes()
        {
            AssertContent("Punching dagger", ItemsConstants.ItemTypes.Weapon, ItemsConstants.Gear.Types.Metal, ItemsConstants.Gear.Types.Uncommon, ItemsConstants.Gear.Types.Melee);
        }

        [Test]
        public void FalchionGearTypes()
        {
            AssertContent("Falchion", ItemsConstants.ItemTypes.Weapon, ItemsConstants.Gear.Types.Metal, ItemsConstants.Gear.Types.Uncommon, ItemsConstants.Gear.Types.Melee);
        }

        [Test]
        public void DireFlailGearTypes()
        {
            AssertContent("Dire flail", ItemsConstants.ItemTypes.Weapon, ItemsConstants.Gear.Types.Metal, ItemsConstants.Gear.Types.Uncommon, ItemsConstants.Gear.Types.Melee, ItemsConstants.Gear.Types.DoubleWeapon);
        }

        [Test]
        public void HeavyFlailGearTypes()
        {
            AssertContent("Heavy flail", ItemsConstants.ItemTypes.Weapon, ItemsConstants.Gear.Types.Metal, ItemsConstants.Gear.Types.Uncommon, ItemsConstants.Gear.Types.Melee);
        }

        [Test]
        public void LightFlailGearTypes()
        {
            AssertContent("Light flail", ItemsConstants.ItemTypes.Weapon, ItemsConstants.Gear.Types.Metal, ItemsConstants.Gear.Types.Uncommon, ItemsConstants.Gear.Types.Melee);
        }

        [Test]
        public void GauntletGearTypes()
        {
            AssertContent("Gauntlet", ItemsConstants.ItemTypes.Weapon, ItemsConstants.Gear.Types.Metal, ItemsConstants.Gear.Types.Uncommon, ItemsConstants.Gear.Types.Melee);
        }

        [Test]
        public void SpikedGauntletGearTypes()
        {
            AssertContent("Spiked gauntlet", ItemsConstants.ItemTypes.Weapon, ItemsConstants.Gear.Types.Metal, ItemsConstants.Gear.Types.Uncommon, ItemsConstants.Gear.Types.Melee);
        }

        [Test]
        public void GlaiveGearTypes()
        {
            AssertContent("Glaive", ItemsConstants.ItemTypes.Weapon, ItemsConstants.Gear.Types.Metal, ItemsConstants.Gear.Types.Uncommon, ItemsConstants.Gear.Types.Melee);
        }

        [Test]
        public void GreatclubGearTypes()
        {
            AssertContent("Greatclub", ItemsConstants.ItemTypes.Weapon, ItemsConstants.Gear.Types.Wood, ItemsConstants.Gear.Types.Uncommon, ItemsConstants.Gear.Types.Melee);
        }

        [Test]
        public void GuisarmeGearTypes()
        {
            AssertContent("Guisarme", ItemsConstants.ItemTypes.Weapon, ItemsConstants.Gear.Types.Metal, ItemsConstants.Gear.Types.Uncommon, ItemsConstants.Gear.Types.Melee);
        }

        [Test]
        public void HalberdGearTypes()
        {
            AssertContent("Halberd", ItemsConstants.ItemTypes.Weapon, ItemsConstants.Gear.Types.Metal, ItemsConstants.Gear.Types.Uncommon, ItemsConstants.Gear.Types.Melee);
        }

        [Test]
        public void HalfspearGearTypes()
        {
            AssertContent("Halfspear", ItemsConstants.ItemTypes.Weapon, ItemsConstants.Gear.Types.Metal, ItemsConstants.Gear.Types.Wood, ItemsConstants.Gear.Types.Uncommon, ItemsConstants.Gear.Types.Melee);
        }

        [Test]
        public void GnomeHookedHammerGearTypes()
        {
            AssertContent("Gnome hooked hammer", ItemsConstants.ItemTypes.Weapon, ItemsConstants.Gear.Types.Metal, ItemsConstants.Gear.Types.Uncommon, ItemsConstants.Gear.Types.Melee, ItemsConstants.Gear.Types.DoubleWeapon);
        }

        [Test]
        public void LightHammerGearTypes()
        {
            AssertContent("Light hammer", ItemsConstants.ItemTypes.Weapon, ItemsConstants.Gear.Types.Metal, ItemsConstants.Gear.Types.Uncommon, ItemsConstants.Gear.Types.Melee);
        }

        [Test]
        public void HandaxeGearTypes()
        {
            AssertContent("Handaxe", ItemsConstants.ItemTypes.Weapon, ItemsConstants.Gear.Types.Metal, ItemsConstants.Gear.Types.Uncommon, ItemsConstants.Gear.Types.Melee);
        }

        [Test]
        public void KukriGearTypes()
        {
            AssertContent("Kukri", ItemsConstants.ItemTypes.Weapon, ItemsConstants.Gear.Types.Metal, ItemsConstants.Gear.Types.Uncommon, ItemsConstants.Gear.Types.Melee);
        }

        [Test]
        public void LanceGearTypes()
        {
            AssertContent("Lance", ItemsConstants.ItemTypes.Weapon, ItemsConstants.Gear.Types.Wood, ItemsConstants.Gear.Types.Metal, ItemsConstants.Gear.Types.Uncommon, ItemsConstants.Gear.Types.Melee);
        }

        [Test]
        public void LongspearGearTypes()
        {
            AssertContent("Halberd", ItemsConstants.ItemTypes.Weapon, ItemsConstants.Gear.Types.Wood, ItemsConstants.Gear.Types.Metal, ItemsConstants.Gear.Types.Uncommon, ItemsConstants.Gear.Types.Melee);
        }

        [Test]
        public void MorningstarGearTypes()
        {
            AssertContent("Morningstar", ItemsConstants.ItemTypes.Weapon, ItemsConstants.Gear.Types.Metal, ItemsConstants.Gear.Types.Uncommon, ItemsConstants.Gear.Types.Melee);
        }

        [Test]
        public void NetGearTypes()
        {
            AssertContent("Net", ItemsConstants.ItemTypes.Weapon, ItemsConstants.Gear.Types.Uncommon, ItemsConstants.Gear.Types.Ranged);
        }

        [Test]
        public void HeavyPickGearTypes()
        {
            AssertContent("Heavy pick", ItemsConstants.ItemTypes.Weapon, ItemsConstants.Gear.Types.Metal, ItemsConstants.Gear.Types.Uncommon, ItemsConstants.Gear.Types.Melee);
        }

        [Test]
        public void LightPickGearTypes()
        {
            AssertContent("Light pick", ItemsConstants.ItemTypes.Weapon, ItemsConstants.Gear.Types.Metal, ItemsConstants.Gear.Types.Uncommon, ItemsConstants.Gear.Types.Melee);
        }

        [Test]
        public void RanseurGearTypes()
        {
            AssertContent("Ranseur", ItemsConstants.ItemTypes.Weapon, ItemsConstants.Gear.Types.Wood, ItemsConstants.Gear.Types.Metal, ItemsConstants.Gear.Types.Uncommon, ItemsConstants.Gear.Types.Melee);
        }

        [Test]
        public void SapGearTypes()
        {
            AssertContent("Sap", ItemsConstants.ItemTypes.Weapon, ItemsConstants.Gear.Types.Uncommon, ItemsConstants.Gear.Types.Melee);
        }

        [Test]
        public void ScytheGearTypes()
        {
            AssertContent("Scythe", ItemsConstants.ItemTypes.Weapon, ItemsConstants.Gear.Types.Wood, ItemsConstants.Gear.Types.Metal, ItemsConstants.Gear.Types.Uncommon, ItemsConstants.Gear.Types.Melee);
        }

        [Test]
        public void ShurikenGearTypes()
        {
            AssertContent("Shuriken", ItemsConstants.ItemTypes.Weapon, ItemsConstants.Gear.Types.Metal, ItemsConstants.Gear.Types.Uncommon, ItemsConstants.Gear.Types.Ranged);
        }

        [Test]
        public void SickleGearTypes()
        {
            AssertContent("Sickle", ItemsConstants.ItemTypes.Weapon, ItemsConstants.Gear.Types.Metal, ItemsConstants.Gear.Types.Uncommon, ItemsConstants.Gear.Types.Melee);
        }

        [Test]
        public void TwoBladedSwordGearTypes()
        {
            AssertContent("Two-bladed sword", ItemsConstants.ItemTypes.Weapon, ItemsConstants.Gear.Types.Metal, ItemsConstants.Gear.Types.Uncommon, ItemsConstants.Gear.Types.Melee, ItemsConstants.Gear.Types.DoubleWeapon);
        }

        [Test]
        public void TridentGearTypes()
        {
            AssertContent("Trident", ItemsConstants.ItemTypes.Weapon, ItemsConstants.Gear.Types.Metal, ItemsConstants.Gear.Types.Uncommon, ItemsConstants.Gear.Types.Melee);
        }

        [Test]
        public void DwarvenUrgroshGearTypes()
        {
            AssertContent("Dwarven urgrosh", ItemsConstants.ItemTypes.Weapon, ItemsConstants.Gear.Types.Metal, ItemsConstants.Gear.Types.Uncommon, ItemsConstants.Gear.Types.Melee, ItemsConstants.Gear.Types.DoubleWeapon);
        }

        [Test]
        public void WarhammerGearTypes()
        {
            AssertContent("Warhammer", ItemsConstants.ItemTypes.Weapon, ItemsConstants.Gear.Types.Metal, ItemsConstants.Gear.Types.Uncommon, ItemsConstants.Gear.Types.Melee);
        }

        [Test]
        public void WhipGearTypes()
        {
            AssertContent("Whip", ItemsConstants.ItemTypes.Weapon, ItemsConstants.Gear.Types.Uncommon, ItemsConstants.Gear.Types.Melee);
        }

        private void AssertContent(String gearName, params String[] types)
        {
            var actualTypes = table[gearName];

            foreach (var type in types)
                Assert.That(actualTypes, Contains.Item(type));

            Assert.That(types.Count(), Is.EqualTo(actualTypes.Count()));
        }
    }
}