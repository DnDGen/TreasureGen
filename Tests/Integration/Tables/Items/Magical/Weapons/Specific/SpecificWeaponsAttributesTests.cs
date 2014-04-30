using System;
using EquipmentGen.Common.Items;
using NUnit.Framework;

namespace EquipmentGen.Tests.Integration.Tables.Items.Magical.Weapons.Specific
{
    [TestFixture]
    public class SpecificWeaponsAttributesTests : AttributesTests
    {
        protected override String tableName
        {
            get { return "SpecificWeaponsAttributes"; }
        }

        [TestCase(WeaponConstants.SleepArrow, ItemTypeConstants.Weapon,
                                              AttributeConstants.Ammunition,
                                              AttributeConstants.Specific,
                                              AttributeConstants.NotBludgeoning,
                                              AttributeConstants.Ranged,
                                              AttributeConstants.Wood,
                                              AttributeConstants.Metal)]
        [TestCase(WeaponConstants.ScreamingBolt, ItemTypeConstants.Weapon,
                                                 AttributeConstants.Ammunition,
                                                 AttributeConstants.Specific,
                                                 AttributeConstants.NotBludgeoning,
                                                 AttributeConstants.Ranged,
                                                 AttributeConstants.Metal)]
        [TestCase(WeaponConstants.SilverDagger, ItemTypeConstants.Weapon,
                                                AttributeConstants.Slashing,
                                                AttributeConstants.Specific,
                                                AttributeConstants.NotBludgeoning,
                                                AttributeConstants.Melee,
                                                AttributeConstants.Metal)]
        [TestCase(WeaponConstants.Longsword, ItemTypeConstants.Weapon,
                                             AttributeConstants.Melee,
                                             AttributeConstants.Specific,
                                             AttributeConstants.NotBludgeoning,
                                             AttributeConstants.Slashing,
                                             AttributeConstants.Metal)]
        [TestCase(WeaponConstants.JavelinOfLightning, ItemTypeConstants.Weapon,
                                                      AttributeConstants.Specific,
                                                      AttributeConstants.Ranged,
                                                      AttributeConstants.Wood,
                                                      AttributeConstants.Metal,
                                                      AttributeConstants.Thrown,
                                                      AttributeConstants.OneTimeUse)]
        [TestCase(WeaponConstants.SlayingArrow, ItemTypeConstants.Weapon,
                                                AttributeConstants.Ammunition,
                                                AttributeConstants.Specific,
                                                AttributeConstants.NotBludgeoning,
                                                AttributeConstants.Ranged,
                                                AttributeConstants.Wood,
                                                AttributeConstants.Metal)]
        [TestCase(WeaponConstants.Dagger, ItemTypeConstants.Weapon,
                                          AttributeConstants.Slashing,
                                          AttributeConstants.Specific,
                                          AttributeConstants.NotBludgeoning,
                                          AttributeConstants.Melee,
                                          AttributeConstants.Metal)]
        [TestCase(WeaponConstants.Battleaxe, ItemTypeConstants.Weapon,
                                             AttributeConstants.Slashing,
                                             AttributeConstants.Specific,
                                             AttributeConstants.NotBludgeoning,
                                             AttributeConstants.Melee,
                                             AttributeConstants.Metal)]
        [TestCase(WeaponConstants.GreaterSlayingArrow, ItemTypeConstants.Weapon,
                                                       AttributeConstants.Ammunition,
                                                       AttributeConstants.Specific,
                                                       AttributeConstants.NotBludgeoning,
                                                       AttributeConstants.Ranged,
                                                       AttributeConstants.Wood,
                                                       AttributeConstants.Metal)]
        [TestCase(WeaponConstants.Shatterspike, ItemTypeConstants.Weapon,
                                                AttributeConstants.Slashing,
                                                AttributeConstants.Specific,
                                                AttributeConstants.NotBludgeoning,
                                                AttributeConstants.Melee,
                                                AttributeConstants.Metal)]
        [TestCase(WeaponConstants.DaggerOfVenom, ItemTypeConstants.Weapon,
                                                 AttributeConstants.Slashing,
                                                 AttributeConstants.Specific,
                                                 AttributeConstants.NotBludgeoning,
                                                 AttributeConstants.Melee,
                                                 AttributeConstants.Metal)]
        [TestCase(WeaponConstants.TridentOfWarning, ItemTypeConstants.Weapon,
                                                    AttributeConstants.Specific,
                                                    AttributeConstants.NotBludgeoning,
                                                    AttributeConstants.Melee,
                                                    AttributeConstants.Metal)]
        [TestCase(WeaponConstants.AssassinsDagger, ItemTypeConstants.Weapon,
                                                   AttributeConstants.Slashing,
                                                   AttributeConstants.Specific,
                                                   AttributeConstants.NotBludgeoning,
                                                   AttributeConstants.Melee,
                                                   AttributeConstants.Metal)]
        [TestCase(WeaponConstants.ShiftersSorrow, ItemTypeConstants.Weapon,
                                                  AttributeConstants.Slashing,
                                                  AttributeConstants.Specific,
                                                  AttributeConstants.NotBludgeoning,
                                                  AttributeConstants.Melee,
                                                  AttributeConstants.DoubleWeapon,
                                                  AttributeConstants.Metal)]
        [TestCase(WeaponConstants.TridentOfFishCommand, ItemTypeConstants.Weapon,
                                                        AttributeConstants.Specific,
                                                        AttributeConstants.NotBludgeoning,
                                                        AttributeConstants.Melee,
                                                        AttributeConstants.Metal)]
        [TestCase(WeaponConstants.FlameTongue, ItemTypeConstants.Weapon,
                                               AttributeConstants.Slashing,
                                               AttributeConstants.Specific,
                                               AttributeConstants.NotBludgeoning,
                                               AttributeConstants.Melee,
                                               AttributeConstants.Metal)]
        [TestCase(WeaponConstants.LuckBlade0, ItemTypeConstants.Weapon,
                                              AttributeConstants.Slashing,
                                              AttributeConstants.Specific,
                                              AttributeConstants.NotBludgeoning,
                                              AttributeConstants.Melee,
                                              AttributeConstants.Metal)]
        [TestCase(WeaponConstants.SwordOfSubtlety, ItemTypeConstants.Weapon,
                                                   AttributeConstants.Slashing,
                                                   AttributeConstants.Specific,
                                                   AttributeConstants.NotBludgeoning,
                                                   AttributeConstants.Melee,
                                                   AttributeConstants.Metal)]
        [TestCase(WeaponConstants.SwordOfThePlanes, ItemTypeConstants.Weapon,
                                                    AttributeConstants.Slashing,
                                                    AttributeConstants.Specific,
                                                    AttributeConstants.NotBludgeoning,
                                                    AttributeConstants.Melee,
                                                    AttributeConstants.Metal)]
        [TestCase(WeaponConstants.NineLivesStealer, ItemTypeConstants.Weapon,
                                                    AttributeConstants.Slashing,
                                                    AttributeConstants.Specific,
                                                    AttributeConstants.NotBludgeoning,
                                                    AttributeConstants.Melee,
                                                    AttributeConstants.Metal)]
        [TestCase(WeaponConstants.SwordOfLifeStealing, ItemTypeConstants.Weapon,
                                                       AttributeConstants.Slashing,
                                                       AttributeConstants.Specific,
                                                       AttributeConstants.NotBludgeoning,
                                                       AttributeConstants.Melee,
                                                       AttributeConstants.Metal)]
        [TestCase(WeaponConstants.Oathbow, ItemTypeConstants.Weapon,
                                           AttributeConstants.Specific,
                                           AttributeConstants.NotBludgeoning,
                                           AttributeConstants.Ranged,
                                           AttributeConstants.Wood)]
        [TestCase(WeaponConstants.MaceOfTerror, ItemTypeConstants.Weapon,
                                                AttributeConstants.Specific,
                                                AttributeConstants.Bludgeoning,
                                                AttributeConstants.Melee,
                                                AttributeConstants.Metal)]
        [TestCase(WeaponConstants.LifeDrinker, ItemTypeConstants.Weapon,
                                               AttributeConstants.Slashing,
                                               AttributeConstants.Specific,
                                               AttributeConstants.NotBludgeoning,
                                               AttributeConstants.Melee,
                                               AttributeConstants.Metal)]
        [TestCase(WeaponConstants.SylvanScimitar, ItemTypeConstants.Weapon,
                                                  AttributeConstants.Slashing,
                                                  AttributeConstants.Specific,
                                                  AttributeConstants.NotBludgeoning,
                                                  AttributeConstants.Melee,
                                                  AttributeConstants.Metal)]
        [TestCase(WeaponConstants.RapierOfPuncturing, ItemTypeConstants.Weapon,
                                                      AttributeConstants.Specific,
                                                      AttributeConstants.NotBludgeoning,
                                                      AttributeConstants.Melee,
                                                      AttributeConstants.Metal)]
        [TestCase(WeaponConstants.SunBlade, ItemTypeConstants.Weapon,
                                            AttributeConstants.Slashing,
                                            AttributeConstants.Specific,
                                            AttributeConstants.NotBludgeoning,
                                            AttributeConstants.Melee,
                                            AttributeConstants.Metal)]
        [TestCase(WeaponConstants.FrostBrand, ItemTypeConstants.Weapon,
                                              AttributeConstants.Slashing,
                                              AttributeConstants.Specific,
                                              AttributeConstants.NotBludgeoning,
                                              AttributeConstants.Melee,
                                              AttributeConstants.Metal)]
        [TestCase(WeaponConstants.DwarvenThrower, ItemTypeConstants.Weapon,
                                                  AttributeConstants.Specific,
                                                  AttributeConstants.Bludgeoning,
                                                  AttributeConstants.Melee,
                                                  AttributeConstants.Metal)]
        [TestCase(WeaponConstants.LuckBlade1, ItemTypeConstants.Weapon,
                                              AttributeConstants.Slashing,
                                              AttributeConstants.Specific,
                                              AttributeConstants.NotBludgeoning,
                                              AttributeConstants.Melee,
                                              AttributeConstants.Metal)]
        [TestCase(WeaponConstants.MaceOfSmiting, ItemTypeConstants.Weapon,
                                                 AttributeConstants.Specific,
                                                 AttributeConstants.Bludgeoning,
                                                 AttributeConstants.Melee,
                                                 AttributeConstants.Metal)]
        [TestCase(WeaponConstants.LuckBlade2, ItemTypeConstants.Weapon,
                                              AttributeConstants.Slashing,
                                              AttributeConstants.Specific,
                                              AttributeConstants.NotBludgeoning,
                                              AttributeConstants.Melee,
                                              AttributeConstants.Metal)]
        [TestCase(WeaponConstants.HolyAvenger, ItemTypeConstants.Weapon,
                                               AttributeConstants.Slashing,
                                               AttributeConstants.Specific,
                                               AttributeConstants.NotBludgeoning,
                                               AttributeConstants.Melee,
                                               AttributeConstants.Metal)]
        [TestCase(WeaponConstants.LuckBlade3, ItemTypeConstants.Weapon,
                                              AttributeConstants.Slashing,
                                              AttributeConstants.Specific,
                                              AttributeConstants.NotBludgeoning,
                                              AttributeConstants.Melee,
                                              AttributeConstants.Metal)]
        public void Attributes(String name, params String[] attributes)
        {
            AssertAttributes(name, attributes);
        }
    }
}