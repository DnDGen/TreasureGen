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

        [TestCase(WeaponConstants.SleepArrow, AttributeConstants.Ammunition,
                                              AttributeConstants.Specific,
                                              AttributeConstants.NotBludgeoning,
                                              AttributeConstants.Ranged,
                                              AttributeConstants.Wood,
                                              AttributeConstants.Metal)]
        [TestCase(WeaponConstants.ScreamingBolt, AttributeConstants.Ammunition,
                                                 AttributeConstants.Specific,
                                                 AttributeConstants.NotBludgeoning,
                                                 AttributeConstants.Ranged,
                                                 AttributeConstants.Metal)]
        [TestCase(WeaponConstants.SilverDagger, AttributeConstants.Slashing,
                                                AttributeConstants.Specific,
                                                AttributeConstants.NotBludgeoning,
                                                AttributeConstants.Melee,
                                                AttributeConstants.Metal)]
        [TestCase(WeaponConstants.Longsword, AttributeConstants.Melee,
                                             AttributeConstants.Specific,
                                             AttributeConstants.NotBludgeoning,
                                             AttributeConstants.Slashing,
                                             AttributeConstants.Metal)]
        [TestCase(WeaponConstants.JavelinOfLightning, AttributeConstants.Specific,
                                                      AttributeConstants.Ranged,
                                                      AttributeConstants.Wood,
                                                      AttributeConstants.Metal,
                                                      AttributeConstants.Thrown,
                                                      AttributeConstants.OneTimeUse)]
        [TestCase(WeaponConstants.SlayingArrow, AttributeConstants.Ammunition,
                                                AttributeConstants.Specific,
                                                AttributeConstants.NotBludgeoning,
                                                AttributeConstants.Ranged,
                                                AttributeConstants.Wood,
                                                AttributeConstants.Metal)]
        [TestCase(WeaponConstants.Dagger, AttributeConstants.Slashing,
                                          AttributeConstants.Specific,
                                          AttributeConstants.NotBludgeoning,
                                          AttributeConstants.Melee,
                                          AttributeConstants.Metal)]
        [TestCase(WeaponConstants.Battleaxe, AttributeConstants.Slashing,
                                             AttributeConstants.Specific,
                                             AttributeConstants.NotBludgeoning,
                                             AttributeConstants.Melee,
                                             AttributeConstants.Metal)]
        [TestCase(WeaponConstants.GreaterSlayingArrow, AttributeConstants.Ammunition,
                                                       AttributeConstants.Specific,
                                                       AttributeConstants.NotBludgeoning,
                                                       AttributeConstants.Ranged,
                                                       AttributeConstants.Wood,
                                                       AttributeConstants.Metal)]
        [TestCase(WeaponConstants.Shatterspike, AttributeConstants.Slashing,
                                                AttributeConstants.Specific,
                                                AttributeConstants.NotBludgeoning,
                                                AttributeConstants.Melee,
                                                AttributeConstants.Metal)]
        [TestCase(WeaponConstants.DaggerOfVenom, AttributeConstants.Slashing,
                                                 AttributeConstants.Specific,
                                                 AttributeConstants.NotBludgeoning,
                                                 AttributeConstants.Melee,
                                                 AttributeConstants.Metal)]
        [TestCase(WeaponConstants.TridentOfWarning, AttributeConstants.Specific,
                                                    AttributeConstants.NotBludgeoning,
                                                    AttributeConstants.Melee,
                                                    AttributeConstants.Metal)]
        [TestCase(WeaponConstants.AssassinsDagger, AttributeConstants.Slashing,
                                                   AttributeConstants.Specific,
                                                   AttributeConstants.NotBludgeoning,
                                                   AttributeConstants.Melee,
                                                   AttributeConstants.Metal)]
        [TestCase(WeaponConstants.ShiftersSorrow, AttributeConstants.Slashing,
                                                  AttributeConstants.Specific,
                                                  AttributeConstants.NotBludgeoning,
                                                  AttributeConstants.Melee,
                                                  AttributeConstants.DoubleWeapon,
                                                  AttributeConstants.Metal)]
        [TestCase(WeaponConstants.TridentOfFishCommand, AttributeConstants.Specific,
                                                        AttributeConstants.NotBludgeoning,
                                                        AttributeConstants.Melee,
                                                        AttributeConstants.Metal)]
        [TestCase(WeaponConstants.FlameTongue, AttributeConstants.Slashing,
                                               AttributeConstants.Specific,
                                               AttributeConstants.NotBludgeoning,
                                               AttributeConstants.Melee,
                                               AttributeConstants.Metal)]
        [TestCase(WeaponConstants.LuckBlade0, AttributeConstants.Slashing,
                                              AttributeConstants.Specific,
                                              AttributeConstants.NotBludgeoning,
                                              AttributeConstants.Melee,
                                              AttributeConstants.Metal)]
        [TestCase(WeaponConstants.SwordOfSubtlety, AttributeConstants.Slashing,
                                                   AttributeConstants.Specific,
                                                   AttributeConstants.NotBludgeoning,
                                                   AttributeConstants.Melee,
                                                   AttributeConstants.Metal)]
        [TestCase(WeaponConstants.SwordOfThePlanes, AttributeConstants.Slashing,
                                                    AttributeConstants.Specific,
                                                    AttributeConstants.NotBludgeoning,
                                                    AttributeConstants.Melee,
                                                    AttributeConstants.Metal)]
        [TestCase(WeaponConstants.NineLivesStealer, AttributeConstants.Slashing,
                                                    AttributeConstants.Specific,
                                                    AttributeConstants.NotBludgeoning,
                                                    AttributeConstants.Melee,
                                                    AttributeConstants.Metal)]
        [TestCase(WeaponConstants.SwordOfLifeStealing, AttributeConstants.Slashing,
                                                       AttributeConstants.Specific,
                                                       AttributeConstants.NotBludgeoning,
                                                       AttributeConstants.Melee,
                                                       AttributeConstants.Metal)]
        [TestCase(WeaponConstants.Oathbow, AttributeConstants.Specific,
                                           AttributeConstants.NotBludgeoning,
                                           AttributeConstants.Ranged,
                                           AttributeConstants.Wood)]
        [TestCase(WeaponConstants.MaceOfTerror, AttributeConstants.Specific,
                                                AttributeConstants.Bludgeoning,
                                                AttributeConstants.Melee,
                                                AttributeConstants.Metal)]
        [TestCase(WeaponConstants.LifeDrinker, AttributeConstants.Slashing,
                                               AttributeConstants.Specific,
                                               AttributeConstants.NotBludgeoning,
                                               AttributeConstants.Melee,
                                               AttributeConstants.Metal)]
        [TestCase(WeaponConstants.SylvanScimitar, AttributeConstants.Slashing,
                                                  AttributeConstants.Specific,
                                                  AttributeConstants.NotBludgeoning,
                                                  AttributeConstants.Melee,
                                                  AttributeConstants.Metal)]
        [TestCase(WeaponConstants.RapierOfPuncturing, AttributeConstants.Specific,
                                                      AttributeConstants.NotBludgeoning,
                                                      AttributeConstants.Melee,
                                                      AttributeConstants.Metal)]
        [TestCase(WeaponConstants.SunBlade, AttributeConstants.Slashing,
                                            AttributeConstants.Specific,
                                            AttributeConstants.NotBludgeoning,
                                            AttributeConstants.Melee,
                                            AttributeConstants.Metal)]
        [TestCase(WeaponConstants.FrostBrand, AttributeConstants.Slashing,
                                              AttributeConstants.Specific,
                                              AttributeConstants.NotBludgeoning,
                                              AttributeConstants.Melee,
                                              AttributeConstants.Metal)]
        [TestCase(WeaponConstants.DwarvenThrower, AttributeConstants.Specific,
                                                  AttributeConstants.Bludgeoning,
                                                  AttributeConstants.Melee,
                                                  AttributeConstants.Metal)]
        [TestCase(WeaponConstants.LuckBlade1, AttributeConstants.Slashing,
                                              AttributeConstants.Specific,
                                              AttributeConstants.NotBludgeoning,
                                              AttributeConstants.Melee,
                                              AttributeConstants.Metal)]
        [TestCase(WeaponConstants.MaceOfSmiting, AttributeConstants.Specific,
                                                 AttributeConstants.Bludgeoning,
                                                 AttributeConstants.Melee,
                                                 AttributeConstants.Metal)]
        [TestCase(WeaponConstants.LuckBlade2, AttributeConstants.Slashing,
                                              AttributeConstants.Specific,
                                              AttributeConstants.NotBludgeoning,
                                              AttributeConstants.Melee,
                                              AttributeConstants.Metal)]
        [TestCase(WeaponConstants.HolyAvenger, AttributeConstants.Slashing,
                                               AttributeConstants.Specific,
                                               AttributeConstants.NotBludgeoning,
                                               AttributeConstants.Melee,
                                               AttributeConstants.Metal)]
        [TestCase(WeaponConstants.LuckBlade3, AttributeConstants.Slashing,
                                              AttributeConstants.Specific,
                                              AttributeConstants.NotBludgeoning,
                                              AttributeConstants.Melee,
                                              AttributeConstants.Metal)]
        public override void Attributes(String name, params String[] attributes)
        {
            base.Attributes(name, attributes);
        }
    }
}