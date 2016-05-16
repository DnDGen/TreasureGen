using NUnit.Framework;
using System;
using TreasureGen.Items;
using TreasureGen.Domain.Tables;

namespace TreasureGen.Tests.Integration.Tables.Items.Mundane.Weapons
{
    [TestFixture]
    public class WeaponAttributesTests : AttributesTests
    {
        protected override String tableName
        {
            get { return String.Format(TableNameConstants.Attributes.Formattable.ITEMTYPEAttributes, ItemTypeConstants.Weapon); }
        }

        [TestCase(WeaponConstants.Dagger, AttributeConstants.Metal,
                                          AttributeConstants.Common,
                                          AttributeConstants.Melee,
                                          AttributeConstants.NotBludgeoning,
                                          AttributeConstants.Slashing,
                                          AttributeConstants.Ranged,
                                          AttributeConstants.Thrown)]
        [TestCase(WeaponConstants.Greataxe,
            AttributeConstants.Metal,
            AttributeConstants.Common,
            AttributeConstants.Melee,
            AttributeConstants.NotBludgeoning,
            AttributeConstants.Slashing,
            AttributeConstants.TwoHanded)]
        [TestCase(WeaponConstants.Greatsword,
            AttributeConstants.Metal,
            AttributeConstants.Common,
            AttributeConstants.Melee,
            AttributeConstants.NotBludgeoning,
            AttributeConstants.Slashing,
            AttributeConstants.TwoHanded)]
        [TestCase(WeaponConstants.Kama, AttributeConstants.Wood,
                                        AttributeConstants.Metal,
                                        AttributeConstants.Common,
                                        AttributeConstants.Melee,
                                        AttributeConstants.NotBludgeoning,
                                        AttributeConstants.Slashing)]
        [TestCase(WeaponConstants.Longsword, AttributeConstants.Metal,
                                             AttributeConstants.Common,
                                             AttributeConstants.Melee,
                                             AttributeConstants.NotBludgeoning,
                                             AttributeConstants.Slashing)]
        [TestCase(WeaponConstants.LightMace, AttributeConstants.Metal,
                                             AttributeConstants.Common,
                                             AttributeConstants.Melee,
                                             AttributeConstants.Bludgeoning)]
        [TestCase(WeaponConstants.HeavyMace, AttributeConstants.Metal,
                                             AttributeConstants.Common,
                                             AttributeConstants.Melee,
                                             AttributeConstants.Bludgeoning)]
        [TestCase(WeaponConstants.Nunchaku, AttributeConstants.Wood,
                                            AttributeConstants.Common,
                                            AttributeConstants.Melee,
                                            AttributeConstants.Bludgeoning)]
        [TestCase(WeaponConstants.Quarterstaff,
            AttributeConstants.Wood,
            AttributeConstants.Common,
            AttributeConstants.DoubleWeapon,
            AttributeConstants.Melee,
            AttributeConstants.Bludgeoning,
            AttributeConstants.TwoHanded)]
        [TestCase(WeaponConstants.Rapier, AttributeConstants.Metal,
                                          AttributeConstants.Common,
                                          AttributeConstants.Melee,
                                          AttributeConstants.NotBludgeoning)]
        [TestCase(WeaponConstants.Scimitar, AttributeConstants.Metal,
                                            AttributeConstants.Common,
                                            AttributeConstants.Melee,
                                            AttributeConstants.NotBludgeoning,
                                            AttributeConstants.Slashing)]
        [TestCase(WeaponConstants.Shortspear, AttributeConstants.Wood,
                                              AttributeConstants.Metal,
                                              AttributeConstants.Common,
                                              AttributeConstants.Melee,
                                              AttributeConstants.NotBludgeoning,
                                              AttributeConstants.Ranged,
                                              AttributeConstants.Thrown)]
        [TestCase(WeaponConstants.Siangham, AttributeConstants.Metal,
                                            AttributeConstants.Common,
                                            AttributeConstants.Melee,
                                            AttributeConstants.NotBludgeoning)]
        [TestCase(WeaponConstants.BastardSword, AttributeConstants.Metal,
                                                AttributeConstants.Common,
                                                AttributeConstants.Melee,
                                                AttributeConstants.NotBludgeoning,
                                                AttributeConstants.Slashing)]
        [TestCase(WeaponConstants.ShortSword, AttributeConstants.Metal,
                                              AttributeConstants.Common,
                                              AttributeConstants.Melee,
                                              AttributeConstants.NotBludgeoning,
                                              AttributeConstants.Slashing)]
        [TestCase(WeaponConstants.DwarvenWaraxe, AttributeConstants.Metal,
                                                 AttributeConstants.Common,
                                                 AttributeConstants.Melee,
                                                 AttributeConstants.NotBludgeoning,
                                                 AttributeConstants.Slashing)]
        [TestCase(WeaponConstants.OrcDoubleAxe,
            AttributeConstants.Metal,
            AttributeConstants.Uncommon,
            AttributeConstants.DoubleWeapon,
            AttributeConstants.Melee,
            AttributeConstants.NotBludgeoning,
            AttributeConstants.Slashing,
            AttributeConstants.TwoHanded)]
        [TestCase(WeaponConstants.Battleaxe, AttributeConstants.Metal,
                                             AttributeConstants.Uncommon,
                                             AttributeConstants.Melee,
                                             AttributeConstants.NotBludgeoning,
                                             AttributeConstants.Slashing)]
        [TestCase(WeaponConstants.SpikedChain,
            AttributeConstants.Metal,
            AttributeConstants.Uncommon,
            AttributeConstants.Melee,
            AttributeConstants.NotBludgeoning,
            AttributeConstants.TwoHanded)]
        [TestCase(WeaponConstants.Club, AttributeConstants.Wood,
                                        AttributeConstants.Uncommon,
                                        AttributeConstants.Melee,
                                        AttributeConstants.Bludgeoning,
                                        AttributeConstants.Ranged,
                                        AttributeConstants.Thrown)]
        [TestCase(WeaponConstants.HandCrossbow, AttributeConstants.Metal,
                                                AttributeConstants.Uncommon,
                                                AttributeConstants.Ranged,
                                                AttributeConstants.NotBludgeoning)]
        [TestCase(WeaponConstants.HeavyRepeatingCrossbow,
            AttributeConstants.Metal,
            AttributeConstants.Uncommon,
            AttributeConstants.Ranged,
            AttributeConstants.NotBludgeoning,
            AttributeConstants.TwoHanded)]
        [TestCase(WeaponConstants.LightRepeatingCrossbow,
            AttributeConstants.Metal,
            AttributeConstants.Uncommon,
            AttributeConstants.Ranged,
            AttributeConstants.NotBludgeoning,
            AttributeConstants.TwoHanded)]
        [TestCase(WeaponConstants.PunchingDagger, AttributeConstants.Metal,
                                                  AttributeConstants.Uncommon,
                                                  AttributeConstants.Melee,
                                                  AttributeConstants.NotBludgeoning)]
        [TestCase(WeaponConstants.Falchion,
            AttributeConstants.Metal,
            AttributeConstants.Uncommon,
            AttributeConstants.Melee,
            AttributeConstants.NotBludgeoning,
            AttributeConstants.Slashing,
            AttributeConstants.TwoHanded)]
        [TestCase(WeaponConstants.DireFlail,
            AttributeConstants.Metal,
            AttributeConstants.Uncommon,
            AttributeConstants.Melee,
            AttributeConstants.DoubleWeapon,
            AttributeConstants.Bludgeoning,
            AttributeConstants.TwoHanded)]
        [TestCase(WeaponConstants.HeavyFlail,
            AttributeConstants.Metal,
            AttributeConstants.Uncommon,
            AttributeConstants.Melee,
            AttributeConstants.Bludgeoning,
            AttributeConstants.TwoHanded)]
        [TestCase(WeaponConstants.LightFlail, AttributeConstants.Metal,
                                              AttributeConstants.Uncommon,
                                              AttributeConstants.Melee,
                                              AttributeConstants.Bludgeoning)]
        [TestCase(WeaponConstants.Gauntlet, AttributeConstants.Metal,
                                            AttributeConstants.Uncommon,
                                            AttributeConstants.Melee,
                                            AttributeConstants.Bludgeoning)]
        [TestCase(WeaponConstants.SpikedGauntlet, AttributeConstants.Metal,
                                                  AttributeConstants.Uncommon,
                                                  AttributeConstants.Melee,
                                                  AttributeConstants.NotBludgeoning)]
        [TestCase(WeaponConstants.Glaive,
            AttributeConstants.Metal,
            AttributeConstants.Uncommon,
            AttributeConstants.Melee,
            AttributeConstants.NotBludgeoning,
            AttributeConstants.Slashing,
            AttributeConstants.TwoHanded)]
        [TestCase(WeaponConstants.Greatclub,
            AttributeConstants.Wood,
            AttributeConstants.Uncommon,
            AttributeConstants.Melee,
            AttributeConstants.Bludgeoning,
            AttributeConstants.TwoHanded)]
        [TestCase(WeaponConstants.Guisarme,
            AttributeConstants.Metal,
            AttributeConstants.Uncommon,
            AttributeConstants.Melee,
            AttributeConstants.NotBludgeoning,
            AttributeConstants.Slashing,
            AttributeConstants.TwoHanded)]
        [TestCase(WeaponConstants.Halberd,
            AttributeConstants.Metal,
            AttributeConstants.Uncommon,
            AttributeConstants.Melee,
            AttributeConstants.NotBludgeoning,
            AttributeConstants.Slashing,
            AttributeConstants.TwoHanded)]
        [TestCase(WeaponConstants.Halfspear,
            AttributeConstants.Metal,
            AttributeConstants.Wood,
            AttributeConstants.Uncommon,
            AttributeConstants.Melee,
            AttributeConstants.NotBludgeoning,
            AttributeConstants.TwoHanded)]
        [TestCase(WeaponConstants.GnomeHookedHammer,
            AttributeConstants.Metal,
            AttributeConstants.Uncommon,
            AttributeConstants.Melee,
            AttributeConstants.DoubleWeapon,
            AttributeConstants.NotBludgeoning,
            AttributeConstants.Bludgeoning,
            AttributeConstants.TwoHanded)]
        [TestCase(WeaponConstants.LightHammer, AttributeConstants.Metal,
                                               AttributeConstants.Uncommon,
                                               AttributeConstants.Melee,
                                               AttributeConstants.Bludgeoning,
                                               AttributeConstants.Ranged,
                                               AttributeConstants.Thrown)]
        [TestCase(WeaponConstants.Handaxe, AttributeConstants.Metal,
                                           AttributeConstants.Uncommon,
                                           AttributeConstants.Melee,
                                           AttributeConstants.NotBludgeoning,
                                           AttributeConstants.Slashing)]
        [TestCase(WeaponConstants.Kukri, AttributeConstants.Metal,
                                         AttributeConstants.Uncommon,
                                         AttributeConstants.Melee,
                                         AttributeConstants.NotBludgeoning,
                                         AttributeConstants.Slashing)]
        [TestCase(WeaponConstants.Lance,
            AttributeConstants.Wood,
            AttributeConstants.Metal,
            AttributeConstants.Uncommon,
            AttributeConstants.Melee,
            AttributeConstants.NotBludgeoning,
            AttributeConstants.TwoHanded)]
        [TestCase(WeaponConstants.Longspear,
            AttributeConstants.Wood,
            AttributeConstants.Metal,
            AttributeConstants.Uncommon,
            AttributeConstants.Melee,
            AttributeConstants.NotBludgeoning,
            AttributeConstants.TwoHanded)]
        [TestCase(WeaponConstants.Morningstar, AttributeConstants.Metal,
                                               AttributeConstants.Uncommon,
                                               AttributeConstants.Melee,
                                               AttributeConstants.NotBludgeoning,
                                               AttributeConstants.Bludgeoning)]
        [TestCase(WeaponConstants.Net,
            AttributeConstants.Uncommon,
            AttributeConstants.Ranged,
            AttributeConstants.Thrown,
            AttributeConstants.TwoHanded)]
        [TestCase(WeaponConstants.HeavyPick, AttributeConstants.Metal,
                                             AttributeConstants.Uncommon,
                                             AttributeConstants.Melee,
                                             AttributeConstants.NotBludgeoning)]
        [TestCase(WeaponConstants.LightPick, AttributeConstants.Metal,
                                             AttributeConstants.Uncommon,
                                             AttributeConstants.Melee,
                                             AttributeConstants.NotBludgeoning)]
        [TestCase(WeaponConstants.Ranseur,
            AttributeConstants.Wood,
            AttributeConstants.Metal,
            AttributeConstants.Uncommon,
            AttributeConstants.Melee,
            AttributeConstants.NotBludgeoning,
            AttributeConstants.TwoHanded)]
        [TestCase(WeaponConstants.Sap, AttributeConstants.Uncommon,
                                       AttributeConstants.Melee,
                                       AttributeConstants.Bludgeoning)]
        [TestCase(WeaponConstants.Scythe,
            AttributeConstants.Wood,
            AttributeConstants.Metal,
            AttributeConstants.Uncommon,
            AttributeConstants.Melee,
            AttributeConstants.NotBludgeoning,
            AttributeConstants.Slashing,
            AttributeConstants.TwoHanded)]
        [TestCase(WeaponConstants.Shuriken, AttributeConstants.Metal,
                                            AttributeConstants.Uncommon,
                                            AttributeConstants.Ranged,
                                            AttributeConstants.NotBludgeoning,
                                            AttributeConstants.Thrown)]
        [TestCase(WeaponConstants.Sickle, AttributeConstants.Metal,
                                          AttributeConstants.Uncommon,
                                          AttributeConstants.Melee,
                                          AttributeConstants.NotBludgeoning,
                                          AttributeConstants.Slashing)]
        [TestCase(WeaponConstants.TwoBladedSword,
            AttributeConstants.Metal,
            AttributeConstants.Uncommon,
            AttributeConstants.Melee,
            AttributeConstants.DoubleWeapon,
            AttributeConstants.NotBludgeoning,
            AttributeConstants.Slashing,
            AttributeConstants.TwoHanded)]
        [TestCase(WeaponConstants.Trident, AttributeConstants.Metal,
                                           AttributeConstants.Uncommon,
                                           AttributeConstants.Melee,
                                           AttributeConstants.NotBludgeoning,
                                           AttributeConstants.Ranged,
                                           AttributeConstants.Thrown)]
        [TestCase(WeaponConstants.DwarvenUrgrosh,
            AttributeConstants.Metal,
            AttributeConstants.Uncommon,
            AttributeConstants.Melee,
            AttributeConstants.DoubleWeapon,
            AttributeConstants.NotBludgeoning,
            AttributeConstants.Slashing,
            AttributeConstants.TwoHanded)]
        [TestCase(WeaponConstants.Warhammer, AttributeConstants.Metal,
                                             AttributeConstants.Uncommon,
                                             AttributeConstants.Melee,
                                             AttributeConstants.Bludgeoning)]
        [TestCase(WeaponConstants.Whip, AttributeConstants.Uncommon,
                                        AttributeConstants.Melee,
                                        AttributeConstants.NotBludgeoning,
                                        AttributeConstants.Slashing)]
        [TestCase(WeaponConstants.ThrowingAxe, AttributeConstants.Common,
                                               AttributeConstants.Ranged,
                                               AttributeConstants.Metal,
                                               AttributeConstants.NotBludgeoning,
                                               AttributeConstants.Slashing,
                                               AttributeConstants.Thrown)]
        [TestCase(WeaponConstants.HeavyCrossbow,
            AttributeConstants.Common,
            AttributeConstants.Ranged,
            AttributeConstants.Wood,
            AttributeConstants.NotBludgeoning,
            AttributeConstants.TwoHanded)]
        [TestCase(WeaponConstants.LightCrossbow,
            AttributeConstants.Common,
            AttributeConstants.Ranged,
            AttributeConstants.Wood,
            AttributeConstants.NotBludgeoning,
            AttributeConstants.TwoHanded)]
        [TestCase(WeaponConstants.Dart, AttributeConstants.Common,
                                        AttributeConstants.Ranged,
                                        AttributeConstants.Metal,
                                        AttributeConstants.NotBludgeoning,
                                        AttributeConstants.Thrown)]
        [TestCase(WeaponConstants.Javelin, AttributeConstants.Common,
                                           AttributeConstants.Ranged,
                                           AttributeConstants.Metal,
                                           AttributeConstants.Wood,
                                           AttributeConstants.NotBludgeoning,
                                           AttributeConstants.Thrown)]
        [TestCase(WeaponConstants.Shortbow,
            AttributeConstants.Common,
            AttributeConstants.Ranged,
            AttributeConstants.Wood,
            AttributeConstants.NotBludgeoning,
            AttributeConstants.TwoHanded)]
        [TestCase(WeaponConstants.CompositePlus0Shortbow,
            AttributeConstants.Common,
            AttributeConstants.Ranged,
            AttributeConstants.Wood,
            AttributeConstants.NotBludgeoning,
            AttributeConstants.TwoHanded)]
        [TestCase(WeaponConstants.CompositePlus1Shortbow,
            AttributeConstants.Common,
            AttributeConstants.Ranged,
            AttributeConstants.Wood,
            AttributeConstants.NotBludgeoning,
            AttributeConstants.TwoHanded)]
        [TestCase(WeaponConstants.CompositePlus2Shortbow,
            AttributeConstants.Common,
            AttributeConstants.Ranged,
            AttributeConstants.Wood,
            AttributeConstants.NotBludgeoning,
            AttributeConstants.TwoHanded)]
        [TestCase(WeaponConstants.Sling,
            AttributeConstants.Common,
            AttributeConstants.Ranged,
            AttributeConstants.Bludgeoning,
            AttributeConstants.TwoHanded)]
        [TestCase(WeaponConstants.Longbow,
            AttributeConstants.Common,
            AttributeConstants.Ranged,
            AttributeConstants.Wood,
            AttributeConstants.NotBludgeoning,
            AttributeConstants.TwoHanded)]
        [TestCase(WeaponConstants.CompositePlus0Longbow,
            AttributeConstants.Common,
            AttributeConstants.Ranged,
            AttributeConstants.Wood,
            AttributeConstants.NotBludgeoning,
            AttributeConstants.TwoHanded)]
        [TestCase(WeaponConstants.CompositePlus1Longbow,
            AttributeConstants.Common,
            AttributeConstants.Ranged,
            AttributeConstants.Wood,
            AttributeConstants.NotBludgeoning,
            AttributeConstants.TwoHanded)]
        [TestCase(WeaponConstants.CompositePlus2Longbow,
            AttributeConstants.Common,
            AttributeConstants.Ranged,
            AttributeConstants.Wood,
            AttributeConstants.NotBludgeoning,
            AttributeConstants.TwoHanded)]
        [TestCase(WeaponConstants.CompositePlus3Longbow,
            AttributeConstants.Common,
            AttributeConstants.Ranged,
            AttributeConstants.Wood,
            AttributeConstants.NotBludgeoning,
            AttributeConstants.TwoHanded)]
        [TestCase(WeaponConstants.CompositePlus4Longbow,
            AttributeConstants.Common,
            AttributeConstants.Ranged,
            AttributeConstants.Wood,
            AttributeConstants.NotBludgeoning,
            AttributeConstants.TwoHanded)]
        public override void Attributes(String name, params String[] attributes)
        {
            base.Attributes(name, attributes);
        }
    }
}