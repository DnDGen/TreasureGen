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
        [TestCase(WeaponConstants.OrcDoubleAxe, ItemTypeConstants.Weapon,
                                                AttributeConstants.Metal,
                                                AttributeConstants.Uncommon,
                                                AttributeConstants.DoubleWeapon,
                                                AttributeConstants.Melee,
                                                AttributeConstants.NotBludgeoning,
                                                AttributeConstants.Slashing)]
        [TestCase(WeaponConstants.Battleaxe, ItemTypeConstants.Weapon,
                                             AttributeConstants.Metal,
                                             AttributeConstants.Uncommon,
                                             AttributeConstants.Melee,
                                             AttributeConstants.NotBludgeoning,
                                             AttributeConstants.Slashing)]
        [TestCase(WeaponConstants.SpikedChain, ItemTypeConstants.Weapon,
                                               AttributeConstants.Metal,
                                               AttributeConstants.Uncommon,
                                               AttributeConstants.Melee,
                                               AttributeConstants.NotBludgeoning)]
        [TestCase(WeaponConstants.Club, ItemTypeConstants.Weapon,
                                        AttributeConstants.Wood,
                                        AttributeConstants.Uncommon,
                                        AttributeConstants.Melee,
                                        AttributeConstants.Bludgeoning,
                                        AttributeConstants.Ranged,
                                        AttributeConstants.Thrown)]
        [TestCase(WeaponConstants.HandCrossbow, ItemTypeConstants.Weapon,
                                                AttributeConstants.Metal,
                                                AttributeConstants.Uncommon,
                                                AttributeConstants.Ranged,
                                                AttributeConstants.NotBludgeoning)]
        [TestCase(WeaponConstants.RepeatingCrossbow, ItemTypeConstants.Weapon,
                                                     AttributeConstants.Metal,
                                                     AttributeConstants.Uncommon,
                                                     AttributeConstants.Ranged,
                                                     AttributeConstants.NotBludgeoning)]
        [TestCase(WeaponConstants.PunchingDagger, ItemTypeConstants.Weapon,
                                                  AttributeConstants.Metal,
                                                  AttributeConstants.Uncommon,
                                                  AttributeConstants.Melee,
                                                  AttributeConstants.NotBludgeoning)]
        [TestCase(WeaponConstants.Falchion, ItemTypeConstants.Weapon,
                                            AttributeConstants.Metal,
                                            AttributeConstants.Uncommon,
                                            AttributeConstants.Melee,
                                            AttributeConstants.NotBludgeoning,
                                            AttributeConstants.Slashing)]
        [TestCase(WeaponConstants.DireFlail, ItemTypeConstants.Weapon,
                                             AttributeConstants.Metal,
                                             AttributeConstants.Uncommon,
                                             AttributeConstants.Melee,
                                             AttributeConstants.DoubleWeapon,
                                             AttributeConstants.Bludgeoning)]
        [TestCase(WeaponConstants.HeavyFlail, ItemTypeConstants.Weapon,
                                              AttributeConstants.Metal,
                                              AttributeConstants.Uncommon,
                                              AttributeConstants.Melee,
                                              AttributeConstants.Bludgeoning)]
        [TestCase(WeaponConstants.LightFlail, ItemTypeConstants.Weapon,
                                              AttributeConstants.Metal,
                                              AttributeConstants.Uncommon,
                                              AttributeConstants.Melee,
                                              AttributeConstants.Bludgeoning)]
        [TestCase(WeaponConstants.Gauntlet, ItemTypeConstants.Weapon,
                                            AttributeConstants.Metal,
                                            AttributeConstants.Uncommon,
                                            AttributeConstants.Melee,
                                            AttributeConstants.Bludgeoning)]
        [TestCase(WeaponConstants.SpikedGauntlet, ItemTypeConstants.Weapon,
                                                  AttributeConstants.Metal,
                                                  AttributeConstants.Uncommon,
                                                  AttributeConstants.Melee,
                                                  AttributeConstants.NotBludgeoning)]
        [TestCase(WeaponConstants.Glaive, ItemTypeConstants.Weapon,
                                          AttributeConstants.Metal,
                                          AttributeConstants.Uncommon,
                                          AttributeConstants.Melee,
                                          AttributeConstants.NotBludgeoning,
                                          AttributeConstants.Slashing)]
        [TestCase(WeaponConstants.Greatclub, ItemTypeConstants.Weapon,
                                             AttributeConstants.Wood,
                                             AttributeConstants.Uncommon,
                                             AttributeConstants.Melee,
                                             AttributeConstants.Bludgeoning)]
        [TestCase(WeaponConstants.Guisarme, ItemTypeConstants.Weapon,
                                            AttributeConstants.Metal,
                                            AttributeConstants.Uncommon,
                                            AttributeConstants.Melee,
                                            AttributeConstants.NotBludgeoning,
                                            AttributeConstants.Slashing)]
        [TestCase(WeaponConstants.Halberd, ItemTypeConstants.Weapon,
                                           AttributeConstants.Metal,
                                           AttributeConstants.Uncommon,
                                           AttributeConstants.Melee,
                                           AttributeConstants.NotBludgeoning,
                                           AttributeConstants.Slashing)]
        [TestCase(WeaponConstants.Halfspear, ItemTypeConstants.Weapon,
                                             AttributeConstants.Metal,
                                             AttributeConstants.Wood,
                                             AttributeConstants.Uncommon,
                                             AttributeConstants.Melee,
                                             AttributeConstants.NotBludgeoning)]
        [TestCase(WeaponConstants.GnomeHookedHammer, ItemTypeConstants.Weapon,
                                                     AttributeConstants.Metal,
                                                     AttributeConstants.Uncommon,
                                                     AttributeConstants.Melee,
                                                     AttributeConstants.DoubleWeapon,
                                                     AttributeConstants.NotBludgeoning,
                                                     AttributeConstants.Bludgeoning)]
        [TestCase(WeaponConstants.LightHammer, ItemTypeConstants.Weapon,
                                               AttributeConstants.Metal,
                                               AttributeConstants.Uncommon,
                                               AttributeConstants.Melee,
                                               AttributeConstants.Bludgeoning,
                                               AttributeConstants.Ranged,
                                               AttributeConstants.Thrown)]
        [TestCase(WeaponConstants.Handaxe, ItemTypeConstants.Weapon,
                                           AttributeConstants.Metal,
                                           AttributeConstants.Uncommon,
                                           AttributeConstants.Melee,
                                           AttributeConstants.NotBludgeoning,
                                           AttributeConstants.Slashing)]
        [TestCase(WeaponConstants.Kukri, ItemTypeConstants.Weapon,
                                         AttributeConstants.Metal,
                                         AttributeConstants.Uncommon,
                                         AttributeConstants.Melee,
                                         AttributeConstants.NotBludgeoning,
                                         AttributeConstants.Slashing)]
        [TestCase(WeaponConstants.Lance, ItemTypeConstants.Weapon,
                                         AttributeConstants.Wood,
                                         AttributeConstants.Metal,
                                         AttributeConstants.Uncommon,
                                         AttributeConstants.Melee,
                                         AttributeConstants.NotBludgeoning)]
        [TestCase(WeaponConstants.Longspear, ItemTypeConstants.Weapon,
                                             AttributeConstants.Wood,
                                             AttributeConstants.Metal,
                                             AttributeConstants.Uncommon,
                                             AttributeConstants.Melee,
                                             AttributeConstants.NotBludgeoning)]
        [TestCase(WeaponConstants.Morningstar, ItemTypeConstants.Weapon,
                                               AttributeConstants.Metal,
                                               AttributeConstants.Uncommon,
                                               AttributeConstants.Melee,
                                               AttributeConstants.NotBludgeoning,
                                               AttributeConstants.Bludgeoning)]
        [TestCase(WeaponConstants.Net, ItemTypeConstants.Weapon,
                                       AttributeConstants.Uncommon,
                                       AttributeConstants.Ranged,
                                       AttributeConstants.Thrown)]
        [TestCase(WeaponConstants.HeavyPick, ItemTypeConstants.Weapon,
                                             AttributeConstants.Metal,
                                             AttributeConstants.Uncommon,
                                             AttributeConstants.Melee,
                                             AttributeConstants.NotBludgeoning)]
        [TestCase(WeaponConstants.LightPick, ItemTypeConstants.Weapon,
                                             AttributeConstants.Metal,
                                             AttributeConstants.Uncommon,
                                             AttributeConstants.Melee,
                                             AttributeConstants.NotBludgeoning)]
        [TestCase(WeaponConstants.Ranseur, ItemTypeConstants.Weapon,
                                           AttributeConstants.Wood,
                                           AttributeConstants.Metal,
                                           AttributeConstants.Uncommon,
                                           AttributeConstants.Melee,
                                           AttributeConstants.NotBludgeoning)]
        [TestCase(WeaponConstants.Sap, ItemTypeConstants.Weapon,
                                       AttributeConstants.Uncommon,
                                       AttributeConstants.Melee,
                                       AttributeConstants.Bludgeoning)]
        [TestCase(WeaponConstants.Scythe, ItemTypeConstants.Weapon,
                                          AttributeConstants.Wood,
                                          AttributeConstants.Metal,
                                          AttributeConstants.Uncommon,
                                          AttributeConstants.Melee,
                                          AttributeConstants.NotBludgeoning,
                                          AttributeConstants.Slashing)]
        [TestCase(WeaponConstants.Shuriken, ItemTypeConstants.Weapon,
                                            AttributeConstants.Metal,
                                            AttributeConstants.Uncommon,
                                            AttributeConstants.Ranged,
                                            AttributeConstants.NotBludgeoning,
                                            AttributeConstants.Thrown)]
        [TestCase(WeaponConstants.Sickle, ItemTypeConstants.Weapon,
                                          AttributeConstants.Metal,
                                          AttributeConstants.Uncommon,
                                          AttributeConstants.Melee,
                                          AttributeConstants.NotBludgeoning,
                                          AttributeConstants.Slashing)]
        [TestCase(WeaponConstants.TwoBladedSword, ItemTypeConstants.Weapon,
                                                  AttributeConstants.Metal,
                                                  AttributeConstants.Uncommon,
                                                  AttributeConstants.Melee,
                                                  AttributeConstants.DoubleWeapon,
                                                  AttributeConstants.NotBludgeoning,
                                                  AttributeConstants.Slashing)]
        [TestCase(WeaponConstants.Trident, ItemTypeConstants.Weapon,
                                           AttributeConstants.Metal,
                                           AttributeConstants.Uncommon,
                                           AttributeConstants.Melee,
                                           AttributeConstants.NotBludgeoning,
                                           AttributeConstants.Ranged,
                                           AttributeConstants.Thrown)]
        [TestCase(WeaponConstants.DwarvenUrgrosh, ItemTypeConstants.Weapon,
                                                  AttributeConstants.Metal,
                                                  AttributeConstants.Uncommon,
                                                  AttributeConstants.Melee,
                                                  AttributeConstants.DoubleWeapon,
                                                  AttributeConstants.NotBludgeoning,
                                                  AttributeConstants.Slashing)]
        [TestCase(WeaponConstants.Warhammer, ItemTypeConstants.Weapon,
                                             AttributeConstants.Metal,
                                             AttributeConstants.Uncommon,
                                             AttributeConstants.Melee,
                                             AttributeConstants.Bludgeoning)]
        [TestCase(WeaponConstants.Whip, ItemTypeConstants.Weapon,
                                        AttributeConstants.Uncommon,
                                        AttributeConstants.Melee,
                                        AttributeConstants.NotBludgeoning,
                                        AttributeConstants.Slashing)]
        [TestCase(WeaponConstants.ThrowingAxe, ItemTypeConstants.Weapon,
                                               AttributeConstants.Common,
                                               AttributeConstants.Ranged,
                                               AttributeConstants.Metal,
                                               AttributeConstants.NotBludgeoning,
                                               AttributeConstants.Slashing,
                                               AttributeConstants.Thrown)]
        [TestCase(WeaponConstants.HeavyCrossbow, ItemTypeConstants.Weapon,
                                                 AttributeConstants.Common,
                                                 AttributeConstants.Ranged,
                                                 AttributeConstants.Wood,
                                                 AttributeConstants.NotBludgeoning)]
        [TestCase(WeaponConstants.LightCrossbow, ItemTypeConstants.Weapon,
                                                 AttributeConstants.Common,
                                                 AttributeConstants.Ranged,
                                                 AttributeConstants.Wood,
                                                 AttributeConstants.NotBludgeoning)]
        [TestCase(WeaponConstants.Dart, ItemTypeConstants.Weapon,
                                        AttributeConstants.Common,
                                        AttributeConstants.Ranged,
                                        AttributeConstants.Metal,
                                        AttributeConstants.NotBludgeoning,
                                        AttributeConstants.Thrown)]
        [TestCase(WeaponConstants.Javelin, ItemTypeConstants.Weapon,
                                           AttributeConstants.Common,
                                           AttributeConstants.Ranged,
                                           AttributeConstants.Metal,
                                           AttributeConstants.Wood,
                                           AttributeConstants.NotBludgeoning,
                                           AttributeConstants.Thrown)]
        [TestCase(WeaponConstants.Shortbow, ItemTypeConstants.Weapon,
                                            AttributeConstants.Common,
                                            AttributeConstants.Ranged,
                                            AttributeConstants.Wood,
                                            AttributeConstants.NotBludgeoning)]
        [TestCase(WeaponConstants.CompositePlus0Shortbow, ItemTypeConstants.Weapon,
                                                          AttributeConstants.Common,
                                                          AttributeConstants.Ranged,
                                                          AttributeConstants.Wood,
                                                          AttributeConstants.NotBludgeoning)]
        [TestCase(WeaponConstants.CompositePlus1Shortbow, ItemTypeConstants.Weapon,
                                                          AttributeConstants.Common,
                                                          AttributeConstants.Ranged,
                                                          AttributeConstants.Wood,
                                                          AttributeConstants.NotBludgeoning)]
        [TestCase(WeaponConstants.CompositePlus2Shortbow, ItemTypeConstants.Weapon,
                                                          AttributeConstants.Common,
                                                          AttributeConstants.Ranged,
                                                          AttributeConstants.Wood,
                                                          AttributeConstants.NotBludgeoning)]
        [TestCase(WeaponConstants.Sling, ItemTypeConstants.Weapon,
                                         AttributeConstants.Common,
                                         AttributeConstants.Ranged,
                                         AttributeConstants.Bludgeoning)]
        [TestCase(WeaponConstants.Longbow, ItemTypeConstants.Weapon,
                                           AttributeConstants.Common,
                                           AttributeConstants.Ranged,
                                           AttributeConstants.Wood,
                                           AttributeConstants.NotBludgeoning)]
        [TestCase(WeaponConstants.CompositePlus0Longbow, ItemTypeConstants.Weapon,
                                                         AttributeConstants.Common,
                                                         AttributeConstants.Ranged,
                                                         AttributeConstants.Wood,
                                                         AttributeConstants.NotBludgeoning)]
        [TestCase(WeaponConstants.CompositePlus1Longbow, ItemTypeConstants.Weapon,
                                                         AttributeConstants.Common,
                                                         AttributeConstants.Ranged,
                                                         AttributeConstants.Wood,
                                                         AttributeConstants.NotBludgeoning)]
        [TestCase(WeaponConstants.CompositePlus2Longbow, ItemTypeConstants.Weapon,
                                                         AttributeConstants.Common,
                                                         AttributeConstants.Ranged,
                                                         AttributeConstants.Wood,
                                                         AttributeConstants.NotBludgeoning)]
        [TestCase(WeaponConstants.CompositePlus3Longbow, ItemTypeConstants.Weapon,
                                                         AttributeConstants.Common,
                                                         AttributeConstants.Ranged,
                                                         AttributeConstants.Wood,
                                                         AttributeConstants.NotBludgeoning)]
        [TestCase(WeaponConstants.CompositePlus4Longbow, ItemTypeConstants.Weapon,
                                                         AttributeConstants.Common,
                                                         AttributeConstants.Ranged,
                                                         AttributeConstants.Wood,
                                                         AttributeConstants.NotBludgeoning)]
        public void Attributes(String name, params String[] attributes)
        {
            AssertAttributes(name, attributes);
        }
    }
}