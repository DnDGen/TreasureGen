using DnDGen.TreasureGen.Items;
using DnDGen.TreasureGen.Items.Mundane;
using DnDGen.TreasureGen.Tests.Unit.Generators.Items;
using NUnit.Framework;
using System.Linq;

namespace DnDGen.TreasureGen.Tests.Integration.Generators.Items.Mundane
{
    [TestFixture]
    public class MundaneWeaponGeneratorTests : IntegrationTests
    {
        private ItemVerifier itemVerifier;
        private MundaneItemGenerator weaponGenerator;

        [SetUp]
        public void Setup()
        {
            itemVerifier = new ItemVerifier();
            weaponGenerator = GetNewInstanceOf<MundaneItemGenerator>(ItemTypeConstants.Weapon);
        }

        [TestCase(WeaponConstants.Arrow)]
        [TestCase(WeaponConstants.BastardSword)]
        [TestCase(WeaponConstants.Battleaxe)]
        [TestCase(WeaponConstants.Bolas)]
        [TestCase(WeaponConstants.Club)]
        [TestCase(WeaponConstants.CompositeLongbow)]
        [TestCase(WeaponConstants.CompositeLongbow_StrengthPlus0)]
        [TestCase(WeaponConstants.CompositeShortbow_StrengthPlus0)]
        [TestCase(WeaponConstants.CompositeLongbow_StrengthPlus1)]
        [TestCase(WeaponConstants.CompositeShortbow_StrengthPlus1)]
        [TestCase(WeaponConstants.CompositeLongbow_StrengthPlus2)]
        [TestCase(WeaponConstants.CompositeShortbow_StrengthPlus2)]
        [TestCase(WeaponConstants.CompositeLongbow_StrengthPlus3)]
        [TestCase(WeaponConstants.CompositeLongbow_StrengthPlus4)]
        [TestCase(WeaponConstants.CompositeShortbow)]
        [TestCase(WeaponConstants.CrossbowBolt)]
        [TestCase(WeaponConstants.Dagger)]
        [TestCase(WeaponConstants.Dart)]
        [TestCase(WeaponConstants.DireFlail)]
        [TestCase(WeaponConstants.DwarvenUrgrosh)]
        [TestCase(WeaponConstants.DwarvenWaraxe)]
        [TestCase(WeaponConstants.Falchion)]
        [TestCase(WeaponConstants.Flail)]
        [TestCase(WeaponConstants.Gauntlet)]
        [TestCase(WeaponConstants.Glaive)]
        [TestCase(WeaponConstants.GnomeHookedHammer)]
        [TestCase(WeaponConstants.Greataxe)]
        [TestCase(WeaponConstants.Greatclub)]
        [TestCase(WeaponConstants.Greatsword)]
        [TestCase(WeaponConstants.Guisarme)]
        [TestCase(WeaponConstants.Halberd)]
        [TestCase(WeaponConstants.Handaxe)]
        [TestCase(WeaponConstants.HandCrossbow)]
        [TestCase(WeaponConstants.HeavyCrossbow)]
        [TestCase(WeaponConstants.HeavyFlail)]
        [TestCase(WeaponConstants.HeavyMace)]
        [TestCase(WeaponConstants.HeavyPick)]
        [TestCase(WeaponConstants.HeavyRepeatingCrossbow)]
        [TestCase(WeaponConstants.Javelin)]
        [TestCase(WeaponConstants.Kama)]
        [TestCase(WeaponConstants.Kukri)]
        [TestCase(WeaponConstants.Lance)]
        [TestCase(WeaponConstants.LightCrossbow)]
        [TestCase(WeaponConstants.LightHammer)]
        [TestCase(WeaponConstants.LightMace)]
        [TestCase(WeaponConstants.LightPick)]
        [TestCase(WeaponConstants.LightRepeatingCrossbow)]
        [TestCase(WeaponConstants.Longbow)]
        [TestCase(WeaponConstants.Longspear)]
        [TestCase(WeaponConstants.Longsword)]
        [TestCase(WeaponConstants.Morningstar)]
        [TestCase(WeaponConstants.Net)]
        [TestCase(WeaponConstants.Nunchaku)]
        [TestCase(WeaponConstants.OrcDoubleAxe)]
        [TestCase(WeaponConstants.PincerStaff)]
        [TestCase(WeaponConstants.PunchingDagger)]
        [TestCase(WeaponConstants.Quarterstaff)]
        [TestCase(WeaponConstants.Ranseur)]
        [TestCase(WeaponConstants.Rapier)]
        [TestCase(WeaponConstants.Sai)]
        [TestCase(WeaponConstants.Sap)]
        [TestCase(WeaponConstants.Scimitar)]
        [TestCase(WeaponConstants.Scythe)]
        [TestCase(WeaponConstants.Shortbow)]
        [TestCase(WeaponConstants.Shortspear)]
        [TestCase(WeaponConstants.ShortSword)]
        [TestCase(WeaponConstants.Shuriken)]
        [TestCase(WeaponConstants.Siangham)]
        [TestCase(WeaponConstants.Sickle)]
        [TestCase(WeaponConstants.Sling)]
        [TestCase(WeaponConstants.SlingBullet)]
        [TestCase(WeaponConstants.Spear)]
        [TestCase(WeaponConstants.SpikedChain)]
        [TestCase(WeaponConstants.SpikedGauntlet)]
        [TestCase(WeaponConstants.ThrowingAxe)]
        [TestCase(WeaponConstants.Trident)]
        [TestCase(WeaponConstants.TwoBladedSword)]
        [TestCase(WeaponConstants.Warhammer)]
        [TestCase(WeaponConstants.Whip)]
        public void GenerateWeapon(string itemName)
        {
            var item = weaponGenerator.Generate(itemName);
            itemVerifier.AssertItem(item);
        }

        [TestCase(WeaponConstants.Longsword, TraitConstants.Sizes.Colossal)]
        [TestCase(WeaponConstants.Longsword, TraitConstants.Sizes.Gargantuan)]
        [TestCase(WeaponConstants.Longsword, TraitConstants.Sizes.Huge)]
        [TestCase(WeaponConstants.Longsword, TraitConstants.Sizes.Large)]
        [TestCase(WeaponConstants.Longsword, TraitConstants.Sizes.Medium)]
        [TestCase(WeaponConstants.Longsword, TraitConstants.Sizes.Small)]
        [TestCase(WeaponConstants.Longsword, TraitConstants.Sizes.Tiny)]
        public void GenerateWeaponOfSize(string itemName, string size)
        {
            var item = weaponGenerator.Generate(itemName, "my trait", size);
            itemVerifier.AssertItem(item);
            Assert.That(item, Is.InstanceOf<Weapon>());

            var weapon = item as Weapon;
            Assert.That(weapon.Size, Is.EqualTo(size));
            Assert.That(weapon.Traits, Contains.Item("my trait")
                .And.Not.Contains(size));
        }

        [TestCase(WeaponConstants.Longsword, TraitConstants.Sizes.Colossal)]
        [TestCase(WeaponConstants.Longsword, TraitConstants.Sizes.Gargantuan)]
        [TestCase(WeaponConstants.Longsword, TraitConstants.Sizes.Huge)]
        [TestCase(WeaponConstants.Longsword, TraitConstants.Sizes.Large)]
        [TestCase(WeaponConstants.Longsword, TraitConstants.Sizes.Medium)]
        [TestCase(WeaponConstants.Longsword, TraitConstants.Sizes.Small)]
        [TestCase(WeaponConstants.Longsword, TraitConstants.Sizes.Tiny)]
        public void GenerateWeaponOfSize_FromTemplate(string itemName, string size)
        {
            var template = itemVerifier.CreateRandomWeaponTemplate(itemName);
            template.Traits.Add(size);

            var item = weaponGenerator.Generate(template);
            itemVerifier.AssertItem(item);
            Assert.That(item, Is.InstanceOf<Weapon>());

            var weapon = item as Weapon;
            Assert.That(weapon.Size, Is.EqualTo(size), weapon.Name);
            Assert.That(weapon.Traits, Does.Not.Contain(size)
                .And.SupersetOf(template.Traits.Take(2)), weapon.Name);
        }

        [TestCase(WeaponConstants.CompositeLongbow, WeaponConstants.Arrow)]
        [TestCase(WeaponConstants.CompositeLongbow_StrengthPlus0, WeaponConstants.Arrow)]
        [TestCase(WeaponConstants.CompositeLongbow_StrengthPlus1, WeaponConstants.Arrow)]
        [TestCase(WeaponConstants.CompositeLongbow_StrengthPlus2, WeaponConstants.Arrow)]
        [TestCase(WeaponConstants.CompositeLongbow_StrengthPlus3, WeaponConstants.Arrow)]
        [TestCase(WeaponConstants.CompositeLongbow_StrengthPlus4, WeaponConstants.Arrow)]
        [TestCase(WeaponConstants.CompositeShortbow, WeaponConstants.Arrow)]
        [TestCase(WeaponConstants.CompositeShortbow_StrengthPlus0, WeaponConstants.Arrow)]
        [TestCase(WeaponConstants.CompositeShortbow_StrengthPlus1, WeaponConstants.Arrow)]
        [TestCase(WeaponConstants.CompositeShortbow_StrengthPlus2, WeaponConstants.Arrow)]
        [TestCase(WeaponConstants.HandCrossbow, WeaponConstants.CrossbowBolt)]
        [TestCase(WeaponConstants.HeavyCrossbow, WeaponConstants.CrossbowBolt)]
        [TestCase(WeaponConstants.HeavyRepeatingCrossbow, WeaponConstants.CrossbowBolt)]
        [TestCase(WeaponConstants.LightCrossbow, WeaponConstants.CrossbowBolt)]
        [TestCase(WeaponConstants.LightRepeatingCrossbow, WeaponConstants.CrossbowBolt)]
        [TestCase(WeaponConstants.Longbow, WeaponConstants.Arrow)]
        [TestCase(WeaponConstants.Shortbow, WeaponConstants.Arrow)]
        [TestCase(WeaponConstants.Sling, WeaponConstants.SlingBullet)]
        public void GenerateWeaponWithAmmunition(string weaponName, string ammunition)
        {
            var item = weaponGenerator.Generate(weaponName);
            itemVerifier.AssertItem(item);
            Assert.That(item, Is.InstanceOf<Weapon>(), item.Name);

            var weapon = item as Weapon;
            Assert.That(weapon.Ammunition, Is.EqualTo(ammunition), item.Name);
        }
    }
}
