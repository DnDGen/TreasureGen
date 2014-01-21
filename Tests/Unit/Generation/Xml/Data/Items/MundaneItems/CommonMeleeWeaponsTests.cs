using NUnit.Framework;

namespace EquipmentGen.Tests.Unit.Generation.Xml.Data.Items.MundaneItems
{
    [TestFixture]
    public class CommonMeleeWeaponsTests : PercentileTests
    {
        [SetUp]
        public void Setup()
        {
            tableName = "CommonMeleeWeapons";
        }

        [Test]
        public void DaggerPercentile()
        {
            AssertContent("Dagger", 1, 4);
        }

        [Test]
        public void GreataxePercentile()
        {
            AssertContent("Greataxe", 5, 14);
        }

        [Test]
        public void GreatswordPercentile()
        {
            AssertContent("Greatsword", 15, 24);
        }

        [Test]
        public void KamaPercentile()
        {
            AssertContent("Kama", 25, 28);
        }

        [Test]
        public void LongswordPercentile()
        {
            AssertContent("Longsword", 29, 41);
        }

        [Test]
        public void LightMacePercentile()
        {
            AssertContent("Light mace", 42, 45);
        }

        [Test]
        public void HeavyMacePercentile()
        {
            AssertContent("Heavy mace", 46, 50);
        }

        [Test]
        public void NunchakuPercentile()
        {
            AssertContent("Nunchaku", 51, 54);
        }

        [Test]
        public void QuarterstaffPercentile()
        {
            AssertContent("Quarterstaff", 55, 57);
        }

        [Test]
        public void RapierPercentile()
        {
            AssertContent("Rapier", 58, 61);
        }

        [Test]
        public void ScimitarPercentile()
        {
            AssertContent("Scimitar", 62, 66);
        }

        [Test]
        public void ShortspearPercentile()
        {
            AssertContent("Shortspear", 67, 70);
        }

        [Test]
        public void SianghamPercentile()
        {
            AssertContent("Siangham", 71, 74);
        }

        [Test]
        public void BastardSwordPercentile()
        {
            AssertContent("Bastard sword", 75, 84);
        }

        [Test]
        public void ShortSwordPercentile()
        {
            AssertContent("Short sword", 85, 89);
        }

        [Test]
        public void DwarvenWaraxePercentile()
        {
            AssertContent("Dwarven waraxe", 90, 100);
        }
    }
}