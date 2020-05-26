using DnDGen.EventGen;
using DnDGen.TreasureGen.Items;
using DnDGen.TreasureGen.Items.Mundane;
using DnDGen.TreasureGen.Tests.Unit.Generators.Items;
using Ninject;
using NUnit.Framework;
using System;
using System.Linq;

namespace DnDGen.TreasureGen.Tests.Integration.Generators.Items.Mundane
{
    [TestFixture]
    public class MundaneWeaponGeneratorTests : IntegrationTests
    {
        [Inject, Named(ItemTypeConstants.Weapon)]
        public MundaneItemGenerator WeaponGenerator { get; set; }
        [Inject]
        public ClientIDManager ClientIDManager { get; set; }

        private ItemVerifier itemVerifier;

        [SetUp]
        public void Setup()
        {
            itemVerifier = new ItemVerifier();
            ClientIDManager.SetClientID(Guid.NewGuid());
        }

        [TestCase(WeaponConstants.Arrow)]
        [TestCase(WeaponConstants.BastardSword)]
        [TestCase(WeaponConstants.Battleaxe)]
        [TestCase(WeaponConstants.Bolas)]
        [TestCase(WeaponConstants.Club)]
        [TestCase(WeaponConstants.CompositeLongbow)]
        [TestCase(WeaponConstants.CompositePlus0Longbow)]
        [TestCase(WeaponConstants.CompositePlus0Shortbow)]
        [TestCase(WeaponConstants.CompositePlus1Longbow)]
        [TestCase(WeaponConstants.CompositePlus1Shortbow)]
        [TestCase(WeaponConstants.CompositePlus2Longbow)]
        [TestCase(WeaponConstants.CompositePlus2Shortbow)]
        [TestCase(WeaponConstants.CompositePlus3Longbow)]
        [TestCase(WeaponConstants.CompositePlus4Longbow)]
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
            var item = WeaponGenerator.Generate(itemName);
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
            var item = WeaponGenerator.Generate(itemName, "my trait", size);
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

            var item = WeaponGenerator.Generate(template);
            itemVerifier.AssertItem(item);
            Assert.That(item, Is.InstanceOf<Weapon>());

            var weapon = item as Weapon;
            Assert.That(weapon.Size, Is.EqualTo(size), weapon.Name);
            Assert.That(weapon.Traits, Does.Not.Contain(size)
                .And.SupersetOf(template.Traits.Take(2)), weapon.Name);
        }
    }
}
