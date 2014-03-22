using EquipmentGen.Tests.Integration.Tables.TestAttributes;
using NUnit.Framework;

namespace EquipmentGen.Tests.Integration.Tables.Items.MagicalItems.Scrolls.Divine
{
    [TestFixture, PercentileTable("Level7DivineSpells")]
    public class Level7DivineSpellsTests : PercentileTests
    {
        [Test]
        public void AnimatePlantsPercentile()
        {
            AssertContent("Animate plants", 1, 5);
        }

        [Test]
        public void BlasphemyPercentile()
        {
            AssertContent("Blasphemy", 6, 9);
        }

        [Test]
        public void ChangestaffPercentile()
        {
            AssertContent("Changestaff", 10, 14);
        }

        [Test]
        public void ControlWeatherPercentile()
        {
            AssertContent("Control weather", 15, 16);
        }

        [Test]
        public void CreepingDoomPercentile()
        {
            AssertContent("Creeping doom", 17, 21);
        }

        [Test]
        public void MassCureSeriousWoundsPercentile()
        {
            AssertContent("Mass cure serious wounds", 22, 27);
        }

        [Test]
        public void DestructionPercentile()
        {
            AssertContent("Destruction", 28, 32);
        }

        [Test]
        public void DictumPercentile()
        {
            AssertContent("Dictum", 33, 36);
        }

        [Test]
        public void EtherealJauntPercentile()
        {
            AssertContent("Ethereal jaunt", 37, 41);
        }

        [Test]
        public void HolyWordPercentile()
        {
            AssertContent("Holy word", 42, 45);
        }

        [Test]
        public void MassInflictSeriousWoundsPercentile()
        {
            AssertContent("Mass inflict serious wounds", 46, 50);
        }

        [Test]
        public void RefugePercentile()
        {
            AssertContent("Refuge", 51, 55);
        }

        [Test]
        public void RegeneratePercentile()
        {
            AssertContent("Regenerate", 56, 60);
        }

        [Test]
        public void RepulsionPercentile()
        {
            AssertContent("Repulsion", 61, 65);
        }

        [Test]
        public void GreaterRestorationPercentile()
        {
            AssertContent("Greater restoration", 66, 69);
        }

        [Test]
        public void ResurrectionPercentile()
        {
            AssertContent("Resurrection", 70, 71);
        }

        [Test]
        public void GreaterScryingPercentile()
        {
            AssertContent("Greater scrying", 72, 76);
        }

        [Test]
        public void SummonMonsterVIIPercentile()
        {
            AssertContent("Summon monster VII", 77, 81);
        }

        [Test]
        public void SummonNaturesAllyVIIPercentile()
        {
            AssertContent("Summon nature's ally VII", 82, 85);
        }

        [Test]
        public void SunbeamPercentile()
        {
            AssertContent("Sunbeam", 86, 90);
        }

        [Test]
        public void SymbolOfStunningPercentile()
        {
            AssertContent("Symbol of stunning", 91);
        }

        [Test]
        public void SymbolOfWeaknessPercentile()
        {
            AssertContent("Symbol of weakness", 92);
        }

        [Test]
        public void TransmuteMetalToWoodPercentile()
        {
            AssertContent("Transmute metal to wood", 93, 97);
        }

        [Test]
        public void WordOfChaosPercentile()
        {
            AssertContent("Word of chaos", 98, 100);
        }
    }
}