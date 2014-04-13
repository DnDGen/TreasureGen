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
            get { return "RingAttributes"; }
        }

        [TestCase("Ram", AttributeConstants.Charged,
                         AttributeConstants.OneTimeUse)]
        [TestCase("Three wishes", AttributeConstants.Charged,
                                  AttributeConstants.OneTimeUse)]
        public void Attributes(String name, params String[] attributes)
        {
            AssertAttributes(name, attributes);
        }
    }
}