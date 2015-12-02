using Ninject;
using NUnit.Framework;
using System;
using TreasureGen.Common.Items;
using TreasureGen.Generators.Items.Magical;

namespace TreasureGen.Tests.Integration.Stress.Items.Magical
{
    [TestFixture]
    public class CurseGeneratorTests : StressTests
    {
        [Inject]
        public ICurseGenerator CurseGenerator { get; set; }

        [TestCase("Curse generator")]
        public override void Stress(String thingToStress)
        {
            Stress();
        }

        protected override void MakeAssertions()
        {
            var curse = CurseGenerator.GenerateCurse();
            Assert.That(curse, Is.Not.Empty);
        }

        [Test]
        public void StressSpecificCursedItem()
        {
            Stress(AssertSpecificCursedItem);
        }

        private void AssertSpecificCursedItem()
        {
            var cursedItem = CurseGenerator.GenerateSpecificCursedItem();

            Assert.That(cursedItem.Name, Is.Not.Empty);
            Assert.That(cursedItem.Attributes, Contains.Item(AttributeConstants.Specific));
            Assert.That(cursedItem.IsMagical, Is.True);
            Assert.That(cursedItem.Magic.Curse, Is.EqualTo(CurseConstants.SpecificCursedItem));
            Assert.That(cursedItem.Quantity, Is.EqualTo(1));
            Assert.That(cursedItem.Traits, Is.Empty);
            Assert.That(cursedItem.Contents, Is.Empty);
            Assert.That(cursedItem.ItemType, Is.Not.Empty);
        }
    }
}