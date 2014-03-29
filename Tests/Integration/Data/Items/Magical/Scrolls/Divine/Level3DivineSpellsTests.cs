using System;
using NUnit.Framework;

namespace EquipmentGen.Tests.Integration.Tables.Items.MagicalItems.Scrolls.Divine
{
    [TestFixture]
    public class Level3DivineSpellsTests : PercentileTests
    {
        protected override String GetTableName()
        {
            return "Level3DivineSpells";
        }

        [Test]
        public void AnimateDeadPercentile()
        {
            AssertPercentile("Animate dead", 1, 2);
        }

        [Test]
        public void BestowCursePercentile()
        {
            AssertPercentile("Bestow curse", 3, 4);
        }

        [Test]
        public void BlindnessDeafnessPercentile()
        {
            AssertPercentile("Blindness/deafness", 5, 6);
        }

        [Test]
        public void CallLightningPercentile()
        {
            AssertPercentile("Call lightning", 7, 8);
        }

        [Test]
        public void ContagionPercentile()
        {
            AssertPercentile("Contagion", 9, 10);
        }

        [Test]
        public void ContinualFlamePercentile()
        {
            AssertPercentile("Continual flame", 11, 12);
        }

        [Test]
        public void CreateFoodAndWaterPercentile()
        {
            AssertPercentile("Create food and water", 13, 14);
        }

        [Test]
        public void CureSeriousWoundsPercentile()
        {
            AssertPercentile("Cure serious wounds", 15, 18);
        }

        [Test]
        public void DarkvisionPercentile()
        {
            AssertPercentile("Darkvision", 19);
        }

        [Test]
        public void DaylightPercentile()
        {
            AssertPercentile("Daylight", 20, 21);
        }

        [Test]
        public void DeeperDarknessPercentile()
        {
            AssertPercentile("Deeper darkness", 22, 23);
        }

        [Test]
        public void DiminishPlantsPercentile()
        {
            AssertPercentile("Diminish plants", 24, 25);
        }

        [Test]
        public void DispelMagicPercentile()
        {
            AssertPercentile("Dispel magic", 26, 27);
        }

        [Test]
        public void DominateAnimalPercentile()
        {
            AssertPercentile("Dominate animal", 28, 29);
        }

        [Test]
        public void GlyphOfWardingPercentile()
        {
            AssertPercentile("Glyph of warding", 30, 31);
        }

        [Test]
        public void HealMountPercentile()
        {
            AssertPercentile("Heal mount", 32);
        }

        [Test]
        public void HelpingHandPercentile()
        {
            AssertPercentile("Helping hand", 33, 34);
        }

        [Test]
        public void InflictSeriousWoundsPercentile()
        {
            AssertPercentile("Inflict serious wounds", 35, 36);
        }

        [Test]
        public void InvisibilityPurgePercentile()
        {
            AssertPercentile("Invisibility purge", 37, 38);
        }

        [Test]
        public void LocateObjectPercentile()
        {
            AssertPercentile("Locate object", 39, 40);
        }

        [Test]
        public void MagicCircleAgainstChaosEvilGoodLawPercentile()
        {
            AssertPercentile("Magic circle against chaos/evil/good/law", 41, 46);
        }

        [Test]
        public void GreaterMagicFangPercentile()
        {
            AssertPercentile("Greater magic fang", 47, 48);
        }

        [Test]
        public void MagicVestmentPercentile()
        {
            AssertPercentile("Magic vestment", 49, 50);
        }

        [Test]
        public void MeldIntoStonePercentile()
        {
            AssertPercentile("Meld into stone", 51, 52);
        }

        [Test]
        public void NeutralizePoisonPercentile()
        {
            AssertPercentile("Neutralize poison", 53, 55);
        }

        [Test]
        public void ObscureObjectPercentile()
        {
            AssertPercentile("Obscure object", 56, 57);
        }

        [Test]
        public void PlantGrowthPercentile()
        {
            AssertPercentile("Plant growth", 58, 59);
        }

        [Test]
        public void PrayerPercentile()
        {
            AssertPercentile("Prayer", 60, 62);
        }

        [Test]
        public void ProtectionFromEnergyPercentile()
        {
            AssertPercentile("Protection from energy", 63, 64);
        }

        [Test]
        public void QuenchPercentile()
        {
            AssertPercentile("Quench", 65, 66);
        }

        [Test]
        public void RemoveBlindnessDeafnessPercentile()
        {
            AssertPercentile("Remove blindness/deafness", 67, 69);
        }

        [Test]
        public void RemoveCursePercentile()
        {
            AssertPercentile("Remove curse", 70, 71);
        }

        [Test]
        public void RemoveDiseasePercentile()
        {
            AssertPercentile("Remove disease", 72, 73);
        }

        [Test]
        public void SearingLightPercentile()
        {
            AssertPercentile("Searing light", 74, 76);
        }

        [Test]
        public void SleetStormPercentile()
        {
            AssertPercentile("Sleet storm", 77, 78);
        }

        [Test]
        public void SnarePercentile()
        {
            AssertPercentile("Snare", 79, 80);
        }

        [Test]
        public void SpeakWithDeadPercentile()
        {
            AssertPercentile("Speak with dead", 81, 83);
        }

        [Test]
        public void SpeakWithPlantsPercentile()
        {
            AssertPercentile("Speak with plants", 84, 85);
        }

        [Test]
        public void SpikeGrowthPercentile()
        {
            AssertPercentile("Spike growth", 86, 87);
        }

        [Test]
        public void StoneShapePercentile()
        {
            AssertPercentile("Stone shape", 88, 89);
        }

        [Test]
        public void SummonMonsterIIIPercentile()
        {
            AssertPercentile("Summon monster III", 90, 91);
        }

        [Test]
        public void SummonNaturesAllyIIIPercentile()
        {
            AssertPercentile("Summon nature's ally III", 92, 93);
        }

        [Test]
        public void WaterBreathingPercentile()
        {
            AssertPercentile("Water breathing", 94, 96);
        }

        [Test]
        public void WaterWalkPercentile()
        {
            AssertPercentile("Water walk", 97, 98);
        }

        [Test]
        public void WindWallPercentile()
        {
            AssertPercentile("Wind wall", 99, 100);
        }
    }
}