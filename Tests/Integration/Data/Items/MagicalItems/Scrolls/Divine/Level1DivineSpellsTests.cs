using EquipmentGen.Tests.Integration.Tables.TestAttributes;
using NUnit.Framework;

namespace EquipmentGen.Tests.Integration.Tables.Items.MagicalItems.Scrolls.Divine
{
    [TestFixture, PercentileTable("Level1DivineSpells")]
    public class Level1DivineSpellsTests : PercentileTests
    {
        [Test]
        public void AlarmPercentile()
        {
            AssertContent("Alarm", 1);
        }

        [Test]
        public void BanePercentile()
        {
            AssertContent("Bane", 2, 3);
        }

        [Test]
        public void BlessPercentile()
        {
            AssertContent("Bless", 4, 6);
        }

        [Test]
        public void BlessWaterPercentile()
        {
            AssertContent("Bless water", 7, 9);
        }

        [Test]
        public void BlessWeaponPercentile()
        {
            AssertContent("Bless weapon", 10);
        }

        [Test]
        public void CalmAnimalsPercentile()
        {
            AssertContent("Calm animals", 11, 12);
        }

        [Test]
        public void CauseFearPercentile()
        {
            AssertContent("Cause fear", 13, 14);
        }

        [Test]
        public void CharmAnimalPercentile()
        {
            AssertContent("Charm animal", 15, 16);
        }

        [Test]
        public void CommandPercentile()
        {
            AssertContent("Command", 17, 19);
        }

        [Test]
        public void ComprehendLanguagesPercentile()
        {
            AssertContent("Comprehend languages", 20, 21);
        }

        [Test]
        public void CureLightWoundsPercentile()
        {
            AssertContent("Cure light wounds", 22, 26);
        }

        [Test]
        public void CurseWaterPercentile()
        {
            AssertContent("Curse water", 27, 28);
        }

        [Test]
        public void DeathwatchPercentile()
        {
            AssertContent("Deathwatch", 29, 30);
        }

        [Test]
        public void DetectAnimalsOrPlantsPercentile()
        {
            AssertContent("Detect animals or plants", 31, 32);
        }

        [Test]
        public void DetectChaosEvilGoodLawPercentile()
        {
            AssertContent("Detect chaos/evil/good/law", 33, 35);
        }

        [Test]
        public void DetectSnaresAndPitsPercentile()
        {
            AssertContent("Detect snares and pits", 36, 37);
        }

        [Test]
        public void DetectUndeadPercentile()
        {
            AssertContent("Detect undead", 38, 39);
        }

        [Test]
        public void DivineFavorPercentile()
        {
            AssertContent("Divine favor", 40, 41);
        }

        [Test]
        public void DoomPercentile()
        {
            AssertContent("Doom", 42, 43);
        }

        [Test]
        public void EndureElementsPercentile()
        {
            AssertContent("Endure elements", 44, 48);
        }

        [Test]
        public void EntanglePercentile()
        {
            AssertContent("Entangle", 49, 50);
        }

        [Test]
        public void EntropicShieldPercentile()
        {
            AssertContent("Entropic shield", 51, 52);
        }

        [Test]
        public void FaerieFirePercentile()
        {
            AssertContent("Faerie fire", 53, 54);
        }

        [Test]
        public void GoodberryPercentile()
        {
            AssertContent("Goodberry", 55, 56);
        }

        [Test]
        public void HideFromAnimalsPercentile()
        {
            AssertContent("Hide from animals", 57, 58);
        }

        [Test]
        public void HideFromUndeadPercentile()
        {
            AssertContent("Hide from undead", 59, 60);
        }

        [Test]
        public void InflictLightWoundsPercentile()
        {
            AssertContent("Inflict light wounds", 61, 62);
        }

        [Test]
        public void JumpPercentile()
        {
            AssertContent("Jump", 63, 64);
        }

        [Test]
        public void LongstriderPercentile()
        {
            AssertContent("Longstrider", 65, 66);
        }

        [Test]
        public void MagicFangPercentile()
        {
            AssertContent("Magic fang", 67, 68);
        }

        [Test]
        public void MagicStonePercentile()
        {
            AssertContent("Magic stone", 69, 72);
        }

        [Test]
        public void MagicWeaponPercentile()
        {
            AssertContent("Magic weapon", 73, 74);
        }

        [Test]
        public void ObscuringMistPercentile()
        {
            AssertContent("Obscuring mist", 75, 78);
        }

        [Test]
        public void PassWithoutTracePercentile()
        {
            AssertContent("Pass without trace", 79, 80);
        }

        [Test]
        public void ProduceFlamePercentile()
        {
            AssertContent("Produce flame", 81, 82);
        }

        [Test]
        public void ProtectionFromChaosEvilGoodLawPercentile()
        {
            AssertContent("Protection from chaos/evil/good/law", 83, 86);
        }

        [Test]
        public void RemoveFearPercentile()
        {
            AssertContent("Remove fear", 87, 88);
        }

        [Test]
        public void SanctuaryPercentile()
        {
            AssertContent("Sanctuary", 89, 90);
        }

        [Test]
        public void ShieldOfFaithPercentile()
        {
            AssertContent("Shield of faith", 91, 92);
        }

        [Test]
        public void ShillelaghPercentile()
        {
            AssertContent("Shillelagh", 93, 94);
        }

        [Test]
        public void SpeakWithAnimalsPercentile()
        {
            AssertContent("Speak with animals", 95, 96);
        }

        [Test]
        public void SummonMonsterIPercentile()
        {
            AssertContent("Summon monster I", 97, 98);
        }

        [Test]
        public void SummonNaturesAllyIPercentile()
        {
            AssertContent("Summon nature's ally I", 99, 100);
        }
    }
}