using NUnit.Framework;
using TreasureGen.Domain.Tables;
using TreasureGen.Items;

namespace TreasureGen.Tests.Integration.Tables.Items.Magical.Armor.Specific
{
    [TestFixture]
    public class SpecificArmorSpecialAbilitiesTests : CollectionsTests
    {
        protected override string tableName
        {
            get { return string.Format(TableNameConstants.Collections.Formattable.SpecificITEMTYPESpecialAbilities, ItemTypeConstants.Armor); }
        }

        [TestCase(ArmorConstants.BandedMailOfLuck)]
        [TestCase(ArmorConstants.BreastplateOfCommand)]
        [TestCase(ArmorConstants.CelestialArmor)]
        [TestCase(ArmorConstants.DemonArmor)]
        [TestCase(ArmorConstants.DwarvenPlate)]
        [TestCase(ArmorConstants.ElvenChain)]
        [TestCase(ArmorConstants.FullPlateOfSpeed)]
        [TestCase(ArmorConstants.PlateArmorOfTheDeep)]
        [TestCase(ArmorConstants.RhinoHide)]
        [TestCase(ArmorConstants.ChainShirt)]
        [TestCase(ArmorConstants.FullPlate)]
        [TestCase(ArmorConstants.Breastplate)]
        public override void Collections(string name, params string[] attributes)
        {
            base.Collections(name, attributes);
        }
    }
}