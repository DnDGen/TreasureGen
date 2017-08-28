using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;
using TreasureGen.Items;
using TreasureGen.Items.Magical;

namespace TreasureGen.Tests.Integration.Stress.Items.Magical
{
    [TestFixture]
    public class WondrousItemGeneratorTests : MagicalItemGeneratorStressTests
    {
        protected override bool allowMinor
        {
            get { return true; }
        }

        protected override string itemType
        {
            get { return ItemTypeConstants.WondrousItem; }
        }

        [Test]
        public void StressWondrousItem()
        {
            stressor.Stress(GenerateAndAssertItem);
        }

        protected override IEnumerable<string> GetItemNames()
        {
            return WondrousItemConstants.GetAllWondrousItems();
        }

        [Test]
        public void StressCustomWondrousItem()
        {
            stressor.Stress(GenerateAndAssertCustomItem);
        }

        protected override void MakeSpecificAssertionsAgainst(Item wondrousItem)
        {
            Assert.That(wondrousItem.Name, Is.Not.Empty);
            Assert.That(wondrousItem.Traits, Is.Not.Null);
            Assert.That(wondrousItem.Attributes, Is.Not.Null);
            Assert.That(wondrousItem.IsMagical, Is.True);
            Assert.That(wondrousItem.Contents, Is.Not.Null);
            Assert.That(wondrousItem.ItemType, Is.EqualTo(ItemTypeConstants.WondrousItem));
            Assert.That(wondrousItem.Magic.Bonus, Is.Not.Negative);
            Assert.That(wondrousItem.Magic.Charges, Is.Not.Negative);
            Assert.That(wondrousItem.Magic.SpecialAbilities, Is.Empty);

            var itemMaterials = wondrousItem.Traits.Intersect(materials);
            Assert.That(itemMaterials, Is.Empty);
        }

        [Test]
        public void BUG_CubicGateDoesNotDuplicateMaterialPlane()
        {
            stressor.Stress(AssertCubicGatePlanesAreUnique);
        }

        private void AssertCubicGatePlanesAreUnique()
        {
            var cubicGate = stressor.Generate(GenerateItem, i => i.ItemType == itemType && i.Name == WondrousItemConstants.CubicGate);
            Assert.That(cubicGate.ItemType, Is.EqualTo(ItemTypeConstants.WondrousItem));
            Assert.That(cubicGate.Name, Is.EqualTo(WondrousItemConstants.CubicGate));
            Assert.That(cubicGate.Contents, Is.Unique);
            Assert.That(cubicGate.Contents.Select(p => p.ToLower()), Is.Unique);
        }

        [Test]
        [Ignore("There is no currently-known use case where we generate a wondrous item from a subset")]
        public void StressWondrousItemFromSubset()
        {
            stressor.Stress(GenerateAndAssertItemFromSubset);
        }
    }
}