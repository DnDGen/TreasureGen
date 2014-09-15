using System;
using NUnit.Framework;

namespace EquipmentGen.Tests.Integration.Tables.Items.Magical.Scrolls.Arcane
{
    [TestFixture]
    public class Level1ArcaneSpellsTests : PercentileTests
    {
        protected override String tableName
        {
            get { return "Level1ArcaneSpells"; }
        }

        [Test]
        public override void TableIsComplete()
        {
            AssertTableIsComplete();
        }

        [TestCase("Alarm", 1, 3)]
        [TestCase("Animate rope", 4, 5)]
        [TestCase("Burning hands", 6, 7)]
        [TestCase("Cause fear", 8, 9)]
        [TestCase("Charm person", 10, 12)]
        [TestCase("Chill touch", 13, 14)]
        [TestCase("Color spray", 15, 16)]
        [TestCase("Comprehend languages", 17, 19)]
        [TestCase("Detect secret doors", 22, 24)]
        [TestCase("Detect undead", 25, 26)]
        [TestCase("Disguise self", 27, 29)]
        [TestCase("Endure elements", 30, 32)]
        [TestCase("Enlarge person", 33, 35)]
        [TestCase("Erase", 36, 37)]
        [TestCase("Expeditious retreat", 38, 40)]
        [TestCase("Grease", 42, 43)]
        [TestCase("Hold portal", 44, 45)]
        [TestCase("Hypnotism", 46, 47)]
        [TestCase("Identify", 48, 49)]
        [TestCase("Jump", 50, 51)]
        [TestCase("Mage armor", 52, 54)]
        [TestCase("Magic missile", 55, 56)]
        [TestCase("Magic weapon", 57, 59)]
        [TestCase("Mount", 60, 62)]
        [TestCase("Nystul's magic aura", 63, 64)]
        [TestCase("Obscuring mist", 65, 66)]
        [TestCase("Protection from chaos/evil/good/law", 67, 74)]
        [TestCase("Ray of enfeeblement", 75, 76)]
        [TestCase("Reduce person", 77, 78)]
        [TestCase("Remove fear", 79, 80)]
        [TestCase("Shield", 81, 82)]
        [TestCase("Shocking grasp", 83, 84)]
        [TestCase("Silent image", 85, 86)]
        [TestCase("Sleep", 87, 88)]
        [TestCase("Summon monster I", 89, 90)]
        [TestCase("Tenser's floating disc", 91, 93)]
        [TestCase("True strike", 94, 95)]
        [TestCase("Unseen servant", 97, 98)]
        [TestCase("Ventriloquism", 99, 100)]
        public override void Percentile(String content, Int32 lower, Int32 upper)
        {
            base.Percentile(content, lower, upper);
        }

        [TestCase("Lesser confusion", 20)]
        [TestCase("Cure light wounds", 21)]
        [TestCase("Feather fall", 41)]
        [TestCase("Undetectable alignment", 96)]
        public override void Percentile(String content, Int32 roll)
        {
            base.Percentile(content, roll);
        }
    }
}