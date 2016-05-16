using NUnit.Framework;
using System;
using TreasureGen.Domain.Tables;
using TreasureGen.Items;
using TreasureGen.Items.Magical;

namespace TreasureGen.Tests.Integration.Tables.Items.Magical.Rods
{
    [TestFixture]
    public class RodAttributesTests : AttributesTests
    {
        protected override string tableName
        {
            get { return string.Format(TableNameConstants.Attributes.Formattable.ITEMTYPEAttributes, ItemTypeConstants.Rod); }
        }

        [TestCase(RodConstants.Metamagic_Enlarge_Lesser)]
        [TestCase(RodConstants.Metamagic_Extend_Lesser)]
        [TestCase(RodConstants.Metamagic_Silent_Lesser)]
        [TestCase(RodConstants.Metamagic_Empower_Lesser)]
        [TestCase(RodConstants.Metamagic_Maximize_Lesser)]
        [TestCase(RodConstants.Metamagic_Quicken_Lesser)]
        [TestCase(RodConstants.Metamagic_Enlarge)]
        [TestCase(RodConstants.Metamagic_Extend)]
        [TestCase(RodConstants.Metamagic_Silent)]
        [TestCase(RodConstants.Metamagic_Empower)]
        [TestCase(RodConstants.Metamagic_Maximize)]
        [TestCase(RodConstants.Metamagic_Quicken)]
        [TestCase(RodConstants.Metamagic_Enlarge_Greater)]
        [TestCase(RodConstants.Metamagic_Extend_Greater)]
        [TestCase(RodConstants.Metamagic_Silent_Greater)]
        [TestCase(RodConstants.Metamagic_Empower_Greater)]
        [TestCase(RodConstants.Metamagic_Maximize_Greater)]
        [TestCase(RodConstants.Metamagic_Quicken_Greater)]
        [TestCase(RodConstants.ImmovableRod)]
        [TestCase(RodConstants.MetalAndMineralDetection)]
        [TestCase(RodConstants.Cancellation)]
        [TestCase(RodConstants.Wonder)]
        [TestCase(RodConstants.Python, AttributeConstants.Bludgeoning,
                                       AttributeConstants.DoubleWeapon,
                                       AttributeConstants.Common,
                                       AttributeConstants.Melee,
                                       AttributeConstants.Wood,
                                       AttributeConstants.Specific)]
        [TestCase(RodConstants.Viper, AttributeConstants.Bludgeoning,
                                      AttributeConstants.Common,
                                      AttributeConstants.Melee,
                                      AttributeConstants.Metal,
                                      AttributeConstants.Specific)]
        [TestCase(RodConstants.FlameExtinguishing)]
        [TestCase(RodConstants.EnemyDetection)]
        [TestCase(RodConstants.Splendor)]
        [TestCase(RodConstants.Withering, AttributeConstants.Bludgeoning,
                                      AttributeConstants.Common,
                                      AttributeConstants.Melee,
                                      AttributeConstants.Metal,
                                      AttributeConstants.Specific)]
        [TestCase(RodConstants.ThunderAndLightning, AttributeConstants.Bludgeoning,
                                                  AttributeConstants.Common,
                                                  AttributeConstants.Melee,
                                                  AttributeConstants.Metal,
                                                  AttributeConstants.Specific)]
        [TestCase(RodConstants.Negation)]
        [TestCase(RodConstants.Flailing, AttributeConstants.Bludgeoning,
                                     AttributeConstants.DoubleWeapon,
                                     AttributeConstants.Melee,
                                     AttributeConstants.Metal,
                                     AttributeConstants.Specific,
                                     AttributeConstants.Uncommon)]
        [TestCase(RodConstants.Absorption, AttributeConstants.Charged,
                                       AttributeConstants.OneTimeUse)]
        [TestCase(RodConstants.Rulership, AttributeConstants.Charged,
                                      AttributeConstants.OneTimeUse)]
        [TestCase(RodConstants.Security)]
        [TestCase(RodConstants.LordlyMight, AttributeConstants.Bludgeoning,
                                         AttributeConstants.Common,
                                         AttributeConstants.Melee,
                                         AttributeConstants.Metal,
                                         AttributeConstants.Specific)]
        [TestCase(RodConstants.Alertness, AttributeConstants.Bludgeoning,
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