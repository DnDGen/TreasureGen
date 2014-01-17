using EquipmentGen.Core.Data.Items;
using NUnit.Framework;

namespace EquipmentGen.Tests.Unit.Data.Items
{
    [TestFixture]
    public class ItemsConstantsTests
    {
        [Test]
        public void MundaneConstant()
        {
            Assert.That(ItemsConstants.Mundane, Is.EqualTo("Mundane"));
        }

        [Test]
        public void MinorConstant()
        {
            Assert.That(ItemsConstants.Minor, Is.EqualTo("Minor"));
        }

        [Test]
        public void MediumConstant()
        {
            Assert.That(ItemsConstants.Medium, Is.EqualTo("Medium"));
        }

        [Test]
        public void MajorConstant()
        {
            Assert.That(ItemsConstants.Major, Is.EqualTo("Major"));
        }
    }
}