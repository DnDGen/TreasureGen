using DnDGen.TreasureGen.Items;
using NUnit.Framework;

namespace DnDGen.TreasureGen.Tests.Unit.Generators.Items
{
    [TestFixture]
    public class DamageTests
    {
        private Damage damage;

        [SetUp]
        public void Setup()
        {
            damage = new Damage();
        }

        [Test]
        public void DamageInitialized()
        {
            Assert.That(damage.Roll, Is.Empty);
            Assert.That(damage.Type, Is.Empty);
            Assert.That(damage.Description, Is.Empty);
            Assert.That(damage.Condition, Is.Empty);
            Assert.That(damage.IsConditional, Is.False);
        }

        [TestCase(null, false)]
        [TestCase("", false)]
        [TestCase("a", true)]
        [TestCase("my condition", true)]
        public void IsConditional(string condition, bool conditional)
        {
            damage.Condition = condition;
            Assert.That(damage.IsConditional, Is.EqualTo(conditional));
        }

        [Test]
        public void Description_WithoutType()
        {
            damage.Roll = "9266d90210";
            damage.Type = string.Empty;

            Assert.That(damage.Description, Is.EqualTo("9266d90210"));
        }

        [Test]
        public void Description_WithType()
        {
            damage.Roll = "9266d90210";
            damage.Type = "emotional";

            Assert.That(damage.Description, Is.EqualTo("9266d90210 emotional"));
        }

        [Test]
        public void Description_WithoutType_WithCondition()
        {
            damage.Roll = "9266d90210";
            damage.Type = string.Empty;
            damage.Condition = "my condition";

            Assert.That(damage.Description, Is.EqualTo("9266d90210 (my condition)"));
        }

        [Test]
        public void Description_WithType_WithCondition()
        {
            damage.Roll = "9266d90210";
            damage.Type = "emotional";
            damage.Condition = "my condition";

            Assert.That(damage.Description, Is.EqualTo("9266d90210 emotional (my condition)"));
        }

        [Test]
        public void Clone_IsDistinctObject()
        {
            damage.Roll = "9266d90210";
            damage.Type = "emotional";
            damage.Condition = "my condition";

            var clone = damage.Clone();
            Assert.That(clone, Is.Not.EqualTo(damage));
            Assert.That(clone.Roll, Is.EqualTo("9266d90210"));
            Assert.That(clone.Type, Is.EqualTo("emotional"));
            Assert.That(clone.Condition, Is.EqualTo("my condition"));
        }
    }
}
