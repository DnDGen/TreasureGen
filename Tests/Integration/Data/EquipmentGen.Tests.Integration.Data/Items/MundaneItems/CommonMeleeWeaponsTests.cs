using EquipmentGen.Core.Data.Items.Constants;
using EquipmentGen.Tests.Integration.Data.Attributes;
using NUnit.Framework;

namespace EquipmentGen.Tests.Integration.Data.Items.MundaneItems
{
    [TestFixture, PercentileTable("CommonMeleeWeapons")]
    public class CommonMeleeWeaponsTests : PercentileTests
    {
        [Test]
        public void DaggerPercentile()
        {
            AssertContent(WeaponConstants.Dagger, 1, 4);
        }

        [Test]
        public void GreataxePercentile()
        {
            AssertContent(WeaponConstants.Greataxe, 5, 14);
        }

        [Test]
        public void GreatswordPercentile()
        {
            AssertContent(WeaponConstants.Greatsword, 15, 24);
        }

        [Test]
        public void KamaPercentile()
        {
            AssertContent(WeaponConstants.Kama, 25, 28);
        }

        [Test]
        public void LongswordPercentile()
        {
            AssertContent(WeaponConstants.Longsword, 29, 41);
        }

        [Test]
        public void LightMacePercentile()
        {
            AssertContent(WeaponConstants.LightMace, 42, 45);
        }

        [Test]
        public void HeavyMacePercentile()
        {
            AssertContent(WeaponConstants.HeavyMace, 46, 50);
        }

        [Test]
        public void NunchakuPercentile()
        {
            AssertContent(WeaponConstants.Nunchaku, 51, 54);
        }

        [Test]
        public void QuarterstaffPercentile()
        {
            AssertContent(WeaponConstants.Quarterstaff, 55, 57);
        }

        [Test]
        public void RapierPercentile()
        {
            AssertContent(WeaponConstants.Rapier, 58, 61);
        }

        [Test]
        public void ScimitarPercentile()
        {
            AssertContent(WeaponConstants.Scimitar, 62, 66);
        }

        [Test]
        public void ShortspearPercentile()
        {
            AssertContent(WeaponConstants.Shortspear, 67, 70);
        }

        [Test]
        public void SianghamPercentile()
        {
            AssertContent(WeaponConstants.Siangham, 71, 74);
        }

        [Test]
        public void BastardSwordPercentile()
        {
            AssertContent(WeaponConstants.BastardSword, 75, 84);
        }

        [Test]
        public void ShortSwordPercentile()
        {
            AssertContent(WeaponConstants.ShortSword, 85, 89);
        }

        [Test]
        public void DwarvenWaraxePercentile()
        {
            AssertContent(WeaponConstants.DwarvenWaraxe, 90, 100);
        }
    }
}