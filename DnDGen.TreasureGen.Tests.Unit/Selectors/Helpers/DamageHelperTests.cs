using DnDGen.TreasureGen.Selectors.Helpers;
using DnDGen.TreasureGen.Tables;
using NUnit.Framework;

namespace DnDGen.TreasureGen.Tests.Unit.Selectors.Helpers
{
    [TestFixture]
    public class DamageHelperTests
    {
        private DamageHelper helper;

        [SetUp]
        public void Setup()
        {
            helper = new DamageHelper();
        }

        [Test]
        public void BuildDataIntoArray()
        {
            var data = helper.BuildData("my roll", "my damage type");
            Assert.That(data[DataIndexConstants.Weapon.DamageData.RollIndex], Is.EqualTo("my roll"));
            Assert.That(data[DataIndexConstants.Weapon.DamageData.TypeIndex], Is.EqualTo("my damage type"));
        }

        [Test]
        public void BuildDataIntoArray_NoDamageType()
        {
            var data = helper.BuildData("my roll", string.Empty);
            Assert.That(data[DataIndexConstants.Weapon.DamageData.RollIndex], Is.EqualTo("my roll"));
            Assert.That(data[DataIndexConstants.Weapon.DamageData.TypeIndex], Is.Empty);
        }

        [Test]
        public void BuildDataIntoString()
        {
            var data = new[] { "this", "is", "my", "data" };
            var dataString = helper.BuildEntry(data);
            Assert.That(dataString, Is.EqualTo("this#is#my#data"));
        }

        [Test]
        public void BuildDataIntoString_MultipleDamages()
        {
            var dataString = helper.BuildEntries("1d3", "slashing", "1d4", "acid");
            Assert.That(dataString, Is.EqualTo("1d3#slashing,1d4#acid"));
        }

        [Test]
        public void ParseEntry()
        {
            var data = helper.ParseEntry("this#is#my#data");
            Assert.That(data, Is.EqualTo(new[] { "this", "is", "my", "data" }));
        }

        [Test]
        public void ParseEntries_NoDamages()
        {
            var data = helper.ParseEntries(string.Empty);
            Assert.That(data, Is.Empty);
        }

        [Test]
        public void ParseEntries_Damage()
        {
            var data = helper.ParseEntries("roll#damage type");
            Assert.That(data, Is.EqualTo(new[]
            {
                new[] { "roll", "damage type" },
            }));
        }

        [Test]
        public void ParseEntries_MultipleDamages()
        {
            var data = helper.ParseEntries("roll#damage type,other roll#other damage type");
            Assert.That(data, Is.EqualTo(new[]
            {
                new[] { "roll", "damage type" },
                new[] { "other roll", "other damage type" },
            }));
        }

        [TestCase("0", "holy")]
        [TestCase("1d4", "")]
        [TestCase("1d6", "emotional")]
        public void BuildKey_FromData(string roll, string type)
        {
            var data = helper.ParseEntry($"{roll}#{type}");
            var key = helper.BuildKey("creature", data);
            Assert.That(key, Is.EqualTo($"creature{roll}{type}"));
        }

        [TestCase("0", "holy")]
        [TestCase("1d4", "")]
        [TestCase("1d6", "emotional")]
        public void BuildKeyFromSections(string roll, string type)
        {
            var key = helper.BuildKeyFromSections("creature", roll, type);
            Assert.That(key, Is.EqualTo($"creature{roll}{type}"));
        }

        [TestCase(0, false)]
        [TestCase(1, false)]
        [TestCase(2, true)]
        [TestCase(3, false)]
        [TestCase(4, false)]
        [TestCase(5, false)]
        [TestCase(6, false)]
        [TestCase(7, false)]
        [TestCase(8, false)]
        [TestCase(9, false)]
        [TestCase(10, false)]
        [TestCase(11, false)]
        [TestCase(12, false)]
        [TestCase(13, false)]
        [TestCase(14, false)]
        [TestCase(15, false)]
        [TestCase(16, false)]
        [TestCase(17, false)]
        [TestCase(18, false)]
        [TestCase(19, false)]
        [TestCase(20, false)]
        public void ValidateEntry_IsValid(int length, bool isValid)
        {
            var data = new string[length];
            var entry = helper.BuildEntry(data);
            var valid = helper.ValidateEntry(entry);
            Assert.That(valid, Is.EqualTo(isValid));
        }
    }
}
