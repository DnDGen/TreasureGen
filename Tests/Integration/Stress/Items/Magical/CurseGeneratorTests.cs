using EquipmentGen.Generators.Interfaces.Items.Magical;
using Ninject;
using NUnit.Framework;

namespace EquipmentGen.Tests.Integration.Stress.Items.Magical
{
    [TestFixture]
    public class CurseGeneratorTests : StressTests
    {
        [Inject]
        public ICurseGenerator CurseGenerator { get; set; }

        [Test]
        public void StressedCurseGenerator()
        {
            StressGenerator();
        }

        protected override void MakeAssertions()
        {
            var curse = CurseGenerator.GenerateCurse();

            Assert.That(curse, Is.Not.Empty);

            var cursedItem = CurseGenerator.GenerateSpecificCursedItem();

            Assert.That(cursedItem.Name, Is.Not.Empty);
            Assert.That(cursedItem.Attributes, Is.Not.Null);
            Assert.That(cursedItem.IsMagical, Is.True);
            Assert.That(cursedItem.Magic.Curse, Is.EqualTo("This is a specific cursed item"));
            Assert.That(cursedItem.Quantity, Is.EqualTo(1));
            Assert.That(cursedItem.Traits, Is.Not.Null);
            Assert.That(cursedItem.Contents, Is.Empty);
        }
    }
}