using EquipmentGen.Core.Data.Items;
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
                ItemsConstants.ItemTypes.Weapon,
                ItemsConstants.Gear.Types.Metal,
                ItemsConstants.Gear.Types.Common,
                ItemsConstants.Gear.Types.Melee,
                ItemsConstants.Gear.Types.NotBludgeoning,
                ItemsConstants.Gear.Types.Slashing,
                ItemsConstants.Gear.Types.Ranged,
                ItemsConstants.Gear.Types.Thrown
            };

            AssertContent(ItemsConstants.Gear.Weapons.Dagger, types);
        }

        [Test]
        public void GreataxeTypes()
        {
            var types = new[] 
            {
                ItemsConstants.ItemTypes.Weapon,
                ItemsConstants.Gear.Types.Metal,
                ItemsConstants.Gear.Types.Common,
                ItemsConstants.Gear.Types.Melee,
                ItemsConstants.Gear.Types.NotBludgeoning,
                ItemsConstants.Gear.Types.Slashing
            };

            AssertContent(ItemsConstants.Gear.Weapons.Greataxe, types);
        }

        [Test]
        public void GreatswordTypes()
        {
            var types = new[] 
            {
                ItemsConstants.ItemTypes.Weapon,
                ItemsConstants.Gear.Types.Metal,
                ItemsConstants.Gear.Types.Common,
                ItemsConstants.Gear.Types.Melee,
                ItemsConstants.Gear.Types.NotBludgeoning,
                ItemsConstants.Gear.Types.Slashing
            };

            AssertContent(ItemsConstants.Gear.Weapons.Greatsword, types);
        }

        [Test]
        public void KamaTypes()
        {
            var types = new[] 
            {
                ItemsConstants.ItemTypes.Weapon,
                ItemsConstants.Gear.Types.Wood,
                ItemsConstants.Gear.Types.Metal,
                ItemsConstants.Gear.Types.Common,
                ItemsConstants.Gear.Types.Melee,
                ItemsConstants.Gear.Types.NotBludgeoning,
                ItemsConstants.Gear.Types.Slashing
            };

            AssertContent(ItemsConstants.Gear.Weapons.Kama, types);
        }

        [Test]
        public void LongswordTypes()
        {
            var types = new[] 
            {
                ItemsConstants.ItemTypes.Weapon,
                ItemsConstants.Gear.Types.Metal,
                ItemsConstants.Gear.Types.Common,
                ItemsConstants.Gear.Types.Melee,
                ItemsConstants.Gear.Types.NotBludgeoning,
                ItemsConstants.Gear.Types.Slashing
            };

            AssertContent(ItemsConstants.Gear.Weapons.Longsword, types);
        }

        [Test]
        public void LightMaceTypes()
        {
            var types = new[] 
            {
                ItemsConstants.ItemTypes.Weapon,
                ItemsConstants.Gear.Types.Metal,
                ItemsConstants.Gear.Types.Common,
                ItemsConstants.Gear.Types.Melee,
                ItemsConstants.Gear.Types.Bludgeoning
            };

            AssertContent(ItemsConstants.Gear.Weapons.LightMace, types);
        }

        [Test]
        public void HeavyMaceTypes()
        {
            var types = new[] 
            {
                ItemsConstants.ItemTypes.Weapon, 
                ItemsConstants.Gear.Types.Metal,
                ItemsConstants.Gear.Types.Common, 
                ItemsConstants.Gear.Types.Melee,
                ItemsConstants.Gear.Types.Bludgeoning
            };

            AssertContent(ItemsConstants.Gear.Weapons.HeavyMace, types);
        }

        [Test]
        public void NunchakuTypes()
        {
            var types = new[] 
            {
                ItemsConstants.ItemTypes.Weapon,
                ItemsConstants.Gear.Types.Wood,
                ItemsConstants.Gear.Types.Common,
                ItemsConstants.Gear.Types.Melee,
                ItemsConstants.Gear.Types.Bludgeoning
            };

            AssertContent(ItemsConstants.Gear.Weapons.Nunchaku, types);
        }

        [Test]
        public void QuarterstaffTypes()
        {
            var types = new[] 
            {
                ItemsConstants.ItemTypes.Weapon,
                ItemsConstants.Gear.Types.Wood,
                ItemsConstants.Gear.Types.Common,
                ItemsConstants.Gear.Types.DoubleWeapon, 
                ItemsConstants.Gear.Types.Melee,
                ItemsConstants.Gear.Types.Bludgeoning
            };

            AssertContent(ItemsConstants.Gear.Weapons.Quarterstaff, types);
        }

        [Test]
        public void RapierTypes()
        {
            var types = new[] 
            {
                ItemsConstants.ItemTypes.Weapon,
                ItemsConstants.Gear.Types.Metal, 
                ItemsConstants.Gear.Types.Common,
                ItemsConstants.Gear.Types.Melee,
                ItemsConstants.Gear.Types.NotBludgeoning
            };

            AssertContent(ItemsConstants.Gear.Weapons.Rapier, types);
        }

        [Test]
        public void ScimitarTypes()
        {
            var types = new[]
            {
                ItemsConstants.ItemTypes.Weapon,
                ItemsConstants.Gear.Types.Metal,
                ItemsConstants.Gear.Types.Common, 
                ItemsConstants.Gear.Types.Melee,
                ItemsConstants.Gear.Types.NotBludgeoning,
                ItemsConstants.Gear.Types.Slashing
            };

            AssertContent(ItemsConstants.Gear.Weapons.Scimitar, types);
        }

        [Test]
        public void ShortspearTypes()
        {
            var types = new[] 
            {
                ItemsConstants.ItemTypes.Weapon,
                ItemsConstants.Gear.Types.Wood,
                ItemsConstants.Gear.Types.Metal,
                ItemsConstants.Gear.Types.Common,
                ItemsConstants.Gear.Types.Melee,
                ItemsConstants.Gear.Types.NotBludgeoning,
                ItemsConstants.Gear.Types.Ranged,
                ItemsConstants.Gear.Types.Thrown
            };

            AssertContent(ItemsConstants.Gear.Weapons.Shortspear, types);
        }

        [Test]
        public void SianghamTypes()
        {
            var types = new[] 
            {
                ItemsConstants.ItemTypes.Weapon,
                ItemsConstants.Gear.Types.Metal,
                ItemsConstants.Gear.Types.Common,
                ItemsConstants.Gear.Types.Melee,
                ItemsConstants.Gear.Types.NotBludgeoning
            };

            AssertContent(ItemsConstants.Gear.Weapons.Siangham, types);
        }

        [Test]
        public void BastardSwordTypes()
        {
            var types = new[]
            {
                ItemsConstants.ItemTypes.Weapon,
                ItemsConstants.Gear.Types.Metal,
                ItemsConstants.Gear.Types.Common,
                ItemsConstants.Gear.Types.Melee,
                ItemsConstants.Gear.Types.NotBludgeoning,
                ItemsConstants.Gear.Types.Slashing
            };

            AssertContent(ItemsConstants.Gear.Weapons.BastardSword, types);
        }

        [Test]
        public void ShortSwordTypes()
        {
            var types = new[] 
            {
                ItemsConstants.ItemTypes.Weapon,
                ItemsConstants.Gear.Types.Metal,
                ItemsConstants.Gear.Types.Common,
                ItemsConstants.Gear.Types.Melee,
                ItemsConstants.Gear.Types.NotBludgeoning,
                ItemsConstants.Gear.Types.Slashing
            };

            AssertContent(ItemsConstants.Gear.Weapons.ShortSword, types);
        }

        [Test]
        public void DwarvenWaraxeTypes()
        {
            var types = new[] 
            {
                ItemsConstants.ItemTypes.Weapon,
                ItemsConstants.Gear.Types.Metal, 
                ItemsConstants.Gear.Types.Common,
                ItemsConstants.Gear.Types.Melee,
                ItemsConstants.Gear.Types.NotBludgeoning,
                ItemsConstants.Gear.Types.Slashing
            };

            AssertContent(ItemsConstants.Gear.Weapons.DwarvenWaraxe, types);
        }

        [Test]
        public void OrcDoubleAxeTypes()
        {
            var types = new[] 
            {
                ItemsConstants.ItemTypes.Weapon,
                ItemsConstants.Gear.Types.Metal,
                ItemsConstants.Gear.Types.Uncommon,
                ItemsConstants.Gear.Types.DoubleWeapon,
                ItemsConstants.Gear.Types.Melee,
                ItemsConstants.Gear.Types.NotBludgeoning,
                ItemsConstants.Gear.Types.Slashing
            };

            AssertContent(ItemsConstants.Gear.Weapons.OrcDoubleAxe, types);
        }

        [Test]
        public void BattleaxeTypes()
        {
            var types = new[]
            {
                ItemsConstants.ItemTypes.Weapon,
                ItemsConstants.Gear.Types.Metal,
                ItemsConstants.Gear.Types.Uncommon,
                ItemsConstants.Gear.Types.Melee,
                ItemsConstants.Gear.Types.NotBludgeoning,
                ItemsConstants.Gear.Types.Slashing
            };

            AssertContent(ItemsConstants.Gear.Weapons.Battleaxe, types);
        }

        [Test]
        public void SpikedChainTypes()
        {
            var types = new[]
            {
                ItemsConstants.ItemTypes.Weapon,
                ItemsConstants.Gear.Types.Metal,
                ItemsConstants.Gear.Types.Uncommon, 
                ItemsConstants.Gear.Types.Melee,
                ItemsConstants.Gear.Types.NotBludgeoning
            };

            AssertContent(ItemsConstants.Gear.Weapons.SpikedChain, types);
        }

        [Test]
        public void ClubTypes()
        {
            var types = new[] 
            {
                ItemsConstants.ItemTypes.Weapon,
                ItemsConstants.Gear.Types.Wood, 
                ItemsConstants.Gear.Types.Uncommon, 
                ItemsConstants.Gear.Types.Melee,
                ItemsConstants.Gear.Types.Bludgeoning,
                ItemsConstants.Gear.Types.Ranged,
                ItemsConstants.Gear.Types.Thrown
            };

            AssertContent(ItemsConstants.Gear.Weapons.Club, types);
        }

        [Test]
        public void HandCrossbowTypes()
        {
            var types = new[]
            {
                ItemsConstants.ItemTypes.Weapon,
                ItemsConstants.Gear.Types.Metal, 
                ItemsConstants.Gear.Types.Uncommon, 
                ItemsConstants.Gear.Types.Ranged,
                ItemsConstants.Gear.Types.NotBludgeoning
            };

            AssertContent(ItemsConstants.Gear.Weapons.HandCrossbow, types);
        }

        [Test]
        public void RepeatingCrossbowTypes()
        {
            var types = new[] 
            {
                ItemsConstants.ItemTypes.Weapon, 
                ItemsConstants.Gear.Types.Metal, 
                ItemsConstants.Gear.Types.Uncommon, 
                ItemsConstants.Gear.Types.Ranged,
                ItemsConstants.Gear.Types.NotBludgeoning
            };

            AssertContent(ItemsConstants.Gear.Weapons.RepeatingCrossbow, types);
        }

        [Test]
        public void PunchingDaggerTypes()
        {
            var types = new[] 
            {
                ItemsConstants.ItemTypes.Weapon,
                ItemsConstants.Gear.Types.Metal,
                ItemsConstants.Gear.Types.Uncommon, 
                ItemsConstants.Gear.Types.Melee,
                ItemsConstants.Gear.Types.NotBludgeoning
            };

            AssertContent(ItemsConstants.Gear.Weapons.PunchingDagger, types);
        }

        [Test]
        public void FalchionTypes()
        {
            var types = new[] 
            {
                ItemsConstants.ItemTypes.Weapon,
                ItemsConstants.Gear.Types.Metal,
                ItemsConstants.Gear.Types.Uncommon, 
                ItemsConstants.Gear.Types.Melee,
                ItemsConstants.Gear.Types.NotBludgeoning,
                ItemsConstants.Gear.Types.Slashing
            };

            AssertContent(ItemsConstants.Gear.Weapons.Falchion, types);
        }

        [Test]
        public void DireFlailTypes()
        {
            var types = new[] 
            {
                ItemsConstants.ItemTypes.Weapon, 
                ItemsConstants.Gear.Types.Metal,
                ItemsConstants.Gear.Types.Uncommon,
                ItemsConstants.Gear.Types.Melee,
                ItemsConstants.Gear.Types.DoubleWeapon,
                ItemsConstants.Gear.Types.Bludgeoning
            };

            AssertContent(ItemsConstants.Gear.Weapons.DireFlail, types);
        }

        [Test]
        public void HeavyFlailTypes()
        {
            var types = new[] 
            {
                ItemsConstants.ItemTypes.Weapon,
                ItemsConstants.Gear.Types.Metal,
                ItemsConstants.Gear.Types.Uncommon,
                ItemsConstants.Gear.Types.Melee,
                ItemsConstants.Gear.Types.Bludgeoning
            };

            AssertContent(ItemsConstants.Gear.Weapons.HeavyFlail, types);
        }

        [Test]
        public void LightFlailTypes()
        {
            var types = new[] 
            {
                ItemsConstants.ItemTypes.Weapon,
                ItemsConstants.Gear.Types.Metal, 
                ItemsConstants.Gear.Types.Uncommon,
                ItemsConstants.Gear.Types.Melee,
                ItemsConstants.Gear.Types.Bludgeoning
            };

            AssertContent(ItemsConstants.Gear.Weapons.LightFlail, types);
        }

        [Test]
        public void GauntletTypes()
        {
            var types = new[] 
            {
                ItemsConstants.ItemTypes.Weapon,
                ItemsConstants.Gear.Types.Metal, 
                ItemsConstants.Gear.Types.Uncommon,
                ItemsConstants.Gear.Types.Melee,
                ItemsConstants.Gear.Types.Bludgeoning
            };

            AssertContent(ItemsConstants.Gear.Weapons.Gauntlet, types);
        }

        [Test]
        public void SpikedGauntletTypes()
        {
            var types = new[] 
            {
                ItemsConstants.ItemTypes.Weapon,
                ItemsConstants.Gear.Types.Metal,
                ItemsConstants.Gear.Types.Uncommon, 
                ItemsConstants.Gear.Types.Melee,
                ItemsConstants.Gear.Types.NotBludgeoning
            };

            AssertContent(ItemsConstants.Gear.Weapons.SpikedGauntlet, types);
        }

        [Test]
        public void GlaiveTypes()
        {
            var types = new[]
            {
                ItemsConstants.ItemTypes.Weapon,
                ItemsConstants.Gear.Types.Metal,
                ItemsConstants.Gear.Types.Uncommon,
                ItemsConstants.Gear.Types.Melee,
                ItemsConstants.Gear.Types.NotBludgeoning,
                ItemsConstants.Gear.Types.Slashing
            };

            AssertContent(ItemsConstants.Gear.Weapons.Glaive, types);
        }

        [Test]
        public void GreatclubTypes()
        {
            var types = new[] 
            {
                ItemsConstants.ItemTypes.Weapon, 
                ItemsConstants.Gear.Types.Wood, 
                ItemsConstants.Gear.Types.Uncommon,
                ItemsConstants.Gear.Types.Melee,
                ItemsConstants.Gear.Types.Bludgeoning
            };

            AssertContent(ItemsConstants.Gear.Weapons.Greatclub, types);
        }

        [Test]
        public void GuisarmeTypes()
        {
            var types = new[] 
            {
                ItemsConstants.ItemTypes.Weapon,
                ItemsConstants.Gear.Types.Metal, 
                ItemsConstants.Gear.Types.Uncommon,
                ItemsConstants.Gear.Types.Melee,
                ItemsConstants.Gear.Types.NotBludgeoning,
                ItemsConstants.Gear.Types.Slashing
            };

            AssertContent(ItemsConstants.Gear.Weapons.Guisarme, types);
        }

        [Test]
        public void HalberdTypes()
        {
            var types = new[] 
            {
                ItemsConstants.ItemTypes.Weapon,
                ItemsConstants.Gear.Types.Metal, 
                ItemsConstants.Gear.Types.Uncommon,
                ItemsConstants.Gear.Types.Melee,
                ItemsConstants.Gear.Types.NotBludgeoning,
                ItemsConstants.Gear.Types.Slashing
            };

            AssertContent(ItemsConstants.Gear.Weapons.Halberd, types);
        }

        [Test]
        public void HalfspearTypes()
        {
            var types = new[] 
            {
                ItemsConstants.ItemTypes.Weapon, 
                ItemsConstants.Gear.Types.Metal, 
                ItemsConstants.Gear.Types.Wood, 
                ItemsConstants.Gear.Types.Uncommon,
                ItemsConstants.Gear.Types.Melee,
                ItemsConstants.Gear.Types.NotBludgeoning
            };

            AssertContent(ItemsConstants.Gear.Weapons.Halfspear, types);
        }

        [Test]
        public void GnomeHookedHammerTypes()
        {
            var types = new[] 
            {
                ItemsConstants.ItemTypes.Weapon,
                ItemsConstants.Gear.Types.Metal, 
                ItemsConstants.Gear.Types.Uncommon,
                ItemsConstants.Gear.Types.Melee,
                ItemsConstants.Gear.Types.DoubleWeapon,
                ItemsConstants.Gear.Types.NotBludgeoning,
                ItemsConstants.Gear.Types.Bludgeoning
            };

            AssertContent(ItemsConstants.Gear.Weapons.GnomeHookedHammer, types);
        }

        [Test]
        public void LightHammerTypes()
        {
            var types = new[] 
            {
                ItemsConstants.ItemTypes.Weapon,
                ItemsConstants.Gear.Types.Metal,
                ItemsConstants.Gear.Types.Uncommon,
                ItemsConstants.Gear.Types.Melee,
                ItemsConstants.Gear.Types.Bludgeoning,
                ItemsConstants.Gear.Types.Ranged,
                ItemsConstants.Gear.Types.Thrown
            };

            AssertContent(ItemsConstants.Gear.Weapons.LightHammer, types);
        }

        [Test]
        public void HandaxeTypes()
        {
            var types = new[] 
            {
                ItemsConstants.ItemTypes.Weapon,
                ItemsConstants.Gear.Types.Metal,
                ItemsConstants.Gear.Types.Uncommon,
                ItemsConstants.Gear.Types.Melee,
                ItemsConstants.Gear.Types.NotBludgeoning,
                ItemsConstants.Gear.Types.Slashing
            };

            AssertContent(ItemsConstants.Gear.Weapons.Handaxe, types);
        }

        [Test]
        public void KukriTypes()
        {
            var types = new[] 
            {
                ItemsConstants.ItemTypes.Weapon,
                ItemsConstants.Gear.Types.Metal, 
                ItemsConstants.Gear.Types.Uncommon,
                ItemsConstants.Gear.Types.Melee,
                ItemsConstants.Gear.Types.NotBludgeoning,
                ItemsConstants.Gear.Types.Slashing
            };

            AssertContent(ItemsConstants.Gear.Weapons.Kukri, types);
        }

        [Test]
        public void LanceTypes()
        {
            var types = new[] 
            {
                ItemsConstants.ItemTypes.Weapon, 
                ItemsConstants.Gear.Types.Wood,
                ItemsConstants.Gear.Types.Metal, 
                ItemsConstants.Gear.Types.Uncommon,
                ItemsConstants.Gear.Types.Melee,
                ItemsConstants.Gear.Types.NotBludgeoning
            };

            AssertContent(ItemsConstants.Gear.Weapons.Lance, types);
        }

        [Test]
        public void LongspearTypes()
        {
            var types = new[] 
            {
                ItemsConstants.ItemTypes.Weapon, 
                ItemsConstants.Gear.Types.Wood,
                ItemsConstants.Gear.Types.Metal, 
                ItemsConstants.Gear.Types.Uncommon,
                ItemsConstants.Gear.Types.Melee,
                ItemsConstants.Gear.Types.NotBludgeoning
            };

            AssertContent(ItemsConstants.Gear.Weapons.Longspear, types);
        }

        [Test]
        public void MorningstarTypes()
        {
            var types = new[] 
            {
                ItemsConstants.ItemTypes.Weapon,
                ItemsConstants.Gear.Types.Metal, 
                ItemsConstants.Gear.Types.Uncommon,
                ItemsConstants.Gear.Types.Melee,
                ItemsConstants.Gear.Types.NotBludgeoning,
                ItemsConstants.Gear.Types.Bludgeoning
            };

            AssertContent(ItemsConstants.Gear.Weapons.Morningstar, types);
        }

        [Test]
        public void NetTypes()
        {
            var types = new[] 
            {
                ItemsConstants.ItemTypes.Weapon, 
                ItemsConstants.Gear.Types.Uncommon, 
                ItemsConstants.Gear.Types.Ranged,
                ItemsConstants.Gear.Types.Thrown
            };

            AssertContent(ItemsConstants.Gear.Weapons.Net, types);
        }

        [Test]
        public void HeavyPickTypes()
        {
            var types = new[] 
            {
                ItemsConstants.ItemTypes.Weapon, 
                ItemsConstants.Gear.Types.Metal,
                ItemsConstants.Gear.Types.Uncommon,
                ItemsConstants.Gear.Types.Melee,
                ItemsConstants.Gear.Types.NotBludgeoning
            };

            AssertContent(ItemsConstants.Gear.Weapons.HeavyPick, types);
        }

        [Test]
        public void LightPickTypes()
        {
            var types = new[] 
            {
                ItemsConstants.ItemTypes.Weapon,
                ItemsConstants.Gear.Types.Metal,
                ItemsConstants.Gear.Types.Uncommon, 
                ItemsConstants.Gear.Types.Melee,
                ItemsConstants.Gear.Types.NotBludgeoning
            };

            AssertContent(ItemsConstants.Gear.Weapons.LightPick, types);
        }

        [Test]
        public void RanseurTypes()
        {
            var types = new[] 
            {
                ItemsConstants.ItemTypes.Weapon,
                ItemsConstants.Gear.Types.Wood,
                ItemsConstants.Gear.Types.Metal, 
                ItemsConstants.Gear.Types.Uncommon,
                ItemsConstants.Gear.Types.Melee,
                ItemsConstants.Gear.Types.NotBludgeoning
            };

            AssertContent(ItemsConstants.Gear.Weapons.Ranseur, types);
        }

        [Test]
        public void SapTypes()
        {
            var types = new[] 
            {
                ItemsConstants.ItemTypes.Weapon,
                ItemsConstants.Gear.Types.Uncommon,
                ItemsConstants.Gear.Types.Melee,
                ItemsConstants.Gear.Types.Bludgeoning
            };

            AssertContent(ItemsConstants.Gear.Weapons.Sap, types);
        }

        [Test]
        public void ScytheTypes()
        {
            var types = new[] 
            {
                ItemsConstants.ItemTypes.Weapon,
                ItemsConstants.Gear.Types.Wood,
                ItemsConstants.Gear.Types.Metal,
                ItemsConstants.Gear.Types.Uncommon,
                ItemsConstants.Gear.Types.Melee,
                ItemsConstants.Gear.Types.NotBludgeoning,
                ItemsConstants.Gear.Types.Slashing
            };

            AssertContent(ItemsConstants.Gear.Weapons.Scythe, types);
        }

        [Test]
        public void ShurikenTypes()
        {
            var types = new[] 
            {
                ItemsConstants.ItemTypes.Weapon, 
                ItemsConstants.Gear.Types.Metal,
                ItemsConstants.Gear.Types.Uncommon,
                ItemsConstants.Gear.Types.Ranged,
                ItemsConstants.Gear.Types.NotBludgeoning,
                ItemsConstants.Gear.Types.Thrown
            };

            AssertContent(ItemsConstants.Gear.Weapons.Shuriken, types);
        }

        [Test]
        public void SickleTypes()
        {
            var types = new[] 
            {
                ItemsConstants.ItemTypes.Weapon, 
                ItemsConstants.Gear.Types.Metal, 
                ItemsConstants.Gear.Types.Uncommon,
                ItemsConstants.Gear.Types.Melee,
                ItemsConstants.Gear.Types.NotBludgeoning,
                ItemsConstants.Gear.Types.Slashing
            };

            AssertContent(ItemsConstants.Gear.Weapons.Sickle, types);
        }

        [Test]
        public void TwoBladedSwordTypes()
        {
            var types = new[] 
            {
                ItemsConstants.ItemTypes.Weapon,
                ItemsConstants.Gear.Types.Metal,
                ItemsConstants.Gear.Types.Uncommon,
                ItemsConstants.Gear.Types.Melee, 
                ItemsConstants.Gear.Types.DoubleWeapon,
                ItemsConstants.Gear.Types.NotBludgeoning,
                ItemsConstants.Gear.Types.Slashing
            };

            AssertContent(ItemsConstants.Gear.Weapons.TwoBladedSword, types);
        }

        [Test]
        public void TridentTypes()
        {
            var types = new[] 
            {
                ItemsConstants.ItemTypes.Weapon,
                ItemsConstants.Gear.Types.Metal,
                ItemsConstants.Gear.Types.Uncommon,
                ItemsConstants.Gear.Types.Melee,
                ItemsConstants.Gear.Types.NotBludgeoning,
                ItemsConstants.Gear.Types.Ranged,
                ItemsConstants.Gear.Types.Thrown
            };

            AssertContent(ItemsConstants.Gear.Weapons.Trident, types);
        }

        [Test]
        public void DwarvenUrgroshTypes()
        {
            var types = new[] 
            {
                ItemsConstants.ItemTypes.Weapon,
                ItemsConstants.Gear.Types.Metal, 
                ItemsConstants.Gear.Types.Uncommon,
                ItemsConstants.Gear.Types.Melee, 
                ItemsConstants.Gear.Types.DoubleWeapon,
                ItemsConstants.Gear.Types.NotBludgeoning,
                ItemsConstants.Gear.Types.Slashing
            };

            AssertContent(ItemsConstants.Gear.Weapons.DwarvenUrgrosh, types);
        }

        [Test]
        public void WarhammerTypes()
        {
            var types = new[] 
            {
                ItemsConstants.ItemTypes.Weapon,
                ItemsConstants.Gear.Types.Metal, 
                ItemsConstants.Gear.Types.Uncommon,
                ItemsConstants.Gear.Types.Melee,
                ItemsConstants.Gear.Types.Bludgeoning
            };

            AssertContent(ItemsConstants.Gear.Weapons.Warhammer, types);
        }

        [Test]
        public void WhipTypes()
        {
            var types = new[]
            {
                ItemsConstants.ItemTypes.Weapon,
                ItemsConstants.Gear.Types.Uncommon, 
                ItemsConstants.Gear.Types.Melee,
                ItemsConstants.Gear.Types.NotBludgeoning,
                ItemsConstants.Gear.Types.Slashing
            };

            AssertContent(ItemsConstants.Gear.Weapons.Whip, types);
        }

        [Test]
        public void ThrowingAxeTypes()
        {
            var types = new[] 
            {
                ItemsConstants.ItemTypes.Weapon, 
                ItemsConstants.Gear.Types.Common, 
                ItemsConstants.Gear.Types.Ranged, 
                ItemsConstants.Gear.Types.Metal,
                ItemsConstants.Gear.Types.NotBludgeoning,
                ItemsConstants.Gear.Types.Slashing,
                ItemsConstants.Gear.Types.Thrown
            };

            AssertContent(ItemsConstants.Gear.Weapons.ThrowingAxe, types);
        }

        [Test]
        public void HeavyCrossbowTypes()
        {
            var types = new[] 
            {
                ItemsConstants.ItemTypes.Weapon, 
                ItemsConstants.Gear.Types.Common, 
                ItemsConstants.Gear.Types.Ranged,
                ItemsConstants.Gear.Types.Wood,
                ItemsConstants.Gear.Types.NotBludgeoning
            };

            AssertContent(ItemsConstants.Gear.Weapons.HeavyCrossbow, types);
        }

        [Test]
        public void LightCrossbowTypes()
        {
            var types = new[] 
            {
                ItemsConstants.ItemTypes.Weapon,
                ItemsConstants.Gear.Types.Common,
                ItemsConstants.Gear.Types.Ranged,
                ItemsConstants.Gear.Types.Wood,
                ItemsConstants.Gear.Types.NotBludgeoning
            };

            AssertContent(ItemsConstants.Gear.Weapons.LightCrossbow, types);
        }

        [Test]
        public void DartTypes()
        {
            var types = new[] 
            {
                ItemsConstants.ItemTypes.Weapon, 
                ItemsConstants.Gear.Types.Common, 
                ItemsConstants.Gear.Types.Ranged, 
                ItemsConstants.Gear.Types.Metal,
                ItemsConstants.Gear.Types.NotBludgeoning,
                ItemsConstants.Gear.Types.Thrown
            };

            AssertContent(ItemsConstants.Gear.Weapons.Dart, types);
        }

        [Test]
        public void JavelinTypes()
        {
            var types = new[] 
            {
                ItemsConstants.ItemTypes.Weapon, 
                ItemsConstants.Gear.Types.Common, 
                ItemsConstants.Gear.Types.Ranged, 
                ItemsConstants.Gear.Types.Metal,
                ItemsConstants.Gear.Types.Wood,
                ItemsConstants.Gear.Types.NotBludgeoning,
                ItemsConstants.Gear.Types.Thrown
            };

            AssertContent(ItemsConstants.Gear.Weapons.Javelin, types);
        }

        [Test]
        public void ShortbowTypes()
        {
            var types = new[] 
            {
                ItemsConstants.ItemTypes.Weapon, 
                ItemsConstants.Gear.Types.Common, 
                ItemsConstants.Gear.Types.Ranged, 
                ItemsConstants.Gear.Types.Wood,
                ItemsConstants.Gear.Types.NotBludgeoning
            };

            AssertContent(ItemsConstants.Gear.Weapons.Shortbow, types);
        }

        [Test]
        public void CompositePlus0ShortbowTypes()
        {
            var types = new[] 
            {
                ItemsConstants.ItemTypes.Weapon, 
                ItemsConstants.Gear.Types.Common, 
                ItemsConstants.Gear.Types.Ranged, 
                ItemsConstants.Gear.Types.Wood,
                ItemsConstants.Gear.Types.NotBludgeoning
            };

            AssertContent(ItemsConstants.Gear.Weapons.CompositePlus0Shortbow, types);
        }

        [Test]
        public void CompositePlus1ShortbowTypes()
        {
            var types = new[] 
            {
                ItemsConstants.ItemTypes.Weapon, 
                ItemsConstants.Gear.Types.Common, 
                ItemsConstants.Gear.Types.Ranged, 
                ItemsConstants.Gear.Types.Wood,
                ItemsConstants.Gear.Types.NotBludgeoning
            };

            AssertContent(ItemsConstants.Gear.Weapons.CompositePlus1Shortbow, types);
        }

        [Test]
        public void CompositePlus2ShortbowTypes()
        {
            var types = new[] 
            {
                ItemsConstants.ItemTypes.Weapon, 
                ItemsConstants.Gear.Types.Common, 
                ItemsConstants.Gear.Types.Ranged, 
                ItemsConstants.Gear.Types.Wood,
                ItemsConstants.Gear.Types.NotBludgeoning
            };

            AssertContent(ItemsConstants.Gear.Weapons.CompositePlus2Shortbow, types);
        }

        [Test]
        public void SlingTypes()
        {
            var types = new[] 
            {
                ItemsConstants.ItemTypes.Weapon, 
                ItemsConstants.Gear.Types.Common, 
                ItemsConstants.Gear.Types.Ranged,
                ItemsConstants.Gear.Types.Bludgeoning
            };

            AssertContent(ItemsConstants.Gear.Weapons.Sling, types);
        }

        [Test]
        public void LongbowTypes()
        {
            var types = new[] 
            {
                ItemsConstants.ItemTypes.Weapon, 
                ItemsConstants.Gear.Types.Common, 
                ItemsConstants.Gear.Types.Ranged, 
                ItemsConstants.Gear.Types.Wood,
                ItemsConstants.Gear.Types.NotBludgeoning
            };

            AssertContent(ItemsConstants.Gear.Weapons.Longbow, types);
        }

        [Test]
        public void CompositePlus0LongbowTypes()
        {
            var types = new[] 
            {
                ItemsConstants.ItemTypes.Weapon, 
                ItemsConstants.Gear.Types.Common, 
                ItemsConstants.Gear.Types.Ranged, 
                ItemsConstants.Gear.Types.Wood,
                ItemsConstants.Gear.Types.NotBludgeoning
            };

            AssertContent(ItemsConstants.Gear.Weapons.CompositePlus0Longbow, types);
        }

        [Test]
        public void CompositePlus1LongbowTypes()
        {
            var types = new[] 
            {
                ItemsConstants.ItemTypes.Weapon, 
                ItemsConstants.Gear.Types.Common, 
                ItemsConstants.Gear.Types.Ranged, 
                ItemsConstants.Gear.Types.Wood,
                ItemsConstants.Gear.Types.NotBludgeoning
            };

            AssertContent(ItemsConstants.Gear.Weapons.CompositePlus1Longbow, types);
        }

        [Test]
        public void CompositePlus2LongbowTypes()
        {
            var types = new[] 
            {
                ItemsConstants.ItemTypes.Weapon, 
                ItemsConstants.Gear.Types.Common, 
                ItemsConstants.Gear.Types.Ranged, 
                ItemsConstants.Gear.Types.Wood,
                ItemsConstants.Gear.Types.NotBludgeoning
            };

            AssertContent(ItemsConstants.Gear.Weapons.CompositePlus2Longbow, types);
        }

        [Test]
        public void CompositePlus3LongbowTypes()
        {
            var types = new[] 
            {
                ItemsConstants.ItemTypes.Weapon, 
                ItemsConstants.Gear.Types.Common, 
                ItemsConstants.Gear.Types.Ranged, 
                ItemsConstants.Gear.Types.Wood,
                ItemsConstants.Gear.Types.NotBludgeoning
            };

            AssertContent(ItemsConstants.Gear.Weapons.CompositePlus3Longbow, types);
        }

        [Test]
        public void CompositePlus4LongbowTypes()
        {
            var types = new[] 
            {
                ItemsConstants.ItemTypes.Weapon, 
                ItemsConstants.Gear.Types.Common, 
                ItemsConstants.Gear.Types.Ranged, 
                ItemsConstants.Gear.Types.Wood,
                ItemsConstants.Gear.Types.NotBludgeoning
            };

            AssertContent(ItemsConstants.Gear.Weapons.CompositePlus4Longbow, types);
        }
    }
}