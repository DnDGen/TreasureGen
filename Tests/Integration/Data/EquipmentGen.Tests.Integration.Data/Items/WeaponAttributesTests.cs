using EquipmentGen.Core.Data.Items.Constants;
using EquipmentGen.Tests.Integration.Data.Attributes;
using NUnit.Framework;

namespace EquipmentGen.Tests.Integration.Data.Items
{
    [TestFixture, AttributesTable("WeaponAttributes")]
    public class WeaponAttributesTests : AttributesTests
    {
        [Test]
        public void DaggerAttributes()
        {
            var attributes = new[]
            {
                ItemTypeConstants.Weapon,
                AttributeConstants.Metal,
                AttributeConstants.Common,
                AttributeConstants.Melee,
                AttributeConstants.NotBludgeoning,
                AttributeConstants.Slashing,
                AttributeConstants.Ranged,
                AttributeConstants.Thrown
            };

            AssertContent(WeaponConstants.Dagger, attributes);
        }

        [Test]
        public void GreataxeAttributes()
        {
            var attributes = new[] 
            {
                ItemTypeConstants.Weapon,
                AttributeConstants.Metal,
                AttributeConstants.Common,
                AttributeConstants.Melee,
                AttributeConstants.NotBludgeoning,
                AttributeConstants.Slashing
            };

            AssertContent(WeaponConstants.Greataxe, attributes);
        }

        [Test]
        public void GreatswordAttributes()
        {
            var attributes = new[] 
            {
                ItemTypeConstants.Weapon,
                AttributeConstants.Metal,
                AttributeConstants.Common,
                AttributeConstants.Melee,
                AttributeConstants.NotBludgeoning,
                AttributeConstants.Slashing
            };

            AssertContent(WeaponConstants.Greatsword, attributes);
        }

        [Test]
        public void KamaAttributes()
        {
            var attributes = new[] 
            {
                ItemTypeConstants.Weapon,
                AttributeConstants.Wood,
                AttributeConstants.Metal,
                AttributeConstants.Common,
                AttributeConstants.Melee,
                AttributeConstants.NotBludgeoning,
                AttributeConstants.Slashing
            };

            AssertContent(WeaponConstants.Kama, attributes);
        }

        [Test]
        public void LongswordAttributes()
        {
            var attributes = new[] 
            {
                ItemTypeConstants.Weapon,
                AttributeConstants.Metal,
                AttributeConstants.Common,
                AttributeConstants.Melee,
                AttributeConstants.NotBludgeoning,
                AttributeConstants.Slashing
            };

            AssertContent(WeaponConstants.Longsword, attributes);
        }

        [Test]
        public void LightMaceAttributes()
        {
            var attributes = new[] 
            {
                ItemTypeConstants.Weapon,
                AttributeConstants.Metal,
                AttributeConstants.Common,
                AttributeConstants.Melee,
                AttributeConstants.Bludgeoning
            };

            AssertContent(WeaponConstants.LightMace, attributes);
        }

        [Test]
        public void HeavyMaceAttributes()
        {
            var attributes = new[] 
            {
                ItemTypeConstants.Weapon, 
                AttributeConstants.Metal,
                AttributeConstants.Common, 
                AttributeConstants.Melee,
                AttributeConstants.Bludgeoning
            };

            AssertContent(WeaponConstants.HeavyMace, attributes);
        }

        [Test]
        public void NunchakuAttributes()
        {
            var attributes = new[] 
            {
                ItemTypeConstants.Weapon,
                AttributeConstants.Wood,
                AttributeConstants.Common,
                AttributeConstants.Melee,
                AttributeConstants.Bludgeoning
            };

            AssertContent(WeaponConstants.Nunchaku, attributes);
        }

        [Test]
        public void QuarterstaffAttributes()
        {
            var attributes = new[] 
            {
                ItemTypeConstants.Weapon,
                AttributeConstants.Wood,
                AttributeConstants.Common,
                AttributeConstants.DoubleWeapon, 
                AttributeConstants.Melee,
                AttributeConstants.Bludgeoning
            };

            AssertContent(WeaponConstants.Quarterstaff, attributes);
        }

        [Test]
        public void RapierAttributes()
        {
            var attributes = new[] 
            {
                ItemTypeConstants.Weapon,
                AttributeConstants.Metal, 
                AttributeConstants.Common,
                AttributeConstants.Melee,
                AttributeConstants.NotBludgeoning
            };

            AssertContent(WeaponConstants.Rapier, attributes);
        }

        [Test]
        public void ScimitarAttributes()
        {
            var attributes = new[]
            {
                ItemTypeConstants.Weapon,
                AttributeConstants.Metal,
                AttributeConstants.Common, 
                AttributeConstants.Melee,
                AttributeConstants.NotBludgeoning,
                AttributeConstants.Slashing
            };

            AssertContent(WeaponConstants.Scimitar, attributes);
        }

        [Test]
        public void ShortspearAttributes()
        {
            var attributes = new[] 
            {
                ItemTypeConstants.Weapon,
                AttributeConstants.Wood,
                AttributeConstants.Metal,
                AttributeConstants.Common,
                AttributeConstants.Melee,
                AttributeConstants.NotBludgeoning,
                AttributeConstants.Ranged,
                AttributeConstants.Thrown
            };

            AssertContent(WeaponConstants.Shortspear, attributes);
        }

        [Test]
        public void SianghamAttributes()
        {
            var attributes = new[] 
            {
                ItemTypeConstants.Weapon,
                AttributeConstants.Metal,
                AttributeConstants.Common,
                AttributeConstants.Melee,
                AttributeConstants.NotBludgeoning
            };

            AssertContent(WeaponConstants.Siangham, attributes);
        }

        [Test]
        public void BastardSwordAttributes()
        {
            var attributes = new[]
            {
                ItemTypeConstants.Weapon,
                AttributeConstants.Metal,
                AttributeConstants.Common,
                AttributeConstants.Melee,
                AttributeConstants.NotBludgeoning,
                AttributeConstants.Slashing
            };

            AssertContent(WeaponConstants.BastardSword, attributes);
        }

        [Test]
        public void ShortSwordAttributes()
        {
            var attributes = new[] 
            {
                ItemTypeConstants.Weapon,
                AttributeConstants.Metal,
                AttributeConstants.Common,
                AttributeConstants.Melee,
                AttributeConstants.NotBludgeoning,
                AttributeConstants.Slashing
            };

            AssertContent(WeaponConstants.ShortSword, attributes);
        }

        [Test]
        public void DwarvenWaraxeAttributes()
        {
            var attributes = new[] 
            {
                ItemTypeConstants.Weapon,
                AttributeConstants.Metal, 
                AttributeConstants.Common,
                AttributeConstants.Melee,
                AttributeConstants.NotBludgeoning,
                AttributeConstants.Slashing
            };

            AssertContent(WeaponConstants.DwarvenWaraxe, attributes);
        }

        [Test]
        public void OrcDoubleAxeAttributes()
        {
            var attributes = new[] 
            {
                ItemTypeConstants.Weapon,
                AttributeConstants.Metal,
                AttributeConstants.Uncommon,
                AttributeConstants.DoubleWeapon,
                AttributeConstants.Melee,
                AttributeConstants.NotBludgeoning,
                AttributeConstants.Slashing
            };

            AssertContent(WeaponConstants.OrcDoubleAxe, attributes);
        }

        [Test]
        public void BattleaxeAttributes()
        {
            var attributes = new[]
            {
                ItemTypeConstants.Weapon,
                AttributeConstants.Metal,
                AttributeConstants.Uncommon,
                AttributeConstants.Melee,
                AttributeConstants.NotBludgeoning,
                AttributeConstants.Slashing
            };

            AssertContent(WeaponConstants.Battleaxe, attributes);
        }

        [Test]
        public void SpikedChainAttributes()
        {
            var attributes = new[]
            {
                ItemTypeConstants.Weapon,
                AttributeConstants.Metal,
                AttributeConstants.Uncommon, 
                AttributeConstants.Melee,
                AttributeConstants.NotBludgeoning
            };

            AssertContent(WeaponConstants.SpikedChain, attributes);
        }

        [Test]
        public void ClubAttributes()
        {
            var attributes = new[] 
            {
                ItemTypeConstants.Weapon,
                AttributeConstants.Wood, 
                AttributeConstants.Uncommon, 
                AttributeConstants.Melee,
                AttributeConstants.Bludgeoning,
                AttributeConstants.Ranged,
                AttributeConstants.Thrown
            };

            AssertContent(WeaponConstants.Club, attributes);
        }

        [Test]
        public void HandCrossbowAttributes()
        {
            var attributes = new[]
            {
                ItemTypeConstants.Weapon,
                AttributeConstants.Metal, 
                AttributeConstants.Uncommon, 
                AttributeConstants.Ranged,
                AttributeConstants.NotBludgeoning
            };

            AssertContent(WeaponConstants.HandCrossbow, attributes);
        }

        [Test]
        public void RepeatingCrossbowAttributes()
        {
            var attributes = new[] 
            {
                ItemTypeConstants.Weapon, 
                AttributeConstants.Metal, 
                AttributeConstants.Uncommon, 
                AttributeConstants.Ranged,
                AttributeConstants.NotBludgeoning
            };

            AssertContent(WeaponConstants.RepeatingCrossbow, attributes);
        }

        [Test]
        public void PunchingDaggerAttributes()
        {
            var attributes = new[] 
            {
                ItemTypeConstants.Weapon,
                AttributeConstants.Metal,
                AttributeConstants.Uncommon, 
                AttributeConstants.Melee,
                AttributeConstants.NotBludgeoning
            };

            AssertContent(WeaponConstants.PunchingDagger, attributes);
        }

        [Test]
        public void FalchionAttributes()
        {
            var attributes = new[] 
            {
                ItemTypeConstants.Weapon,
                AttributeConstants.Metal,
                AttributeConstants.Uncommon, 
                AttributeConstants.Melee,
                AttributeConstants.NotBludgeoning,
                AttributeConstants.Slashing
            };

            AssertContent(WeaponConstants.Falchion, attributes);
        }

        [Test]
        public void DireFlailAttributes()
        {
            var attributes = new[] 
            {
                ItemTypeConstants.Weapon, 
                AttributeConstants.Metal,
                AttributeConstants.Uncommon,
                AttributeConstants.Melee,
                AttributeConstants.DoubleWeapon,
                AttributeConstants.Bludgeoning
            };

            AssertContent(WeaponConstants.DireFlail, attributes);
        }

        [Test]
        public void HeavyFlailAttributes()
        {
            var attributes = new[] 
            {
                ItemTypeConstants.Weapon,
                AttributeConstants.Metal,
                AttributeConstants.Uncommon,
                AttributeConstants.Melee,
                AttributeConstants.Bludgeoning
            };

            AssertContent(WeaponConstants.HeavyFlail, attributes);
        }

        [Test]
        public void LightFlailAttributes()
        {
            var attributes = new[] 
            {
                ItemTypeConstants.Weapon,
                AttributeConstants.Metal, 
                AttributeConstants.Uncommon,
                AttributeConstants.Melee,
                AttributeConstants.Bludgeoning
            };

            AssertContent(WeaponConstants.LightFlail, attributes);
        }

        [Test]
        public void GauntletAttributes()
        {
            var attributes = new[] 
            {
                ItemTypeConstants.Weapon,
                AttributeConstants.Metal, 
                AttributeConstants.Uncommon,
                AttributeConstants.Melee,
                AttributeConstants.Bludgeoning
            };

            AssertContent(WeaponConstants.Gauntlet, attributes);
        }

        [Test]
        public void SpikedGauntletAttributes()
        {
            var attributes = new[] 
            {
                ItemTypeConstants.Weapon,
                AttributeConstants.Metal,
                AttributeConstants.Uncommon, 
                AttributeConstants.Melee,
                AttributeConstants.NotBludgeoning
            };

            AssertContent(WeaponConstants.SpikedGauntlet, attributes);
        }

        [Test]
        public void GlaiveAttributes()
        {
            var attributes = new[]
            {
                ItemTypeConstants.Weapon,
                AttributeConstants.Metal,
                AttributeConstants.Uncommon,
                AttributeConstants.Melee,
                AttributeConstants.NotBludgeoning,
                AttributeConstants.Slashing
            };

            AssertContent(WeaponConstants.Glaive, attributes);
        }

        [Test]
        public void GreatclubAttributes()
        {
            var attributes = new[] 
            {
                ItemTypeConstants.Weapon, 
                AttributeConstants.Wood, 
                AttributeConstants.Uncommon,
                AttributeConstants.Melee,
                AttributeConstants.Bludgeoning
            };

            AssertContent(WeaponConstants.Greatclub, attributes);
        }

        [Test]
        public void GuisarmeAttributes()
        {
            var attributes = new[] 
            {
                ItemTypeConstants.Weapon,
                AttributeConstants.Metal, 
                AttributeConstants.Uncommon,
                AttributeConstants.Melee,
                AttributeConstants.NotBludgeoning,
                AttributeConstants.Slashing
            };

            AssertContent(WeaponConstants.Guisarme, attributes);
        }

        [Test]
        public void HalberdAttributes()
        {
            var attributes = new[] 
            {
                ItemTypeConstants.Weapon,
                AttributeConstants.Metal, 
                AttributeConstants.Uncommon,
                AttributeConstants.Melee,
                AttributeConstants.NotBludgeoning,
                AttributeConstants.Slashing
            };

            AssertContent(WeaponConstants.Halberd, attributes);
        }

        [Test]
        public void HalfspearAttributes()
        {
            var attributes = new[] 
            {
                ItemTypeConstants.Weapon, 
                AttributeConstants.Metal, 
                AttributeConstants.Wood, 
                AttributeConstants.Uncommon,
                AttributeConstants.Melee,
                AttributeConstants.NotBludgeoning
            };

            AssertContent(WeaponConstants.Halfspear, attributes);
        }

        [Test]
        public void GnomeHookedHammerAttributes()
        {
            var attributes = new[] 
            {
                ItemTypeConstants.Weapon,
                AttributeConstants.Metal, 
                AttributeConstants.Uncommon,
                AttributeConstants.Melee,
                AttributeConstants.DoubleWeapon,
                AttributeConstants.NotBludgeoning,
                AttributeConstants.Bludgeoning
            };

            AssertContent(WeaponConstants.GnomeHookedHammer, attributes);
        }

        [Test]
        public void LightHammerAttributes()
        {
            var attributes = new[] 
            {
                ItemTypeConstants.Weapon,
                AttributeConstants.Metal,
                AttributeConstants.Uncommon,
                AttributeConstants.Melee,
                AttributeConstants.Bludgeoning,
                AttributeConstants.Ranged,
                AttributeConstants.Thrown
            };

            AssertContent(WeaponConstants.LightHammer, attributes);
        }

        [Test]
        public void HandaxeAttributes()
        {
            var attributes = new[] 
            {
                ItemTypeConstants.Weapon,
                AttributeConstants.Metal,
                AttributeConstants.Uncommon,
                AttributeConstants.Melee,
                AttributeConstants.NotBludgeoning,
                AttributeConstants.Slashing
            };

            AssertContent(WeaponConstants.Handaxe, attributes);
        }

        [Test]
        public void KukriAttributes()
        {
            var attributes = new[] 
            {
                ItemTypeConstants.Weapon,
                AttributeConstants.Metal, 
                AttributeConstants.Uncommon,
                AttributeConstants.Melee,
                AttributeConstants.NotBludgeoning,
                AttributeConstants.Slashing
            };

            AssertContent(WeaponConstants.Kukri, attributes);
        }

        [Test]
        public void LanceAttributes()
        {
            var attributes = new[] 
            {
                ItemTypeConstants.Weapon, 
                AttributeConstants.Wood,
                AttributeConstants.Metal, 
                AttributeConstants.Uncommon,
                AttributeConstants.Melee,
                AttributeConstants.NotBludgeoning
            };

            AssertContent(WeaponConstants.Lance, attributes);
        }

        [Test]
        public void LongspearAttributes()
        {
            var attributes = new[] 
            {
                ItemTypeConstants.Weapon, 
                AttributeConstants.Wood,
                AttributeConstants.Metal, 
                AttributeConstants.Uncommon,
                AttributeConstants.Melee,
                AttributeConstants.NotBludgeoning
            };

            AssertContent(WeaponConstants.Longspear, attributes);
        }

        [Test]
        public void MorningstarAttributes()
        {
            var attributes = new[] 
            {
                ItemTypeConstants.Weapon,
                AttributeConstants.Metal, 
                AttributeConstants.Uncommon,
                AttributeConstants.Melee,
                AttributeConstants.NotBludgeoning,
                AttributeConstants.Bludgeoning
            };

            AssertContent(WeaponConstants.Morningstar, attributes);
        }

        [Test]
        public void NetAttributes()
        {
            var attributes = new[] 
            {
                ItemTypeConstants.Weapon, 
                AttributeConstants.Uncommon, 
                AttributeConstants.Ranged,
                AttributeConstants.Thrown
            };

            AssertContent(WeaponConstants.Net, attributes);
        }

        [Test]
        public void HeavyPickAttributes()
        {
            var attributes = new[] 
            {
                ItemTypeConstants.Weapon, 
                AttributeConstants.Metal,
                AttributeConstants.Uncommon,
                AttributeConstants.Melee,
                AttributeConstants.NotBludgeoning
            };

            AssertContent(WeaponConstants.HeavyPick, attributes);
        }

        [Test]
        public void LightPickAttributes()
        {
            var attributes = new[] 
            {
                ItemTypeConstants.Weapon,
                AttributeConstants.Metal,
                AttributeConstants.Uncommon, 
                AttributeConstants.Melee,
                AttributeConstants.NotBludgeoning
            };

            AssertContent(WeaponConstants.LightPick, attributes);
        }

        [Test]
        public void RanseurAttributes()
        {
            var attributes = new[] 
            {
                ItemTypeConstants.Weapon,
                AttributeConstants.Wood,
                AttributeConstants.Metal, 
                AttributeConstants.Uncommon,
                AttributeConstants.Melee,
                AttributeConstants.NotBludgeoning
            };

            AssertContent(WeaponConstants.Ranseur, attributes);
        }

        [Test]
        public void SapAttributes()
        {
            var attributes = new[] 
            {
                ItemTypeConstants.Weapon,
                AttributeConstants.Uncommon,
                AttributeConstants.Melee,
                AttributeConstants.Bludgeoning
            };

            AssertContent(WeaponConstants.Sap, attributes);
        }

        [Test]
        public void ScytheAttributes()
        {
            var attributes = new[] 
            {
                ItemTypeConstants.Weapon,
                AttributeConstants.Wood,
                AttributeConstants.Metal,
                AttributeConstants.Uncommon,
                AttributeConstants.Melee,
                AttributeConstants.NotBludgeoning,
                AttributeConstants.Slashing
            };

            AssertContent(WeaponConstants.Scythe, attributes);
        }

        [Test]
        public void ShurikenAttributes()
        {
            var attributes = new[] 
            {
                ItemTypeConstants.Weapon, 
                AttributeConstants.Metal,
                AttributeConstants.Uncommon,
                AttributeConstants.Ranged,
                AttributeConstants.NotBludgeoning,
                AttributeConstants.Thrown
            };

            AssertContent(WeaponConstants.Shuriken, attributes);
        }

        [Test]
        public void SickleAttributes()
        {
            var attributes = new[] 
            {
                ItemTypeConstants.Weapon, 
                AttributeConstants.Metal, 
                AttributeConstants.Uncommon,
                AttributeConstants.Melee,
                AttributeConstants.NotBludgeoning,
                AttributeConstants.Slashing
            };

            AssertContent(WeaponConstants.Sickle, attributes);
        }

        [Test]
        public void TwoBladedSwordAttributes()
        {
            var attributes = new[] 
            {
                ItemTypeConstants.Weapon,
                AttributeConstants.Metal,
                AttributeConstants.Uncommon,
                AttributeConstants.Melee, 
                AttributeConstants.DoubleWeapon,
                AttributeConstants.NotBludgeoning,
                AttributeConstants.Slashing
            };

            AssertContent(WeaponConstants.TwoBladedSword, attributes);
        }

        [Test]
        public void TridentAttributes()
        {
            var attributes = new[] 
            {
                ItemTypeConstants.Weapon,
                AttributeConstants.Metal,
                AttributeConstants.Uncommon,
                AttributeConstants.Melee,
                AttributeConstants.NotBludgeoning,
                AttributeConstants.Ranged,
                AttributeConstants.Thrown
            };

            AssertContent(WeaponConstants.Trident, attributes);
        }

        [Test]
        public void DwarvenUrgroshAttributes()
        {
            var attributes = new[] 
            {
                ItemTypeConstants.Weapon,
                AttributeConstants.Metal, 
                AttributeConstants.Uncommon,
                AttributeConstants.Melee, 
                AttributeConstants.DoubleWeapon,
                AttributeConstants.NotBludgeoning,
                AttributeConstants.Slashing
            };

            AssertContent(WeaponConstants.DwarvenUrgrosh, attributes);
        }

        [Test]
        public void WarhammerAttributes()
        {
            var attributes = new[] 
            {
                ItemTypeConstants.Weapon,
                AttributeConstants.Metal, 
                AttributeConstants.Uncommon,
                AttributeConstants.Melee,
                AttributeConstants.Bludgeoning
            };

            AssertContent(WeaponConstants.Warhammer, attributes);
        }

        [Test]
        public void WhipAttributes()
        {
            var attributes = new[]
            {
                ItemTypeConstants.Weapon,
                AttributeConstants.Uncommon, 
                AttributeConstants.Melee,
                AttributeConstants.NotBludgeoning,
                AttributeConstants.Slashing
            };

            AssertContent(WeaponConstants.Whip, attributes);
        }

        [Test]
        public void ThrowingAxeAttributes()
        {
            var attributes = new[] 
            {
                ItemTypeConstants.Weapon, 
                AttributeConstants.Common, 
                AttributeConstants.Ranged, 
                AttributeConstants.Metal,
                AttributeConstants.NotBludgeoning,
                AttributeConstants.Slashing,
                AttributeConstants.Thrown
            };

            AssertContent(WeaponConstants.ThrowingAxe, attributes);
        }

        [Test]
        public void HeavyCrossbowAttributes()
        {
            var attributes = new[] 
            {
                ItemTypeConstants.Weapon, 
                AttributeConstants.Common, 
                AttributeConstants.Ranged,
                AttributeConstants.Wood,
                AttributeConstants.NotBludgeoning
            };

            AssertContent(WeaponConstants.HeavyCrossbow, attributes);
        }

        [Test]
        public void LightCrossbowAttributes()
        {
            var attributes = new[] 
            {
                ItemTypeConstants.Weapon,
                AttributeConstants.Common,
                AttributeConstants.Ranged,
                AttributeConstants.Wood,
                AttributeConstants.NotBludgeoning
            };

            AssertContent(WeaponConstants.LightCrossbow, attributes);
        }

        [Test]
        public void DartAttributes()
        {
            var attributes = new[] 
            {
                ItemTypeConstants.Weapon, 
                AttributeConstants.Common, 
                AttributeConstants.Ranged, 
                AttributeConstants.Metal,
                AttributeConstants.NotBludgeoning,
                AttributeConstants.Thrown
            };

            AssertContent(WeaponConstants.Dart, attributes);
        }

        [Test]
        public void JavelinAttributes()
        {
            var attributes = new[] 
            {
                ItemTypeConstants.Weapon, 
                AttributeConstants.Common, 
                AttributeConstants.Ranged, 
                AttributeConstants.Metal,
                AttributeConstants.Wood,
                AttributeConstants.NotBludgeoning,
                AttributeConstants.Thrown
            };

            AssertContent(WeaponConstants.Javelin, attributes);
        }

        [Test]
        public void ShortbowAttributes()
        {
            var attributes = new[] 
            {
                ItemTypeConstants.Weapon, 
                AttributeConstants.Common, 
                AttributeConstants.Ranged, 
                AttributeConstants.Wood,
                AttributeConstants.NotBludgeoning
            };

            AssertContent(WeaponConstants.Shortbow, attributes);
        }

        [Test]
        public void CompositePlus0ShortbowAttributes()
        {
            var attributes = new[] 
            {
                ItemTypeConstants.Weapon, 
                AttributeConstants.Common, 
                AttributeConstants.Ranged, 
                AttributeConstants.Wood,
                AttributeConstants.NotBludgeoning
            };

            AssertContent(WeaponConstants.CompositePlus0Shortbow, attributes);
        }

        [Test]
        public void CompositePlus1ShortbowAttributes()
        {
            var attributes = new[] 
            {
                ItemTypeConstants.Weapon, 
                AttributeConstants.Common, 
                AttributeConstants.Ranged, 
                AttributeConstants.Wood,
                AttributeConstants.NotBludgeoning
            };

            AssertContent(WeaponConstants.CompositePlus1Shortbow, attributes);
        }

        [Test]
        public void CompositePlus2ShortbowAttributes()
        {
            var attributes = new[] 
            {
                ItemTypeConstants.Weapon, 
                AttributeConstants.Common, 
                AttributeConstants.Ranged, 
                AttributeConstants.Wood,
                AttributeConstants.NotBludgeoning
            };

            AssertContent(WeaponConstants.CompositePlus2Shortbow, attributes);
        }

        [Test]
        public void SlingAttributes()
        {
            var attributes = new[] 
            {
                ItemTypeConstants.Weapon, 
                AttributeConstants.Common, 
                AttributeConstants.Ranged,
                AttributeConstants.Bludgeoning
            };

            AssertContent(WeaponConstants.Sling, attributes);
        }

        [Test]
        public void LongbowAttributes()
        {
            var attributes = new[] 
            {
                ItemTypeConstants.Weapon, 
                AttributeConstants.Common, 
                AttributeConstants.Ranged, 
                AttributeConstants.Wood,
                AttributeConstants.NotBludgeoning
            };

            AssertContent(WeaponConstants.Longbow, attributes);
        }

        [Test]
        public void CompositePlus0LongbowAttributes()
        {
            var attributes = new[] 
            {
                ItemTypeConstants.Weapon, 
                AttributeConstants.Common, 
                AttributeConstants.Ranged, 
                AttributeConstants.Wood,
                AttributeConstants.NotBludgeoning
            };

            AssertContent(WeaponConstants.CompositePlus0Longbow, attributes);
        }

        [Test]
        public void CompositePlus1LongbowAttributes()
        {
            var attributes = new[] 
            {
                ItemTypeConstants.Weapon, 
                AttributeConstants.Common, 
                AttributeConstants.Ranged, 
                AttributeConstants.Wood,
                AttributeConstants.NotBludgeoning
            };

            AssertContent(WeaponConstants.CompositePlus1Longbow, attributes);
        }

        [Test]
        public void CompositePlus2LongbowAttributes()
        {
            var attributes = new[] 
            {
                ItemTypeConstants.Weapon, 
                AttributeConstants.Common, 
                AttributeConstants.Ranged, 
                AttributeConstants.Wood,
                AttributeConstants.NotBludgeoning
            };

            AssertContent(WeaponConstants.CompositePlus2Longbow, attributes);
        }

        [Test]
        public void CompositePlus3LongbowAttributes()
        {
            var attributes = new[] 
            {
                ItemTypeConstants.Weapon, 
                AttributeConstants.Common, 
                AttributeConstants.Ranged, 
                AttributeConstants.Wood,
                AttributeConstants.NotBludgeoning
            };

            AssertContent(WeaponConstants.CompositePlus3Longbow, attributes);
        }

        [Test]
        public void CompositePlus4LongbowAttributes()
        {
            var attributes = new[] 
            {
                ItemTypeConstants.Weapon, 
                AttributeConstants.Common, 
                AttributeConstants.Ranged, 
                AttributeConstants.Wood,
                AttributeConstants.NotBludgeoning
            };

            AssertContent(WeaponConstants.CompositePlus4Longbow, attributes);
        }
    }
}