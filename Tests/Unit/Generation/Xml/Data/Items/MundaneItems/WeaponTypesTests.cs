using EquipmentGen.Core.Data.Items.Constants;
using EquipmentGen.Tests.Unit.Generation.Xml.Data.Attributes;
using NUnit.Framework;

namespace EquipmentGen.Tests.Unit.Generation.Xml.Data.Items.MundaneItems
{
    [TestFixture, TypesTable("WeaponTypes")]
    public class WeaponTypesTests : TypesTest
    {
        [Test]
        public void DaggerTypes()
        {
            var types = new[]
            {
                ItemTypeConstants.Weapon,
                TypeConstants.Metal,
                TypeConstants.Common,
                TypeConstants.Melee,
                TypeConstants.NotBludgeoning,
                TypeConstants.Slashing,
                TypeConstants.Ranged,
                TypeConstants.Thrown
            };

            AssertContent(WeaponConstants.Dagger, types);
        }

        [Test]
        public void GreataxeTypes()
        {
            var types = new[] 
            {
                ItemTypeConstants.Weapon,
                TypeConstants.Metal,
                TypeConstants.Common,
                TypeConstants.Melee,
                TypeConstants.NotBludgeoning,
                TypeConstants.Slashing
            };

            AssertContent(WeaponConstants.Greataxe, types);
        }

        [Test]
        public void GreatswordTypes()
        {
            var types = new[] 
            {
                ItemTypeConstants.Weapon,
                TypeConstants.Metal,
                TypeConstants.Common,
                TypeConstants.Melee,
                TypeConstants.NotBludgeoning,
                TypeConstants.Slashing
            };

            AssertContent(WeaponConstants.Greatsword, types);
        }

        [Test]
        public void KamaTypes()
        {
            var types = new[] 
            {
                ItemTypeConstants.Weapon,
                TypeConstants.Wood,
                TypeConstants.Metal,
                TypeConstants.Common,
                TypeConstants.Melee,
                TypeConstants.NotBludgeoning,
                TypeConstants.Slashing
            };

            AssertContent(WeaponConstants.Kama, types);
        }

        [Test]
        public void LongswordTypes()
        {
            var types = new[] 
            {
                ItemTypeConstants.Weapon,
                TypeConstants.Metal,
                TypeConstants.Common,
                TypeConstants.Melee,
                TypeConstants.NotBludgeoning,
                TypeConstants.Slashing
            };

            AssertContent(WeaponConstants.Longsword, types);
        }

        [Test]
        public void LightMaceTypes()
        {
            var types = new[] 
            {
                ItemTypeConstants.Weapon,
                TypeConstants.Metal,
                TypeConstants.Common,
                TypeConstants.Melee,
                TypeConstants.Bludgeoning
            };

            AssertContent(WeaponConstants.LightMace, types);
        }

        [Test]
        public void HeavyMaceTypes()
        {
            var types = new[] 
            {
                ItemTypeConstants.Weapon, 
                TypeConstants.Metal,
                TypeConstants.Common, 
                TypeConstants.Melee,
                TypeConstants.Bludgeoning
            };

            AssertContent(WeaponConstants.HeavyMace, types);
        }

        [Test]
        public void NunchakuTypes()
        {
            var types = new[] 
            {
                ItemTypeConstants.Weapon,
                TypeConstants.Wood,
                TypeConstants.Common,
                TypeConstants.Melee,
                TypeConstants.Bludgeoning
            };

            AssertContent(WeaponConstants.Nunchaku, types);
        }

        [Test]
        public void QuarterstaffTypes()
        {
            var types = new[] 
            {
                ItemTypeConstants.Weapon,
                TypeConstants.Wood,
                TypeConstants.Common,
                TypeConstants.DoubleWeapon, 
                TypeConstants.Melee,
                TypeConstants.Bludgeoning
            };

            AssertContent(WeaponConstants.Quarterstaff, types);
        }

        [Test]
        public void RapierTypes()
        {
            var types = new[] 
            {
                ItemTypeConstants.Weapon,
                TypeConstants.Metal, 
                TypeConstants.Common,
                TypeConstants.Melee,
                TypeConstants.NotBludgeoning
            };

            AssertContent(WeaponConstants.Rapier, types);
        }

        [Test]
        public void ScimitarTypes()
        {
            var types = new[]
            {
                ItemTypeConstants.Weapon,
                TypeConstants.Metal,
                TypeConstants.Common, 
                TypeConstants.Melee,
                TypeConstants.NotBludgeoning,
                TypeConstants.Slashing
            };

            AssertContent(WeaponConstants.Scimitar, types);
        }

        [Test]
        public void ShortspearTypes()
        {
            var types = new[] 
            {
                ItemTypeConstants.Weapon,
                TypeConstants.Wood,
                TypeConstants.Metal,
                TypeConstants.Common,
                TypeConstants.Melee,
                TypeConstants.NotBludgeoning,
                TypeConstants.Ranged,
                TypeConstants.Thrown
            };

            AssertContent(WeaponConstants.Shortspear, types);
        }

        [Test]
        public void SianghamTypes()
        {
            var types = new[] 
            {
                ItemTypeConstants.Weapon,
                TypeConstants.Metal,
                TypeConstants.Common,
                TypeConstants.Melee,
                TypeConstants.NotBludgeoning
            };

            AssertContent(WeaponConstants.Siangham, types);
        }

        [Test]
        public void BastardSwordTypes()
        {
            var types = new[]
            {
                ItemTypeConstants.Weapon,
                TypeConstants.Metal,
                TypeConstants.Common,
                TypeConstants.Melee,
                TypeConstants.NotBludgeoning,
                TypeConstants.Slashing
            };

            AssertContent(WeaponConstants.BastardSword, types);
        }

        [Test]
        public void ShortSwordTypes()
        {
            var types = new[] 
            {
                ItemTypeConstants.Weapon,
                TypeConstants.Metal,
                TypeConstants.Common,
                TypeConstants.Melee,
                TypeConstants.NotBludgeoning,
                TypeConstants.Slashing
            };

            AssertContent(WeaponConstants.ShortSword, types);
        }

        [Test]
        public void DwarvenWaraxeTypes()
        {
            var types = new[] 
            {
                ItemTypeConstants.Weapon,
                TypeConstants.Metal, 
                TypeConstants.Common,
                TypeConstants.Melee,
                TypeConstants.NotBludgeoning,
                TypeConstants.Slashing
            };

            AssertContent(WeaponConstants.DwarvenWaraxe, types);
        }

        [Test]
        public void OrcDoubleAxeTypes()
        {
            var types = new[] 
            {
                ItemTypeConstants.Weapon,
                TypeConstants.Metal,
                TypeConstants.Uncommon,
                TypeConstants.DoubleWeapon,
                TypeConstants.Melee,
                TypeConstants.NotBludgeoning,
                TypeConstants.Slashing
            };

            AssertContent(WeaponConstants.OrcDoubleAxe, types);
        }

        [Test]
        public void BattleaxeTypes()
        {
            var types = new[]
            {
                ItemTypeConstants.Weapon,
                TypeConstants.Metal,
                TypeConstants.Uncommon,
                TypeConstants.Melee,
                TypeConstants.NotBludgeoning,
                TypeConstants.Slashing
            };

            AssertContent(WeaponConstants.Battleaxe, types);
        }

        [Test]
        public void SpikedChainTypes()
        {
            var types = new[]
            {
                ItemTypeConstants.Weapon,
                TypeConstants.Metal,
                TypeConstants.Uncommon, 
                TypeConstants.Melee,
                TypeConstants.NotBludgeoning
            };

            AssertContent(WeaponConstants.SpikedChain, types);
        }

        [Test]
        public void ClubTypes()
        {
            var types = new[] 
            {
                ItemTypeConstants.Weapon,
                TypeConstants.Wood, 
                TypeConstants.Uncommon, 
                TypeConstants.Melee,
                TypeConstants.Bludgeoning,
                TypeConstants.Ranged,
                TypeConstants.Thrown
            };

            AssertContent(WeaponConstants.Club, types);
        }

        [Test]
        public void HandCrossbowTypes()
        {
            var types = new[]
            {
                ItemTypeConstants.Weapon,
                TypeConstants.Metal, 
                TypeConstants.Uncommon, 
                TypeConstants.Ranged,
                TypeConstants.NotBludgeoning
            };

            AssertContent(WeaponConstants.HandCrossbow, types);
        }

        [Test]
        public void RepeatingCrossbowTypes()
        {
            var types = new[] 
            {
                ItemTypeConstants.Weapon, 
                TypeConstants.Metal, 
                TypeConstants.Uncommon, 
                TypeConstants.Ranged,
                TypeConstants.NotBludgeoning
            };

            AssertContent(WeaponConstants.RepeatingCrossbow, types);
        }

        [Test]
        public void PunchingDaggerTypes()
        {
            var types = new[] 
            {
                ItemTypeConstants.Weapon,
                TypeConstants.Metal,
                TypeConstants.Uncommon, 
                TypeConstants.Melee,
                TypeConstants.NotBludgeoning
            };

            AssertContent(WeaponConstants.PunchingDagger, types);
        }

        [Test]
        public void FalchionTypes()
        {
            var types = new[] 
            {
                ItemTypeConstants.Weapon,
                TypeConstants.Metal,
                TypeConstants.Uncommon, 
                TypeConstants.Melee,
                TypeConstants.NotBludgeoning,
                TypeConstants.Slashing
            };

            AssertContent(WeaponConstants.Falchion, types);
        }

        [Test]
        public void DireFlailTypes()
        {
            var types = new[] 
            {
                ItemTypeConstants.Weapon, 
                TypeConstants.Metal,
                TypeConstants.Uncommon,
                TypeConstants.Melee,
                TypeConstants.DoubleWeapon,
                TypeConstants.Bludgeoning
            };

            AssertContent(WeaponConstants.DireFlail, types);
        }

        [Test]
        public void HeavyFlailTypes()
        {
            var types = new[] 
            {
                ItemTypeConstants.Weapon,
                TypeConstants.Metal,
                TypeConstants.Uncommon,
                TypeConstants.Melee,
                TypeConstants.Bludgeoning
            };

            AssertContent(WeaponConstants.HeavyFlail, types);
        }

        [Test]
        public void LightFlailTypes()
        {
            var types = new[] 
            {
                ItemTypeConstants.Weapon,
                TypeConstants.Metal, 
                TypeConstants.Uncommon,
                TypeConstants.Melee,
                TypeConstants.Bludgeoning
            };

            AssertContent(WeaponConstants.LightFlail, types);
        }

        [Test]
        public void GauntletTypes()
        {
            var types = new[] 
            {
                ItemTypeConstants.Weapon,
                TypeConstants.Metal, 
                TypeConstants.Uncommon,
                TypeConstants.Melee,
                TypeConstants.Bludgeoning
            };

            AssertContent(WeaponConstants.Gauntlet, types);
        }

        [Test]
        public void SpikedGauntletTypes()
        {
            var types = new[] 
            {
                ItemTypeConstants.Weapon,
                TypeConstants.Metal,
                TypeConstants.Uncommon, 
                TypeConstants.Melee,
                TypeConstants.NotBludgeoning
            };

            AssertContent(WeaponConstants.SpikedGauntlet, types);
        }

        [Test]
        public void GlaiveTypes()
        {
            var types = new[]
            {
                ItemTypeConstants.Weapon,
                TypeConstants.Metal,
                TypeConstants.Uncommon,
                TypeConstants.Melee,
                TypeConstants.NotBludgeoning,
                TypeConstants.Slashing
            };

            AssertContent(WeaponConstants.Glaive, types);
        }

        [Test]
        public void GreatclubTypes()
        {
            var types = new[] 
            {
                ItemTypeConstants.Weapon, 
                TypeConstants.Wood, 
                TypeConstants.Uncommon,
                TypeConstants.Melee,
                TypeConstants.Bludgeoning
            };

            AssertContent(WeaponConstants.Greatclub, types);
        }

        [Test]
        public void GuisarmeTypes()
        {
            var types = new[] 
            {
                ItemTypeConstants.Weapon,
                TypeConstants.Metal, 
                TypeConstants.Uncommon,
                TypeConstants.Melee,
                TypeConstants.NotBludgeoning,
                TypeConstants.Slashing
            };

            AssertContent(WeaponConstants.Guisarme, types);
        }

        [Test]
        public void HalberdTypes()
        {
            var types = new[] 
            {
                ItemTypeConstants.Weapon,
                TypeConstants.Metal, 
                TypeConstants.Uncommon,
                TypeConstants.Melee,
                TypeConstants.NotBludgeoning,
                TypeConstants.Slashing
            };

            AssertContent(WeaponConstants.Halberd, types);
        }

        [Test]
        public void HalfspearTypes()
        {
            var types = new[] 
            {
                ItemTypeConstants.Weapon, 
                TypeConstants.Metal, 
                TypeConstants.Wood, 
                TypeConstants.Uncommon,
                TypeConstants.Melee,
                TypeConstants.NotBludgeoning
            };

            AssertContent(WeaponConstants.Halfspear, types);
        }

        [Test]
        public void GnomeHookedHammerTypes()
        {
            var types = new[] 
            {
                ItemTypeConstants.Weapon,
                TypeConstants.Metal, 
                TypeConstants.Uncommon,
                TypeConstants.Melee,
                TypeConstants.DoubleWeapon,
                TypeConstants.NotBludgeoning,
                TypeConstants.Bludgeoning
            };

            AssertContent(WeaponConstants.GnomeHookedHammer, types);
        }

        [Test]
        public void LightHammerTypes()
        {
            var types = new[] 
            {
                ItemTypeConstants.Weapon,
                TypeConstants.Metal,
                TypeConstants.Uncommon,
                TypeConstants.Melee,
                TypeConstants.Bludgeoning,
                TypeConstants.Ranged,
                TypeConstants.Thrown
            };

            AssertContent(WeaponConstants.LightHammer, types);
        }

        [Test]
        public void HandaxeTypes()
        {
            var types = new[] 
            {
                ItemTypeConstants.Weapon,
                TypeConstants.Metal,
                TypeConstants.Uncommon,
                TypeConstants.Melee,
                TypeConstants.NotBludgeoning,
                TypeConstants.Slashing
            };

            AssertContent(WeaponConstants.Handaxe, types);
        }

        [Test]
        public void KukriTypes()
        {
            var types = new[] 
            {
                ItemTypeConstants.Weapon,
                TypeConstants.Metal, 
                TypeConstants.Uncommon,
                TypeConstants.Melee,
                TypeConstants.NotBludgeoning,
                TypeConstants.Slashing
            };

            AssertContent(WeaponConstants.Kukri, types);
        }

        [Test]
        public void LanceTypes()
        {
            var types = new[] 
            {
                ItemTypeConstants.Weapon, 
                TypeConstants.Wood,
                TypeConstants.Metal, 
                TypeConstants.Uncommon,
                TypeConstants.Melee,
                TypeConstants.NotBludgeoning
            };

            AssertContent(WeaponConstants.Lance, types);
        }

        [Test]
        public void LongspearTypes()
        {
            var types = new[] 
            {
                ItemTypeConstants.Weapon, 
                TypeConstants.Wood,
                TypeConstants.Metal, 
                TypeConstants.Uncommon,
                TypeConstants.Melee,
                TypeConstants.NotBludgeoning
            };

            AssertContent(WeaponConstants.Longspear, types);
        }

        [Test]
        public void MorningstarTypes()
        {
            var types = new[] 
            {
                ItemTypeConstants.Weapon,
                TypeConstants.Metal, 
                TypeConstants.Uncommon,
                TypeConstants.Melee,
                TypeConstants.NotBludgeoning,
                TypeConstants.Bludgeoning
            };

            AssertContent(WeaponConstants.Morningstar, types);
        }

        [Test]
        public void NetTypes()
        {
            var types = new[] 
            {
                ItemTypeConstants.Weapon, 
                TypeConstants.Uncommon, 
                TypeConstants.Ranged,
                TypeConstants.Thrown
            };

            AssertContent(WeaponConstants.Net, types);
        }

        [Test]
        public void HeavyPickTypes()
        {
            var types = new[] 
            {
                ItemTypeConstants.Weapon, 
                TypeConstants.Metal,
                TypeConstants.Uncommon,
                TypeConstants.Melee,
                TypeConstants.NotBludgeoning
            };

            AssertContent(WeaponConstants.HeavyPick, types);
        }

        [Test]
        public void LightPickTypes()
        {
            var types = new[] 
            {
                ItemTypeConstants.Weapon,
                TypeConstants.Metal,
                TypeConstants.Uncommon, 
                TypeConstants.Melee,
                TypeConstants.NotBludgeoning
            };

            AssertContent(WeaponConstants.LightPick, types);
        }

        [Test]
        public void RanseurTypes()
        {
            var types = new[] 
            {
                ItemTypeConstants.Weapon,
                TypeConstants.Wood,
                TypeConstants.Metal, 
                TypeConstants.Uncommon,
                TypeConstants.Melee,
                TypeConstants.NotBludgeoning
            };

            AssertContent(WeaponConstants.Ranseur, types);
        }

        [Test]
        public void SapTypes()
        {
            var types = new[] 
            {
                ItemTypeConstants.Weapon,
                TypeConstants.Uncommon,
                TypeConstants.Melee,
                TypeConstants.Bludgeoning
            };

            AssertContent(WeaponConstants.Sap, types);
        }

        [Test]
        public void ScytheTypes()
        {
            var types = new[] 
            {
                ItemTypeConstants.Weapon,
                TypeConstants.Wood,
                TypeConstants.Metal,
                TypeConstants.Uncommon,
                TypeConstants.Melee,
                TypeConstants.NotBludgeoning,
                TypeConstants.Slashing
            };

            AssertContent(WeaponConstants.Scythe, types);
        }

        [Test]
        public void ShurikenTypes()
        {
            var types = new[] 
            {
                ItemTypeConstants.Weapon, 
                TypeConstants.Metal,
                TypeConstants.Uncommon,
                TypeConstants.Ranged,
                TypeConstants.NotBludgeoning,
                TypeConstants.Thrown
            };

            AssertContent(WeaponConstants.Shuriken, types);
        }

        [Test]
        public void SickleTypes()
        {
            var types = new[] 
            {
                ItemTypeConstants.Weapon, 
                TypeConstants.Metal, 
                TypeConstants.Uncommon,
                TypeConstants.Melee,
                TypeConstants.NotBludgeoning,
                TypeConstants.Slashing
            };

            AssertContent(WeaponConstants.Sickle, types);
        }

        [Test]
        public void TwoBladedSwordTypes()
        {
            var types = new[] 
            {
                ItemTypeConstants.Weapon,
                TypeConstants.Metal,
                TypeConstants.Uncommon,
                TypeConstants.Melee, 
                TypeConstants.DoubleWeapon,
                TypeConstants.NotBludgeoning,
                TypeConstants.Slashing
            };

            AssertContent(WeaponConstants.TwoBladedSword, types);
        }

        [Test]
        public void TridentTypes()
        {
            var types = new[] 
            {
                ItemTypeConstants.Weapon,
                TypeConstants.Metal,
                TypeConstants.Uncommon,
                TypeConstants.Melee,
                TypeConstants.NotBludgeoning,
                TypeConstants.Ranged,
                TypeConstants.Thrown
            };

            AssertContent(WeaponConstants.Trident, types);
        }

        [Test]
        public void DwarvenUrgroshTypes()
        {
            var types = new[] 
            {
                ItemTypeConstants.Weapon,
                TypeConstants.Metal, 
                TypeConstants.Uncommon,
                TypeConstants.Melee, 
                TypeConstants.DoubleWeapon,
                TypeConstants.NotBludgeoning,
                TypeConstants.Slashing
            };

            AssertContent(WeaponConstants.DwarvenUrgrosh, types);
        }

        [Test]
        public void WarhammerTypes()
        {
            var types = new[] 
            {
                ItemTypeConstants.Weapon,
                TypeConstants.Metal, 
                TypeConstants.Uncommon,
                TypeConstants.Melee,
                TypeConstants.Bludgeoning
            };

            AssertContent(WeaponConstants.Warhammer, types);
        }

        [Test]
        public void WhipTypes()
        {
            var types = new[]
            {
                ItemTypeConstants.Weapon,
                TypeConstants.Uncommon, 
                TypeConstants.Melee,
                TypeConstants.NotBludgeoning,
                TypeConstants.Slashing
            };

            AssertContent(WeaponConstants.Whip, types);
        }

        [Test]
        public void ThrowingAxeTypes()
        {
            var types = new[] 
            {
                ItemTypeConstants.Weapon, 
                TypeConstants.Common, 
                TypeConstants.Ranged, 
                TypeConstants.Metal,
                TypeConstants.NotBludgeoning,
                TypeConstants.Slashing,
                TypeConstants.Thrown
            };

            AssertContent(WeaponConstants.ThrowingAxe, types);
        }

        [Test]
        public void HeavyCrossbowTypes()
        {
            var types = new[] 
            {
                ItemTypeConstants.Weapon, 
                TypeConstants.Common, 
                TypeConstants.Ranged,
                TypeConstants.Wood,
                TypeConstants.NotBludgeoning
            };

            AssertContent(WeaponConstants.HeavyCrossbow, types);
        }

        [Test]
        public void LightCrossbowTypes()
        {
            var types = new[] 
            {
                ItemTypeConstants.Weapon,
                TypeConstants.Common,
                TypeConstants.Ranged,
                TypeConstants.Wood,
                TypeConstants.NotBludgeoning
            };

            AssertContent(WeaponConstants.LightCrossbow, types);
        }

        [Test]
        public void DartTypes()
        {
            var types = new[] 
            {
                ItemTypeConstants.Weapon, 
                TypeConstants.Common, 
                TypeConstants.Ranged, 
                TypeConstants.Metal,
                TypeConstants.NotBludgeoning,
                TypeConstants.Thrown
            };

            AssertContent(WeaponConstants.Dart, types);
        }

        [Test]
        public void JavelinTypes()
        {
            var types = new[] 
            {
                ItemTypeConstants.Weapon, 
                TypeConstants.Common, 
                TypeConstants.Ranged, 
                TypeConstants.Metal,
                TypeConstants.Wood,
                TypeConstants.NotBludgeoning,
                TypeConstants.Thrown
            };

            AssertContent(WeaponConstants.Javelin, types);
        }

        [Test]
        public void ShortbowTypes()
        {
            var types = new[] 
            {
                ItemTypeConstants.Weapon, 
                TypeConstants.Common, 
                TypeConstants.Ranged, 
                TypeConstants.Wood,
                TypeConstants.NotBludgeoning
            };

            AssertContent(WeaponConstants.Shortbow, types);
        }

        [Test]
        public void CompositePlus0ShortbowTypes()
        {
            var types = new[] 
            {
                ItemTypeConstants.Weapon, 
                TypeConstants.Common, 
                TypeConstants.Ranged, 
                TypeConstants.Wood,
                TypeConstants.NotBludgeoning
            };

            AssertContent(WeaponConstants.CompositePlus0Shortbow, types);
        }

        [Test]
        public void CompositePlus1ShortbowTypes()
        {
            var types = new[] 
            {
                ItemTypeConstants.Weapon, 
                TypeConstants.Common, 
                TypeConstants.Ranged, 
                TypeConstants.Wood,
                TypeConstants.NotBludgeoning
            };

            AssertContent(WeaponConstants.CompositePlus1Shortbow, types);
        }

        [Test]
        public void CompositePlus2ShortbowTypes()
        {
            var types = new[] 
            {
                ItemTypeConstants.Weapon, 
                TypeConstants.Common, 
                TypeConstants.Ranged, 
                TypeConstants.Wood,
                TypeConstants.NotBludgeoning
            };

            AssertContent(WeaponConstants.CompositePlus2Shortbow, types);
        }

        [Test]
        public void SlingTypes()
        {
            var types = new[] 
            {
                ItemTypeConstants.Weapon, 
                TypeConstants.Common, 
                TypeConstants.Ranged,
                TypeConstants.Bludgeoning
            };

            AssertContent(WeaponConstants.Sling, types);
        }

        [Test]
        public void LongbowTypes()
        {
            var types = new[] 
            {
                ItemTypeConstants.Weapon, 
                TypeConstants.Common, 
                TypeConstants.Ranged, 
                TypeConstants.Wood,
                TypeConstants.NotBludgeoning
            };

            AssertContent(WeaponConstants.Longbow, types);
        }

        [Test]
        public void CompositePlus0LongbowTypes()
        {
            var types = new[] 
            {
                ItemTypeConstants.Weapon, 
                TypeConstants.Common, 
                TypeConstants.Ranged, 
                TypeConstants.Wood,
                TypeConstants.NotBludgeoning
            };

            AssertContent(WeaponConstants.CompositePlus0Longbow, types);
        }

        [Test]
        public void CompositePlus1LongbowTypes()
        {
            var types = new[] 
            {
                ItemTypeConstants.Weapon, 
                TypeConstants.Common, 
                TypeConstants.Ranged, 
                TypeConstants.Wood,
                TypeConstants.NotBludgeoning
            };

            AssertContent(WeaponConstants.CompositePlus1Longbow, types);
        }

        [Test]
        public void CompositePlus2LongbowTypes()
        {
            var types = new[] 
            {
                ItemTypeConstants.Weapon, 
                TypeConstants.Common, 
                TypeConstants.Ranged, 
                TypeConstants.Wood,
                TypeConstants.NotBludgeoning
            };

            AssertContent(WeaponConstants.CompositePlus2Longbow, types);
        }

        [Test]
        public void CompositePlus3LongbowTypes()
        {
            var types = new[] 
            {
                ItemTypeConstants.Weapon, 
                TypeConstants.Common, 
                TypeConstants.Ranged, 
                TypeConstants.Wood,
                TypeConstants.NotBludgeoning
            };

            AssertContent(WeaponConstants.CompositePlus3Longbow, types);
        }

        [Test]
        public void CompositePlus4LongbowTypes()
        {
            var types = new[] 
            {
                ItemTypeConstants.Weapon, 
                TypeConstants.Common, 
                TypeConstants.Ranged, 
                TypeConstants.Wood,
                TypeConstants.NotBludgeoning
            };

            AssertContent(WeaponConstants.CompositePlus4Longbow, types);
        }
    }
}