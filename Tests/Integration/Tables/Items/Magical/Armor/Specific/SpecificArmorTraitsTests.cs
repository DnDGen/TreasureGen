using System;
using TreasureGen.Common.Items;
using TreasureGen.Tables;
using NUnit.Framework;

namespace TreasureGen.Tests.Integration.Tables.Items.Magical.Armor.Specific
{
    [TestFixture]
    public class SpecificArmorTraitsTests : AttributesTests
    {
        protected override String tableName
        {
            get { return String.Format(TableNameConstants.Attributes.Formattable.SpecificITEMTYPETraits, ItemTypeConstants.Armor); }
        }

        [TestCase(ArmorConstants.BandedMailOfLuck)]
        [TestCase(ArmorConstants.BreastplateOfCommand)]
        [TestCase(ArmorConstants.CelestialArmor)]
        [TestCase(ArmorConstants.DemonArmor)]
        [TestCase(ArmorConstants.DwarvenPlate, TraitConstants.Adamantine)]
        [TestCase(ArmorConstants.ElvenChain, TraitConstants.Mithral)]
        [TestCase(ArmorConstants.FullPlateOfSpeed, TraitConstants.Mithral)]
        [TestCase(ArmorConstants.PlateArmorOfTheDeep)]
        [TestCase(ArmorConstants.RhinoHide)]
        [TestCase(ArmorConstants.ChainShirt, TraitConstants.Mithral)]
        [TestCase(ArmorConstants.FullPlate, TraitConstants.Dragonhide)]
        [TestCase(ArmorConstants.Breastplate, TraitConstants.Adamantine)]
        public override void Attributes(String name, params String[] attributes)
        {
            base.Attributes(name, attributes);
        }
    }
}