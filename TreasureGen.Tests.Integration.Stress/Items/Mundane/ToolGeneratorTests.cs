using NUnit.Framework;
using System.Collections.Generic;
using TreasureGen.Items;
using TreasureGen.Items.Mundane;

namespace TreasureGen.Tests.Integration.Stress.Items.Mundane
{
    [TestFixture]
    public class ToolGeneratorTests : MundaneItemGeneratorStressTests
    {
        [SetUp]
        public void Setup()
        {
            mundaneItemGenerator = GetNewInstanceOf<MundaneItemGenerator>(ItemTypeConstants.Tool);
        }

        [Test]
        public void StressTool()
        {
            Stress(StressItem);
        }

        protected override void MakeSpecificAssertionsAgainst(Item tool)
        {
            Assert.That(tool.Name, Is.Not.Empty);
            Assert.That(tool.Attributes, Is.Empty);
            Assert.That(tool.IsMagical, Is.False);
            Assert.That(tool.Quantity, Is.EqualTo(1));
            Assert.That(tool.ItemType, Is.EqualTo(ItemTypeConstants.Tool));
        }

        [Test]
        public override void NoDecorationsHappen()
        {
            AssertNoDecorationsHappen();
        }

        protected override IEnumerable<string> GetItemNames()
        {
            return ToolConstants.GetAllTools();
        }

        [Test]
        public void StressCustomTool()
        {
            Stress(StressCustomItem);
        }

        [Test]
        public void StressRandomCustomTool()
        {
            Stress(StressRandomCustomItem);
        }

        [Test]
        public void StressToolFromSubset()
        {
            Stress(StressItemFromSubset);
        }
    }
}