using EquipmentGen.Core.Data.Items;
using NUnit.Framework;

namespace EquipmentGen.Tests.Unit.Data.Items
{
    [TestFixture]
    public class TraitItemTests
    {
        private TraitItem traitItem;

        [SetUp]
        public void Setup()
        {
            traitItem = new TraitItem();
            traitItem.Name = "shiny TraitItem";
        }

        [Test]
        public void PlainTraitItem()
        {
            Assert.That(traitItem.ToString(), Is.EqualTo(traitItem.Name));
        }

        [Test]
        public void TraitItemWithOneTrait()
        {
            traitItem.Traits.Add("trait");

            Assert.That(traitItem.ToString(), Is.EqualTo("shiny TraitItem (trait)"));
        }

        [Test]
        public void TraitItemWithTwoTraits()
        {
            traitItem.Traits.Add("trait");
            traitItem.Traits.Add("other trait");

            Assert.That(traitItem.ToString(), Is.EqualTo("shiny TraitItem (trait, other trait)"));
        }

        [Test]
        public void TraitItemWithThreeTraits()
        {
            traitItem.Traits.Add("trait");
            traitItem.Traits.Add("other trait");
            traitItem.Traits.Add("third trait");

            Assert.That(traitItem.ToString(), Is.EqualTo("shiny TraitItem (trait, other trait, third trait)"));
        }
    }
}