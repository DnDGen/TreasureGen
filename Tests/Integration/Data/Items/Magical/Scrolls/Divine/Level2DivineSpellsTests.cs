using System;
using NUnit.Framework;

namespace EquipmentGen.Tests.Integration.Tables.Items.MagicalItems.Scrolls.Divine
{
    [TestFixture]
    public class Level2DivineSpellsTests : PercentileTests
    {
        protected override String GetTableName()
        {
            return "Level2DivineSpells";
        }

        [Test]
        public void AnimalMessengerPercentile()
        {
            AssertPercentile("Animal messenger", 1);
        }

        [Test]
        public void AnimalTrancePercentile()
        {
            AssertPercentile("Animal trance", 2);
        }

        [Test]
        public void AuguryPercentile()
        {
            AssertPercentile("Augury", 3, 4);
        }

        [Test]
        public void BarkskinPercentile()
        {
            AssertPercentile("Barkskin", 5, 6);
        }

        [Test]
        public void BearsEndurancePercentile()
        {
            AssertPercentile("Bear's endurance", 7, 9);
        }

        [Test]
        public void BullsStrengthPercentile()
        {
            AssertPercentile("Bull's strength", 10, 12);
        }

        [Test]
        public void CalmEmotionsPercentile()
        {
            AssertPercentile("Calm emotions", 13, 14);
        }

        [Test]
        public void CatsGracePercentile()
        {
            AssertPercentile("Cat's grace", 15, 17);
        }

        [Test]
        public void ChillMetalPercentile()
        {
            AssertPercentile("Chill metal", 18);
        }

        [Test]
        public void ConsecratePercentile()
        {
            AssertPercentile("Consecrate", 19, 20);
        }

        [Test]
        public void CureModerateWoundsPercentile()
        {
            AssertPercentile("Cure moderate wounds", 21, 24);
        }

        [Test]
        public void DarknessPercentile()
        {
            AssertPercentile("Darkness", 25, 26);
        }

        [Test]
        public void DeathKnellPercentile()
        {
            AssertPercentile("Death knell", 27);
        }

        [Test]
        public void DelayPoisonPercentile()
        {
            AssertPercentile("Delay poison", 28, 30);
        }

        [Test]
        public void DesecratePercentile()
        {
            AssertPercentile("Desecrate", 31, 32);
        }

        [Test]
        public void EaglesSplendorPercentile()
        {
            AssertPercentile("Eagle's splendor", 33, 35);
        }

        [Test]
        public void EnthrallPercentile()
        {
            AssertPercentile("Enthrall", 36, 37);
        }

        [Test]
        public void FindTrapsPercentile()
        {
            AssertPercentile("Find traps", 38, 39);
        }

        [Test]
        public void FireTrapPercentile()
        {
            AssertPercentile("Fire trap", 40);
        }

        [Test]
        public void FlameBladePercentile()
        {
            AssertPercentile("Flame blade", 41, 42);
        }

        [Test]
        public void FlamingSpherePercentile()
        {
            AssertPercentile("Flaming sphere", 43, 44);
        }

        [Test]
        public void FogCloudPercentile()
        {
            AssertPercentile("Fog cloud", 45, 46);
        }

        [Test]
        public void GentleReposePercentile()
        {
            AssertPercentile("Gentle repose", 47);
        }

        [Test]
        public void GustOfWindPercentile()
        {
            AssertPercentile("Gust of wind", 48);
        }

        [Test]
        public void HeatMetalPercentile()
        {
            AssertPercentile("Heat metal", 49);
        }

        [Test]
        public void HoldAnimalPercentile()
        {
            AssertPercentile("Hold animal", 50, 51);
        }

        [Test]
        public void HoldPersonPercentile()
        {
            AssertPercentile("Hold person", 52, 54);
        }

        [Test]
        public void InflictModerateWoundsPercentile()
        {
            AssertPercentile("Inflict moderate wounds", 55, 56);
        }

        [Test]
        public void MakeWholePercentile()
        {
            AssertPercentile("Make whole", 57, 58);
        }

        [Test]
        public void OwlsWisdomPercentile()
        {
            AssertPercentile("Owl's wisdom", 59, 61);
        }

        [Test]
        public void ReduceAnimalPercentile()
        {
            AssertPercentile("Reduce animal", 62);
        }

        [Test]
        public void RemoveParalysisPercentile()
        {
            AssertPercentile("Remove paralysis", 63, 64);
        }

        [Test]
        public void ResistEnergyPercentile()
        {
            AssertPercentile("Resist energy", 65, 67);
        }

        [Test]
        public void LesserRestorationPercentile()
        {
            AssertPercentile("Lesser restoration", 68, 70);
        }

        [Test]
        public void ShatterPercentile()
        {
            AssertPercentile("Shatter", 71, 72);
        }

        [Test]
        public void ShieldOtherPercentile()
        {
            AssertPercentile("Shield other", 73, 74);
        }

        [Test]
        public void SilencePercentile()
        {
            AssertPercentile("Silence", 75, 76);
        }

        [Test]
        public void SnarePercentile()
        {
            AssertPercentile("Snare", 77);
        }

        [Test]
        public void SoftenEarthAndStonePercentile()
        {
            AssertPercentile("Soften earth and stone", 78);
        }

        [Test]
        public void SoundBurstPercentile()
        {
            AssertPercentile("Sound burst", 79, 80);
        }

        [Test]
        public void SpeakWithPlantsPercentile()
        {
            AssertPercentile("Speak with plants", 81);
        }

        [Test]
        public void SpiderClimbPercentile()
        {
            AssertPercentile("Spider climb", 82, 83);
        }

        [Test]
        public void SpiritualWeaponPercentile()
        {
            AssertPercentile("Spiritual weapon", 84, 85);
        }

        [Test]
        public void StatusPercentile()
        {
            AssertPercentile("Status", 86);
        }

        [Test]
        public void SummonMonsterIIPercentile()
        {
            AssertPercentile("Summon monster II", 87, 88);
        }

        [Test]
        public void SummonNaturesAllyIIPercentile()
        {
            AssertPercentile("Summon nature's ally II", 89, 90);
        }

        [Test]
        public void SummonSwarmPercentile()
        {
            AssertPercentile("Summon swarm", 91, 92);
        }

        [Test]
        public void TreeShapePercentile()
        {
            AssertPercentile("Tree shape", 93);
        }

        [Test]
        public void UndetectableAlignmentPercentile()
        {
            AssertPercentile("Undetectable alignment", 94, 95);
        }

        [Test]
        public void WarpWoodPercentile()
        {
            AssertPercentile("Warp wood", 96, 97);
        }

        [Test]
        public void WoodShapePercentile()
        {
            AssertPercentile("Wood shape", 98);
        }

        [Test]
        public void ZoneOfTruthPercentile()
        {
            AssertPercentile("Zone of truth", 99, 100);
        }
    }
}