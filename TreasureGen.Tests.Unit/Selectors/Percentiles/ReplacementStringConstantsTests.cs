using NUnit.Framework;
using System.Linq;
using TreasureGen.Domain.Selectors.Percentiles;

namespace TreasureGen.Tests.Unit.Selectors.Percentiles
{
    [TestFixture]
    public class ReplacementStringConstantsTests
    {
        [TestCase(ReplacementStringConstants.DesignatedFoe, "DESIGNATEDFOE")]
        [TestCase(ReplacementStringConstants.Energy, "ENERGY")]
        [TestCase(ReplacementStringConstants.Gender, "GENDER")]
        [TestCase(ReplacementStringConstants.Height, "HEIGHT")]
        [TestCase(ReplacementStringConstants.KnowledgeCategory, "KNOWLEDGECATEGORY")]
        [TestCase(ReplacementStringConstants.PartialAlignment, "PARTIALALIGNMENT")]
        [TestCase(ReplacementStringConstants.FullAlignment, "FULLALIGNMENT")]
        public void Constant(string constant, string value)
        {
            Assert.That(constant, Is.EqualTo(value));
        }

        [Test]
        public void AllReplacementStrings()
        {
            var replacementStrings = ReplacementStringConstants.GetAll();

            Assert.That(replacementStrings, Contains.Item(ReplacementStringConstants.DesignatedFoe));
            Assert.That(replacementStrings, Contains.Item(ReplacementStringConstants.Energy));
            Assert.That(replacementStrings, Contains.Item(ReplacementStringConstants.Gender));
            Assert.That(replacementStrings, Contains.Item(ReplacementStringConstants.Height));
            Assert.That(replacementStrings, Contains.Item(ReplacementStringConstants.KnowledgeCategory));
            Assert.That(replacementStrings, Contains.Item(ReplacementStringConstants.PartialAlignment));
            Assert.That(replacementStrings, Contains.Item(ReplacementStringConstants.FullAlignment));
            Assert.That(replacementStrings.Count(), Is.EqualTo(7));
        }
    }
}