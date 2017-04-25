using Moq;
using NUnit.Framework;
using TreasureGen.Domain.Selectors.Collections;
using TreasureGen.Domain.Tables;
using TreasureGen.Items;

namespace TreasureGen.Tests.Unit.Selectors.Collections
{
    [TestFixture]
    public class WeaponDataSelectorTests
    {
        private IWeaponDataSelector weaponDataSelector;
        private Mock<ICollectionsSelector> mockInnerSelector;

        [SetUp]
        public void Setup()
        {
            mockInnerSelector = new Mock<ICollectionsSelector>();
            weaponDataSelector = new WeaponDataSelector(mockInnerSelector.Object);
        }

        [Test]
        public void GetWeaponData()
        {
            var data = new string[3];
            data[DataIndexConstants.Weapon.CriticalMultiplier] = "over 9000!!!";
            data[DataIndexConstants.Weapon.DamageType] = "emotional";
            data[DataIndexConstants.Weapon.ThreatRange] = "here to there";

            mockInnerSelector.Setup(s => s.SelectFrom(TableNameConstants.Collections.Set.WeaponData, "weapon")).Returns(data);

            var damages = new string[7];
            damages[0] = "almost nothing";
            damages[1] = "a little";
            damages[2] = "a normal amount";
            damages[3] = "quite a bit";
            damages[4] = "a ton";
            damages[5] = "way too much";
            damages[6] = "DAYUM";

            mockInnerSelector.Setup(s => s.SelectFrom(TableNameConstants.Collections.Set.WeaponDamages, "weapon")).Returns(damages);

            var selection = weaponDataSelector.Select("weapon");
            Assert.That(selection.CriticalMultiplier, Is.EqualTo("over 9000!!!"));
            Assert.That(selection.DamageType, Is.EqualTo("emotional"));
            Assert.That(selection.ThreatRange, Is.EqualTo("here to there"));
            Assert.That(selection.DamageBySize[TraitConstants.Sizes.Colossal], Is.EqualTo("DAYUM"));
            Assert.That(selection.DamageBySize[TraitConstants.Sizes.Gargantuan], Is.EqualTo("way too much"));
            Assert.That(selection.DamageBySize[TraitConstants.Sizes.Huge], Is.EqualTo("a ton"));
            Assert.That(selection.DamageBySize[TraitConstants.Sizes.Large], Is.EqualTo("quite a bit"));
            Assert.That(selection.DamageBySize[TraitConstants.Sizes.Medium], Is.EqualTo("a normal amount"));
            Assert.That(selection.DamageBySize[TraitConstants.Sizes.Small], Is.EqualTo("a little"));
            Assert.That(selection.DamageBySize[TraitConstants.Sizes.Tiny], Is.EqualTo("almost nothing"));
            Assert.That(selection.DamageBySize.Count, Is.EqualTo(7));
        }
    }
}
