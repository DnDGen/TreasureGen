using System;
using TreasureGen.Items;
using NUnit.Framework;

namespace TreasureGen.Tests.Unit.Generators.Items
{
    [TestFixture]
    public class PowerConstantsTests
    {
        [TestCase(PowerConstants.Mundane, "Mundane")]
        [TestCase(PowerConstants.Minor, "Minor")]
        [TestCase(PowerConstants.Medium, "Medium")]
        [TestCase(PowerConstants.Major, "Major")]
        public void Constant(String constant, String value)
        {
            Assert.That(constant, Is.EqualTo(value));
        }
    }
}