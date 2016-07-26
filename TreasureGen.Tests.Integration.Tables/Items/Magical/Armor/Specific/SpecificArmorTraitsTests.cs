using System;
using TreasureGen.Items;
using TreasureGen.Domain.Tables;
using NUnit.Framework;

namespace TreasureGen.Tests.Integration.Tables.Items.Magical.Armor.Specific
{
    [TestFixture]
    public class SpecificArmorTraitsTests : CollectionsTests
    {
        protected override String tableName
        {
            get { return String.Format(TableNameConstants.Collections.Formattable.SpecificITEMTYPETraits, ItemTypeConstants.Armor); }
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
        public override void Collections(String name, params String[] attributes)
        {
            base.Collections(name, attributes);
        }
    }
}