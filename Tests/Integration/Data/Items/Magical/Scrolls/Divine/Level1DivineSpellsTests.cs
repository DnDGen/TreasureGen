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
            AssertPercentile("Alarm", 1);
        }

        [Test]
        public void BanePercentile()
        {
            AssertPercentile("Bane", 2, 3);
        }

        [Test]
        public void BlessPercentile()
        {
            AssertPercentile("Bless", 4, 6);
        }

        [Test]
        public void BlessWaterPercentile()
        {
            AssertPercentile("Bless water", 7, 9);
        }

        [Test]
        public void BlessWeaponPercentile()
        {
            AssertPercentile("Bless weapon", 10);
        }

        [Test]
        public void CalmAnimalsPercentile()
        {
            AssertPercentile("Calm animals", 11, 12);
        }

        [Test]
        public void CauseFearPercentile()
        {
            AssertPercentile("Cause fear", 13, 14);
        }

        [Test]
        public void CharmAnimalPercentile()
        {
            AssertPercentile("Charm animal", 15, 16);
        }

        [Test]
        public void CommandPercentile()
        {
            AssertPercentile("Command", 17, 19);
        }

        [Test]
        public void ComprehendLanguagesPercentile()
        {
            AssertPercentile("Comprehend languages", 20, 21);
        }

        [Test]
        public void CureLightWoundsPercentile()
        {
            AssertPercentile("Cure light wounds", 22, 26);
        }

        [Test]
        public void CurseWaterPercentile()
        {
            AssertPercentile("Curse water", 27, 28);
        }

        [Test]
        public void DeathwatchPercentile()
        {
            AssertPercentile("Deathwatch", 29, 30);
        }

        [Test]
        public void DetectAnimalsOrPlantsPercentile()
        {
            AssertPercentile("Detect animals or plants", 31, 32);
        }

        [Test]
        public void DetectChaosEvilGoodLawPercentile()
        {
            AssertPercentile("Detect chaos/evil/good/law", 33, 35);
        }

        [Test]
        public void DetectSnaresAndPitsPercentile()
        {
            AssertPercentile("Detect snares and pits", 36, 37);
        }

        [Test]
        public void DetectUndeadPercentile()
        {
            AssertPercentile("Detect undead", 38, 39);
        }

        [Test]
        public void DivineFavorPercentile()
        {
            AssertPercentile("Divine favor", 40, 41);
        }

        [Test]
        public void DoomPercentile()
        {
            AssertPercentile("Doom", 42, 43);
        }

        [Test]
        public void EndureElementsPercentile()
        {
            AssertPercentile("Endure elements", 44, 48);
        }

        [Test]
        public void EntanglePercentile()
        {
            AssertPercentile("Entangle", 49, 50);
        }

        [Test]
        public void EntropicShieldPercentile()
        {
            AssertPercentile("Entropic shield", 51, 52);
        }

        [Test]
        public void FaerieFirePercentile()
        {
            AssertPercentile("Faerie fire", 53, 54);
        }

        [Test]
        public void GoodberryPercentile()
        {
            AssertPercentile("Goodberry", 55, 56);
        }

        [Test]
        public void HideFromAnimalsPercentile()
        {
            AssertPercentile("Hide from animals", 57, 58);
        }

        [Test]
        public void HideFromUndeadPercentile()
        {
            AssertPercentile("Hide from undead", 59, 60);
        }

        [Test]
        public void InflictLightWoundsPercentile()
        {
            AssertPercentile("Inflict light wounds", 61, 62);
        }

        [Test]
        public void JumpPercentile()
        {
            AssertPercentile("Jump", 63, 64);
        }

        [Test]
        public void LongstriderPercentile()
        {
            AssertPercentile("Longstrider", 65, 66);
        }

        [Test]
        public void MagicFangPercentile()
        {
            AssertPercentile("Magic fang", 67, 68);
        }

        [Test]
        public void MagicStonePercentile()
        {
            AssertPercentile("Magic stone", 69, 72);
        }

        [Test]
        public void MagicWeaponPercentile()
        {
            AssertPercentile("Magic weapon", 73, 74);
        }

        [Test]
        public void ObscuringMistPercentile()
        {
            AssertPercentile("Obscuring mist", 75, 78);
        }

        [Test]
        public void PassWithoutTracePercentile()
        {
            AssertPercentile("Pass without trace", 79, 80);
        }

        [Test]
        public void ProduceFlamePercentile()
        {
            AssertPercentile("Produce flame", 81, 82);
        }

        [Test]
        public void ProtectionFromChaosEvilGoodLawPercentile()
        {
            AssertPercentile("Protection from chaos/evil/good/law", 83, 86);
        }

        [Test]
        public void RemoveFearPercentile()
        {
            AssertPercentile("Remove fear", 87, 88);
        }

        [Test]
        public void SanctuaryPercentile()
        {
            AssertPercentile("Sanctuary", 89, 90);
        }

        [Test]
        public void ShieldOfFaithPercentile()
        {
            AssertPercentile("Shield of faith", 91, 92);
        }

        [Test]
        public void ShillelaghPercentile()
        {
            AssertPercentile("Shillelagh", 93, 94);
        }

        [Test]
        public void SpeakWithAnimalsPercentile()
        {
            AssertPercentile("Speak with animals", 95, 96);
        }

        [Test]
        public void SummonMonsterIPercentile()
        {
            AssertPercentile("Summon monster I", 97, 98);
        }

        [Test]
        public void SummonNaturesAllyIPercentile()
        {
            AssertPercentile("Summon nature's ally I", 99, 100);
        }
    }
}