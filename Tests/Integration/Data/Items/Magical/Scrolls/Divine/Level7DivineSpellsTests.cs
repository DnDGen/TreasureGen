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
            AssertPercentile("Animate plants", 1, 5);
        }

        [Test]
        public void BlasphemyPercentile()
        {
            AssertPercentile("Blasphemy", 6, 9);
        }

        [Test]
        public void ChangestaffPercentile()
        {
            AssertPercentile("Changestaff", 10, 14);
        }

        [Test]
        public void ControlWeatherPercentile()
        {
            AssertPercentile("Control weather", 15, 16);
        }

        [Test]
        public void CreepingDoomPercentile()
        {
            AssertPercentile("Creeping doom", 17, 21);
        }

        [Test]
        public void MassCureSeriousWoundsPercentile()
        {
            AssertPercentile("Mass cure serious wounds", 22, 27);
        }

        [Test]
        public void DestructionPercentile()
        {
            AssertPercentile("Destruction", 28, 32);
        }

        [Test]
        public void DictumPercentile()
        {
            AssertPercentile("Dictum", 33, 36);
        }

        [Test]
        public void EtherealJauntPercentile()
        {
            AssertPercentile("Ethereal jaunt", 37, 41);
        }

        [Test]
        public void HolyWordPercentile()
        {
            AssertPercentile("Holy word", 42, 45);
        }

        [Test]
        public void MassInflictSeriousWoundsPercentile()
        {
            AssertPercentile("Mass inflict serious wounds", 46, 50);
        }

        [Test]
        public void RefugePercentile()
        {
            AssertPercentile("Refuge", 51, 55);
        }

        [Test]
        public void RegeneratePercentile()
        {
            AssertPercentile("Regenerate", 56, 60);
        }

        [Test]
        public void RepulsionPercentile()
        {
            AssertPercentile("Repulsion", 61, 65);
        }

        [Test]
        public void GreaterRestorationPercentile()
        {
            AssertPercentile("Greater restoration", 66, 69);
        }

        [Test]
        public void ResurrectionPercentile()
        {
            AssertPercentile("Resurrection", 70, 71);
        }

        [Test]
        public void GreaterScryingPercentile()
        {
            AssertPercentile("Greater scrying", 72, 76);
        }

        [Test]
        public void SummonMonsterVIIPercentile()
        {
            AssertPercentile("Summon monster VII", 77, 81);
        }

        [Test]
        public void SummonNaturesAllyVIIPercentile()
        {
            AssertPercentile("Summon nature's ally VII", 82, 85);
        }

        [Test]
        public void SunbeamPercentile()
        {
            AssertPercentile("Sunbeam", 86, 90);
        }

        [Test]
        public void SymbolOfStunningPercentile()
        {
            AssertPercentile("Symbol of stunning", 91);
        }

        [Test]
        public void SymbolOfWeaknessPercentile()
        {
            AssertPercentile("Symbol of weakness", 92);
        }

        [Test]
        public void TransmuteMetalToWoodPercentile()
        {
            AssertPercentile("Transmute metal to wood", 93, 97);
        }

        [Test]
        public void WordOfChaosPercentile()
        {
            AssertPercentile("Word of chaos", 98, 100);
        }
    }
}