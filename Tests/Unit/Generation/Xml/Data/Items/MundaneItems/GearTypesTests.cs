using EquipmentGen.Core.Data.Items;
using NUnit.Framework;

namespace EquipmentGen.Tests.Unit.Generation.Xml.Data.Items.MundaneItems
{
    [TestFixture]
    public class GearTypesTests : TypesTest
    {
        [SetUp]
        public void Setup()
        {
            filename = "GearTypes.xml";
        }

        [Test]
        public void BucklerGearTypes()
        {
            var types = new[] 
            { 
                ItemsConstants.ItemTypes.Armor, 
                ItemsConstants.Gear.Types.Wood
            };

            AssertContent(ItemsConstants.Gear.Armor.Buckler, types);
        }

        [Test]
        public void LightWoodenShieldGearTypes()
        {
            var types = new[] 
            {
                ItemsConstants.ItemTypes.Armor,
                ItemsConstants.Gear.Types.Wood
            };

            AssertContent(ItemsConstants.Gear.Armor.LightWoodenShield, types);
        }

        [Test]
        public void LightSteelShieldGearTypes()
        {
            var types = new[] 
            {
                ItemsConstants.ItemTypes.Armor, 
                ItemsConstants.Gear.Types.Metal 
            };

            AssertContent(ItemsConstants.Gear.Armor.LightSteelShield, types);
        }

        [Test]
        public void HeavyWoodenShieldGearTypes()
        {
            var types = new[]
            {
                ItemsConstants.ItemTypes.Armor,
                ItemsConstants.Gear.Types.Wood
            };

            AssertContent(ItemsConstants.Gear.Armor.HeavyWoodenShield, types);
        }

        [Test]
        public void HeavySteelShieldGearTypes()
        {
            var types = new[]
            { 
                ItemsConstants.ItemTypes.Armor,
                ItemsConstants.Gear.Types.Metal
            };

            AssertContent(ItemsConstants.Gear.Armor.HeavySteelShield, types);
        }

        [Test]
        public void TowerShieldGearTypes()
        {
            var types = new[]
            {
                ItemsConstants.ItemTypes.Armor, 
                ItemsConstants.Gear.Types.Wood
            };

            AssertContent(ItemsConstants.Gear.Armor.TowerShield, types);
        }

        [Test]
        public void PaddedArmorGearTypes()
        {
            var types = new[]
            { 
                ItemsConstants.ItemTypes.Armor
            };

            AssertContent(ItemsConstants.Gear.Armor.PaddedArmor, types);
        }

        [Test]
        public void LeatherArmorGearTypes()
        {
            var types = new[]
            {
                ItemsConstants.ItemTypes.Armor
            };

            AssertContent(ItemsConstants.Gear.Armor.LeatherArmor, types);
        }

        [Test]
        public void StuddedLeatherArmorGearTypes()
        {
            var types = new[] 
            {
                ItemsConstants.ItemTypes.Armor, 
                ItemsConstants.Gear.Types.Metal
            };

            AssertContent(ItemsConstants.Gear.Armor.StuddedLeatherArmor, types);
        }

        [Test]
        public void ChainShirtArmorGearTypes()
        {
            var types = new[] 
            {
                ItemsConstants.ItemTypes.Armor,
                ItemsConstants.Gear.Types.Metal
            };

            AssertContent(ItemsConstants.Gear.Armor.ChainShirt, types);
        }

        [Test]
        public void HideArmorGearTypes()
        {
            var types = new[] 
            {
                ItemsConstants.ItemTypes.Armor
            };

            AssertContent(ItemsConstants.Gear.Armor.HideArmor, types);
        }

        [Test]
        public void ScaleMailGearTypes()
        {
            var types = new[] 
            { 
                ItemsConstants.ItemTypes.Armor,
                ItemsConstants.Gear.Types.Metal
            };

            AssertContent(ItemsConstants.Gear.Armor.ScaleMail, types);
        }

        [Test]
        public void ChainmailGearTypes()
        {
            var types = new[]
            { 
                ItemsConstants.ItemTypes.Armor,
                ItemsConstants.Gear.Types.Metal
            };

            AssertContent(ItemsConstants.Gear.Armor.Chainmail, types);
        }

        [Test]
        public void BreastplateGearTypes()
        {
            var types = new[] 
            {
                ItemsConstants.ItemTypes.Armor, 
                ItemsConstants.Gear.Types.Metal
            };

            AssertContent(ItemsConstants.Gear.Armor.Breastplate, types);
        }

        [Test]
        public void SplintMailGearTypes()
        {
            var types = new[]
            {
                ItemsConstants.ItemTypes.Armor,
                ItemsConstants.Gear.Types.Metal 
            };

            AssertContent(ItemsConstants.Gear.Armor.SplintMail, types);
        }

        [Test]
        public void BandedMailGearTypes()
        {
            var types = new[] 
            {
                ItemsConstants.ItemTypes.Armor,
                ItemsConstants.Gear.Types.Metal
            };

            AssertContent(ItemsConstants.Gear.Armor.BandedMail, types);
        }

        [Test]
        public void HalfPlateGearTypes()
        {
            var types = new[]
            {
                ItemsConstants.ItemTypes.Armor,
                ItemsConstants.Gear.Types.Metal
            };

            AssertContent(ItemsConstants.Gear.Armor.HalfPlate, types);
        }

        [Test]
        public void FullPlateGearTypes()
        {
            var types = new[] 
            { 
                ItemsConstants.ItemTypes.Armor, 
                ItemsConstants.Gear.Types.Metal
            };

            AssertContent(ItemsConstants.Gear.Armor.FullPlate, types);
        }

        [Test]
        public void DaggerGearTypes()
        {
            var types = new[]
            {
                ItemsConstants.ItemTypes.Weapon,
                ItemsConstants.Gear.Types.Metal,
                ItemsConstants.Gear.Types.Common,
                ItemsConstants.Gear.Types.Melee
            };

            AssertContent(ItemsConstants.Gear.Weapons.Dagger, types);
        }

        [Test]
        public void GreataxeGearTypes()
        {
            var types = new[] 
            {
                ItemsConstants.ItemTypes.Weapon,
                ItemsConstants.Gear.Types.Metal,
                ItemsConstants.Gear.Types.Common,
                ItemsConstants.Gear.Types.Melee
            };

            AssertContent(ItemsConstants.Gear.Weapons.Greataxe, types);
        }

        [Test]
        public void GreatswordGearTypes()
        {
            var types = new[] 
            {
                ItemsConstants.ItemTypes.Weapon,
                ItemsConstants.Gear.Types.Metal,
                ItemsConstants.Gear.Types.Common,
                ItemsConstants.Gear.Types.Melee 
            };

            AssertContent(ItemsConstants.Gear.Weapons.Greatsword, types);
        }

        [Test]
        public void KamaGearTypes()
        {
            var types = new[] 
            {
                ItemsConstants.ItemTypes.Weapon,
                ItemsConstants.Gear.Types.Wood,
                ItemsConstants.Gear.Types.Metal,
                ItemsConstants.Gear.Types.Common,
                ItemsConstants.Gear.Types.Melee
            };

            AssertContent(ItemsConstants.Gear.Weapons.Kama, types);
        }

        [Test]
        public void LongswordGearTypes()
        {
            var types = new[] 
            {
                ItemsConstants.ItemTypes.Weapon,
                ItemsConstants.Gear.Types.Metal,
                ItemsConstants.Gear.Types.Common,
                ItemsConstants.Gear.Types.Melee 
            };

            AssertContent(ItemsConstants.Gear.Weapons.Longsword, types);
        }

        [Test]
        public void LightMaceGearTypes()
        {
            var types = new[] 
            {
                ItemsConstants.ItemTypes.Weapon,
                ItemsConstants.Gear.Types.Metal,
                ItemsConstants.Gear.Types.Common,
                ItemsConstants.Gear.Types.Melee 
            };

            AssertContent(ItemsConstants.Gear.Weapons.LightMace, types);
        }

        [Test]
        public void HeavyMaceGearTypes()
        {
            var types = new[] 
            {
                ItemsConstants.ItemTypes.Weapon, 
                ItemsConstants.Gear.Types.Metal,
                ItemsConstants.Gear.Types.Common, 
                ItemsConstants.Gear.Types.Melee
            };

            AssertContent(ItemsConstants.Gear.Weapons.HeavyMace, types);
        }

        [Test]
        public void NunchakuGearTypes()
        {
            var types = new[] 
            {
                ItemsConstants.ItemTypes.Weapon,
                ItemsConstants.Gear.Types.Wood,
                ItemsConstants.Gear.Types.Common,
                ItemsConstants.Gear.Types.Melee
            };

            AssertContent(ItemsConstants.Gear.Weapons.Nunchaku, types);
        }

        [Test]
        public void QuarterstaffGearTypes()
        {
            var types = new[] 
            {
                ItemsConstants.ItemTypes.Weapon,
                ItemsConstants.Gear.Types.Wood,
                ItemsConstants.Gear.Types.Common,
                ItemsConstants.Gear.Types.DoubleWeapon, 
                ItemsConstants.Gear.Types.Melee
            };

            AssertContent(ItemsConstants.Gear.Weapons.Quarterstaff, types);
        }

        [Test]
        public void RapierGearTypes()
        {
            var types = new[] 
            {
                ItemsConstants.ItemTypes.Weapon,
                ItemsConstants.Gear.Types.Metal, 
                ItemsConstants.Gear.Types.Common,
                ItemsConstants.Gear.Types.Melee
            };

            AssertContent(ItemsConstants.Gear.Weapons.Rapier, types);
        }

        [Test]
        public void ScimitarGearTypes()
        {
            var types = new[]
            {
                ItemsConstants.ItemTypes.Weapon,
                ItemsConstants.Gear.Types.Metal,
                ItemsConstants.Gear.Types.Common, 
                ItemsConstants.Gear.Types.Melee
            };

            AssertContent(ItemsConstants.Gear.Weapons.Scimitar, types);
        }

        [Test]
        public void ShortspearGearTypes()
        {
            var types = new[] 
            {
                ItemsConstants.ItemTypes.Weapon,
                ItemsConstants.Gear.Types.Wood,
                ItemsConstants.Gear.Types.Metal,
                ItemsConstants.Gear.Types.Common,
                ItemsConstants.Gear.Types.Melee 
            };

            AssertContent(ItemsConstants.Gear.Weapons.Shortspear, types);
        }

        [Test]
        public void SianghamGearTypes()
        {
            var types = new[] 
            {
                ItemsConstants.ItemTypes.Weapon,
                ItemsConstants.Gear.Types.Metal,
                ItemsConstants.Gear.Types.Common,
                ItemsConstants.Gear.Types.Melee
            };

            AssertContent(ItemsConstants.Gear.Weapons.Siangham, types);
        }

        [Test]
        public void BastardSwordGearTypes()
        {
            var types = new[]
            {
                ItemsConstants.ItemTypes.Weapon,
                ItemsConstants.Gear.Types.Metal,
                ItemsConstants.Gear.Types.Common,
                ItemsConstants.Gear.Types.Melee
            };

            AssertContent(ItemsConstants.Gear.Weapons.BastardSword, types);
        }

        [Test]
        public void ShortSwordGearTypes()
        {
            var types = new[] 
            {
                ItemsConstants.ItemTypes.Weapon,
                ItemsConstants.Gear.Types.Metal,
                ItemsConstants.Gear.Types.Common,
                ItemsConstants.Gear.Types.Melee 
            };

            AssertContent(ItemsConstants.Gear.Weapons.ShortSword, types);
        }

        [Test]
        public void DwarvenWaraxeGearTypes()
        {
            var types = new[] 
            {
                ItemsConstants.ItemTypes.Weapon,
                ItemsConstants.Gear.Types.Metal, 
                ItemsConstants.Gear.Types.Common,
                ItemsConstants.Gear.Types.Melee
            };

            AssertContent(ItemsConstants.Gear.Weapons.DwarvenWaraxe, types);
        }

        [Test]
        public void OrcDoubleAxeGearTypes()
        {
            var types = new[] { };
            AssertContent(ItemsConstants.Gear.Weapons.OrcDoubleAxe, ItemsConstants.ItemTypes.Weapon, ItemsConstants.Gear.Types.Metal, ItemsConstants.Gear.Types.Uncommon, ItemsConstants.Gear.Types.DoubleWeapon, ItemsConstants.Gear.Types.Melee);
        }

        [Test]
        public void BattleaxeGearTypes()
        {
            var types = new[] { };
            AssertContent(ItemsConstants.Gear.Weapons.Battleaxe, ItemsConstants.ItemTypes.Weapon, ItemsConstants.Gear.Types.Metal, ItemsConstants.Gear.Types.Uncommon, ItemsConstants.Gear.Types.Melee);
        }

        [Test]
        public void SpikedChainGearTypes()
        {
            var types = new[] { };
            AssertContent(ItemsConstants.Gear.Weapons.SpikedChain, ItemsConstants.ItemTypes.Weapon, ItemsConstants.Gear.Types.Metal, ItemsConstants.Gear.Types.Uncommon, ItemsConstants.Gear.Types.Melee);
        }

        [Test]
        public void ClubGearTypes()
        {
            var types = new[] { };
            AssertContent(ItemsConstants.Gear.Weapons.Club, ItemsConstants.ItemTypes.Weapon, ItemsConstants.Gear.Types.Wood, ItemsConstants.Gear.Types.Uncommon, ItemsConstants.Gear.Types.Melee);
        }

        [Test]
        public void HandCrossbowGearTypes()
        {
            var types = new[] { };
            AssertContent(ItemsConstants.Gear.Weapons.HandCrossbow, ItemsConstants.ItemTypes.Weapon, ItemsConstants.Gear.Types.Metal, ItemsConstants.Gear.Types.Uncommon, ItemsConstants.Gear.Types.Ranged);
        }

        [Test]
        public void RepeatingCrossbowGearTypes()
        {
            var types = new[] { };
            AssertContent(ItemsConstants.Gear.Weapons.RepeatingCrossbow, ItemsConstants.ItemTypes.Weapon, ItemsConstants.Gear.Types.Metal, ItemsConstants.Gear.Types.Uncommon, ItemsConstants.Gear.Types.Ranged);
        }

        [Test]
        public void PunchingDaggerGearTypes()
        {
            var types = new[] { };
            AssertContent(ItemsConstants.Gear.Weapons.PunchingDagger, ItemsConstants.ItemTypes.Weapon, ItemsConstants.Gear.Types.Metal, ItemsConstants.Gear.Types.Uncommon, ItemsConstants.Gear.Types.Melee);
        }

        [Test]
        public void FalchionGearTypes()
        {
            var types = new[] { };
            AssertContent(ItemsConstants.Gear.Weapons.Falchion, ItemsConstants.ItemTypes.Weapon, ItemsConstants.Gear.Types.Metal, ItemsConstants.Gear.Types.Uncommon, ItemsConstants.Gear.Types.Melee);
        }

        [Test]
        public void DireFlailGearTypes()
        {
            var types = new[] { };
            AssertContent(ItemsConstants.Gear.Weapons.DireFlail, ItemsConstants.ItemTypes.Weapon, ItemsConstants.Gear.Types.Metal, ItemsConstants.Gear.Types.Uncommon, ItemsConstants.Gear.Types.Melee, ItemsConstants.Gear.Types.DoubleWeapon);
        }

        [Test]
        public void HeavyFlailGearTypes()
        {
            var types = new[] { };
            AssertContent(ItemsConstants.Gear.Weapons.HeavyFlail, ItemsConstants.ItemTypes.Weapon, ItemsConstants.Gear.Types.Metal, ItemsConstants.Gear.Types.Uncommon, ItemsConstants.Gear.Types.Melee);
        }

        [Test]
        public void LightFlailGearTypes()
        {
            var types = new[] { };
            AssertContent(ItemsConstants.Gear.Weapons.LightFlail, ItemsConstants.ItemTypes.Weapon, ItemsConstants.Gear.Types.Metal, ItemsConstants.Gear.Types.Uncommon, ItemsConstants.Gear.Types.Melee);
        }

        [Test]
        public void GauntletGearTypes()
        {
            var types = new[] { };
            AssertContent(ItemsConstants.Gear.Weapons.Gauntlet, ItemsConstants.ItemTypes.Weapon, ItemsConstants.Gear.Types.Metal, ItemsConstants.Gear.Types.Uncommon, ItemsConstants.Gear.Types.Melee);
        }

        [Test]
        public void SpikedGauntletGearTypes()
        {
            var types = new[] { };
            AssertContent(ItemsConstants.Gear.Weapons.SpikedGauntlet, ItemsConstants.ItemTypes.Weapon, ItemsConstants.Gear.Types.Metal, ItemsConstants.Gear.Types.Uncommon, ItemsConstants.Gear.Types.Melee);
        }

        [Test]
        public void GlaiveGearTypes()
        {
            var types = new[] { };
            AssertContent(ItemsConstants.Gear.Weapons.Glaive, ItemsConstants.ItemTypes.Weapon, ItemsConstants.Gear.Types.Metal, ItemsConstants.Gear.Types.Uncommon, ItemsConstants.Gear.Types.Melee);
        }

        [Test]
        public void GreatclubGearTypes()
        {
            var types = new[] { };
            AssertContent(ItemsConstants.Gear.Weapons.Greatclub, ItemsConstants.ItemTypes.Weapon, ItemsConstants.Gear.Types.Wood, ItemsConstants.Gear.Types.Uncommon, ItemsConstants.Gear.Types.Melee);
        }

        [Test]
        public void GuisarmeGearTypes()
        {
            var types = new[] { };
            AssertContent(ItemsConstants.Gear.Weapons.Guisarme, ItemsConstants.ItemTypes.Weapon, ItemsConstants.Gear.Types.Metal, ItemsConstants.Gear.Types.Uncommon, ItemsConstants.Gear.Types.Melee);
        }

        [Test]
        public void HalberdGearTypes()
        {
            var types = new[] { };
            AssertContent(ItemsConstants.Gear.Weapons.Halberd, ItemsConstants.ItemTypes.Weapon, ItemsConstants.Gear.Types.Metal, ItemsConstants.Gear.Types.Uncommon, ItemsConstants.Gear.Types.Melee);
        }

        [Test]
        public void HalfspearGearTypes()
        {
            var types = new[] { };
            AssertContent(ItemsConstants.Gear.Weapons.Halfspear, ItemsConstants.ItemTypes.Weapon, ItemsConstants.Gear.Types.Metal, ItemsConstants.Gear.Types.Wood, ItemsConstants.Gear.Types.Uncommon, ItemsConstants.Gear.Types.Melee);
        }

        [Test]
        public void GnomeHookedHammerGearTypes()
        {
            var types = new[] { };
            AssertContent(ItemsConstants.Gear.Weapons.GnomeHookedHammer, ItemsConstants.ItemTypes.Weapon, ItemsConstants.Gear.Types.Metal, ItemsConstants.Gear.Types.Uncommon, ItemsConstants.Gear.Types.Melee, ItemsConstants.Gear.Types.DoubleWeapon);
        }

        [Test]
        public void LightHammerGearTypes()
        {
            var types = new[] { };
            AssertContent(ItemsConstants.Gear.Weapons.LightHammer, ItemsConstants.ItemTypes.Weapon, ItemsConstants.Gear.Types.Metal, ItemsConstants.Gear.Types.Uncommon, ItemsConstants.Gear.Types.Melee);
        }

        [Test]
        public void HandaxeGearTypes()
        {
            var types = new[] { };
            AssertContent(ItemsConstants.Gear.Weapons.Handaxe, ItemsConstants.ItemTypes.Weapon, ItemsConstants.Gear.Types.Metal, ItemsConstants.Gear.Types.Uncommon, ItemsConstants.Gear.Types.Melee);
        }

        [Test]
        public void KukriGearTypes()
        {
            var types = new[] { };
            AssertContent(ItemsConstants.Gear.Weapons.Kukri, ItemsConstants.ItemTypes.Weapon, ItemsConstants.Gear.Types.Metal, ItemsConstants.Gear.Types.Uncommon, ItemsConstants.Gear.Types.Melee);
        }

        [Test]
        public void LanceGearTypes()
        {
            var types = new[] { };
            AssertContent(ItemsConstants.Gear.Weapons.Lance, ItemsConstants.ItemTypes.Weapon, ItemsConstants.Gear.Types.Wood, ItemsConstants.Gear.Types.Metal, ItemsConstants.Gear.Types.Uncommon, ItemsConstants.Gear.Types.Melee);
        }

        [Test]
        public void LongspearGearTypes()
        {
            var types = new[] { };
            AssertContent(ItemsConstants.Gear.Weapons.Longspear, ItemsConstants.ItemTypes.Weapon, ItemsConstants.Gear.Types.Wood, ItemsConstants.Gear.Types.Metal, ItemsConstants.Gear.Types.Uncommon, ItemsConstants.Gear.Types.Melee);
        }

        [Test]
        public void MorningstarGearTypes()
        {
            var types = new[] { };
            AssertContent(ItemsConstants.Gear.Weapons.Morningstar, ItemsConstants.ItemTypes.Weapon, ItemsConstants.Gear.Types.Metal, ItemsConstants.Gear.Types.Uncommon, ItemsConstants.Gear.Types.Melee);
        }

        [Test]
        public void NetGearTypes()
        {
            var types = new[] { };
            AssertContent(ItemsConstants.Gear.Weapons.Net, ItemsConstants.ItemTypes.Weapon, ItemsConstants.Gear.Types.Uncommon, ItemsConstants.Gear.Types.Ranged);
        }

        [Test]
        public void HeavyPickGearTypes()
        {
            var types = new[] { };
            AssertContent(ItemsConstants.Gear.Weapons.HeavyPick, ItemsConstants.ItemTypes.Weapon, ItemsConstants.Gear.Types.Metal, ItemsConstants.Gear.Types.Uncommon, ItemsConstants.Gear.Types.Melee);
        }

        [Test]
        public void LightPickGearTypes()
        {
            var types = new[] { };
            AssertContent(ItemsConstants.Gear.Weapons.LightPick, ItemsConstants.ItemTypes.Weapon, ItemsConstants.Gear.Types.Metal, ItemsConstants.Gear.Types.Uncommon, ItemsConstants.Gear.Types.Melee);
        }

        [Test]
        public void RanseurGearTypes()
        {
            var types = new[] { };
            AssertContent(ItemsConstants.Gear.Weapons.Ranseur, ItemsConstants.ItemTypes.Weapon, ItemsConstants.Gear.Types.Wood, ItemsConstants.Gear.Types.Metal, ItemsConstants.Gear.Types.Uncommon, ItemsConstants.Gear.Types.Melee);
        }

        [Test]
        public void SapGearTypes()
        {
            var types = new[] { };
            AssertContent(ItemsConstants.Gear.Weapons.Sap, ItemsConstants.ItemTypes.Weapon, ItemsConstants.Gear.Types.Uncommon, ItemsConstants.Gear.Types.Melee);
        }

        [Test]
        public void ScytheGearTypes()
        {
            var types = new[] { };
            AssertContent(ItemsConstants.Gear.Weapons.Scythe, ItemsConstants.ItemTypes.Weapon, ItemsConstants.Gear.Types.Wood, ItemsConstants.Gear.Types.Metal, ItemsConstants.Gear.Types.Uncommon, ItemsConstants.Gear.Types.Melee);
        }

        [Test]
        public void ShurikenGearTypes()
        {
            var types = new[] { };
            AssertContent(ItemsConstants.Gear.Weapons.Shuriken, ItemsConstants.ItemTypes.Weapon, ItemsConstants.Gear.Types.Metal, ItemsConstants.Gear.Types.Uncommon, ItemsConstants.Gear.Types.Ranged);
        }

        [Test]
        public void SickleGearTypes()
        {
            var types = new[] { };
            AssertContent(ItemsConstants.Gear.Weapons.Sickle, ItemsConstants.ItemTypes.Weapon, ItemsConstants.Gear.Types.Metal, ItemsConstants.Gear.Types.Uncommon, ItemsConstants.Gear.Types.Melee);
        }

        [Test]
        public void TwoBladedSwordGearTypes()
        {
            var types = new[] { };
            AssertContent(ItemsConstants.Gear.Weapons.TwoBladedSword, ItemsConstants.ItemTypes.Weapon, ItemsConstants.Gear.Types.Metal, ItemsConstants.Gear.Types.Uncommon, ItemsConstants.Gear.Types.Melee, ItemsConstants.Gear.Types.DoubleWeapon);
        }

        [Test]
        public void TridentGearTypes()
        {
            var types = new[] { };
            AssertContent(ItemsConstants.Gear.Weapons.Trident, ItemsConstants.ItemTypes.Weapon, ItemsConstants.Gear.Types.Metal, ItemsConstants.Gear.Types.Uncommon, ItemsConstants.Gear.Types.Melee);
        }

        [Test]
        public void DwarvenUrgroshGearTypes()
        {
            var types = new[] { };
            AssertContent(ItemsConstants.Gear.Weapons.DwarvenUrgrosh, ItemsConstants.ItemTypes.Weapon, ItemsConstants.Gear.Types.Metal, ItemsConstants.Gear.Types.Uncommon, ItemsConstants.Gear.Types.Melee, ItemsConstants.Gear.Types.DoubleWeapon);
        }

        [Test]
        public void WarhammerGearTypes()
        {
            var types = new[] { };
            AssertContent(ItemsConstants.Gear.Weapons.Warhammer, ItemsConstants.ItemTypes.Weapon, ItemsConstants.Gear.Types.Metal, ItemsConstants.Gear.Types.Uncommon, ItemsConstants.Gear.Types.Melee);
        }

        [Test]
        public void WhipGearTypes()
        {
            var types = new[] { };
            AssertContent(ItemsConstants.Gear.Weapons.Whip, ItemsConstants.ItemTypes.Weapon, ItemsConstants.Gear.Types.Uncommon, ItemsConstants.Gear.Types.Melee);
        }

        [Test]
        public void ArrowGearTypes()
        {
            var types = new[] { };
            AssertContent(ItemsConstants.Gear.Weapons.Arrow, ItemsConstants.ItemTypes.Weapon, ItemsConstants.Gear.Types.Common, ItemsConstants.Gear.Types.Ranged, ItemsConstants.Gear.Types.Ammunition, ItemsConstants.Gear.Types.Metal, ItemsConstants.Gear.Types.Wood);
        }

        [Test]
        public void CrossbowBoltGearTypes()
        {
            var types = new[] { };
            AssertContent(ItemsConstants.Gear.Weapons.CrossbowBolt, ItemsConstants.ItemTypes.Weapon, ItemsConstants.Gear.Types.Common, ItemsConstants.Gear.Types.Ranged, ItemsConstants.Gear.Types.Ammunition, ItemsConstants.Gear.Types.Metal);
        }

        [Test]
        public void SlingBulletGearTypes()
        {
            var types = new[] { };
            AssertContent(ItemsConstants.Gear.Weapons.SlingBullet, ItemsConstants.ItemTypes.Weapon, ItemsConstants.Gear.Types.Common, ItemsConstants.Gear.Types.Ranged, ItemsConstants.Gear.Types.Ammunition, ItemsConstants.Gear.Types.Metal);
        }
    }
}