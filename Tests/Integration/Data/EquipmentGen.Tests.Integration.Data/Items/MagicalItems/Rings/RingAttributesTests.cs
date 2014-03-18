using EquipmentGen.Core.Data.Items.Constants;
using EquipmentGen.Tests.Integration.Data.Attributes;
using NUnit.Framework;

namespace EquipmentGen.Tests.Integration.Data.Items.MagicalItems.Rings
{
    [TestFixture, AttributesTable("RingAttributes")]
    public class RingAttributesTests : AttributesTests
    {
        [Test]
        public void RamAttributes()
        {
            var attributes = new[]
            {
                AttributeConstants.Charged,
                AttributeConstants.OneTimeUse
            };

            AssertContent("Ram", attributes);
        }

        [Test]
        public void ThreeWishesAttributes()
        {
            var attributes = new[]
            {
                AttributeConstants.Charged,
                AttributeConstants.OneTimeUse
            };

            AssertContent("Three wishes", attributes);
        }
    }
}