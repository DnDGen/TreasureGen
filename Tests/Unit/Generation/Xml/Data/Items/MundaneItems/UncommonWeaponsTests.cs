using EquipmentGen.Core.Data.Items;
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
            AssertContent(ItemsConstants.Gear.Weapons.OrcDoubleAxe, 1, 3);
        }

        [Test]
        public void BattleaxePercentile()
        {
            AssertContent(ItemsConstants.Gear.Weapons.Battleaxe, 4, 7);
        }

        [Test]
        public void SpikedChainPercentile()
        {
            AssertContent(ItemsConstants.Gear.Weapons.SpikedChain, 8, 10);
        }

        [Test]
        public void ClubPercentile()
        {
            AssertContent(ItemsConstants.Gear.Weapons.Club, 11, 12);
        }

        [Test]
        public void HandCrossbowPercentile()
        {
            AssertContent(ItemsConstants.Gear.Weapons.HandCrossbow, 13, 16);
        }

        [Test]
        public void RepeatingCrossbowPercentile()
        {
            AssertContent(ItemsConstants.Gear.Weapons.RepeatingCrossbow, 17, 19);
        }

        [Test]
        public void PunchingDaggerPercentile()
        {
            AssertContent(ItemsConstants.Gear.Weapons.PunchingDagger, 20, 21);
        }

        [Test]
        public void FalchionPercentile()
        {
            AssertContent(ItemsConstants.Gear.Weapons.Falchion, 22, 23);
        }

        [Test]
        public void DireFlailPercentile()
        {
            AssertContent(ItemsConstants.Gear.Weapons.DireFlail, 24, 26);
        }

        [Test]
        public void HeavyFlailPercentile()
        {
            AssertContent(ItemsConstants.Gear.Weapons.HeavyFlail, 27, 31);
        }

        [Test]
        public void LightFlailPercentile()
        {
            AssertContent(ItemsConstants.Gear.Weapons.LightFlail, 32, 35);
        }

        [Test]
        public void GauntletPercentile()
        {
            AssertContent(ItemsConstants.Gear.Weapons.Gauntlet, 36, 37);
        }

        [Test]
        public void SpikedGauntletPercentile()
        {
            AssertContent(ItemsConstants.Gear.Weapons.SpikedGauntlet, 38, 39);
        }

        [Test]
        public void GlaivePercentile()
        {
            AssertContent(ItemsConstants.Gear.Weapons.Glaive, 40, 41);
        }

        [Test]
        public void GreatclubPercentile()
        {
            AssertContent(ItemsConstants.Gear.Weapons.Greatclub, 42, 43);
        }

        [Test]
        public void GuisarmePercentile()
        {
            AssertContent(ItemsConstants.Gear.Weapons.Guisarme, 44, 45);
        }

        [Test]
        public void HalberdPercentile()
        {
            AssertContent(ItemsConstants.Gear.Weapons.Halberd, 46, 48);
        }

        [Test]
        public void HalfspearPercentile()
        {
            AssertContent(ItemsConstants.Gear.Weapons.Halfspear, 49, 51);
        }

        [Test]
        public void GnomeHookedHammerPercentile()
        {
            AssertContent(ItemsConstants.Gear.Weapons.GnomeHookedHammer, 52, 54);
        }

        [Test]
        public void LightHammerPercentile()
        {
            AssertContent(ItemsConstants.Gear.Weapons.LightHammer, 55, 56);
        }

        [Test]
        public void HandaxePercentile()
        {
            AssertContent(ItemsConstants.Gear.Weapons.Handaxe, 57, 58);
        }

        [Test]
        public void KukriPercentile()
        {
            AssertContent(ItemsConstants.Gear.Weapons.Kukri, 59, 61);
        }

        [Test]
        public void LancePercentile()
        {
            AssertContent(ItemsConstants.Gear.Weapons.Lance, 62, 64);
        }

        [Test]
        public void LongspearPercentile()
        {
            AssertContent(ItemsConstants.Gear.Weapons.Longspear, 65, 67);
        }

        [Test]
        public void MorningstarPercentile()
        {
            AssertContent(ItemsConstants.Gear.Weapons.Morningstar, 68, 70);
        }

        [Test]
        public void NetPercentile()
        {
            AssertContent(ItemsConstants.Gear.Weapons.Net, 71, 72);
        }

        [Test]
        public void HeavyPickPercentile()
        {
            AssertContent(ItemsConstants.Gear.Weapons.HeavyPick, 73, 74);
        }

        [Test]
        public void LightPickPercentile()
        {
            AssertContent(ItemsConstants.Gear.Weapons.LightPick, 75, 76);
        }

        [Test]
        public void RanseurPercentile()
        {
            AssertContent(ItemsConstants.Gear.Weapons.Ranseur, 77, 78);
        }

        [Test]
        public void SapPercentile()
        {
            AssertContent(ItemsConstants.Gear.Weapons.Sap, 79, 80);
        }

        [Test]
        public void ScythePercentile()
        {
            AssertContent(ItemsConstants.Gear.Weapons.Scythe, 81, 82);
        }

        [Test]
        public void ShurikenPercentile()
        {
            AssertContent(ItemsConstants.Gear.Weapons.Shuriken, 83, 84);
        }

        [Test]
        public void SicklePercentile()
        {
            AssertContent(ItemsConstants.Gear.Weapons.Sickle, 85, 86);
        }

        [Test]
        public void TwoBladedSwordPercentile()
        {
            AssertContent(ItemsConstants.Gear.Weapons.TwoBladedSword, 87, 89);
        }

        [Test]
        public void TridentPercentile()
        {
            AssertContent(ItemsConstants.Gear.Weapons.Trident, 90, 91);
        }

        [Test]
        public void DwarvenUrgroshPercentile()
        {
            AssertContent(ItemsConstants.Gear.Weapons.DwarvenUrgrosh, 92, 94);
        }

        [Test]
        public void WarhammerPercentile()
        {
            AssertContent(ItemsConstants.Gear.Weapons.Warhammer, 95, 97);
        }

        [Test]
        public void WhipPercentile()
        {
            AssertContent(ItemsConstants.Gear.Weapons.Whip, 98, 100);
        }
    }
}