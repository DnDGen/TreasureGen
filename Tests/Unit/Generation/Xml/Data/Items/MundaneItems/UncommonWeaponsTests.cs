using EquipmentGen.Core.Data.Items;
using EquipmentGen.Core.Data.Items.Constants;
using EquipmentGen.Tests.Unit.Generation.Xml.Data.Attributes;
using NUnit.Framework;

namespace EquipmentGen.Tests.Unit.Generation.Xml.Data.Items.MundaneItems
{
    [TestFixture, PercentileTable("UncommonWeapons")]
    public class UncommonWeaponsTests : PercentileTests
    {
        [Test]
        public void OrcDoubleAxePercentile()
        {
            AssertContent(WeaponConstants.OrcDoubleAxe, 1, 3);
        }

        [Test]
        public void BattleaxePercentile()
        {
            AssertContent(WeaponConstants.Battleaxe, 4, 7);
        }

        [Test]
        public void SpikedChainPercentile()
        {
            AssertContent(WeaponConstants.SpikedChain, 8, 10);
        }

        [Test]
        public void ClubPercentile()
        {
            AssertContent(WeaponConstants.Club, 11, 12);
        }

        [Test]
        public void HandCrossbowPercentile()
        {
            AssertContent(WeaponConstants.HandCrossbow, 13, 16);
        }

        [Test]
        public void RepeatingCrossbowPercentile()
        {
            AssertContent(WeaponConstants.RepeatingCrossbow, 17, 19);
        }

        [Test]
        public void PunchingDaggerPercentile()
        {
            AssertContent(WeaponConstants.PunchingDagger, 20, 21);
        }

        [Test]
        public void FalchionPercentile()
        {
            AssertContent(WeaponConstants.Falchion, 22, 23);
        }

        [Test]
        public void DireFlailPercentile()
        {
            AssertContent(WeaponConstants.DireFlail, 24, 26);
        }

        [Test]
        public void HeavyFlailPercentile()
        {
            AssertContent(WeaponConstants.HeavyFlail, 27, 31);
        }

        [Test]
        public void LightFlailPercentile()
        {
            AssertContent(WeaponConstants.LightFlail, 32, 35);
        }

        [Test]
        public void GauntletPercentile()
        {
            AssertContent(WeaponConstants.Gauntlet, 36, 37);
        }

        [Test]
        public void SpikedGauntletPercentile()
        {
            AssertContent(WeaponConstants.SpikedGauntlet, 38, 39);
        }

        [Test]
        public void GlaivePercentile()
        {
            AssertContent(WeaponConstants.Glaive, 40, 41);
        }

        [Test]
        public void GreatclubPercentile()
        {
            AssertContent(WeaponConstants.Greatclub, 42, 43);
        }

        [Test]
        public void GuisarmePercentile()
        {
            AssertContent(WeaponConstants.Guisarme, 44, 45);
        }

        [Test]
        public void HalberdPercentile()
        {
            AssertContent(WeaponConstants.Halberd, 46, 48);
        }

        [Test]
        public void HalfspearPercentile()
        {
            AssertContent(WeaponConstants.Halfspear, 49, 51);
        }

        [Test]
        public void GnomeHookedHammerPercentile()
        {
            AssertContent(WeaponConstants.GnomeHookedHammer, 52, 54);
        }

        [Test]
        public void LightHammerPercentile()
        {
            AssertContent(WeaponConstants.LightHammer, 55, 56);
        }

        [Test]
        public void HandaxePercentile()
        {
            AssertContent(WeaponConstants.Handaxe, 57, 58);
        }

        [Test]
        public void KukriPercentile()
        {
            AssertContent(WeaponConstants.Kukri, 59, 61);
        }

        [Test]
        public void LancePercentile()
        {
            AssertContent(WeaponConstants.Lance, 62, 64);
        }

        [Test]
        public void LongspearPercentile()
        {
            AssertContent(WeaponConstants.Longspear, 65, 67);
        }

        [Test]
        public void MorningstarPercentile()
        {
            AssertContent(WeaponConstants.Morningstar, 68, 70);
        }

        [Test]
        public void NetPercentile()
        {
            AssertContent(WeaponConstants.Net, 71, 72);
        }

        [Test]
        public void HeavyPickPercentile()
        {
            AssertContent(WeaponConstants.HeavyPick, 73, 74);
        }

        [Test]
        public void LightPickPercentile()
        {
            AssertContent(WeaponConstants.LightPick, 75, 76);
        }

        [Test]
        public void RanseurPercentile()
        {
            AssertContent(WeaponConstants.Ranseur, 77, 78);
        }

        [Test]
        public void SapPercentile()
        {
            AssertContent(WeaponConstants.Sap, 79, 80);
        }

        [Test]
        public void ScythePercentile()
        {
            AssertContent(WeaponConstants.Scythe, 81, 82);
        }

        [Test]
        public void ShurikenPercentile()
        {
            AssertContent(WeaponConstants.Shuriken, 83, 84);
        }

        [Test]
        public void SicklePercentile()
        {
            AssertContent(WeaponConstants.Sickle, 85, 86);
        }

        [Test]
        public void TwoBladedSwordPercentile()
        {
            AssertContent(WeaponConstants.TwoBladedSword, 87, 89);
        }

        [Test]
        public void TridentPercentile()
        {
            AssertContent(WeaponConstants.Trident, 90, 91);
        }

        [Test]
        public void DwarvenUrgroshPercentile()
        {
            AssertContent(WeaponConstants.DwarvenUrgrosh, 92, 94);
        }

        [Test]
        public void WarhammerPercentile()
        {
            AssertContent(WeaponConstants.Warhammer, 95, 97);
        }

        [Test]
        public void WhipPercentile()
        {
            AssertContent(WeaponConstants.Whip, 98, 100);
        }
    }
}