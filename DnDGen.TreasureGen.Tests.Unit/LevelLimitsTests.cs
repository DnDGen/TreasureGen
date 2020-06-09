using NUnit.Framework;

namespace DnDGen.TreasureGen.Tests.Unit
{
    [TestFixture]
    public class LevelLimitsTests
    {
        [TestCase(LevelLimits.Minimum, 1)]
        [TestCase(LevelLimits.Maximum, 100)]
        public void LevelLimit(int limit, int value)
        {
            Assert.That(limit, Is.EqualTo(value));
        }
    }
}
