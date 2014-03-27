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
            AssertPercentile("Alarm", 1, 3);
        }

        [Test]
        public void AnimateRopePercentile()
        {
            AssertPercentile("Animate rope", 4, 5);
        }

        [Test]
        public void BurningHandsPercentile()
        {
            AssertPercentile("Burning hands", 6, 7);
        }

        [Test]
        public void CauseFearPercentile()
        {
            AssertPercentile("Cause fear", 8, 9);
        }

        [Test]
        public void CharmPersonPercentile()
        {
            AssertPercentile("Charm person", 10, 12);
        }

        [Test]
        public void ChillTouchPercentile()
        {
            AssertPercentile("Chill touch", 13, 14);
        }

        [Test]
        public void ColorSprayPercentile()
        {
            AssertPercentile("Color spray", 15, 16);
        }

        [Test]
        public void ComprehendLanguagesPercentile()
        {
            AssertPercentile("Comprehend languages", 17, 19);
        }

        [Test]
        public void LesserConfusionPercentile()
        {
            AssertPercentile("Lesser confusion", 20);
        }

        [Test]
        public void CureLightWoundsPercentile()
        {
            AssertPercentile("Cure light wounds", 21);
        }

        [Test]
        public void DetectSecretDoorsPercentile()
        {
            AssertPercentile("Detect secret doors", 22, 24);
        }

        [Test]
        public void DetectUndeadPercentile()
        {
            AssertPercentile("Detect undead", 25, 26);
        }

        [Test]
        public void DisguiseSelfPercentile()
        {
            AssertPercentile("Disguise self", 27, 29);
        }

        [Test]
        public void EndureElementsPercentile()
        {
            AssertPercentile("Endure elements", 30, 32);
        }

        [Test]
        public void EnlargePersonPercentile()
        {
            AssertPercentile("Enlarge person", 33, 35);
        }

        [Test]
        public void ErasePercentile()
        {
            AssertPercentile("Erase", 36, 37);
        }

        [Test]
        public void ExpeditiousRetreatPercentile()
        {
            AssertPercentile("Expeditious retreat", 38, 40);
        }

        [Test]
        public void FeatherFallPercentile()
        {
            AssertPercentile("Feather fall", 41);
        }

        [Test]
        public void GreasePercentile()
        {
            AssertPercentile("Grease", 42, 43);
        }

        [Test]
        public void HoldPortalPercentile()
        {
            AssertPercentile("Hold portal", 44, 45);
        }

        [Test]
        public void HypnotismPercentile()
        {
            AssertPercentile("Hypnotism", 46, 47);
        }

        [Test]
        public void IdentifyPercentile()
        {
            AssertPercentile("Identify", 48, 49);
        }

        [Test]
        public void JumpPercentile()
        {
            AssertPercentile("Jump", 50, 51);
        }

        [Test]
        public void MageArmorPercentile()
        {
            AssertPercentile("Mage armor", 52, 54);
        }

        [Test]
        public void MagicMissilePercentile()
        {
            AssertPercentile("Magic missile", 55, 56);
        }

        [Test]
        public void MagicWeaponPercentile()
        {
            AssertPercentile("Magic weapon", 57, 59);
        }

        [Test]
        public void MountPercentile()
        {
            AssertPercentile("Mount", 60, 62);
        }

        [Test]
        public void NystulsMagicAuraPercentile()
        {
            AssertPercentile("Nystul's magic aura", 63, 64);
        }

        [Test]
        public void ObscuringMistPercentile()
        {
            AssertPercentile("Obscuring mist", 65, 66);
        }

        [Test]
        public void ProtectionFromChaosOrEvilOrGoodOrLawPercentile()
        {
            AssertPercentile("Protection from chaos/evil/good/law", 67, 74);
        }

        [Test]
        public void RayOfEnfeeblementPercentile()
        {
            AssertPercentile("Ray of enfeeblement", 75, 76);
        }

        [Test]
        public void ReducePersonPercentile()
        {
            AssertPercentile("Reduce person", 77, 78);
        }

        [Test]
        public void RemoveFearPercentile()
        {
            AssertPercentile("Remove fear", 79, 80);
        }

        [Test]
        public void ShieldPercentile()
        {
            AssertPercentile("Shield", 81, 82);
        }

        [Test]
        public void ShockingGraspPercentile()
        {
            AssertPercentile("Shocking grasp", 83, 84);
        }

        [Test]
        public void SilentImagePercentile()
        {
            AssertPercentile("Silent image", 85, 86);
        }

        [Test]
        public void SleepPercentile()
        {
            AssertPercentile("Sleep", 87, 88);
        }

        [Test]
        public void SummonMonsterIPercentile()
        {
            AssertPercentile("Summon monster I", 89, 90);
        }

        [Test]
        public void TensersFloatingDiscPercentile()
        {
            AssertPercentile("Tenser's floating disc", 91, 93);
        }

        [Test]
        public void TrueStrikePercentile()
        {
            AssertPercentile("True strike", 94, 95);
        }

        [Test]
        public void UndetectableAlignmentPercentile()
        {
            AssertPercentile("Undetectable alignment", 96);
        }

        [Test]
        public void UnseenServantPercentile()
        {
            AssertPercentile("Unseen servant", 97, 98);
        }

        [Test]
        public void VentriloquismPercentile()
        {
            AssertPercentile("Ventriloquism", 99, 100);
        }
    }
}