using DnDGen.TreasureGen.Generators.Items;
using DnDGen.TreasureGen.Items;
using NUnit.Framework;
using System.Collections.Generic;

namespace DnDGen.TreasureGen.Tests.Unit.Generators.Items
{
    [TestFixture]
    public class PowerHelperTests
    {
        [TestCase(PowerConstants.Mundane, PowerConstants.Mundane,
            PowerConstants.Mundane)]
        [TestCase(PowerConstants.Mundane, PowerConstants.Minor,
            PowerConstants.Minor)]
        [TestCase(PowerConstants.Mundane, PowerConstants.Medium,
            PowerConstants.Medium)]
        [TestCase(PowerConstants.Mundane, PowerConstants.Major,
            PowerConstants.Major)]
        [TestCase(PowerConstants.Mundane, PowerConstants.Mundane,
            PowerConstants.Mundane,
            PowerConstants.Minor)]
        [TestCase(PowerConstants.Mundane, PowerConstants.Minor,
            PowerConstants.Minor,
            PowerConstants.Medium)]
        [TestCase(PowerConstants.Mundane, PowerConstants.Medium,
            PowerConstants.Medium,
            PowerConstants.Major)]
        [TestCase(PowerConstants.Mundane, PowerConstants.Mundane,
            PowerConstants.Mundane,
            PowerConstants.Minor,
            PowerConstants.Medium)]
        [TestCase(PowerConstants.Mundane, PowerConstants.Minor,
            PowerConstants.Minor,
            PowerConstants.Medium,
            PowerConstants.Major)]
        [TestCase(PowerConstants.Mundane, PowerConstants.Mundane,
            PowerConstants.Mundane,
            PowerConstants.Minor,
            PowerConstants.Medium,
            PowerConstants.Major)]
        [TestCase(PowerConstants.Minor, PowerConstants.Mundane,
            PowerConstants.Mundane)]
        [TestCase(PowerConstants.Minor, PowerConstants.Minor,
            PowerConstants.Minor)]
        [TestCase(PowerConstants.Minor, PowerConstants.Medium,
            PowerConstants.Medium)]
        [TestCase(PowerConstants.Minor, PowerConstants.Major,
            PowerConstants.Major)]
        [TestCase(PowerConstants.Minor, PowerConstants.Minor,
            PowerConstants.Mundane,
            PowerConstants.Minor)]
        [TestCase(PowerConstants.Minor, PowerConstants.Minor,
            PowerConstants.Minor,
            PowerConstants.Medium)]
        [TestCase(PowerConstants.Minor, PowerConstants.Medium,
            PowerConstants.Medium,
            PowerConstants.Major)]
        [TestCase(PowerConstants.Minor, PowerConstants.Minor,
            PowerConstants.Mundane,
            PowerConstants.Minor,
            PowerConstants.Medium)]
        [TestCase(PowerConstants.Minor, PowerConstants.Minor,
            PowerConstants.Minor,
            PowerConstants.Medium,
            PowerConstants.Major)]
        [TestCase(PowerConstants.Minor, PowerConstants.Minor,
            PowerConstants.Mundane,
            PowerConstants.Minor,
            PowerConstants.Medium,
            PowerConstants.Major)]
        [TestCase(PowerConstants.Medium, PowerConstants.Mundane,
            PowerConstants.Mundane)]
        [TestCase(PowerConstants.Medium, PowerConstants.Minor,
            PowerConstants.Minor)]
        [TestCase(PowerConstants.Medium, PowerConstants.Medium,
            PowerConstants.Medium)]
        [TestCase(PowerConstants.Medium, PowerConstants.Major,
            PowerConstants.Major)]
        [TestCase(PowerConstants.Medium, PowerConstants.Minor,
            PowerConstants.Mundane,
            PowerConstants.Minor)]
        [TestCase(PowerConstants.Medium, PowerConstants.Medium,
            PowerConstants.Minor,
            PowerConstants.Medium)]
        [TestCase(PowerConstants.Medium, PowerConstants.Medium,
            PowerConstants.Medium,
            PowerConstants.Major)]
        [TestCase(PowerConstants.Medium, PowerConstants.Medium,
            PowerConstants.Mundane,
            PowerConstants.Minor,
            PowerConstants.Medium)]
        [TestCase(PowerConstants.Medium, PowerConstants.Medium,
            PowerConstants.Minor,
            PowerConstants.Medium,
            PowerConstants.Major)]
        [TestCase(PowerConstants.Medium, PowerConstants.Medium,
            PowerConstants.Mundane,
            PowerConstants.Minor,
            PowerConstants.Medium,
            PowerConstants.Major)]
        [TestCase(PowerConstants.Major, PowerConstants.Mundane,
            PowerConstants.Mundane)]
        [TestCase(PowerConstants.Major, PowerConstants.Minor,
            PowerConstants.Minor)]
        [TestCase(PowerConstants.Major, PowerConstants.Medium,
            PowerConstants.Medium)]
        [TestCase(PowerConstants.Major, PowerConstants.Major,
            PowerConstants.Major)]
        [TestCase(PowerConstants.Major, PowerConstants.Minor,
            PowerConstants.Mundane,
            PowerConstants.Minor)]
        [TestCase(PowerConstants.Major, PowerConstants.Medium,
            PowerConstants.Minor,
            PowerConstants.Medium)]
        [TestCase(PowerConstants.Major, PowerConstants.Major,
            PowerConstants.Medium,
            PowerConstants.Major)]
        [TestCase(PowerConstants.Major, PowerConstants.Medium,
            PowerConstants.Mundane,
            PowerConstants.Minor,
            PowerConstants.Medium)]
        [TestCase(PowerConstants.Major, PowerConstants.Major,
            PowerConstants.Minor,
            PowerConstants.Medium,
            PowerConstants.Major)]
        [TestCase(PowerConstants.Major, PowerConstants.Major,
            PowerConstants.Mundane,
            PowerConstants.Minor,
            PowerConstants.Medium,
            PowerConstants.Major)]
        public void AdjustPowerCorrectly(string requested, string expected, params string[] available)
        {
            var power = PowerHelper.AdjustPower(requested, available);
            Assert.That(power, Is.EqualTo(expected));
        }

        [Test]
        public void AdjustPower_ThrowsExceptionWhenNoAvailablePowers()
        {
            Assert.That(() => PowerHelper.AdjustPower("my power", new List<string>()),
                Throws.ArgumentException.With.Message.EqualTo("No available powers from which to adjust the requested power: my power"));
        }
    }
}
