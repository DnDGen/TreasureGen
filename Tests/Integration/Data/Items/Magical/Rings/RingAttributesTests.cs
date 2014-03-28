using EquipmentGen.Common.Items;
using EquipmentGen.Tests.Integration.Tables.TestAttributes;
using NUnit.Framework;

namespace EquipmentGen.Tests.Integration.Tables.Items.MagicalItems.Rings
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