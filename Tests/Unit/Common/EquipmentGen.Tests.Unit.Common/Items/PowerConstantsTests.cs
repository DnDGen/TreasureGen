using EquipmentGen.Common.Items;
using NUnit.Framework;

namespace EquipmentGen.Tests.Unit.Common.Items
{
    [TestFixture]
    public class PowerConstantsTests
    {
        [Test]
        public void MundaneConstant()
        {
            Assert.That(PowerConstants.Mundane, Is.EqualTo("Mundane"));
        }

        [Test]
        public void MinorConstant()
        {
            Assert.That(PowerConstants.Minor, Is.EqualTo("Minor"));
        }

        [Test]
        public void MediumConstant()
        {
            Assert.That(PowerConstants.Medium, Is.EqualTo("Medium"));
        }

        [Test]
        public void MajorConstant()
        {
            Assert.That(PowerConstants.Major, Is.EqualTo("Major"));
        }
    }
}