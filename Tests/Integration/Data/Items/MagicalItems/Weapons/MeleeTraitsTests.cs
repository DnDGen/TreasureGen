using System;
using EquipmentGen.Common.Items;
using EquipmentGen.Tests.Integration.Tables.TestAttributes;
using NUnit.Framework;

namespace EquipmentGen.Tests.Integration.Tables.Items.MagicalItems.Weapons
{
    [TestFixture, PercentileTable("MeleeTraits")]
    public class MeleeTraitsTests : PercentileTests
    {
        [TestCase(TraitConstants.ShedsLight, 1, 30)]
        [TestCase(TraitConstants.Markings, 31, 45)]
        public void Percentile(String content, Int32 lower, Int32 upper)
        {
            AssertPercentile(content, lower, upper);
        }

        [Test]
        public void EmptyPercentile()
        {
            AssertEmpty(46, 100);
        }
    }
}