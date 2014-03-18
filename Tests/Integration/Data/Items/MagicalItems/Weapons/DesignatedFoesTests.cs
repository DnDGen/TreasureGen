using EquipmentGen.Tests.Integration.Tables.Attributes;
using NUnit.Framework;

namespace EquipmentGen.Tests.Integration.Tables.Items.MagicalItems.Weapons
{
    [TestFixture, PercentileTable("DesignatedFoes")]
    public class DesignatedFoesTests : PercentileTests
    {
        [Test]
        public void AberrationPercentile()
        {
            AssertContent("Aberration", 1, 5);
        }

        [Test]
        public void AnimalPercentile()
        {
            AssertContent("Animal", 6, 9);
        }

        [Test]
        public void ConstructPercentile()
        {
            AssertContent("Construct", 10, 16);
        }

        [Test]
        public void DragonPercentile()
        {
            AssertContent("Dragon", 17, 22);
        }

        [Test]
        public void ElementalPercentile()
        {
            AssertContent("Elemental", 23, 27);
        }

        [Test]
        public void FeyPercentile()
        {
            AssertContent("Fey", 28, 32);
        }

        [Test]
        public void GiantPercentile()
        {
            AssertContent("Giant", 33, 39);
        }

        [Test]
        public void AquaticHumanoidPercentile()
        {
            AssertContent("Aquatic-humanoid", 40);
        }

        [Test]
        public void DwarfPercentile()
        {
            AssertContent("Dwarf", 41, 42);
        }

        [Test]
        public void ElfPercentile()
        {
            AssertContent("Elf", 43, 44);
        }

        [Test]
        public void GnollPercentile()
        {
            AssertContent("Gnoll", 45);
        }

        [Test]
        public void GnomePercentile()
        {
            AssertContent("Gnome", 46);
        }

        [Test]
        public void GoblinoidPercentile()
        {
            AssertContent("Goblinoid", 47, 49);
        }

        [Test]
        public void HalflingPercentile()
        {
            AssertContent("Halfling", 50);
        }

        [Test]
        public void HumanPercentile()
        {
            AssertContent("Human", 51, 54);
        }

        [Test]
        public void ReptilianHumanoidPercentile()
        {
            AssertContent("Reptilian-humanoid", 55, 57);
        }

        [Test]
        public void OrcPercentile()
        {
            AssertContent("Orc", 58, 60);
        }

        [Test]
        public void MagicalBeastPercentile()
        {
            AssertContent("Magical-beast", 61, 65);
        }

        [Test]
        public void MonstrousHumanoidsPercentile()
        {
            AssertContent("Mounstrous-humanoid", 66, 70);
        }

        [Test]
        public void OozePercentile()
        {
            AssertContent("Ooze", 71, 72);
        }

        [Test]
        public void AirOutsiderPercentile()
        {
            AssertContent("Air-outsider", 73);
        }

        [Test]
        public void ChaoticOutsiderPercentile()
        {
            AssertContent("Chaotic-outsider", 74, 76);
        }

        [Test]
        public void EarthOutsiderPercentile()
        {
            AssertContent("Earth-outsider", 77);
        }

        [Test]
        public void EvilOutsiderPercentile()
        {
            AssertContent("Evil-outsider", 78, 80);
        }

        [Test]
        public void FireOutsiderPercentile()
        {
            AssertContent("Fire-outsider", 81);
        }

        [Test]
        public void GoodOutsiderPercentile()
        {
            AssertContent("Good-outsider", 82, 84);
        }

        [Test]
        public void LawfulOutsiderPercentile()
        {
            AssertContent("Lawful-outsider", 85, 87);
        }

        [Test]
        public void WaterOutsiderPercentile()
        {
            AssertContent("Water-outsider", 88);
        }

        [Test]
        public void PlantPercentile()
        {
            AssertContent("Plant", 89, 90);
        }

        [Test]
        public void UndeadPercentile()
        {
            AssertContent("Undead", 91, 98);
        }

        [Test]
        public void VerminPercentile()
        {
            AssertContent("Vermin", 99, 100);
        }
    }
}