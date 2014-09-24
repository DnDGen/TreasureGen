﻿using System;
using EquipmentGen.Common.Items;
using EquipmentGen.Tables.Interfaces;
using NUnit.Framework;

namespace EquipmentGen.Tests.Integration.Tables.Items.Magical.WondrousItems
{
    [TestFixture]
    public class MajorWondrousItemsTests : TypeAndAmountPercentileTests
    {
        protected override String tableName
        {
            get { return String.Format(TableNameConstants.Percentiles.Formattable.POWERITEMTYPEs, PowerConstants.Major, ItemTypeConstants.WondrousItem); }
        }

        [Test]
        public override void TableIsComplete()
        {
            AssertTableIsComplete();
        }

        [TestCase("Dimensional shackles", 0, 1)]
        [TestCase("Obsidian steed figurine of wondrous power", 0, 2)]
        [TestCase("Drums of panic", 0, 3)]
        [TestCase("Orange ioun stone", 0, 4)]
        [TestCase("Pale green prism ioun stone", 0, 5)]
        [TestCase("Lantern of revealing", 0, 6)]
        [TestCase("Robe of blending", 0, 7)]
        [TestCase("Amulet of natural armor", 4, 8)]
        [TestCase("Amulet of proof against detection and location", 0, 9)]
        [TestCase("5 ft. by 10 ft. carpet of flying", 0, 10)]
        [TestCase("Iron golem manual", 0, 11)]
        [TestCase("Amulet of health", 6, 12)]
        [TestCase("Belt of giant strength", 6, 13)]
        [TestCase("Bracers of armor", 6, 14)]
        [TestCase("Cloak of charisma", 6, 15)]
        [TestCase("Gloves of dexterity", 6, 16)]
        [TestCase("Headband of intellect", 6, 17)]
        [TestCase("Vibrant purple prism ioun stone", 0, 18)]
        [TestCase("6th-level spell pearl of power", 0, 19)]
        [TestCase("Periapt of wisdom", 6, 20)]
        [TestCase("Scarab of protection", 0, 21)]
        [TestCase("Lavender and green ellipsoid ioun stone", 0, 22)]
        [TestCase("Ring gates", 0, 23)]
        [TestCase("Crystal ball", 0, 24)]
        [TestCase("Greater stone golem manual", 0, 25)]
        [TestCase("Orb of storms", 0, 26)]
        [TestCase("Boots of teleportation", 0, 27)]
        [TestCase("Bracers of armor", 7, 28)]
        [TestCase("7th-level spell pearl of power", 0, 29)]
        [TestCase("Amulet of natural armor", 5, 30)]
        [TestCase("Major cloak of displacement", 0, 31)]
        [TestCase("Crystal ball with see invisibility", 0, 32)]
        [TestCase("Horn of Valhalla", 0, 33)]
        [TestCase("Crystal ball with detect thoughts", 0, 34)]
        [TestCase("6 ft. by 9 ft. carpet of flying", 0, 35)]
        [TestCase("Amulet of mighty fists", 3, 36)]
        [TestCase("Wings of flying", 0, 37)]
        [TestCase("Cloak of etherealness", 0, 38)]
        [TestCase("Daern's instant fortress", 0, 39)]
        [TestCase("Manual of bodily health", 2, 40)]
        [TestCase("Manual of gainful exercise", 2, 41)]
        [TestCase("Manual of quickness in action", 2, 42)]
        [TestCase("Tome of clear thought", 2, 43)]
        [TestCase("Tome of leadership and influence", 2, 44)]
        [TestCase("Tome of understanding", 2, 45)]
        [TestCase("Eyes of charming", 0, 46)]
        [TestCase("Robe of stars", 0, 47)]
        [TestCase("10 ft. by 10 ft. carpet of flying", 0, 48)]
        [TestCase("Darkskull", 0, 49)]
        [TestCase("Cube of force", 0, 50)]
        [TestCase("Bracers of armor", 8, 51)]
        [TestCase("8th-level spell pearl of power", 0, 52)]
        [TestCase("Crystal ball with telepathy", 0, 53)]
        [TestCase("Greater horn of blasting", 0, 54)]
        [TestCase("Two spells pearl of power", 0, 55)]
        [TestCase("Helm of teleportation", 0, 56)]
        [TestCase("Gem of seeing", 0, 57)]
        [TestCase("Robe of the archmagi", 0, 58)]
        [TestCase("Mantle of faith", 0, 59)]
        [TestCase("Crystal ball with true seeing", 0, 60)]
        [TestCase("9th-level spell pearl of power", 0, 61)]
        [TestCase("Well of many worlds", 0, 62)]
        [TestCase("Manual of bodily health", 3, 63)]
        [TestCase("Manual of gainful exercise", 3, 64)]
        [TestCase("Manual of quickness in action", 3, 65)]
        [TestCase("Tome of clear thought", 3, 66)]
        [TestCase("Tome of leadership and influence", 3, 67)]
        [TestCase("Tome of understanding", 3, 68)]
        [TestCase("Apparatus of Kwalish", 0, 69)]
        [TestCase("Mantle of spell resistance", 0, 70)]
        [TestCase("Mirror of opposition", 0, 71)]
        [TestCase("Greater strand of prayer beads", 0, 72)]
        [TestCase("Amulet of mighty fists", 4, 73)]
        [TestCase("Eyes of petrification", 0, 74)]
        [TestCase("Bowl of commanding water elementals", 0, 75)]
        [TestCase("Brazier of commanding fire elementals", 0, 76)]
        [TestCase("Censer of controlling air elementals", 0, 77)]
        [TestCase("Stone of controlling earth elementals", 0, 78)]
        [TestCase("Manual of bodily health", 4, 79)]
        [TestCase("Manual of gainful exercise", 4, 80)]
        [TestCase("Manual of quickness in action", 4, 81)]
        [TestCase("Tome of clear thought", 4, 82)]
        [TestCase("Tome of leadership and influence", 4, 83)]
        [TestCase("Tome of understanding", 4, 84)]
        [TestCase("Amulet of the planes", 0, 85)]
        [TestCase("Robe of eyes", 0, 86)]
        [TestCase("Helm of brilliance", 0, 87)]
        [TestCase("Manual of bodily health", 5, 88)]
        [TestCase("Manual of gainful exercise", 5, 89)]
        [TestCase("Manual of quickness in action", 5, 90)]
        [TestCase("Tome of clear thought", 5, 91)]
        [TestCase("Tome of leadership and influence", 5, 92)]
        [TestCase("Tome of understanding", 5, 93)]
        [TestCase("Efreeti bottle", 0, 94)]
        [TestCase("Amulet of mighty fists", 5, 95)]
        [TestCase("Chaos diamond", 0, 96)]
        [TestCase("Cubic gate", 0, 97)]
        [TestCase("Iron flask", 0, 98)]
        [TestCase("Mirror of mental prowess", 0, 99)]
        [TestCase("Mirror of life trapping", 0, 100)]
        public override void TypeAndAmountPercentile(String type, Int32 amount, Int32 roll)
        {
            base.TypeAndAmountPercentile(type, amount, roll);
        }
    }
}