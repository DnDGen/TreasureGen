using EquipmentGen.Core.Data.Items;
using EquipmentGen.Tests.Unit.Generation.Xml.Data.Attributes;
using NUnit.Framework;

namespace EquipmentGen.Tests.Unit.Generation.Xml.Data.Items.MundaneItems
{
    [TestFixture, PercentileTable("CommonMeleeWeapons")]
    public class CommonMeleeWeaponsTests : PercentileTests
    {
        [Test]
        public void DaggerPercentile()
        {
            AssertContent(ItemsConstants.Gear.Weapons.Dagger, 1, 4);
        }

        [Test]
        public void GreataxePercentile()
        {
            AssertContent(ItemsConstants.Gear.Weapons.Greataxe, 5, 14);
        }

        [Test]
        public void GreatswordPercentile()
        {
            AssertContent(ItemsConstants.Gear.Weapons.Greatsword, 15, 24);
        }

        [Test]
        public void KamaPercentile()
        {
            AssertContent(ItemsConstants.Gear.Weapons.Kama, 25, 28);
        }

        [Test]
        public void LongswordPercentile()
        {
            AssertContent(ItemsConstants.Gear.Weapons.Longsword, 29, 41);
        }

        [Test]
        public void LightMacePercentile()
        {
            AssertContent(ItemsConstants.Gear.Weapons.LightMace, 42, 45);
        }

        [Test]
        public void HeavyMacePercentile()
        {
            AssertContent(ItemsConstants.Gear.Weapons.HeavyMace, 46, 50);
        }

        [Test]
        public void NunchakuPercentile()
        {
            AssertContent(ItemsConstants.Gear.Weapons.Nunchaku, 51, 54);
        }

        [Test]
        public void QuarterstaffPercentile()
        {
            AssertContent(ItemsConstants.Gear.Weapons.Quarterstaff, 55, 57);
        }

        [Test]
        public void RapierPercentile()
        {
            AssertContent(ItemsConstants.Gear.Weapons.Rapier, 58, 61);
        }

        [Test]
        public void ScimitarPercentile()
        {
            AssertContent(ItemsConstants.Gear.Weapons.Scimitar, 62, 66);
        }

        [Test]
        public void ShortspearPercentile()
        {
            AssertContent(ItemsConstants.Gear.Weapons.Shortspear, 67, 70);
        }

        [Test]
        public void SianghamPercentile()
        {
            AssertContent(ItemsConstants.Gear.Weapons.Siangham, 71, 74);
        }

        [Test]
        public void BastardSwordPercentile()
        {
            AssertContent(ItemsConstants.Gear.Weapons.BastardSword, 75, 84);
        }

        [Test]
        public void ShortSwordPercentile()
        {
            AssertContent(ItemsConstants.Gear.Weapons.ShortSword, 85, 89);
        }

        [Test]
        public void DwarvenWaraxePercentile()
        {
            AssertContent(ItemsConstants.Gear.Weapons.DwarvenWaraxe, 90, 100);
        }
    }
}