﻿using System;
using EquipmentGen.Common.Items;
using EquipmentGen.Tables.Interfaces;
using NUnit.Framework;

namespace EquipmentGen.Tests.Integration.Tables.Items.Magical.WondrousItems
{
    [TestFixture]
    public class MinorWondrousItemsTests : TypeAndAmountPercentileTests
    {
        protected override String tableName
        {
            get { return String.Format(TableNameConstants.Percentiles.Formattable.POWERITEMTYPEs, PowerConstants.Minor, ItemTypeConstants.WondrousItem); }
        }

        [Test]
        public override void TableIsComplete()
        {
            AssertTableIsComplete();
        }

        [TestCase("Quaal's anchor feather token", 0, 1)]
        [TestCase("Universal solvent", 0, 2)]
        [TestCase("Elixer of love", 0, 3)]
        [TestCase("Unguent of timelessness", 0, 4)]
        [TestCase("Quaal's fan feather token", 0, 5)]
        [TestCase("Dust of tracelessness", 0, 6)]
        [TestCase("Elixer of hiding", 0, 7)]
        [TestCase("Elixer of sneaking", 0, 8)]
        [TestCase("Elixer of swimming", 0, 9)]
        [TestCase("Elixer of vision", 0, 10)]
        [TestCase("Silversheen", 0, 11)]
        [TestCase("Quaal's bird feather token", 0, 12)]
        [TestCase("Quaal's tree feather token", 0, 13)]
        [TestCase("Quaal's swan boat feather token", 0, 14)]
        [TestCase("Elixer of truth", 0, 15)]
        [TestCase("Quaal's whip feather token", 0, 16)]
        [TestCase("Dust of dryness", 0, 17)]
        [TestCase("Gray bag of tricks", 0, 18)]
        [TestCase("Hand of the mage", 0, 19)]
        [TestCase("Bracers of armor", 1, 20)]
        [TestCase("Cloak of resistance", 1, 21)]
        [TestCase("1st-level spell pearl of power", 0, 22)]
        [TestCase("Phylactery of faithfulness", 0, 23)]
        [TestCase("Salve of slipperiness", 0, 24)]
        [TestCase("Elixer of fire breath", 0, 25)]
        [TestCase("Pipes of the sewers", 0, 26)]
        [TestCase("Dust of illusion", 0, 27)]
        [TestCase("Goggles of minute seeing", 0, 28)]
        [TestCase("Brooch of shielding", 0, 29)]
        [TestCase("Necklace of fireballs type I", 0, 30)]
        [TestCase("Dust of appearance", 0, 31)]
        [TestCase("Hat of disguise", 0, 32)]
        [TestCase("Pipes of sounding", 0, 33)]
        [TestCase("Quiver of Ehlonna", 0, 34)]
        [TestCase("Amulet of natural armor", 1, 35)]
        [TestCase("Heward's handy haversack", 0, 36)]
        [TestCase("Horn of fog", 0, 37)]
        [TestCase("Elemental gem", 0, 38)]
        [TestCase("Robe of bones", 0, 39)]
        [TestCase("Sovereign glue", 0, 40)]
        [TestCase("Bag of holding type I", 0, 41)]
        [TestCase("Boots of elvenkind", 0, 42)]
        [TestCase("Boots of the winterlands", 0, 43)]
        [TestCase("Candle of truth", 0, 44)]
        [TestCase("Cloak of elvenkind", 0, 45)]
        [TestCase("Eyes of the eagle", 0, 46)]
        [TestCase("Golembane scarab", 0, 47)]
        [TestCase("Necklace of fireballs type II", 0, 48)]
        [TestCase("Stone of alarm", 0, 49)]
        [TestCase("Rust bag of tricks", 0, 50)]
        [TestCase("Bead of force", 0, 51)]
        [TestCase("Chime of opening", 0, 52)]
        [TestCase("Horseshoes of speed", 0, 53)]
        [TestCase("Rope of climbing", 0, 54)]
        [TestCase("Dust of disappearance", 0, 55)]
        [TestCase("Lens of detection", 0, 56)]
        [TestCase("Druid's vestments", 0, 57)]
        [TestCase("Silver raven figurine of wondrous power", 0, 58)]
        [TestCase("Amulet of health", 2, 59)]
        [TestCase("Bracers of armor", 2, 60)]
        [TestCase("Cloak of charisma", 2, 61)]
        [TestCase("Cloak of resistance", 2, 62)]
        [TestCase("Gauntlets of ogre power", 0, 63)]
        [TestCase("Gloves of arrow snaring", 0, 64)]
        [TestCase("Gloves of dexterity", 2, 65)]
        [TestCase("Headband of intellect", 2, 66)]
        [TestCase("Clear spindle ioun stone", 0, 67)]
        [TestCase("Keoghtom's ointment", 0, 68)]
        [TestCase("Nolzur's marvelous pigments", 0, 69)]
        [TestCase("2nd-level spell pearl of power", 0, 70)]
        [TestCase("Periapt of wisdom", 2, 71)]
        [TestCase("Stone salve", 0, 72)]
        [TestCase("Necklace of fireballs type III", 0, 73)]
        [TestCase("Circlet of persuasion", 0, 74)]
        [TestCase("Slippers of spider climbing", 0, 75)]
        [TestCase("Incense of meditation", 0, 76)]
        [TestCase("Bag of holding type II", 0, 77)]
        [TestCase("Lesser bracers of archery", 0, 78)]
        [TestCase("Dusty rose prism ioun stone", 0, 79)]
        [TestCase("Helm of comprehend languages and read magic", 0, 80)]
        [TestCase("Vest of escape", 0, 81)]
        [TestCase("Eversmoking bottle", 0, 82)]
        [TestCase("Murlynd's spoon", 0, 83)]
        [TestCase("Necklace of fireballs type IV", 0, 84)]
        [TestCase("Boots of striding and springing", 0, 85)]
        [TestCase("Wind fan", 0, 86)]
        [TestCase("Amulet of mighty fists", 1, 87)]
        [TestCase("Horseshoes of a zephyr", 0, 88)]
        [TestCase("Pipes of haunting", 0, 89)]
        [TestCase("Necklace of fireballs type V", 0, 90)]
        [TestCase("Gloves of swimming and climbing", 0, 91)]
        [TestCase("Tan bag of tricks", 0, 92)]
        [TestCase("Minor circlet of blasting", 0, 93)]
        [TestCase("Horn of goodness/evil", 0, 94)]
        [TestCase("Robe of useful items", 0, 95)]
        [TestCase("Folding boat", 0, 96)]
        [TestCase("Cloak of the manta ray", 0, 97)]
        [TestCase("Bottle of air", 0, 98)]
        [TestCase("Bag of holding type III", 0, 99)]
        [TestCase("Periapt of health", 0, 100)]
        public override void TypeAndAmountPercentile(String type, Int32 amount, Int32 roll)
        {
            base.TypeAndAmountPercentile(type, amount, roll);
        }
    }
}