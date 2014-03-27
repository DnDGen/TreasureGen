using EquipmentGen.Tests.Integration.Tables.TestAttributes;
using NUnit.Framework;

namespace EquipmentGen.Tests.Integration.Tables.Items.MagicalItems.Scrolls.Arcane
{
    [TestFixture, PercentileTable("Level2ArcaneSpells")]
    public class Level2ArcaneSpellsTests : PercentileTests
    {
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
        public void ArcaneLockPercentile()
        {
            AssertPercentile("Arcane lock", 3);
        }

        [Test]
        public void BearsEndurancePercentile()
        {
            AssertPercentile("Bear's endurance", 4, 6);
        }

        [Test]
        public void BlindnessDeafnessPercentile()
        {
            AssertPercentile("Blindness/deafness", 7, 8);
        }

        [Test]
        public void BlurPercentile()
        {
            AssertPercentile("Blur", 9, 10);
        }

        [Test]
        public void BullsStrengthPercentile()
        {
            AssertPercentile("Bull's strength", 11, 13);
        }

        [Test]
        public void CalmEmotionsPercentile()
        {
            AssertPercentile("Calm emotions", 14);
        }

        [Test]
        public void CatsGracePercentile()
        {
            AssertPercentile("Cat's grace", 15, 17);
        }

        [Test]
        public void CommandUndeadPercentile()
        {
            AssertPercentile("Command undead", 18, 19);
        }

        [Test]
        public void ContinualFlamePercentile()
        {
            AssertPercentile("Continual flame", 20);
        }

        [Test]
        public void CureModerateWoundsPercentile()
        {
            AssertPercentile("Cure moderate wounds", 21);
        }

        [Test]
        public void DarknessPercentile()
        {
            AssertPercentile("Darkness", 22);
        }

        [Test]
        public void DarkvisionPercentile()
        {
            AssertPercentile("Darkvision", 23, 25);
        }

        [Test]
        public void DazeMonsterPercentile()
        {
            AssertPercentile("Daze monster", 26);
        }

        [Test]
        public void DelayPoisonPercentile()
        {
            AssertPercentile("Delay poison", 27);
        }

        [Test]
        public void DetectThoughtsPercentile()
        {
            AssertPercentile("Detect thoughts", 28, 29);
        }

        [Test]
        public void DisguiseSelfPercentile()
        {
            AssertPercentile("Disguise self", 30, 31);
        }

        [Test]
        public void EaglesSplendorPercentile()
        {
            AssertPercentile("Eagle's splendor", 32, 34);
        }

        [Test]
        public void EnthrallPercentile()
        {
            AssertPercentile("Enthrall", 35);
        }

        [Test]
        public void FalseLifePercentile()
        {
            AssertPercentile("False life", 36, 37);
        }

        [Test]
        public void FlamingSpherePercentile()
        {
            AssertPercentile("Flaming sphere", 38, 39);
        }

        [Test]
        public void FogCloudPercentile()
        {
            AssertPercentile("Fog cloud", 40);
        }

        [Test]
        public void FoxsCunningPercentile()
        {
            AssertPercentile("Fox's cunning", 41, 43);
        }

        [Test]
        public void GhoulTouchPercentile()
        {
            AssertPercentile("Ghoul touch", 44);
        }

        [Test]
        public void GlitterdustPercentile()
        {
            AssertPercentile("Glitterdust", 45, 46);
        }

        [Test]
        public void GustOfWindPercentile()
        {
            AssertPercentile("Gust of wind", 47);
        }

        [Test]
        public void HypnoticPatternPercentile()
        {
            AssertPercentile("Hypnotic pattern", 48, 49);
        }

        [Test]
        public void InvisibilityPercentile()
        {
            AssertPercentile("Invisibility", 50, 52);
        }

        [Test]
        public void KnockPercentile()
        {
            AssertPercentile("Knock", 53, 55);
        }

        [Test]
        public void LeomundsTrapPercentile()
        {
            AssertPercentile("Leomund's trap", 56);
        }

        [Test]
        public void LevitatePercentile()
        {
            AssertPercentile("Levitate", 57, 58);
        }

        [Test]
        public void LocateObjectPercentile()
        {
            AssertPercentile("Locate object", 59);
        }

        [Test]
        public void MagicMouthPercentile()
        {
            AssertPercentile("Magic mouth", 60);
        }

        [Test]
        public void MelfsAcidArrowPercentile()
        {
            AssertPercentile("Melf's acid arrow", 61, 62);
        }

        [Test]
        public void MinorImagePercentile()
        {
            AssertPercentile("Minor image", 63);
        }

        [Test]
        public void MirrorImagePercentile()
        {
            AssertPercentile("Mirror image", 64, 65);
        }

        [Test]
        public void MisdirectionPercentile()
        {
            AssertPercentile("Misdirection", 66);
        }

        [Test]
        public void ObscureObjectPercentile()
        {
            AssertPercentile("Obscure object", 67);
        }

        [Test]
        public void OwlsWisdomPercentile()
        {
            AssertPercentile("Owl's wisdom", 68, 70);
        }

        [Test]
        public void ProtectionFromArrowsPercentile()
        {
            AssertPercentile("Protection from arrows", 71, 73);
        }

        [Test]
        public void PyrotechnicsPercentile()
        {
            AssertPercentile("Pyrotechnics", 74, 75);
        }

        [Test]
        public void ResistEnergyPercentile()
        {
            AssertPercentile("Resist energy", 76, 78);
        }

        [Test]
        public void RopeTrickPercentile()
        {
            AssertPercentile("Rope trick", 79);
        }

        [Test]
        public void ScarePercentile()
        {
            AssertPercentile("Scare", 80);
        }

        [Test]
        public void ScorchingRayPercentile()
        {
            AssertPercentile("Scorching ray", 81, 82);
        }

        [Test]
        public void SeeInvisibilityPercentile()
        {
            AssertPercentile("See invisibility", 83, 85);
        }

        [Test]
        public void ShatterPercentile()
        {
            AssertPercentile("Shatter", 86);
        }

        [Test]
        public void SilencePercentile()
        {
            AssertPercentile("Silence", 87);
        }

        [Test]
        public void SoundBurstPercentile()
        {
            AssertPercentile("Sound burst", 88);
        }

        [Test]
        public void SpectralHandPercentile()
        {
            AssertPercentile("Spectral hand", 89);
        }

        [Test]
        public void SpiderClimbPercentile()
        {
            AssertPercentile("Spider climb", 90, 91);
        }

        [Test]
        public void SummonMonsterIIPercentile()
        {
            AssertPercentile("Summon monster II", 92, 93);
        }

        [Test]
        public void SummonSwarmPercentile()
        {
            AssertPercentile("Summon swarm", 94, 95);
        }

        [Test]
        public void TashasHideousLaughterPercentile()
        {
            AssertPercentile("Tasha's hideous laughter", 96);
        }

        [Test]
        public void TouchOfIdiocyPercentile()
        {
            AssertPercentile("Touch of idiocy", 97);
        }

        [Test]
        public void WebPercentile()
        {
            AssertPercentile("Web", 98, 99);
        }

        [Test]
        public void WhisperingWindPercentile()
        {
            AssertPercentile("Whispering wind", 100);
        }
    }
}