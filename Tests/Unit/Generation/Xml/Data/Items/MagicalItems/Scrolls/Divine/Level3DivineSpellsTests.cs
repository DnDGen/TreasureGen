using EquipmentGen.Tests.Unit.Generation.Xml.Data.Attributes;
using NUnit.Framework;

namespace EquipmentGen.Tests.Unit.Generation.Xml.Data.Items.MagicalItems.Scrolls.Divine
{
    [TestFixture, PercentileTable("Level3DivineSpells")]
    public class Level3DivineSpellsTests : PercentileTests
    {
        [Test]
        public void AnimateDeadPercentile()
        {
            AssertContent("Animate dead", 1, 2);
        }

        [Test]
        public void BestowCursePercentile()
        {
            AssertContent("Bestow curse", 3, 4);
        }

        [Test]
        public void BlindnessDeafnessPercentile()
        {
            AssertContent("Blindness/deafness", 5, 6);
        }

        [Test]
        public void CallLightningPercentile()
        {
            AssertContent("Call lightning", 7, 8);
        }

        [Test]
        public void ContagionPercentile()
        {
            AssertContent("Contagion", 9, 10);
        }

        [Test]
        public void ContinualFlamePercentile()
        {
            AssertContent("Continual flame", 11, 12);
        }

        [Test]
        public void CreateFoodAndWaterPercentile()
        {
            AssertContent("Create food and water", 13, 14);
        }

        [Test]
        public void CureSeriousWoundsPercentile()
        {
            AssertContent("Cure serious wounds", 15, 18);
        }

        [Test]
        public void DarkvisionPercentile()
        {
            AssertContent("Darkvision", 19);
        }

        [Test]
        public void DaylightPercentile()
        {
            AssertContent("Daylight", 20, 21);
        }

        [Test]
        public void DeeperDarknessPercentile()
        {
            AssertContent("Deeper darkness", 22, 23);
        }

        [Test]
        public void DiminishPlantsPercentile()
        {
            AssertContent("Diminish plants", 24, 25);
        }

        [Test]
        public void DispelMagicPercentile()
        {
            AssertContent("Dispel magic", 26, 27);
        }

        [Test]
        public void DominateAnimalPercentile()
        {
            AssertContent("Dominate animal", 28, 29);
        }

        [Test]
        public void GlyphOfWardingPercentile()
        {
            AssertContent("Glyph of warding", 30, 31);
        }

        [Test]
        public void HealMountPercentile()
        {
            AssertContent("Heal mount", 32);
        }

        [Test]
        public void HelpingHandPercentile()
        {
            AssertContent("Helping hand", 33, 34);
        }

        [Test]
        public void InflictSeriousWoundsPercentile()
        {
            AssertContent("Inflict serious wounds", 35, 36);
        }

        [Test]
        public void InvisibilityPurgePercentile()
        {
            AssertContent("Invisibility purge", 37, 38);
        }

        [Test]
        public void LocateObjectPercentile()
        {
            AssertContent("Locate object", 39, 40);
        }

        [Test]
        public void MagicCircleAgainstChaosEvilGoodLawPercentile()
        {
            AssertContent("Magic circle against chaos/evil/good/law", 41, 46);
        }

        [Test]
        public void GreaterMagicFangPercentile()
        {
            AssertContent("Greater magic fang", 47, 48);
        }

        [Test]
        public void MagicVestmentPercentile()
        {
            AssertContent("Magic vestment", 49, 50);
        }

        [Test]
        public void MeldIntoStonePercentile()
        {
            AssertContent("Meld into stone", 51, 52);
        }

        [Test]
        public void NeutralizePoisonPercentile()
        {
            AssertContent("Neutralize poison", 53, 55);
        }

        [Test]
        public void ObscureObjectPercentile()
        {
            AssertContent("Obscure object", 56, 57);
        }

        [Test]
        public void PlantGrowthPercentile()
        {
            AssertContent("Plant growth", 58, 59);
        }

        [Test]
        public void PrayerPercentile()
        {
            AssertContent("Prayer", 60, 62);
        }

        [Test]
        public void ProtectionFromEnergyPercentile()
        {
            AssertContent("Protection from energy", 63, 64);
        }

        [Test]
        public void QuenchPercentile()
        {
            AssertContent("Quench", 65, 66);
        }

        [Test]
        public void RemoveBlindnessDeafnessPercentile()
        {
            AssertContent("Remove blindness/deafness", 67, 69);
        }

        [Test]
        public void RemoveCursePercentile()
        {
            AssertContent("Remove curse", 70, 71);
        }

        [Test]
        public void RemoveDiseasePercentile()
        {
            AssertContent("Remove disease", 72, 73);
        }

        [Test]
        public void SearingLightPercentile()
        {
            AssertContent("Searing light", 74, 76);
        }

        [Test]
        public void SleetStormPercentile()
        {
            AssertContent("Sleet storm", 77, 78);
        }

        [Test]
        public void SnarePercentile()
        {
            AssertContent("Snare", 79, 80);
        }

        [Test]
        public void SpeakWithDeadPercentile()
        {
            AssertContent("Speak with dead", 81, 83);
        }

        [Test]
        public void SpeakWithPlantsPercentile()
        {
            AssertContent("Speak with plants", 84, 85);
        }

        [Test]
        public void SpikeGrowthPercentile()
        {
            AssertContent("Spike growth", 86, 87);
        }

        [Test]
        public void StoneShapePercentile()
        {
            AssertContent("Stone shape", 88, 89);
        }

        [Test]
        public void SummonMonsterIIIPercentile()
        {
            AssertContent("Summon monster III", 90, 91);
        }

        [Test]
        public void SummonNaturesAllyIIIPercentile()
        {
            AssertContent("Summon nature's ally III", 92, 93);
        }

        [Test]
        public void WaterBreathingPercentile()
        {
            AssertContent("Water breathing", 94, 96);
        }

        [Test]
        public void WaterWalkPercentile()
        {
            AssertContent("Water walk", 97, 98);
        }

        [Test]
        public void WindWallPercentile()
        {
            AssertContent("Wind wall", 99, 100);
        }
    }
}