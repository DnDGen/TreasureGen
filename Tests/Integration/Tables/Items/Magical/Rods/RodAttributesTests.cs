using System;
using EquipmentGen.Common.Items;
using NUnit.Framework;

namespace EquipmentGen.Tests.Integration.Tables.Items.Magical.Rods
{
    [TestFixture]
    public class RodAttributesTests : AttributesTests
    {
        protected override String tableName
        {
            get { return "RodAttributes"; }
        }

        [TestCase("Rod of lesser metamagic: Enlarge")]
        [TestCase("Rod of lesser metamagic: Extend")]
        [TestCase("Rod of lesser metamagic: Silent")]
        [TestCase("Rod of lesser metamagic: Empower")]
        [TestCase("Rod of lesser metamagic: Maximize")]
        [TestCase("Rod of lesser metamagic: Quicken")]
        [TestCase("Rod of metamagic: Enlarge")]
        [TestCase("Rod of metamagic: Extend")]
        [TestCase("Rod of metamagic: Silent")]
        [TestCase("Rod of metamagic: Empower")]
        [TestCase("Rod of metamagic: Maximize")]
        [TestCase("Rod of metamagic: Quicken")]
        [TestCase("Rod of greater metamagic: Enlarge")]
        [TestCase("Rod of greater metamagic: Extend")]
        [TestCase("Rod of greater metamagic: Silent")]
        [TestCase("Rod of greater metamagic: Empower")]
        [TestCase("Rod of greater metamagic: Maximize")]
        [TestCase("Rod of greater metamagic: Quicken")]
        [TestCase("Immovable rod")]
        [TestCase("Rod of metal and mineral detection")]
        [TestCase("Rod of cancellation")]
        [TestCase("Rod of wonder")]
        [TestCase("Rod of the python", AttributeConstants.Bludgeoning,
                                       AttributeConstants.DoubleWeapon,
                                       AttributeConstants.Common,
                                       AttributeConstants.Melee,
                                       AttributeConstants.Wood,
                                       AttributeConstants.Specific)]
        [TestCase("Rod of the viper", AttributeConstants.Bludgeoning,
                                      AttributeConstants.Common,
                                      AttributeConstants.Melee,
                                      AttributeConstants.Metal,
                                      AttributeConstants.Specific)]
        [TestCase("Rod of flame extinguishing")]
        [TestCase("Rod of enemy detection")]
        [TestCase("Rod of splendor")]
        [TestCase("Rod of withering", AttributeConstants.Bludgeoning,
                                      AttributeConstants.Common,
                                      AttributeConstants.Melee,
                                      AttributeConstants.Metal,
                                      AttributeConstants.Specific)]
        [TestCase("Rod of thunder and lightning", AttributeConstants.Bludgeoning,
                                                  AttributeConstants.Common,
                                                  AttributeConstants.Melee,
                                                  AttributeConstants.Metal,
                                                  AttributeConstants.Specific)]
        [TestCase("Rod of negation")]
        [TestCase("Rod of flailing", AttributeConstants.Bludgeoning,
                                     AttributeConstants.DoubleWeapon,
                                     AttributeConstants.Melee,
                                     AttributeConstants.Metal,
                                     AttributeConstants.Specific,
                                     AttributeConstants.Uncommon)]
        [TestCase("Rod of absorption", AttributeConstants.Charged,
                                       AttributeConstants.OneTimeUse)]
        [TestCase("Rod of rulership", AttributeConstants.Charged,
                                      AttributeConstants.OneTimeUse)]
        [TestCase("Rod of security")]
        [TestCase("Rod of lordly might", AttributeConstants.Bludgeoning,
                                         AttributeConstants.Common,
                                         AttributeConstants.Melee,
                                         AttributeConstants.Metal,
                                         AttributeConstants.Specific)]
        [TestCase("Rod of alertness", AttributeConstants.Bludgeoning,
                                      AttributeConstants.Common,
                                      AttributeConstants.Melee,
                                      AttributeConstants.Metal,
                                      AttributeConstants.Specific)]
        public override void Attributes(String name, params String[] attributes)
        {
            base.Attributes(name, attributes);
        }
    }
}