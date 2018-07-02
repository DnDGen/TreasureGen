using NUnit.Framework;
using TreasureGen.Tables;
using TreasureGen.Items;

namespace TreasureGen.Tests.Integration.Tables.Items.Magical.Armor.Specific
{
    [TestFixture]
    public class SpecificShieldSpecialAbilitiesTests : CollectionsTests
    {
        protected override string tableName
        {
            get { return string.Format(TableNameConstants.Collections.Formattable.SpecificITEMTYPESpecialAbilities, AttributeConstants.Shield); }
        }

        [TestCase(ArmorConstants.AbsorbingShield)]
        [TestCase(ArmorConstants.CastersShield)]
        [TestCase(ArmorConstants.Buckler)]
        [TestCase(ArmorConstants.HeavySteelShield)]
        [TestCase(ArmorConstants.HeavyWoodenShield)]
        [TestCase(ArmorConstants.LionsShield)]
        [TestCase(ArmorConstants.SpinedShield)]
        [TestCase(ArmorConstants.WingedShield)]
        public override void Collections(string name, params string[] attributes)
        {
            base.Collections(name, attributes);
        }
    }
}