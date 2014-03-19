using EquipmentGen.Tests.Integration.Tables.TestAttributes;
using NUnit.Framework;

namespace EquipmentGen.Tests.Integration.Tables.Items.MagicalItems.Scrolls.Divine
{
    [TestFixture, PercentileTable("Level2DivineSpells")]
    public class Level2DivineSpellsTests : PercentileTests
    {
        [Test]
        public void AnimalMessengerPercentile()
        {
            AssertContent("Animal messenger", 1);
        }

        [Test]
        public void AnimalTrancePercentile()
        {
            AssertContent("Animal trance", 2);
        }

        [Test]
        public void AuguryPercentile()
        {
            AssertContent("Augury", 3, 4);
        }

        [Test]
        public void BarkskinPercentile()
        {
            AssertContent("Barkskin", 5, 6);
        }

        [Test]
        public void BearsEndurancePercentile()
        {
            AssertContent("Bear's endurance", 7, 9);
        }

        [Test]
        public void BullsStrengthPercentile()
        {
            AssertContent("Bull's strength", 10, 12);
        }

        [Test]
        public void CalmEmotionsPercentile()
        {
            AssertContent("Calm emotions", 13, 14);
        }

        [Test]
        public void CatsGracePercentile()
        {
            AssertContent("Cat's grace", 15, 17);
        }

        [Test]
        public void ChillMetalPercentile()
        {
            AssertContent("Chill metal", 18);
        }

        [Test]
        public void ConsecratePercentile()
        {
            AssertContent("Consecrate", 19, 20);
        }

        [Test]
        public void CureModerateWoundsPercentile()
        {
            AssertContent("Cure moderate wounds", 21, 24);
        }

        [Test]
        public void DarknessPercentile()
        {
            AssertContent("Darkness", 25, 26);
        }

        [Test]
        public void DeathKnellPercentile()
        {
            AssertContent("Death knell", 27);
        }

        [Test]
        public void DelayPoisonPercentile()
        {
            AssertContent("Delay poison", 28, 30);
        }

        [Test]
        public void DesecratePercentile()
        {
            AssertContent("Desecrate", 31, 32);
        }

        [Test]
        public void EaglesSplendorPercentile()
        {
            AssertContent("Eagle's splendor", 33, 35);
        }

        [Test]
        public void EnthrallPercentile()
        {
            AssertContent("Enthrall", 36, 37);
        }

        [Test]
        public void FindTrapsPercentile()
        {
            AssertContent("Find traps", 38, 39);
        }

        [Test]
        public void FireTrapPercentile()
        {
            AssertContent("Fire trap", 40);
        }

        [Test]
        public void FlameBladePercentile()
        {
            AssertContent("Flame blade", 41, 42);
        }

        [Test]
        public void FlamingSpherePercentile()
        {
            AssertContent("Flaming sphere", 43, 44);
        }

        [Test]
        public void FogCloudPercentile()
        {
            AssertContent("Fog cloud", 45, 46);
        }

        [Test]
        public void GentleReposePercentile()
        {
            AssertContent("Gentle repose", 47);
        }

        [Test]
        public void GustOfWindPercentile()
        {
            AssertContent("Gust of wind", 48);
        }

        [Test]
        public void HeatMetalPercentile()
        {
            AssertContent("Heat metal", 49);
        }

        [Test]
        public void HoldAnimalPercentile()
        {
            AssertContent("Hold animal", 50, 51);
        }

        [Test]
        public void HoldPersonPercentile()
        {
            AssertContent("Hold person", 52, 54);
        }

        [Test]
        public void InflictModerateWoundsPercentile()
        {
            AssertContent("Inflict moderate wounds", 55, 56);
        }

        [Test]
        public void MakeWholePercentile()
        {
            AssertContent("Make whole", 57, 58);
        }

        [Test]
        public void OwlsWisdomPercentile()
        {
            AssertContent("Owl's wisdom", 59, 61);
        }

        [Test]
        public void ReduceAnimalPercentile()
        {
            AssertContent("Reduce animal", 62);
        }

        [Test]
        public void RemoveParalysisPercentile()
        {
            AssertContent("Remove paralysis", 63, 64);
        }

        [Test]
        public void ResistEnergyPercentile()
        {
            AssertContent("Resist energy", 65, 67);
        }

        [Test]
        public void LesserRestorationPercentile()
        {
            AssertContent("Lesser restoration", 68, 70);
        }

        [Test]
        public void ShatterPercentile()
        {
            AssertContent("Shatter", 71, 72);
        }

        [Test]
        public void ShieldOtherPercentile()
        {
            AssertContent("Shield other", 73, 74);
        }

        [Test]
        public void SilencePercentile()
        {
            AssertContent("Silence", 75, 76);
        }

        [Test]
        public void SnarePercentile()
        {
            AssertContent("Snare", 77);
        }

        [Test]
        public void SoftenEarthAndStonePercentile()
        {
            AssertContent("Soften earth and stone", 78);
        }

        [Test]
        public void SoundBurstPercentile()
        {
            AssertContent("Sound burst", 79, 80);
        }

        [Test]
        public void SpeakWithPlantsPercentile()
        {
            AssertContent("Speak with plants", 81);
        }

        [Test]
        public void SpiderClimbPercentile()
        {
            AssertContent("Spider climb", 82, 83);
        }

        [Test]
        public void SpiritualWeaponPercentile()
        {
            AssertContent("Spiritual weapon", 84, 85);
        }

        [Test]
        public void StatusPercentile()
        {
            AssertContent("Status", 86);
        }

        [Test]
        public void SummonMonsterIIPercentile()
        {
            AssertContent("Summon monster II", 87, 88);
        }

        [Test]
        public void SummonNaturesAllyIIPercentile()
        {
            AssertContent("Summon nature's ally II", 89, 90);
        }

        [Test]
        public void SummonSwarmPercentile()
        {
            AssertContent("Summon swarm", 91, 92);
        }

        [Test]
        public void TreeShapePercentile()
        {
            AssertContent("Tree shape", 93);
        }

        [Test]
        public void UndetectableAlignmentPercentile()
        {
            AssertContent("Undetectable alignment", 94, 95);
        }

        [Test]
        public void WarpWoodPercentile()
        {
            AssertContent("Warp wood", 96, 97);
        }

        [Test]
        public void WoodShapePercentile()
        {
            AssertContent("Wood shape", 98);
        }

        [Test]
        public void ZoneOfTruthPercentile()
        {
            AssertContent("Zone of truth", 99, 100);
        }
    }
}