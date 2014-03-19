using EquipmentGen.Tests.Integration.Tables.TestAttributes;
using NUnit.Framework;

namespace EquipmentGen.Tests.Integration.Tables.Items.MagicalItems.Scrolls.Arcane
{
    [TestFixture, PercentileTable("Level1ArcaneSpells")]
    public class Level1ArcaneSpellsTests : PercentileTests
    {
        [Test]
        public void AlarmPercentile()
        {
            AssertContent("Alarm", 1, 3);
        }

        [Test]
        public void AnimateRopePercentile()
        {
            AssertContent("Animate rope", 4, 5);
        }

        [Test]
        public void BurningHandsPercentile()
        {
            AssertContent("Burning hands", 6, 7);
        }

        [Test]
        public void CauseFearPercentile()
        {
            AssertContent("Cause fear", 8, 9);
        }

        [Test]
        public void CharmPersonPercentile()
        {
            AssertContent("Charm person", 10, 12);
        }

        [Test]
        public void ChillTouchPercentile()
        {
            AssertContent("Chill touch", 13, 14);
        }

        [Test]
        public void ColorSprayPercentile()
        {
            AssertContent("Color spray", 15, 16);
        }

        [Test]
        public void ComprehendLanguagesPercentile()
        {
            AssertContent("Comprehend languages", 17, 19);
        }

        [Test]
        public void LesserConfusionPercentile()
        {
            AssertContent("Lesser confusion", 20);
        }

        [Test]
        public void CureLightWoundsPercentile()
        {
            AssertContent("Cure light wounds", 21);
        }

        [Test]
        public void DetectSecretDoorsPercentile()
        {
            AssertContent("Detect secret doors", 22, 24);
        }

        [Test]
        public void DetectUndeadPercentile()
        {
            AssertContent("Detect undead", 25, 26);
        }

        [Test]
        public void DisguiseSelfPercentile()
        {
            AssertContent("Disguise self", 27, 29);
        }

        [Test]
        public void EndureElementsPercentile()
        {
            AssertContent("Endure elements", 30, 32);
        }

        [Test]
        public void EnlargePersonPercentile()
        {
            AssertContent("Enlarge person", 33, 35);
        }

        [Test]
        public void ErasePercentile()
        {
            AssertContent("Erase", 36, 37);
        }

        [Test]
        public void ExpeditiousRetreatPercentile()
        {
            AssertContent("Expeditious retreat", 38, 40);
        }

        [Test]
        public void FeatherFallPercentile()
        {
            AssertContent("Feather fall", 41);
        }

        [Test]
        public void GreasePercentile()
        {
            AssertContent("Grease", 42, 43);
        }

        [Test]
        public void HoldPortalPercentile()
        {
            AssertContent("Hold portal", 44, 45);
        }

        [Test]
        public void HypnotismPercentile()
        {
            AssertContent("Hypnotism", 46, 47);
        }

        [Test]
        public void IdentifyPercentile()
        {
            AssertContent("Identify", 48, 49);
        }

        [Test]
        public void JumpPercentile()
        {
            AssertContent("Jump", 50, 51);
        }

        [Test]
        public void MageArmorPercentile()
        {
            AssertContent("Mage armor", 52, 54);
        }

        [Test]
        public void MagicMissilePercentile()
        {
            AssertContent("Magic missile", 55, 56);
        }

        [Test]
        public void MagicWeaponPercentile()
        {
            AssertContent("Magic weapon", 57, 59);
        }

        [Test]
        public void MountPercentile()
        {
            AssertContent("Mount", 60, 62);
        }

        [Test]
        public void NystulsMagicAuraPercentile()
        {
            AssertContent("Nystul's magic aura", 63, 64);
        }

        [Test]
        public void ObscuringMistPercentile()
        {
            AssertContent("Obscuring mist", 65, 66);
        }

        [Test]
        public void ProtectionFromChaosOrEvilOrGoodOrLawPercentile()
        {
            AssertContent("Protection from chaos/evil/good/law", 67, 74);
        }

        [Test]
        public void RayOfEnfeeblementPercentile()
        {
            AssertContent("Ray of enfeeblement", 75, 76);
        }

        [Test]
        public void ReducePersonPercentile()
        {
            AssertContent("Reduce person", 77, 78);
        }

        [Test]
        public void RemoveFearPercentile()
        {
            AssertContent("Remove fear", 79, 80);
        }

        [Test]
        public void ShieldPercentile()
        {
            AssertContent("Shield", 81, 82);
        }

        [Test]
        public void ShockingGraspPercentile()
        {
            AssertContent("Shocking grasp", 83, 84);
        }

        [Test]
        public void SilentImagePercentile()
        {
            AssertContent("Silent image", 85, 86);
        }

        [Test]
        public void SleepPercentile()
        {
            AssertContent("Sleep", 87, 88);
        }

        [Test]
        public void SummonMonsterIPercentile()
        {
            AssertContent("Summon monster I", 89, 90);
        }

        [Test]
        public void TensersFloatingDiscPercentile()
        {
            AssertContent("Tenser's floating disc", 91, 93);
        }

        [Test]
        public void TrueStrikePercentile()
        {
            AssertContent("True strike", 94, 95);
        }

        [Test]
        public void UndetectableAlignmentPercentile()
        {
            AssertContent("Undetectable alignment", 96);
        }

        [Test]
        public void UnseenServantPercentile()
        {
            AssertContent("Unseen servant", 97, 98);
        }

        [Test]
        public void VentriloquismPercentile()
        {
            AssertContent("Ventriloquism", 99, 100);
        }
    }
}