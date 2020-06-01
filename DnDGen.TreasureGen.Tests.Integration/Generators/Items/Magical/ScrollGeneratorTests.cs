using DnDGen.TreasureGen.Items;
using DnDGen.TreasureGen.Items.Magical;
using DnDGen.TreasureGen.Tests.Unit.Generators.Items;
using Ninject;
using NUnit.Framework;

namespace DnDGen.TreasureGen.Tests.Integration.Generators.Items.Magical
{
    [TestFixture]
    public class ScrollGeneratorTests : IntegrationTests
    {
        [Inject, Named(ItemTypeConstants.Scroll)]
        public MagicalItemGenerator ScrollGenerator { get; set; }

        private ItemVerifier itemVerifier;

        [SetUp]
        public void Setup()
        {
            itemVerifier = new ItemVerifier();
        }

        [TestCase(ItemTypeConstants.Scroll, PowerConstants.Minor)]
        [TestCase(ItemTypeConstants.Scroll, PowerConstants.Medium)]
        [TestCase(ItemTypeConstants.Scroll, PowerConstants.Major)]
        [TestCase("whatever", PowerConstants.Minor)]
        [TestCase("whatever", PowerConstants.Medium)]
        [TestCase("whatever", PowerConstants.Major)]
        public void GenerateScroll(string itemName, string power)
        {
            var isOfPower = ScrollGenerator.IsItemOfPower(itemName, power);
            Assert.That(isOfPower, Is.True);

            var item = ScrollGenerator.Generate(power, itemName);
            itemVerifier.AssertItem(item);
        }
    }
}
