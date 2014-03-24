using System;
using EquipmentGen.Common.Items;
using NUnit.Framework;

namespace EquipmentGen.Tests.Unit.Common.Items
{
    [TestFixture]
    public class PowerConstantsTests
    {
        [TestCase(PowerConstants.Mundane, "Mundane")]
        [TestCase(PowerConstants.Minor, "Minor")]
        [TestCase(PowerConstants.Medium, "Medium")]
        [TestCase(PowerConstants.Major, "Major")]
        public void PowerConstantIsCorrect(String constant, String value)
        {
            Assert.That(constant, Is.EqualTo(value));
        }
    }
}