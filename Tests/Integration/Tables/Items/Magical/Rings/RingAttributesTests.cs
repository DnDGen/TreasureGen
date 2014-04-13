using System;
using EquipmentGen.Common.Items;
using NUnit.Framework;

namespace EquipmentGen.Tests.Integration.Tables.Items.Magical.Rings
{
    [TestFixture]
    public class RingAttributesTests : AttributesTests
    {
        protected override String tableName
        {
            get { return "GemDescriptions"; }
        }

        protected override String GetTableName()
        {
            return "RingAttributes";
        }

        [Test]
        public void RamAttributes()
        {
            var attributes = new[]
            {
                AttributeConstants.Charged,
                AttributeConstants.OneTimeUse
            };

            AssertAttributes("Ram", attributes);
        }

        [Test]
        public void ThreeWishesAttributes()
        {
            var attributes = new[]
            {
                AttributeConstants.Charged,
                AttributeConstants.OneTimeUse
            };

            AssertAttributes("Three wishes", attributes);
        }
    }
}