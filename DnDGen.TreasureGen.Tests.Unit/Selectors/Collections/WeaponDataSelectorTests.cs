using DnDGen.Infrastructure.Selectors.Collections;
using DnDGen.TreasureGen.Items;
using DnDGen.TreasureGen.Selectors.Collections;
using DnDGen.TreasureGen.Selectors.Helpers;
using DnDGen.TreasureGen.Tables;
using Moq;
using NUnit.Framework;

namespace DnDGen.TreasureGen.Tests.Unit.Selectors.Collections
{
    [TestFixture]
    public class WeaponDataSelectorTests
    {
        private IWeaponDataSelector weaponDataSelector;
        private Mock<ICollectionSelector> mockInnerSelector;
        private DamageHelper damageHelper;

        [SetUp]
        public void Setup()
        {
            mockInnerSelector = new Mock<ICollectionSelector>();
            weaponDataSelector = new WeaponDataSelector(mockInnerSelector.Object);
            damageHelper = new DamageHelper();
        }

        [Test]
        public void GetWeaponData()
        {
            var data = new string[3];
            data[DataIndexConstants.Weapon.ThreatRange] = 9266.ToString();
            data[DataIndexConstants.Weapon.CriticalMultiplier] = "sevenfold";
            data[DataIndexConstants.Weapon.Ammunition] = "dirty laundry";

            mockInnerSelector.Setup(s => s.SelectFrom(TableNameConstants.Collections.Set.WeaponData, "weapon")).Returns(data);

            var damages = new string[14];
            damages[0] = damageHelper.BuildEntry("almost nothing", "emotional");
            damages[1] = damageHelper.BuildEntry("a little", "emotional");
            damages[2] = damageHelper.BuildEntry("a normal amount", "emotional");
            damages[3] = damageHelper.BuildEntry("quite a bit", "emotional");
            damages[4] = damageHelper.BuildEntry("a ton", "emotional");
            damages[5] = damageHelper.BuildEntry("way too much", "emotional");
            damages[6] = damageHelper.BuildEntry("DAYUM", "emotional");
            damages[7] = damageHelper.BuildEntry("almost nothing but more", "emotional");
            damages[8] = damageHelper.BuildEntry("a little but more", "emotional");
            damages[9] = damageHelper.BuildEntry("a normal amount but more", "emotional");
            damages[10] = damageHelper.BuildEntry("quite a bit but more", "emotional");
            damages[11] = damageHelper.BuildEntry("a ton but more", "emotional");
            damages[12] = damageHelper.BuildEntry("way too much but more", "emotional");
            damages[13] = damageHelper.BuildEntry("DAYUM but more", "emotional");

            mockInnerSelector.Setup(s => s.SelectFrom(TableNameConstants.Collections.Set.WeaponDamages, "weapon")).Returns(damages);

            var selection = weaponDataSelector.Select("weapon");
            Assert.That(selection.ThreatRange, Is.EqualTo(9266));
            Assert.That(selection.Ammunition, Is.EqualTo("dirty laundry"));
            Assert.That(selection.CriticalMultiplier, Is.EqualTo("sevenfold"));
            Assert.That(selection.DamagesBySize[TraitConstants.Sizes.Colossal], Has.Count.EqualTo(1));
            Assert.That(selection.DamagesBySize[TraitConstants.Sizes.Colossal][0].Description, Is.EqualTo("DAYUM emotional"));
            Assert.That(selection.DamagesBySize[TraitConstants.Sizes.Gargantuan], Has.Count.EqualTo(1));
            Assert.That(selection.DamagesBySize[TraitConstants.Sizes.Gargantuan][0].Description, Is.EqualTo("way too much emotional"));
            Assert.That(selection.DamagesBySize[TraitConstants.Sizes.Huge], Has.Count.EqualTo(1));
            Assert.That(selection.DamagesBySize[TraitConstants.Sizes.Huge][0].Description, Is.EqualTo("a ton emotional"));
            Assert.That(selection.DamagesBySize[TraitConstants.Sizes.Large], Has.Count.EqualTo(1));
            Assert.That(selection.DamagesBySize[TraitConstants.Sizes.Large][0].Description, Is.EqualTo("quite a bit emotional"));
            Assert.That(selection.DamagesBySize[TraitConstants.Sizes.Medium], Has.Count.EqualTo(1));
            Assert.That(selection.DamagesBySize[TraitConstants.Sizes.Medium][0].Description, Is.EqualTo("a normal amount emotional"));
            Assert.That(selection.DamagesBySize[TraitConstants.Sizes.Small], Has.Count.EqualTo(1));
            Assert.That(selection.DamagesBySize[TraitConstants.Sizes.Small][0].Description, Is.EqualTo("a little emotional"));
            Assert.That(selection.DamagesBySize[TraitConstants.Sizes.Tiny], Has.Count.EqualTo(1));
            Assert.That(selection.DamagesBySize[TraitConstants.Sizes.Tiny][0].Description, Is.EqualTo("almost nothing emotional"));
            Assert.That(selection.DamagesBySize.Count, Is.EqualTo(7));
            Assert.That(selection.CriticalDamagesBySize[TraitConstants.Sizes.Colossal], Has.Count.EqualTo(1));
            Assert.That(selection.CriticalDamagesBySize[TraitConstants.Sizes.Colossal][0].Description, Is.EqualTo("DAYUM but more emotional"));
            Assert.That(selection.CriticalDamagesBySize[TraitConstants.Sizes.Gargantuan], Has.Count.EqualTo(1));
            Assert.That(selection.CriticalDamagesBySize[TraitConstants.Sizes.Gargantuan][0].Description, Is.EqualTo("way too much but more emotional"));
            Assert.That(selection.CriticalDamagesBySize[TraitConstants.Sizes.Huge], Has.Count.EqualTo(1));
            Assert.That(selection.CriticalDamagesBySize[TraitConstants.Sizes.Huge][0].Description, Is.EqualTo("a ton but more emotional"));
            Assert.That(selection.CriticalDamagesBySize[TraitConstants.Sizes.Large], Has.Count.EqualTo(1));
            Assert.That(selection.CriticalDamagesBySize[TraitConstants.Sizes.Large][0].Description, Is.EqualTo("quite a bit but more emotional"));
            Assert.That(selection.CriticalDamagesBySize[TraitConstants.Sizes.Medium], Has.Count.EqualTo(1));
            Assert.That(selection.CriticalDamagesBySize[TraitConstants.Sizes.Medium][0].Description, Is.EqualTo("a normal amount but more emotional"));
            Assert.That(selection.CriticalDamagesBySize[TraitConstants.Sizes.Small], Has.Count.EqualTo(1));
            Assert.That(selection.CriticalDamagesBySize[TraitConstants.Sizes.Small][0].Description, Is.EqualTo("a little but more emotional"));
            Assert.That(selection.CriticalDamagesBySize[TraitConstants.Sizes.Tiny], Has.Count.EqualTo(1));
            Assert.That(selection.CriticalDamagesBySize[TraitConstants.Sizes.Tiny][0].Description, Is.EqualTo("almost nothing but more emotional"));
            Assert.That(selection.CriticalDamagesBySize.Count, Is.EqualTo(7));
        }

        [Test]
        public void GetWeaponData_MultipleDamages()
        {
            var data = new string[3];
            data[DataIndexConstants.Weapon.ThreatRange] = 9266.ToString();
            data[DataIndexConstants.Weapon.CriticalMultiplier] = "sevenfold";
            data[DataIndexConstants.Weapon.Ammunition] = "dirty laundry";

            mockInnerSelector.Setup(s => s.SelectFrom(TableNameConstants.Collections.Set.WeaponData, "weapon")).Returns(data);

            var damages = new string[14];
            damages[0] = damageHelper.BuildEntries("almost nothing", "emotional", "sort of nothing", "spiritual");
            damages[1] = damageHelper.BuildEntries("a little", "emotional", "a bit", "spiritual");
            damages[2] = damageHelper.BuildEntries("a normal amount", "emotional", "a standard amount", "spiritual");
            damages[3] = damageHelper.BuildEntries("quite a bit", "emotional", "quite a lot", "spiritual");
            damages[4] = damageHelper.BuildEntries("a ton", "emotional", "a truckload", "spiritual");
            damages[5] = damageHelper.BuildEntries("way too much", "emotional", "far too much", "spiritual");
            damages[6] = damageHelper.BuildEntries("DAYUM", "emotional", "OHLAWDITCOMIN'", "spiritual");
            damages[7] = damageHelper.BuildEntries("almost nothing but more", "emotional", "sort of nothing but more", "spiritual");
            damages[8] = damageHelper.BuildEntries("a little but more", "emotional", "a bit but more", "spiritual");
            damages[9] = damageHelper.BuildEntries("a normal amount but more", "emotional", "a standard amount but more", "spiritual");
            damages[10] = damageHelper.BuildEntries("quite a bit but more", "emotional", "quite a lot but more", "spiritual");
            damages[11] = damageHelper.BuildEntries("a ton but more", "emotional", "a truckload but more", "spiritual");
            damages[12] = damageHelper.BuildEntries("way too much but more", "emotional", "far too much but more", "spiritual");
            damages[13] = damageHelper.BuildEntries("DAYUM but more", "emotional", "OHLAWDITCOMIN' but more", "spiritual");

            mockInnerSelector.Setup(s => s.SelectFrom(TableNameConstants.Collections.Set.WeaponDamages, "weapon")).Returns(damages);

            var selection = weaponDataSelector.Select("weapon");
            Assert.That(selection.ThreatRange, Is.EqualTo(9266));
            Assert.That(selection.Ammunition, Is.EqualTo("dirty laundry"));
            Assert.That(selection.CriticalMultiplier, Is.EqualTo("sevenfold"));
            Assert.That(selection.DamagesBySize[TraitConstants.Sizes.Colossal], Has.Count.EqualTo(2));
            Assert.That(selection.DamagesBySize[TraitConstants.Sizes.Colossal][0].Description, Is.EqualTo("DAYUM emotional"));
            Assert.That(selection.DamagesBySize[TraitConstants.Sizes.Colossal][1].Description, Is.EqualTo("OHLAWDITCOMIN' spiritual"));
            Assert.That(selection.DamagesBySize[TraitConstants.Sizes.Gargantuan], Has.Count.EqualTo(2));
            Assert.That(selection.DamagesBySize[TraitConstants.Sizes.Gargantuan][0].Description, Is.EqualTo("way too much emotional"));
            Assert.That(selection.DamagesBySize[TraitConstants.Sizes.Gargantuan][1].Description, Is.EqualTo("far too much spiritual"));
            Assert.That(selection.DamagesBySize[TraitConstants.Sizes.Huge], Has.Count.EqualTo(2));
            Assert.That(selection.DamagesBySize[TraitConstants.Sizes.Huge][0].Description, Is.EqualTo("a ton emotional"));
            Assert.That(selection.DamagesBySize[TraitConstants.Sizes.Huge][1].Description, Is.EqualTo("a truckload spiritual"));
            Assert.That(selection.DamagesBySize[TraitConstants.Sizes.Large], Has.Count.EqualTo(2));
            Assert.That(selection.DamagesBySize[TraitConstants.Sizes.Large][0].Description, Is.EqualTo("quite a bit emotional"));
            Assert.That(selection.DamagesBySize[TraitConstants.Sizes.Large][1].Description, Is.EqualTo("quite a lot spiritual"));
            Assert.That(selection.DamagesBySize[TraitConstants.Sizes.Medium], Has.Count.EqualTo(2));
            Assert.That(selection.DamagesBySize[TraitConstants.Sizes.Medium][0].Description, Is.EqualTo("a normal amount emotional"));
            Assert.That(selection.DamagesBySize[TraitConstants.Sizes.Medium][1].Description, Is.EqualTo("a standard amount spiritual"));
            Assert.That(selection.DamagesBySize[TraitConstants.Sizes.Small], Has.Count.EqualTo(2));
            Assert.That(selection.DamagesBySize[TraitConstants.Sizes.Small][0].Description, Is.EqualTo("a little emotional"));
            Assert.That(selection.DamagesBySize[TraitConstants.Sizes.Small][1].Description, Is.EqualTo("a bit spiritual"));
            Assert.That(selection.DamagesBySize[TraitConstants.Sizes.Tiny], Has.Count.EqualTo(2));
            Assert.That(selection.DamagesBySize[TraitConstants.Sizes.Tiny][0].Description, Is.EqualTo("almost nothing emotional"));
            Assert.That(selection.DamagesBySize[TraitConstants.Sizes.Tiny][1].Description, Is.EqualTo("sort of nothing spiritual"));
            Assert.That(selection.DamagesBySize.Count, Is.EqualTo(7));
            Assert.That(selection.CriticalDamagesBySize[TraitConstants.Sizes.Colossal], Has.Count.EqualTo(2));
            Assert.That(selection.CriticalDamagesBySize[TraitConstants.Sizes.Colossal][0].Description, Is.EqualTo("DAYUM but more emotional"));
            Assert.That(selection.CriticalDamagesBySize[TraitConstants.Sizes.Colossal][1].Description, Is.EqualTo("OHLAWDITCOMIN' but more spiritual"));
            Assert.That(selection.CriticalDamagesBySize[TraitConstants.Sizes.Gargantuan], Has.Count.EqualTo(2));
            Assert.That(selection.CriticalDamagesBySize[TraitConstants.Sizes.Gargantuan][0].Description, Is.EqualTo("way too much but more emotional"));
            Assert.That(selection.CriticalDamagesBySize[TraitConstants.Sizes.Gargantuan][1].Description, Is.EqualTo("far too much but more spiritual"));
            Assert.That(selection.CriticalDamagesBySize[TraitConstants.Sizes.Huge], Has.Count.EqualTo(2));
            Assert.That(selection.CriticalDamagesBySize[TraitConstants.Sizes.Huge][0].Description, Is.EqualTo("a ton but more emotional"));
            Assert.That(selection.CriticalDamagesBySize[TraitConstants.Sizes.Huge][1].Description, Is.EqualTo("a truckload but more spiritual"));
            Assert.That(selection.CriticalDamagesBySize[TraitConstants.Sizes.Large], Has.Count.EqualTo(2));
            Assert.That(selection.CriticalDamagesBySize[TraitConstants.Sizes.Large][0].Description, Is.EqualTo("quite a bit but more emotional"));
            Assert.That(selection.CriticalDamagesBySize[TraitConstants.Sizes.Large][1].Description, Is.EqualTo("quite a lot but more spiritual"));
            Assert.That(selection.CriticalDamagesBySize[TraitConstants.Sizes.Medium], Has.Count.EqualTo(2));
            Assert.That(selection.CriticalDamagesBySize[TraitConstants.Sizes.Medium][0].Description, Is.EqualTo("a normal amount but more emotional"));
            Assert.That(selection.CriticalDamagesBySize[TraitConstants.Sizes.Medium][1].Description, Is.EqualTo("a standard amount but more spiritual"));
            Assert.That(selection.CriticalDamagesBySize[TraitConstants.Sizes.Small], Has.Count.EqualTo(2));
            Assert.That(selection.CriticalDamagesBySize[TraitConstants.Sizes.Small][0].Description, Is.EqualTo("a little but more emotional"));
            Assert.That(selection.CriticalDamagesBySize[TraitConstants.Sizes.Small][1].Description, Is.EqualTo("a bit but more spiritual"));
            Assert.That(selection.CriticalDamagesBySize[TraitConstants.Sizes.Tiny], Has.Count.EqualTo(2));
            Assert.That(selection.CriticalDamagesBySize[TraitConstants.Sizes.Tiny][0].Description, Is.EqualTo("almost nothing but more emotional"));
            Assert.That(selection.CriticalDamagesBySize[TraitConstants.Sizes.Tiny][1].Description, Is.EqualTo("sort of nothing but more spiritual"));
            Assert.That(selection.CriticalDamagesBySize.Count, Is.EqualTo(7));
        }
    }
}
