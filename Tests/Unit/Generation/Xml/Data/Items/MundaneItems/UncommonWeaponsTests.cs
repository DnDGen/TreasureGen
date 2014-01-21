using NUnit.Framework;

namespace EquipmentGen.Tests.Unit.Generation.Xml.Data.Items.MundaneItems
{
    [TestFixture]
    public class UncommonWeaponsTests : PercentileTests
    {
        [SetUp]
        public void Setup()
        {
            tableName = "UncommonWeapons";
        }

        [Test]
        public void OrcDoubleAxePercentile()
        {
            AssertContent("Orc double axe", 1, 3);
        }

        [Test]
        public void BattleaxePercentile()
        {
            AssertContent("Battleaxe", 4, 7);
        }

        [Test]
        public void SpikedChainPercentile()
        {
            AssertContent("Spiked chain", 8, 10);
        }

        [Test]
        public void ClubPercentile()
        {
            AssertContent("Club", 11, 12);
        }

        [Test]
        public void HandCrossbowPercentile()
        {
            AssertContent("Hand crossbow", 13, 16);
        }

        [Test]
        public void RepeatingCrossbowPercentile()
        {
            AssertContent("Repeating crossbow", 17, 19);
        }

        [Test]
        public void PunchingDaggerPercentile()
        {
            AssertContent("Punching dagger", 20, 21);
        }

        [Test]
        public void FalchionPercentile()
        {
            AssertContent("Falchion", 22, 23);
        }

        [Test]
        public void DireFlailPercentile()
        {
            AssertContent("Dire flail", 24, 26);
        }

        [Test]
        public void HeavyFlailPercentile()
        {
            AssertContent("Heavy flail", 27, 31);
        }

        [Test]
        public void LightFlailPercentile()
        {
            AssertContent("Light flail", 32, 35);
        }

        [Test]
        public void GauntletPercentile()
        {
            AssertContent("Gauntlet", 36, 37);
        }

        [Test]
        public void SpikedGauntletPercentile()
        {
            AssertContent("Spiked gauntlet", 38, 39);
        }

        [Test]
        public void GlaivePercentile()
        {
            AssertContent("Glaive", 40, 41);
        }

        [Test]
        public void GreatclubPercentile()
        {
            AssertContent("Greatclub", 42, 43);
        }

        [Test]
        public void GuisarmePercentile()
        {
            AssertContent("Guisarme", 44, 45);
        }

        [Test]
        public void HalberdPercentile()
        {
            AssertContent("Halberd", 46, 48);
        }

        [Test]
        public void HalfspearPercentile()
        {
            AssertContent("Halfspear", 49, 51);
        }

        [Test]
        public void GnomeHookedHammerPercentile()
        {
            AssertContent("Gnome hooked hammer", 52, 54);
        }

        [Test]
        public void LightHammerPercentile()
        {
            AssertContent("Light hammer", 55, 56);
        }

        [Test]
        public void HandaxePercentile()
        {
            AssertContent("Handaxe", 57, 58);
        }

        [Test]
        public void KukriPercentile()
        {
            AssertContent("Kukri", 59, 61);
        }

        [Test]
        public void LancePercentile()
        {
            AssertContent("Lance", 62, 64);
        }

        [Test]
        public void LongspearPercentile()
        {
            AssertContent("Longspear", 65, 67);
        }

        [Test]
        public void MorningstarPercentile()
        {
            AssertContent("Morningstar", 68, 70);
        }

        [Test]
        public void NetPercentile()
        {
            AssertContent("Net", 71, 72);
        }

        [Test]
        public void HeavyPickPercentile()
        {
            AssertContent("Heavy pick", 73, 74);
        }

        [Test]
        public void LightPickPercentile()
        {
            AssertContent("Light pick", 75, 76);
        }

        [Test]
        public void RanseurPercentile()
        {
            AssertContent("Ranseur", 77, 78);
        }

        [Test]
        public void SapPercentile()
        {
            AssertContent("Sap", 79, 80);
        }

        [Test]
        public void ScythePercentile()
        {
            AssertContent("Scythe", 81, 82);
        }

        [Test]
        public void ShurikenPercentile()
        {
            AssertContent("Shuriken", 83, 84);
        }

        [Test]
        public void SicklePercentile()
        {
            AssertContent("Sickle", 85, 86);
        }

        [Test]
        public void TwoBladedSwordPercentile()
        {
            AssertContent("Two-bladed sword", 87, 89);
        }

        [Test]
        public void TridentPercentile()
        {
            AssertContent("Trident", 90, 91);
        }

        [Test]
        public void DwarvenUrgroshPercentile()
        {
            AssertContent("Dwarven urgrosh", 92, 94);
        }

        [Test]
        public void WarhammerPercentile()
        {
            AssertContent("Warhammer", 95, 97);
        }

        [Test]
        public void WhipPercentile()
        {
            AssertContent("Whip", 98, 100);
        }
    }
}