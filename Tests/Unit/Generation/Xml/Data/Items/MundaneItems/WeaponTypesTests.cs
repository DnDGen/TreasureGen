using EquipmentGen.Core.Data.Items;
using EquipmentGen.Tests.Unit.Generation.Xml.Data.Attributes;
using NUnit.Framework;

namespace EquipmentGen.Tests.Unit.Generation.Xml.Data.Items.MundaneItems
{
    [TestFixture, TypesTableName("WeaponTypes")]
    public class WeaponTypesTests : TypesTest
    {
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
            var types = new[] 
            {
                ItemsConstants.ItemTypes.Weapon,
                ItemsConstants.Gear.Types.Metal,
                ItemsConstants.Gear.Types.Uncommon,
                ItemsConstants.Gear.Types.DoubleWeapon,
                ItemsConstants.Gear.Types.Melee 
            };

            AssertContent(ItemsConstants.Gear.Weapons.OrcDoubleAxe, types);
        }

        [Test]
        public void BattleaxeGearTypes()
        {
            var types = new[]
            {
                ItemsConstants.ItemTypes.Weapon,
                ItemsConstants.Gear.Types.Metal,
                ItemsConstants.Gear.Types.Uncommon,
                ItemsConstants.Gear.Types.Melee 
            };

            AssertContent(ItemsConstants.Gear.Weapons.Battleaxe, types);
        }

        [Test]
        public void SpikedChainGearTypes()
        {
            var types = new[]
            {
                ItemsConstants.ItemTypes.Weapon,
                ItemsConstants.Gear.Types.Metal,
                ItemsConstants.Gear.Types.Uncommon, 
                ItemsConstants.Gear.Types.Melee 
            };

            AssertContent(ItemsConstants.Gear.Weapons.SpikedChain, types);
        }

        [Test]
        public void ClubGearTypes()
        {
            var types = new[] 
            {
                ItemsConstants.ItemTypes.Weapon,
                ItemsConstants.Gear.Types.Wood, 
                ItemsConstants.Gear.Types.Uncommon, 
                ItemsConstants.Gear.Types.Melee 
            };

            AssertContent(ItemsConstants.Gear.Weapons.Club, types);
        }

        [Test]
        public void HandCrossbowGearTypes()
        {
            var types = new[]
            {
                ItemsConstants.ItemTypes.Weapon,
                ItemsConstants.Gear.Types.Metal, 
                ItemsConstants.Gear.Types.Uncommon, 
                ItemsConstants.Gear.Types.Ranged 
            };

            AssertContent(ItemsConstants.Gear.Weapons.HandCrossbow, types);
        }

        [Test]
        public void RepeatingCrossbowGearTypes()
        {
            var types = new[] 
            {
                ItemsConstants.ItemTypes.Weapon, 
                ItemsConstants.Gear.Types.Metal, 
                ItemsConstants.Gear.Types.Uncommon, 
                ItemsConstants.Gear.Types.Ranged 
            };

            AssertContent(ItemsConstants.Gear.Weapons.RepeatingCrossbow, types);
        }

        [Test]
        public void PunchingDaggerGearTypes()
        {
            var types = new[] 
            {
                ItemsConstants.ItemTypes.Weapon,
                ItemsConstants.Gear.Types.Metal,
                ItemsConstants.Gear.Types.Uncommon, 
                ItemsConstants.Gear.Types.Melee 
            };

            AssertContent(ItemsConstants.Gear.Weapons.PunchingDagger, types);
        }

        [Test]
        public void FalchionGearTypes()
        {
            var types = new[] 
            {
                ItemsConstants.ItemTypes.Weapon,
                ItemsConstants.Gear.Types.Metal,
                ItemsConstants.Gear.Types.Uncommon, 
                ItemsConstants.Gear.Types.Melee 
            };

            AssertContent(ItemsConstants.Gear.Weapons.Falchion, types);
        }

        [Test]
        public void DireFlailGearTypes()
        {
            var types = new[] 
            {
                ItemsConstants.ItemTypes.Weapon, 
                ItemsConstants.Gear.Types.Metal,
                ItemsConstants.Gear.Types.Uncommon,
                ItemsConstants.Gear.Types.Melee,
                ItemsConstants.Gear.Types.DoubleWeapon
            };

            AssertContent(ItemsConstants.Gear.Weapons.DireFlail, types);
        }

        [Test]
        public void HeavyFlailGearTypes()
        {
            var types = new[] 
            {
                ItemsConstants.ItemTypes.Weapon,
                ItemsConstants.Gear.Types.Metal,
                ItemsConstants.Gear.Types.Uncommon,
                ItemsConstants.Gear.Types.Melee 
            };

            AssertContent(ItemsConstants.Gear.Weapons.HeavyFlail, types);
        }

        [Test]
        public void LightFlailGearTypes()
        {
            var types = new[] 
            {
                ItemsConstants.ItemTypes.Weapon,
                ItemsConstants.Gear.Types.Metal, 
                ItemsConstants.Gear.Types.Uncommon,
                ItemsConstants.Gear.Types.Melee 
            };

            AssertContent(ItemsConstants.Gear.Weapons.LightFlail, types);
        }

        [Test]
        public void GauntletGearTypes()
        {
            var types = new[] 
            {
                ItemsConstants.ItemTypes.Weapon,
                ItemsConstants.Gear.Types.Metal, 
                ItemsConstants.Gear.Types.Uncommon,
                ItemsConstants.Gear.Types.Melee 
            };

            AssertContent(ItemsConstants.Gear.Weapons.Gauntlet, types);
        }

        [Test]
        public void SpikedGauntletGearTypes()
        {
            var types = new[] 
            {
                ItemsConstants.ItemTypes.Weapon,
                ItemsConstants.Gear.Types.Metal,
                ItemsConstants.Gear.Types.Uncommon, 
                ItemsConstants.Gear.Types.Melee 
            };

            AssertContent(ItemsConstants.Gear.Weapons.SpikedGauntlet, types);
        }

        [Test]
        public void GlaiveGearTypes()
        {
            var types = new[]
            {
                ItemsConstants.ItemTypes.Weapon,
                ItemsConstants.Gear.Types.Metal,
                ItemsConstants.Gear.Types.Uncommon,
                ItemsConstants.Gear.Types.Melee
            };

            AssertContent(ItemsConstants.Gear.Weapons.Glaive, types);
        }

        [Test]
        public void GreatclubGearTypes()
        {
            var types = new[] 
            {
                ItemsConstants.ItemTypes.Weapon, 
                ItemsConstants.Gear.Types.Wood, 
                ItemsConstants.Gear.Types.Uncommon,
                ItemsConstants.Gear.Types.Melee 
            };

            AssertContent(ItemsConstants.Gear.Weapons.Greatclub, types);
        }

        [Test]
        public void GuisarmeGearTypes()
        {
            var types = new[] 
            {
                ItemsConstants.ItemTypes.Weapon,
                ItemsConstants.Gear.Types.Metal, 
                ItemsConstants.Gear.Types.Uncommon,
                ItemsConstants.Gear.Types.Melee
            };

            AssertContent(ItemsConstants.Gear.Weapons.Guisarme, types);
        }

        [Test]
        public void HalberdGearTypes()
        {
            var types = new[] 
            {
                ItemsConstants.ItemTypes.Weapon,
                ItemsConstants.Gear.Types.Metal, 
                ItemsConstants.Gear.Types.Uncommon,
                ItemsConstants.Gear.Types.Melee 
            };

            AssertContent(ItemsConstants.Gear.Weapons.Halberd, types);
        }

        [Test]
        public void HalfspearGearTypes()
        {
            var types = new[] 
            {
                ItemsConstants.ItemTypes.Weapon, 
                ItemsConstants.Gear.Types.Metal, 
                ItemsConstants.Gear.Types.Wood, 
                ItemsConstants.Gear.Types.Uncommon,
                ItemsConstants.Gear.Types.Melee 
            };

            AssertContent(ItemsConstants.Gear.Weapons.Halfspear, types);
        }

        [Test]
        public void GnomeHookedHammerGearTypes()
        {
            var types = new[] 
            {
                ItemsConstants.ItemTypes.Weapon,
                ItemsConstants.Gear.Types.Metal, 
                ItemsConstants.Gear.Types.Uncommon,
                ItemsConstants.Gear.Types.Melee,
                ItemsConstants.Gear.Types.DoubleWeapon 
            };

            AssertContent(ItemsConstants.Gear.Weapons.GnomeHookedHammer, types);
        }

        [Test]
        public void LightHammerGearTypes()
        {
            var types = new[] 
            {
                ItemsConstants.ItemTypes.Weapon,
                ItemsConstants.Gear.Types.Metal,
                ItemsConstants.Gear.Types.Uncommon,
                ItemsConstants.Gear.Types.Melee
            };

            AssertContent(ItemsConstants.Gear.Weapons.LightHammer, types);
        }

        [Test]
        public void HandaxeGearTypes()
        {
            var types = new[] 
            {
                ItemsConstants.ItemTypes.Weapon,
                ItemsConstants.Gear.Types.Metal,
                ItemsConstants.Gear.Types.Uncommon,
                ItemsConstants.Gear.Types.Melee 
            };

            AssertContent(ItemsConstants.Gear.Weapons.Handaxe, types);
        }

        [Test]
        public void KukriGearTypes()
        {
            var types = new[] 
            {
                ItemsConstants.ItemTypes.Weapon,
                ItemsConstants.Gear.Types.Metal, 
                ItemsConstants.Gear.Types.Uncommon,
                ItemsConstants.Gear.Types.Melee 
            };

            AssertContent(ItemsConstants.Gear.Weapons.Kukri, types);
        }

        [Test]
        public void LanceGearTypes()
        {
            var types = new[] 
            {
                ItemsConstants.ItemTypes.Weapon, 
                ItemsConstants.Gear.Types.Wood,
                ItemsConstants.Gear.Types.Metal, 
                ItemsConstants.Gear.Types.Uncommon,
                ItemsConstants.Gear.Types.Melee
            };

            AssertContent(ItemsConstants.Gear.Weapons.Lance, types);
        }

        [Test]
        public void LongspearGearTypes()
        {
            var types = new[] 
            {
                ItemsConstants.ItemTypes.Weapon, 
                ItemsConstants.Gear.Types.Wood,
                ItemsConstants.Gear.Types.Metal, 
                ItemsConstants.Gear.Types.Uncommon,
                ItemsConstants.Gear.Types.Melee 
            };

            AssertContent(ItemsConstants.Gear.Weapons.Longspear, types);
        }

        [Test]
        public void MorningstarGearTypes()
        {
            var types = new[] 
            {
                ItemsConstants.ItemTypes.Weapon,
                ItemsConstants.Gear.Types.Metal, 
                ItemsConstants.Gear.Types.Uncommon,
                ItemsConstants.Gear.Types.Melee 
            };

            AssertContent(ItemsConstants.Gear.Weapons.Morningstar, types);
        }

        [Test]
        public void NetGearTypes()
        {
            var types = new[] 
            {
                ItemsConstants.ItemTypes.Weapon, 
                ItemsConstants.Gear.Types.Uncommon, 
                ItemsConstants.Gear.Types.Ranged 
            };

            AssertContent(ItemsConstants.Gear.Weapons.Net, types);
        }

        [Test]
        public void HeavyPickGearTypes()
        {
            var types = new[] 
            {
                ItemsConstants.ItemTypes.Weapon, 
                ItemsConstants.Gear.Types.Metal,
                ItemsConstants.Gear.Types.Uncommon,
                ItemsConstants.Gear.Types.Melee 
            };

            AssertContent(ItemsConstants.Gear.Weapons.HeavyPick, types);
        }

        [Test]
        public void LightPickGearTypes()
        {
            var types = new[] 
            {
                ItemsConstants.ItemTypes.Weapon,
                ItemsConstants.Gear.Types.Metal,
                ItemsConstants.Gear.Types.Uncommon, 
                ItemsConstants.Gear.Types.Melee
            };

            AssertContent(ItemsConstants.Gear.Weapons.LightPick, types);
        }

        [Test]
        public void RanseurGearTypes()
        {
            var types = new[] 
            {
                ItemsConstants.ItemTypes.Weapon,
                ItemsConstants.Gear.Types.Wood,
                ItemsConstants.Gear.Types.Metal, 
                ItemsConstants.Gear.Types.Uncommon,
                ItemsConstants.Gear.Types.Melee 
            };

            AssertContent(ItemsConstants.Gear.Weapons.Ranseur, types);
        }

        [Test]
        public void SapGearTypes()
        {
            var types = new[] 
            {
                ItemsConstants.ItemTypes.Weapon,
                ItemsConstants.Gear.Types.Uncommon,
                ItemsConstants.Gear.Types.Melee
            };

            AssertContent(ItemsConstants.Gear.Weapons.Sap, types);
        }

        [Test]
        public void ScytheGearTypes()
        {
            var types = new[] 
            {
                ItemsConstants.ItemTypes.Weapon,
                ItemsConstants.Gear.Types.Wood,
                ItemsConstants.Gear.Types.Metal,
                ItemsConstants.Gear.Types.Uncommon,
                ItemsConstants.Gear.Types.Melee 
            };

            AssertContent(ItemsConstants.Gear.Weapons.Scythe, types);
        }

        [Test]
        public void ShurikenGearTypes()
        {
            var types = new[] 
            {
                ItemsConstants.ItemTypes.Weapon, 
                ItemsConstants.Gear.Types.Metal,
                ItemsConstants.Gear.Types.Uncommon,
                ItemsConstants.Gear.Types.Ranged 
            };

            AssertContent(ItemsConstants.Gear.Weapons.Shuriken, types);
        }

        [Test]
        public void SickleGearTypes()
        {
            var types = new[] 
            {
                ItemsConstants.ItemTypes.Weapon, 
                ItemsConstants.Gear.Types.Metal, 
                ItemsConstants.Gear.Types.Uncommon,
                ItemsConstants.Gear.Types.Melee 
            };

            AssertContent(ItemsConstants.Gear.Weapons.Sickle, types);
        }

        [Test]
        public void TwoBladedSwordGearTypes()
        {
            var types = new[] 
            {
                ItemsConstants.ItemTypes.Weapon,
                ItemsConstants.Gear.Types.Metal,
                ItemsConstants.Gear.Types.Uncommon,
                ItemsConstants.Gear.Types.Melee, 
                ItemsConstants.Gear.Types.DoubleWeapon
            };

            AssertContent(ItemsConstants.Gear.Weapons.TwoBladedSword, types);
        }

        [Test]
        public void TridentGearTypes()
        {
            var types = new[] 
            {
                ItemsConstants.ItemTypes.Weapon,
                ItemsConstants.Gear.Types.Metal,
                ItemsConstants.Gear.Types.Uncommon,
                ItemsConstants.Gear.Types.Melee 
            };

            AssertContent(ItemsConstants.Gear.Weapons.Trident, types);
        }

        [Test]
        public void DwarvenUrgroshGearTypes()
        {
            var types = new[] 
            {
                ItemsConstants.ItemTypes.Weapon,
                ItemsConstants.Gear.Types.Metal, 
                ItemsConstants.Gear.Types.Uncommon,
                ItemsConstants.Gear.Types.Melee, 
                ItemsConstants.Gear.Types.DoubleWeapon
            };

            AssertContent(ItemsConstants.Gear.Weapons.DwarvenUrgrosh, types);
        }

        [Test]
        public void WarhammerGearTypes()
        {
            var types = new[] 
            {
                ItemsConstants.ItemTypes.Weapon,
                ItemsConstants.Gear.Types.Metal, 
                ItemsConstants.Gear.Types.Uncommon,
                ItemsConstants.Gear.Types.Melee 
            };

            AssertContent(ItemsConstants.Gear.Weapons.Warhammer, types);
        }

        [Test]
        public void WhipGearTypes()
        {
            var types = new[]
            {
                ItemsConstants.ItemTypes.Weapon,
                ItemsConstants.Gear.Types.Uncommon, 
                ItemsConstants.Gear.Types.Melee 
            };

            AssertContent(ItemsConstants.Gear.Weapons.Whip, types);
        }

        [Test]
        public void ThrowingAxeGearTypes()
        {
            var types = new[] 
            {
                ItemsConstants.ItemTypes.Weapon, 
                ItemsConstants.Gear.Types.Common, 
                ItemsConstants.Gear.Types.Ranged, 
                ItemsConstants.Gear.Types.Metal 
            };

            AssertContent(ItemsConstants.Gear.Weapons.ThrowingAxe, types);
        }

        [Test]
        public void HeavyCrossbowGearTypes()
        {
            var types = new[] 
            {
                ItemsConstants.ItemTypes.Weapon, 
                ItemsConstants.Gear.Types.Common, 
                ItemsConstants.Gear.Types.Ranged,
                ItemsConstants.Gear.Types.Wood
            };

            AssertContent(ItemsConstants.Gear.Weapons.HeavyCrossbow, types);
        }

        [Test]
        public void LightCrossbowGearTypes()
        {
            var types = new[] 
            {
                ItemsConstants.ItemTypes.Weapon,
                ItemsConstants.Gear.Types.Common,
                ItemsConstants.Gear.Types.Ranged,
                ItemsConstants.Gear.Types.Wood 
            };

            AssertContent(ItemsConstants.Gear.Weapons.LightCrossbow, types);
        }

        [Test]
        public void DartGearTypes()
        {
            var types = new[] 
            {
                ItemsConstants.ItemTypes.Weapon, 
                ItemsConstants.Gear.Types.Common, 
                ItemsConstants.Gear.Types.Ranged, 
                ItemsConstants.Gear.Types.Metal
            };

            AssertContent(ItemsConstants.Gear.Weapons.Dart, types);
        }

        [Test]
        public void JavelinGearTypes()
        {
            var types = new[] 
            {
                ItemsConstants.ItemTypes.Weapon, 
                ItemsConstants.Gear.Types.Common, 
                ItemsConstants.Gear.Types.Ranged, 
                ItemsConstants.Gear.Types.Metal,
                ItemsConstants.Gear.Types.Wood 
            };

            AssertContent(ItemsConstants.Gear.Weapons.Javelin, types);
        }

        [Test]
        public void ShortbowGearTypes()
        {
            var types = new[] 
            {
                ItemsConstants.ItemTypes.Weapon, 
                ItemsConstants.Gear.Types.Common, 
                ItemsConstants.Gear.Types.Ranged, 
                ItemsConstants.Gear.Types.Wood
            };

            AssertContent(ItemsConstants.Gear.Weapons.Shortbow, types);
        }

        [Test]
        public void CompositePlus0ShortbowGearTypes()
        {
            var types = new[] 
            {
                ItemsConstants.ItemTypes.Weapon, 
                ItemsConstants.Gear.Types.Common, 
                ItemsConstants.Gear.Types.Ranged, 
                ItemsConstants.Gear.Types.Wood
            };

            AssertContent(ItemsConstants.Gear.Weapons.CompositePlus0Shortbow, types);
        }

        [Test]
        public void CompositePlus1ShortbowGearTypes()
        {
            var types = new[] 
            {
                ItemsConstants.ItemTypes.Weapon, 
                ItemsConstants.Gear.Types.Common, 
                ItemsConstants.Gear.Types.Ranged, 
                ItemsConstants.Gear.Types.Wood
            };

            AssertContent(ItemsConstants.Gear.Weapons.CompositePlus1Shortbow, types);
        }

        [Test]
        public void CompositePlus2ShortbowGearTypes()
        {
            var types = new[] 
            {
                ItemsConstants.ItemTypes.Weapon, 
                ItemsConstants.Gear.Types.Common, 
                ItemsConstants.Gear.Types.Ranged, 
                ItemsConstants.Gear.Types.Wood
            };

            AssertContent(ItemsConstants.Gear.Weapons.CompositePlus2Shortbow, types);
        }

        [Test]
        public void SlingGearTypes()
        {
            var types = new[] 
            {
                ItemsConstants.ItemTypes.Weapon, 
                ItemsConstants.Gear.Types.Common, 
                ItemsConstants.Gear.Types.Ranged
            };

            AssertContent(ItemsConstants.Gear.Weapons.Sling, types);
        }

        [Test]
        public void LongbowGearTypes()
        {
            var types = new[] 
            {
                ItemsConstants.ItemTypes.Weapon, 
                ItemsConstants.Gear.Types.Common, 
                ItemsConstants.Gear.Types.Ranged, 
                ItemsConstants.Gear.Types.Wood
            };

            AssertContent(ItemsConstants.Gear.Weapons.Longbow, types);
        }

        [Test]
        public void CompositePlus0LongbowGearTypes()
        {
            var types = new[] 
            {
                ItemsConstants.ItemTypes.Weapon, 
                ItemsConstants.Gear.Types.Common, 
                ItemsConstants.Gear.Types.Ranged, 
                ItemsConstants.Gear.Types.Wood
            };

            AssertContent(ItemsConstants.Gear.Weapons.CompositePlus0Longbow, types);
        }

        [Test]
        public void CompositePlus1LongbowGearTypes()
        {
            var types = new[] 
            {
                ItemsConstants.ItemTypes.Weapon, 
                ItemsConstants.Gear.Types.Common, 
                ItemsConstants.Gear.Types.Ranged, 
                ItemsConstants.Gear.Types.Wood
            };

            AssertContent(ItemsConstants.Gear.Weapons.CompositePlus1Longbow, types);
        }

        [Test]
        public void CompositePlus2LongbowGearTypes()
        {
            var types = new[] 
            {
                ItemsConstants.ItemTypes.Weapon, 
                ItemsConstants.Gear.Types.Common, 
                ItemsConstants.Gear.Types.Ranged, 
                ItemsConstants.Gear.Types.Wood
            };

            AssertContent(ItemsConstants.Gear.Weapons.CompositePlus2Longbow, types);
        }

        [Test]
        public void CompositePlus3LongbowGearTypes()
        {
            var types = new[] 
            {
                ItemsConstants.ItemTypes.Weapon, 
                ItemsConstants.Gear.Types.Common, 
                ItemsConstants.Gear.Types.Ranged, 
                ItemsConstants.Gear.Types.Wood
            };

            AssertContent(ItemsConstants.Gear.Weapons.CompositePlus3Longbow, types);
        }

        [Test]
        public void CompositePlus4LongbowGearTypes()
        {
            var types = new[] 
            {
                ItemsConstants.ItemTypes.Weapon, 
                ItemsConstants.Gear.Types.Common, 
                ItemsConstants.Gear.Types.Ranged, 
                ItemsConstants.Gear.Types.Wood
            };

            AssertContent(ItemsConstants.Gear.Weapons.CompositePlus4Longbow, types);
        }
    }
}