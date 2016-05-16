using NUnit.Framework;
using System.Linq;
using TreasureGen.Items.Magical;

namespace TreasureGen.Tests.Unit.Generators.Items.Magical
{
    [TestFixture]
    public class AlignmentConstantsTests
    {
        [TestCase(AlignmentConstants.Chaotic, "Chaotic")]
        [TestCase(AlignmentConstants.Evil, "Evil")]
        [TestCase(AlignmentConstants.Good, "Good")]
        [TestCase(AlignmentConstants.Lawful, "Lawful")]
        [TestCase(AlignmentConstants.Neutral, "Neutral")]
        public void Constant(string constant, string value)
        {
            Assert.That(constant, Is.EqualTo(value));
        }

        [Test]
        public void LawfulGoodConstant()
        {
            Assert.That(AlignmentConstants.LawfulGood, Is.EqualTo("Lawful Good"));
        }

        [Test]
        public void LawfulNeutralConstant()
        {
            Assert.That(AlignmentConstants.LawfulNeutral, Is.EqualTo("Lawful Neutral"));
        }

        [Test]
        public void LawfulEvilConstant()
        {
            Assert.That(AlignmentConstants.LawfulEvil, Is.EqualTo("Lawful Evil"));
        }

        [Test]
        public void NeutralGoodConstant()
        {
            Assert.That(AlignmentConstants.NeutralGood, Is.EqualTo("Neutral Good"));
        }

        [Test]
        public void TrueNeutralConstant()
        {
            Assert.That(AlignmentConstants.TrueNeutral, Is.EqualTo("True Neutral"));
        }

        [Test]
        public void NeutralEvilConstant()
        {
            Assert.That(AlignmentConstants.NeutralEvil, Is.EqualTo("Neutral Evil"));
        }

        [Test]
        public void ChaoticGoodConstant()
        {
            Assert.That(AlignmentConstants.ChaoticGood, Is.EqualTo("Chaotic Good"));
        }

        [Test]
        public void ChaoticNeutralConstant()
        {
            Assert.That(AlignmentConstants.ChaoticNeutral, Is.EqualTo("Chaotic Neutral"));
        }

        [Test]
        public void ChaoticEvilConstant()
        {
            Assert.That(AlignmentConstants.ChaoticEvil, Is.EqualTo("Chaotic Evil"));
        }

        [Test]
        public void AllAlignments()
        {
            var alignments = AlignmentConstants.GetAllAlignments();

            Assert.That(alignments, Contains.Item(AlignmentConstants.ChaoticEvil));
            Assert.That(alignments, Contains.Item(AlignmentConstants.ChaoticGood));
            Assert.That(alignments, Contains.Item(AlignmentConstants.ChaoticNeutral));
            Assert.That(alignments, Contains.Item(AlignmentConstants.LawfulEvil));
            Assert.That(alignments, Contains.Item(AlignmentConstants.LawfulGood));
            Assert.That(alignments, Contains.Item(AlignmentConstants.LawfulNeutral));
            Assert.That(alignments, Contains.Item(AlignmentConstants.NeutralEvil));
            Assert.That(alignments, Contains.Item(AlignmentConstants.NeutralGood));
            Assert.That(alignments, Contains.Item(AlignmentConstants.TrueNeutral));
            Assert.That(alignments.Count(), Is.EqualTo(9));
        }

        [Test]
        public void AllPartialAlignments()
        {
            var partialAlignments = AlignmentConstants.GetAllPartialAlignments();

            Assert.That(partialAlignments, Contains.Item(AlignmentConstants.Chaotic));
            Assert.That(partialAlignments, Contains.Item(AlignmentConstants.Evil));
            Assert.That(partialAlignments, Contains.Item(AlignmentConstants.Good));
            Assert.That(partialAlignments, Contains.Item(AlignmentConstants.Lawful));
            Assert.That(partialAlignments, Contains.Item(AlignmentConstants.Neutral));
            Assert.That(partialAlignments.Count(), Is.EqualTo(5));
        }
    }
}