using System;
using EquipmentGen.Common.Items;
using NUnit.Framework;

namespace EquipmentGen.Tests.Integration.Tables.Items.Magical.Weapons
{
    [TestFixture]
    public class MeleeTraitsTests : PercentileTests
    {
        protected override String GetTableName()
        {
            return "MeleeTraits";
        }

        [TestCase(TraitConstants.ShedsLight, 1, 30)]
        [TestCase(TraitConstants.Markings, 31, 45)]
        public void Percentile(String content, Int32 lower, Int32 upper)
        {
            AssertPercentile(content, lower, upper);
        }

        [Test]
        public void EmptyPercentile()
        {
            AssertPercentile(String.Empty, 46, 100);
        }
    }
}