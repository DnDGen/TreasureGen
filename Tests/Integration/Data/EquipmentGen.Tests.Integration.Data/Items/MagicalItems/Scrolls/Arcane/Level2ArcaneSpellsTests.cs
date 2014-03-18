using EquipmentGen.Tests.Integration.Data.Attributes;
using NUnit.Framework;

namespace EquipmentGen.Tests.Integration.Data.Items.MagicalItems.Scrolls.Arcane
{
    [TestFixture, PercentileTable("Level2ArcaneSpells")]
    public class Level2ArcaneSpellsTests : PercentileTests
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
        public void ArcaneLockPercentile()
        {
            AssertContent("Arcane lock", 3);
        }

        [Test]
        public void BearsEndurancePercentile()
        {
            AssertContent("Bear's endurance", 4, 6);
        }

        [Test]
        public void BlindnessDeafnessPercentile()
        {
            AssertContent("Blindness/deafness", 7, 8);
        }

        [Test]
        public void BlurPercentile()
        {
            AssertContent("Blur", 9, 10);
        }

        [Test]
        public void BullsStrengthPercentile()
        {
            AssertContent("Bull's strength", 11, 13);
        }

        [Test]
        public void CalmEmotionsPercentile()
        {
            AssertContent("Calm emotions", 14);
        }

        [Test]
        public void CatsGracePercentile()
        {
            AssertContent("Cat's grace", 15, 17);
        }

        [Test]
        public void CommandUndeadPercentile()
        {
            AssertContent("Command undead", 18, 19);
        }

        [Test]
        public void ContinualFlamePercentile()
        {
            AssertContent("Continual flame", 20);
        }

        [Test]
        public void CureModerateWoundsPercentile()
        {
            AssertContent("Cure moderate wounds", 21);
        }

        [Test]
        public void DarknessPercentile()
        {
            AssertContent("Darkness", 22);
        }

        [Test]
        public void DarkvisionPercentile()
        {
            AssertContent("Darkvision", 23, 25);
        }

        [Test]
        public void DazeMonsterPercentile()
        {
            AssertContent("Daze monster", 26);
        }

        [Test]
        public void DelayPoisonPercentile()
        {
            AssertContent("Delay poison", 27);
        }

        [Test]
        public void DetectThoughtsPercentile()
        {
            AssertContent("Detect thoughts", 28, 29);
        }

        [Test]
        public void DisguiseSelfPercentile()
        {
            AssertContent("Disguise self", 30, 31);
        }

        [Test]
        public void EaglesSplendorPercentile()
        {
            AssertContent("Eagle's splendor", 32, 34);
        }

        [Test]
        public void EnthrallPercentile()
        {
            AssertContent("Enthrall", 35);
        }

        [Test]
        public void FalseLifePercentile()
        {
            AssertContent("False life", 36, 37);
        }

        [Test]
        public void FlamingSpherePercentile()
        {
            AssertContent("Flaming sphere", 38, 39);
        }

        [Test]
        public void FogCloudPercentile()
        {
            AssertContent("Fog cloud", 40);
        }

        [Test]
        public void FoxsCunningPercentile()
        {
            AssertContent("Fox's cunning", 41, 43);
        }

        [Test]
        public void GhoulTouchPercentile()
        {
            AssertContent("Ghoul touch", 44);
        }

        [Test]
        public void GlitterdustPercentile()
        {
            AssertContent("Glitterdust", 45, 46);
        }

        [Test]
        public void GustOfWindPercentile()
        {
            AssertContent("Gust of wind", 47);
        }

        [Test]
        public void HypnoticPatternPercentile()
        {
            AssertContent("Hypnotic pattern", 48, 49);
        }

        [Test]
        public void InvisibilityPercentile()
        {
            AssertContent("Invisibility", 50, 52);
        }

        [Test]
        public void KnockPercentile()
        {
            AssertContent("Knock", 53, 55);
        }

        [Test]
        public void LeomundsTrapPercentile()
        {
            AssertContent("Leomund's trap", 56);
        }

        [Test]
        public void LevitatePercentile()
        {
            AssertContent("Levitate", 57, 58);
        }

        [Test]
        public void LocateObjectPercentile()
        {
            AssertContent("Locate object", 59);
        }

        [Test]
        public void MagicMouthPercentile()
        {
            AssertContent("Magic mouth", 60);
        }

        [Test]
        public void MelfsAcidArrowPercentile()
        {
            AssertContent("Melf's acid arrow", 61, 62);
        }

        [Test]
        public void MinorImagePercentile()
        {
            AssertContent("Minor image", 63);
        }

        [Test]
        public void MirrorImagePercentile()
        {
            AssertContent("Mirror image", 64, 65);
        }

        [Test]
        public void MisdirectionPercentile()
        {
            AssertContent("Misdirection", 66);
        }

        [Test]
        public void ObscureObjectPercentile()
        {
            AssertContent("Obscure object", 67);
        }

        [Test]
        public void OwlsWisdomPercentile()
        {
            AssertContent("Owl's wisdom", 68, 70);
        }

        [Test]
        public void ProtectionFromArrowsPercentile()
        {
            AssertContent("Protection from arrows", 71, 73);
        }

        [Test]
        public void PyrotechnicsPercentile()
        {
            AssertContent("Pyrotechnics", 74, 75);
        }

        [Test]
        public void ResistEnergyPercentile()
        {
            AssertContent("Resist energy", 76, 78);
        }

        [Test]
        public void RopeTrickPercentile()
        {
            AssertContent("Rope trick", 79);
        }

        [Test]
        public void ScarePercentile()
        {
            AssertContent("Scare", 80);
        }

        [Test]
        public void ScorchingRayPercentile()
        {
            AssertContent("Scorching ray", 81, 82);
        }

        [Test]
        public void SeeInvisibilityPercentile()
        {
            AssertContent("See invisibility", 83, 85);
        }

        [Test]
        public void ShatterPercentile()
        {
            AssertContent("Shatter", 86);
        }

        [Test]
        public void SilencePercentile()
        {
            AssertContent("Silence", 87);
        }

        [Test]
        public void SoundBurstPercentile()
        {
            AssertContent("Sound burst", 88);
        }

        [Test]
        public void SpectralHandPercentile()
        {
            AssertContent("Spectral hand", 89);
        }

        [Test]
        public void SpiderClimbPercentile()
        {
            AssertContent("Spider climb", 90, 91);
        }

        [Test]
        public void SummonMonsterIIPercentile()
        {
            AssertContent("Summon monster II", 92, 93);
        }

        [Test]
        public void SummonSwarmPercentile()
        {
            AssertContent("Summon swarm", 94, 95);
        }

        [Test]
        public void TashasHideousLaughterPercentile()
        {
            AssertContent("Tasha's hideous laughter", 96);
        }

        [Test]
        public void TouchOfIdiocyPercentile()
        {
            AssertContent("Touch of idiocy", 97);
        }

        [Test]
        public void WebPercentile()
        {
            AssertContent("Web", 98, 99);
        }

        [Test]
        public void WhisperingWindPercentile()
        {
            AssertContent("Whispering wind", 100);
        }
    }
}