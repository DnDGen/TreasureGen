using System;
using EquipmentGen.Common.Items;
using NUnit.Framework;

namespace EquipmentGen.Tests.Integration.Tables.Items.Magical.Armor
{
    [TestFixture]
    public class ArmorTypesTests : PercentileTests
    {
        protected override String tableName
        {
            get { return "ArmorTypes"; }
        }

        [TestCase(ArmorConstants.PaddedArmor, 1)]
        [TestCase(ArmorConstants.LeatherArmor, 2)]
        [TestCase(ArmorConstants.ScaleMail, 43)]
        [TestCase(ArmorConstants.Chainmail, 44)]
        [TestCase(ArmorConstants.SplintMail, 58)]
        [TestCase(ArmorConstants.BandedMail, 59)]
        [TestCase(ArmorConstants.HalfPlate, 60)]
        public void Percentile(String content, Int32 roll)
        {
            AssertPercentile(content, roll);
        }

        [TestCase(ArmorConstants.StuddedLeatherArmor, 3, 17)]
        [TestCase(ArmorConstants.ChainShirt, 18, 32)]
        [TestCase(ArmorConstants.HideArmor, 33, 42)]
        [TestCase(ArmorConstants.Breastplate, 45, 57)]
        [TestCase(ArmorConstants.FullPlate, 61, 100)]
        public void Percentile(String content, Int32 lower, Int32 upper)
        {
            AssertPercentile(content, lower, upper);
        }
    }
}