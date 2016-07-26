using System;
using TreasureGen.Items;
using TreasureGen.Domain.Tables;
using NUnit.Framework;

namespace TreasureGen.Tests.Integration.Tables.Items.Magical.Armor.Specific
{
    [TestFixture]
    public class SpecificShieldTraitsTests : CollectionsTests
    {
        protected override String tableName
        {
            get { return String.Format(TableNameConstants.Collections.Formattable.SpecificITEMTYPETraits, AttributeConstants.Shield); }
        }

        [TestCase(ArmorConstants.AbsorbingShield)]
        [TestCase(ArmorConstants.CastersShield)]
        [TestCase(ArmorConstants.Buckler, TraitConstants.Darkwood)]
        [TestCase(ArmorConstants.HeavySteelShield, TraitConstants.Mithral)]
        [TestCase(ArmorConstants.HeavyWoodenShield, TraitConstants.Darkwood)]
        [TestCase(ArmorConstants.LionsShield)]
        [TestCase(ArmorConstants.SpinedShield)]
        [TestCase(ArmorConstants.WingedShield)]
        public override void Collections(String name, params String[] attributes)
        {
            base.Collections(name, attributes);
        }
    }
}