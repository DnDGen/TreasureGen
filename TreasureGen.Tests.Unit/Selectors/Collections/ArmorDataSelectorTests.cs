using DnDGen.Core.Selectors.Collections;
using Moq;
using NUnit.Framework;
using TreasureGen.Domain.Selectors.Collections;
using TreasureGen.Domain.Tables;

namespace TreasureGen.Tests.Unit.Selectors.Collections
{
    [TestFixture]
    public class ArmorDataSelectorTests
    {
        private IArmorDataSelector armorDataSelector;
        private Mock<ICollectionsSelector> mockInnerSelector;

        [SetUp]
        public void Setup()
        {
            mockInnerSelector = new Mock<ICollectionsSelector>();
            armorDataSelector = new ArmorDataSelector(mockInnerSelector.Object);
        }

        [Test]
        public void GetArmorData()
        {
            var data = new string[3];
            data[DataIndexConstants.Armor.ArmorBonus] = "9266";
            data[DataIndexConstants.Armor.ArmorCheckPenalty] = "-90210";
            data[DataIndexConstants.Armor.MaxDexterityBonus] = "42";

            mockInnerSelector.Setup(s => s.SelectFrom(TableNameConstants.Collections.Set.ArmorData, "armor")).Returns(data);

            var selection = armorDataSelector.Select("armor");
            Assert.That(selection.ArmorBonus, Is.EqualTo(9266));
            Assert.That(selection.ArmorCheckPenalty, Is.EqualTo(-90210));
            Assert.That(selection.MaxDexterityBonus, Is.EqualTo(42));
        }
    }
}
