using System;
using EquipmentGen.Common.Items;
using NUnit.Framework;

namespace EquipmentGen.Tests.Integration.Tables.Items.Magical.WondrousItems
{
    [TestFixture]
    public class RobeOfUsefulItemsBaseItemsTests : AttributesTests
    {
        protected override String tableName
        {
            get { return "RobeOfUsefulItemsBaseItems"; }
        }

        [TestCase("Items", WeaponConstants.Dagger,
                           WeaponConstants.Dagger,
                           "Bullseye lantern (filled and lit)",
                           "Bullseye lantern (filled and lit)",
                           "Highly polished 2-foot-by-4-foot steel mirror",
                           "Highly polished 2-foot-by-4-foot steel mirror",
                           "10-foot pole",
                           "10-foot pole",
                           "50-foot hempen rope",
                           "50-foot hempen rope",
                           "Sack",
                           "Sack")]
        public void Attributes(String name, params String[] attributes)
        {
            AssertAttributes(name, attributes);
        }
    }
}