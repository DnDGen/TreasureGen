using System;
using EquipmentGen.Common.Items;
using NUnit.Framework;

namespace EquipmentGen.Tests.Integration.Tables.Items.Mundane.Weapons
{
    [TestFixture]
    public class WeaponAttributesTests : AttributesTests
    {
        protected override String tableName
        {
            get { return "WeaponAttributes"; }
        }

        [TestCase(WeaponConstants.Dagger, ItemTypeConstants.Weapon,
                                          AttributeConstants.Metal,
                                          AttributeConstants.Common,
                                          AttributeConstants.Melee,
                                          AttributeConstants.NotBludgeoning,
                                          AttributeConstants.Slashing,
                                          AttributeConstants.Ranged,
                                          AttributeConstants.Thrown)]
        [TestCase(WeaponConstants.Greataxe, ItemTypeConstants.Weapon,
                                            AttributeConstants.Metal,
                                            AttributeConstants.Common,
                                            AttributeConstants.Melee,
                                            AttributeConstants.NotBludgeoning,
                                            AttributeConstants.Slashing)]
        [TestCase(WeaponConstants.Greatsword, ItemTypeConstants.Weapon,
                                              AttributeConstants.Metal,
                                              AttributeConstants.Common,
                                              AttributeConstants.Melee,
                                              AttributeConstants.NotBludgeoning,
                                              AttributeConstants.Slashing)]
        [TestCase(WeaponConstants.Kama, ItemTypeConstants.Weapon,
                                        AttributeConstants.Wood,
                                        AttributeConstants.Metal,
                                        AttributeConstants.Common,
                                        AttributeConstants.Melee,
                                        AttributeConstants.NotBludgeoning,
                                        AttributeConstants.Slashing)]
        [TestCase(WeaponConstants.Longsword, ItemTypeConstants.Weapon,
                                             AttributeConstants.Metal,
                                             AttributeConstants.Common,
                                             AttributeConstants.Melee,
                                             AttributeConstants.NotBludgeoning,
                                             AttributeConstants.Slashing)]
        [TestCase(WeaponConstants.LightMace, ItemTypeConstants.Weapon,
                                             AttributeConstants.Metal,
                                             AttributeConstants.Common,
                                             AttributeConstants.Melee,
                                             AttributeConstants.Bludgeoning)]
        [TestCase(WeaponConstants.HeavyMace, ItemTypeConstants.Weapon,
                                             AttributeConstants.Metal,
                                             AttributeConstants.Common,
                                             AttributeConstants.Melee,
                                             AttributeConstants.Bludgeoning)]
        [TestCase(WeaponConstants.Nunchaku, ItemTypeConstants.Weapon,
                                            AttributeConstants.Wood,
                                            AttributeConstants.Common,
                                            AttributeConstants.Melee,
                                            AttributeConstants.Bludgeoning)]
        [TestCase(WeaponConstants.Quarterstaff, ItemTypeConstants.Weapon,
                                                AttributeConstants.Wood,
                                                AttributeConstants.Common,
                                                AttributeConstants.DoubleWeapon,
                                                AttributeConstants.Melee,
                                                AttributeConstants.Bludgeoning)]
        [TestCase(WeaponConstants.Rapier, ItemTypeConstants.Weapon,
                                          AttributeConstants.Metal,
                                          AttributeConstants.Common,
                                          AttributeConstants.Melee,
                                          AttributeConstants.NotBludgeoning)]
        [TestCase(WeaponConstants.Scimitar, ItemTypeConstants.Weapon,
                                            AttributeConstants.Metal,
                                            AttributeConstants.Common,
                                            AttributeConstants.Melee,
                                            AttributeConstants.NotBludgeoning,
                                            AttributeConstants.Slashing)]
        [TestCase(WeaponConstants.Shortspear, ItemTypeConstants.Weapon,
                                              AttributeConstants.Wood,
                                              AttributeConstants.Metal,
                                              AttributeConstants.Common,
                                              AttributeConstants.Melee,
                                              AttributeConstants.NotBludgeoning,
                                              AttributeConstants.Ranged,
                                              AttributeConstants.Thrown)]
        [TestCase(WeaponConstants.Siangham, ItemTypeConstants.Weapon,
                                            AttributeConstants.Metal,
                                            AttributeConstants.Common,
                                            AttributeConstants.Melee,
                                            AttributeConstants.NotBludgeoning)]
        [TestCase(WeaponConstants.BastardSword, ItemTypeConstants.Weapon,
                                                AttributeConstants.Metal,
                                                AttributeConstants.Common,
                                                AttributeConstants.Melee,
                                                AttributeConstants.NotBludgeoning,
                                                AttributeConstants.Slashing)]
        [TestCase(WeaponConstants.ShortSword, ItemTypeConstants.Weapon,
                                              AttributeConstants.Metal,
                                              AttributeConstants.Common,
                                              AttributeConstants.Melee,
                                              AttributeConstants.NotBludgeoning,
                                              AttributeConstants.Slashing)]
        [TestCase(WeaponConstants.DwarvenWaraxe, ItemTypeConstants.Weapon,
                                                 AttributeConstants.Metal,
                                                 AttributeConstants.Common,
                                                 AttributeConstants.Melee,
                                                 AttributeConstants.NotBludgeoning,
                                                 AttributeConstants.Slashing)]
        public void Attributes(String name, params String[] attributes)
        {
            AssertAttributes(name, attributes);
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

            AssertAttributes(WeaponConstants.OrcDoubleAxe, attributes);
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

            AssertAttributes(WeaponConstants.Battleaxe, attributes);
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

            AssertAttributes(WeaponConstants.SpikedChain, attributes);
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

            AssertAttributes(WeaponConstants.Club, attributes);
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

            AssertAttributes(WeaponConstants.HandCrossbow, attributes);
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

            AssertAttributes(WeaponConstants.RepeatingCrossbow, attributes);
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

            AssertAttributes(WeaponConstants.PunchingDagger, attributes);
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

            AssertAttributes(WeaponConstants.Falchion, attributes);
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

            AssertAttributes(WeaponConstants.DireFlail, attributes);
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

            AssertAttributes(WeaponConstants.HeavyFlail, attributes);
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

            AssertAttributes(WeaponConstants.LightFlail, attributes);
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

            AssertAttributes(WeaponConstants.Gauntlet, attributes);
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

            AssertAttributes(WeaponConstants.SpikedGauntlet, attributes);
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

            AssertAttributes(WeaponConstants.Glaive, attributes);
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

            AssertAttributes(WeaponConstants.Greatclub, attributes);
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

            AssertAttributes(WeaponConstants.Guisarme, attributes);
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

            AssertAttributes(WeaponConstants.Halberd, attributes);
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

            AssertAttributes(WeaponConstants.Halfspear, attributes);
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

            AssertAttributes(WeaponConstants.GnomeHookedHammer, attributes);
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

            AssertAttributes(WeaponConstants.LightHammer, attributes);
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

            AssertAttributes(WeaponConstants.Handaxe, attributes);
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

            AssertAttributes(WeaponConstants.Kukri, attributes);
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

            AssertAttributes(WeaponConstants.Lance, attributes);
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

            AssertAttributes(WeaponConstants.Longspear, attributes);
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

            AssertAttributes(WeaponConstants.Morningstar, attributes);
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

            AssertAttributes(WeaponConstants.Net, attributes);
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

            AssertAttributes(WeaponConstants.HeavyPick, attributes);
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

            AssertAttributes(WeaponConstants.LightPick, attributes);
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

            AssertAttributes(WeaponConstants.Ranseur, attributes);
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

            AssertAttributes(WeaponConstants.Sap, attributes);
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

            AssertAttributes(WeaponConstants.Scythe, attributes);
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

            AssertAttributes(WeaponConstants.Shuriken, attributes);
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

            AssertAttributes(WeaponConstants.Sickle, attributes);
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

            AssertAttributes(WeaponConstants.TwoBladedSword, attributes);
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

            AssertAttributes(WeaponConstants.Trident, attributes);
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

            AssertAttributes(WeaponConstants.DwarvenUrgrosh, attributes);
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

            AssertAttributes(WeaponConstants.Warhammer, attributes);
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

            AssertAttributes(WeaponConstants.Whip, attributes);
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

            AssertAttributes(WeaponConstants.ThrowingAxe, attributes);
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

            AssertAttributes(WeaponConstants.HeavyCrossbow, attributes);
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

            AssertAttributes(WeaponConstants.LightCrossbow, attributes);
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

            AssertAttributes(WeaponConstants.Dart, attributes);
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

            AssertAttributes(WeaponConstants.Javelin, attributes);
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

            AssertAttributes(WeaponConstants.Shortbow, attributes);
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

            AssertAttributes(WeaponConstants.CompositePlus0Shortbow, attributes);
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

            AssertAttributes(WeaponConstants.CompositePlus1Shortbow, attributes);
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

            AssertAttributes(WeaponConstants.CompositePlus2Shortbow, attributes);
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

            AssertAttributes(WeaponConstants.Sling, attributes);
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

            AssertAttributes(WeaponConstants.Longbow, attributes);
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

            AssertAttributes(WeaponConstants.CompositePlus0Longbow, attributes);
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

            AssertAttributes(WeaponConstants.CompositePlus1Longbow, attributes);
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

            AssertAttributes(WeaponConstants.CompositePlus2Longbow, attributes);
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

            AssertAttributes(WeaponConstants.CompositePlus3Longbow, attributes);
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

            AssertAttributes(WeaponConstants.CompositePlus4Longbow, attributes);
        }
    }
}