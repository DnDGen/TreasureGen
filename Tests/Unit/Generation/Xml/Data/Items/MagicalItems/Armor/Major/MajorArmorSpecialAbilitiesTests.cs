using EquipmentGen.Tests.Unit.Generation.Xml.Data.Attributes;
using NUnit.Framework;

namespace EquipmentGen.Tests.Unit.Generation.Xml.Data.Items.MagicalItems.Armor.Major
{
    [TestFixture, PercentileTable("MajorArmorSpecialAbilities")]
    public class MajorArmorSpecialAbilitiesTests : PercentileTests
    {
        [Test]
        public void GlameredPercentile()
        {
            AssertContent("Glamered,0,0", 1, 3);
        }

        [Test]
        public void LightFortificationPercentile()
        {
            AssertContent("Fortification,1,1,Light fortification", 4);
        }

        [Test]
        public void ImprovedSlickPercentile()
        {
            AssertContent("Slick,0,2,Improved slick", 5, 7);
        }

        [Test]
        public void ImprovedShadowPercentile()
        {
            AssertContent("Shadow,0,2,Improved shadow", 8, 10);
        }

        [Test]
        public void ImprovedSilentMovesPercentile()
        {
            AssertContent("Silent moves,0,2,Improved silent moves", 11, 13);
        }

        [Test]
        public void AcidResistancePercentile()
        {
            AssertContent("Acid resistance,0,1", 14, 16);
        }

        [Test]
        public void ColdResistancePercentile()
        {
            AssertContent("Cold resistance,0,1", 17, 19);
        }

        [Test]
        public void ElectricityResistancePercentile()
        {
            AssertContent("Electricity resistance,0,1", 20, 22);
        }

        [Test]
        public void FireResistancePercentile()
        {
            AssertContent("Fire resistance,0,1", 23, 25);
        }

        [Test]
        public void SonicResistancePercentile()
        {
            AssertContent("Sonic resistance,0,1", 26, 28);
        }

        [Test]
        public void GhostTouchPercentile()
        {
            AssertContent("Ghost touch,3,0", 29, 33);
        }

        [Test]
        public void InvulnerabilityPercentile()
        {
            AssertContent("Invulnerability,3,0", 34, 35);
        }

        [Test]
        public void ModerateFortificationPercentile()
        {
            AssertContent("Fortification,3,2,Moderate fortification", 36, 40);
        }

        [Test]
        public void SpellResistance15Percentile()
        {
            AssertContent("Spell resistance,3,15,Spell resistance (15)", 41, 42);
        }

        [Test]
        public void WildPercentile()
        {
            AssertContent("Wild,3,0", 43);
        }

        [Test]
        public void GreaterSlickPercentile()
        {
            AssertContent("Slick,0,3,Greater slick", 44, 48);
        }

        [Test]
        public void GreaterShadowPercentile()
        {
            AssertContent("Shadow,0,3,Greater shadow", 49, 53);
        }

        [Test]
        public void GreaterSilentMovesPercentile()
        {
            AssertContent("Silent moves,0,3,Greater silent moves", 54, 58);
        }

        [Test]
        public void ImprovedAcidResistancePercentile()
        {
            AssertContent("Acid resistance,0,2,Improved acid resistance", 59, 63);
        }

        [Test]
        public void ImprovedColdResistancePercentile()
        {
            AssertContent("Cold resistance,0,2,Improved cold resistance", 64, 68);
        }

        [Test]
        public void ImprovedElectricityResistancePercentile()
        {
            AssertContent("Electricity resistance,0,2,Improved electricity resistance", 69, 73);
        }

        [Test]
        public void ImprovedFireResistancePercentile()
        {
            AssertContent("Fire resistance,0,2,Improved fire resistance", 74, 78);
        }

        [Test]
        public void ImprovedSonicResistancePercentile()
        {
            AssertContent("Sonic resistance,0,2,Improved sonic resistance", 79, 83);
        }

        [Test]
        public void SpellResistance17Percentile()
        {
            AssertContent("Spell resistance,4,17,Spell resistance (17)", 84, 88);
        }

        [Test]
        public void EtherealnessPercentile()
        {
            AssertContent("Etherealness,0,0", 89);
        }

        [Test]
        public void UndeadControllingPercentile()
        {
            AssertContent("Undead controlling,0,0", 90);
        }

        [Test]
        public void HeavyFortificationPercentile()
        {
            AssertContent("Fortification,5,3,Heavy fortification", 91, 92);
        }

        [Test]
        public void SpellResistance19Percentile()
        {
            AssertContent("Spell resistance,5,19,Spell resistance (19)", 93, 94);
        }

        [Test]
        public void GreaterAcidResistancePercentile()
        {
            AssertContent("Acid resistance,0,3,Greater acid resistance", 95);
        }

        [Test]
        public void GreaterColdResistancePercentile()
        {
            AssertContent("Cold resistance,0,3,Greater cold resistance", 96);
        }

        [Test]
        public void GreaterElectricityResistancePercentile()
        {
            AssertContent("Electricity resistance,0,3,Greater electricity resistance", 97);
        }

        [Test]
        public void GreaterFireResistancePercentile()
        {
            AssertContent("Fire resistance,0,3,Greater fire resistance", 98);
        }

        [Test]
        public void GreaterSonicResistancePercentile()
        {
            AssertContent("Sonic resistance,0,3,Greater sonic resistance", 99);
        }

        [Test]
        public void BonusSpecialAbilityPercentile()
        {
            AssertContent("BonusSpecialAbility,0,0", 100);
        }
    }
}